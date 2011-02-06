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
	public partial class ConsoleWindow : Form {
		
		public ConsoleWindow() {
			InitializeComponent();
		}

		internal void AddResults(List<EncoderResults> resultsList) {
			if(resultsList == null) {
				return;
			}
			foreach(EncoderResults result in resultsList){
				ListViewItem item = new ListViewItem(result.FileName);
				item.SubItems.Add(result.ConsoleText);
				consoleListView.Items.Add(item);
			}
		}

		private void consoleListView_DoubleClick(object sender, EventArgs e) {
			DetailsWindow detailsWin = new DetailsWindow();
			detailsWin.SetTitle(consoleListView.SelectedItems[0].SubItems[0].Text);
			detailsWin.SetBodyText(consoleListView.SelectedItems[0].SubItems[1].Text);
			detailsWin.ShowDialog(this);
		}
	}
}
