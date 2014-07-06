/*
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

namespace FlacSquisher {
	public partial class EncoderOptions : Form {
		public EncoderOptions() {
			InitializeComponent();
		}

		public OptionsSet OptionSet {
			get {
				OptionsSet os = new OptionsSet();
				os.Encoder = (EncoderParams.EncoderChoice) tabControl1.SelectedIndex;
				if(qualityRadio.Checked) {
					os.Target = 0;
				}
				else {
					os.Target = 1;
				}
				os.Mono = mono.Checked;
				os.Cbr = cbr.Checked;
				os.Bitrate = bitrateBar.Value;
				if(os.Encoder == EncoderParams.EncoderChoice.OggEnc) {
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
				tabControl1.SelectedIndex = (int) os.Encoder;
				qualityRadio.Checked = (os.Target == 0);
				mono.Checked = os.Mono;
				cbr.Checked = os.Cbr;
				bitrateBar.Value = os.Bitrate;
				if(os.Encoder == EncoderParams.EncoderChoice.OggEnc) {
					oggQual.Value = os.Quality;
				}
				else {
					qualBar.Value = os.Quality;
				}
				vbrMode.SelectedIndex = os.VbrMode;
			}
		}

		public EncoderParams.EncoderChoice Encoder {
			get {
				return (EncoderParams.EncoderChoice) tabControl1.SelectedIndex;
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
