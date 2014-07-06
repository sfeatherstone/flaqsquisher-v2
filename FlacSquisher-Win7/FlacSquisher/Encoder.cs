/*
Copyright 2008-2014 Michael Brown

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
		EncoderParams.EncoderChoice encoderChoice;
		string options;
		int threadCount;
		Queue<FileInfo> jobQueue;
		BackgroundWorker bw;
		bool copyFiles;
		bool hidewin;
		List<String> ignoreList;
		List<String> copyList;
		int maxImageSize;

		string flacexe;
		string oggPath;
		string lamePath;
		string metaflacPath;

		bool thirdPartyLame;
		EncoderParams.ReplayGainType replayGainType;
		#endregion

		#region Utility Variables
		string dirSeperator = System.IO.Path.DirectorySeparatorChar.ToString();
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
			replayGainType = args.GainType;
			maxImageSize = args.MaxImageSize;

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
			if(encoderChoice == EncoderParams.EncoderChoice.OggEnc) {
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

			if(encoderChoice == EncoderParams.EncoderChoice.OggEnc) {
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

			byte[] tag = new byte[3];
			try {
				int byteCount = fi.OpenRead().Read(tag, 0, 3);
			}
			catch(SystemException) { // Covers IOException and UnauthorizedAccessException
				return "The FLAC file can't be read; please check the permissions for the file.";
			}
			if(tag[0] == 'I' && tag[1] == 'D' && tag[2] == '3') {
				return "OggEnc does not support FLAC files that contain ID3 tags.";
			}
			
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

			p.Close();

			return consoleText;
		}

		private string encodeMp3File(FileInfo fi, string destPath) {
			string consoleText = "";
			string coverArtPath = "";
			string decodedTempFile = ""; // used if we're running on Unix, because I/O piping of external processes doesn't work the same
			string encoderSourceFile = fi.FullName;
			string encoderDestFile = destPath;

			ProcessStartInfo psi = new ProcessStartInfo();

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

			// Workaround for legacy JRiver software, which ends all Flac tags in null characters (this bug was fixed in 18.0.153)
			// http://sourceforge.net/p/flacsquisher/discussion/841928/thread/0ee9d24e/
			output = output.Replace("\0", "");
			// Escape quotes in the tags, so they don't mess up the command-line
			output = output.Replace("\"", "\\\"");

			// Use regexs to extract metadata piece-by-piece from the monolithic text output
			Regex regex = new Regex("comment\\[\\d+\\]: ARTIST=(.*)", RegexOptions.IgnoreCase);
			Match match = regex.Match(output);
			String artist = "";
			if(match.Success) {
				artist = match.Groups[1].Value;
				artist = artist.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: TITLE=(.*)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String title = "";
			if(match.Success) {
				title = match.Groups[1].Value;
				title = title.Trim();
			}
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
			regex = new Regex("comment\\[\\d+\\]: ALBUM\\s?ARTIST=(.*)", RegexOptions.IgnoreCase);
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
			regex = new Regex("comment\\[\\d+\\]: COMPOSER=(.*)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String composer = "";
			if(match.Success) {
				composer = match.Groups[1].Value;
				composer = composer.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: PUBLISHER=(.*)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String publisher = "";
			if(match.Success) {
				publisher = match.Groups[1].Value;
				publisher = publisher.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: COPYRIGHT=(.*)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String copyright = "";
			if(match.Success) {
				copyright = match.Groups[1].Value;
				copyright = copyright.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: replaygain_album_gain=(.*) dB", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String albumGain = "";
			if(match.Success) {
				albumGain = match.Groups[1].Value;
				albumGain = albumGain.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: replaygain_album_peak=(.*)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String albumPeak = "";
			if(match.Success) {
				albumPeak = match.Groups[1].Value;
				albumPeak = albumPeak.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: replaygain_track_gain=(.*) dB", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String trackGain = "";
			if(match.Success) {
				trackGain = match.Groups[1].Value;
				trackGain = trackGain.Trim();
			}
			regex = new Regex("comment\\[\\d+\\]: replaygain_track_peak=(.*)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			String trackPeak = "";
			if(match.Success) {
				trackPeak = match.Groups[1].Value;
				trackPeak = trackPeak.Trim();
			}

			String lameopts = options + " --ta \"" + artist + "\" --tt \"" + title + "\" --tl \"" + album + "\" --ty \""
				+ date + "\" --tn \"" + tracknum + "\" --tg \"" + genre + "\" ";

			if(albumArtist.Length > 0) {
				lameopts += "--tv \"TPE2=" + albumArtist + "\" ";
			}
			if(discnum.Length > 0) {
				lameopts += "--tv \"TPOS=" + discnum + "\" ";
			}
			if(composer.Length > 0) {
				lameopts += "--tv \"TCOM=" + composer + "\" ";
			}
			if(publisher.Length > 0) {
				lameopts += "--tv \"TPUB=" + publisher + "\" ";
			}
			if(copyright.Length > 0) {
				lameopts += "--tv \"TCOP=" + copyright + "\" ";
			}

			// Lame Tag is put on by default
			if(replayGainType == EncoderParams.ReplayGainType.ID3Tag) {
				lameopts += "--tv \"TXXX=replaygain_album_gain=" + albumGain + " dB\" ";
				lameopts += "--tv \"TXXX=replaygain_album_peak=" + albumPeak + "\" ";
				lameopts += "--tv \"TXXX=replaygain_track_gain=" + trackGain + " dB\" ";
				lameopts += "--tv \"TXXX=replaygain_track_peak=" + trackPeak + "\" ";
			}
			else if(replayGainType == EncoderParams.ReplayGainType.None) {
				lameopts += "--noreplaygain ";
			}
			else if(replayGainType == EncoderParams.ReplayGainType.Album) {
				if(albumGain.Length > 0 && albumGain[0] == '-') {
					lameopts += "--gain " + albumGain + " ";
				}
			}
			else if(replayGainType == EncoderParams.ReplayGainType.Track) {
				if(trackGain.Length > 0 && trackGain[0] == '-') {
					lameopts += "--gain " + trackGain + " ";
				}
			}

			regex = new Regex("type: 6 \\(PICTURE\\)", RegexOptions.IgnoreCase);
			match = regex.Match(output);
			if(match.Success) {
				// export the cover art to a randomly named file (to make sure we don't overwrite another file)
				try {
					coverArtPath = Path.GetTempFileName();
				}
				catch(IOException) { // The encoding can continue without cover art, but let the user know
					consoleText += "FlacSquisher was unable to create a temporary file, so no cover art was carried " + 
						"over. Deleting some files in the temporary folder may fix this.";
				}

				if(File.Exists(coverArtPath)) {
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

					// LAME used to have a limit of 128KB for embedded art; as of 3.99 it doesn't have that
					// restriction, and seems to be able to accept much larger images. Foobar2000 will only
					// embed up to 16MB in a Flac file, so that seems like a good cut-off point.
					// The real problem is that the Metaflac list process will fill FlacSquisher's memory space
					// when handling album art even larger than that (tested using 37MB jpeg).
					FileInfo coverArtInfo = new FileInfo(coverArtPath);
					long length = coverArtInfo.Length;
					if(0 < length && length < maxImageSize * 1024) {
						lameopts += "--ti \"" + coverArtPath + "\" ";
					}
				}
			}

			lameopts += "--add-id3v2 --ignore-tag-errors ";

			if(!hidewin) {
				lameopts += "--verbose ";
			}

			if(System.Environment.OSVersion.Platform == PlatformID.Unix || System.Environment.OSVersion.Platform == PlatformID.MacOSX) {
				// Mono can't create cmd.exe, so as far as I can tell we can't do I/O piping from inside Unix environments
				try {
					decodedTempFile = Path.GetTempFileName();
				}
				catch(IOException) {
					return "FlacSquisher was unable to create a temporary file, so the encoding process failed. Deleting some files in the temporary folder may fix this.";
				}

				ProcessStartInfo flacPsi = new ProcessStartInfo();
				flacPsi.FileName = flacexe;
				flacPsi.Arguments = " -df -o \"" + decodedTempFile + "\" \"" + encoderSourceFile + "\"";
				flacPsi.WindowStyle = ProcessWindowStyle.Hidden;
				flacPsi.CreateNoWindow = true;
				flacPsi.UseShellExecute = false;
				flacPsi.RedirectStandardError = true;

				Process flacProcess = Process.Start(flacPsi);

				StreamReader flacError = flacProcess.StandardError;
				String flacErrorString = flacError.ReadToEnd();

				flacProcess.WaitForExit();
				flacError.Close();

				if(flacProcess.ExitCode != 0) {
					consoleText = flacErrorString;
				}

				flacProcess.Close();

				psi.FileName = lamePath;

				psi.Arguments = lameopts;
				psi.Arguments += " \"" + decodedTempFile + "\" " + lameopts + " \"" + encoderDestFile + "\"";
			}
			else if(thirdPartyLame || BugWorkarounds.LameLibsndfileReturnsZero) {
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
				consoleText += errorString;
			}

			p.Close();

			// if we imported the cover art, delete the temp file
			if(File.Exists(coverArtPath)) {
				File.Delete(coverArtPath);
			}

			if(File.Exists(decodedTempFile)) {
				File.Delete(decodedTempFile);
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
