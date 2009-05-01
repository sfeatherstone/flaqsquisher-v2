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

		public OptionsSet OptionsSet {
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
	}
}
