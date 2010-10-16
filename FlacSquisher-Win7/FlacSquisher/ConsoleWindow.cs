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
