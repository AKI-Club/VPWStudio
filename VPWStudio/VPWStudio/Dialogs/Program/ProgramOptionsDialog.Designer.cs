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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Emulator");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Build");
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tlpBuildLogVerbosity = new System.Windows.Forms.TableLayoutPanel();
			this.labelBuildLogVerbosity = new System.Windows.Forms.Label();
			this.cbBuildLogVerbosity = new System.Windows.Forms.ComboBox();
			this.tvOptions = new System.Windows.Forms.TreeView();
			this.optionControlEmu = new VPWStudio.Controls.OptionsControl_Emulator();
			this.tlpBuildLogVerbosity.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(338, 180);
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
			this.buttonCancel.Location = new System.Drawing.Point(419, 180);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tlpBuildLogVerbosity
			// 
			this.tlpBuildLogVerbosity.ColumnCount = 2;
			this.tlpBuildLogVerbosity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.57747F));
			this.tlpBuildLogVerbosity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.42254F));
			this.tlpBuildLogVerbosity.Controls.Add(this.labelBuildLogVerbosity, 0, 0);
			this.tlpBuildLogVerbosity.Controls.Add(this.cbBuildLogVerbosity, 1, 0);
			this.tlpBuildLogVerbosity.Location = new System.Drawing.Point(139, 12);
			this.tlpBuildLogVerbosity.Name = "tlpBuildLogVerbosity";
			this.tlpBuildLogVerbosity.RowCount = 1;
			this.tlpBuildLogVerbosity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBuildLogVerbosity.Size = new System.Drawing.Size(355, 26);
			this.tlpBuildLogVerbosity.TabIndex = 5;
			// 
			// labelBuildLogVerbosity
			// 
			this.labelBuildLogVerbosity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBuildLogVerbosity.AutoSize = true;
			this.labelBuildLogVerbosity.Location = new System.Drawing.Point(3, 6);
			this.labelBuildLogVerbosity.Name = "labelBuildLogVerbosity";
			this.labelBuildLogVerbosity.Size = new System.Drawing.Size(99, 13);
			this.labelBuildLogVerbosity.TabIndex = 0;
			this.labelBuildLogVerbosity.Text = "Build Log &Verbosity";
			// 
			// cbBuildLogVerbosity
			// 
			this.cbBuildLogVerbosity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbBuildLogVerbosity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBuildLogVerbosity.FormattingEnabled = true;
			this.cbBuildLogVerbosity.Location = new System.Drawing.Point(108, 3);
			this.cbBuildLogVerbosity.Name = "cbBuildLogVerbosity";
			this.cbBuildLogVerbosity.Size = new System.Drawing.Size(244, 21);
			this.cbBuildLogVerbosity.TabIndex = 1;
			// 
			// tvOptions
			// 
			this.tvOptions.FullRowSelect = true;
			this.tvOptions.HideSelection = false;
			this.tvOptions.Location = new System.Drawing.Point(12, 12);
			this.tvOptions.Name = "tvOptions";
			treeNode1.Name = "Emulator";
			treeNode1.Text = "Emulator";
			treeNode2.Name = "Build";
			treeNode2.Text = "Build";
			this.tvOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			this.tvOptions.Size = new System.Drawing.Size(121, 191);
			this.tvOptions.TabIndex = 6;
			this.tvOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOptions_AfterSelect);
			// 
			// optionControlEmu
			// 
			this.optionControlEmu.Location = new System.Drawing.Point(139, 12);
			this.optionControlEmu.Name = "optionControlEmu";
			this.optionControlEmu.Size = new System.Drawing.Size(355, 80);
			this.optionControlEmu.TabIndex = 7;
			// 
			// ProgramOptionsDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(506, 215);
			this.Controls.Add(this.optionControlEmu);
			this.Controls.Add(this.tvOptions);
			this.Controls.Add(this.tlpBuildLogVerbosity);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgramOptionsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Program Options";
			this.tlpBuildLogVerbosity.ResumeLayout(false);
			this.tlpBuildLogVerbosity.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tlpBuildLogVerbosity;
		private System.Windows.Forms.Label labelBuildLogVerbosity;
		private System.Windows.Forms.ComboBox cbBuildLogVerbosity;
		private System.Windows.Forms.TreeView tvOptions;
		private Controls.OptionsControl_Emulator optionControlEmu;
	}
}