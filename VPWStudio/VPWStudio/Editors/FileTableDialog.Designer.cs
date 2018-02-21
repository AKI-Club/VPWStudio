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
			this.chFileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chLzss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsFileEntry = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.extractFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripFileTable = new System.Windows.Forms.MenuStrip();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMidwaydecFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.extractRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFileEntry.SuspendLayout();
			this.menuStripFileTable.SuspendLayout();
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
            this.chFileType,
            this.chLzss,
            this.chComments});
			this.lvFileList.ContextMenuStrip = this.cmsFileEntry;
			this.lvFileList.FullRowSelect = true;
			this.lvFileList.GridLines = true;
			this.lvFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvFileList.Location = new System.Drawing.Point(12, 27);
			this.lvFileList.Name = "lvFileList";
			this.lvFileList.ShowGroups = false;
			this.lvFileList.Size = new System.Drawing.Size(568, 393);
			this.lvFileList.TabIndex = 1;
			this.lvFileList.UseCompatibleStateImageBehavior = false;
			this.lvFileList.View = System.Windows.Forms.View.Details;
			this.lvFileList.DoubleClick += new System.EventHandler(this.lvFileList_DoubleClick);
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
			// chFileType
			// 
			this.chFileType.Text = "File Type";
			this.chFileType.Width = 64;
			// 
			// chLzss
			// 
			this.chLzss.Text = "LZSS";
			this.chLzss.Width = 44;
			// 
			// chComments
			// 
			this.chComments.Text = "Comments";
			this.chComments.Width = 224;
			// 
			// cmsFileEntry
			// 
			this.cmsFileEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.extractFileToolStripMenuItem,
            this.extractRawToolStripMenuItem});
			this.cmsFileEntry.Name = "cmsFileEntry";
			this.cmsFileEntry.Size = new System.Drawing.Size(164, 98);
			this.cmsFileEntry.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFileEntry_Opening);
			// 
			// editInformationToolStripMenuItem
			// 
			this.editInformationToolStripMenuItem.Name = "editInformationToolStripMenuItem";
			this.editInformationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.editInformationToolStripMenuItem.Text = "Edit &Information...";
			this.editInformationToolStripMenuItem.Click += new System.EventHandler(this.editInformationToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
			// 
			// extractFileToolStripMenuItem
			// 
			this.extractFileToolStripMenuItem.Name = "extractFileToolStripMenuItem";
			this.extractFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.extractFileToolStripMenuItem.Tag = "ExtractFile";
			this.extractFileToolStripMenuItem.Text = "&Extract File...";
			this.extractFileToolStripMenuItem.Click += new System.EventHandler(this.extractFileToolStripMenuItem_Click);
			// 
			// menuStripFileTable
			// 
			this.menuStripFileTable.AllowMerge = false;
			this.menuStripFileTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
			this.menuStripFileTable.Location = new System.Drawing.Point(0, 0);
			this.menuStripFileTable.Name = "menuStripFileTable";
			this.menuStripFileTable.Size = new System.Drawing.Size(592, 24);
			this.menuStripFileTable.TabIndex = 2;
			this.menuStripFileTable.Text = "menuStrip1";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportMidwaydecFileListToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.exportToolStripMenuItem.Text = "&Export";
			// 
			// exportMidwaydecFileListToolStripMenuItem
			// 
			this.exportMidwaydecFileListToolStripMenuItem.Name = "exportMidwaydecFileListToolStripMenuItem";
			this.exportMidwaydecFileListToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.exportMidwaydecFileListToolStripMenuItem.Text = "Export &Midwaydec File List...";
			this.exportMidwaydecFileListToolStripMenuItem.Click += new System.EventHandler(this.exportMidwaydecFileListToolStripMenuItem_Click);
			// 
			// extractRawToolStripMenuItem
			// 
			this.extractRawToolStripMenuItem.Name = "extractRawToolStripMenuItem";
			this.extractRawToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.extractRawToolStripMenuItem.Text = "Extract &Raw...";
			this.extractRawToolStripMenuItem.Click += new System.EventHandler(this.extractRawToolStripMenuItem_Click);
			// 
			// FileTableDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 432);
			this.Controls.Add(this.menuStripFileTable);
			this.Controls.Add(this.lvFileList);
			this.MainMenuStrip = this.menuStripFileTable;
			this.Name = "FileTableDialog";
			this.Text = "File Table";
			this.cmsFileEntry.ResumeLayout(false);
			this.menuStripFileTable.ResumeLayout(false);
			this.menuStripFileTable.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListView lvFileList;
		private System.Windows.Forms.ColumnHeader chFileID;
		private System.Windows.Forms.ColumnHeader chLocation;
		private System.Windows.Forms.ColumnHeader chLzss;
		private System.Windows.Forms.ColumnHeader chComments;
		private System.Windows.Forms.ColumnHeader chRomAddr;
		private System.Windows.Forms.ContextMenuStrip cmsFileEntry;
		private System.Windows.Forms.ToolStripMenuItem extractFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem editInformationToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader chFileType;
		private System.Windows.Forms.MenuStrip menuStripFileTable;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportMidwaydecFileListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem extractRawToolStripMenuItem;
	}
}