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
			this.gbDestinationWrestlers.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbDestStable
			// 
			this.cbDestStable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDestStable.FormattingEnabled = true;
			this.cbDestStable.Location = new System.Drawing.Point(12, 54);
			this.cbDestStable.Name = "cbDestStable";
			this.cbDestStable.Size = new System.Drawing.Size(121, 21);
			this.cbDestStable.TabIndex = 0;
			// 
			// gbDestinationWrestlers
			// 
			this.gbDestinationWrestlers.Controls.Add(this.lbDestStableWrestlers);
			this.gbDestinationWrestlers.Location = new System.Drawing.Point(163, 38);
			this.gbDestinationWrestlers.Name = "gbDestinationWrestlers";
			this.gbDestinationWrestlers.Size = new System.Drawing.Size(137, 150);
			this.gbDestinationWrestlers.TabIndex = 1;
			this.gbDestinationWrestlers.TabStop = false;
			this.gbDestinationWrestlers.Text = "Destination Wrestlers";
			// 
			// lbDestStableWrestlers
			// 
			this.lbDestStableWrestlers.FormattingEnabled = true;
			this.lbDestStableWrestlers.Location = new System.Drawing.Point(6, 19);
			this.lbDestStableWrestlers.Name = "lbDestStableWrestlers";
			this.lbDestStableWrestlers.Size = new System.Drawing.Size(125, 121);
			this.lbDestStableWrestlers.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(144, 194);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(225, 194);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelDestStable
			// 
			this.labelDestStable.AutoSize = true;
			this.labelDestStable.Location = new System.Drawing.Point(12, 38);
			this.labelDestStable.Name = "labelDestStable";
			this.labelDestStable.Size = new System.Drawing.Size(93, 13);
			this.labelDestStable.TabIndex = 2;
			this.labelDestStable.Text = "Destination &Stable";
			// 
			// SwapWrestler_VPW2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 229);
			this.Controls.Add(this.cbDestStable);
			this.Controls.Add(this.labelDestStable);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbDestinationWrestlers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SwapWrestler_VPW2";
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
	}
}