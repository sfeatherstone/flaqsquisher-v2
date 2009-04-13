using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace FlacSquisher {
	class Encoder : BackgroundWorker {

		string flacPath;
		string outputPath;
		int encoderChoice;
		string options;
		int threadCount;
		ReaderWriterLock rwl;
		Queue<FileInfo> jobQueue;
		BackgroundWorker bw;

		public Encoder() {
		}

		public Encoder(string flacdir, string outputdir, int encoder, string cmdopts, int threads, ReaderWriterLock rwlock, Queue<FileInfo> jq, BackgroundWorker backworker) {
			flacPath = flacdir;
			outputPath = outputdir;
			encoderChoice = encoder;
			options = cmdopts;
			threadCount = threads;
			rwl = rwlock;
			jobQueue = jq;
			bw = backworker;
		}

		public void encoderThread() {
			try { // exception will occur when queue is empty
				FileInfo fi;
				// goes until the queue is empty
				while(jobQueue.Count > 0) {
					fi = jobQueue.Dequeue();
					encodeFile(fi);

					// increment "value" on the progress bar by one
					bw.ReportProgress(20, jobQueue.Count);
				}
			}
			catch(Exception ex) {
				ex.ToString();
				//MessageBox::Show(e->ToString());
			}
			finally {
				// enable the encode button only if this is the last thread executing
				rwl.AcquireWriterLock(-1);
				try {
					if(threadCount > 1) {
						try {
							threadCount--;
						}
						finally {
						}
					}
					else {
						//flacsquisher.enableEncodeButton();
					}
				}
				catch(Exception ex) {
					ex.ToString();
				}
				finally {
					rwl.ReleaseWriterLock();
				}
			}
		}

		public void encodeFile(FileInfo fi) {
			System.Windows.Forms.MessageBox.Show(fi.ToString());
		}

	}
}
