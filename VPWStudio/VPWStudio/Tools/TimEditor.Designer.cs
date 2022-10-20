
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
			this.tlpTextureButtons = new System.Windows.Forms.TableLayoutPanel();
			this.btnTextureAdd = new System.Windows.Forms.Button();
			this.btnTextureRemove = new System.Windows.Forms.Button();
			this.lbTextures = new System.Windows.Forms.ListBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exportTIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnTextureMoveUp = new System.Windows.Forms.Button();
			this.btnTextureMoveDown = new System.Windows.Forms.Button();
			this.gbClut = new System.Windows.Forms.GroupBox();
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
            this.openTIMToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportTIMToolStripMenuItem});
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
			this.gbTextures.Size = new System.Drawing.Size(200, 226);
			this.gbTextures.TabIndex = 2;
			this.gbTextures.TabStop = false;
			this.gbTextures.Text = "&Textures";
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
			this.tlpTextureButtons.Controls.Add(this.btnTextureMoveUp, 0, 1);
			this.tlpTextureButtons.Controls.Add(this.btnTextureMoveDown, 1, 1);
			this.tlpTextureButtons.Location = new System.Drawing.Point(6, 155);
			this.tlpTextureButtons.Name = "tlpTextureButtons";
			this.tlpTextureButtons.RowCount = 2;
			this.tlpTextureButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTextureButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTextureButtons.Size = new System.Drawing.Size(188, 65);
			this.tlpTextureButtons.TabIndex = 1;
			// 
			// btnTextureAdd
			// 
			this.btnTextureAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextureAdd.Location = new System.Drawing.Point(3, 4);
			this.btnTextureAdd.Name = "btnTextureAdd";
			this.btnTextureAdd.Size = new System.Drawing.Size(88, 23);
			this.btnTextureAdd.TabIndex = 0;
			this.btnTextureAdd.Text = "&Add...";
			this.btnTextureAdd.UseVisualStyleBackColor = true;
			this.btnTextureAdd.Click += new System.EventHandler(this.btnTextureAdd_Click);
			// 
			// btnTextureRemove
			// 
			this.btnTextureRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextureRemove.Location = new System.Drawing.Point(97, 4);
			this.btnTextureRemove.Name = "btnTextureRemove";
			this.btnTextureRemove.Size = new System.Drawing.Size(88, 23);
			this.btnTextureRemove.TabIndex = 1;
			this.btnTextureRemove.Text = "&Remove";
			this.btnTextureRemove.UseVisualStyleBackColor = true;
			this.btnTextureRemove.Click += new System.EventHandler(this.btnTextureRemove_Click);
			// 
			// lbTextures
			// 
			this.lbTextures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbTextures.FormattingEnabled = true;
			this.lbTextures.Location = new System.Drawing.Point(6, 19);
			this.lbTextures.Name = "lbTextures";
			this.lbTextures.Size = new System.Drawing.Size(188, 121);
			this.lbTextures.TabIndex = 0;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// exportTIMToolStripMenuItem
			// 
			this.exportTIMToolStripMenuItem.Name = "exportTIMToolStripMenuItem";
			this.exportTIMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exportTIMToolStripMenuItem.Text = "Export TIM...";
			this.exportTIMToolStripMenuItem.Click += new System.EventHandler(this.exportTIMToolStripMenuItem_Click);
			// 
			// btnTextureMoveUp
			// 
			this.btnTextureMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextureMoveUp.Location = new System.Drawing.Point(3, 37);
			this.btnTextureMoveUp.Name = "btnTextureMoveUp";
			this.btnTextureMoveUp.Size = new System.Drawing.Size(88, 23);
			this.btnTextureMoveUp.TabIndex = 2;
			this.btnTextureMoveUp.Text = "Move &Up";
			this.btnTextureMoveUp.UseVisualStyleBackColor = true;
			this.btnTextureMoveUp.Click += new System.EventHandler(this.btnTextureMoveUp_Click);
			// 
			// btnTextureMoveDown
			// 
			this.btnTextureMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextureMoveDown.Location = new System.Drawing.Point(97, 37);
			this.btnTextureMoveDown.Name = "btnTextureMoveDown";
			this.btnTextureMoveDown.Size = new System.Drawing.Size(88, 23);
			this.btnTextureMoveDown.TabIndex = 3;
			this.btnTextureMoveDown.Text = "Move &Down";
			this.btnTextureMoveDown.UseVisualStyleBackColor = true;
			this.btnTextureMoveDown.Click += new System.EventHandler(this.btnTextureMoveDown_Click);
			// 
			// gbClut
			// 
			this.gbClut.Location = new System.Drawing.Point(12, 259);
			this.gbClut.Name = "gbClut";
			this.gbClut.Size = new System.Drawing.Size(200, 167);
			this.gbClut.TabIndex = 3;
			this.gbClut.TabStop = false;
			this.gbClut.Text = "CLUT/&Palettes";
			// 
			// TimEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(804, 451);
			this.Controls.Add(this.gbClut);
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
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exportTIMToolStripMenuItem;
		private System.Windows.Forms.Button btnTextureMoveUp;
		private System.Windows.Forms.Button btnTextureMoveDown;
		private System.Windows.Forms.GroupBox gbClut;
	}
}