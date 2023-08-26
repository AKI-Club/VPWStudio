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
			this.chProjComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsFileEntry = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.setTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuBackgroundReplacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.viewHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHexRomDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHexReplacementFileDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.extractFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.extractRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripFileTable = new System.Windows.Forms.MenuStrip();
			this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.goToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchFileTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadFileTableDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMidwaydecFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelSelectedItems = new System.Windows.Forms.ToolStripStatusLabel();
			this.exportFileTableDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsFileEntry.SuspendLayout();
			this.menuStripFileTable.SuspendLayout();
			this.statusStrip1.SuspendLayout();
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
            this.chComments,
            this.chProjComments});
			this.lvFileList.ContextMenuStrip = this.cmsFileEntry;
			this.lvFileList.FullRowSelect = true;
			this.lvFileList.GridLines = true;
			this.lvFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvFileList.HideSelection = false;
			this.lvFileList.Location = new System.Drawing.Point(12, 27);
			this.lvFileList.Name = "lvFileList";
			this.lvFileList.ShowGroups = false;
			this.lvFileList.Size = new System.Drawing.Size(680, 389);
			this.lvFileList.TabIndex = 1;
			this.lvFileList.UseCompatibleStateImageBehavior = false;
			this.lvFileList.View = System.Windows.Forms.View.Details;
			this.lvFileList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvFileList_ItemSelectionChanged);
			this.lvFileList.SelectedIndexChanged += new System.EventHandler(this.lvFileList_SelectedIndexChanged);
			this.lvFileList.DoubleClick += new System.EventHandler(this.lvFileList_DoubleClick);
			this.lvFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFileList_KeyDown);
			// 
			// chFileID
			// 
			this.chFileID.Text = "File ID";
			this.chFileID.Width = 44;
			// 
			// chLocation
			// 
			this.chLocation.Text = "Location";
			this.chLocation.Width = 80;
			// 
			// chRomAddr
			// 
			this.chRomAddr.Text = "ROM Address";
			this.chRomAddr.Width = 80;
			// 
			// chFileType
			// 
			this.chFileType.Text = "File Type";
			this.chFileType.Width = 98;
			// 
			// chLzss
			// 
			this.chLzss.Text = "LZSS";
			this.chLzss.Width = 44;
			// 
			// chComments
			// 
			this.chComments.Text = "Comments";
			this.chComments.Width = 232;
			// 
			// chProjComments
			// 
			this.chProjComments.Text = "Project-Specific Comments";
			this.chProjComments.Width = 232;
			// 
			// cmsFileEntry
			// 
			this.cmsFileEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTypeToolStripMenuItem,
            this.editInformationToolStripMenuItem,
            this.menuBackgroundReplacementToolStripMenuItem,
            this.toolStripSeparator3,
            this.viewHexToolStripMenuItem,
            this.toolStripSeparator1,
            this.extractFileToolStripMenuItem,
            this.extractRawToolStripMenuItem});
			this.cmsFileEntry.Name = "cmsFileEntry";
			this.cmsFileEntry.Size = new System.Drawing.Size(251, 148);
			this.cmsFileEntry.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFileEntry_Opening);
			// 
			// setTypeToolStripMenuItem
			// 
			this.setTypeToolStripMenuItem.Name = "setTypeToolStripMenuItem";
			this.setTypeToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.setTypeToolStripMenuItem.Text = "Set &Type";
			// 
			// editInformationToolStripMenuItem
			// 
			this.editInformationToolStripMenuItem.Name = "editInformationToolStripMenuItem";
			this.editInformationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.editInformationToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.editInformationToolStripMenuItem.Text = "Edit &Information...";
			this.editInformationToolStripMenuItem.Click += new System.EventHandler(this.editInformationToolStripMenuItem_Click);
			// 
			// menuBackgroundReplacementToolStripMenuItem
			// 
			this.menuBackgroundReplacementToolStripMenuItem.Enabled = false;
			this.menuBackgroundReplacementToolStripMenuItem.Name = "menuBackgroundReplacementToolStripMenuItem";
			this.menuBackgroundReplacementToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.menuBackgroundReplacementToolStripMenuItem.Text = "&MenuBackground Replacement...";
			this.menuBackgroundReplacementToolStripMenuItem.Visible = false;
			this.menuBackgroundReplacementToolStripMenuItem.Click += new System.EventHandler(this.menuBackgroundReplacementToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(247, 6);
			// 
			// viewHexToolStripMenuItem
			// 
			this.viewHexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHexRomDataToolStripMenuItem,
            this.viewHexReplacementFileDataToolStripMenuItem});
			this.viewHexToolStripMenuItem.Name = "viewHexToolStripMenuItem";
			this.viewHexToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.viewHexToolStripMenuItem.Text = "View &Hex";
			// 
			// viewHexRomDataToolStripMenuItem
			// 
			this.viewHexRomDataToolStripMenuItem.Name = "viewHexRomDataToolStripMenuItem";
			this.viewHexRomDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.viewHexRomDataToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.viewHexRomDataToolStripMenuItem.Text = "ROM Data...";
			this.viewHexRomDataToolStripMenuItem.Click += new System.EventHandler(this.viewHexRomDataToolStripMenuItem_Click);
			// 
			// viewHexReplacementFileDataToolStripMenuItem
			// 
			this.viewHexReplacementFileDataToolStripMenuItem.Name = "viewHexReplacementFileDataToolStripMenuItem";
			this.viewHexReplacementFileDataToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.viewHexReplacementFileDataToolStripMenuItem.Text = "ReplacementFile Data...";
			this.viewHexReplacementFileDataToolStripMenuItem.Click += new System.EventHandler(this.viewHexReplacementFileDataToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(247, 6);
			// 
			// extractFileToolStripMenuItem
			// 
			this.extractFileToolStripMenuItem.Name = "extractFileToolStripMenuItem";
			this.extractFileToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.extractFileToolStripMenuItem.Tag = "ExtractFile";
			this.extractFileToolStripMenuItem.Text = "&Extract File...";
			this.extractFileToolStripMenuItem.Click += new System.EventHandler(this.extractFileToolStripMenuItem_Click);
			// 
			// extractRawToolStripMenuItem
			// 
			this.extractRawToolStripMenuItem.Name = "extractRawToolStripMenuItem";
			this.extractRawToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
			this.extractRawToolStripMenuItem.Text = "Extract &Raw...";
			this.extractRawToolStripMenuItem.Click += new System.EventHandler(this.extractRawToolStripMenuItem_Click);
			// 
			// menuStripFileTable
			// 
			this.menuStripFileTable.AllowMerge = false;
			this.menuStripFileTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navigationToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.exportToolStripMenuItem});
			this.menuStripFileTable.Location = new System.Drawing.Point(0, 0);
			this.menuStripFileTable.Name = "menuStripFileTable";
			this.menuStripFileTable.Size = new System.Drawing.Size(704, 24);
			this.menuStripFileTable.TabIndex = 2;
			this.menuStripFileTable.Text = "menuStrip1";
			// 
			// navigationToolStripMenuItem
			// 
			this.navigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem,
            this.toolStripSeparator2,
            this.goToTopToolStripMenuItem,
            this.goToBottomToolStripMenuItem,
            this.toolStripSeparator4,
            this.searchToolStripMenuItem,
            this.searchFileTypeToolStripMenuItem,
            this.findNextToolStripMenuItem});
			this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
			this.navigationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.navigationToolStripMenuItem.Text = "&Navigation";
			// 
			// goToToolStripMenuItem
			// 
			this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
			this.goToToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.goToToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.goToToolStripMenuItem.Text = "&Go to...";
			this.goToToolStripMenuItem.Click += new System.EventHandler(this.goToToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
			// 
			// goToTopToolStripMenuItem
			// 
			this.goToTopToolStripMenuItem.Name = "goToTopToolStripMenuItem";
			this.goToTopToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.goToTopToolStripMenuItem.Text = "Go to Top";
			this.goToTopToolStripMenuItem.Click += new System.EventHandler(this.goToTopToolStripMenuItem_Click);
			// 
			// goToBottomToolStripMenuItem
			// 
			this.goToBottomToolStripMenuItem.Name = "goToBottomToolStripMenuItem";
			this.goToBottomToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.goToBottomToolStripMenuItem.Text = "Go to Bottom";
			this.goToBottomToolStripMenuItem.Click += new System.EventHandler(this.goToBottomToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.searchToolStripMenuItem.Text = "&Search Text...";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
			// 
			// searchFileTypeToolStripMenuItem
			// 
			this.searchFileTypeToolStripMenuItem.Name = "searchFileTypeToolStripMenuItem";
			this.searchFileTypeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.searchFileTypeToolStripMenuItem.Text = "Search FileType...";
			this.searchFileTypeToolStripMenuItem.Click += new System.EventHandler(this.searchFileTypeToolStripMenuItem_Click);
			// 
			// findNextToolStripMenuItem
			// 
			this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
			this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.findNextToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.findNextToolStripMenuItem.Text = "Find &Next";
			this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
			// 
			// databaseToolStripMenuItem
			// 
			this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadFileTableDatabaseToolStripMenuItem});
			this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
			this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.databaseToolStripMenuItem.Text = "&Database";
			// 
			// reloadFileTableDatabaseToolStripMenuItem
			// 
			this.reloadFileTableDatabaseToolStripMenuItem.Name = "reloadFileTableDatabaseToolStripMenuItem";
			this.reloadFileTableDatabaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.reloadFileTableDatabaseToolStripMenuItem.Text = "&Reload File Table Database";
			this.reloadFileTableDatabaseToolStripMenuItem.Click += new System.EventHandler(this.reloadFileTableDatabaseToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportMidwaydecFileListToolStripMenuItem,
            this.exportCSVToolStripMenuItem,
            this.exportFileTableDBToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.exportToolStripMenuItem.Text = "&Export";
			// 
			// exportMidwaydecFileListToolStripMenuItem
			// 
			this.exportMidwaydecFileListToolStripMenuItem.Name = "exportMidwaydecFileListToolStripMenuItem";
			this.exportMidwaydecFileListToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.exportMidwaydecFileListToolStripMenuItem.Text = "Export &Midwaydec File List...";
			this.exportMidwaydecFileListToolStripMenuItem.Click += new System.EventHandler(this.exportMidwaydecFileListToolStripMenuItem_Click);
			// 
			// exportCSVToolStripMenuItem
			// 
			this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
			this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.exportCSVToolStripMenuItem.Text = "Export &CSV...";
			this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelSelectedItems});
			this.statusStrip1.Location = new System.Drawing.Point(0, 419);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(704, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssLabelSelectedItems
			// 
			this.tssLabelSelectedItems.Name = "tssLabelSelectedItems";
			this.tssLabelSelectedItems.Size = new System.Drawing.Size(92, 17);
			this.tssLabelSelectedItems.Text = "# items selected";
			// 
			// exportFileTableDBToolStripMenuItem
			// 
			this.exportFileTableDBToolStripMenuItem.Name = "exportFileTableDBToolStripMenuItem";
			this.exportFileTableDBToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
			this.exportFileTableDBToolStripMenuItem.Text = "Export &FileTableDB...";
			this.exportFileTableDBToolStripMenuItem.Click += new System.EventHandler(this.exportFileTableDBToolStripMenuItem_Click);
			// 
			// FileTableDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 441);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStripFileTable);
			this.Controls.Add(this.lvFileList);
			this.MainMenuStrip = this.menuStripFileTable;
			this.MinimumSize = new System.Drawing.Size(720, 480);
			this.Name = "FileTableDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Table";
			this.cmsFileEntry.ResumeLayout(false);
			this.menuStripFileTable.ResumeLayout(false);
			this.menuStripFileTable.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem goToTopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToBottomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reloadFileTableDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setTypeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewHexToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuBackgroundReplacementToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelSelectedItems;
		private System.Windows.Forms.ColumnHeader chProjComments;
		private System.Windows.Forms.ToolStripMenuItem searchFileTypeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewHexRomDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewHexReplacementFileDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportFileTableDBToolStripMenuItem;
	}
}