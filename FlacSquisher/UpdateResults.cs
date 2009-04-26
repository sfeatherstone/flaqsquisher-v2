using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlacSquisher {
	public partial class UpdateResults : Form {
		public UpdateResults() {
			InitializeComponent();
		}

		public string Results {
			get {
				return results.Text;
			}
			set {
				results.Text = value;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void yesButton_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}
	}
}
