namespace VPWStudio
{
	partial class WrestlerEditMain
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
			this.tbTempInfoDump = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbTempInfoDump
			// 
			this.tbTempInfoDump.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTempInfoDump.Location = new System.Drawing.Point(12, 12);
			this.tbTempInfoDump.Multiline = true;
			this.tbTempInfoDump.Name = "tbTempInfoDump";
			this.tbTempInfoDump.ReadOnly = true;
			this.tbTempInfoDump.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbTempInfoDump.Size = new System.Drawing.Size(492, 249);
			this.tbTempInfoDump.TabIndex = 0;
			// 
			// WrestlerEditMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 273);
			this.Controls.Add(this.tbTempInfoDump);
			this.MinimumSize = new System.Drawing.Size(524, 300);
			this.Name = "WrestlerEditMain";
			this.Text = "Wrestlers";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbTempInfoDump;
	}
}