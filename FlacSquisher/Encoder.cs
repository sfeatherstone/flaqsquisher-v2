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

		string flacexe;
		string oggPath;
		string lamePath;
		string metaflacPath;

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
			hidewin = args.Hidewin;

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
					lock(jobQueue) {
						fi = jobQueue.Dequeue();
					}
					encodeFile(fi);

					// increment "value" on the progress bar by one
					bw.ReportProgress(20, jobQueue.Count);
				}
			}
			catch(Exception ex) {
				ex.ToString();
				//MessageBox::Show(e->ToString());
			}
			finally {

			}
		}

		// take the file file passed in, and encode it using the selected encoder and options
		public void encodeFile(FileInfo fi) {
			// get the portion of the path that will be shared by the source and destination paths
			string partialPath = fi.DirectoryName.Remove(0, flacPath.Length);
			string destPath;

			string dirSeperator = System.IO.Path.DirectorySeparatorChar.ToString();

			// copy the ignored files, if the settings allow it
			if(copyFiles) {
				foreach(String ext in ignoreList) {
					if(fi.Name.ToLower().EndsWith(ext.ToLower())) {
						destPath = outputPath + partialPath + dirSeperator + fi.Name;

						if(File.Exists(destPath)) {
							return;
						}

						if(!Directory.Exists(outputPath + partialPath)) {
							Directory.CreateDirectory(outputPath + partialPath);
						}

						File.Copy(fi.FullName, destPath);
					}
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
				return;
			}
			// LAME doesn't like to output to non-existent directories
			if(!Directory.Exists(outputPath + partialPath)) {
				Directory.CreateDirectory(outputPath + partialPath);
			}

			// call different things on the command line, depending on which encoder is being used
			ProcessStartInfo psi = new ProcessStartInfo();
			if(encoderChoice == 0) {
				// oggenc can take Flac files as input, so no decoding necessary
				psi.FileName = oggPath;
				psi.Arguments = "\"" + fi.FullName + "\" -o \"" + destPath + "\" " + options;
			}

			else {
				// LAME does not automatically tag MP3s encoded from FLACs like OggEnc does, so we need to use Metaflac and LAME's tag options
				ProcessStartInfo metaflacPsi = new ProcessStartInfo();
				metaflacPsi.FileName = metaflacPath;
				metaflacPsi.Arguments = "--list \"" + fi.FullName + "\"";
				metaflacPsi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				metaflacPsi.CreateNoWindow = true;
				metaflacPsi.RedirectStandardOutput = true;
				metaflacPsi.UseShellExecute = false;

				Process metaflacProcess = Process.Start(metaflacPsi);
				metaflacProcess.Start();
				StreamReader sOut = metaflacProcess.StandardOutput;
				String output = sOut.ReadToEnd();

				metaflacProcess.WaitForExit();
				sOut.Close();
				metaflacProcess.Close();

				// Use regexs to extract information from the monolithic text file
				// First grab the artist name
				Regex regex = new Regex("comment\\[\\d+\\]: ARTIST=(.*)");
				Match match = regex.Match(output);
				String artist = "";
				if(match.Success) {
					artist = match.Groups[1].Value;
					artist = artist.Trim();
				}
				// Next grab the track title
				regex = new Regex("comment\\[\\d+\\]: TITLE=(.*)");
				match = regex.Match(output);
				String title = "";
				if(match.Success) {
					title = match.Groups[1].Value;
					title = title.Trim();
				}
				// Next grab the album title
				regex = new Regex("comment\\[\\d+\\]: ALBUM=(.*)");
				match = regex.Match(output);
				String album = "";
				if(match.Success) {
					album = match.Groups[1].Value;
					album = album.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: DATE=(.*)");
				match = regex.Match(output);
				String date = "";
				if(match.Success) {
					date = match.Groups[1].Value;
					date = date.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: TRACKNUMBER=(.*)");
				match = regex.Match(output);
				String tracknum = "";
				if(match.Success) {
					tracknum = match.Groups[1].Value;
					tracknum = tracknum.Trim();
				}
				regex = new Regex("comment\\[\\d+\\]: GENRE=(.*)");
				match = regex.Match(output);
				String genre = "";
				if(match.Success) {
					genre = match.Groups[1].Value;
					genre = genre.Trim();
				}

				// Add the tagging options to the command line
				String lameopts = options + " --ta \"" + artist + "\" --tt \"" + title + "\" --tl \"" + album + "\" --ty \""
					+ date + "\" --tn \"" + tracknum + "\" --tg \"" + genre + "\" --add-id3v2 --ignore-tag-errors ";

				// LAME cannot take Flac files as input as of 3.97, so we need to decode using flac.exe first
				psi.FileName = "cmd.exe";
				// "/s" switch allows us to give the arguments of "/c" inside quotes
				psi.Arguments = "/s /c \"\"" + flacexe + "\" -dc \"" + fi.FullName + "\" | \"" + lamePath + "\" " + lameopts + " --verbose - \"" + destPath + "\"\"";
			}

			if(hidewin) {
				psi.WindowStyle = ProcessWindowStyle.Hidden;
				psi.CreateNoWindow = true;
			}
			else {
				psi.WindowStyle = ProcessWindowStyle.Normal;
				psi.CreateNoWindow = false;
			}

			//psi.UseShellExecute = false;
			System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);


			// don't set a timeout, cause encoding could take a long time, depending on CPU speed, load, and file length
			p.WaitForExit();

			// close the process handle when it's exited
			p.Close();
		}

	}
}
