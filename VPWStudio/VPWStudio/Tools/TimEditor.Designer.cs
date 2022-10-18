
namespace VPWStudio.Tools
{
	partial class TimEditor
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.timStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openTIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbTextures = new System.Windows.Forms.GroupBox();
			this.lbTextures = new System.Windows.Forms.ListBox();
			this.tlpTextureButtons = new System.Windows.Forms.TableLayoutPanel();
			this.btnTextureAdd = new System.Windows.Forms.Button();
			this.btnTextureRemove = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.gbTextures.SuspendLayout();
			this.tlpTextureButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 429);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(804, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// timStatusLabel
			// 
			this.timStatusLabel.Name = "timStatusLabel";
			this.timStatusLabel.Size = new System.Drawing.Size(90, 17);
			this.timStatusLabel.Text = "New project file";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(804, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openTIMToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newProjectToolStripMenuItem.Text = "&New Project";
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
			// 
			// openTIMToolStripMenuItem
			// 
			this.openTIMToolStripMenuItem.Name = "openTIMToolStripMenuItem";
			this.openTIMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openTIMToolStripMenuItem.Text = "&Open TIM...";
			this.openTIMToolStripMenuItem.Click += new System.EventHandler(this.openTIMToolStripMenuItem_Click);
			// 
			// gbTextures
			// 
			this.gbTextures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbTextures.Controls.Add(this.tlpTextureButtons);
			this.gbTextures.Controls.Add(this.lbTextures);
			this.gbTextures.Location = new System.Drawing.Point(12, 27);
			this.gbTextures.Name = "gbTextures";
			this.gbTextures.Size = new System.Drawing.Size(200, 399);
			this.gbTextures.TabIndex = 2;
			this.gbTextures.TabStop = false;
			this.gbTextures.Text = "Textures";
			// 
			// lbTextures
			// 
			this.lbTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbTextures.FormattingEnabled = true;
			this.lbTextures.Location = new System.Drawing.Point(6, 19);
			this.lbTextures.Name = "lbTextures";
			this.lbTextures.Size = new System.Drawing.Size(188, 329);
			this.lbTextures.TabIndex = 0;
			// 
			// tlpTextureButtons
			// 
			this.tlpTextureButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpTextureButtons.ColumnCount = 2;
			this.tlpTextureButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTextureButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTextureButtons.Controls.Add(this.btnTextureAdd, 0, 0);
			this.tlpTextureButtons.Controls.Add(this.btnTextureRemove, 1, 0);
			this.tlpTextureButtons.Location = new System.Drawing.Point(6, 355);
			this.tlpTextureButtons.Name = "tlpTextureButtons";
			this.tlpTextureButtons.RowCount = 1;
			this.tlpTextureButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTextureButtons.Size = new System.Drawing.Size(188, 38);
			this.tlpTextureButtons.TabIndex = 1;
			// 
			// btnTextureAdd
			// 
			this.btnTextureAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextureAdd.Location = new System.Drawing.Point(3, 7);
			this.btnTextureAdd.Name = "btnTextureAdd";
			this.btnTextureAdd.Size = new System.Drawing.Size(88, 23);
			this.btnTextureAdd.TabIndex = 0;
			this.btnTextureAdd.Text = "&Add...";
			this.btnTextureAdd.UseVisualStyleBackColor = true;
			// 
			// btnTextureRemove
			// 
			this.btnTextureRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextureRemove.Location = new System.Drawing.Point(97, 7);
			this.btnTextureRemove.Name = "btnTextureRemove";
			this.btnTextureRemove.Size = new System.Drawing.Size(88, 23);
			this.btnTextureRemove.TabIndex = 1;
			this.btnTextureRemove.Text = "&Remove";
			this.btnTextureRemove.UseVisualStyleBackColor = true;
			// 
			// TimEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(804, 451);
			this.Controls.Add(this.gbTextures);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(820, 490);
			this.Name = "TimEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TIM Editor";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.gbTextures.ResumeLayout(false);
			this.tlpTextureButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel timStatusLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openTIMToolStripMenuItem;
		private System.Windows.Forms.GroupBox gbTextures;
		private System.Windows.Forms.ListBox lbTextures;
		private System.Windows.Forms.TableLayoutPanel tlpTextureButtons;
		private System.Windows.Forms.Button btnTextureAdd;
		private System.Windows.Forms.Button btnTextureRemove;
	}
}