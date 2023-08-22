namespace VPWStudio
{
	partial class NewProjectDialog
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tlpCustomLoc = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetCustomLocFile = new System.Windows.Forms.Button();
			this.tbCustomLocationFile = new System.Windows.Forms.TextBox();
			this.labelOutROM = new System.Windows.Forms.Label();
			this.labelProjectName = new System.Windows.Forms.Label();
			this.tbProjectName = new System.Windows.Forms.TextBox();
			this.labelRomFile = new System.Windows.Forms.Label();
			this.tlpRomFile = new System.Windows.Forms.TableLayoutPanel();
			this.buttonOpenROM = new System.Windows.Forms.Button();
			this.tbRomFile = new System.Windows.Forms.TextBox();
			this.labelGameType = new System.Windows.Forms.Label();
			this.cbGameVersion = new System.Windows.Forms.ComboBox();
			this.labelAuthors = new System.Windows.Forms.Label();
			this.tbAuthors = new System.Windows.Forms.TextBox();
			this.tlpOutROM = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetOutROM = new System.Windows.Forms.Button();
			this.tbOutROMPath = new System.Windows.Forms.TextBox();
			this.chbCustomLocation = new System.Windows.Forms.CheckBox();
			this.chbCustomFileTableDB = new System.Windows.Forms.CheckBox();
			this.tlpCustomFileTableDB = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetCustomFileTableDBFile = new System.Windows.Forms.Button();
			this.tbCustomFileTableDBFile = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tlpCustomLoc.SuspendLayout();
			this.tlpRomFile.SuspendLayout();
			this.tlpOutROM.SuspendLayout();
			this.tlpCustomFileTableDB.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(326, 258);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(407, 258);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tableLayoutPanel1.Controls.Add(this.tlpCustomLoc, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelOutROM, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelProjectName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbProjectName, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelRomFile, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tlpRomFile, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelGameType, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.cbGameVersion, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelAuthors, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbAuthors, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tlpOutROM, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.chbCustomLocation, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.chbCustomFileTableDB, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.tlpCustomFileTableDB, 1, 6);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 240);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// tlpCustomLoc
			// 
			this.tlpCustomLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpCustomLoc.ColumnCount = 2;
			this.tlpCustomLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpCustomLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpCustomLoc.Controls.Add(this.buttonSetCustomLocFile, 1, 0);
			this.tlpCustomLoc.Controls.Add(this.tbCustomLocationFile, 0, 0);
			this.tlpCustomLoc.Location = new System.Drawing.Point(167, 173);
			this.tlpCustomLoc.Name = "tlpCustomLoc";
			this.tlpCustomLoc.RowCount = 1;
			this.tlpCustomLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCustomLoc.Size = new System.Drawing.Size(300, 28);
			this.tlpCustomLoc.TabIndex = 9;
			// 
			// buttonSetCustomLocFile
			// 
			this.buttonSetCustomLocFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetCustomLocFile.Enabled = false;
			this.buttonSetCustomLocFile.Location = new System.Drawing.Point(273, 3);
			this.buttonSetCustomLocFile.Name = "buttonSetCustomLocFile";
			this.buttonSetCustomLocFile.Size = new System.Drawing.Size(24, 22);
			this.buttonSetCustomLocFile.TabIndex = 1;
			this.buttonSetCustomLocFile.Text = "...";
			this.buttonSetCustomLocFile.UseVisualStyleBackColor = true;
			this.buttonSetCustomLocFile.Click += new System.EventHandler(this.buttonSetCustomLocFile_Click);
			// 
			// tbCustomLocationFile
			// 
			this.tbCustomLocationFile.AllowDrop = true;
			this.tbCustomLocationFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCustomLocationFile.Enabled = false;
			this.tbCustomLocationFile.Location = new System.Drawing.Point(3, 4);
			this.tbCustomLocationFile.Name = "tbCustomLocationFile";
			this.tbCustomLocationFile.Size = new System.Drawing.Size(264, 20);
			this.tbCustomLocationFile.TabIndex = 2;
			this.tbCustomLocationFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCustomLocationFile_DragDrop);
			this.tbCustomLocationFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCustomLocationFile_DragEnter);
			// 
			// labelOutROM
			// 
			this.labelOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutROM.AutoSize = true;
			this.labelOutROM.Location = new System.Drawing.Point(3, 146);
			this.labelOutROM.Name = "labelOutROM";
			this.labelOutROM.Size = new System.Drawing.Size(158, 13);
			this.labelOutROM.TabIndex = 5;
			this.labelOutROM.Text = "Output ROM &File";
			// 
			// labelProjectName
			// 
			this.labelProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelProjectName.AutoSize = true;
			this.labelProjectName.Location = new System.Drawing.Point(3, 10);
			this.labelProjectName.Name = "labelProjectName";
			this.labelProjectName.Size = new System.Drawing.Size(158, 13);
			this.labelProjectName.TabIndex = 0;
			this.labelProjectName.Text = "Project &Name";
			// 
			// tbProjectName
			// 
			this.tbProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProjectName.Location = new System.Drawing.Point(167, 7);
			this.tbProjectName.Name = "tbProjectName";
			this.tbProjectName.Size = new System.Drawing.Size(300, 20);
			this.tbProjectName.TabIndex = 0;
			// 
			// labelRomFile
			// 
			this.labelRomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRomFile.AutoSize = true;
			this.labelRomFile.Location = new System.Drawing.Point(3, 112);
			this.labelRomFile.Name = "labelRomFile";
			this.labelRomFile.Size = new System.Drawing.Size(158, 13);
			this.labelRomFile.TabIndex = 3;
			this.labelRomFile.Text = "&Base ROM File";
			// 
			// tlpRomFile
			// 
			this.tlpRomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpRomFile.ColumnCount = 2;
			this.tlpRomFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpRomFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpRomFile.Controls.Add(this.buttonOpenROM, 1, 0);
			this.tlpRomFile.Controls.Add(this.tbRomFile, 0, 0);
			this.tlpRomFile.Location = new System.Drawing.Point(167, 105);
			this.tlpRomFile.Name = "tlpRomFile";
			this.tlpRomFile.RowCount = 1;
			this.tlpRomFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRomFile.Size = new System.Drawing.Size(300, 28);
			this.tlpRomFile.TabIndex = 3;
			// 
			// buttonOpenROM
			// 
			this.buttonOpenROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenROM.Location = new System.Drawing.Point(273, 3);
			this.buttonOpenROM.Name = "buttonOpenROM";
			this.buttonOpenROM.Size = new System.Drawing.Size(24, 22);
			this.buttonOpenROM.TabIndex = 4;
			this.buttonOpenROM.Text = "...";
			this.buttonOpenROM.UseVisualStyleBackColor = true;
			this.buttonOpenROM.Click += new System.EventHandler(this.buttonOpenROM_Click);
			// 
			// tbRomFile
			// 
			this.tbRomFile.AllowDrop = true;
			this.tbRomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRomFile.Location = new System.Drawing.Point(3, 4);
			this.tbRomFile.Name = "tbRomFile";
			this.tbRomFile.Size = new System.Drawing.Size(264, 20);
			this.tbRomFile.TabIndex = 3;
			this.tbRomFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbRomFile_DragDrop);
			this.tbRomFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbRomFile_DragEnter);
			// 
			// labelGameType
			// 
			this.labelGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGameType.AutoSize = true;
			this.labelGameType.Location = new System.Drawing.Point(3, 78);
			this.labelGameType.Name = "labelGameType";
			this.labelGameType.Size = new System.Drawing.Size(158, 13);
			this.labelGameType.TabIndex = 2;
			this.labelGameType.Text = "&Game Type";
			// 
			// cbGameVersion
			// 
			this.cbGameVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbGameVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameVersion.FormattingEnabled = true;
			this.cbGameVersion.Location = new System.Drawing.Point(167, 74);
			this.cbGameVersion.Name = "cbGameVersion";
			this.cbGameVersion.Size = new System.Drawing.Size(300, 21);
			this.cbGameVersion.TabIndex = 2;
			// 
			// labelAuthors
			// 
			this.labelAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAuthors.AutoSize = true;
			this.labelAuthors.Location = new System.Drawing.Point(3, 44);
			this.labelAuthors.Name = "labelAuthors";
			this.labelAuthors.Size = new System.Drawing.Size(158, 13);
			this.labelAuthors.TabIndex = 1;
			this.labelAuthors.Text = "&Author(s) (optional)";
			// 
			// tbAuthors
			// 
			this.tbAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAuthors.Location = new System.Drawing.Point(167, 41);
			this.tbAuthors.Name = "tbAuthors";
			this.tbAuthors.Size = new System.Drawing.Size(300, 20);
			this.tbAuthors.TabIndex = 1;
			// 
			// tlpOutROM
			// 
			this.tlpOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpOutROM.ColumnCount = 2;
			this.tlpOutROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpOutROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpOutROM.Controls.Add(this.buttonSetOutROM, 1, 0);
			this.tlpOutROM.Controls.Add(this.tbOutROMPath, 0, 0);
			this.tlpOutROM.Location = new System.Drawing.Point(167, 139);
			this.tlpOutROM.Name = "tlpOutROM";
			this.tlpOutROM.RowCount = 1;
			this.tlpOutROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOutROM.Size = new System.Drawing.Size(300, 28);
			this.tlpOutROM.TabIndex = 7;
			// 
			// buttonSetOutROM
			// 
			this.buttonSetOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetOutROM.Location = new System.Drawing.Point(273, 3);
			this.buttonSetOutROM.Name = "buttonSetOutROM";
			this.buttonSetOutROM.Size = new System.Drawing.Size(24, 22);
			this.buttonSetOutROM.TabIndex = 1;
			this.buttonSetOutROM.Text = "...";
			this.buttonSetOutROM.UseVisualStyleBackColor = true;
			this.buttonSetOutROM.Click += new System.EventHandler(this.buttonSetOutROM_Click);
			// 
			// tbOutROMPath
			// 
			this.tbOutROMPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutROMPath.Location = new System.Drawing.Point(3, 4);
			this.tbOutROMPath.Name = "tbOutROMPath";
			this.tbOutROMPath.Size = new System.Drawing.Size(264, 20);
			this.tbOutROMPath.TabIndex = 2;
			this.tbOutROMPath.Text = "built.z64";
			// 
			// chbCustomLocation
			// 
			this.chbCustomLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbCustomLocation.AutoSize = true;
			this.chbCustomLocation.Location = new System.Drawing.Point(3, 178);
			this.chbCustomLocation.Name = "chbCustomLocation";
			this.chbCustomLocation.Size = new System.Drawing.Size(158, 17);
			this.chbCustomLocation.TabIndex = 8;
			this.chbCustomLocation.Text = "Custom &Location File";
			this.chbCustomLocation.UseVisualStyleBackColor = true;
			this.chbCustomLocation.Click += new System.EventHandler(this.chbCustomLocation_Click);
			// 
			// chbCustomFileTableDB
			// 
			this.chbCustomFileTableDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbCustomFileTableDB.AutoSize = true;
			this.chbCustomFileTableDB.Location = new System.Drawing.Point(3, 213);
			this.chbCustomFileTableDB.Name = "chbCustomFileTableDB";
			this.chbCustomFileTableDB.Size = new System.Drawing.Size(158, 17);
			this.chbCustomFileTableDB.TabIndex = 10;
			this.chbCustomFileTableDB.Text = "Custom &FileTableDB File";
			this.chbCustomFileTableDB.UseVisualStyleBackColor = true;
			this.chbCustomFileTableDB.Click += new System.EventHandler(this.chbCustomFileTableDB_Click);
			// 
			// tlpCustomFileTableDB
			// 
			this.tlpCustomFileTableDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpCustomFileTableDB.ColumnCount = 2;
			this.tlpCustomFileTableDB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpCustomFileTableDB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpCustomFileTableDB.Controls.Add(this.tbCustomFileTableDBFile, 0, 0);
			this.tlpCustomFileTableDB.Controls.Add(this.buttonSetCustomFileTableDBFile, 1, 0);
			this.tlpCustomFileTableDB.Location = new System.Drawing.Point(167, 207);
			this.tlpCustomFileTableDB.Name = "tlpCustomFileTableDB";
			this.tlpCustomFileTableDB.RowCount = 1;
			this.tlpCustomFileTableDB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCustomFileTableDB.Size = new System.Drawing.Size(300, 30);
			this.tlpCustomFileTableDB.TabIndex = 11;
			// 
			// buttonSetCustomFileTableDBFile
			// 
			this.buttonSetCustomFileTableDBFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetCustomFileTableDBFile.Enabled = false;
			this.buttonSetCustomFileTableDBFile.Location = new System.Drawing.Point(273, 4);
			this.buttonSetCustomFileTableDBFile.Name = "buttonSetCustomFileTableDBFile";
			this.buttonSetCustomFileTableDBFile.Size = new System.Drawing.Size(24, 22);
			this.buttonSetCustomFileTableDBFile.TabIndex = 2;
			this.buttonSetCustomFileTableDBFile.Text = "...";
			this.buttonSetCustomFileTableDBFile.UseVisualStyleBackColor = true;
			this.buttonSetCustomFileTableDBFile.Click += new System.EventHandler(this.buttonSetCustomFileTableDBFile_Click);
			// 
			// tbCustomFileTableDBFile
			// 
			this.tbCustomFileTableDBFile.AllowDrop = true;
			this.tbCustomFileTableDBFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCustomFileTableDBFile.Enabled = false;
			this.tbCustomFileTableDBFile.Location = new System.Drawing.Point(3, 5);
			this.tbCustomFileTableDBFile.Name = "tbCustomFileTableDBFile";
			this.tbCustomFileTableDBFile.Size = new System.Drawing.Size(264, 20);
			this.tbCustomFileTableDBFile.TabIndex = 3;
			this.tbCustomFileTableDBFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCustomFileTableDBFile_DragDrop);
			this.tbCustomFileTableDBFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCustomFileTableDBFile_DragEnter);
			// 
			// NewProjectDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(494, 293);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 300);
			this.Name = "NewProjectDialog";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Project";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tlpCustomLoc.ResumeLayout(false);
			this.tlpCustomLoc.PerformLayout();
			this.tlpRomFile.ResumeLayout(false);
			this.tlpRomFile.PerformLayout();
			this.tlpOutROM.ResumeLayout(false);
			this.tlpOutROM.PerformLayout();
			this.tlpCustomFileTableDB.ResumeLayout(false);
			this.tlpCustomFileTableDB.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ComboBox cbGameVersion;
		private System.Windows.Forms.Label labelGameType;
		private System.Windows.Forms.Label labelProjectName;
		private System.Windows.Forms.TextBox tbProjectName;
		private System.Windows.Forms.Label labelRomFile;
		private System.Windows.Forms.TableLayoutPanel tlpRomFile;
		private System.Windows.Forms.Button buttonOpenROM;
		private System.Windows.Forms.TextBox tbRomFile;
		private System.Windows.Forms.Label labelAuthors;
		private System.Windows.Forms.TextBox tbAuthors;
		private System.Windows.Forms.Label labelOutROM;
		private System.Windows.Forms.TableLayoutPanel tlpOutROM;
		private System.Windows.Forms.Button buttonSetOutROM;
		private System.Windows.Forms.TextBox tbOutROMPath;
		private System.Windows.Forms.TableLayoutPanel tlpCustomLoc;
		private System.Windows.Forms.Button buttonSetCustomLocFile;
		private System.Windows.Forms.TextBox tbCustomLocationFile;
		private System.Windows.Forms.CheckBox chbCustomLocation;
		private System.Windows.Forms.CheckBox chbCustomFileTableDB;
		private System.Windows.Forms.TableLayoutPanel tlpCustomFileTableDB;
		private System.Windows.Forms.TextBox tbCustomFileTableDBFile;
		private System.Windows.Forms.Button buttonSetCustomFileTableDBFile;
	}
}