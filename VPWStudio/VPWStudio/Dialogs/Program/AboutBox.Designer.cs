namespace VPWStudio
{
	partial class AboutBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.tbInformation = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.labelVersion = new System.Windows.Forms.Label();
			this.tlpBottomSection = new System.Windows.Forms.TableLayoutPanel();
			this.okButton = new System.Windows.Forms.Button();
			this.linkLabelAJWorld = new System.Windows.Forms.LinkLabel();
			this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tlpMain.SuspendLayout();
			this.tlpBottomSection.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbInformation
			// 
			this.tbInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbInformation.Location = new System.Drawing.Point(6, 115);
			this.tbInformation.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.tbInformation.Multiline = true;
			this.tbInformation.Name = "tbInformation";
			this.tbInformation.ReadOnly = true;
			this.tbInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbInformation.Size = new System.Drawing.Size(575, 243);
			this.tbInformation.TabIndex = 1;
			this.tbInformation.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::VPWStudio.Properties.Resources.AboutBox_Banner;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(584, 80);
			this.pictureBox1.TabIndex = 25;
			this.pictureBox1.TabStop = false;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.labelVersion, 0, 1);
			this.tlpMain.Controls.Add(this.pictureBox1, 0, 0);
			this.tlpMain.Controls.Add(this.tbInformation, 0, 2);
			this.tlpMain.Controls.Add(this.tlpBottomSection, 0, 3);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 4;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.16949F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.98305F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.50847F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.Size = new System.Drawing.Size(584, 395);
			this.tlpMain.TabIndex = 26;
			// 
			// labelVersion
			// 
			this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelVersion.Location = new System.Drawing.Point(3, 82);
			this.labelVersion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.labelVersion.Size = new System.Drawing.Size(578, 28);
			this.labelVersion.TabIndex = 31;
			this.labelVersion.Text = "(version string)";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tlpBottomSection
			// 
			this.tlpBottomSection.ColumnCount = 3;
			this.tlpBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tlpBottomSection.Controls.Add(this.linkLabelAJWorld, 0, 0);
			this.tlpBottomSection.Controls.Add(this.okButton, 2, 0);
			this.tlpBottomSection.Controls.Add(this.linkLabelGitHub, 1, 0);
			this.tlpBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpBottomSection.Location = new System.Drawing.Point(3, 364);
			this.tlpBottomSection.Name = "tlpBottomSection";
			this.tlpBottomSection.RowCount = 1;
			this.tlpBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBottomSection.Size = new System.Drawing.Size(578, 28);
			this.tlpBottomSection.TabIndex = 30;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(378, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(197, 22);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "&OK, sure, just get me out of here.";
			// 
			// linkLabelAJWorld
			// 
			this.linkLabelAJWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelAJWorld.AutoSize = true;
			this.linkLabelAJWorld.Location = new System.Drawing.Point(3, 7);
			this.linkLabelAJWorld.Name = "linkLabelAJWorld";
			this.linkLabelAJWorld.Size = new System.Drawing.Size(138, 13);
			this.linkLabelAJWorld.TabIndex = 2;
			this.linkLabelAJWorld.TabStop = true;
			this.linkLabelAJWorld.Text = "https://vpw.ajworld.net/";
			this.linkLabelAJWorld.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAJWorld_LinkClicked);
			// 
			// linkLabelGitHub
			// 
			this.linkLabelGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelGitHub.AutoSize = true;
			this.linkLabelGitHub.Location = new System.Drawing.Point(147, 7);
			this.linkLabelGitHub.Name = "linkLabelGitHub";
			this.linkLabelGitHub.Size = new System.Drawing.Size(225, 13);
			this.linkLabelGitHub.TabIndex = 3;
			this.linkLabelGitHub.TabStop = true;
			this.linkLabelGitHub.Text = "https://github.com/AKI-Club/VPWStudio";
			this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(584, 395);
			this.Controls.Add(this.tlpMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutBox";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.tlpBottomSection.ResumeLayout(false);
			this.tlpBottomSection.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox tbInformation;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private System.Windows.Forms.TableLayoutPanel tlpBottomSection;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.LinkLabel linkLabelAJWorld;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.LinkLabel linkLabelGitHub;
	}
}
