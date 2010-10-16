namespace FlacSquisher {
	partial class FlacSquisher {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flacDirLabel = new System.Windows.Forms.Label();
			this.flacDir = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.outputDir = new System.Windows.Forms.TextBox();
			this.flacDirButton = new System.Windows.Forms.Button();
			this.outputDirButton = new System.Windows.Forms.Button();
			this.encoder = new System.Windows.Forms.ComboBox();
			this.encoderLabel = new System.Windows.Forms.Label();
			this.cliParams = new System.Windows.Forms.TextBox();
			this.cliLabel = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.exitButton = new System.Windows.Forms.Button();
			this.encodeButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.threadsLabel = new System.Windows.Forms.Label();
			this.threadCounter = new System.Windows.Forms.NumericUpDown();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.encodeProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.encodeStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.recursingBackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.encodingBackgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			this.consoleWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.threadCounter)).BeginInit();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(553, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleWindowToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.optionsToolStripMenuItem.Text = "Options...";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineHelpToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// onlineHelpToolStripMenuItem
			// 
			this.onlineHelpToolStripMenuItem.Name = "onlineHelpToolStripMenuItem";
			this.onlineHelpToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.onlineHelpToolStripMenuItem.Text = "Online Help";
			this.onlineHelpToolStripMenuItem.Click += new System.EventHandler(this.onlineHelpToolStripMenuItem_Click);
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
			this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// flacDirLabel
			// 
			this.flacDirLabel.AutoSize = true;
			this.flacDirLabel.Location = new System.Drawing.Point(6, 16);
			this.flacDirLabel.Name = "flacDirLabel";
			this.flacDirLabel.Size = new System.Drawing.Size(78, 13);
			this.flacDirLabel.TabIndex = 1;
			this.flacDirLabel.Text = "FLAC Directory";
			// 
			// flacDir
			// 
			this.flacDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flacDir.Location = new System.Drawing.Point(6, 32);
			this.flacDir.Name = "flacDir";
			this.flacDir.Size = new System.Drawing.Size(310, 20);
			this.flacDir.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Output Directory";
			// 
			// outputDir
			// 
			this.outputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.outputDir.Location = new System.Drawing.Point(6, 71);
			this.outputDir.Name = "outputDir";
			this.outputDir.Size = new System.Drawing.Size(310, 20);
			this.outputDir.TabIndex = 4;
			// 
			// flacDirButton
			// 
			this.flacDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flacDirButton.Location = new System.Drawing.Point(322, 30);
			this.flacDirButton.Name = "flacDirButton";
			this.flacDirButton.Size = new System.Drawing.Size(75, 23);
			this.flacDirButton.TabIndex = 5;
			this.flacDirButton.Text = "Change...";
			this.flacDirButton.UseVisualStyleBackColor = true;
			this.flacDirButton.Click += new System.EventHandler(this.flacDirButton_Click);
			// 
			// outputDirButton
			// 
			this.outputDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.outputDirButton.Location = new System.Drawing.Point(322, 69);
			this.outputDirButton.Name = "outputDirButton";
			this.outputDirButton.Size = new System.Drawing.Size(75, 23);
			this.outputDirButton.TabIndex = 6;
			this.outputDirButton.Text = "Change...";
			this.outputDirButton.UseVisualStyleBackColor = true;
			this.outputDirButton.Click += new System.EventHandler(this.outputDirButton_Click);
			// 
			// encoder
			// 
			this.encoder.FormattingEnabled = true;
			this.encoder.Location = new System.Drawing.Point(6, 32);
			this.encoder.Name = "encoder";
			this.encoder.Size = new System.Drawing.Size(159, 21);
			this.encoder.TabIndex = 7;
			this.encoder.SelectedIndexChanged += new System.EventHandler(this.encoder_SelectedIndexChanged);
			// 
			// encoderLabel
			// 
			this.encoderLabel.AutoSize = true;
			this.encoderLabel.Location = new System.Drawing.Point(0, 16);
			this.encoderLabel.Name = "encoderLabel";
			this.encoderLabel.Size = new System.Drawing.Size(47, 13);
			this.encoderLabel.TabIndex = 8;
			this.encoderLabel.Text = "Encoder";
			// 
			// cliParams
			// 
			this.cliParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cliParams.Location = new System.Drawing.Point(6, 72);
			this.cliParams.Name = "cliParams";
			this.cliParams.Size = new System.Drawing.Size(310, 20);
			this.cliParams.TabIndex = 10;
			// 
			// cliLabel
			// 
			this.cliLabel.AutoSize = true;
			this.cliLabel.Location = new System.Drawing.Point(0, 56);
			this.cliLabel.Name = "cliLabel";
			this.cliLabel.Size = new System.Drawing.Size(80, 13);
			this.cliLabel.TabIndex = 9;
			this.cliLabel.Text = "Command Line:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.flacDirLabel);
			this.groupBox1.Controls.Add(this.outputDirButton);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.flacDir);
			this.groupBox1.Controls.Add(this.flacDirButton);
			this.groupBox1.Controls.Add(this.outputDir);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 100);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Directories";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cliParams);
			this.groupBox2.Controls.Add(this.encoderLabel);
			this.groupBox2.Controls.Add(this.cliLabel);
			this.groupBox2.Controls.Add(this.encoder);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 109);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(410, 104);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Encoder Options";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.3894F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.61059F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.statusStrip, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.07407F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.92593F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 239);
			this.tableLayoutPanel1.TabIndex = 13;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.exitButton);
			this.panel1.Controls.Add(this.encodeButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(419, 109);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(131, 104);
			this.panel1.TabIndex = 13;
			// 
			// exitButton
			// 
			this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.exitButton.Location = new System.Drawing.Point(3, 32);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(75, 23);
			this.exitButton.TabIndex = 1;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// encodeButton
			// 
			this.encodeButton.Location = new System.Drawing.Point(3, 3);
			this.encodeButton.Name = "encodeButton";
			this.encodeButton.Size = new System.Drawing.Size(75, 23);
			this.encodeButton.TabIndex = 0;
			this.encodeButton.Text = "Encode!";
			this.encodeButton.UseVisualStyleBackColor = true;
			this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.threadsLabel);
			this.panel2.Controls.Add(this.threadCounter);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(419, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(131, 100);
			this.panel2.TabIndex = 14;
			// 
			// threadsLabel
			// 
			this.threadsLabel.AutoSize = true;
			this.threadsLabel.Location = new System.Drawing.Point(3, 3);
			this.threadsLabel.Name = "threadsLabel";
			this.threadsLabel.Size = new System.Drawing.Size(98, 13);
			this.threadsLabel.TabIndex = 15;
			this.threadsLabel.Text = "Number of Threads";
			// 
			// threadCounter
			// 
			this.threadCounter.Location = new System.Drawing.Point(3, 19);
			this.threadCounter.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.threadCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.threadCounter.Name = "threadCounter";
			this.threadCounter.Size = new System.Drawing.Size(46, 20);
			this.threadCounter.TabIndex = 14;
			this.threadCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// statusStrip
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.statusStrip, 2);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeProgress,
            this.encodeStatus});
			this.statusStrip.Location = new System.Drawing.Point(0, 217);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(553, 22);
			this.statusStrip.TabIndex = 15;
			// 
			// encodeProgress
			// 
			this.encodeProgress.MarqueeAnimationSpeed = 10;
			this.encodeProgress.Name = "encodeProgress";
			this.encodeProgress.Size = new System.Drawing.Size(175, 16);
			this.encodeProgress.Visible = false;
			// 
			// encodeStatus
			// 
			this.encodeStatus.Name = "encodeStatus";
			this.encodeStatus.Size = new System.Drawing.Size(38, 17);
			this.encodeStatus.Text = "Ready";
			// 
			// recursingBackgroundWorker1
			// 
			this.recursingBackgroundWorker1.WorkerReportsProgress = true;
			this.recursingBackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.recursingBackgroundWorker1_DoWork);
			this.recursingBackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.recursingBackgroundWorker1_RunWorkerCompleted);
			this.recursingBackgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.recursingBackgroundWorker1_ProgressChanged);
			// 
			// encodingBackgroundWorker2
			// 
			this.encodingBackgroundWorker2.WorkerReportsProgress = true;
			this.encodingBackgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.encodingBackgroundWorker2_DoWork);
			this.encodingBackgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.encodingBackgroundWorker2_RunWorkerCompleted);
			this.encodingBackgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.encodingBackgroundWorker2_ProgressChanged);
			// 
			// consoleWindowToolStripMenuItem
			// 
			this.consoleWindowToolStripMenuItem.Name = "consoleWindowToolStripMenuItem";
			this.consoleWindowToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.consoleWindowToolStripMenuItem.Text = "Console Window...";
			this.consoleWindowToolStripMenuItem.Click += new System.EventHandler(this.consoleWindowToolStripMenuItem_Click);
			// 
			// FlacSquisher
			// 
			this.AcceptButton = this.encodeButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.exitButton;
			this.ClientSize = new System.Drawing.Size(553, 263);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FlacSquisher";
			this.Text = "FlacSquisher";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FlacSquisher_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.threadCounter)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem onlineHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label flacDirLabel;
		private System.Windows.Forms.TextBox flacDir;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox outputDir;
		private System.Windows.Forms.Button flacDirButton;
		private System.Windows.Forms.Button outputDirButton;
		private System.Windows.Forms.ComboBox encoder;

		private System.Windows.Forms.Label encoderLabel;


		private System.Windows.Forms.Label cliLabel;
		private System.Windows.Forms.TextBox cliParams;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button encodeButton;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.NumericUpDown threadCounter;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label threadsLabel;
		private System.Windows.Forms.StatusStrip statusStrip;

		private System.Windows.Forms.ToolStripProgressBar encodeProgress;


		private System.Windows.Forms.ToolStripStatusLabel encodeStatus;
		private System.ComponentModel.BackgroundWorker recursingBackgroundWorker1;
		private System.ComponentModel.BackgroundWorker encodingBackgroundWorker2;
		private System.Windows.Forms.ToolStripMenuItem consoleWindowToolStripMenuItem;

	}
}

