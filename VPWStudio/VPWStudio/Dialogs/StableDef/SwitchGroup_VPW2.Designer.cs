namespace VPWStudio
{
	partial class SwitchGroup_VPW2
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
			this.labelTarget = new System.Windows.Forms.Label();
			this.cbTargetGroup = new System.Windows.Forms.ComboBox();
			this.labelWrestlerID = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(126, 52);
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
			this.buttonCancel.Location = new System.Drawing.Point(207, 52);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelTarget
			// 
			this.labelTarget.AutoSize = true;
			this.labelTarget.Location = new System.Drawing.Point(12, 28);
			this.labelTarget.Name = "labelTarget";
			this.labelTarget.Size = new System.Drawing.Size(62, 13);
			this.labelTarget.TabIndex = 0;
			this.labelTarget.Text = "New &Stable";
			// 
			// cbTargetGroup
			// 
			this.cbTargetGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTargetGroup.FormattingEnabled = true;
			this.cbTargetGroup.Location = new System.Drawing.Point(79, 25);
			this.cbTargetGroup.Name = "cbTargetGroup";
			this.cbTargetGroup.Size = new System.Drawing.Size(203, 21);
			this.cbTargetGroup.TabIndex = 1;
			// 
			// labelWrestlerID
			// 
			this.labelWrestlerID.AutoSize = true;
			this.labelWrestlerID.Location = new System.Drawing.Point(12, 9);
			this.labelWrestlerID.Name = "labelWrestlerID";
			this.labelWrestlerID.Size = new System.Drawing.Size(247, 13);
			this.labelWrestlerID.TabIndex = 4;
			this.labelWrestlerID.Text = "Moving Wrestler ID2: {0:X2}, currently in Stable {1}";
			// 
			// SwitchGroup_VPW2
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(294, 87);
			this.Controls.Add(this.labelWrestlerID);
			this.Controls.Add(this.cbTargetGroup);
			this.Controls.Add(this.labelTarget);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SwitchGroup_VPW2";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Move Wrestler to Stable";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelTarget;
		private System.Windows.Forms.ComboBox cbTargetGroup;
		private System.Windows.Forms.Label labelWrestlerID;
	}
}