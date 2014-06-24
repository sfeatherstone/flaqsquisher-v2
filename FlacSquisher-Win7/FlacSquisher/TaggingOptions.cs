using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlacSquisher {
	public partial class ReplayGainOptions : Form {
		public ReplayGainOptions() {
			InitializeComponent();
		}

		internal EncoderParams.ReplayGainType GainType {
			get {
				if(lameTagRadio.Checked) {
					return EncoderParams.ReplayGainType.LameTag;
				}
				else if(id3TagRadio.Checked) {
					return EncoderParams.ReplayGainType.ID3Tag;
				}
				else if(noneRadio.Checked) {
					return EncoderParams.ReplayGainType.None;
				}
				else if(albumRadio.Checked) {
					return EncoderParams.ReplayGainType.Album;
				}
				else if(trackRadio.Checked) {
					return EncoderParams.ReplayGainType.Track;
				}
				else {
					throw new NotImplementedException("Internal error: The gain type selected has not been fully implemented for ReplayGain");
				}
			}
			set {
				if(value == EncoderParams.ReplayGainType.LameTag) {
					lameTagRadio.Checked = true;
				}
				else if(value == EncoderParams.ReplayGainType.ID3Tag) {
					id3TagRadio.Checked = true;
				}
				else if(value == EncoderParams.ReplayGainType.None) {
					noneRadio.Checked = true;
				}
				else if(value == EncoderParams.ReplayGainType.Album) {
					albumRadio.Checked = true;
				}
				else if(value == EncoderParams.ReplayGainType.Track) {
					trackRadio.Checked = true;
				}
				else {
					throw new NotImplementedException("Internal error: The " + value.ToString() + " type has not been fully implemented for ReplayGain");
				}
			}
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
