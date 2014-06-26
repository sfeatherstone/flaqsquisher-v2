﻿/*
Copyright 2008-2013 Michael Brown

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
	public partial class TaggingOptions : Form {
		public TaggingOptions() {
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

		internal int MaxImageSize {
			get {
				return (int)maxImageSize.Value;
			}
			set {
				maxImageSize.Value = value;
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
