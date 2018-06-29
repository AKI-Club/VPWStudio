namespace VPWStudio.Editors
{
	partial class AkiTextEditor
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
			this.gbCurrentText = new System.Windows.Forms.GroupBox();
			this.tbCurText = new System.Windows.Forms.TextBox();
			this.gbNewText = new System.Windows.Forms.GroupBox();
			this.tbNewText = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.cbTextEntries = new System.Windows.Forms.ComboBox();
			this.labelTextEntry = new System.Windows.Forms.Label();
			this.buttonImportCSV = new System.Windows.Forms.Button();
			this.buttonExportCSV = new System.Windows.Forms.Button();
			this.buttonControlCodes = new System.Windows.Forms.Button();
			this.gbCurrentText.SuspendLayout();
			this.gbNewText.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCurrentText
			// 
			this.gbCurrentText.Controls.Add(this.tbCurText);
			this.gbCurrentText.Location = new System.Drawing.Point(12, 39);
			this.gbCurrentText.Name = "gbCurrentText";
			this.gbCurrentText.Size = new System.Drawing.Size(480, 144);
			this.gbCurrentText.TabIndex = 1;
			this.gbCurrentText.TabStop = false;
			this.gbCurrentText.Text = "O&riginal Text";
			// 
			// tbCurText
			// 
			this.tbCurText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCurText.Location = new System.Drawing.Point(3, 16);
			this.tbCurText.Multiline = true;
			this.tbCurText.Name = "tbCurText";
			this.tbCurText.ReadOnly = true;
			this.tbCurText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCurText.Size = new System.Drawing.Size(474, 125);
			this.tbCurText.TabIndex = 1;
			// 
			// gbNewText
			// 
			this.gbNewText.Controls.Add(this.tbNewText);
			this.gbNewText.Location = new System.Drawing.Point(12, 189);
			this.gbNewText.Name = "gbNewText";
			this.gbNewText.Size = new System.Drawing.Size(480, 144);
			this.gbNewText.TabIndex = 2;
			this.gbNewText.TabStop = false;
			this.gbNewText.Text = "&New Text";
			// 
			// tbNewText
			// 
			this.tbNewText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbNewText.Location = new System.Drawing.Point(3, 16);
			this.tbNewText.Multiline = true;
			this.tbNewText.Name = "tbNewText";
			this.tbNewText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbNewText.Size = new System.Drawing.Size(474, 125);
			this.tbNewText.TabIndex = 2;
			this.tbNewText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNewText_KeyUp);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(336, 339);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(417, 339);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// cbTextEntries
			// 
			this.cbTextEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTextEntries.Location = new System.Drawing.Point(73, 12);
			this.cbTextEntries.Name = "cbTextEntries";
			this.cbTextEntries.Size = new System.Drawing.Size(419, 21);
			this.cbTextEntries.TabIndex = 0;
			this.cbTextEntries.SelectedIndexChanged += new System.EventHandler(this.cbTextEntries_SelectedIndexChanged);
			// 
			// labelTextEntry
			// 
			this.labelTextEntry.AutoSize = true;
			this.labelTextEntry.Location = new System.Drawing.Point(12, 15);
			this.labelTextEntry.Name = "labelTextEntry";
			this.labelTextEntry.Size = new System.Drawing.Size(55, 13);
			this.labelTextEntry.TabIndex = 0;
			this.labelTextEntry.Text = "&Text Entry";
			// 
			// buttonImportCSV
			// 
			this.buttonImportCSV.Location = new System.Drawing.Point(12, 339);
			this.buttonImportCSV.Name = "buttonImportCSV";
			this.buttonImportCSV.Size = new System.Drawing.Size(88, 23);
			this.buttonImportCSV.TabIndex = 3;
			this.buttonImportCSV.Text = "&Import CSV...";
			this.buttonImportCSV.UseVisualStyleBackColor = true;
			this.buttonImportCSV.Click += new System.EventHandler(this.buttonImportCSV_Click);
			// 
			// buttonExportCSV
			// 
			this.buttonExportCSV.Location = new System.Drawing.Point(106, 339);
			this.buttonExportCSV.Name = "buttonExportCSV";
			this.buttonExportCSV.Size = new System.Drawing.Size(88, 23);
			this.buttonExportCSV.TabIndex = 4;
			this.buttonExportCSV.Text = "&Export CSV...";
			this.buttonExportCSV.UseVisualStyleBackColor = true;
			this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
			// 
			// buttonControlCodes
			// 
			this.buttonControlCodes.Location = new System.Drawing.Point(200, 339);
			this.buttonControlCodes.Name = "buttonControlCodes";
			this.buttonControlCodes.Size = new System.Drawing.Size(130, 23);
			this.buttonControlCodes.TabIndex = 5;
			this.buttonControlCodes.Text = "Control Co&des";
			this.buttonControlCodes.UseVisualStyleBackColor = true;
			this.buttonControlCodes.Click += new System.EventHandler(this.buttonControlCodes_Click);
			// 
			// AkiTextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 374);
			this.Controls.Add(this.buttonControlCodes);
			this.Controls.Add(this.buttonExportCSV);
			this.Controls.Add(this.buttonImportCSV);
			this.Controls.Add(this.labelTextEntry);
			this.Controls.Add(this.cbTextEntries);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbNewText);
			this.Controls.Add(this.gbCurrentText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AkiTextEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AKI Text Editor";
			this.gbCurrentText.ResumeLayout(false);
			this.gbCurrentText.PerformLayout();
			this.gbNewText.ResumeLayout(false);
			this.gbNewText.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCurrentText;
		private System.Windows.Forms.GroupBox gbNewText;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox tbCurText;
		private System.Windows.Forms.TextBox tbNewText;
		private System.Windows.Forms.ComboBox cbTextEntries;
		private System.Windows.Forms.Label labelTextEntry;
		private System.Windows.Forms.Button buttonImportCSV;
		private System.Windows.Forms.Button buttonExportCSV;
		private System.Windows.Forms.Button buttonControlCodes;
	}
}