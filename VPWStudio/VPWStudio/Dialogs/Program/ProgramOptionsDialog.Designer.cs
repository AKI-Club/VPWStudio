namespace VPWStudio
{
	partial class ProgramOptionsDialog
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
			this.tlpEmuPath = new System.Windows.Forms.TableLayoutPanel();
			this.labelEmuPath = new System.Windows.Forms.Label();
			this.tbEmuPath = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.gbEmuSettings = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tbEmulatorArguments = new System.Windows.Forms.TextBox();
			this.labelEmuArguments = new System.Windows.Forms.Label();
			this.tlpBuildLogVerbosity = new System.Windows.Forms.TableLayoutPanel();
			this.labelBuildLogVerbosity = new System.Windows.Forms.Label();
			this.cbBuildLogVerbosity = new System.Windows.Forms.ComboBox();
			this.tlpEmuPath.SuspendLayout();
			this.gbEmuSettings.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tlpBuildLogVerbosity.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(354, 152);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(435, 152);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tlpEmuPath
			// 
			this.tlpEmuPath.ColumnCount = 3;
			this.tlpEmuPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.02469F));
			this.tlpEmuPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.97531F));
			this.tlpEmuPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
			this.tlpEmuPath.Controls.Add(this.labelEmuPath, 0, 0);
			this.tlpEmuPath.Controls.Add(this.tbEmuPath, 1, 0);
			this.tlpEmuPath.Controls.Add(this.buttonBrowse, 2, 0);
			this.tlpEmuPath.Location = new System.Drawing.Point(6, 19);
			this.tlpEmuPath.Name = "tlpEmuPath";
			this.tlpEmuPath.RowCount = 1;
			this.tlpEmuPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEmuPath.Size = new System.Drawing.Size(486, 35);
			this.tlpEmuPath.TabIndex = 2;
			// 
			// labelEmuPath
			// 
			this.labelEmuPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEmuPath.AutoSize = true;
			this.labelEmuPath.Location = new System.Drawing.Point(3, 11);
			this.labelEmuPath.Name = "labelEmuPath";
			this.labelEmuPath.Size = new System.Drawing.Size(66, 13);
			this.labelEmuPath.TabIndex = 0;
			this.labelEmuPath.Text = "&Path";
			// 
			// tbEmuPath
			// 
			this.tbEmuPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEmuPath.Location = new System.Drawing.Point(75, 7);
			this.tbEmuPath.Name = "tbEmuPath";
			this.tbEmuPath.Size = new System.Drawing.Size(326, 20);
			this.tbEmuPath.TabIndex = 0;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(407, 6);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(76, 23);
			this.buttonBrowse.TabIndex = 1;
			this.buttonBrowse.Text = "&Browse...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// gbEmuSettings
			// 
			this.gbEmuSettings.Controls.Add(this.tableLayoutPanel2);
			this.gbEmuSettings.Controls.Add(this.tlpEmuPath);
			this.gbEmuSettings.Location = new System.Drawing.Point(12, 12);
			this.gbEmuSettings.Name = "gbEmuSettings";
			this.gbEmuSettings.Size = new System.Drawing.Size(498, 102);
			this.gbEmuSettings.TabIndex = 4;
			this.gbEmuSettings.TabStop = false;
			this.gbEmuSettings.Text = "Emulator Settings";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.tableLayoutPanel2.Controls.Add(this.tbEmulatorArguments, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.labelEmuArguments, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 60);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(486, 34);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// tbEmulatorArguments
			// 
			this.tbEmulatorArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEmulatorArguments.Location = new System.Drawing.Point(75, 7);
			this.tbEmulatorArguments.Name = "tbEmulatorArguments";
			this.tbEmulatorArguments.Size = new System.Drawing.Size(408, 20);
			this.tbEmulatorArguments.TabIndex = 0;
			// 
			// labelEmuArguments
			// 
			this.labelEmuArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEmuArguments.AutoSize = true;
			this.labelEmuArguments.Location = new System.Drawing.Point(3, 10);
			this.labelEmuArguments.Name = "labelEmuArguments";
			this.labelEmuArguments.Size = new System.Drawing.Size(66, 13);
			this.labelEmuArguments.TabIndex = 1;
			this.labelEmuArguments.Text = "&Arguments";
			// 
			// tlpBuildLogVerbosity
			// 
			this.tlpBuildLogVerbosity.ColumnCount = 2;
			this.tlpBuildLogVerbosity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpBuildLogVerbosity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpBuildLogVerbosity.Controls.Add(this.labelBuildLogVerbosity, 0, 0);
			this.tlpBuildLogVerbosity.Controls.Add(this.cbBuildLogVerbosity, 1, 0);
			this.tlpBuildLogVerbosity.Location = new System.Drawing.Point(12, 120);
			this.tlpBuildLogVerbosity.Name = "tlpBuildLogVerbosity";
			this.tlpBuildLogVerbosity.RowCount = 1;
			this.tlpBuildLogVerbosity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBuildLogVerbosity.Size = new System.Drawing.Size(498, 26);
			this.tlpBuildLogVerbosity.TabIndex = 5;
			// 
			// labelBuildLogVerbosity
			// 
			this.labelBuildLogVerbosity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBuildLogVerbosity.AutoSize = true;
			this.labelBuildLogVerbosity.Location = new System.Drawing.Point(3, 6);
			this.labelBuildLogVerbosity.Name = "labelBuildLogVerbosity";
			this.labelBuildLogVerbosity.Size = new System.Drawing.Size(118, 13);
			this.labelBuildLogVerbosity.TabIndex = 0;
			this.labelBuildLogVerbosity.Text = "Build Log &Verbosity";
			// 
			// cbBuildLogVerbosity
			// 
			this.cbBuildLogVerbosity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBuildLogVerbosity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBuildLogVerbosity.FormattingEnabled = true;
			this.cbBuildLogVerbosity.Location = new System.Drawing.Point(127, 3);
			this.cbBuildLogVerbosity.Name = "cbBuildLogVerbosity";
			this.cbBuildLogVerbosity.Size = new System.Drawing.Size(368, 21);
			this.cbBuildLogVerbosity.TabIndex = 1;
			// 
			// ProgramOptionsDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(522, 187);
			this.Controls.Add(this.tlpBuildLogVerbosity);
			this.Controls.Add(this.gbEmuSettings);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgramOptionsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Program Options";
			this.tlpEmuPath.ResumeLayout(false);
			this.tlpEmuPath.PerformLayout();
			this.gbEmuSettings.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tlpBuildLogVerbosity.ResumeLayout(false);
			this.tlpBuildLogVerbosity.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tlpEmuPath;
		private System.Windows.Forms.Label labelEmuPath;
		private System.Windows.Forms.TextBox tbEmuPath;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.GroupBox gbEmuSettings;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox tbEmulatorArguments;
		private System.Windows.Forms.Label labelEmuArguments;
		private System.Windows.Forms.TableLayoutPanel tlpBuildLogVerbosity;
		private System.Windows.Forms.Label labelBuildLogVerbosity;
		private System.Windows.Forms.ComboBox cbBuildLogVerbosity;
	}
}