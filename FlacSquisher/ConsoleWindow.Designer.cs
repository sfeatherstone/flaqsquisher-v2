namespace FlacSquisher {
	partial class ConsoleWindow {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.consoleTextbox = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.clearButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.consoleTextbox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.21805F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.78195F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 266);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// consoleTextbox
			// 
			this.consoleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.consoleTextbox.Location = new System.Drawing.Point(3, 3);
			this.consoleTextbox.Multiline = true;
			this.consoleTextbox.Name = "consoleTextbox";
			this.consoleTextbox.ReadOnly = true;
			this.consoleTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.consoleTextbox.Size = new System.Drawing.Size(286, 226);
			this.consoleTextbox.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.clearButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 235);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(286, 28);
			this.panel1.TabIndex = 1;
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(3, 3);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(89, 23);
			this.clearButton.TabIndex = 0;
			this.clearButton.Text = "Clear console";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// ConsoleWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ConsoleWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ConsoleWindow";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox consoleTextbox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button clearButton;
	}
}