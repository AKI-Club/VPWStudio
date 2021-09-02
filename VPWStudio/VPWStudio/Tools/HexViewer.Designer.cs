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
			this.hexBox1.Copied += new System.EventHandler(this.hexBox1_Copied);
			// 
			// HexViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.hexBox1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 600);
			this.MinimumSize = new System.Drawing.Size(640, 400);
			this.Name = "HexViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "Hex Viewer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HexViewer_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private Be.Windows.Forms.HexBox hexBox1;
	}
}