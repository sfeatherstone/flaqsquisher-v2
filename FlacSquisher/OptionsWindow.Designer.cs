namespace FlacSquisher {
	partial class OptionsWindow {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.defaultsButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.copyExts = new System.Windows.Forms.TextBox();
			this.copyExtsLabel = new System.Windows.Forms.Label();
			this.fileextsLabel = new System.Windows.Forms.Label();
			this.fileExts = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.encodingOptionsButton = new System.Windows.Forms.Button();
			this.hidewin = new System.Windows.Forms.CheckBox();
			this.encoderBox = new System.Windows.Forms.GroupBox();
			this.metaflacButton = new System.Windows.Forms.Button();
			this.lameButton = new System.Windows.Forms.Button();
			this.flacButton = new System.Windows.Forms.Button();
			this.oggButton = new System.Windows.Forms.Button();
			this.metaflacLocation = new System.Windows.Forms.TextBox();
			this.metaflacLabel = new System.Windows.Forms.Label();
			this.lameLocation = new System.Windows.Forms.TextBox();
			this.lameLabel = new System.Windows.Forms.Label();
			this.flacLocation = new System.Windows.Forms.TextBox();
			this.flacLabel = new System.Windows.Forms.Label();
			this.oggLocation = new System.Windows.Forms.TextBox();
			this.oggLabel = new System.Windows.Forms.Label();
			this.thirdPartyLameBox = new System.Windows.Forms.CheckBox();
			this.thirdPartyLameTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.encoderBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.encoderBox, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.09882F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.90119F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 381);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Controls.Add(this.defaultsButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 350);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(418, 28);
			this.panel1.TabIndex = 0;
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(259, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(340, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// defaultsButton
			// 
			this.defaultsButton.Location = new System.Drawing.Point(3, 3);
			this.defaultsButton.Name = "defaultsButton";
			this.defaultsButton.Size = new System.Drawing.Size(75, 23);
			this.defaultsButton.TabIndex = 0;
			this.defaultsButton.Text = "Defaults";
			this.defaultsButton.UseVisualStyleBackColor = true;
			this.defaultsButton.Click += new System.EventHandler(this.defaultsButton_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.copyExts);
			this.panel2.Controls.Add(this.copyExtsLabel);
			this.panel2.Controls.Add(this.fileextsLabel);
			this.panel2.Controls.Add(this.fileExts);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 256);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(418, 88);
			this.panel2.TabIndex = 2;
			// 
			// copyExts
			// 
			this.copyExts.Location = new System.Drawing.Point(3, 59);
			this.copyExts.Name = "copyExts";
			this.copyExts.Size = new System.Drawing.Size(412, 20);
			this.copyExts.TabIndex = 5;
			// 
			// copyExtsLabel
			// 
			this.copyExtsLabel.AutoSize = true;
			this.copyExtsLabel.Location = new System.Drawing.Point(3, 43);
			this.copyExtsLabel.Name = "copyExtsLabel";
			this.copyExtsLabel.Size = new System.Drawing.Size(114, 13);
			this.copyExtsLabel.TabIndex = 4;
			this.copyExtsLabel.Text = "File extensions to copy";
			// 
			// fileextsLabel
			// 
			this.fileextsLabel.AutoSize = true;
			this.fileextsLabel.Location = new System.Drawing.Point(3, 4);
			this.fileextsLabel.Name = "fileextsLabel";
			this.fileextsLabel.Size = new System.Drawing.Size(120, 13);
			this.fileextsLabel.TabIndex = 2;
			this.fileextsLabel.Text = "File extensions to ignore";
			// 
			// fileExts
			// 
			this.fileExts.Location = new System.Drawing.Point(3, 20);
			this.fileExts.Name = "fileExts";
			this.fileExts.Size = new System.Drawing.Size(412, 20);
			this.fileExts.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.thirdPartyLameBox);
			this.panel3.Controls.Add(this.encodingOptionsButton);
			this.panel3.Controls.Add(this.hidewin);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 193);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(418, 57);
			this.panel3.TabIndex = 3;
			// 
			// encodingOptionsButton
			// 
			this.encodingOptionsButton.Location = new System.Drawing.Point(301, 7);
			this.encodingOptionsButton.Name = "encodingOptionsButton";
			this.encodingOptionsButton.Size = new System.Drawing.Size(108, 23);
			this.encodingOptionsButton.TabIndex = 1;
			this.encodingOptionsButton.Text = "Encoding Options...";
			this.encodingOptionsButton.UseVisualStyleBackColor = true;
			this.encodingOptionsButton.Click += new System.EventHandler(this.encodingOptionsButton_Click);
			// 
			// hidewin
			// 
			this.hidewin.AutoSize = true;
			this.hidewin.Location = new System.Drawing.Point(9, 7);
			this.hidewin.Name = "hidewin";
			this.hidewin.Size = new System.Drawing.Size(178, 17);
			this.hidewin.TabIndex = 0;
			this.hidewin.Text = "Hide Command Prompt windows";
			this.hidewin.UseVisualStyleBackColor = true;
			// 
			// encoderBox
			// 
			this.encoderBox.Controls.Add(this.metaflacButton);
			this.encoderBox.Controls.Add(this.lameButton);
			this.encoderBox.Controls.Add(this.flacButton);
			this.encoderBox.Controls.Add(this.oggButton);
			this.encoderBox.Controls.Add(this.metaflacLocation);
			this.encoderBox.Controls.Add(this.metaflacLabel);
			this.encoderBox.Controls.Add(this.lameLocation);
			this.encoderBox.Controls.Add(this.lameLabel);
			this.encoderBox.Controls.Add(this.flacLocation);
			this.encoderBox.Controls.Add(this.flacLabel);
			this.encoderBox.Controls.Add(this.oggLocation);
			this.encoderBox.Controls.Add(this.oggLabel);
			this.encoderBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.encoderBox.Location = new System.Drawing.Point(3, 3);
			this.encoderBox.Name = "encoderBox";
			this.encoderBox.Size = new System.Drawing.Size(418, 184);
			this.encoderBox.TabIndex = 4;
			this.encoderBox.TabStop = false;
			this.encoderBox.Text = "Encoders";
			// 
			// metaflacButton
			// 
			this.metaflacButton.Location = new System.Drawing.Point(340, 147);
			this.metaflacButton.Name = "metaflacButton";
			this.metaflacButton.Size = new System.Drawing.Size(75, 23);
			this.metaflacButton.TabIndex = 11;
			this.metaflacButton.Text = "Choose...";
			this.metaflacButton.UseVisualStyleBackColor = true;
			this.metaflacButton.Click += new System.EventHandler(this.metaflacButton_Click);
			// 
			// lameButton
			// 
			this.lameButton.Location = new System.Drawing.Point(340, 108);
			this.lameButton.Name = "lameButton";
			this.lameButton.Size = new System.Drawing.Size(75, 23);
			this.lameButton.TabIndex = 10;
			this.lameButton.Text = "Choose...";
			this.lameButton.UseVisualStyleBackColor = true;
			this.lameButton.Click += new System.EventHandler(this.lameButton_Click);
			// 
			// flacButton
			// 
			this.flacButton.Location = new System.Drawing.Point(340, 69);
			this.flacButton.Name = "flacButton";
			this.flacButton.Size = new System.Drawing.Size(75, 23);
			this.flacButton.TabIndex = 9;
			this.flacButton.Text = "Choose...";
			this.flacButton.UseVisualStyleBackColor = true;
			this.flacButton.Click += new System.EventHandler(this.flacButton_Click);
			// 
			// oggButton
			// 
			this.oggButton.Location = new System.Drawing.Point(340, 30);
			this.oggButton.Name = "oggButton";
			this.oggButton.Size = new System.Drawing.Size(75, 23);
			this.oggButton.TabIndex = 8;
			this.oggButton.Text = "Choose...";
			this.oggButton.UseVisualStyleBackColor = true;
			this.oggButton.Click += new System.EventHandler(this.oggButton_Click);
			// 
			// metaflacLocation
			// 
			this.metaflacLocation.Location = new System.Drawing.Point(3, 149);
			this.metaflacLocation.Name = "metaflacLocation";
			this.metaflacLocation.Size = new System.Drawing.Size(331, 20);
			this.metaflacLocation.TabIndex = 7;
			// 
			// metaflacLabel
			// 
			this.metaflacLabel.AutoSize = true;
			this.metaflacLabel.Location = new System.Drawing.Point(3, 133);
			this.metaflacLabel.Name = "metaflacLabel";
			this.metaflacLabel.Size = new System.Drawing.Size(48, 13);
			this.metaflacLabel.TabIndex = 6;
			this.metaflacLabel.Text = "Metaflac";
			// 
			// lameLocation
			// 
			this.lameLocation.Location = new System.Drawing.Point(3, 110);
			this.lameLocation.Name = "lameLocation";
			this.lameLocation.Size = new System.Drawing.Size(331, 20);
			this.lameLocation.TabIndex = 5;
			// 
			// lameLabel
			// 
			this.lameLabel.AutoSize = true;
			this.lameLabel.Location = new System.Drawing.Point(3, 94);
			this.lameLabel.Name = "lameLabel";
			this.lameLabel.Size = new System.Drawing.Size(76, 13);
			this.lameLabel.TabIndex = 4;
			this.lameLabel.Text = "Lame Encoder";
			// 
			// flacLocation
			// 
			this.flacLocation.Location = new System.Drawing.Point(3, 71);
			this.flacLocation.Name = "flacLocation";
			this.flacLocation.Size = new System.Drawing.Size(331, 20);
			this.flacLocation.TabIndex = 3;
			// 
			// flacLabel
			// 
			this.flacLabel.AutoSize = true;
			this.flacLabel.Location = new System.Drawing.Point(3, 55);
			this.flacLabel.Name = "flacLabel";
			this.flacLabel.Size = new System.Drawing.Size(70, 13);
			this.flacLabel.TabIndex = 2;
			this.flacLabel.Text = "Flac Encoder";
			// 
			// oggLocation
			// 
			this.oggLocation.Location = new System.Drawing.Point(3, 32);
			this.oggLocation.Name = "oggLocation";
			this.oggLocation.Size = new System.Drawing.Size(331, 20);
			this.oggLocation.TabIndex = 1;
			// 
			// oggLabel
			// 
			this.oggLabel.AutoSize = true;
			this.oggLabel.Location = new System.Drawing.Point(3, 16);
			this.oggLabel.Name = "oggLabel";
			this.oggLabel.Size = new System.Drawing.Size(70, 13);
			this.oggLabel.TabIndex = 0;
			this.oggLabel.Text = "Ogg Encoder";
			// 
			// thirdPartyLameBox
			// 
			this.thirdPartyLameBox.AutoSize = true;
			this.thirdPartyLameBox.Location = new System.Drawing.Point(9, 30);
			this.thirdPartyLameBox.Name = "thirdPartyLameBox";
			this.thirdPartyLameBox.Size = new System.Drawing.Size(185, 17);
			this.thirdPartyLameBox.TabIndex = 12;
			this.thirdPartyLameBox.Text = "Using non-standard copy of Lame";
			this.thirdPartyLameTooltip.SetToolTip(this.thirdPartyLameBox, "Check this if you downloaded Lame yourself");
			this.thirdPartyLameBox.UseVisualStyleBackColor = true;
			// 
			// OptionsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 381);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "OptionsWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.encoderBox.ResumeLayout(false);
			this.encoderBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button defaultsButton;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label fileextsLabel;
		private System.Windows.Forms.TextBox fileExts;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button encodingOptionsButton;
		private System.Windows.Forms.CheckBox hidewin;
		private System.Windows.Forms.GroupBox encoderBox;
		private System.Windows.Forms.Label flacLabel;
		private System.Windows.Forms.TextBox oggLocation;
		private System.Windows.Forms.Label oggLabel;
		private System.Windows.Forms.Button oggButton;
		private System.Windows.Forms.TextBox metaflacLocation;
		private System.Windows.Forms.Label metaflacLabel;
		private System.Windows.Forms.TextBox lameLocation;
		private System.Windows.Forms.Label lameLabel;
		private System.Windows.Forms.TextBox flacLocation;
		private System.Windows.Forms.Button flacButton;
		private System.Windows.Forms.Button lameButton;
		private System.Windows.Forms.Button metaflacButton;
		private System.Windows.Forms.TextBox copyExts;
		private System.Windows.Forms.Label copyExtsLabel;
		private System.Windows.Forms.CheckBox thirdPartyLameBox;
		private System.Windows.Forms.ToolTip thirdPartyLameTooltip;
	}
}