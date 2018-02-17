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
			this.lbWrestlerEntries = new System.Windows.Forms.ListBox();
			this.editControl_VPW2 = new VPWStudio.Controls.WrestlerEdit_VPW2();
			this.SuspendLayout();
			// 
			// tbTempInfoDump
			// 
			this.tbTempInfoDump.Location = new System.Drawing.Point(12, 163);
			this.tbTempInfoDump.Multiline = true;
			this.tbTempInfoDump.Name = "tbTempInfoDump";
			this.tbTempInfoDump.ReadOnly = true;
			this.tbTempInfoDump.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbTempInfoDump.Size = new System.Drawing.Size(274, 143);
			this.tbTempInfoDump.TabIndex = 0;
			// 
			// lbWrestlerEntries
			// 
			this.lbWrestlerEntries.FormattingEnabled = true;
			this.lbWrestlerEntries.Location = new System.Drawing.Point(12, 12);
			this.lbWrestlerEntries.Name = "lbWrestlerEntries";
			this.lbWrestlerEntries.ScrollAlwaysVisible = true;
			this.lbWrestlerEntries.Size = new System.Drawing.Size(274, 134);
			this.lbWrestlerEntries.TabIndex = 2;
			this.lbWrestlerEntries.SelectedIndexChanged += new System.EventHandler(this.lbWrestlerEntries_SelectedIndexChanged);
			// 
			// editControl_VPW2
			// 
			this.editControl_VPW2.Location = new System.Drawing.Point(292, 12);
			this.editControl_VPW2.Name = "editControl_VPW2";
			this.editControl_VPW2.Size = new System.Drawing.Size(450, 300);
			this.editControl_VPW2.TabIndex = 1;
			// 
			// WrestlerEditMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 318);
			this.Controls.Add(this.lbWrestlerEntries);
			this.Controls.Add(this.editControl_VPW2);
			this.Controls.Add(this.tbTempInfoDump);
			this.MinimumSize = new System.Drawing.Size(524, 300);
			this.Name = "WrestlerEditMain";
			this.Text = "Wrestlers";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbTempInfoDump;
		private Controls.WrestlerEdit_VPW2 editControl_VPW2;
		private System.Windows.Forms.ListBox lbWrestlerEntries;
	}
}