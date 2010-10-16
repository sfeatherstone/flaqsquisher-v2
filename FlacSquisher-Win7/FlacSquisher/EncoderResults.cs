using System;
using System.Collections.Generic;
using System.Text;

namespace FlacSquisher {
	class EncoderResults {

		string consoleText;
		int queueCount;

		public EncoderResults() {
		}
		public EncoderResults(string consoleText, int queueCount) {
			this.consoleText = consoleText;
			this.queueCount = queueCount;
		}

		public string ConsoleText {
			get{
				return consoleText;
			}
		}

		public int QueueCount{
			get {
				return queueCount;
			}
		}
	}
}
