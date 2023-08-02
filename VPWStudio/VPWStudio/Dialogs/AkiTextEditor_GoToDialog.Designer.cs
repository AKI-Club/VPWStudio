
namespace VPWStudio
{
	partial class AkiTextEditor_GoToDialog
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
			this.nudTextEntryID = new System.Windows.Forms.NumericUpDown();
			this.lblTextIndex = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudTextEntryID)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(12, 38);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(99, 38);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// nudTextEntryID
			// 
			this.nudTextEntryID.Location = new System.Drawing.Point(84, 12);
			this.nudTextEntryID.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
			this.nudTextEntryID.Name = "nudTextEntryID";
			this.nudTextEntryID.Size = new System.Drawing.Size(90, 20);
			this.nudTextEntryID.TabIndex = 1;
			// 
			// lblTextIndex
			// 
			this.lblTextIndex.AutoSize = true;
			this.lblTextIndex.Location = new System.Drawing.Point(12, 14);
			this.lblTextIndex.Name = "lblTextIndex";
			this.lblTextIndex.Size = new System.Drawing.Size(57, 13);
			this.lblTextIndex.TabIndex = 0;
			this.lblTextIndex.Text = "Text &Index";
			// 
			// AkiTextEditor_GoToDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(186, 73);
			this.Controls.Add(this.lblTextIndex);
			this.Controls.Add(this.nudTextEntryID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AkiTextEditor_GoToDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Go To Text Entry";
			((System.ComponentModel.ISupportInitialize)(this.nudTextEntryID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.NumericUpDown nudTextEntryID;
		private System.Windows.Forms.Label lblTextIndex;
	}
}