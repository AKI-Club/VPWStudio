namespace VPWStudio
{
	partial class AkiArchiveTool
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
			this.components = new System.ComponentModel.Container();
			this.gbArchiveFiles = new System.Windows.Forms.GroupBox();
			this.buttonReplace = new System.Windows.Forms.Button();
			this.buttonExtract = new System.Windows.Forms.Button();
			this.lbFiles = new System.Windows.Forms.ListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.gbSelItem = new System.Windows.Forms.GroupBox();
			this.buttonOpenAs = new System.Windows.Forms.Button();
			this.cmsOpenAs = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.akiTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonViewHexEditor = new System.Windows.Forms.Button();
			this.tbSelItemInfo = new System.Windows.Forms.TextBox();
			this.cI4PaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cI8PaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.gbArchiveFiles.SuspendLayout();
			this.gbSelItem.SuspendLayout();
			this.cmsOpenAs.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbArchiveFiles
			// 
			this.gbArchiveFiles.Controls.Add(this.buttonReplace);
			this.gbArchiveFiles.Controls.Add(this.buttonExtract);
			this.gbArchiveFiles.Controls.Add(this.lbFiles);
			this.gbArchiveFiles.Location = new System.Drawing.Point(12, 12);
			this.gbArchiveFiles.Name = "gbArchiveFiles";
			this.gbArchiveFiles.Size = new System.Drawing.Size(200, 431);
			this.gbArchiveFiles.TabIndex = 0;
			this.gbArchiveFiles.TabStop = false;
			this.gbArchiveFiles.Text = "&Files";
			// 
			// buttonReplace
			// 
			this.buttonReplace.Location = new System.Drawing.Point(104, 402);
			this.buttonReplace.Name = "buttonReplace";
			this.buttonReplace.Size = new System.Drawing.Size(90, 23);
			this.buttonReplace.TabIndex = 3;
			this.buttonReplace.Text = "&Replace File...";
			this.buttonReplace.UseVisualStyleBackColor = true;
			this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
			// 
			// buttonExtract
			// 
			this.buttonExtract.Location = new System.Drawing.Point(6, 402);
			this.buttonExtract.Name = "buttonExtract";
			this.buttonExtract.Size = new System.Drawing.Size(90, 23);
			this.buttonExtract.TabIndex = 2;
			this.buttonExtract.Text = "&Export File...";
			this.buttonExtract.UseVisualStyleBackColor = true;
			this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
			// 
			// lbFiles
			// 
			this.lbFiles.FormattingEnabled = true;
			this.lbFiles.Location = new System.Drawing.Point(6, 19);
			this.lbFiles.Name = "lbFiles";
			this.lbFiles.Size = new System.Drawing.Size(188, 368);
			this.lbFiles.TabIndex = 1;
			this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_SelectedIndexChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(466, 420);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 7;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(547, 420);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// gbSelItem
			// 
			this.gbSelItem.Controls.Add(this.buttonOpenAs);
			this.gbSelItem.Controls.Add(this.buttonViewHexEditor);
			this.gbSelItem.Controls.Add(this.tbSelItemInfo);
			this.gbSelItem.Location = new System.Drawing.Point(218, 12);
			this.gbSelItem.Name = "gbSelItem";
			this.gbSelItem.Size = new System.Drawing.Size(402, 400);
			this.gbSelItem.TabIndex = 4;
			this.gbSelItem.TabStop = false;
			this.gbSelItem.Text = "Selected &Item";
			// 
			// buttonOpenAs
			// 
			this.buttonOpenAs.ContextMenuStrip = this.cmsOpenAs;
			this.buttonOpenAs.Location = new System.Drawing.Point(307, 371);
			this.buttonOpenAs.Name = "buttonOpenAs";
			this.buttonOpenAs.Size = new System.Drawing.Size(89, 23);
			this.buttonOpenAs.TabIndex = 9;
			this.buttonOpenAs.Text = "Open As...";
			this.buttonOpenAs.UseVisualStyleBackColor = true;
			this.buttonOpenAs.Click += new System.EventHandler(this.buttonOpenAs_Click);
			// 
			// cmsOpenAs
			// 
			this.cmsOpenAs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akiTextureToolStripMenuItem,
            this.iTextureToolStripMenuItem,
            this.toolStripSeparator1,
            this.cI4PaletteToolStripMenuItem,
            this.cI8PaletteToolStripMenuItem});
			this.cmsOpenAs.Name = "cmsOpenAs";
			this.cmsOpenAs.Size = new System.Drawing.Size(181, 120);
			// 
			// akiTextureToolStripMenuItem
			// 
			this.akiTextureToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.FileType_AkiTexture;
			this.akiTextureToolStripMenuItem.Name = "akiTextureToolStripMenuItem";
			this.akiTextureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.akiTextureToolStripMenuItem.Text = "AkiTexture";
			this.akiTextureToolStripMenuItem.Click += new System.EventHandler(this.akiTextureToolStripMenuItem_Click);
			// 
			// iTextureToolStripMenuItem
			// 
			this.iTextureToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.FileType_I4Texture;
			this.iTextureToolStripMenuItem.Name = "iTextureToolStripMenuItem";
			this.iTextureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.iTextureToolStripMenuItem.Text = "ITexture";
			this.iTextureToolStripMenuItem.Click += new System.EventHandler(this.iTextureToolStripMenuItem_Click);
			// 
			// buttonViewHexEditor
			// 
			this.buttonViewHexEditor.Location = new System.Drawing.Point(6, 371);
			this.buttonViewHexEditor.Name = "buttonViewHexEditor";
			this.buttonViewHexEditor.Size = new System.Drawing.Size(99, 23);
			this.buttonViewHexEditor.TabIndex = 6;
			this.buttonViewHexEditor.Text = "&Hex Viewer...";
			this.buttonViewHexEditor.UseVisualStyleBackColor = true;
			this.buttonViewHexEditor.Click += new System.EventHandler(this.buttonViewHexEditor_Click);
			// 
			// tbSelItemInfo
			// 
			this.tbSelItemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSelItemInfo.Location = new System.Drawing.Point(6, 19);
			this.tbSelItemInfo.Multiline = true;
			this.tbSelItemInfo.Name = "tbSelItemInfo";
			this.tbSelItemInfo.ReadOnly = true;
			this.tbSelItemInfo.Size = new System.Drawing.Size(390, 346);
			this.tbSelItemInfo.TabIndex = 5;
			// 
			// cI4PaletteToolStripMenuItem
			// 
			this.cI4PaletteToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.FileType_Ci4Palette;
			this.cI4PaletteToolStripMenuItem.Name = "cI4PaletteToolStripMenuItem";
			this.cI4PaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cI4PaletteToolStripMenuItem.Text = "CI4Palette";
			this.cI4PaletteToolStripMenuItem.Click += new System.EventHandler(this.cI4PaletteToolStripMenuItem_Click);
			// 
			// cI8PaletteToolStripMenuItem
			// 
			this.cI8PaletteToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.FileType_Ci8Palette;
			this.cI8PaletteToolStripMenuItem.Name = "cI8PaletteToolStripMenuItem";
			this.cI8PaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cI8PaletteToolStripMenuItem.Text = "CI8Palette";
			this.cI8PaletteToolStripMenuItem.Click += new System.EventHandler(this.cI8PaletteToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// AkiArchiveTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 455);
			this.Controls.Add(this.gbSelItem);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbArchiveFiles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "AkiArchiveTool";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AKI Archive Tool";
			this.gbArchiveFiles.ResumeLayout(false);
			this.gbSelItem.ResumeLayout(false);
			this.gbSelItem.PerformLayout();
			this.cmsOpenAs.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbArchiveFiles;
		private System.Windows.Forms.ListBox lbFiles;
		private System.Windows.Forms.Button buttonReplace;
		private System.Windows.Forms.Button buttonExtract;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox gbSelItem;
		private System.Windows.Forms.Button buttonViewHexEditor;
		private System.Windows.Forms.TextBox tbSelItemInfo;
		private System.Windows.Forms.Button buttonOpenAs;
		private System.Windows.Forms.ContextMenuStrip cmsOpenAs;
		private System.Windows.Forms.ToolStripMenuItem akiTextureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iTextureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cI4PaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cI8PaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}