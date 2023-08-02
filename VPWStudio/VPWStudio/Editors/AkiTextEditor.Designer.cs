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
			this.buttonControlCodes = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importTabCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importAkiTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportTabCSVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAkiTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbCurrentText.SuspendLayout();
			this.gbNewText.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCurrentText
			// 
			this.gbCurrentText.Controls.Add(this.tbCurText);
			this.gbCurrentText.Location = new System.Drawing.Point(12, 62);
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
			this.gbNewText.Location = new System.Drawing.Point(12, 212);
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
			this.buttonOK.Location = new System.Drawing.Point(336, 362);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(417, 362);
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
			this.cbTextEntries.Location = new System.Drawing.Point(73, 35);
			this.cbTextEntries.Name = "cbTextEntries";
			this.cbTextEntries.Size = new System.Drawing.Size(419, 21);
			this.cbTextEntries.TabIndex = 0;
			this.cbTextEntries.SelectedIndexChanged += new System.EventHandler(this.cbTextEntries_SelectedIndexChanged);
			// 
			// labelTextEntry
			// 
			this.labelTextEntry.AutoSize = true;
			this.labelTextEntry.Location = new System.Drawing.Point(12, 38);
			this.labelTextEntry.Name = "labelTextEntry";
			this.labelTextEntry.Size = new System.Drawing.Size(55, 13);
			this.labelTextEntry.TabIndex = 0;
			this.labelTextEntry.Text = "&Text Entry";
			// 
			// buttonControlCodes
			// 
			this.buttonControlCodes.Location = new System.Drawing.Point(12, 362);
			this.buttonControlCodes.Name = "buttonControlCodes";
			this.buttonControlCodes.Size = new System.Drawing.Size(130, 23);
			this.buttonControlCodes.TabIndex = 5;
			this.buttonControlCodes.Text = "Control Co&des";
			this.buttonControlCodes.UseVisualStyleBackColor = true;
			this.buttonControlCodes.Click += new System.EventHandler(this.buttonControlCodes_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.goToToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(504, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTabCSVToolStripMenuItem,
            this.importAkiTextToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.importToolStripMenuItem.Text = "&Import";
			// 
			// importTabCSVToolStripMenuItem
			// 
			this.importTabCSVToolStripMenuItem.Name = "importTabCSVToolStripMenuItem";
			this.importTabCSVToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.importTabCSVToolStripMenuItem.Text = "Tab-separated CSV...";
			this.importTabCSVToolStripMenuItem.Click += new System.EventHandler(this.importTabCSVToolStripMenuItem_Click);
			// 
			// importAkiTextToolStripMenuItem
			// 
			this.importAkiTextToolStripMenuItem.Name = "importAkiTextToolStripMenuItem";
			this.importAkiTextToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.importAkiTextToolStripMenuItem.Text = "akitext Tool Format...";
			this.importAkiTextToolStripMenuItem.Click += new System.EventHandler(this.importAkiTextToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTabCSVToolStripMenuItem1,
            this.exportAkiTextToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.exportToolStripMenuItem.Text = "&Export";
			// 
			// exportTabCSVToolStripMenuItem1
			// 
			this.exportTabCSVToolStripMenuItem1.Name = "exportTabCSVToolStripMenuItem1";
			this.exportTabCSVToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
			this.exportTabCSVToolStripMenuItem1.Text = "Tab-separated CSV...";
			this.exportTabCSVToolStripMenuItem1.Click += new System.EventHandler(this.exportTabCSVToolStripMenuItem1_Click);
			// 
			// exportAkiTextToolStripMenuItem
			// 
			this.exportAkiTextToolStripMenuItem.Name = "exportAkiTextToolStripMenuItem";
			this.exportAkiTextToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.exportAkiTextToolStripMenuItem.Text = "akitext Tool Format...";
			this.exportAkiTextToolStripMenuItem.Click += new System.EventHandler(this.exportAkiTextToolStripMenuItem_Click);
			// 
			// goToToolStripMenuItem
			// 
			this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
			this.goToToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.goToToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.goToToolStripMenuItem.Text = "&Go To...";
			this.goToToolStripMenuItem.Click += new System.EventHandler(this.goToToolStripMenuItem_Click);
			// 
			// AkiTextEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 397);
			this.Controls.Add(this.buttonControlCodes);
			this.Controls.Add(this.labelTextEntry);
			this.Controls.Add(this.cbTextEntries);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbNewText);
			this.Controls.Add(this.gbCurrentText);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AkiTextEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AKI Text Editor";
			this.gbCurrentText.ResumeLayout(false);
			this.gbCurrentText.PerformLayout();
			this.gbNewText.ResumeLayout(false);
			this.gbNewText.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
		private System.Windows.Forms.Button buttonControlCodes;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importTabCSVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportTabCSVToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem importAkiTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAkiTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
	}
}