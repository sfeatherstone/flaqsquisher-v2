/*
Copyright 2008-2011 Michael Brown

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FlacSquisher {
	class Encoder : BackgroundWorker {

		string flacPath;
		string outputPath;
		int encoderChoice;
		string options;
		int threadCount;
		Queue<FileInfo> jobQueue;
		BackgroundWorker bw;
		bool copyFiles;
		bool hidewin;
		List<String> ignoreList;
		List<String> copyList;

		string flacexe;
		string oggPath;
		string lamePath;
		string metaflacPath;

		bool thirdPartyLame;

		private static object lockObject = new object();

		private static Regex printableAscii = new Regex(@"[^\u0020-\u007E]", RegexOptions.Compiled);

		public Encoder() {
		}

		public Encoder(EncoderParams encoderParams, BackgroundWorker backworker) {
			EncoderParams args = encoderParams;
			flacPath = args.FlacDir;
			outputPath = args.OutputDir;
			encoderChoice = args.SelectedEncoder;
			options = args.CliParams;
			threadCount = args.Threads;
			jobQueue = args.JobQueue;
			copyFiles = args.CopyFiles;
			ignoreList = args.IgnoreList;
			copyList = args.CopyList;
			hidewin = args.Hidewin;
			thirdPartyLame = args.ThirdPartyLame;

			flacexe = args.FlacExe;
			oggPath = args.OggPath;
			lamePath = args.LamePath;
			metaflacPath = args.MetaflacPath;
			
			bw = backworker;
		}

		public void encoderThread() {
			try { // exception will occur when queue is empty
				FileInfo fi;
				// goes until the queue is empty
				while(jobQueue.Count > 0) {
					//lock(jobQueue) {
					lock(lockObject) {
						fi = jobQueue.Dequeue();
					}
					String consoleText = encodeFile(fi);

					EncoderResults results = new EncoderResults(String.Copy(fi.FullName), String.Copy(consoleText), jobQueue.Count);

					// increment "value" on the progress bar by one
					bw.ReportProgress(20, results);
				}
			}
			catch(Exception ex) {
				ex.ToString();
				//MessageBox::Show(e->ToString());
			}
			finally {

			}
		}

		public static object LockObject {
			get {
				return lockObject;
			}
		}

		// take the file file passed in, and encode it using the selected encoder and options
		public String encodeFile(FileInfo fi) {
			// get the portion of the path that will be shared by the source and destination paths
			string partialPath = fi.DirectoryName.Remove(0, flacPath.Length);
			string destPath;
			string coverArtPath = "";
			string consoleText = "";

			bool useTempFile = false; // temp files only used if we detect non-ASCII characters
			string encoderSourceFile = fi.FullName;
			string encoderDestFile;

			string dirSeperator = System.IO.Path.DirectorySeparatorChar.ToString();

			// copy the files with the extensions that we want to copy
			foreach(String ext in copyList) {
				if(fi.Name.ToLower().EndsWith(ext.ToLower())) {
					destPath = outputPath + partialPath + dirSeperator + fi.Name;

					if(File.Exists(destPath)) {
						return "";
					}

					if(!Directory.Exists(outputPath + partialPath)) {
						Directory.CreateDirectory(outputPath + partialPath);
					}

					File.Copy(fi.FullName, destPath);
					return "";
				}
			}

			if(encoderChoice == 0) {
				destPath = outputPath + partialPath + dirSeperator + fi.Name.Replace(".flac", ".ogg");
				// in case the input file is a FLAC file without an extension, add .ogg on the end
				if(!destPath.EndsWith(".ogg")) {
					destPath = destPath + ".ogg";
				}
			}
			else {
				destPath = outputPath + partialPath + dirSeperator + fi.Name.Replace(".flac", ".mp3");
				// in case the input file is a FLAC file without an extension, add .mp3 on the end
				if(!destPath.EndsWith(".mp3")) {
					destPath = destPath + ".mp3";
				}
			}
			// if the resulting path exists already, we don't need to encode again
			if(File.Exists(destPath)) {
				return "";
			}
			// LAME doesn't like to output to non-existent directories
			if(!Directory.Exists(outputPath + partialPath)) {
				Directory.CreateDirectory(outputPath + partialPath);
			}
			encoderDestFile = destPath;

			// call different things on the command line, depending on which encoder is being used
			ProcessStartInfo psi = new ProcessStartInfo();
			if(encoderChoice == 0) {
				// oggenc can take Flac files as input, so no decoding necessary
				psi.FileName = oggPath;
				psi.Arguments = "\"" + fi.FullName + "\" -o \"" + destPath + "\" " + options;
			}

			else {
				// LAME only has support for Extended ASCII, but to be safe we'll restrict it to printable ASCII
				// If the filename contains non-printable-ASCII characters, use a temporary file
				// http://stackoverflow.com/questions/1999566/string-filter-detect-non-ascii-signs
				if(printableAscii.IsMatch(fi.FullName)) {
					useTempFile = true;
					encoderSourceFile = Path.GetTempFileName();
					encoderDestFile = Path.GetTempFileName();
					File.Copy(fi.FullName, encoderSourceFile, true);
				}

				// LAME does not automatically tag MP3s encoded from FLACs like OggEnc does, so we need to use Metaflac and LAME's tag options
				ProcessStartInfo metaflacPsi = new ProcessStartInfo();
				metaflacPsi.FileName = metaflacPath;
				metaflacPsi.Arguments = "--no-utf8-convert --list \"" + encoderSourceFile + "\"";
				metaflacPsi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				metaflacPsi.CreateNoWindow = true;
				metaflacPsi.RedirectStandardOutput = true;
				metaflacPsi.UseShellExecute = false;
				metaflacPsi.StandardOutputEncoding = Encoding.UTF8;

				Process metaflacProcess = Process.Start(metaflacPsi);
				metaflacProcess.Start();
				StreamReader sOut = metaflacProcess.StandardOutput;
				String output = sOut.ReadToEnd();

				metaflacProcess.WaitForExit();
				sOut.Close();
				metaflacProcess.Close();

				// export the cover art to a randomly named file (to make sure we don't overwrite another file)
				//uint seedNum = (uint) new Random().Next();
				//coverArtPath = outputPath + partialPath + dirSeperator + seedNum;
				coverArtPath = Path.GetTempFileName();

				metaflacPsi = new ProcessStartInfo();
				metaflacPsi.FileName = metaflacPath;
				metaflacPsi.Arguments = "--no-utf8-convert --export-picture-to=\"" +
					coverArtPath + "\" \"" + encoderSourceFile + "\"";
				metaflacPsi.WindowStyle = ProcessWindowStyle.Hidden;
				metaflacPsi.CreateNoWindow = true;
				metaflacPsi.UseShellExecute = false;

				metaflacProcess = Process.Start(metaflacPsi);
				metaflacProcess.Start();
				metaflacProcess.WaitForExit();
				sOut.Close();
				metaflacProcess.Close();

				// Use regexs to extract information from the monolithic text file
				// First grab the artist name
				Regex regex = new Regex("comment\\[\\d+\\]: ARTIST=(.*)", RegexOptions.IgnoreCase);
				Match match = regex.Match(output);
				String artist = "";
				if(match.Success) {
					artist = match.Groups[1].Value;
					artist = artist.Trim();
				}
				// Next grab the track title
				regex = new Regex("comment\\[\\d+\\]: TITLE=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String title = "";
				if(match.Success) {
					title = match.Groups[1].Value;
					title = title.Trim();
				}
				// Next grab the album title
				regex = new Regex("comment\\[\\d+\\]: ALBUM=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String album = "";
				if(match.Success) {
					album = match.Groups[1].Value;
					album = album.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: DATE=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String date = "";
				if(match.Success) {
					date = match.Groups[1].Value;
					date = date.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: TRACKNUMBER=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String tracknum = "";
				if(match.Success) {
					tracknum = match.Groups[1].Value;
					tracknum = tracknum.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: GENRE=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String genre = "";
				if(match.Success) {
					genre = match.Groups[1].Value;
					genre = genre.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: ALBUM ARTIST=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String albumArtist = "";
				if(match.Success) {
					albumArtist = match.Groups[1].Value;
					albumArtist = albumArtist.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: DISCNUMBER=(.*)", RegexOptions.IgnoreCase);
				match = regex.Match(output);
				String discnum = "";
				if(match.Success) {
					discnum = match.Groups[1].Value;
					discnum = discnum.Trim();
				}

				// Add the tagging options to the command line
				String lameopts = options + " --ta \"" + artist + "\" --tt \"" + title + "\" --tl \"" + album + "\" --ty \""
					+ date + "\" --tn \"" + tracknum + "\" --tg \"" + genre + "\" ";

				if(albumArtist.Length > 0) {
					lameopts += "--tv \"TPE2=" + albumArtist + "\" ";
				}
				if(discnum.Length > 0) {
					lameopts += "--tv \"TPOS=" + discnum + "\" ";
				}

				if(File.Exists(coverArtPath)) {
					FileStream coverArtFile = File.OpenRead(coverArtPath);
					long length = coverArtFile.Length;
					if(0 < length && length < 128 * 1024) { // LAME will fail if we attempt to give it album art larger than 128KB
						lameopts += "--ti \"" + coverArtPath + "\" ";
					}
					coverArtFile.Close();
				}
				lameopts += "--add-id3v2 --ignore-tag-errors ";

				if(!hidewin) {
					lameopts += "--verbose ";
				}

				if(thirdPartyLame || BugWorkarounds.LameLibsndfileReturnsZero) {
					// The normal compile of LAME cannot take Flac files as
					// input, so we need to decode using flac.exe first
					psi.FileName = "cmd.exe";
					// "/s" switch allows us to give the arguments of "/c" inside quotes
					psi.Arguments = "/s /c \"\"" + flacexe + "\" -dc \"" + encoderSourceFile + "\" | \"" + lamePath + "\" " +
						lameopts + " - \"" + encoderDestFile + "\"\"";
				}
				else {
					// Since FlacSquisher 0.3.2, we've included the libsndfile .dll with Lame, so we can use
					// Flac files as input. (we didn't implement this until 0.5.6)
					psi.FileName = lamePath;

					psi.Arguments = lameopts;
					psi.Arguments += " \"" + encoderSourceFile + "\" \"" + encoderDestFile + "\"";
				}
			}

			if(hidewin) {
				psi.WindowStyle = ProcessWindowStyle.Hidden;
				psi.CreateNoWindow = true;
			}
			else {
				psi.WindowStyle = ProcessWindowStyle.Normal;
				psi.CreateNoWindow = false;
			}

			psi.RedirectStandardError = true;
			psi.UseShellExecute = false;

			System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);

			StreamReader sError = p.StandardError;
			String errorString = sError.ReadToEnd();

			// don't set a timeout, cause encoding could take a long time, depending on CPU speed, load, and file length
			p.WaitForExit();

			sError.Close();

			if(p.ExitCode != 0) {
				consoleText = errorString;
			}

			// close the process handle when it's exited
			p.Close();

			// if we imported the cover art, delete the temp file
			if(File.Exists(coverArtPath)) {
				File.Delete(coverArtPath);
			}

			if(useTempFile) {
				File.Move(encoderDestFile, destPath);
				File.Delete(encoderSourceFile);
			}

			return consoleText;
		}

	}
}
