﻿/*
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

		#region Argument Copies
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
		#endregion

		#region Utility Variables
		string dirSeperator = System.IO.Path.DirectorySeparatorChar.ToString();
		private static Regex printableAscii = new Regex(@"[^\u0020-\u007E]", RegexOptions.Compiled);
		#endregion

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

		private static object lockObject = new object();
		public static object LockObject {
			get {
				return lockObject;
			}
		}

		public void encoderThread() {
			FileInfo fi = null;
			while(jobQueue.Count > 0) {
				try {
					lock(lockObject) {
						fi = jobQueue.Dequeue();
					}
				}
				// this type of exception will occur when queue is empty on dequeue -- just in case the lock
				// isn't sufficient, we don't want that condition to be fatal
				catch(InvalidOperationException) {
				}
				String consoleText = encodeFile(fi);

				EncoderResults results = new EncoderResults(String.Copy(fi.FullName), String.Copy(consoleText), jobQueue.Count);

				// increment "value" on the progress bar by one
				bw.ReportProgress(20, results);
			}
		}

		/// <summary>
		/// Take the file file passed in, and encode it using the selected encoder and options
		/// </summary>
		/// <param name="fi">The FileInfo object of the file to be encoded</param>
		/// <returns>Empty string if successful, otherwise the console output</returns>
		private String encodeFile(FileInfo fi) {
			// get the portion of the path that will be shared by the source and destination paths
			string partialPath = fi.DirectoryName.Remove(0, flacPath.Length);
			string destPath;
			string consoleText = "";

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

			string extension;
			if(encoderChoice == 0) {
				extension = ".ogg";
			}
			else {
				extension = ".mp3";
			}
			destPath = buildDestPath(fi, partialPath, extension);

			// if the resulting path exists already, we don't need to encode again
			if(File.Exists(destPath)) {
				return "";
			}
			// LAME doesn't like to output to non-existent directories
			if(!Directory.Exists(outputPath + partialPath)) {
				Directory.CreateDirectory(outputPath + partialPath);
			}

			if(encoderChoice == 0) {
				consoleText = encodeOggFile(fi, destPath);
			}
			else {
				consoleText = encodeMp3File(fi, destPath);
			}

			return consoleText;
		}

		private string encodeOggFile(FileInfo fi, string destPath) {
			string consoleText = "";

			ProcessStartInfo psi = new ProcessStartInfo();
			
			// oggenc can take Flac files as input, so no decoding necessary
			psi.FileName = oggPath;
			psi.Arguments = "\"" + fi.FullName + "\" -o \"" + destPath + "\" " + options;

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

			return consoleText;
		}

		private string encodeMp3File(FileInfo fi, string destPath) {
			string consoleText = "";
			string coverArtPath = "";
			bool useTempFile = false; // temp files only used if we detect non-ASCII characters
			string encoderSourceFile = fi.FullName;
			string encoderDestFile = destPath;

			// call different things on the command line, depending on which encoder is being used
			ProcessStartInfo psi = new ProcessStartInfo();

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

			regex = new Regex("type: 6 \\(PICTURE\\)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			if(match.Success) {
				// export the cover art to a randomly named file (to make sure we don't overwrite another file)
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

				if(File.Exists(coverArtPath)) {
					FileStream coverArtFile = File.OpenRead(coverArtPath);
					long length = coverArtFile.Length;
					if(0 < length && length < 128 * 1024) { // LAME will fail if we attempt to give it album art larger than 128KB
						lameopts += "--ti \"" + coverArtPath + "\" ";
					}
					coverArtFile.Close();
				}
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

		private string buildDestPath(FileInfo fi, string partialPath, string extension) {
			string destPath;
			destPath = outputPath + partialPath + dirSeperator + fi.Name.Replace(".flac", extension);
			// in case the input file is a FLAC file without an extension, add the extension on the end
			if(!destPath.EndsWith(extension)) {
				destPath = destPath + extension;
			}
			return destPath;
		}

	}
}
