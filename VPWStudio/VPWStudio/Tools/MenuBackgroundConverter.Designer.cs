namespace VPWStudio
{
	partial class MenuBackgroundConverter
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tlpImage = new System.Windows.Forms.TableLayoutPanel();
			this.labelImageConvert = new System.Windows.Forms.Label();
			this.buttonBrowseImage = new System.Windows.Forms.Button();
			this.tbImage = new System.Windows.Forms.TextBox();
			this.tlpGame = new System.Windows.Forms.TableLayoutPanel();
			this.cbTargetGame = new System.Windows.Forms.ComboBox();
			this.labelTargetGame = new System.Windows.Forms.Label();
			this.tlpOutDir = new System.Windows.Forms.TableLayoutPanel();
			this.buttonBrowseOutput = new System.Windows.Forms.Button();
			this.labelOutputDir = new System.Windows.Forms.Label();
			this.tbOutputDir = new System.Windows.Forms.TextBox();
			this.tlpImage.SuspendLayout();
			this.tlpGame.SuspendLayout();
			this.tlpOutDir.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(327, 137);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(408, 137);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tlpImage
			// 
			this.tlpImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpImage.ColumnCount = 3;
			this.tlpImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImage.Controls.Add(this.labelImageConvert, 0, 0);
			this.tlpImage.Controls.Add(this.buttonBrowseImage, 2, 0);
			this.tlpImage.Controls.Add(this.tbImage, 1, 0);
			this.tlpImage.Location = new System.Drawing.Point(12, 12);
			this.tlpImage.Name = "tlpImage";
			this.tlpImage.RowCount = 1;
			this.tlpImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpImage.Size = new System.Drawing.Size(471, 36);
			this.tlpImage.TabIndex = 2;
			// 
			// labelImageConvert
			// 
			this.labelImageConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelImageConvert.AutoSize = true;
			this.labelImageConvert.Location = new System.Drawing.Point(3, 11);
			this.labelImageConvert.Name = "labelImageConvert";
			this.labelImageConvert.Size = new System.Drawing.Size(88, 13);
			this.labelImageConvert.TabIndex = 0;
			this.labelImageConvert.Text = "&Image to Convert";
			// 
			// buttonBrowseImage
			// 
			this.buttonBrowseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseImage.Location = new System.Drawing.Point(379, 6);
			this.buttonBrowseImage.Name = "buttonBrowseImage";
			this.buttonBrowseImage.Size = new System.Drawing.Size(89, 23);
			this.buttonBrowseImage.TabIndex = 1;
			this.buttonBrowseImage.Text = "&Browse...";
			this.buttonBrowseImage.UseVisualStyleBackColor = true;
			this.buttonBrowseImage.Click += new System.EventHandler(this.buttonBrowseImage_Click);
			// 
			// tbImage
			// 
			this.tbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbImage.Location = new System.Drawing.Point(97, 8);
			this.tbImage.Name = "tbImage";
			this.tbImage.Size = new System.Drawing.Size(276, 20);
			this.tbImage.TabIndex = 0;
			// 
			// tlpGame
			// 
			this.tlpGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpGame.ColumnCount = 2;
			this.tlpGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tlpGame.Controls.Add(this.cbTargetGame, 1, 0);
			this.tlpGame.Controls.Add(this.labelTargetGame, 0, 0);
			this.tlpGame.Location = new System.Drawing.Point(12, 53);
			this.tlpGame.Name = "tlpGame";
			this.tlpGame.RowCount = 1;
			this.tlpGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpGame.Size = new System.Drawing.Size(471, 36);
			this.tlpGame.TabIndex = 3;
			// 
			// cbTargetGame
			// 
			this.cbTargetGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTargetGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTargetGame.FormattingEnabled = true;
			this.cbTargetGame.Items.AddRange(new object[] {
            "WrestleMania 2000 (320x24)",
            "VPW2, No Mercy (64x30)"});
			this.cbTargetGame.Location = new System.Drawing.Point(97, 7);
			this.cbTargetGame.Name = "cbTargetGame";
			this.cbTargetGame.Size = new System.Drawing.Size(371, 21);
			this.cbTargetGame.TabIndex = 2;
			// 
			// labelTargetGame
			// 
			this.labelTargetGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTargetGame.AutoSize = true;
			this.labelTargetGame.Location = new System.Drawing.Point(3, 11);
			this.labelTargetGame.Name = "labelTargetGame";
			this.labelTargetGame.Size = new System.Drawing.Size(88, 13);
			this.labelTargetGame.TabIndex = 2;
			this.labelTargetGame.Text = "Target &Game";
			// 
			// tlpOutDir
			// 
			this.tlpOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpOutDir.ColumnCount = 3;
			this.tlpOutDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpOutDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpOutDir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpOutDir.Controls.Add(this.buttonBrowseOutput, 2, 0);
			this.tlpOutDir.Controls.Add(this.labelOutputDir, 0, 0);
			this.tlpOutDir.Controls.Add(this.tbOutputDir, 1, 0);
			this.tlpOutDir.Location = new System.Drawing.Point(12, 95);
			this.tlpOutDir.Name = "tlpOutDir";
			this.tlpOutDir.RowCount = 1;
			this.tlpOutDir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOutDir.Size = new System.Drawing.Size(471, 36);
			this.tlpOutDir.TabIndex = 4;
			// 
			// buttonBrowseOutput
			// 
			this.buttonBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseOutput.Location = new System.Drawing.Point(379, 6);
			this.buttonBrowseOutput.Name = "buttonBrowseOutput";
			this.buttonBrowseOutput.Size = new System.Drawing.Size(89, 23);
			this.buttonBrowseOutput.TabIndex = 4;
			this.buttonBrowseOutput.Text = "B&rowse...";
			this.buttonBrowseOutput.UseVisualStyleBackColor = true;
			this.buttonBrowseOutput.Click += new System.EventHandler(this.buttonBrowseOutput_Click);
			// 
			// labelOutputDir
			// 
			this.labelOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutputDir.AutoSize = true;
			this.labelOutputDir.Location = new System.Drawing.Point(3, 11);
			this.labelOutputDir.Name = "labelOutputDir";
			this.labelOutputDir.Size = new System.Drawing.Size(88, 13);
			this.labelOutputDir.TabIndex = 3;
			this.labelOutputDir.Text = "Output &Directory";
			// 
			// tbOutputDir
			// 
			this.tbOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputDir.Location = new System.Drawing.Point(97, 8);
			this.tbOutputDir.Name = "tbOutputDir";
			this.tbOutputDir.Size = new System.Drawing.Size(276, 20);
			this.tbOutputDir.TabIndex = 3;
			// 
			// MenuBackgroundConverter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(495, 172);
			this.Controls.Add(this.tlpOutDir);
			this.Controls.Add(this.tlpGame);
			this.Controls.Add(this.tlpImage);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MenuBackgroundConverter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Menu Background Converter";
			this.tlpImage.ResumeLayout(false);
			this.tlpImage.PerformLayout();
			this.tlpGame.ResumeLayout(false);
			this.tlpGame.PerformLayout();
			this.tlpOutDir.ResumeLayout(false);
			this.tlpOutDir.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tlpImage;
		private System.Windows.Forms.Label labelImageConvert;
		private System.Windows.Forms.TableLayoutPanel tlpGame;
		private System.Windows.Forms.ComboBox cbTargetGame;
		private System.Windows.Forms.Label labelTargetGame;
		private System.Windows.Forms.Button buttonBrowseImage;
		private System.Windows.Forms.TextBox tbImage;
		private System.Windows.Forms.TableLayoutPanel tlpOutDir;
		private System.Windows.Forms.Button buttonBrowseOutput;
		private System.Windows.Forms.Label labelOutputDir;
		private System.Windows.Forms.TextBox tbOutputDir;
	}
}