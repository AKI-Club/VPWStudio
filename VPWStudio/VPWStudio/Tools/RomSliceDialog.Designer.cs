namespace VPWStudio
{
	partial class RomSliceDialog
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelStartAddr = new System.Windows.Forms.Label();
			this.tbStartAddr = new System.Windows.Forms.TextBox();
			this.gbParamType = new System.Windows.Forms.GroupBox();
			this.rbEndOffset = new System.Windows.Forms.RadioButton();
			this.rbLength = new System.Windows.Forms.RadioButton();
			this.labelEndValue = new System.Windows.Forms.Label();
			this.tbEndValue = new System.Windows.Forms.TextBox();
			this.labelNotice = new System.Windows.Forms.Label();
			this.gbParamType.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(173, 114);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(56, 23);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(236, 114);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(56, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelStartAddr
			// 
			this.labelStartAddr.AutoSize = true;
			this.labelStartAddr.Location = new System.Drawing.Point(12, 46);
			this.labelStartAddr.Name = "labelStartAddr";
			this.labelStartAddr.Size = new System.Drawing.Size(70, 13);
			this.labelStartAddr.TabIndex = 0;
			this.labelStartAddr.Text = "Start Address";
			// 
			// tbStartAddr
			// 
			this.tbStartAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbStartAddr.Location = new System.Drawing.Point(88, 43);
			this.tbStartAddr.MaxLength = 32;
			this.tbStartAddr.Name = "tbStartAddr";
			this.tbStartAddr.Size = new System.Drawing.Size(204, 20);
			this.tbStartAddr.TabIndex = 1;
			// 
			// gbParamType
			// 
			this.gbParamType.Controls.Add(this.rbEndOffset);
			this.gbParamType.Controls.Add(this.rbLength);
			this.gbParamType.Location = new System.Drawing.Point(12, 95);
			this.gbParamType.Name = "gbParamType";
			this.gbParamType.Size = new System.Drawing.Size(155, 42);
			this.gbParamType.TabIndex = 4;
			this.gbParamType.TabStop = false;
			this.gbParamType.Text = "End Value Type";
			// 
			// rbEndOffset
			// 
			this.rbEndOffset.AutoSize = true;
			this.rbEndOffset.Location = new System.Drawing.Point(74, 19);
			this.rbEndOffset.Name = "rbEndOffset";
			this.rbEndOffset.Size = new System.Drawing.Size(75, 17);
			this.rbEndOffset.TabIndex = 5;
			this.rbEndOffset.Text = "&End Offset";
			this.rbEndOffset.UseVisualStyleBackColor = true;
			// 
			// rbLength
			// 
			this.rbLength.AutoSize = true;
			this.rbLength.Checked = true;
			this.rbLength.Location = new System.Drawing.Point(6, 19);
			this.rbLength.Name = "rbLength";
			this.rbLength.Size = new System.Drawing.Size(58, 17);
			this.rbLength.TabIndex = 4;
			this.rbLength.TabStop = true;
			this.rbLength.Text = "&Length";
			this.rbLength.UseVisualStyleBackColor = true;
			// 
			// labelEndValue
			// 
			this.labelEndValue.AutoSize = true;
			this.labelEndValue.Location = new System.Drawing.Point(12, 72);
			this.labelEndValue.Name = "labelEndValue";
			this.labelEndValue.Size = new System.Drawing.Size(56, 13);
			this.labelEndValue.TabIndex = 2;
			this.labelEndValue.Text = "&End Value";
			// 
			// tbEndValue
			// 
			this.tbEndValue.Location = new System.Drawing.Point(88, 69);
			this.tbEndValue.MaxLength = 32;
			this.tbEndValue.Name = "tbEndValue";
			this.tbEndValue.Size = new System.Drawing.Size(204, 20);
			this.tbEndValue.TabIndex = 3;
			// 
			// labelNotice
			// 
			this.labelNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNotice.Location = new System.Drawing.Point(12, 9);
			this.labelNotice.Name = "labelNotice";
			this.labelNotice.Size = new System.Drawing.Size(280, 24);
			this.labelNotice.TabIndex = 0;
			this.labelNotice.Text = "ALL VALUES ARE HEX!\r\nDON\'T BE A DUMBY DUMDUM!";
			this.labelNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RomSliceDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(304, 149);
			this.Controls.Add(this.labelNotice);
			this.Controls.Add(this.tbEndValue);
			this.Controls.Add(this.labelEndValue);
			this.Controls.Add(this.gbParamType);
			this.Controls.Add(this.tbStartAddr);
			this.Controls.Add(this.labelStartAddr);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RomSliceDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Test ROM Slice";
			this.gbParamType.ResumeLayout(false);
			this.gbParamType.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelStartAddr;
		private System.Windows.Forms.TextBox tbStartAddr;
		private System.Windows.Forms.GroupBox gbParamType;
		private System.Windows.Forms.RadioButton rbEndOffset;
		private System.Windows.Forms.RadioButton rbLength;
		private System.Windows.Forms.Label labelEndValue;
		private System.Windows.Forms.TextBox tbEndValue;
		private System.Windows.Forms.Label labelNotice;
	}
}