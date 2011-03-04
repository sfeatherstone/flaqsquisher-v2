﻿/*
Copyright 2008-2010 Michael Brown

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
using System.IO;

namespace FlacSquisher {
	public partial class OptionsWindow : Form {

		string encoderStr;
		public string EncoderStr {
			get {
				return encoderStr;
			}
		}
		int encoderChoice;
		public int EncoderChoice {
			get {
				return encoderChoice;
			}
		}

		public OptionsWindow() {
			InitializeComponent();

			encoderStr = "";
			encoderChoice = -1;
		}

		public string OggPath {
			get {
				return oggLocation.Text;
			}
			set {
				oggLocation.Text = value;
			}
		}

		private void oggButton_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Executable Files (*.exe)|*.exe|All Files|*.*";
			if(ofd.ShowDialog() != DialogResult.Cancel) {
				oggLocation.Text = ofd.FileName;
			}
		}

		public string FlacPath {
			get {
				return flacLocation.Text;
			}
			set {
				flacLocation.Text = value;
			}
		}

		private void flacButton_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Executable Files (*.exe)|*.exe|All Files|*.*";
			if(ofd.ShowDialog() != DialogResult.Cancel) {
				flacLocation.Text = ofd.FileName;
			}
		}

		public string LamePath {
			get {
				return lameLocation.Text;
			}
			set {
				lameLocation.Text = value;
			}
		}

		private void lameButton_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Executable Files (*.exe)|*.exe|All Files|*.*";
			if(ofd.ShowDialog() != DialogResult.Cancel) {
				lameLocation.Text = ofd.FileName;
			}
		}

		public string MetaflacPath {
			get {
				return metaflacLocation.Text;
			}
			set {
				metaflacLocation.Text = value;
			}
		}

		private void metaflacButton_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Executable Files (*.exe)|*.exe|All Files|*.*";
			if(ofd.ShowDialog() != DialogResult.Cancel) {
				metaflacLocation.Text = ofd.FileName;
			}
		}

		public bool Hidewin {
			get {
				return hidewin.Checked;
			}
			set {
				hidewin.Checked = value;
			}
		}

		public bool ThirdPartyLame {
			get {
				return thirdPartyLameBox.Checked;
			}
			set {
				thirdPartyLameBox.Checked = value;
			}
		}

		private void encodingOptionsButton_Click(object sender, EventArgs e) {
			EncoderOptions encoderOpts = new EncoderOptions();
			if(encoderOpts.ShowDialog(this) != DialogResult.Cancel){
				encoderStr = encoderOpts.toString();
				encoderChoice = encoderOpts.Encoder;
			}
		}

		public string FileExts {
			get {
				return fileExts.Text;
			}
			set {
				fileExts.Text = value;
			}
		}

		public bool CopyFiles {
			get {
				//return copyFiles.Checked;
				return false;
			}
			set {
				//copyFiles.Checked = value;
			}
		}

		public string CopyExts {
			get {
				return copyExts.Text;
			}
			set {
				copyExts.Text = value;
			}
		}

		private void defaultsButton_Click(object sender, EventArgs e) {
			oggLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "oggenc.exe";
			flacLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "flac.exe";
			lameLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "lame.exe";
			metaflacLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "metaflac.exe";
			hidewin.Checked = true;
			thirdPartyLameBox.Checked = false;
			fileExts.Text = "txt log pdf cue";
			copyExts.Text = "jpg png";
		}

		private void okButton_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}