namespace VPWStudio
{
	partial class StableDefParseTest
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
			this.tbInput = new System.Windows.Forms.TextBox();
			this.labelInput = new System.Windows.Forms.Label();
			this.buttonParse = new System.Windows.Forms.Button();
			this.gbOutput = new System.Windows.Forms.GroupBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.gbOutput.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbInput
			// 
			this.tbInput.Location = new System.Drawing.Point(49, 12);
			this.tbInput.Name = "tbInput";
			this.tbInput.Size = new System.Drawing.Size(180, 20);
			this.tbInput.TabIndex = 0;
			// 
			// labelInput
			// 
			this.labelInput.AutoSize = true;
			this.labelInput.Location = new System.Drawing.Point(12, 15);
			this.labelInput.Name = "labelInput";
			this.labelInput.Size = new System.Drawing.Size(31, 13);
			this.labelInput.TabIndex = 1;
			this.labelInput.Text = "&Input";
			// 
			// buttonParse
			// 
			this.buttonParse.Location = new System.Drawing.Point(235, 10);
			this.buttonParse.Name = "buttonParse";
			this.buttonParse.Size = new System.Drawing.Size(65, 23);
			this.buttonParse.TabIndex = 2;
			this.buttonParse.Text = "&Parse";
			this.buttonParse.UseVisualStyleBackColor = true;
			this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
			// 
			// gbOutput
			// 
			this.gbOutput.Controls.Add(this.tbOutput);
			this.gbOutput.Location = new System.Drawing.Point(12, 38);
			this.gbOutput.Name = "gbOutput";
			this.gbOutput.Size = new System.Drawing.Size(288, 163);
			this.gbOutput.TabIndex = 3;
			this.gbOutput.TabStop = false;
			this.gbOutput.Text = "Output";
			// 
			// tbOutput
			// 
			this.tbOutput.Location = new System.Drawing.Point(6, 19);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.Size = new System.Drawing.Size(276, 138);
			this.tbOutput.TabIndex = 0;
			// 
			// StableDefParseTest
			// 
			this.AcceptButton = this.buttonParse;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 213);
			this.Controls.Add(this.gbOutput);
			this.Controls.Add(this.buttonParse);
			this.Controls.Add(this.labelInput);
			this.Controls.Add(this.tbInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StableDefParseTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "StableDefParseTest";
			this.gbOutput.ResumeLayout(false);
			this.gbOutput.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.Label labelInput;
		private System.Windows.Forms.Button buttonParse;
		private System.Windows.Forms.GroupBox gbOutput;
		private System.Windows.Forms.TextBox tbOutput;
	}
}