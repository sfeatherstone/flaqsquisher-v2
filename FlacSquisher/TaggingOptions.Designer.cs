namespace FlacSquisher {
	partial class TaggingOptions {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaggingOptions));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.replayGainBox = new System.Windows.Forms.GroupBox();
			this.replayGainLabel = new System.Windows.Forms.Label();
			this.trackRadio = new System.Windows.Forms.RadioButton();
			this.albumRadio = new System.Windows.Forms.RadioButton();
			this.noneRadio = new System.Windows.Forms.RadioButton();
			this.id3TagRadio = new System.Windows.Forms.RadioButton();
			this.lameTagRadio = new System.Windows.Forms.RadioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.albumArtBox = new System.Windows.Forms.GroupBox();
			this.kbLabel = new System.Windows.Forms.Label();
			this.maxImageSize = new System.Windows.Forms.NumericUpDown();
			this.artSizeLabel = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.replayGainBox.SuspendLayout();
			this.panel1.SuspendLayout();
			this.albumArtBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxImageSize)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.replayGainBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.albumArtBox, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 292);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// replayGainBox
			// 
			this.replayGainBox.Controls.Add(this.replayGainLabel);
			this.replayGainBox.Controls.Add(this.trackRadio);
			this.replayGainBox.Controls.Add(this.albumRadio);
			this.replayGainBox.Controls.Add(this.noneRadio);
			this.replayGainBox.Controls.Add(this.id3TagRadio);
			this.replayGainBox.Controls.Add(this.lameTagRadio);
			this.replayGainBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.replayGainBox.Location = new System.Drawing.Point(3, 3);
			this.replayGainBox.Name = "replayGainBox";
			this.replayGainBox.Size = new System.Drawing.Size(448, 192);
			this.replayGainBox.TabIndex = 0;
			this.replayGainBox.TabStop = false;
			this.replayGainBox.Text = "ReplayGain Type";
			// 
			// replayGainLabel
			// 
			this.replayGainLabel.AutoSize = true;
			this.replayGainLabel.Location = new System.Drawing.Point(9, 16);
			this.replayGainLabel.MaximumSize = new System.Drawing.Size(435, 0);
			this.replayGainLabel.Name = "replayGainLabel";
			this.replayGainLabel.Size = new System.Drawing.Size(433, 39);
			this.replayGainLabel.TabIndex = 5;
			this.replayGainLabel.Text = resources.GetString("replayGainLabel.Text");
			// 
			// trackRadio
			// 
			this.trackRadio.AutoSize = true;
			this.trackRadio.Location = new System.Drawing.Point(9, 166);
			this.trackRadio.Name = "trackRadio";
			this.trackRadio.Size = new System.Drawing.Size(122, 17);
			this.trackRadio.TabIndex = 4;
			this.trackRadio.Text = "Track (Experimental)";
			this.toolTip1.SetToolTip(this.trackRadio, "Uses the ReplayGain track tag on the FLAC files to decrease the volume of the aud" +
					"io data. Requires LAME version 3.100 or greater.");
			this.trackRadio.UseVisualStyleBackColor = true;
			// 
			// albumRadio
			// 
			this.albumRadio.AutoSize = true;
			this.albumRadio.Location = new System.Drawing.Point(9, 143);
			this.albumRadio.Name = "albumRadio";
			this.albumRadio.Size = new System.Drawing.Size(123, 17);
			this.albumRadio.TabIndex = 3;
			this.albumRadio.Text = "Album (Experimental)";
			this.toolTip1.SetToolTip(this.albumRadio, "Uses the ReplayGain album tag on the FLAC files to decrease the volume of the aud" +
					"io data. Requires LAME version 3.100 or greater.");
			this.albumRadio.UseVisualStyleBackColor = true;
			// 
			// noneRadio
			// 
			this.noneRadio.AutoSize = true;
			this.noneRadio.Location = new System.Drawing.Point(9, 120);
			this.noneRadio.Name = "noneRadio";
			this.noneRadio.Size = new System.Drawing.Size(51, 17);
			this.noneRadio.TabIndex = 2;
			this.noneRadio.Text = "None";
			this.toolTip1.SetToolTip(this.noneRadio, "Disables LAME\'s default ReplayGain scanning and tagging. This gives a small perfo" +
					"rmance increase in the encoding.");
			this.noneRadio.UseVisualStyleBackColor = true;
			// 
			// id3TagRadio
			// 
			this.id3TagRadio.AutoSize = true;
			this.id3TagRadio.Location = new System.Drawing.Point(9, 97);
			this.id3TagRadio.Name = "id3TagRadio";
			this.id3TagRadio.Size = new System.Drawing.Size(64, 17);
			this.id3TagRadio.TabIndex = 1;
			this.id3TagRadio.Text = "ID3 Tag";
			this.toolTip1.SetToolTip(this.id3TagRadio, "Moves the current ReplayGain tag values to the ID3 tags, using the same format th" +
					"at Foobar2000 uses.");
			this.id3TagRadio.UseVisualStyleBackColor = true;
			// 
			// lameTagRadio
			// 
			this.lameTagRadio.AutoSize = true;
			this.lameTagRadio.Checked = true;
			this.lameTagRadio.Location = new System.Drawing.Point(9, 74);
			this.lameTagRadio.Name = "lameTagRadio";
			this.lameTagRadio.Size = new System.Drawing.Size(115, 17);
			this.lameTagRadio.TabIndex = 0;
			this.lameTagRadio.TabStop = true;
			this.lameTagRadio.Text = "LAME tag (Default)";
			this.toolTip1.SetToolTip(this.lameTagRadio, "By default since 3.94, Lame has calculated the track-based ReplayGain value, and " +
					"stored it inside the MP3 Info Tag. Very few MP3 players take advantage of this t" +
					"ag.");
			this.lameTagRadio.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 256);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(448, 33);
			this.panel1.TabIndex = 1;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(364, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(284, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// albumArtBox
			// 
			this.albumArtBox.Controls.Add(this.kbLabel);
			this.albumArtBox.Controls.Add(this.maxImageSize);
			this.albumArtBox.Controls.Add(this.artSizeLabel);
			this.albumArtBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.albumArtBox.Location = new System.Drawing.Point(3, 201);
			this.albumArtBox.Name = "albumArtBox";
			this.albumArtBox.Size = new System.Drawing.Size(448, 49);
			this.albumArtBox.TabIndex = 2;
			this.albumArtBox.TabStop = false;
			this.albumArtBox.Text = "Embedded Album Art";
			// 
			// kbLabel
			// 
			this.kbLabel.AutoSize = true;
			this.kbLabel.Location = new System.Drawing.Point(163, 22);
			this.kbLabel.Name = "kbLabel";
			this.kbLabel.Size = new System.Drawing.Size(20, 13);
			this.kbLabel.TabIndex = 2;
			this.kbLabel.Text = "kB";
			// 
			// maxImageSize
			// 
			this.maxImageSize.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
			this.maxImageSize.Location = new System.Drawing.Point(87, 20);
			this.maxImageSize.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
			this.maxImageSize.Name = "maxImageSize";
			this.maxImageSize.Size = new System.Drawing.Size(70, 20);
			this.maxImageSize.TabIndex = 1;
			this.toolTip1.SetToolTip(this.maxImageSize, "Sets the maximum size of album art that will be copied over into the MP3 file. Ca" +
					"nnot be set higher than 16384kB (16MB).");
			this.maxImageSize.Value = new decimal(new int[] {
            16384,
            0,
            0,
            0});
			// 
			// artSizeLabel
			// 
			this.artSizeLabel.AutoSize = true;
			this.artSizeLabel.Location = new System.Drawing.Point(6, 22);
			this.artSizeLabel.Name = "artSizeLabel";
			this.artSizeLabel.Size = new System.Drawing.Size(75, 13);
			this.artSizeLabel.TabIndex = 0;
			this.artSizeLabel.Text = "Maximum size:";
			// 
			// TaggingOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 292);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "TaggingOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tagging Options";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.replayGainBox.ResumeLayout(false);
			this.replayGainBox.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.albumArtBox.ResumeLayout(false);
			this.albumArtBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxImageSize)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox replayGainBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.RadioButton lameTagRadio;
		private System.Windows.Forms.RadioButton id3TagRadio;
		private System.Windows.Forms.RadioButton noneRadio;
		private System.Windows.Forms.RadioButton albumRadio;
		private System.Windows.Forms.RadioButton trackRadio;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label replayGainLabel;
		private System.Windows.Forms.GroupBox albumArtBox;
		private System.Windows.Forms.Label kbLabel;
		private System.Windows.Forms.NumericUpDown maxImageSize;
		private System.Windows.Forms.Label artSizeLabel;
	}
}