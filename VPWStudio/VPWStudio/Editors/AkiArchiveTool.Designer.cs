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
			this.gbArchiveFiles = new System.Windows.Forms.GroupBox();
			this.lbFiles = new System.Windows.Forms.ListBox();
			this.buttonExtract = new System.Windows.Forms.Button();
			this.buttonReplace = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.gbSelItem = new System.Windows.Forms.GroupBox();
			this.tbSelItemInfo = new System.Windows.Forms.TextBox();
			this.buttonViewHexEditor = new System.Windows.Forms.Button();
			this.gbArchiveFiles.SuspendLayout();
			this.gbSelItem.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbArchiveFiles
			// 
			this.gbArchiveFiles.Controls.Add(this.buttonReplace);
			this.gbArchiveFiles.Controls.Add(this.buttonExtract);
			this.gbArchiveFiles.Controls.Add(this.lbFiles);
			this.gbArchiveFiles.Location = new System.Drawing.Point(12, 12);
			this.gbArchiveFiles.Name = "gbArchiveFiles";
			this.gbArchiveFiles.Size = new System.Drawing.Size(200, 429);
			this.gbArchiveFiles.TabIndex = 0;
			this.gbArchiveFiles.TabStop = false;
			this.gbArchiveFiles.Text = "&Files";
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
			// buttonExtract
			// 
			this.buttonExtract.Location = new System.Drawing.Point(6, 400);
			this.buttonExtract.Name = "buttonExtract";
			this.buttonExtract.Size = new System.Drawing.Size(90, 23);
			this.buttonExtract.TabIndex = 2;
			this.buttonExtract.Text = "&Export File...";
			this.buttonExtract.UseVisualStyleBackColor = true;
			this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
			// 
			// buttonReplace
			// 
			this.buttonReplace.Location = new System.Drawing.Point(104, 400);
			this.buttonReplace.Name = "buttonReplace";
			this.buttonReplace.Size = new System.Drawing.Size(90, 23);
			this.buttonReplace.TabIndex = 3;
			this.buttonReplace.Text = "&Replace File...";
			this.buttonReplace.UseVisualStyleBackColor = true;
			this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(464, 418);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(545, 418);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// gbSelItem
			// 
			this.gbSelItem.Controls.Add(this.buttonViewHexEditor);
			this.gbSelItem.Controls.Add(this.tbSelItemInfo);
			this.gbSelItem.Location = new System.Drawing.Point(218, 12);
			this.gbSelItem.Name = "gbSelItem";
			this.gbSelItem.Size = new System.Drawing.Size(402, 400);
			this.gbSelItem.TabIndex = 4;
			this.gbSelItem.TabStop = false;
			this.gbSelItem.Text = "Selected &Item";
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
			this.tbSelItemInfo.TabIndex = 0;
			// 
			// buttonViewHexEditor
			// 
			this.buttonViewHexEditor.Location = new System.Drawing.Point(297, 371);
			this.buttonViewHexEditor.Name = "buttonViewHexEditor";
			this.buttonViewHexEditor.Size = new System.Drawing.Size(99, 23);
			this.buttonViewHexEditor.TabIndex = 1;
			this.buttonViewHexEditor.Text = "&Hex Viewer...";
			this.buttonViewHexEditor.UseVisualStyleBackColor = true;
			this.buttonViewHexEditor.Click += new System.EventHandler(this.buttonViewHexEditor_Click);
			// 
			// AkiArchiveTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.gbSelItem);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbArchiveFiles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AkiArchiveTool";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AKI Archive Tool";
			this.gbArchiveFiles.ResumeLayout(false);
			this.gbSelItem.ResumeLayout(false);
			this.gbSelItem.PerformLayout();
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
	}
}