namespace VPWStudio.Editors.WM2K
{
	partial class Entrance_WM2K
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
			this.tlpEntrances = new System.Windows.Forms.TableLayoutPanel();
			this.cbEntrances = new System.Windows.Forms.ComboBox();
			this.labelEntrance = new System.Windows.Forms.Label();
			this.tcEntranceTabs = new System.Windows.Forms.TabControl();
			this.tpMain = new System.Windows.Forms.TabPage();
			this.tpTitantron = new System.Windows.Forms.TabPage();
			this.tlpEntranceMain = new System.Windows.Forms.TableLayoutPanel();
			this.labelTitantronPointer = new System.Windows.Forms.Label();
			this.labelThemeMusic = new System.Windows.Forms.Label();
			this.labelTextIndex = new System.Windows.Forms.Label();
			this.labelUnknown = new System.Windows.Forms.Label();
			this.labelLightingDelay = new System.Windows.Forms.Label();
			this.tbTitantronPointer = new System.Windows.Forms.TextBox();
			this.tbThemeMusic = new System.Windows.Forms.TextBox();
			this.tbTextIndex = new System.Windows.Forms.TextBox();
			this.tbUnknown = new System.Windows.Forms.TextBox();
			this.tbLightingDelay = new System.Windows.Forms.TextBox();
			this.tlpEntrances.SuspendLayout();
			this.tcEntranceTabs.SuspendLayout();
			this.tpMain.SuspendLayout();
			this.tlpEntranceMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpEntrances
			// 
			this.tlpEntrances.ColumnCount = 2;
			this.tlpEntrances.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpEntrances.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpEntrances.Controls.Add(this.cbEntrances, 1, 0);
			this.tlpEntrances.Controls.Add(this.labelEntrance, 0, 0);
			this.tlpEntrances.Location = new System.Drawing.Point(12, 12);
			this.tlpEntrances.Name = "tlpEntrances";
			this.tlpEntrances.RowCount = 1;
			this.tlpEntrances.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEntrances.Size = new System.Drawing.Size(352, 36);
			this.tlpEntrances.TabIndex = 0;
			// 
			// cbEntrances
			// 
			this.cbEntrances.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbEntrances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntrances.FormattingEnabled = true;
			this.cbEntrances.Location = new System.Drawing.Point(108, 7);
			this.cbEntrances.Name = "cbEntrances";
			this.cbEntrances.Size = new System.Drawing.Size(241, 21);
			this.cbEntrances.TabIndex = 0;
			this.cbEntrances.SelectedIndexChanged += new System.EventHandler(this.cbEntrances_SelectedIndexChanged);
			// 
			// labelEntrance
			// 
			this.labelEntrance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEntrance.AutoSize = true;
			this.labelEntrance.Location = new System.Drawing.Point(3, 11);
			this.labelEntrance.Name = "labelEntrance";
			this.labelEntrance.Size = new System.Drawing.Size(99, 13);
			this.labelEntrance.TabIndex = 1;
			this.labelEntrance.Text = "&Entrance";
			// 
			// tcEntranceTabs
			// 
			this.tcEntranceTabs.Controls.Add(this.tpMain);
			this.tcEntranceTabs.Controls.Add(this.tpTitantron);
			this.tcEntranceTabs.Location = new System.Drawing.Point(12, 54);
			this.tcEntranceTabs.Name = "tcEntranceTabs";
			this.tcEntranceTabs.SelectedIndex = 0;
			this.tcEntranceTabs.Size = new System.Drawing.Size(352, 207);
			this.tcEntranceTabs.TabIndex = 1;
			// 
			// tpMain
			// 
			this.tpMain.Controls.Add(this.tlpEntranceMain);
			this.tpMain.Location = new System.Drawing.Point(4, 22);
			this.tpMain.Name = "tpMain";
			this.tpMain.Padding = new System.Windows.Forms.Padding(3);
			this.tpMain.Size = new System.Drawing.Size(344, 181);
			this.tpMain.TabIndex = 0;
			this.tpMain.Text = "Main";
			this.tpMain.UseVisualStyleBackColor = true;
			// 
			// tpTitantron
			// 
			this.tpTitantron.Location = new System.Drawing.Point(4, 22);
			this.tpTitantron.Name = "tpTitantron";
			this.tpTitantron.Padding = new System.Windows.Forms.Padding(3);
			this.tpTitantron.Size = new System.Drawing.Size(344, 181);
			this.tpTitantron.TabIndex = 1;
			this.tpTitantron.Text = "Titantron";
			this.tpTitantron.UseVisualStyleBackColor = true;
			// 
			// tlpEntranceMain
			// 
			this.tlpEntranceMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpEntranceMain.ColumnCount = 2;
			this.tlpEntranceMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpEntranceMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpEntranceMain.Controls.Add(this.labelTitantronPointer, 0, 0);
			this.tlpEntranceMain.Controls.Add(this.labelThemeMusic, 0, 1);
			this.tlpEntranceMain.Controls.Add(this.labelTextIndex, 0, 2);
			this.tlpEntranceMain.Controls.Add(this.labelUnknown, 0, 3);
			this.tlpEntranceMain.Controls.Add(this.labelLightingDelay, 0, 4);
			this.tlpEntranceMain.Controls.Add(this.tbTitantronPointer, 1, 0);
			this.tlpEntranceMain.Controls.Add(this.tbThemeMusic, 1, 1);
			this.tlpEntranceMain.Controls.Add(this.tbTextIndex, 1, 2);
			this.tlpEntranceMain.Controls.Add(this.tbUnknown, 1, 3);
			this.tlpEntranceMain.Controls.Add(this.tbLightingDelay, 1, 4);
			this.tlpEntranceMain.Location = new System.Drawing.Point(6, 6);
			this.tlpEntranceMain.Name = "tlpEntranceMain";
			this.tlpEntranceMain.RowCount = 5;
			this.tlpEntranceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpEntranceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpEntranceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpEntranceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpEntranceMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpEntranceMain.Size = new System.Drawing.Size(332, 169);
			this.tlpEntranceMain.TabIndex = 0;
			// 
			// labelTitantronPointer
			// 
			this.labelTitantronPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitantronPointer.AutoSize = true;
			this.labelTitantronPointer.Location = new System.Drawing.Point(3, 10);
			this.labelTitantronPointer.Name = "labelTitantronPointer";
			this.labelTitantronPointer.Size = new System.Drawing.Size(93, 13);
			this.labelTitantronPointer.TabIndex = 0;
			this.labelTitantronPointer.Text = "Titantron Pointer";
			// 
			// labelThemeMusic
			// 
			this.labelThemeMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelThemeMusic.AutoSize = true;
			this.labelThemeMusic.Location = new System.Drawing.Point(3, 43);
			this.labelThemeMusic.Name = "labelThemeMusic";
			this.labelThemeMusic.Size = new System.Drawing.Size(93, 13);
			this.labelThemeMusic.TabIndex = 1;
			this.labelThemeMusic.Text = "Theme Music";
			// 
			// labelTextIndex
			// 
			this.labelTextIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTextIndex.AutoSize = true;
			this.labelTextIndex.Location = new System.Drawing.Point(3, 76);
			this.labelTextIndex.Name = "labelTextIndex";
			this.labelTextIndex.Size = new System.Drawing.Size(93, 13);
			this.labelTextIndex.TabIndex = 2;
			this.labelTextIndex.Text = "Text Index";
			// 
			// labelUnknown
			// 
			this.labelUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUnknown.AutoSize = true;
			this.labelUnknown.Location = new System.Drawing.Point(3, 109);
			this.labelUnknown.Name = "labelUnknown";
			this.labelUnknown.Size = new System.Drawing.Size(93, 13);
			this.labelUnknown.TabIndex = 3;
			this.labelUnknown.Text = "Unknown";
			// 
			// labelLightingDelay
			// 
			this.labelLightingDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelLightingDelay.AutoSize = true;
			this.labelLightingDelay.Location = new System.Drawing.Point(3, 144);
			this.labelLightingDelay.Name = "labelLightingDelay";
			this.labelLightingDelay.Size = new System.Drawing.Size(93, 13);
			this.labelLightingDelay.TabIndex = 4;
			this.labelLightingDelay.Text = "Lighting, Delay";
			// 
			// tbTitantronPointer
			// 
			this.tbTitantronPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTitantronPointer.Location = new System.Drawing.Point(102, 6);
			this.tbTitantronPointer.Name = "tbTitantronPointer";
			this.tbTitantronPointer.ReadOnly = true;
			this.tbTitantronPointer.Size = new System.Drawing.Size(227, 20);
			this.tbTitantronPointer.TabIndex = 5;
			// 
			// tbThemeMusic
			// 
			this.tbThemeMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbThemeMusic.Location = new System.Drawing.Point(102, 39);
			this.tbThemeMusic.Name = "tbThemeMusic";
			this.tbThemeMusic.ReadOnly = true;
			this.tbThemeMusic.Size = new System.Drawing.Size(227, 20);
			this.tbThemeMusic.TabIndex = 6;
			// 
			// tbTextIndex
			// 
			this.tbTextIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTextIndex.Location = new System.Drawing.Point(102, 72);
			this.tbTextIndex.Name = "tbTextIndex";
			this.tbTextIndex.ReadOnly = true;
			this.tbTextIndex.Size = new System.Drawing.Size(227, 20);
			this.tbTextIndex.TabIndex = 7;
			// 
			// tbUnknown
			// 
			this.tbUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnknown.Location = new System.Drawing.Point(102, 105);
			this.tbUnknown.Name = "tbUnknown";
			this.tbUnknown.ReadOnly = true;
			this.tbUnknown.Size = new System.Drawing.Size(227, 20);
			this.tbUnknown.TabIndex = 8;
			// 
			// tbLightingDelay
			// 
			this.tbLightingDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLightingDelay.Location = new System.Drawing.Point(102, 140);
			this.tbLightingDelay.Name = "tbLightingDelay";
			this.tbLightingDelay.ReadOnly = true;
			this.tbLightingDelay.Size = new System.Drawing.Size(227, 20);
			this.tbLightingDelay.TabIndex = 9;
			// 
			// Entrance_WM2K
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 273);
			this.Controls.Add(this.tcEntranceTabs);
			this.Controls.Add(this.tlpEntrances);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Entrance_WM2K";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "WM2K Entrance Editor";
			this.tlpEntrances.ResumeLayout(false);
			this.tlpEntrances.PerformLayout();
			this.tcEntranceTabs.ResumeLayout(false);
			this.tpMain.ResumeLayout(false);
			this.tlpEntranceMain.ResumeLayout(false);
			this.tlpEntranceMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpEntrances;
		private System.Windows.Forms.ComboBox cbEntrances;
		private System.Windows.Forms.Label labelEntrance;
		private System.Windows.Forms.TabControl tcEntranceTabs;
		private System.Windows.Forms.TabPage tpMain;
		private System.Windows.Forms.TabPage tpTitantron;
		private System.Windows.Forms.TableLayoutPanel tlpEntranceMain;
		private System.Windows.Forms.Label labelTitantronPointer;
		private System.Windows.Forms.Label labelThemeMusic;
		private System.Windows.Forms.Label labelTextIndex;
		private System.Windows.Forms.Label labelUnknown;
		private System.Windows.Forms.Label labelLightingDelay;
		private System.Windows.Forms.TextBox tbTitantronPointer;
		private System.Windows.Forms.TextBox tbThemeMusic;
		private System.Windows.Forms.TextBox tbTextIndex;
		private System.Windows.Forms.TextBox tbUnknown;
		private System.Windows.Forms.TextBox tbLightingDelay;
	}
}