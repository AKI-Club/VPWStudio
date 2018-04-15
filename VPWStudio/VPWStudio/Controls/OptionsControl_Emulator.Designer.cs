namespace VPWStudio.Controls
{
	partial class OptionsControl_Emulator
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tlpEmuArguments = new System.Windows.Forms.TableLayoutPanel();
			this.tbEmulatorArguments = new System.Windows.Forms.TextBox();
			this.labelEmuArguments = new System.Windows.Forms.Label();
			this.tlpEmuPath = new System.Windows.Forms.TableLayoutPanel();
			this.labelEmuPath = new System.Windows.Forms.Label();
			this.tbEmuPath = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.tlpEmuArguments.SuspendLayout();
			this.tlpEmuPath.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpEmuArguments
			// 
			this.tlpEmuArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEmuArguments.ColumnCount = 2;
			this.tlpEmuArguments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.79208F));
			this.tlpEmuArguments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.20792F));
			this.tlpEmuArguments.Controls.Add(this.tbEmulatorArguments, 1, 0);
			this.tlpEmuArguments.Controls.Add(this.labelEmuArguments, 0, 0);
			this.tlpEmuArguments.Location = new System.Drawing.Point(3, 43);
			this.tlpEmuArguments.Name = "tlpEmuArguments";
			this.tlpEmuArguments.RowCount = 1;
			this.tlpEmuArguments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEmuArguments.Size = new System.Drawing.Size(314, 34);
			this.tlpEmuArguments.TabIndex = 5;
			// 
			// tbEmulatorArguments
			// 
			this.tbEmulatorArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEmulatorArguments.Location = new System.Drawing.Point(68, 7);
			this.tbEmulatorArguments.Name = "tbEmulatorArguments";
			this.tbEmulatorArguments.Size = new System.Drawing.Size(243, 20);
			this.tbEmulatorArguments.TabIndex = 0;
			// 
			// labelEmuArguments
			// 
			this.labelEmuArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEmuArguments.AutoSize = true;
			this.labelEmuArguments.Location = new System.Drawing.Point(3, 10);
			this.labelEmuArguments.Name = "labelEmuArguments";
			this.labelEmuArguments.Size = new System.Drawing.Size(59, 13);
			this.labelEmuArguments.TabIndex = 1;
			this.labelEmuArguments.Text = "&Arguments";
			// 
			// tlpEmuPath
			// 
			this.tlpEmuPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEmuPath.ColumnCount = 3;
			this.tlpEmuPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.02469F));
			this.tlpEmuPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.97531F));
			this.tlpEmuPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			this.tlpEmuPath.Controls.Add(this.labelEmuPath, 0, 0);
			this.tlpEmuPath.Controls.Add(this.tbEmuPath, 1, 0);
			this.tlpEmuPath.Controls.Add(this.buttonBrowse, 2, 0);
			this.tlpEmuPath.Location = new System.Drawing.Point(3, 3);
			this.tlpEmuPath.MinimumSize = new System.Drawing.Size(314, 34);
			this.tlpEmuPath.Name = "tlpEmuPath";
			this.tlpEmuPath.RowCount = 1;
			this.tlpEmuPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEmuPath.Size = new System.Drawing.Size(314, 34);
			this.tlpEmuPath.TabIndex = 4;
			// 
			// labelEmuPath
			// 
			this.labelEmuPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEmuPath.AutoSize = true;
			this.labelEmuPath.Location = new System.Drawing.Point(3, 10);
			this.labelEmuPath.Name = "labelEmuPath";
			this.labelEmuPath.Size = new System.Drawing.Size(35, 13);
			this.labelEmuPath.TabIndex = 0;
			this.labelEmuPath.Text = "&Path";
			// 
			// tbEmuPath
			// 
			this.tbEmuPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEmuPath.Location = new System.Drawing.Point(44, 7);
			this.tbEmuPath.Name = "tbEmuPath";
			this.tbEmuPath.Size = new System.Drawing.Size(184, 20);
			this.tbEmuPath.TabIndex = 0;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(234, 5);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(77, 23);
			this.buttonBrowse.TabIndex = 1;
			this.buttonBrowse.Text = "&Browse...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// OptionsControl_Emulator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tlpEmuArguments);
			this.Controls.Add(this.tlpEmuPath);
			this.Name = "OptionsControl_Emulator";
			this.Size = new System.Drawing.Size(320, 80);
			this.tlpEmuArguments.ResumeLayout(false);
			this.tlpEmuArguments.PerformLayout();
			this.tlpEmuPath.ResumeLayout(false);
			this.tlpEmuPath.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpEmuArguments;
		private System.Windows.Forms.Label labelEmuArguments;
		private System.Windows.Forms.TableLayoutPanel tlpEmuPath;
		private System.Windows.Forms.Label labelEmuPath;
		private System.Windows.Forms.Button buttonBrowse;
		public System.Windows.Forms.TextBox tbEmulatorArguments;
		public System.Windows.Forms.TextBox tbEmuPath;
	}
}
