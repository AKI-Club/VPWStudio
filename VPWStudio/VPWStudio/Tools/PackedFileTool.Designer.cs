namespace VPWStudio
{
	partial class PackedFileTool
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
			this.tbCurFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.buttonResave = new System.Windows.Forms.Button();
			this.lbFileEntries = new System.Windows.Forms.ListBox();
			this.tbSelectedFileInfo = new System.Windows.Forms.TextBox();
			this.buttonExtractFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbCurFile
			// 
			this.tbCurFile.Location = new System.Drawing.Point(78, 14);
			this.tbCurFile.Name = "tbCurFile";
			this.tbCurFile.ReadOnly = true;
			this.tbCurFile.Size = new System.Drawing.Size(333, 20);
			this.tbCurFile.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Current File";
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(417, 12);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 5;
			this.buttonOpen.Text = "&Open...";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// buttonResave
			// 
			this.buttonResave.Location = new System.Drawing.Point(350, 322);
			this.buttonResave.Name = "buttonResave";
			this.buttonResave.Size = new System.Drawing.Size(142, 23);
			this.buttonResave.TabIndex = 9;
			this.buttonResave.Text = "Bad Idea Jeans (Repack)";
			this.buttonResave.UseVisualStyleBackColor = true;
			this.buttonResave.Click += new System.EventHandler(this.buttonResave_Click);
			// 
			// lbFileEntries
			// 
			this.lbFileEntries.FormattingEnabled = true;
			this.lbFileEntries.Location = new System.Drawing.Point(12, 41);
			this.lbFileEntries.Name = "lbFileEntries";
			this.lbFileEntries.Size = new System.Drawing.Size(166, 264);
			this.lbFileEntries.TabIndex = 10;
			this.lbFileEntries.SelectedIndexChanged += new System.EventHandler(this.lbFileEntries_SelectedIndexChanged);
			// 
			// tbSelectedFileInfo
			// 
			this.tbSelectedFileInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSelectedFileInfo.Location = new System.Drawing.Point(184, 41);
			this.tbSelectedFileInfo.Multiline = true;
			this.tbSelectedFileInfo.Name = "tbSelectedFileInfo";
			this.tbSelectedFileInfo.ReadOnly = true;
			this.tbSelectedFileInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSelectedFileInfo.Size = new System.Drawing.Size(308, 264);
			this.tbSelectedFileInfo.TabIndex = 11;
			// 
			// buttonExtractFile
			// 
			this.buttonExtractFile.Location = new System.Drawing.Point(12, 322);
			this.buttonExtractFile.Name = "buttonExtractFile";
			this.buttonExtractFile.Size = new System.Drawing.Size(166, 23);
			this.buttonExtractFile.TabIndex = 12;
			this.buttonExtractFile.Text = "&Extract File...";
			this.buttonExtractFile.UseVisualStyleBackColor = true;
			this.buttonExtractFile.Click += new System.EventHandler(this.buttonExtractFile_Click);
			// 
			// PackedFileTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 357);
			this.Controls.Add(this.buttonExtractFile);
			this.Controls.Add(this.tbSelectedFileInfo);
			this.Controls.Add(this.lbFileEntries);
			this.Controls.Add(this.buttonResave);
			this.Controls.Add(this.tbCurFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOpen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "PackedFileTool";
			this.Text = "Packed File Tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbCurFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Button buttonResave;
		private System.Windows.Forms.ListBox lbFileEntries;
		private System.Windows.Forms.TextBox tbSelectedFileInfo;
		private System.Windows.Forms.Button buttonExtractFile;
	}
}