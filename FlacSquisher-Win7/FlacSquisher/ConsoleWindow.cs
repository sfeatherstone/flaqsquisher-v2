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
		bool messagePending = false;
		
		public ConsoleWindow() {
			InitializeComponent();
		}

		private void clearButton_Click(object sender, EventArgs e) {
			consoleTextbox.Clear();
		}

		public void AddErrorMessage(string message) {
			consoleTextbox.AppendText(message + "\n");
			messagePending = true;
		}

		public void ResetMessageCheck() {
			messagePending = false;
		}

		public bool MessagePending() {
			return messagePending;
		}

		public string ConsoleText {
			get {
				return consoleTextbox.Text;
			}
			set {
				consoleTextbox.Text = value;
			}
		}
	}
}
