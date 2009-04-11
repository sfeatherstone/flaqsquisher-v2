// FlacSquisher - A utility to convert a directory of Flac audio files
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

namespace FlacSquisher {
	public partial class FlacSquisher : Form {

		public string dirSeparator = System.IO.Path.DirectorySeparatorChar.ToString();

		String settingsPath;
		String oggPath;
		String flacexe;
		String lamePath;
		String metaflacPath;
		String ignoredExts;
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
				ignoredExts = "txt jpg log pdf png";
				hidewin = true;
			}

			// needed for users who upgrade from an old version that didn't have metaflac
			if(String.IsNullOrEmpty(metaflacPath)) {
				metaflacPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + dirSeparator + "metaflac.exe";
			}

			encodeStatus.Text = "Ready";
			encodeProgress.Width = 1;
			encodeProgress.Visible = false;

			majorv = 0;
			minorv = 5;
			rev = 0;

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
				sw.Write(metaflacPath);
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
			encodeProgress.Width = 200;
			encodeProgress.Value = 0;
			encodeProgress.MarqueeAnimationSpeed = 35;
			encodeProgress.Style = ProgressBarStyle.Marquee;
			encodeProgress.Visible = true;

			List<String> ignoreList = new List<String>();

			String[] split = ignoredExts.Split(' ');

			ignoreList.AddRange(split);

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

			Thread recurserThread = new Thread(new ThreadStart(recurser.recurseDirs));
			recurserThread.IsBackground = false;
			recurserThread.Start();

			Thread.Sleep(50);

			rwl.AcquireWriterLock(-1);
			rwl.ReleaseLock();

			// find files in "source" directory
			Queue<FileInfo> jobQueue = recurser.getJobQueue();

			encodeStatus.Text = "Setting up threads...";

			// if source directory is empty, don't bother making encoding threads
			if(jobQueue.Count < 1) {
				MessageBox.Show("The Flac directory is empty.", "Empty source directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
				encodeStatus.Text = "Ready";
				encodeProgress.Visible = false;
				encodeButton.Enabled = true;
				return;
			}

			int threads;

			rwl.AcquireWriterLock(-1); // -1 == wait forever for the lock
			try {
				threads = (int)threadCounter.Value; // Value is a System::Decimal, hence the cast
			}
			finally {
				rwl.ReleaseWriterLock();
			}

			// set up encoder
			Encoder encoderManager = new Encoder(flacDir.Text, outputDir.Text,
				encoder.SelectedIndex, cliParams.Text, threads, this);
			
			

			// update status bar
			encodeStatus.Text = "Starting to encode...";
			encodeProgress.Value = 0;
			encodeProgress.Maximum = jobQueue.Count;
			encodeProgress.Style = ProgressBarStyle.Continuous;

			List<Thread> threadList = new List<Thread>();

			// set up 'n' threads for processing the queue
			for(int i = 0; i < threadCounter.Value; i++) {
				Thread encoderThread = new Thread(
					new ThreadStart(encoderManager.encoderThread));
				encoderThread.IsBackground = true;
				threadList.Add(encoderThread);

				// Start the thread.
				encoderThread.Start();

			}

		}

		public void updateProgressBar() {
			// min() included for bounds checking, lock needed to prevent count being "short"
			rwl.AcquireWriterLock(-1);
			encodeProgress.Value = Math.Min((encodeProgress.Value + 1), encodeProgress.Maximum);

			// update the status text
			encodeStatus.Text = encodeProgress.Value + " of " + encodeProgress.Maximum + " files completed";
			rwl.ReleaseWriterLock();

			// refresh the window, just in case
			this.Refresh();
		}

		public void enableEncodeButton() {
			encodeButton.Enabled = true;
		}


	}
}
