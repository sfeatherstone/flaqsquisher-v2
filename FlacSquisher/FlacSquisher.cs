﻿// FlacSquisher - A utility to convert a directory of Flac audio files
// to MP3 or Ogg Vorbis format, preserving the directory structure of
// the Flac files

/*
Copyright 2008 Michael Brown

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

namespace FlacSquisher {
	public partial class FlacSquisher : Form {

		public string dirSeparator = System.IO.Path.DirectorySeparatorChar.ToString();

		String settingsPath;
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
		int encoderChoice;

		int majorv;
		int minorv;
		int rev;

		ReaderWriterLock rwl = new ReaderWriterLock();
		List<String> ignoreList;
		List<String> copyList;

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

			// check if config file exists
			if(File.Exists(settingsPath)) {
				loadSettingsFile(settingsPath);
			}
			else { // load defaults (in executable's directory) if config file does not exist
				oggPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "oggenc.exe";
				flacexe = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "flac.exe";
				lamePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "lame.exe";
				metaflacPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "metaflac.exe";
				ignoredExts = "txt log pdf";
				copiedExts = "jpg png";
				hidewin = true;
			}

			// needed for users who upgrade from an old version that didn't have metaflac
			if(String.IsNullOrEmpty(metaflacPath)) {
				metaflacPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "metaflac.exe";
			}
			if(copiedExts == null) {
				copiedExts = "";
			}

			encodeStatus.Text = "Ready";
			encodeProgress.Width = 1;
			encodeProgress.Visible = false;

			majorv = 0;
			minorv = 5;
			rev = 2;

			this.Text = "FlacSquisher v" + majorv + "." + minorv + "." + rev;

		}

		// called on initialization to restore the settings from the last session (called only if the config file exists)
		private int loadSettingsFile(String filePath) {
			try {
				StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
				flacDir.Text = sr.ReadLine();
				outputDir.Text = sr.ReadLine();
				encoder.SelectedIndex = Convert.ToInt32(sr.ReadLine());
				oggPath = sr.ReadLine();
				flacexe = sr.ReadLine();
				lamePath = sr.ReadLine();
				cliParams.Text = sr.ReadLine();
				hidewin = bool.Parse(sr.ReadLine());
				ignoredExts = sr.ReadLine();
				copyFiles = bool.Parse(sr.ReadLine());
				metaflacPath = sr.ReadLine();
				copiedExts = sr.ReadLine();
				sr.Close();
				return 1;
			}
			catch(Exception ex) { // any settings loaded before the error remain -- this may or may not be desired
				MessageBox.Show("The configuration file was not read in properly. This sometimes happens when upgrading from an earlier version. Please ensure that your settings were imported properly.",
						"Configuration file error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				return 0;
			}
		}

		// called on formClose to save settings from this session
		private int saveSettingsFile(String filePath) {
			try {
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
				sw.Write(copiedExts.ToString());
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
			saveSettingsFile(settingsPath);
		}

		// chooses "source" directory containing Flac files to be recoded
		private void flacDirButton_Click(object sender, EventArgs e) {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if(fbd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
				flacDir.Text = fbd.SelectedPath;
			}
		}

		// chooses "destination" directory to contain files output by the recoding
		private void outputDirButton_Click(object sender, EventArgs e) {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
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
			// disable encodeButton until encoding is finished
			encodeButton.Enabled = false;
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
			encodeProgress.Width = 400;
			encodeProgress.Value = 0;
			encodeProgress.MarqueeAnimationSpeed = 50;
			encodeProgress.Style = ProgressBarStyle.Marquee;
			encodeProgress.Visible = true;

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

			FolderRecurser recurser = new FolderRecurser(flacDir.Text, ignoreList.ToArray(), copyFiles, rwl);

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
			args.FlacDir = flacDir.Text;
			args.OutputDir = outputDir.Text;
			args.SelectedEncoder = encoder.SelectedIndex;
			args.CliParams = cliParams.Text;
			args.Threads = threads;
			args.Rwl = rwl;
			args.CopyFiles = copyFiles;
			args.FlacExe = flacexe;
			args.OggPath = oggPath;
			args.LamePath = lamePath;
			args.MetaflacPath = metaflacPath;
			args.Hidewin = hidewin;
			args.IgnoreList = ignoreList;
			args.CopyList = copyList;

			this.recursingBackgroundWorker1.RunWorkerAsync(args);
		}

		public void updateProgressBar() {
			// min() included for bounds checking, lock needed to prevent count being "short"
			encodeProgress.Value = Math.Min((encodeProgress.Value + 1), encodeProgress.Maximum);

			// update the status text
			encodeStatus.Text = encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";

			// refresh the window, just in case
			this.Refresh();
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

			e.Result = args;

			bw.ReportProgress(20, args.JobQueue.Count);
		}

		private void recursingBackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			encodeProgress.Style = ProgressBarStyle.Continuous;
			encodeProgress.Value = 0;
			encodeProgress.Maximum = (int)e.UserState;
		}

		private void recursingBackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			this.encodingBackgroundWorker2.RunWorkerAsync(e.Result);
		}

		private void encodingBackgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker bw = sender as BackgroundWorker;

			EncoderParams args = (EncoderParams) e.Argument;

			bw.ReportProgress(0, args.JobQueue.Count);

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
			int queuesize = (int)e.UserState;
			// need to account for files the other threads are currently encoding
			int otherThreads = (int)threadCounter.Value - 1;
			int progress = encodeProgress.Maximum - (queuesize + otherThreads);

			encodeProgress.Style = ProgressBarStyle.Continuous;

			// max() included so that the progress never goes backwards
			progress = Math.Max(encodeProgress.Value, progress);
			// min() included for bounds checking
			encodeProgress.Value = Math.Min((progress), encodeProgress.Maximum);

			// update the status text
			encodeStatus.Text = "" + encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";

			// refresh the window, just in case
			this.Refresh();
		}

		private void encodingBackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			encodeProgress.Value = encodeProgress.Maximum;

			// update the status text
			encodeStatus.Text = "" + encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";
			
			encodeButton.Enabled = true;
		}

		// send them to the project forums page
		private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("http://sourceforge.net/forum/?group_id=232925");
		}

		// this method checks with the project webserver to see if there's a newer version
		private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
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
						Process.Start("http://sourceforge.net/project/showfiles.php?group_id=232925");
					}
				}
				else {
					MessageBox.Show("No newer version is available");
				}
			}
			catch(Exception ex) {
				UpdateResults ur = new UpdateResults();
				ur.Results = "Error contacting the server to check for updates." + Environment.NewLine + "Would you like to check manually on the web?";
				ur.ShowDialog();
				if(ur.DialogResult == DialogResult.Yes) {
					Process.Start("http://sourceforge.net/project/showfiles.php?group_id=232925");
				}
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutWindow aw = new AboutWindow();
			aw.ShowDialog(this);
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			OptionsWindow ow = new OptionsWindow();
			ow.OggPath = oggPath;
			ow.LamePath = lamePath;
			ow.FlacPath = flacexe;
			ow.MetaflacPath = metaflacPath;
			ow.Hidewin = hidewin;
			ow.FileExts = ignoredExts;
			ow.CopyFiles = copyFiles;
			ow.CopyExts = copiedExts;
			ow.ShowDialog(this);

			if(ow.DialogResult == DialogResult.OK) {
				oggPath = ow.OggPath;
				lamePath = ow.LamePath;
				flacexe = ow.FlacPath;
				metaflacPath = ow.MetaflacPath;
				hidewin = ow.Hidewin;
				ignoredExts = ow.FileExts;
				copyFiles = ow.CopyFiles;
				copiedExts = ow.CopyExts;
				if(ow.EncoderChoice != -1) {
					encoder.SelectedIndex = ow.EncoderChoice;
				}
				if(!String.IsNullOrEmpty(ow.EncoderStr)) {
					cliParams.Text = ow.EncoderStr;
				}
			}
		}

		

	}
}
