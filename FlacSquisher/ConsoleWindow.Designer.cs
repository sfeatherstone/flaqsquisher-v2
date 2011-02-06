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
			this.consoleListView = new System.Windows.Forms.ListView();
			this.fileNameHeader = new System.Windows.Forms.ColumnHeader();
			this.consoleText = new System.Windows.Forms.ColumnHeader();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.consoleListView, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.07483F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.92517F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 294);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// consoleListView
			// 
			this.consoleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameHeader,
            this.consoleText});
			this.consoleListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.consoleListView.FullRowSelect = true;
			this.consoleListView.Location = new System.Drawing.Point(3, 3);
			this.consoleListView.Name = "consoleListView";
			this.consoleListView.ShowItemToolTips = true;
			this.consoleListView.Size = new System.Drawing.Size(466, 288);
			this.consoleListView.TabIndex = 0;
			this.consoleListView.UseCompatibleStateImageBehavior = false;
			this.consoleListView.View = System.Windows.Forms.View.Details;
			this.consoleListView.DoubleClick += new System.EventHandler(this.consoleListView_DoubleClick);
			// 
			// fileNameHeader
			// 
			this.fileNameHeader.Text = "FileName";
			this.fileNameHeader.Width = 250;
			// 
			// consoleText
			// 
			this.consoleText.Text = "Error Message";
			this.consoleText.Width = 210;
			// 
			// ConsoleWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 294);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ConsoleWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ConsoleWindow";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListView consoleListView;
		private System.Windows.Forms.ColumnHeader fileNameHeader;
		private System.Windows.Forms.ColumnHeader consoleText;
	}
}