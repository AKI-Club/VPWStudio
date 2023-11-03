
namespace VPWStudio
{
	partial class StringRenderTest
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
			this.pbStringPreview = new System.Windows.Forms.PictureBox();
			this.gbText = new System.Windows.Forms.GroupBox();
			this.tbPreviewText = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbStringPreview)).BeginInit();
			this.gbText.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbStringPreview
			// 
			this.pbStringPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pbStringPreview.Location = new System.Drawing.Point(12, 149);
			this.pbStringPreview.MaximumSize = new System.Drawing.Size(480, 240);
			this.pbStringPreview.MinimumSize = new System.Drawing.Size(480, 240);
			this.pbStringPreview.Name = "pbStringPreview";
			this.pbStringPreview.Size = new System.Drawing.Size(480, 240);
			this.pbStringPreview.TabIndex = 0;
			this.pbStringPreview.TabStop = false;
			// 
			// gbText
			// 
			this.gbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbText.Controls.Add(this.tbPreviewText);
			this.gbText.Location = new System.Drawing.Point(12, 12);
			this.gbText.Name = "gbText";
			this.gbText.Size = new System.Drawing.Size(480, 131);
			this.gbText.TabIndex = 2;
			this.gbText.TabStop = false;
			this.gbText.Text = "&Text";
			// 
			// tbPreviewText
			// 
			this.tbPreviewText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPreviewText.Location = new System.Drawing.Point(3, 16);
			this.tbPreviewText.MaxLength = 65535;
			this.tbPreviewText.Multiline = true;
			this.tbPreviewText.Name = "tbPreviewText";
			this.tbPreviewText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbPreviewText.Size = new System.Drawing.Size(474, 112);
			this.tbPreviewText.TabIndex = 0;
			this.tbPreviewText.TextChanged += new System.EventHandler(this.tbPreviewText_TextChanged);
			// 
			// StringRenderTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 401);
			this.Controls.Add(this.gbText);
			this.Controls.Add(this.pbStringPreview);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(520, 414);
			this.Name = "StringRenderTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "String Render Test";
			((System.ComponentModel.ISupportInitialize)(this.pbStringPreview)).EndInit();
			this.gbText.ResumeLayout(false);
			this.gbText.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbStringPreview;
		private System.Windows.Forms.GroupBox gbText;
		private System.Windows.Forms.TextBox tbPreviewText;
	}
}