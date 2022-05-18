namespace VPWStudio
{
	partial class SwapWrestler_VPW2
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
			this.cbDestStable = new System.Windows.Forms.ComboBox();
			this.gbDestinationWrestlers = new System.Windows.Forms.GroupBox();
			this.lbDestStableWrestlers = new System.Windows.Forms.ListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelDestStable = new System.Windows.Forms.Label();
			this.labelSwapWres1 = new System.Windows.Forms.Label();
			this.gbDestinationWrestlers.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbDestStable
			// 
			this.cbDestStable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDestStable.FormattingEnabled = true;
			this.cbDestStable.Location = new System.Drawing.Point(111, 25);
			this.cbDestStable.Name = "cbDestStable";
			this.cbDestStable.Size = new System.Drawing.Size(150, 21);
			this.cbDestStable.TabIndex = 1;
			this.cbDestStable.SelectedIndexChanged += new System.EventHandler(this.cbDestStable_SelectedIndexChanged);
			// 
			// gbDestinationWrestlers
			// 
			this.gbDestinationWrestlers.Controls.Add(this.lbDestStableWrestlers);
			this.gbDestinationWrestlers.Location = new System.Drawing.Point(12, 52);
			this.gbDestinationWrestlers.Name = "gbDestinationWrestlers";
			this.gbDestinationWrestlers.Size = new System.Drawing.Size(249, 136);
			this.gbDestinationWrestlers.TabIndex = 2;
			this.gbDestinationWrestlers.TabStop = false;
			this.gbDestinationWrestlers.Text = "Destination &Wrestlers";
			// 
			// lbDestStableWrestlers
			// 
			this.lbDestStableWrestlers.FormattingEnabled = true;
			this.lbDestStableWrestlers.Location = new System.Drawing.Point(6, 19);
			this.lbDestStableWrestlers.Name = "lbDestStableWrestlers";
			this.lbDestStableWrestlers.Size = new System.Drawing.Size(237, 108);
			this.lbDestStableWrestlers.TabIndex = 3;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(12, 194);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(186, 194);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelDestStable
			// 
			this.labelDestStable.AutoSize = true;
			this.labelDestStable.Location = new System.Drawing.Point(12, 28);
			this.labelDestStable.Name = "labelDestStable";
			this.labelDestStable.Size = new System.Drawing.Size(93, 13);
			this.labelDestStable.TabIndex = 0;
			this.labelDestStable.Text = "Destination &Stable";
			// 
			// labelSwapWres1
			// 
			this.labelSwapWres1.AutoSize = true;
			this.labelSwapWres1.Location = new System.Drawing.Point(12, 9);
			this.labelSwapWres1.Name = "labelSwapWres1";
			this.labelSwapWres1.Size = new System.Drawing.Size(256, 13);
			this.labelSwapWres1.TabIndex = 0;
			this.labelSwapWres1.Text = "Swapping Wrestler ID2 {0:X2}, currently in Stable {1}";
			// 
			// SwapWrestler_VPW2
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(273, 229);
			this.Controls.Add(this.labelSwapWres1);
			this.Controls.Add(this.cbDestStable);
			this.Controls.Add(this.labelDestStable);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbDestinationWrestlers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SwapWrestler_VPW2";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Swap Wrestlers";
			this.gbDestinationWrestlers.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbDestStable;
		private System.Windows.Forms.GroupBox gbDestinationWrestlers;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListBox lbDestStableWrestlers;
		private System.Windows.Forms.Label labelDestStable;
		private System.Windows.Forms.Label labelSwapWres1;
	}
}