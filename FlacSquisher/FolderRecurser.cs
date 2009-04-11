using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace FlacSquisher {
	class FolderRecurser {
		string directory;
		string[] ignoreList;
		bool copyFiles;

		Queue<FileInfo> jobQueue;

		ReaderWriterLock rwl;

		public FolderRecurser() {
		}

		public FolderRecurser(string dir, string[] ignored, bool copy, ReaderWriterLock rwlock) {
			directory = dir;
			ignoreList = ignored;
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
			recurse(directory);
			rwl.ReleaseLock();
		}

		public Queue<FileInfo> recurse(string rootDir) {
			DirectoryInfo dirinfo = new DirectoryInfo(rootDir);
			//Queue<FileInfo> jobQueue = new Queue<FileInfo>();

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
				if(!foundExt || copyFiles) {
					//if(!fi->Name->ToLower()->EndsWith("flac")){
					//MessageBox::Show(fi->Name);
					//}
					jobQueue.Enqueue(fi);
				}
			}

			// pseudo-tail-recursive, if this compiler is helped by that at all
			foreach(DirectoryInfo di in dirinfo.GetDirectories()) {
				recurse(di.FullName);
				//Queue<FileInfo> retQueue = recurse(di.FullName);
				//foreach(FileInfo fi in retQueue) {
				//	jobQueue.Enqueue(fi);
				//}
			}
			return jobQueue;
		}
	}
}
