namespace VPWStudio
{
	partial class AkiTextTool
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
			this.tbInfoDump = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbInfoDump
			// 
			this.tbInfoDump.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInfoDump.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbInfoDump.Location = new System.Drawing.Point(12, 12);
			this.tbInfoDump.MaxLength = 65535;
			this.tbInfoDump.Multiline = true;
			this.tbInfoDump.Name = "tbInfoDump";
			this.tbInfoDump.ReadOnly = true;
			this.tbInfoDump.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbInfoDump.Size = new System.Drawing.Size(467, 249);
			this.tbInfoDump.TabIndex = 0;
			// 
			// AkiTextTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 273);
			this.Controls.Add(this.tbInfoDump);
			this.Name = "AkiTextTool";
			this.Text = "AkiTextTool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbInfoDump;
	}
}