﻿
namespace VPWStudio
{
	partial class TestScene3D_AddEditDialog
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tlpItemInfo = new System.Windows.Forms.TableLayoutPanel();
			this.lblModelFileID = new System.Windows.Forms.Label();
			this.lblPaletteFileID = new System.Windows.Forms.Label();
			this.lblTextureFileID = new System.Windows.Forms.Label();
			this.cbModelFileID = new System.Windows.Forms.ComboBox();
			this.cbPaletteFileID = new System.Windows.Forms.ComboBox();
			this.cbTextureFileID = new System.Windows.Forms.ComboBox();
			this.tbModelComment = new System.Windows.Forms.TextBox();
			this.tbPaletteComment = new System.Windows.Forms.TextBox();
			this.tbTextureComment = new System.Windows.Forms.TextBox();
			this.lblCiType = new System.Windows.Forms.Label();
			this.cbCiType = new System.Windows.Forms.ComboBox();
			this.tlpItemInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(236, 166);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(317, 166);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tlpItemInfo
			// 
			this.tlpItemInfo.ColumnCount = 3;
			this.tlpItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.5098F));
			this.tlpItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.56863F));
			this.tlpItemInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.92157F));
			this.tlpItemInfo.Controls.Add(this.lblModelFileID, 0, 0);
			this.tlpItemInfo.Controls.Add(this.cbModelFileID, 1, 0);
			this.tlpItemInfo.Controls.Add(this.tbModelComment, 2, 0);
			this.tlpItemInfo.Controls.Add(this.lblTextureFileID, 0, 3);
			this.tlpItemInfo.Controls.Add(this.cbTextureFileID, 1, 3);
			this.tlpItemInfo.Controls.Add(this.tbTextureComment, 2, 3);
			this.tlpItemInfo.Controls.Add(this.tbPaletteComment, 2, 2);
			this.tlpItemInfo.Controls.Add(this.cbPaletteFileID, 1, 2);
			this.tlpItemInfo.Controls.Add(this.lblPaletteFileID, 0, 2);
			this.tlpItemInfo.Controls.Add(this.lblCiType, 0, 1);
			this.tlpItemInfo.Controls.Add(this.cbCiType, 2, 1);
			this.tlpItemInfo.Location = new System.Drawing.Point(12, 12);
			this.tlpItemInfo.Name = "tlpItemInfo";
			this.tlpItemInfo.RowCount = 4;
			this.tlpItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpItemInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpItemInfo.Size = new System.Drawing.Size(380, 148);
			this.tlpItemInfo.TabIndex = 2;
			// 
			// lblModelFileID
			// 
			this.lblModelFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblModelFileID.AutoSize = true;
			this.lblModelFileID.Location = new System.Drawing.Point(3, 12);
			this.lblModelFileID.Name = "lblModelFileID";
			this.lblModelFileID.Size = new System.Drawing.Size(87, 13);
			this.lblModelFileID.TabIndex = 0;
			this.lblModelFileID.Text = "&Model File ID";
			// 
			// lblPaletteFileID
			// 
			this.lblPaletteFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPaletteFileID.AutoSize = true;
			this.lblPaletteFileID.Location = new System.Drawing.Point(3, 86);
			this.lblPaletteFileID.Name = "lblPaletteFileID";
			this.lblPaletteFileID.Size = new System.Drawing.Size(87, 13);
			this.lblPaletteFileID.TabIndex = 1;
			this.lblPaletteFileID.Text = "&Palette File ID";
			// 
			// lblTextureFileID
			// 
			this.lblTextureFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTextureFileID.AutoSize = true;
			this.lblTextureFileID.Location = new System.Drawing.Point(3, 123);
			this.lblTextureFileID.Name = "lblTextureFileID";
			this.lblTextureFileID.Size = new System.Drawing.Size(87, 13);
			this.lblTextureFileID.TabIndex = 2;
			this.lblTextureFileID.Text = "&Texture File ID";
			// 
			// cbModelFileID
			// 
			this.cbModelFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbModelFileID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModelFileID.DropDownWidth = 512;
			this.cbModelFileID.FormattingEnabled = true;
			this.cbModelFileID.Location = new System.Drawing.Point(96, 8);
			this.cbModelFileID.Name = "cbModelFileID";
			this.cbModelFileID.Size = new System.Drawing.Size(75, 21);
			this.cbModelFileID.TabIndex = 3;
			this.cbModelFileID.SelectedIndexChanged += new System.EventHandler(this.cbModelFileID_SelectedIndexChanged);
			// 
			// cbPaletteFileID
			// 
			this.cbPaletteFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPaletteFileID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPaletteFileID.DropDownWidth = 512;
			this.cbPaletteFileID.FormattingEnabled = true;
			this.cbPaletteFileID.Location = new System.Drawing.Point(96, 82);
			this.cbPaletteFileID.Name = "cbPaletteFileID";
			this.cbPaletteFileID.Size = new System.Drawing.Size(75, 21);
			this.cbPaletteFileID.TabIndex = 4;
			this.cbPaletteFileID.SelectedIndexChanged += new System.EventHandler(this.cbPaletteFileID_SelectedIndexChanged);
			// 
			// cbTextureFileID
			// 
			this.cbTextureFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTextureFileID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTextureFileID.DropDownWidth = 512;
			this.cbTextureFileID.FormattingEnabled = true;
			this.cbTextureFileID.Location = new System.Drawing.Point(96, 119);
			this.cbTextureFileID.Name = "cbTextureFileID";
			this.cbTextureFileID.Size = new System.Drawing.Size(75, 21);
			this.cbTextureFileID.TabIndex = 5;
			this.cbTextureFileID.SelectedIndexChanged += new System.EventHandler(this.cbTextureFileID_SelectedIndexChanged);
			// 
			// tbModelComment
			// 
			this.tbModelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbModelComment.Location = new System.Drawing.Point(177, 8);
			this.tbModelComment.Name = "tbModelComment";
			this.tbModelComment.ReadOnly = true;
			this.tbModelComment.Size = new System.Drawing.Size(200, 20);
			this.tbModelComment.TabIndex = 6;
			// 
			// tbPaletteComment
			// 
			this.tbPaletteComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPaletteComment.Location = new System.Drawing.Point(177, 82);
			this.tbPaletteComment.Name = "tbPaletteComment";
			this.tbPaletteComment.ReadOnly = true;
			this.tbPaletteComment.Size = new System.Drawing.Size(200, 20);
			this.tbPaletteComment.TabIndex = 7;
			// 
			// tbTextureComment
			// 
			this.tbTextureComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTextureComment.Location = new System.Drawing.Point(177, 119);
			this.tbTextureComment.Name = "tbTextureComment";
			this.tbTextureComment.ReadOnly = true;
			this.tbTextureComment.Size = new System.Drawing.Size(200, 20);
			this.tbTextureComment.TabIndex = 8;
			// 
			// lblCiType
			// 
			this.lblCiType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCiType.AutoSize = true;
			this.lblCiType.Location = new System.Drawing.Point(3, 49);
			this.lblCiType.Name = "lblCiType";
			this.lblCiType.Size = new System.Drawing.Size(87, 13);
			this.lblCiType.TabIndex = 9;
			this.lblCiType.Text = "CI T&ype";
			// 
			// cbCiType
			// 
			this.cbCiType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbCiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCiType.FormattingEnabled = true;
			this.cbCiType.Items.AddRange(new object[] {
            "CI4 (16 colors)",
            "CI8 (256 colors)"});
			this.cbCiType.Location = new System.Drawing.Point(177, 45);
			this.cbCiType.Name = "cbCiType";
			this.cbCiType.Size = new System.Drawing.Size(200, 21);
			this.cbCiType.TabIndex = 10;
			this.cbCiType.SelectedIndexChanged += new System.EventHandler(this.cbCiType_SelectedIndexChanged);
			// 
			// TestScene3D_AddEditDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(404, 201);
			this.Controls.Add(this.tlpItemInfo);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TestScene3D_AddEditDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Object";
			this.tlpItemInfo.ResumeLayout(false);
			this.tlpItemInfo.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TableLayoutPanel tlpItemInfo;
		private System.Windows.Forms.Label lblModelFileID;
		private System.Windows.Forms.Label lblPaletteFileID;
		private System.Windows.Forms.Label lblTextureFileID;
		private System.Windows.Forms.ComboBox cbModelFileID;
		private System.Windows.Forms.ComboBox cbPaletteFileID;
		private System.Windows.Forms.ComboBox cbTextureFileID;
		private System.Windows.Forms.TextBox tbModelComment;
		private System.Windows.Forms.TextBox tbPaletteComment;
		private System.Windows.Forms.TextBox tbTextureComment;
		private System.Windows.Forms.Label lblCiType;
		private System.Windows.Forms.ComboBox cbCiType;
	}
}