
namespace VPWStudio.Editors.VPW64
{
	partial class DefaultCostume_VPW64
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
			this.cbCostumes = new System.Windows.Forms.ComboBox();
			this.tbCostumeOutput = new System.Windows.Forms.TextBox();
			this.tcCostumeColors = new System.Windows.Forms.TabControl();
			this.tpCostume1 = new System.Windows.Forms.TabPage();
			this.tpCostume2 = new System.Windows.Forms.TabPage();
			this.tpCostume3 = new System.Windows.Forms.TabPage();
			this.tpCostume4 = new System.Windows.Forms.TabPage();
			this.cccCos1Color3 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos1Color1 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos1Color2 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos2Color3 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos2Color1 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos2Color2 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos3Color3 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos3Color1 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos3Color2 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos4Color3 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos4Color1 = new VPWStudio.Controls.CostumeColorControl();
			this.cccCos4Color2 = new VPWStudio.Controls.CostumeColorControl();
			this.tcCostumeColors.SuspendLayout();
			this.tpCostume1.SuspendLayout();
			this.tpCostume2.SuspendLayout();
			this.tpCostume3.SuspendLayout();
			this.tpCostume4.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbCostumes
			// 
			this.cbCostumes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbCostumes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCostumes.FormattingEnabled = true;
			this.cbCostumes.Location = new System.Drawing.Point(12, 12);
			this.cbCostumes.Name = "cbCostumes";
			this.cbCostumes.Size = new System.Drawing.Size(600, 21);
			this.cbCostumes.TabIndex = 0;
			this.cbCostumes.SelectedIndexChanged += new System.EventHandler(this.cbCostumes_SelectedIndexChanged);
			// 
			// tbCostumeOutput
			// 
			this.tbCostumeOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCostumeOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbCostumeOutput.Location = new System.Drawing.Point(12, 39);
			this.tbCostumeOutput.Multiline = true;
			this.tbCostumeOutput.Name = "tbCostumeOutput";
			this.tbCostumeOutput.ReadOnly = true;
			this.tbCostumeOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCostumeOutput.Size = new System.Drawing.Size(297, 310);
			this.tbCostumeOutput.TabIndex = 1;
			// 
			// tcCostumeColors
			// 
			this.tcCostumeColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcCostumeColors.Controls.Add(this.tpCostume1);
			this.tcCostumeColors.Controls.Add(this.tpCostume2);
			this.tcCostumeColors.Controls.Add(this.tpCostume3);
			this.tcCostumeColors.Controls.Add(this.tpCostume4);
			this.tcCostumeColors.Location = new System.Drawing.Point(315, 39);
			this.tcCostumeColors.Name = "tcCostumeColors";
			this.tcCostumeColors.SelectedIndex = 0;
			this.tcCostumeColors.Size = new System.Drawing.Size(297, 145);
			this.tcCostumeColors.TabIndex = 6;
			// 
			// tpCostume1
			// 
			this.tpCostume1.Controls.Add(this.cccCos1Color3);
			this.tpCostume1.Controls.Add(this.cccCos1Color1);
			this.tpCostume1.Controls.Add(this.cccCos1Color2);
			this.tpCostume1.Location = new System.Drawing.Point(4, 22);
			this.tpCostume1.Name = "tpCostume1";
			this.tpCostume1.Padding = new System.Windows.Forms.Padding(3);
			this.tpCostume1.Size = new System.Drawing.Size(289, 119);
			this.tpCostume1.TabIndex = 0;
			this.tpCostume1.Text = "Costume 1";
			this.tpCostume1.UseVisualStyleBackColor = true;
			// 
			// tpCostume2
			// 
			this.tpCostume2.Controls.Add(this.cccCos2Color3);
			this.tpCostume2.Controls.Add(this.cccCos2Color1);
			this.tpCostume2.Controls.Add(this.cccCos2Color2);
			this.tpCostume2.Location = new System.Drawing.Point(4, 22);
			this.tpCostume2.Name = "tpCostume2";
			this.tpCostume2.Padding = new System.Windows.Forms.Padding(3);
			this.tpCostume2.Size = new System.Drawing.Size(289, 119);
			this.tpCostume2.TabIndex = 1;
			this.tpCostume2.Text = "Costume 2";
			this.tpCostume2.UseVisualStyleBackColor = true;
			// 
			// tpCostume3
			// 
			this.tpCostume3.Controls.Add(this.cccCos3Color3);
			this.tpCostume3.Controls.Add(this.cccCos3Color1);
			this.tpCostume3.Controls.Add(this.cccCos3Color2);
			this.tpCostume3.Location = new System.Drawing.Point(4, 22);
			this.tpCostume3.Name = "tpCostume3";
			this.tpCostume3.Size = new System.Drawing.Size(289, 119);
			this.tpCostume3.TabIndex = 2;
			this.tpCostume3.Text = "Costume 3";
			this.tpCostume3.UseVisualStyleBackColor = true;
			// 
			// tpCostume4
			// 
			this.tpCostume4.Controls.Add(this.cccCos4Color3);
			this.tpCostume4.Controls.Add(this.cccCos4Color1);
			this.tpCostume4.Controls.Add(this.cccCos4Color2);
			this.tpCostume4.Location = new System.Drawing.Point(4, 22);
			this.tpCostume4.Name = "tpCostume4";
			this.tpCostume4.Size = new System.Drawing.Size(289, 119);
			this.tpCostume4.TabIndex = 3;
			this.tpCostume4.Text = "Costume 4";
			this.tpCostume4.UseVisualStyleBackColor = true;
			// 
			// cccCos1Color3
			// 
			this.cccCos1Color3.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos1Color3.Location = new System.Drawing.Point(6, 80);
			this.cccCos1Color3.Name = "cccCos1Color3";
			this.cccCos1Color3.ReadOnly = true;
			this.cccCos1Color3.Size = new System.Drawing.Size(277, 29);
			this.cccCos1Color3.TabIndex = 4;
			// 
			// cccCos1Color1
			// 
			this.cccCos1Color1.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos1Color1.Location = new System.Drawing.Point(6, 10);
			this.cccCos1Color1.Name = "cccCos1Color1";
			this.cccCos1Color1.ReadOnly = true;
			this.cccCos1Color1.Size = new System.Drawing.Size(277, 29);
			this.cccCos1Color1.TabIndex = 2;
			// 
			// cccCos1Color2
			// 
			this.cccCos1Color2.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos1Color2.Location = new System.Drawing.Point(6, 45);
			this.cccCos1Color2.Name = "cccCos1Color2";
			this.cccCos1Color2.ReadOnly = true;
			this.cccCos1Color2.Size = new System.Drawing.Size(277, 29);
			this.cccCos1Color2.TabIndex = 3;
			// 
			// cccCos2Color3
			// 
			this.cccCos2Color3.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos2Color3.Location = new System.Drawing.Point(6, 80);
			this.cccCos2Color3.Name = "cccCos2Color3";
			this.cccCos2Color3.ReadOnly = true;
			this.cccCos2Color3.Size = new System.Drawing.Size(277, 29);
			this.cccCos2Color3.TabIndex = 7;
			// 
			// cccCos2Color1
			// 
			this.cccCos2Color1.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos2Color1.Location = new System.Drawing.Point(6, 10);
			this.cccCos2Color1.Name = "cccCos2Color1";
			this.cccCos2Color1.ReadOnly = true;
			this.cccCos2Color1.Size = new System.Drawing.Size(277, 29);
			this.cccCos2Color1.TabIndex = 5;
			// 
			// cccCos2Color2
			// 
			this.cccCos2Color2.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos2Color2.Location = new System.Drawing.Point(6, 45);
			this.cccCos2Color2.Name = "cccCos2Color2";
			this.cccCos2Color2.ReadOnly = true;
			this.cccCos2Color2.Size = new System.Drawing.Size(277, 29);
			this.cccCos2Color2.TabIndex = 6;
			// 
			// cccCos3Color3
			// 
			this.cccCos3Color3.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos3Color3.Location = new System.Drawing.Point(6, 80);
			this.cccCos3Color3.Name = "cccCos3Color3";
			this.cccCos3Color3.ReadOnly = true;
			this.cccCos3Color3.Size = new System.Drawing.Size(277, 29);
			this.cccCos3Color3.TabIndex = 10;
			// 
			// cccCos3Color1
			// 
			this.cccCos3Color1.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos3Color1.Location = new System.Drawing.Point(6, 10);
			this.cccCos3Color1.Name = "cccCos3Color1";
			this.cccCos3Color1.ReadOnly = true;
			this.cccCos3Color1.Size = new System.Drawing.Size(277, 29);
			this.cccCos3Color1.TabIndex = 8;
			// 
			// cccCos3Color2
			// 
			this.cccCos3Color2.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos3Color2.Location = new System.Drawing.Point(6, 45);
			this.cccCos3Color2.Name = "cccCos3Color2";
			this.cccCos3Color2.ReadOnly = true;
			this.cccCos3Color2.Size = new System.Drawing.Size(277, 29);
			this.cccCos3Color2.TabIndex = 9;
			// 
			// cccCos4Color3
			// 
			this.cccCos4Color3.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos4Color3.Location = new System.Drawing.Point(6, 80);
			this.cccCos4Color3.Name = "cccCos4Color3";
			this.cccCos4Color3.ReadOnly = true;
			this.cccCos4Color3.Size = new System.Drawing.Size(277, 29);
			this.cccCos4Color3.TabIndex = 13;
			// 
			// cccCos4Color1
			// 
			this.cccCos4Color1.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos4Color1.Location = new System.Drawing.Point(6, 10);
			this.cccCos4Color1.Name = "cccCos4Color1";
			this.cccCos4Color1.ReadOnly = true;
			this.cccCos4Color1.Size = new System.Drawing.Size(277, 29);
			this.cccCos4Color1.TabIndex = 11;
			// 
			// cccCos4Color2
			// 
			this.cccCos4Color2.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccCos4Color2.Location = new System.Drawing.Point(6, 45);
			this.cccCos4Color2.Name = "cccCos4Color2";
			this.cccCos4Color2.ReadOnly = true;
			this.cccCos4Color2.Size = new System.Drawing.Size(277, 29);
			this.cccCos4Color2.TabIndex = 12;
			// 
			// DefaultCostume_VPW64
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.tcCostumeColors);
			this.Controls.Add(this.tbCostumeOutput);
			this.Controls.Add(this.cbCostumes);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 400);
			this.Name = "DefaultCostume_VPW64";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "VPW64 Default Costume Data";
			this.tcCostumeColors.ResumeLayout(false);
			this.tpCostume1.ResumeLayout(false);
			this.tpCostume2.ResumeLayout(false);
			this.tpCostume3.ResumeLayout(false);
			this.tpCostume4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbCostumes;
		private System.Windows.Forms.TextBox tbCostumeOutput;
		private Controls.CostumeColorControl cccCos1Color1;
		private Controls.CostumeColorControl cccCos1Color2;
		private Controls.CostumeColorControl cccCos1Color3;
		private System.Windows.Forms.TabControl tcCostumeColors;
		private System.Windows.Forms.TabPage tpCostume1;
		private System.Windows.Forms.TabPage tpCostume2;
		private System.Windows.Forms.TabPage tpCostume3;
		private System.Windows.Forms.TabPage tpCostume4;
		private Controls.CostumeColorControl cccCos2Color3;
		private Controls.CostumeColorControl cccCos2Color1;
		private Controls.CostumeColorControl cccCos2Color2;
		private Controls.CostumeColorControl cccCos3Color3;
		private Controls.CostumeColorControl cccCos3Color1;
		private Controls.CostumeColorControl cccCos3Color2;
		private Controls.CostumeColorControl cccCos4Color3;
		private Controls.CostumeColorControl cccCos4Color1;
		private Controls.CostumeColorControl cccCos4Color2;
	}
}