using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FlacSquisher {
	class Encoder {

		string flacPath;
		string outputPath;
		int encoderChoice;
		string options;
		int threadCount;
		FlacSquisher flacsquisher;

		public Encoder() {
		}

		public Encoder(string flacdir, string outputdir, int encoder, string cmdopts, int threads, FlacSquisher fs) {
			flacPath = flacdir;
			outputPath = outputdir;
			encoderChoice = encoder;
			options = cmdopts;
			threadCount = threads;
			flacsquisher = fs;
		}

		public void encoderThread() {
			try { // exception will occur when queue is empty
				FileInfo fi;
				// goes until the queue is empty
				while(jobQueue.Count > 0) {
					fi = jobQueue.Dequeue();
					encodeFile(fi);

					// increment "value" on the progress bar by one
					flacsquisher.updateProgressBar();
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
						flacsquisher.enableEncodeButton();
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

		}

	}
}
