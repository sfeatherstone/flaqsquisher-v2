using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlacSquisher {
	public partial class DetailsWindow : Form {
		public DetailsWindow() {
			InitializeComponent();
		}

		public void SetTitle(String title){
			this.Text = title;
		}

		public void SetBodyText(String body) {
			this.textBox.Text = body;
		}
	}
}
