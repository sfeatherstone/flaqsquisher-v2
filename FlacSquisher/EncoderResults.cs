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
