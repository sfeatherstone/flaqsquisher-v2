// FlacSquisher - A utility to convert a directory of Flac audio files
// to MP3 or Ogg Vorbis format, preserving the directory structure of
// the Flac files

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace FlacSquisher {
	public partial class FlacSquisher : Form {

		public string dirSeparator = System.IO.Path.DirectorySeparatorChar.ToString();

		String settingsPath;
		String newSettingsPath;
		String oggPath;
		String flacexe;
		String lamePath;
		String metaflacPath;
		String ignoredExts;
		String copiedExts;
		bool hidewin;

		String flacPath;
		String outputPath;
		String options;
		bool copyFiles;
		bool thirdPartyLame;
		int encoderChoice;
		bool autoUpdate;

		int majorv;
		int minorv;
		int rev;

		ReaderWriterLock rwl = new ReaderWriterLock();
		List<String> ignoreList;
		List<String> copyList;

		bool consoleMessagesQueued = false;
		List<EncoderResults> resultsList;
		private static object lockObject = new object();
		Queue<FileInfo> jobQueue;
		bool encodeInProgress = false;
		bool encodeAborted = false;
		int abortedQueueSize;

		public FlacSquisher() {
			InitializeComponent();

			// set the default (and maximum) number of threads to the
			// number of logical cores in the CPU
			threadCounter.Value = System.Environment.ProcessorCount;
			threadCounter.Maximum = threadCounter.Value;

			// add encoder types to the drop-down box
			encoder.Items.Add("OggEnc2 (Ogg Vorbis)");
			encoder.Items.Add("Lame (mp3)");

			settingsPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "config.cfg";
			newSettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + dirSeparator + "FlacSquisher" + dirSeparator + "config.cfg";

			if(File.Exists(newSettingsPath)) { // check if new config file exists
				loadSettingsFile(newSettingsPath);
			}
			else if(File.Exists(settingsPath)) { // if the new file doesn't exist, we've just upgraded from an old version
				loadSettingsFile(settingsPath);
			}
			else { // load defaults (in executable's directory) if config file does not exist
				oggPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "oggenc.exe";
				flacexe = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "flac.exe";
				lamePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "lame.exe";
				metaflacPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "metaflac.exe";
				ignoredExts = "txt log pdf cue mp3 mp4 flv";
				copiedExts = "jpg png";
				hidewin = true;
				thirdPartyLame = false;
				autoUpdate = false;
			}

			// needed for users who upgrade from an old version that didn't have metaflac
			if(String.IsNullOrEmpty(metaflacPath)) {
				metaflacPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "metaflac.exe";
			}
			if(copiedExts == null) {
				copiedExts = "";
			}

			// if we aren't checking for updates, then it's unlikely this will show on-screen at all
			encodeStatus.Text = "Checking for updates...";
			encodeProgress.Width = 1;
			encodeProgress.Visible = false;

			//majorv = 0;
			//minorv = 5;
			//rev = 5;

			System.Reflection.Assembly assem = System.Reflection.Assembly.GetExecutingAssembly();
			string[] resNames = assem.GetManifestResourceNames();

			foreach(string assemName in resNames) {
				if(assemName.EndsWith("ico")) {
					Stream iconStream = assem.GetManifestResourceStream(assemName);
					this.Icon = new Icon(iconStream);
					iconStream.Close();
					break;
				}
			}


			// we only use 3 fields of the version number, unlike .NET's built-in
			// 4 fields, so for "rev" we use the "build" field
			majorv = System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version.Major;
			minorv = System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version.Minor;
			rev = System.Reflection.Assembly.GetAssembly(this.GetType()).GetName().Version.Build;

			this.Text = "FlacSquisher v" + majorv + "." + minorv + "." + rev;

			if(autoUpdate) {
				checkForUpdates(false);
			}
			encodeStatus.Text = "Ready";
		}

		/// <summary>
		/// called on initialization to restore the settings from the last session (called only if the config file exists)
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private int loadSettingsFile(String filePath) {
			try {
				StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
				string temp;
				flacDir.Text = sr.ReadLine();
				outputDir.Text = sr.ReadLine();
				temp = sr.ReadLine();
				if(!string.IsNullOrEmpty(temp)) {
					encoder.SelectedIndex = Convert.ToInt32(temp);
				}
				oggPath = sr.ReadLine();
				flacexe = sr.ReadLine();
				lamePath = sr.ReadLine();
				cliParams.Text = sr.ReadLine();
				temp = sr.ReadLine();
				if(!string.IsNullOrEmpty(temp)) {
					hidewin = bool.Parse(temp);
				}
				ignoredExts = sr.ReadLine();
				temp = sr.ReadLine();
				if(!string.IsNullOrEmpty(temp)) {
					copyFiles = bool.Parse(temp);
				}
				metaflacPath = sr.ReadLine();
				copiedExts = sr.ReadLine();
				temp = sr.ReadLine();
				if(!string.IsNullOrEmpty(temp)) {
					thirdPartyLame = bool.Parse(temp);
				}
				temp = sr.ReadLine();
				if(!string.IsNullOrEmpty(temp)) {
					autoUpdate = bool.Parse(temp);
				}
				sr.Close();
				return 1;
			}
			catch(Exception) { // any settings loaded before the error remain -- this may or may not be desired
				MessageBox.Show("The configuration file was not read in properly. This sometimes happens when upgrading from an earlier version. Please ensure that your settings were imported properly.",
						"Configuration file error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				return 0;
			}
		}

		// called on formClose to save settings from this session
		private int saveSettingsFile(String filePath) {
			try {
				if(!File.Exists(filePath)) { // now that we use %AppData%\FlacSquisher, make sure it exists
					Directory.CreateDirectory(filePath.Remove(filePath.LastIndexOf("config.cfg")));
				}
				StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8); // false is "Don't append"
				sw.Write(flacDir.Text + Environment.NewLine);
				sw.Write(outputDir.Text + Environment.NewLine);
				sw.Write(encoder.SelectedIndex + Environment.NewLine);
				sw.Write(oggPath + Environment.NewLine);
				sw.Write(flacexe + Environment.NewLine);
				sw.Write(lamePath + Environment.NewLine);
				sw.Write(cliParams.Text + Environment.NewLine);
				sw.Write(hidewin.ToString() + Environment.NewLine);
				sw.Write(ignoredExts.ToString() + Environment.NewLine);
				sw.Write(copyFiles.ToString() + Environment.NewLine);
				sw.Write(metaflacPath + Environment.NewLine);
				sw.Write(copiedExts.ToString() + Environment.NewLine);
				sw.Write(thirdPartyLame.ToString() + Environment.NewLine);
				sw.Write(autoUpdate.ToString());
				sw.Close();
				return 1;
			}
			catch(Exception ex) { // any errors are likely discovered on attempting to open the file, so most likely nothing is written
				MessageBox.Show("The config file was not written properly. Please report this to the application owners: " + ex.ToString());
				return 0;
			}

		}

		// called by File->Exit menu item
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		// called by Exit button on form
		private void exitButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void FlacSquisher_FormClosed(object sender, FormClosedEventArgs e) {
			saveSettingsFile(newSettingsPath);
		}

		// chooses "source" directory containing Flac files to be recoded
		private void flacDirButton_Click(object sender, EventArgs e) {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if(Directory.Exists(flacDir.Text)) {
				// clean up and resolve all parts of the path, such as "\..\", before passing the path
				DirectoryInfo dirInfo = new DirectoryInfo(flacDir.Text);
				fbd.SelectedPath = dirInfo.FullName;
			}
			if(fbd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
				flacDir.Text = fbd.SelectedPath;
			}
		}

		// chooses "destination" directory to contain files output by the recoding
		private void outputDirButton_Click(object sender, EventArgs e) {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if(Directory.Exists(outputDir.Text)) {
				// clean up and resolve all parts of the path, such as "\..\", before passing the path
				DirectoryInfo dirInfo = new DirectoryInfo(outputDir.Text);
				fbd.SelectedPath = dirInfo.FullName;
			}
			if(fbd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
				outputDir.Text = fbd.SelectedPath;
			}
		}

		// if encoder is changed, load default command-line options for that encoder
		private void encoder_SelectedIndexChanged(object sender, EventArgs e) {
			if(encoder.SelectedIndex == 0) {
				cliParams.Text = "-q 6"; // oggenc options
			}
			else {
				cliParams.Text = "-V2 --vbr-new -q0"; // lame options
			}
		}

		// called with "Encode" button -- queues files in the "source" directory to be processed,
		// then starts 'n' encoding threads to process the queue
		private void encodeButton_Click(object sender, EventArgs e) {
			// disable encodeButton until we finish processing the button press
			encodeButton.Enabled = false;
			if(encodeInProgress) {
				encodeButton.Text = "Stopping...";
				encodeAborted = true;
				lock(lockObject) {
					abortedQueueSize = jobQueue.Count;
					jobQueue.Clear();
				}
			}
			else {
				encodeInProgress = true;
				encode();
			}
		}

		public void encode() {
			// this section should be kept in case of bad config files, etc.
			if(encoder.SelectedIndex == 0) {
				if(String.IsNullOrEmpty(oggPath)) {
					oggPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "oggenc.exe";
				}
			}
			else {
				if(String.IsNullOrEmpty(lamePath)) {
					lamePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "lame.exe";
				}
				if(String.IsNullOrEmpty(flacexe)) {
					flacexe = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "flac.exe";
				}
			}

			// set up status bar
			encodeStatus.Text = "Recursing directories...";
			encodeProgress.Width = 175; // this seems to change the width in Mono, but only the Designer seems to affect the width in Windows
			encodeProgress.Value = 0;
			encodeProgress.MarqueeAnimationSpeed = 50;
			encodeProgress.Style = ProgressBarStyle.Marquee;
			encodeProgress.Visible = true;

			encodeAborted = false;

			ignoreList = new List<String>();
			String[] split = ignoredExts.Split(' ');
			if(!String.IsNullOrEmpty(ignoredExts)) {
				ignoreList.AddRange(split);
			}

			copyList = new List<String>();
			split = copiedExts.Split(' ');
			if(!String.IsNullOrEmpty(copiedExts)) {
				copyList.AddRange(split);
			}

			// make sure source and destination directories are given
			if(String.IsNullOrEmpty(flacDir.Text) || String.IsNullOrEmpty(outputDir.Text)) {
				MessageBox.Show("The Flac directory and destination directory must both be specified", "Specify directories", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				encodeStatus.Text = "Ready";
				encodeProgress.Visible = false;
				encodeButton.Enabled = true;
				return;
			}

			// make sure source directory exists
			if(!Directory.Exists(flacDir.Text)) {
				MessageBox.Show("The source directory does not exist.", "Non-existent source directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				encodeStatus.Text = "Ready";
				encodeProgress.Visible = false;
				encodeButton.Enabled = true;
				return;
			}

			resultsList = new List<EncoderResults>();

			if(TaskbarManager.IsPlatformSupported) {
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
			}

			String flacDirString = flacDir.Text;
			if(flacDirString.EndsWith(dirSeparator)) {
				flacDirString = flacDirString.TrimEnd(new char[1] { System.IO.Path.DirectorySeparatorChar });
			}
			String outputDirString = outputDir.Text;
			if(outputDirString.EndsWith(dirSeparator)) {
				outputDirString = outputDirString.TrimEnd(new char[1] { System.IO.Path.DirectorySeparatorChar });
			}

			FolderRecurser recurser = new FolderRecurser(flacDirString, ignoreList.ToArray(), copyList.ToArray(), copyFiles, rwl);

			int threads;
			rwl.AcquireWriterLock(-1); // -1 == wait forever for the lock
			try {
				threads = (int)threadCounter.Value; // Value is a System::Decimal, hence the cast
			}
			finally {
				rwl.ReleaseWriterLock();
			}

			EncoderParams args = new EncoderParams();

			args.Recurser = recurser;
			args.FlacDir = flacDirString;
			args.OutputDir = outputDirString;
			args.SelectedEncoder = encoder.SelectedIndex;
			args.CliParams = cliParams.Text;
			args.Threads = threads;
			args.CopyFiles = copyFiles;
			args.FlacExe = flacexe;
			args.OggPath = oggPath;
			args.LamePath = lamePath;
			args.MetaflacPath = metaflacPath;
			args.Hidewin = hidewin;
			args.IgnoreList = ignoreList;
			args.CopyList = copyList;
			args.ThirdPartyLame = thirdPartyLame;
			args.GainType = EncoderParams.ReplayGainType.LameTag;

			this.recursingBackgroundWorker1.RunWorkerAsync(args);
		}

		public void updateProgressBar() {
			// min() included for bounds checking, lock needed to prevent count being "short"
			encodeProgress.Value = Math.Min((encodeProgress.Value + 1), encodeProgress.Maximum);

			// update the status text
			encodeStatus.Text = encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";
		}

		public void enableEncodeButton() {
			encodeButton.Enabled = true;
		}

		private void recursingBackgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
			/*FolderRecurser recurser = new FolderRecurser(flacDir.Text, ignoreList.ToArray(), copyFiles, rwl);

			Thread recurserThread = new Thread(new ThreadStart(recurser.recurseDirs));
			recurserThread.IsBackground = false;
			recurserThread.Start();

			while(recurserThread.IsAlive) {
			}
			recurserThread.Join();*/

			BackgroundWorker bw = sender as BackgroundWorker;

			EncoderParams args = (EncoderParams) e.Argument;

			FolderRecurser recurser = args.Recurser;

			recurser.recurseDirs();

			args.JobQueue = recurser.getJobQueue();
			jobQueue = args.JobQueue;

			e.Result = args;

			bw.ReportProgress(20, args.JobQueue.Count);
		}

		private void recursingBackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			encodeProgress.Style = ProgressBarStyle.Continuous;
			encodeProgress.Value = 0;
			encodeProgress.Maximum = (int)e.UserState;

			encodeButton.Text = "Stop";
			encodeButton.Enabled = true;

			if(TaskbarManager.IsPlatformSupported) {
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
				TaskbarManager.Instance.SetProgressValue(0, (int)e.UserState);
			}
		}

		private void recursingBackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			this.encodingBackgroundWorker2.RunWorkerAsync(e.Result);
		}

		private void encodingBackgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker bw = sender as BackgroundWorker;

			EncoderParams args = (EncoderParams) e.Argument;

			EncoderResults results = new EncoderResults("", "", args.JobQueue.Count);
			bw.ReportProgress(0, results);

			//encodeStatus.Text = "Setting up threads...";

			// set up encoder
			Encoder encoderManager = new Encoder(args, bw);

			List<Thread> threadList = new List<Thread>();

			// set up 'n' threads for processing the queue
			for(int i = 0; i < args.Threads; i++) {
				Thread encoderThread = new Thread(
					new ThreadStart(encoderManager.encoderThread));
				encoderThread.IsBackground = true;
				threadList.Add(encoderThread);

				// Start the thread.
				encoderThread.Start();

			}

			for(int i = 0; i < args.Threads; i++) {
				threadList[i].Join();
			}
		}

		private void encodingBackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			EncoderResults results = (EncoderResults)e.UserState;
			int queuesize = results.QueueCount;
			if(!String.IsNullOrEmpty(results.ConsoleText)) {
				consoleMessagesQueued = true;
				lock(lockObject) {
					resultsList.Add(results);
				}
			}

			// need to account for files the other threads are currently encoding
			int otherThreads = (int)threadCounter.Value - 1;
			int maximum = encodeProgress.Maximum;
			if(encodeAborted) {
				queuesize = abortedQueueSize;
			}
			int progress = maximum - (queuesize + otherThreads);

			encodeProgress.Style = ProgressBarStyle.Continuous;

			// max() included so that the progress never goes backwards
			progress = Math.Max(encodeProgress.Value, progress);
			// min() included for bounds checking
			encodeProgress.Value = Math.Min((progress), encodeProgress.Maximum);

			// update the status text
			encodeStatus.Text = "" + encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";

			if(TaskbarManager.IsPlatformSupported) {
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
				TaskbarManager.Instance.SetProgressValue(progress, encodeProgress.Maximum);
			}

			// refresh the window, just in case
			this.Refresh();
		}

		private void encodingBackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			int endProgress = encodeProgress.Maximum;
			if(encodeAborted) {
				endProgress = encodeProgress.Maximum - abortedQueueSize;
			}
			encodeProgress.Value = endProgress;

			// update the status text
			encodeStatus.Text = "" + encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";

			encodeButton.Text = "Encode!";
			encodeButton.Enabled = true;
			encodeInProgress = false;

			if(TaskbarManager.IsPlatformSupported) {
				TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
				TaskbarManager.Instance.SetProgressValue(encodeProgress.Value, encodeProgress.Maximum);
			}

			if(consoleMessagesQueued) {
				ConsoleWindow consoleWin = new ConsoleWindow();
				consoleWin.AddResults(resultsList);
				consoleWin.ShowDialog(this);
			}
		}

		// send them to the project forums page
		private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://sourceforge.net/projects/flacsquisher/forums");
		}

		// this method checks with the project webserver to see if there's a newer version
		private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
			checkForUpdates(true);
		}

		/// <summary>
		/// Checks with the project webserver to see if there's a newer version available
		/// </summary>
		private void checkForUpdates(bool reportOnNoNewVersion) {
			try {
				WebRequest req = WebRequest.Create("http://flacsquisher.sourceforge.net/latest.txt");
				WebResponse resp = req.GetResponse();
				StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
				String newest = sr.ReadLine();
				int firstperiod = newest.IndexOf(".");
				int lastperiod = newest.LastIndexOf(".");
				int newmajor = int.Parse(newest.Substring(0, firstperiod));
				int newminor = int.Parse(newest.Substring(firstperiod + 1, lastperiod - firstperiod - 1));
				int newrev = int.Parse(newest.Substring(lastperiod + 1));
				if(majorv < newmajor || (majorv == newmajor && minorv < newminor) || (majorv == newmajor && minorv == newminor && rev < newrev)) {
					UpdateResults ur = new UpdateResults();
					ur.Results = "Version " + newest + " is available." + Environment.NewLine + "Would you like to download it?";
					ur.ShowDialog();
					if(ur.DialogResult == DialogResult.Yes) {
						Process.Start("http://sourceforge.net/projects/flacsquisher/files/");
					}
				}
				else {
					if(reportOnNoNewVersion) {
						MessageBox.Show("No newer version is available");
					}
				}
			}
			catch(Exception) {
				UpdateResults ur = new UpdateResults();
				ur.Results = "Error contacting the server to check for updates." + Environment.NewLine + "Would you like to check manually on the web?";
				ur.ShowDialog();
				if(ur.DialogResult == DialogResult.Yes) {
					Process.Start("http://sourceforge.net/projects/flacsquisher/files/");
				}
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutWindow aw = new AboutWindow(String.Format("{0}.{1}.{2}", majorv, minorv, rev));
			aw.ShowDialog(this);
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			OptionsWindow ow = new OptionsWindow();
			ow.OggPath = oggPath;
			ow.LamePath = lamePath;
			ow.FlacPath = flacexe;
			ow.MetaflacPath = metaflacPath;
			ow.Hidewin = hidewin;
			ow.ThirdPartyLame = thirdPartyLame;
			ow.FileExts = ignoredExts;
			ow.CopyFiles = copyFiles;
			ow.CopyExts = copiedExts;
			ow.AutoUpdate = autoUpdate;
			ow.ShowDialog(this);

			if(ow.DialogResult == DialogResult.OK) {
				oggPath = ow.OggPath;
				lamePath = ow.LamePath;
				flacexe = ow.FlacPath;
				metaflacPath = ow.MetaflacPath;
				hidewin = ow.Hidewin;
				thirdPartyLame = ow.ThirdPartyLame;
				ignoredExts = ow.FileExts;
				copyFiles = ow.CopyFiles;
				copiedExts = ow.CopyExts;
				autoUpdate = ow.AutoUpdate;
				if(ow.EncoderChoice != -1) {
					encoder.SelectedIndex = ow.EncoderChoice;
				}
				if(!String.IsNullOrEmpty(ow.EncoderStr)) {
					cliParams.Text = ow.EncoderStr;
				}
			}
		}

		private void consoleWindowToolStripMenuItem_Click(object sender, EventArgs e) {
			ConsoleWindow consoleWin = new ConsoleWindow();
			consoleWin.AddResults(resultsList);
			consoleWin.ShowDialog(this);
		}

		

	}
}
