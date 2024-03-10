
namespace VPWStudio
{
	partial class CodeSegTest
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
			this.lblCodeSeg = new System.Windows.Forms.Label();
			this.cbCodeSegs = new System.Windows.Forms.ComboBox();
			this.tbCodeSegInfo = new System.Windows.Forms.TextBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.tbPtrOut = new System.Windows.Forms.TextBox();
			this.tbPtrIn = new System.Windows.Forms.TextBox();
			this.lblPtrToRom = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// lblCodeSeg
			// 
			this.lblCodeSeg.AutoSize = true;
			this.lblCodeSeg.Location = new System.Drawing.Point(12, 15);
			this.lblCodeSeg.Name = "lblCodeSeg";
			this.lblCodeSeg.Size = new System.Drawing.Size(77, 13);
			this.lblCodeSeg.TabIndex = 0;
			this.lblCodeSeg.Text = "Code &Segment";
			// 
			// cbCodeSegs
			// 
			this.cbCodeSegs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbCodeSegs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCodeSegs.FormattingEnabled = true;
			this.cbCodeSegs.Location = new System.Drawing.Point(95, 12);
			this.cbCodeSegs.Name = "cbCodeSegs";
			this.cbCodeSegs.Size = new System.Drawing.Size(327, 21);
			this.cbCodeSegs.TabIndex = 1;
			this.cbCodeSegs.SelectedIndexChanged += new System.EventHandler(this.cbCodeSegs_SelectedIndexChanged);
			// 
			// tbCodeSegInfo
			// 
			this.tbCodeSegInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCodeSegInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbCodeSegInfo.Location = new System.Drawing.Point(12, 39);
			this.tbCodeSegInfo.Multiline = true;
			this.tbCodeSegInfo.Name = "tbCodeSegInfo";
			this.tbCodeSegInfo.ReadOnly = true;
			this.tbCodeSegInfo.Size = new System.Drawing.Size(410, 154);
			this.tbCodeSegInfo.TabIndex = 2;
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(226, 199);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(55, 23);
			this.btnConvert.TabIndex = 5;
			this.btnConvert.Text = "&Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// tbPtrOut
			// 
			this.tbPtrOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPtrOut.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPtrOut.Location = new System.Drawing.Point(287, 201);
			this.tbPtrOut.MaxLength = 8;
			this.tbPtrOut.Name = "tbPtrOut";
			this.tbPtrOut.ReadOnly = true;
			this.tbPtrOut.Size = new System.Drawing.Size(135, 23);
			this.tbPtrOut.TabIndex = 6;
			this.toolTip1.SetToolTip(this.tbPtrOut, "Output ROM location (Z64 format)");
			// 
			// tbPtrIn
			// 
			this.tbPtrIn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPtrIn.Location = new System.Drawing.Point(101, 201);
			this.tbPtrIn.MaxLength = 8;
			this.tbPtrIn.Name = "tbPtrIn";
			this.tbPtrIn.Size = new System.Drawing.Size(119, 23);
			this.tbPtrIn.TabIndex = 4;
			this.toolTip1.SetToolTip(this.tbPtrIn, "Input pointer value (80XXXXXX)");
			// 
			// lblPtrToRom
			// 
			this.lblPtrToRom.AutoSize = true;
			this.lblPtrToRom.Location = new System.Drawing.Point(12, 205);
			this.lblPtrToRom.Name = "lblPtrToRom";
			this.lblPtrToRom.Size = new System.Drawing.Size(80, 13);
			this.lblPtrToRom.TabIndex = 3;
			this.lblPtrToRom.Text = "Pointer to ROM";
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 300;
			this.toolTip1.AutoPopDelay = 3000;
			this.toolTip1.InitialDelay = 300;
			this.toolTip1.ReshowDelay = 30;
			// 
			// CodeSegTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 234);
			this.Controls.Add(this.lblPtrToRom);
			this.Controls.Add(this.tbPtrIn);
			this.Controls.Add(this.tbPtrOut);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.tbCodeSegInfo);
			this.Controls.Add(this.cbCodeSegs);
			this.Controls.Add(this.lblCodeSeg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(450, 273);
			this.Name = "CodeSegTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Code Segment Test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCodeSeg;
		private System.Windows.Forms.ComboBox cbCodeSegs;
		private System.Windows.Forms.TextBox tbCodeSegInfo;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox tbPtrOut;
		private System.Windows.Forms.TextBox tbPtrIn;
		private System.Windows.Forms.Label lblPtrToRom;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}