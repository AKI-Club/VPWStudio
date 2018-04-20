namespace VPWStudio.Editors.VPW2
{
	partial class CostumeDefs
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
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpBodyTypes = new System.Windows.Forms.TabPage();
			this.tpCostumes = new System.Windows.Forms.TabPage();
			this.tpHeadMask = new System.Windows.Forms.TabPage();
			this.lbBodyTypes = new System.Windows.Forms.ListBox();
			this.tcHeadsMasks = new System.Windows.Forms.TabControl();
			this.tpHeads = new System.Windows.Forms.TabPage();
			this.tpMasks = new System.Windows.Forms.TabPage();
			this.tcMain.SuspendLayout();
			this.tpBodyTypes.SuspendLayout();
			this.tpHeadMask.SuspendLayout();
			this.tcHeadsMasks.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpBodyTypes);
			this.tcMain.Controls.Add(this.tpCostumes);
			this.tcMain.Controls.Add(this.tpHeadMask);
			this.tcMain.Location = new System.Drawing.Point(12, 12);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(608, 389);
			this.tcMain.TabIndex = 0;
			// 
			// tpBodyTypes
			// 
			this.tpBodyTypes.Controls.Add(this.lbBodyTypes);
			this.tpBodyTypes.Location = new System.Drawing.Point(4, 22);
			this.tpBodyTypes.Name = "tpBodyTypes";
			this.tpBodyTypes.Padding = new System.Windows.Forms.Padding(3);
			this.tpBodyTypes.Size = new System.Drawing.Size(600, 363);
			this.tpBodyTypes.TabIndex = 0;
			this.tpBodyTypes.Text = "Body Types";
			this.tpBodyTypes.UseVisualStyleBackColor = true;
			// 
			// tpCostumes
			// 
			this.tpCostumes.Location = new System.Drawing.Point(4, 22);
			this.tpCostumes.Name = "tpCostumes";
			this.tpCostumes.Padding = new System.Windows.Forms.Padding(3);
			this.tpCostumes.Size = new System.Drawing.Size(600, 363);
			this.tpCostumes.TabIndex = 1;
			this.tpCostumes.Text = "Costumes";
			this.tpCostumes.UseVisualStyleBackColor = true;
			// 
			// tpHeadMask
			// 
			this.tpHeadMask.Controls.Add(this.tcHeadsMasks);
			this.tpHeadMask.Location = new System.Drawing.Point(4, 22);
			this.tpHeadMask.Name = "tpHeadMask";
			this.tpHeadMask.Size = new System.Drawing.Size(600, 363);
			this.tpHeadMask.TabIndex = 2;
			this.tpHeadMask.Text = "Heads/Masks";
			this.tpHeadMask.UseVisualStyleBackColor = true;
			// 
			// lbBodyTypes
			// 
			this.lbBodyTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbBodyTypes.FormattingEnabled = true;
			this.lbBodyTypes.Location = new System.Drawing.Point(6, 6);
			this.lbBodyTypes.Name = "lbBodyTypes";
			this.lbBodyTypes.Size = new System.Drawing.Size(120, 355);
			this.lbBodyTypes.TabIndex = 2;
			// 
			// tcHeadsMasks
			// 
			this.tcHeadsMasks.Controls.Add(this.tpHeads);
			this.tcHeadsMasks.Controls.Add(this.tpMasks);
			this.tcHeadsMasks.Location = new System.Drawing.Point(3, 3);
			this.tcHeadsMasks.Name = "tcHeadsMasks";
			this.tcHeadsMasks.SelectedIndex = 0;
			this.tcHeadsMasks.Size = new System.Drawing.Size(594, 357);
			this.tcHeadsMasks.TabIndex = 0;
			// 
			// tpHeads
			// 
			this.tpHeads.Location = new System.Drawing.Point(4, 22);
			this.tpHeads.Name = "tpHeads";
			this.tpHeads.Padding = new System.Windows.Forms.Padding(3);
			this.tpHeads.Size = new System.Drawing.Size(586, 331);
			this.tpHeads.TabIndex = 0;
			this.tpHeads.Text = "Heads";
			this.tpHeads.UseVisualStyleBackColor = true;
			// 
			// tpMasks
			// 
			this.tpMasks.Location = new System.Drawing.Point(4, 22);
			this.tpMasks.Name = "tpMasks";
			this.tpMasks.Padding = new System.Windows.Forms.Padding(3);
			this.tpMasks.Size = new System.Drawing.Size(586, 331);
			this.tpMasks.TabIndex = 1;
			this.tpMasks.Text = "Masks";
			this.tpMasks.UseVisualStyleBackColor = true;
			// 
			// CostumeDefs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 413);
			this.Controls.Add(this.tcMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CostumeDefs";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Costumes, Heads/Masks, Body Types (VPW2)";
			this.tcMain.ResumeLayout(false);
			this.tpBodyTypes.ResumeLayout(false);
			this.tpHeadMask.ResumeLayout(false);
			this.tcHeadsMasks.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpBodyTypes;
		private System.Windows.Forms.TabPage tpCostumes;
		private System.Windows.Forms.TabPage tpHeadMask;
		private System.Windows.Forms.ListBox lbBodyTypes;
		private System.Windows.Forms.TabControl tcHeadsMasks;
		private System.Windows.Forms.TabPage tpHeads;
		private System.Windows.Forms.TabPage tpMasks;
	}
}