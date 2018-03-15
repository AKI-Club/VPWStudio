namespace VPWStudio.Editors
{
	partial class FontDialog
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
			this.gbCharacters = new System.Windows.Forms.GroupBox();
			this.lbCharacters = new System.Windows.Forms.ListBox();
			this.gbCharacters.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCharacters
			// 
			this.gbCharacters.Controls.Add(this.lbCharacters);
			this.gbCharacters.Location = new System.Drawing.Point(12, 41);
			this.gbCharacters.Name = "gbCharacters";
			this.gbCharacters.Size = new System.Drawing.Size(109, 402);
			this.gbCharacters.TabIndex = 0;
			this.gbCharacters.TabStop = false;
			this.gbCharacters.Text = "Characters";
			// 
			// lbCharacters
			// 
			this.lbCharacters.FormattingEnabled = true;
			this.lbCharacters.Location = new System.Drawing.Point(6, 19);
			this.lbCharacters.Name = "lbCharacters";
			this.lbCharacters.ScrollAlwaysVisible = true;
			this.lbCharacters.Size = new System.Drawing.Size(97, 368);
			this.lbCharacters.TabIndex = 0;
			this.lbCharacters.SelectedIndexChanged += new System.EventHandler(this.lbCharacters_SelectedIndexChanged);
			// 
			// FontDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 455);
			this.Controls.Add(this.gbCharacters);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::VPWStudio.Properties.Resources.Font;
			this.MaximizeBox = false;
			this.Name = "FontDialog";
			this.Text = "Fonts";
			this.gbCharacters.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCharacters;
		private System.Windows.Forms.ListBox lbCharacters;
	}
}