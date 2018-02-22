namespace VPWStudio
{
	partial class FileTable_TexPreviewDialog
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
			this.pbPreview = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// pbPreview
			// 
			this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPreview.Location = new System.Drawing.Point(0, 0);
			this.pbPreview.Margin = new System.Windows.Forms.Padding(0);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(248, 229);
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// FileTable_TexPreviewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(248, 229);
			this.Controls.Add(this.pbPreview);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.MinimumSize = new System.Drawing.Size(16, 16);
			this.Name = "FileTable_TexPreviewDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preview";
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbPreview;
	}
}