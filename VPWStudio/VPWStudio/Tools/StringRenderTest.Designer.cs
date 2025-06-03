
namespace VPWStudio
{
	partial class StringRenderTest
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
			this.pbStringPreview = new System.Windows.Forms.PictureBox();
			this.gbText = new System.Windows.Forms.GroupBox();
			this.tbPreviewText = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.largeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.smallFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadedFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			((System.ComponentModel.ISupportInitialize)(this.pbStringPreview)).BeginInit();
			this.gbText.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbStringPreview
			// 
			this.pbStringPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbStringPreview.BackColor = System.Drawing.Color.Black;
			this.pbStringPreview.Location = new System.Drawing.Point(12, 168);
			this.pbStringPreview.MaximumSize = new System.Drawing.Size(480, 240);
			this.pbStringPreview.MinimumSize = new System.Drawing.Size(480, 240);
			this.pbStringPreview.Name = "pbStringPreview";
			this.pbStringPreview.Size = new System.Drawing.Size(480, 240);
			this.pbStringPreview.TabIndex = 0;
			this.pbStringPreview.TabStop = false;
			// 
			// gbText
			// 
			this.gbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbText.Controls.Add(this.tbPreviewText);
			this.gbText.Location = new System.Drawing.Point(12, 27);
			this.gbText.Name = "gbText";
			this.gbText.Size = new System.Drawing.Size(480, 131);
			this.gbText.TabIndex = 2;
			this.gbText.TabStop = false;
			this.gbText.Text = "&Text";
			// 
			// tbPreviewText
			// 
			this.tbPreviewText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPreviewText.Location = new System.Drawing.Point(3, 16);
			this.tbPreviewText.MaxLength = 65535;
			this.tbPreviewText.Multiline = true;
			this.tbPreviewText.Name = "tbPreviewText";
			this.tbPreviewText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbPreviewText.Size = new System.Drawing.Size(474, 112);
			this.tbPreviewText.TabIndex = 0;
			this.tbPreviewText.TextChanged += new System.EventHandler(this.tbPreviewText_TextChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(504, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeFontToolStripMenuItem,
            this.smallFontToolStripMenuItem,
            this.toolStripSeparator1,
            this.openFontToolStripMenuItem,
            this.loadedFontToolStripMenuItem});
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.fontToolStripMenuItem.Text = "&Font";
			// 
			// largeFontToolStripMenuItem
			// 
			this.largeFontToolStripMenuItem.Name = "largeFontToolStripMenuItem";
			this.largeFontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.largeFontToolStripMenuItem.Text = "&Large Font";
			this.largeFontToolStripMenuItem.Click += new System.EventHandler(this.largeFontToolStripMenuItem_Click);
			// 
			// smallFontToolStripMenuItem
			// 
			this.smallFontToolStripMenuItem.Name = "smallFontToolStripMenuItem";
			this.smallFontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.smallFontToolStripMenuItem.Text = "&Small Font";
			this.smallFontToolStripMenuItem.Click += new System.EventHandler(this.smallFontToolStripMenuItem_Click);
			// 
			// openFontToolStripMenuItem
			// 
			this.openFontToolStripMenuItem.Name = "openFontToolStripMenuItem";
			this.openFontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openFontToolStripMenuItem.Text = "&Open Font...";
			this.openFontToolStripMenuItem.Click += new System.EventHandler(this.openFontToolStripMenuItem_Click);
			// 
			// loadedFontToolStripMenuItem
			// 
			this.loadedFontToolStripMenuItem.Name = "loadedFontToolStripMenuItem";
			this.loadedFontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadedFontToolStripMenuItem.Text = "Lo&aded Font";
			this.loadedFontToolStripMenuItem.Click += new System.EventHandler(this.loadedFontToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// StringRenderTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 420);
			this.Controls.Add(this.gbText);
			this.Controls.Add(this.pbStringPreview);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(520, 414);
			this.Name = "StringRenderTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "String Render Test";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StringRenderTest_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pbStringPreview)).EndInit();
			this.gbText.ResumeLayout(false);
			this.gbText.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbStringPreview;
		private System.Windows.Forms.GroupBox gbText;
		private System.Windows.Forms.TextBox tbPreviewText;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem largeFontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem smallFontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFontToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem loadedFontToolStripMenuItem;
	}
}