namespace VPWStudio
{
	partial class FileTableDialog
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
			this.lvFileList = new System.Windows.Forms.ListView();
			this.chFileID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chRomAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chLzss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsFileEntry = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.extractRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.setCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFileEntry.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvFileList
			// 
			this.lvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileID,
            this.chLocation,
            this.chRomAddr,
            this.chLzss,
            this.chComments});
			this.lvFileList.ContextMenuStrip = this.cmsFileEntry;
			this.lvFileList.FullRowSelect = true;
			this.lvFileList.GridLines = true;
			this.lvFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvFileList.Location = new System.Drawing.Point(12, 12);
			this.lvFileList.Name = "lvFileList";
			this.lvFileList.ShowGroups = false;
			this.lvFileList.Size = new System.Drawing.Size(568, 390);
			this.lvFileList.TabIndex = 1;
			this.lvFileList.UseCompatibleStateImageBehavior = false;
			this.lvFileList.View = System.Windows.Forms.View.Details;
			// 
			// chFileID
			// 
			this.chFileID.Text = "File ID";
			this.chFileID.Width = 44;
			// 
			// chLocation
			// 
			this.chLocation.Text = "Location";
			this.chLocation.Width = 85;
			// 
			// chRomAddr
			// 
			this.chRomAddr.Text = "ROM Address";
			this.chRomAddr.Width = 85;
			// 
			// chLzss
			// 
			this.chLzss.Text = "LZSS";
			this.chLzss.Width = 44;
			// 
			// chComments
			// 
			this.chComments.Text = "Comments";
			this.chComments.Width = 256;
			// 
			// cmsFileEntry
			// 
			this.cmsFileEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractRawToolStripMenuItem,
            this.toolStripSeparator1,
            this.setCommentToolStripMenuItem});
			this.cmsFileEntry.Name = "cmsFileEntry";
			this.cmsFileEntry.Size = new System.Drawing.Size(151, 54);
			// 
			// extractRawToolStripMenuItem
			// 
			this.extractRawToolStripMenuItem.Name = "extractRawToolStripMenuItem";
			this.extractRawToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.extractRawToolStripMenuItem.Text = "&Extract Raw...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
			// 
			// setCommentToolStripMenuItem
			// 
			this.setCommentToolStripMenuItem.Name = "setCommentToolStripMenuItem";
			this.setCommentToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.setCommentToolStripMenuItem.Text = "Set &Comment...";
			this.setCommentToolStripMenuItem.Click += new System.EventHandler(this.setCommentToolStripMenuItem_Click);
			// 
			// FileTableDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 414);
			this.Controls.Add(this.lvFileList);
			this.Name = "FileTableDialog";
			this.Text = "File Table";
			this.cmsFileEntry.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView lvFileList;
		private System.Windows.Forms.ColumnHeader chFileID;
		private System.Windows.Forms.ColumnHeader chLocation;
		private System.Windows.Forms.ColumnHeader chLzss;
		private System.Windows.Forms.ColumnHeader chComments;
		private System.Windows.Forms.ColumnHeader chRomAddr;
		private System.Windows.Forms.ContextMenuStrip cmsFileEntry;
		private System.Windows.Forms.ToolStripMenuItem extractRawToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem setCommentToolStripMenuItem;
	}
}