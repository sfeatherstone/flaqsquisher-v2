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
	public class OptionsSet {
		EncoderParams.EncoderChoice encoder;
		public EncoderParams.EncoderChoice Encoder {
			get {
				return encoder;
			}
			set {
				encoder = value;
			}
		}

		int target;
		public int Target {
			get {
				return target;
			}
			set {
				target = value;
			}
		}

		bool mono;
		public bool Mono {
			get {
				return mono;
			}
			set {
				mono = value;
			}
		}

		bool cbr;
		public bool Cbr {
			get {
				return cbr;
			}
			set {
				cbr = value;
			}
		}

		int bitrate;
		public int Bitrate {
			get {
				return bitrate;
			}
			set {
				bitrate = value;
			}
		}

		int quality;
		public int Quality {
			get {
				return quality;
			}
			set {
				quality = value;
			}
		}

		int vbrmode;
		public int VbrMode {
			get {
				return vbrmode;
			}
			set {
				vbrmode = value;
			}
		}
	}
}
