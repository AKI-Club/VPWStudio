
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
			this.cccColor1 = new VPWStudio.Controls.CostumeColorControl();
			this.cccColor2 = new VPWStudio.Controls.CostumeColorControl();
			this.cccColor3 = new VPWStudio.Controls.CostumeColorControl();
			this.gbCostume1Colors = new System.Windows.Forms.GroupBox();
			this.gbCostume1Colors.SuspendLayout();
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
			// cccColor1
			// 
			this.cccColor1.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccColor1.Location = new System.Drawing.Point(6, 19);
			this.cccColor1.Name = "cccColor1";
			this.cccColor1.ReadOnly = true;
			this.cccColor1.Size = new System.Drawing.Size(285, 29);
			this.cccColor1.TabIndex = 2;
			// 
			// cccColor2
			// 
			this.cccColor2.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccColor2.Location = new System.Drawing.Point(6, 54);
			this.cccColor2.Name = "cccColor2";
			this.cccColor2.ReadOnly = true;
			this.cccColor2.Size = new System.Drawing.Size(285, 29);
			this.cccColor2.TabIndex = 3;
			// 
			// cccColor3
			// 
			this.cccColor3.ColorModeType = VPWStudio.Controls.CostumeColorControl.ColorMode.VPW64;
			this.cccColor3.Location = new System.Drawing.Point(6, 89);
			this.cccColor3.Name = "cccColor3";
			this.cccColor3.ReadOnly = true;
			this.cccColor3.Size = new System.Drawing.Size(285, 29);
			this.cccColor3.TabIndex = 4;
			// 
			// gbCostume1Colors
			// 
			this.gbCostume1Colors.Controls.Add(this.cccColor1);
			this.gbCostume1Colors.Controls.Add(this.cccColor3);
			this.gbCostume1Colors.Controls.Add(this.cccColor2);
			this.gbCostume1Colors.Location = new System.Drawing.Point(315, 39);
			this.gbCostume1Colors.Name = "gbCostume1Colors";
			this.gbCostume1Colors.Size = new System.Drawing.Size(297, 133);
			this.gbCostume1Colors.TabIndex = 5;
			this.gbCostume1Colors.TabStop = false;
			this.gbCostume1Colors.Text = "Costume 1 Colors";
			// 
			// DefaultCostume_VPW64
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.gbCostume1Colors);
			this.Controls.Add(this.tbCostumeOutput);
			this.Controls.Add(this.cbCostumes);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 400);
			this.Name = "DefaultCostume_VPW64";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "VPW64 Default Costume Data";
			this.gbCostume1Colors.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbCostumes;
		private System.Windows.Forms.TextBox tbCostumeOutput;
		private Controls.CostumeColorControl cccColor1;
		private Controls.CostumeColorControl cccColor2;
		private Controls.CostumeColorControl cccColor3;
		private System.Windows.Forms.GroupBox gbCostume1Colors;
	}
}