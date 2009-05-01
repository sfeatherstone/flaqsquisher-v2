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
				return copyFiles.Checked;
			}
			set {
				copyFiles.Checked = value;
			}
		}

		private void defaultsButton_Click(object sender, EventArgs e) {
			oggLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "oggenc.exe";
			flacLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "flac.exe";
			lameLocation.Text = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "lame.exe";
			fileExts.Text = "txt jpg log pdf png";
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
