namespace VPWStudio
{
	partial class HexViewer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.hexBox1 = new Be.Windows.Forms.HexBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labelHexViewStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelInsertMode = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// hexBox1
			// 
			this.hexBox1.ColumnInfoVisible = true;
			this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hexBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hexBox1.LineInfoVisible = true;
			this.hexBox1.Location = new System.Drawing.Point(0, 0);
			this.hexBox1.Name = "hexBox1";
			this.hexBox1.ReadOnly = true;
			this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.hexBox1.Size = new System.Drawing.Size(624, 361);
			this.hexBox1.StringViewVisible = true;
			this.hexBox1.TabIndex = 0;
			this.hexBox1.UseFixedBytesPerLine = true;
			this.hexBox1.VScrollBarVisible = true;
			this.hexBox1.InsertActiveChanged += new System.EventHandler(this.hexBox1_InsertActiveChanged);
			this.hexBox1.Copied += new System.EventHandler(this.hexBox1_Copied);
			this.hexBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hexBox1_KeyUp);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelHexViewStatus,
            this.labelInsertMode});
			this.statusStrip1.Location = new System.Drawing.Point(0, 337);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(624, 24);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labelHexViewStatus
			// 
			this.labelHexViewStatus.Name = "labelHexViewStatus";
			this.labelHexViewStatus.Size = new System.Drawing.Size(549, 19);
			this.labelHexViewStatus.Spring = true;
			this.labelHexViewStatus.Text = "test";
			this.labelHexViewStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelInsertMode
			// 
			this.labelInsertMode.BackColor = System.Drawing.SystemColors.Control;
			this.labelInsertMode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.labelInsertMode.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.labelInsertMode.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelInsertMode.Name = "labelInsertMode";
			this.labelInsertMode.Size = new System.Drawing.Size(60, 19);
			this.labelInsertMode.Text = "ins ovr";
			this.labelInsertMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// HexViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.hexBox1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 600);
			this.MinimumSize = new System.Drawing.Size(640, 400);
			this.Name = "HexViewer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "Hex Viewer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HexViewer_FormClosing);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Be.Windows.Forms.HexBox hexBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labelHexViewStatus;
		private System.Windows.Forms.ToolStripStatusLabel labelInsertMode;
	}
}