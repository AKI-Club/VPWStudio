
namespace VPWStudio
{
	partial class SelectTextureDialog
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
			this.tlpTexture = new System.Windows.Forms.TableLayoutPanel();
			this.gbPreview = new System.Windows.Forms.GroupBox();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.tlpTextureSelect = new System.Windows.Forms.TableLayoutPanel();
			this.labelTextureType = new System.Windows.Forms.Label();
			this.labelTextureFileID = new System.Windows.Forms.Label();
			this.labelPaletteFileID = new System.Windows.Forms.Label();
			this.cbTextureType = new System.Windows.Forms.ComboBox();
			this.cbTextureFileIDs = new System.Windows.Forms.ComboBox();
			this.cbPaletteFileIDs = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tlpDialogResultButtons = new System.Windows.Forms.TableLayoutPanel();
			this.tlpTexture.SuspendLayout();
			this.gbPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.tlpTextureSelect.SuspendLayout();
			this.tlpDialogResultButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpTexture
			// 
			this.tlpTexture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tlpTexture.ColumnCount = 2;
			this.tlpTexture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTexture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpTexture.Controls.Add(this.gbPreview, 1, 0);
			this.tlpTexture.Controls.Add(this.tlpTextureSelect, 0, 0);
			this.tlpTexture.Location = new System.Drawing.Point(12, 12);
			this.tlpTexture.Name = "tlpTexture";
			this.tlpTexture.RowCount = 1;
			this.tlpTexture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpTexture.Size = new System.Drawing.Size(472, 219);
			this.tlpTexture.TabIndex = 0;
			// 
			// gbPreview
			// 
			this.gbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbPreview.Controls.Add(this.pbPreview);
			this.gbPreview.Location = new System.Drawing.Point(239, 3);
			this.gbPreview.Name = "gbPreview";
			this.gbPreview.Size = new System.Drawing.Size(230, 213);
			this.gbPreview.TabIndex = 0;
			this.gbPreview.TabStop = false;
			this.gbPreview.Text = "Preview";
			// 
			// pbPreview
			// 
			this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPreview.Location = new System.Drawing.Point(3, 16);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(224, 194);
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// tlpTextureSelect
			// 
			this.tlpTextureSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tlpTextureSelect.ColumnCount = 2;
			this.tlpTextureSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpTextureSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpTextureSelect.Controls.Add(this.labelTextureType, 0, 0);
			this.tlpTextureSelect.Controls.Add(this.labelTextureFileID, 0, 1);
			this.tlpTextureSelect.Controls.Add(this.labelPaletteFileID, 0, 2);
			this.tlpTextureSelect.Controls.Add(this.cbTextureType, 1, 0);
			this.tlpTextureSelect.Controls.Add(this.cbTextureFileIDs, 1, 1);
			this.tlpTextureSelect.Controls.Add(this.cbPaletteFileIDs, 1, 2);
			this.tlpTextureSelect.Location = new System.Drawing.Point(3, 3);
			this.tlpTextureSelect.Name = "tlpTextureSelect";
			this.tlpTextureSelect.RowCount = 3;
			this.tlpTextureSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpTextureSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpTextureSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpTextureSelect.Size = new System.Drawing.Size(230, 213);
			this.tlpTextureSelect.TabIndex = 1;
			// 
			// labelTextureType
			// 
			this.labelTextureType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTextureType.AutoSize = true;
			this.labelTextureType.Location = new System.Drawing.Point(3, 29);
			this.labelTextureType.Name = "labelTextureType";
			this.labelTextureType.Size = new System.Drawing.Size(86, 13);
			this.labelTextureType.TabIndex = 0;
			this.labelTextureType.Text = "Texture &Type";
			// 
			// labelTextureFileID
			// 
			this.labelTextureFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTextureFileID.AutoSize = true;
			this.labelTextureFileID.Location = new System.Drawing.Point(3, 100);
			this.labelTextureFileID.Name = "labelTextureFileID";
			this.labelTextureFileID.Size = new System.Drawing.Size(86, 13);
			this.labelTextureFileID.TabIndex = 1;
			this.labelTextureFileID.Text = "Texture &File ID";
			// 
			// labelPaletteFileID
			// 
			this.labelPaletteFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPaletteFileID.AutoSize = true;
			this.labelPaletteFileID.Location = new System.Drawing.Point(3, 171);
			this.labelPaletteFileID.Name = "labelPaletteFileID";
			this.labelPaletteFileID.Size = new System.Drawing.Size(86, 13);
			this.labelPaletteFileID.TabIndex = 2;
			this.labelPaletteFileID.Text = "&Palette File ID";
			// 
			// cbTextureType
			// 
			this.cbTextureType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTextureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTextureType.FormattingEnabled = true;
			this.cbTextureType.Items.AddRange(new object[] {
			"CI4Texture",
			"CI8Texture",
			"AkiTexture"});
			this.cbTextureType.Location = new System.Drawing.Point(95, 25);
			this.cbTextureType.Name = "cbTextureType";
			this.cbTextureType.Size = new System.Drawing.Size(132, 21);
			this.cbTextureType.TabIndex = 3;
			this.cbTextureType.SelectedIndexChanged += new System.EventHandler(this.cbTextureType_SelectedIndexChanged);
			this.cbTextureType.SelectionChangeCommitted += new System.EventHandler(this.cbTextureType_SelectionChangeCommitted);
			// 
			// cbTextureFileIDs
			// 
			this.cbTextureFileIDs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTextureFileIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTextureFileIDs.FormattingEnabled = true;
			this.cbTextureFileIDs.Location = new System.Drawing.Point(95, 96);
			this.cbTextureFileIDs.Name = "cbTextureFileIDs";
			this.cbTextureFileIDs.Size = new System.Drawing.Size(132, 21);
			this.cbTextureFileIDs.TabIndex = 4;
			this.cbTextureFileIDs.SelectedIndexChanged += new System.EventHandler(this.cbTextureFileIDs_SelectedIndexChanged);
			this.cbTextureFileIDs.SelectionChangeCommitted += new System.EventHandler(this.cbTextureFileIDs_SelectionChangeCommitted);
			// 
			// cbPaletteFileIDs
			// 
			this.cbPaletteFileIDs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPaletteFileIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPaletteFileIDs.FormattingEnabled = true;
			this.cbPaletteFileIDs.Location = new System.Drawing.Point(95, 167);
			this.cbPaletteFileIDs.Name = "cbPaletteFileIDs";
			this.cbPaletteFileIDs.Size = new System.Drawing.Size(132, 21);
			this.cbPaletteFileIDs.TabIndex = 5;
			this.cbPaletteFileIDs.SelectedIndexChanged += new System.EventHandler(this.cbPaletteFileIDs_SelectedIndexChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(3, 3);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(230, 26);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(239, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(230, 26);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tlpDialogResultButtons
			// 
			this.tlpDialogResultButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tlpDialogResultButtons.ColumnCount = 2;
			this.tlpDialogResultButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDialogResultButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDialogResultButtons.Controls.Add(this.buttonOK, 0, 0);
			this.tlpDialogResultButtons.Controls.Add(this.buttonCancel, 1, 0);
			this.tlpDialogResultButtons.Location = new System.Drawing.Point(12, 237);
			this.tlpDialogResultButtons.Name = "tlpDialogResultButtons";
			this.tlpDialogResultButtons.RowCount = 1;
			this.tlpDialogResultButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDialogResultButtons.Size = new System.Drawing.Size(472, 32);
			this.tlpDialogResultButtons.TabIndex = 3;
			// 
			// SelectTextureDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 281);
			this.Controls.Add(this.tlpDialogResultButtons);
			this.Controls.Add(this.tlpTexture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 320);
			this.Name = "SelectTextureDialog";
			this.Text = "Select Texture";
			this.tlpTexture.ResumeLayout(false);
			this.gbPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.tlpTextureSelect.ResumeLayout(false);
			this.tlpTextureSelect.PerformLayout();
			this.tlpDialogResultButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpTexture;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tlpDialogResultButtons;
		private System.Windows.Forms.GroupBox gbPreview;
		private System.Windows.Forms.TableLayoutPanel tlpTextureSelect;
		private System.Windows.Forms.Label labelTextureType;
		private System.Windows.Forms.Label labelTextureFileID;
		private System.Windows.Forms.Label labelPaletteFileID;
		private System.Windows.Forms.ComboBox cbTextureType;
		private System.Windows.Forms.ComboBox cbTextureFileIDs;
		private System.Windows.Forms.ComboBox cbPaletteFileIDs;
		private System.Windows.Forms.PictureBox pbPreview;
	}
}