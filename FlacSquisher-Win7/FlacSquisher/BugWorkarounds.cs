/*
Copyright 2008-2011 Michael Brown

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
	/// <summary>
	/// Keeps track of whether workarounds for other programs are active; if there is a bug in LAME, for
	/// instance, we keep track of it here.
	/// </summary>
	class BugWorkarounds {
		/// <summary>
		/// Only class methods will be created for this class, not instance methods; there is no need to
		/// call the constructor
		/// </summary>
		public BugWorkarounds() {
		}

		/// <summary>
		/// The copy of Lame that's compiled against libsndfile (to allow flac input directly) always
		/// returns zero (success), even if given non-audio data
		/// http://www.hydrogenaudio.org/forums/index.php?showtopic=86833
		/// </summary>
		public static bool LameLibsndfileReturnsZero {
			get {
				return true;
			}
		}
	}
}
