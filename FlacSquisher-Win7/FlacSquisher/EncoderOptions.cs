using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlacSquisher {
	public partial class EncoderOptions : Form {
		public EncoderOptions() {
			InitializeComponent();
		}

		public OptionsSet OptionSet {
			get {
				OptionsSet os = new OptionsSet();
				os.Encoder = tabControl1.SelectedIndex;
				if(qualityRadio.Checked) {
					os.Target = 0;
				}
				else {
					os.Target = 1;
				}
				os.Mono = mono.Checked;
				os.Cbr = cbr.Checked;
				os.Bitrate = bitrateBar.Value;
				if(os.Encoder == 0) {
					os.Quality = oggQual.Value;
				}
				else {
					os.Quality = qualBar.Value;
				}
				os.VbrMode = vbrMode.SelectedIndex;
				return os;
			}
			set {
				OptionsSet os = value;
				tabControl1.SelectedIndex = os.Encoder;
				qualityRadio.Checked = (os.Target == 0);
				mono.Checked = os.Mono;
				cbr.Checked = os.Cbr;
				bitrateBar.Value = os.Bitrate;
				if(os.Encoder == 0) {
					oggQual.Value = os.Quality;
				}
				else {
					qualBar.Value = os.Quality;
				}
				vbrMode.SelectedIndex = os.VbrMode;
			}
		}

		public int Encoder {
			get {
				return tabControl1.SelectedIndex;
			}
		}

		public String toString() {
			String str;
			if(tabControl1.SelectedIndex == 0) {
				str = "-q " + oggQual.Value;
			}
			else { // using LAME
				str = "";
				if(qualityRadio.Checked) { // vbr
					double qual = 10.0 - (qualBar.Value * 0.1);
					str += "-V" + qual + " ";
					if(vbrMode.SelectedIndex == 1) { // "standard" instead of "fast"
						str += " --vbr-old ";
					}
				}
				else {
					if(cbr.Checked) {
						str += " -b " + bitrateBar.Value + " ";
					}
					else { // abr
						str += " --abr " + bitrateBar.Value + " ";
					}
				}
				if(mono.Checked) {
					str += " -a ";
				}
			}
			return str;
		}

		private void okButton_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void EncoderOptions_Load(object sender, EventArgs e) {
			// change MP3 options so nothing's enabled that shouldn't be
			qualityRadio.Checked = true;
			bitrateBox.Enabled = false;
			vbrMode.SelectedIndex = 0;
		}

		private void bitrateRadio_CheckedChanged(object sender, EventArgs e) {
			bitrateBox.Enabled = bitrateRadio.Checked;
		}

		private void qualityRadio_CheckedChanged(object sender, EventArgs e) {
			lameQualBox.Enabled = qualityRadio.Checked;
		}
	}
}
