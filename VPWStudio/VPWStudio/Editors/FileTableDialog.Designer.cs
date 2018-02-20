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
			this.extractFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.editInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chFileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.chFileType,
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
			this.chComments.Width = 224;
			// 
			// cmsFileEntry
			// 
			this.cmsFileEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.extractFileToolStripMenuItem});
			this.cmsFileEntry.Name = "cmsFileEntry";
			this.cmsFileEntry.Size = new System.Drawing.Size(164, 76);
			// 
			// extractFileToolStripMenuItem
			// 
			this.extractFileToolStripMenuItem.Name = "extractFileToolStripMenuItem";
			this.extractFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.extractFileToolStripMenuItem.Text = "&Extract File...";
			this.extractFileToolStripMenuItem.Click += new System.EventHandler(this.extractFileToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
			// 
			// editInformationToolStripMenuItem
			// 
			this.editInformationToolStripMenuItem.Name = "editInformationToolStripMenuItem";
			this.editInformationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.editInformationToolStripMenuItem.Text = "Edit &Information...";
			this.editInformationToolStripMenuItem.Click += new System.EventHandler(this.editInformationToolStripMenuItem_Click);
			// 
			// chFileType
			// 
			this.chFileType.Text = "File Type";
			this.chFileType.Width = 64;
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
		private System.Windows.Forms.ToolStripMenuItem extractFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem editInformationToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader chFileType;
	}
}