﻿/*
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
using System.Threading;
using System.IO;

namespace FlacSquisher {
	public class FolderRecurser {
		string directory;
		string[] ignoreList;
		string[] copyList;
		bool copyFiles;

		Queue<FileInfo> jobQueue;

		ReaderWriterLock rwl;

		public FolderRecurser() {
		}

		public FolderRecurser(string dir, string[] ignored, string[] copied, bool copy, ReaderWriterLock rwlock) {
			directory = dir;
			ignoreList = ignored;
			copyList = copied;
			copyFiles = copy;
			jobQueue = new Queue<FileInfo>();
			rwl = rwlock;
		}

		public Queue<FileInfo> getJobQueue() {
			return jobQueue;
		}

		public void recurseDirs() {
			rwl.AcquireWriterLock(-1);
			if(string.IsNullOrEmpty(directory)) {
				throw new Exception("No directory specified for FolderRecurser");
			}
			DirectoryInfo dirinfo = new DirectoryInfo(directory);
			recurse(dirinfo);
			rwl.ReleaseLock();
		}

		public Queue<FileInfo> recurse(DirectoryInfo dirinfo) {
			// make sure source directory exists (just a safeguard only really relevant on first level of recursion)
			if(!dirinfo.Exists) {
				return jobQueue;
			}

			bool foundExt;

			foreach(FileInfo fi in dirinfo.GetFiles()) {
				foundExt = false;
				foreach(String ext in ignoreList) {
					if(fi.Name.ToLower().EndsWith(ext.ToLower())) {
						foundExt = true;
					}
				}
				// copy exts should override ignored exts, so people can transfer a more specific set of files
				// (since we only check "EndsWith" instead of actually checking the true file extension)
				foreach(String copyExt in copyList) {
					if(fi.Name.ToLower().EndsWith(copyExt.ToLower())) {
						foundExt = false;
					}
				}
				if(!foundExt) {
					jobQueue.Enqueue(fi);
				}
			}

			// pseudo-tail-recursive, if this compiler is helped by that at all
			foreach(DirectoryInfo di in dirinfo.GetDirectories()) {
				recurse(di);
			}
			return jobQueue;
		}
	}
}
