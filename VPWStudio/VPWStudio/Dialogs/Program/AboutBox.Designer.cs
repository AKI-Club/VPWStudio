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
			this.llWebsite = new System.Windows.Forms.LinkLabel();
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
			this.tbInformation.Size = new System.Drawing.Size(497, 243);
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
			this.pictureBox1.Size = new System.Drawing.Size(506, 80);
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
			this.tlpMain.Size = new System.Drawing.Size(506, 395);
			this.tlpMain.TabIndex = 26;
			// 
			// labelVersion
			// 
			this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelVersion.Location = new System.Drawing.Point(6, 87);
			this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelVersion.MinimumSize = new System.Drawing.Size(271, 17);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(497, 17);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "(version string)";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tlpBottomSection
			// 
			this.tlpBottomSection.ColumnCount = 2;
			this.tlpBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.2F));
			this.tlpBottomSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.8F));
			this.tlpBottomSection.Controls.Add(this.okButton, 1, 0);
			this.tlpBottomSection.Controls.Add(this.llWebsite, 0, 0);
			this.tlpBottomSection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpBottomSection.Location = new System.Drawing.Point(3, 364);
			this.tlpBottomSection.Name = "tlpBottomSection";
			this.tlpBottomSection.RowCount = 1;
			this.tlpBottomSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpBottomSection.Size = new System.Drawing.Size(500, 28);
			this.tlpBottomSection.TabIndex = 30;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(323, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(174, 22);
			this.okButton.TabIndex = 3;
			this.okButton.Text = "&OK, sure, just get me out of here.";
			// 
			// llWebsite
			// 
			this.llWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.llWebsite.AutoSize = true;
			this.llWebsite.Location = new System.Drawing.Point(3, 7);
			this.llWebsite.Name = "llWebsite";
			this.llWebsite.Size = new System.Drawing.Size(314, 13);
			this.llWebsite.TabIndex = 2;
			this.llWebsite.TabStop = true;
			this.llWebsite.Text = "http://vpw.ajworld.net/";
			this.llWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llWebsite_LinkClicked);
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(506, 395);
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
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.TableLayoutPanel tlpBottomSection;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.LinkLabel llWebsite;
	}
}
