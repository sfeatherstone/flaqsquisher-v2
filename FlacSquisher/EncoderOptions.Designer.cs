namespace FlacSquisher {
	partial class EncoderOptions {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ogg10 = new System.Windows.Forms.Label();
			this.ogg6 = new System.Windows.Forms.Label();
			this.oggMinus1 = new System.Windows.Forms.Label();
			this.oggQual = new System.Windows.Forms.TrackBar();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lameAttribution = new System.Windows.Forms.Label();
			this.lameQualBox = new System.Windows.Forms.GroupBox();
			this.lame50 = new System.Windows.Forms.Label();
			this.lame100 = new System.Windows.Forms.Label();
			this.lame10 = new System.Windows.Forms.Label();
			this.vbrLabel = new System.Windows.Forms.Label();
			this.vbrMode = new System.Windows.Forms.ComboBox();
			this.qualBar = new System.Windows.Forms.TrackBar();
			this.bitrateBox = new System.Windows.Forms.GroupBox();
			this.lame256 = new System.Windows.Forms.Label();
			this.lame192 = new System.Windows.Forms.Label();
			this.lame128 = new System.Windows.Forms.Label();
			this.lame64 = new System.Windows.Forms.Label();
			this.lame320 = new System.Windows.Forms.Label();
			this.lame8 = new System.Windows.Forms.Label();
			this.bitrateBar = new System.Windows.Forms.TrackBar();
			this.cbr = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.mono = new System.Windows.Forms.CheckBox();
			this.targetBox = new System.Windows.Forms.GroupBox();
			this.qualityRadio = new System.Windows.Forms.RadioButton();
			this.bitrateRadio = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.oggQual)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.lameQualBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.qualBar)).BeginInit();
			this.bitrateBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bitrateBar)).BeginInit();
			this.panel3.SuspendLayout();
			this.targetBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(534, 432);
			this.panel1.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(447, 397);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(366, 397);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(534, 391);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(526, 365);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "OggEnc (Ogg Vorbis)";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ogg10);
			this.groupBox1.Controls.Add(this.ogg6);
			this.groupBox1.Controls.Add(this.oggMinus1);
			this.groupBox1.Controls.Add(this.oggQual);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(520, 179);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Quality";
			// 
			// ogg10
			// 
			this.ogg10.AutoSize = true;
			this.ogg10.Location = new System.Drawing.Point(415, 37);
			this.ogg10.Name = "ogg10";
			this.ogg10.Size = new System.Drawing.Size(19, 13);
			this.ogg10.TabIndex = 3;
			this.ogg10.Text = "10";
			// 
			// ogg6
			// 
			this.ogg6.AutoSize = true;
			this.ogg6.Location = new System.Drawing.Point(295, 37);
			this.ogg6.Name = "ogg6";
			this.ogg6.Size = new System.Drawing.Size(13, 13);
			this.ogg6.TabIndex = 2;
			this.ogg6.Text = "6";
			// 
			// oggMinus1
			// 
			this.oggMinus1.AutoSize = true;
			this.oggMinus1.Location = new System.Drawing.Point(85, 37);
			this.oggMinus1.Name = "oggMinus1";
			this.oggMinus1.Size = new System.Drawing.Size(16, 13);
			this.oggMinus1.TabIndex = 1;
			this.oggMinus1.Text = "-1";
			// 
			// oggQual
			// 
			this.oggQual.Location = new System.Drawing.Point(79, 53);
			this.oggQual.Minimum = -1;
			this.oggQual.Name = "oggQual";
			this.oggQual.Size = new System.Drawing.Size(355, 45);
			this.oggQual.TabIndex = 0;
			this.oggQual.Value = 6;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tableLayoutPanel1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(526, 365);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "LAME (MP3)";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.lameQualBox, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.bitrateBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.67308F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.32692F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 359);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lameAttribution);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 335);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(514, 21);
			this.panel2.TabIndex = 0;
			// 
			// lameAttribution
			// 
			this.lameAttribution.AutoSize = true;
			this.lameAttribution.Location = new System.Drawing.Point(3, 0);
			this.lameAttribution.Name = "lameAttribution";
			this.lameAttribution.Size = new System.Drawing.Size(148, 13);
			this.lameAttribution.TabIndex = 0;
			this.lameAttribution.Text = "Using LAME encoding engine";
			// 
			// lameQualBox
			// 
			this.lameQualBox.Controls.Add(this.lame50);
			this.lameQualBox.Controls.Add(this.lame100);
			this.lameQualBox.Controls.Add(this.lame10);
			this.lameQualBox.Controls.Add(this.vbrLabel);
			this.lameQualBox.Controls.Add(this.vbrMode);
			this.lameQualBox.Controls.Add(this.qualBar);
			this.lameQualBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lameQualBox.Location = new System.Drawing.Point(3, 211);
			this.lameQualBox.Name = "lameQualBox";
			this.lameQualBox.Size = new System.Drawing.Size(514, 118);
			this.lameQualBox.TabIndex = 1;
			this.lameQualBox.TabStop = false;
			this.lameQualBox.Text = "Quality";
			// 
			// lame50
			// 
			this.lame50.AutoSize = true;
			this.lame50.Location = new System.Drawing.Point(226, 21);
			this.lame50.Name = "lame50";
			this.lame50.Size = new System.Drawing.Size(19, 13);
			this.lame50.TabIndex = 5;
			this.lame50.Text = "50";
			// 
			// lame100
			// 
			this.lame100.AutoSize = true;
			this.lame100.Location = new System.Drawing.Point(386, 21);
			this.lame100.Name = "lame100";
			this.lame100.Size = new System.Drawing.Size(25, 13);
			this.lame100.TabIndex = 4;
			this.lame100.Text = "100";
			// 
			// lame10
			// 
			this.lame10.AutoSize = true;
			this.lame10.Location = new System.Drawing.Point(95, 21);
			this.lame10.Name = "lame10";
			this.lame10.Size = new System.Drawing.Size(19, 13);
			this.lame10.TabIndex = 3;
			this.lame10.Text = "10";
			// 
			// vbrLabel
			// 
			this.vbrLabel.AutoSize = true;
			this.vbrLabel.Location = new System.Drawing.Point(65, 94);
			this.vbrLabel.Name = "vbrLabel";
			this.vbrLabel.Size = new System.Drawing.Size(106, 13);
			this.vbrLabel.TabIndex = 2;
			this.vbrLabel.Text = "Variable bitrate mode";
			// 
			// vbrMode
			// 
			this.vbrMode.FormattingEnabled = true;
			this.vbrMode.Items.AddRange(new object[] {
            "fast (default)",
            "standard (\"old\" method)"});
			this.vbrMode.Location = new System.Drawing.Point(177, 91);
			this.vbrMode.Name = "vbrMode";
			this.vbrMode.Size = new System.Drawing.Size(148, 21);
			this.vbrMode.TabIndex = 1;
			// 
			// qualBar
			// 
			this.qualBar.Location = new System.Drawing.Point(93, 40);
			this.qualBar.Maximum = 100;
			this.qualBar.Minimum = 10;
			this.qualBar.Name = "qualBar";
			this.qualBar.Size = new System.Drawing.Size(318, 45);
			this.qualBar.TabIndex = 0;
			this.qualBar.TickFrequency = 10;
			this.qualBar.Value = 70;
			// 
			// bitrateBox
			// 
			this.bitrateBox.Controls.Add(this.lame256);
			this.bitrateBox.Controls.Add(this.lame192);
			this.bitrateBox.Controls.Add(this.lame128);
			this.bitrateBox.Controls.Add(this.lame64);
			this.bitrateBox.Controls.Add(this.lame320);
			this.bitrateBox.Controls.Add(this.lame8);
			this.bitrateBox.Controls.Add(this.bitrateBar);
			this.bitrateBox.Controls.Add(this.cbr);
			this.bitrateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bitrateBox.Location = new System.Drawing.Point(3, 98);
			this.bitrateBox.Name = "bitrateBox";
			this.bitrateBox.Size = new System.Drawing.Size(514, 107);
			this.bitrateBox.TabIndex = 2;
			this.bitrateBox.TabStop = false;
			this.bitrateBox.Text = "Bitrate";
			// 
			// lame256
			// 
			this.lame256.AutoSize = true;
			this.lame256.Location = new System.Drawing.Point(386, 17);
			this.lame256.Name = "lame256";
			this.lame256.Size = new System.Drawing.Size(25, 13);
			this.lame256.TabIndex = 7;
			this.lame256.Text = "256";
			// 
			// lame192
			// 
			this.lame192.AutoSize = true;
			this.lame192.Location = new System.Drawing.Point(287, 17);
			this.lame192.Name = "lame192";
			this.lame192.Size = new System.Drawing.Size(25, 13);
			this.lame192.TabIndex = 6;
			this.lame192.Text = "192";
			// 
			// lame128
			// 
			this.lame128.AutoSize = true;
			this.lame128.Location = new System.Drawing.Point(190, 17);
			this.lame128.Name = "lame128";
			this.lame128.Size = new System.Drawing.Size(25, 13);
			this.lame128.TabIndex = 5;
			this.lame128.Text = "128";
			// 
			// lame64
			// 
			this.lame64.AutoSize = true;
			this.lame64.Location = new System.Drawing.Point(95, 17);
			this.lame64.Name = "lame64";
			this.lame64.Size = new System.Drawing.Size(19, 13);
			this.lame64.TabIndex = 4;
			this.lame64.Text = "64";
			// 
			// lame320
			// 
			this.lame320.AutoSize = true;
			this.lame320.Location = new System.Drawing.Point(483, 17);
			this.lame320.Name = "lame320";
			this.lame320.Size = new System.Drawing.Size(25, 13);
			this.lame320.TabIndex = 3;
			this.lame320.Text = "320";
			// 
			// lame8
			// 
			this.lame8.AutoSize = true;
			this.lame8.Location = new System.Drawing.Point(13, 17);
			this.lame8.Name = "lame8";
			this.lame8.Size = new System.Drawing.Size(13, 13);
			this.lame8.TabIndex = 2;
			this.lame8.Text = "8";
			// 
			// bitrateBar
			// 
			this.bitrateBar.Location = new System.Drawing.Point(6, 33);
			this.bitrateBar.Maximum = 320;
			this.bitrateBar.Minimum = 8;
			this.bitrateBar.Name = "bitrateBar";
			this.bitrateBar.Size = new System.Drawing.Size(502, 45);
			this.bitrateBar.TabIndex = 1;
			this.bitrateBar.TickFrequency = 12;
			this.bitrateBar.Value = 192;
			// 
			// cbr
			// 
			this.cbr.AutoSize = true;
			this.cbr.Location = new System.Drawing.Point(68, 84);
			this.cbr.Name = "cbr";
			this.cbr.Size = new System.Drawing.Size(192, 17);
			this.cbr.TabIndex = 0;
			this.cbr.Text = "Restrict encoder to constant bitrate";
			this.cbr.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.mono);
			this.panel3.Controls.Add(this.targetBox);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(514, 89);
			this.panel3.TabIndex = 3;
			// 
			// mono
			// 
			this.mono.AutoSize = true;
			this.mono.Location = new System.Drawing.Point(389, 19);
			this.mono.Name = "mono";
			this.mono.Size = new System.Drawing.Size(100, 17);
			this.mono.TabIndex = 1;
			this.mono.Text = "Mono encoding";
			this.mono.UseVisualStyleBackColor = true;
			// 
			// targetBox
			// 
			this.targetBox.Controls.Add(this.qualityRadio);
			this.targetBox.Controls.Add(this.bitrateRadio);
			this.targetBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.targetBox.Location = new System.Drawing.Point(0, 0);
			this.targetBox.Name = "targetBox";
			this.targetBox.Size = new System.Drawing.Size(171, 89);
			this.targetBox.TabIndex = 0;
			this.targetBox.TabStop = false;
			this.targetBox.Text = "Target";
			// 
			// qualityRadio
			// 
			this.qualityRadio.AutoSize = true;
			this.qualityRadio.Location = new System.Drawing.Point(6, 42);
			this.qualityRadio.Name = "qualityRadio";
			this.qualityRadio.Size = new System.Drawing.Size(57, 17);
			this.qualityRadio.TabIndex = 1;
			this.qualityRadio.TabStop = true;
			this.qualityRadio.Text = "Quality";
			this.qualityRadio.UseVisualStyleBackColor = true;
			// 
			// bitrateRadio
			// 
			this.bitrateRadio.AutoSize = true;
			this.bitrateRadio.Location = new System.Drawing.Point(6, 19);
			this.bitrateRadio.Name = "bitrateRadio";
			this.bitrateRadio.Size = new System.Drawing.Size(55, 17);
			this.bitrateRadio.TabIndex = 0;
			this.bitrateRadio.TabStop = true;
			this.bitrateRadio.Text = "Bitrate";
			this.bitrateRadio.UseVisualStyleBackColor = true;
			// 
			// EncoderOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(534, 432);
			this.Controls.Add(this.panel1);
			this.Name = "EncoderOptions";
			this.Text = "EncoderOptions";
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.oggQual)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.lameQualBox.ResumeLayout(false);
			this.lameQualBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.qualBar)).EndInit();
			this.bitrateBox.ResumeLayout(false);
			this.bitrateBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bitrateBar)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.targetBox.ResumeLayout(false);
			this.targetBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label ogg10;
		private System.Windows.Forms.Label ogg6;
		private System.Windows.Forms.Label oggMinus1;
		private System.Windows.Forms.TrackBar oggQual;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lameAttribution;
		private System.Windows.Forms.GroupBox lameQualBox;
		private System.Windows.Forms.Label lame50;
		private System.Windows.Forms.Label lame100;
		private System.Windows.Forms.Label lame10;
		private System.Windows.Forms.Label vbrLabel;
		private System.Windows.Forms.ComboBox vbrMode;
		private System.Windows.Forms.TrackBar qualBar;
		private System.Windows.Forms.GroupBox bitrateBox;
		private System.Windows.Forms.CheckBox cbr;
		private System.Windows.Forms.TrackBar bitrateBar;
		private System.Windows.Forms.Label lame256;
		private System.Windows.Forms.Label lame192;
		private System.Windows.Forms.Label lame128;
		private System.Windows.Forms.Label lame64;
		private System.Windows.Forms.Label lame320;
		private System.Windows.Forms.Label lame8;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox mono;
		private System.Windows.Forms.GroupBox targetBox;
		private System.Windows.Forms.RadioButton qualityRadio;
		private System.Windows.Forms.RadioButton bitrateRadio;
	}
}