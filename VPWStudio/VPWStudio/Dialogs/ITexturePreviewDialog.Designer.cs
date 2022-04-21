namespace VPWStudio
{
	partial class ITexturePreviewDialog
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
			this.components = new System.ComponentModel.Container();
			this.cmsPreview = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.savePNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.foregroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tlpMainContainer = new System.Windows.Forms.TableLayoutPanel();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.tlpImageControls = new System.Windows.Forms.TableLayoutPanel();
			this.buttonRedraw = new System.Windows.Forms.Button();
			this.labelWidth = new System.Windows.Forms.Label();
			this.labelHeight = new System.Windows.Forms.Label();
			this.nudWidth = new System.Windows.Forms.NumericUpDown();
			this.nudHeight = new System.Windows.Forms.NumericUpDown();
			this.cmsPreview.SuspendLayout();
			this.tlpMainContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.tlpImageControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// cmsPreview
			// 
			this.cmsPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePNGToolStripMenuItem,
            this.backgroundColorToolStripMenuItem,
            this.foregroundColorToolStripMenuItem});
			this.cmsPreview.Name = "cmsPreview";
			this.cmsPreview.Size = new System.Drawing.Size(180, 70);
			// 
			// savePNGToolStripMenuItem
			// 
			this.savePNGToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
			this.savePNGToolStripMenuItem.Name = "savePNGToolStripMenuItem";
			this.savePNGToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.savePNGToolStripMenuItem.Text = "Save &PNG...";
			this.savePNGToolStripMenuItem.Click += new System.EventHandler(this.savePNGToolStripMenuItem_Click);
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.backgroundColorToolStripMenuItem.Text = "&Background Color...";
			this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
			// 
			// foregroundColorToolStripMenuItem
			// 
			this.foregroundColorToolStripMenuItem.Name = "foregroundColorToolStripMenuItem";
			this.foregroundColorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.foregroundColorToolStripMenuItem.Text = "&Foreground Color...";
			this.foregroundColorToolStripMenuItem.Click += new System.EventHandler(this.foregroundColorToolStripMenuItem_Click);
			// 
			// tlpMainContainer
			// 
			this.tlpMainContainer.ColumnCount = 1;
			this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMainContainer.Controls.Add(this.pbPreview, 0, 1);
			this.tlpMainContainer.Controls.Add(this.tlpImageControls, 0, 0);
			this.tlpMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMainContainer.Location = new System.Drawing.Point(0, 0);
			this.tlpMainContainer.Name = "tlpMainContainer";
			this.tlpMainContainer.RowCount = 2;
			this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.51376F));
			this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.48624F));
			this.tlpMainContainer.Size = new System.Drawing.Size(314, 218);
			this.tlpMainContainer.TabIndex = 1;
			// 
			// pbPreview
			// 
			this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbPreview.BackColor = System.Drawing.SystemColors.Control;
			this.pbPreview.ContextMenuStrip = this.cmsPreview;
			this.pbPreview.Location = new System.Drawing.Point(0, 35);
			this.pbPreview.Margin = new System.Windows.Forms.Padding(0);
			this.pbPreview.MinimumSize = new System.Drawing.Size(1, 1);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(314, 183);
			this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbPreview.TabIndex = 3;
			this.pbPreview.TabStop = false;
			// 
			// tlpImageControls
			// 
			this.tlpImageControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpImageControls.ColumnCount = 5;
			this.tlpImageControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImageControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImageControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImageControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImageControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpImageControls.Controls.Add(this.buttonRedraw, 4, 0);
			this.tlpImageControls.Controls.Add(this.labelWidth, 0, 0);
			this.tlpImageControls.Controls.Add(this.labelHeight, 2, 0);
			this.tlpImageControls.Controls.Add(this.nudWidth, 1, 0);
			this.tlpImageControls.Controls.Add(this.nudHeight, 3, 0);
			this.tlpImageControls.Location = new System.Drawing.Point(3, 3);
			this.tlpImageControls.Name = "tlpImageControls";
			this.tlpImageControls.RowCount = 1;
			this.tlpImageControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpImageControls.Size = new System.Drawing.Size(308, 29);
			this.tlpImageControls.TabIndex = 4;
			// 
			// buttonRedraw
			// 
			this.buttonRedraw.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonRedraw.Location = new System.Drawing.Point(247, 3);
			this.buttonRedraw.Name = "buttonRedraw";
			this.buttonRedraw.Size = new System.Drawing.Size(58, 23);
			this.buttonRedraw.TabIndex = 2;
			this.buttonRedraw.Text = "&Redraw";
			this.buttonRedraw.UseVisualStyleBackColor = true;
			this.buttonRedraw.Click += new System.EventHandler(this.buttonRedraw_Click);
			// 
			// labelWidth
			// 
			this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWidth.AutoSize = true;
			this.labelWidth.Location = new System.Drawing.Point(3, 8);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new System.Drawing.Size(55, 13);
			this.labelWidth.TabIndex = 0;
			this.labelWidth.Text = "&Width";
			// 
			// labelHeight
			// 
			this.labelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHeight.AutoSize = true;
			this.labelHeight.Location = new System.Drawing.Point(125, 8);
			this.labelHeight.Name = "labelHeight";
			this.labelHeight.Size = new System.Drawing.Size(55, 13);
			this.labelHeight.TabIndex = 1;
			this.labelHeight.Text = "&Height";
			// 
			// nudWidth
			// 
			this.nudWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudWidth.Location = new System.Drawing.Point(64, 4);
			this.nudWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
			this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWidth.Name = "nudWidth";
			this.nudWidth.Size = new System.Drawing.Size(55, 20);
			this.nudWidth.TabIndex = 0;
			this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWidth.Enter += new System.EventHandler(this.nudWidth_Enter);
			// 
			// nudHeight
			// 
			this.nudHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudHeight.Location = new System.Drawing.Point(186, 4);
			this.nudHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
			this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudHeight.Name = "nudHeight";
			this.nudHeight.Size = new System.Drawing.Size(55, 20);
			this.nudHeight.TabIndex = 1;
			this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudHeight.Enter += new System.EventHandler(this.nudHeight_Enter);
			// 
			// ITexturePreviewDialog
			// 
			this.AcceptButton = this.buttonRedraw;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(314, 218);
			this.Controls.Add(this.tlpMainContainer);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1024, 768);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(322, 245);
			this.Name = "ITexturePreviewDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preview";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_ITexturePreviewDialog_KeyDown);
			this.cmsPreview.ResumeLayout(false);
			this.tlpMainContainer.ResumeLayout(false);
			this.tlpMainContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.tlpImageControls.ResumeLayout(false);
			this.tlpImageControls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip cmsPreview;
		private System.Windows.Forms.ToolStripMenuItem savePNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tlpMainContainer;
		private System.Windows.Forms.PictureBox pbPreview;
		private System.Windows.Forms.TableLayoutPanel tlpImageControls;
		private System.Windows.Forms.Button buttonRedraw;
		private System.Windows.Forms.Label labelWidth;
		private System.Windows.Forms.Label labelHeight;
		private System.Windows.Forms.NumericUpDown nudWidth;
		private System.Windows.Forms.NumericUpDown nudHeight;
		private System.Windows.Forms.ToolStripMenuItem foregroundColorToolStripMenuItem;
	}
}