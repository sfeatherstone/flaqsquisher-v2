﻿/*
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
using System.Threading;
using System.IO;

namespace FlacSquisher {
	class EncoderParams {

		FolderRecurser recurser;
		public FolderRecurser Recurser {
			get {
				return recurser;
			}
			set {
				recurser = value;
			}
		}

		string flacDir;
		public string FlacDir {
			get {
				return flacDir;
			}
			set {
				flacDir = value;
			}
		}

		string outputDir;
		public string OutputDir {
			get {
				return outputDir;
			}
			set {
				outputDir = value;
			}
		}

		int selectedEncoder;
		public int SelectedEncoder {
			get {
				return selectedEncoder;
			}
			set {
				selectedEncoder = value;
			}
		}

		string cliParams;
		public string CliParams{
			get {
				return cliParams;
			}
			set {
				cliParams = value;
			}
		}

		int threads;
		public int Threads {
			get {
				return threads;
			}
			set {
				threads = value;
			}
		}

		Queue<FileInfo> jobQueue;
		public Queue<FileInfo> JobQueue {
			get {
				return jobQueue;
			}
			set {
				jobQueue = value;
			}
		}

		bool copyFiles;
		public bool CopyFiles {
			get {
				return copyFiles;
			}
			set {
				copyFiles = value;
			}
		}

		string flacexe;
		public string FlacExe {
			get {
				return flacexe;
			}
			set {
				flacexe = value;
			}
		}

		string oggPath;
		public string OggPath {
			get {
				return oggPath;
			}
			set {
				oggPath = value;
			}
		}

		string lamePath;
		public string LamePath {
			get {
				return lamePath;
			}
			set {
				lamePath = value;
			}
		}

		string metaflacPath;
		public string MetaflacPath {
			get {
				return metaflacPath;
			}
			set {
				metaflacPath = value;
			}
		}

		bool hidewin;
		public bool Hidewin {
			get {
				return hidewin;
			}
			set {
				hidewin = value;
			}
		}

		List<String> ignoreList;
		public List<String> IgnoreList {
			get {
				return ignoreList;
			}
			set {
				ignoreList = value;
			}
		}

		List<String> copyList;
		public List<String> CopyList {
			get {
				return copyList;
			}
			set {
				copyList = value;
			}
		}

		bool thirdPartyLame;
		public bool ThirdPartyLame {
			get {
				return thirdPartyLame;
			}
			set {
				thirdPartyLame = value;
			}
		}
	}
}
