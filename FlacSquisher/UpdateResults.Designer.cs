namespace FlacSquisher {
	partial class UpdateResults {
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
			this.results = new System.Windows.Forms.Label();
			this.yesButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// results
			// 
			this.results.AutoSize = true;
			this.results.Location = new System.Drawing.Point(12, 9);
			this.results.Name = "results";
			this.results.Size = new System.Drawing.Size(35, 13);
			this.results.TabIndex = 0;
			this.results.Text = "label1";
			// 
			// yesButton
			// 
			this.yesButton.Location = new System.Drawing.Point(12, 105);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(75, 23);
			this.yesButton.TabIndex = 1;
			this.yesButton.Text = "Yes";
			this.yesButton.UseVisualStyleBackColor = true;
			this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(147, 105);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// UpdateResults
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(234, 140);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.yesButton);
			this.Controls.Add(this.results);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "UpdateResults";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FlacSquisher Update";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label results;
		private System.Windows.Forms.Button yesButton;
		private System.Windows.Forms.Button cancelButton;
	}
}