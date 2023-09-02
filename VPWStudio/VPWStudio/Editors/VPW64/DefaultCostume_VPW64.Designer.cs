
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
			this.tbCostumeOutput.Size = new System.Drawing.Size(600, 310);
			this.tbCostumeOutput.TabIndex = 1;
			// 
			// DefaultCostume_VPW64
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.tbCostumeOutput);
			this.Controls.Add(this.cbCostumes);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 400);
			this.Name = "DefaultCostume_VPW64";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "VPW64 Default Costume Data";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbCostumes;
		private System.Windows.Forms.TextBox tbCostumeOutput;
	}
}