using System;
using System.Collections.Generic;
using System.Text;

namespace FlacSquisher {
	public class OptionsSet {
		int encoder;
		public int Encoder {
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
