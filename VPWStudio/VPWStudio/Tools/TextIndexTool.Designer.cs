
namespace VPWStudio.Tools
{
	partial class TextIndexTool
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
			this.btnUpdate = new System.Windows.Forms.Button();
			this.tbInputValue = new System.Windows.Forms.TextBox();
			this.tbOutputValue = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblInput = new System.Windows.Forms.Label();
			this.lblOutput = new System.Windows.Forms.Label();
			this.labelRegion = new System.Windows.Forms.Label();
			this.lblRegionValue = new System.Windows.Forms.Label();
			this.lblNote = new System.Windows.Forms.Label();
			this.btnLaunchTextEditor = new System.Windows.Forms.Button();
			this.lblMode = new System.Windows.Forms.Label();
			this.flpMode = new System.Windows.Forms.FlowLayoutPanel();
			this.rbVPW2 = new System.Windows.Forms.RadioButton();
			this.rbNoMercy = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.flpMode.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(285, 142);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 12;
			this.btnUpdate.Text = "&Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// tbInputValue
			// 
			this.tbInputValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInputValue.Location = new System.Drawing.Point(90, 5);
			this.tbInputValue.MaxLength = 8;
			this.tbInputValue.Name = "tbInputValue";
			this.tbInputValue.Size = new System.Drawing.Size(255, 20);
			this.tbInputValue.TabIndex = 1;
			// 
			// tbOutputValue
			// 
			this.tbOutputValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputValue.Location = new System.Drawing.Point(90, 36);
			this.tbOutputValue.MaxLength = 32;
			this.tbOutputValue.Name = "tbOutputValue";
			this.tbOutputValue.ReadOnly = true;
			this.tbOutputValue.Size = new System.Drawing.Size(255, 20);
			this.tbOutputValue.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tableLayoutPanel1.Controls.Add(this.tbInputValue, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbOutputValue, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblInput, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblOutput, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelRegion, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblRegionValue, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblMode, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.flpMode, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 124);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblInput
			// 
			this.lblInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInput.AutoSize = true;
			this.lblInput.Location = new System.Drawing.Point(3, 9);
			this.lblInput.Name = "lblInput";
			this.lblInput.Size = new System.Drawing.Size(81, 13);
			this.lblInput.TabIndex = 0;
			this.lblInput.Text = "&Input (0xF???)";
			// 
			// lblOutput
			// 
			this.lblOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblOutput.AutoSize = true;
			this.lblOutput.Location = new System.Drawing.Point(3, 40);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(81, 13);
			this.lblOutput.TabIndex = 2;
			this.lblOutput.Text = "&Output";
			// 
			// labelRegion
			// 
			this.labelRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRegion.AutoSize = true;
			this.labelRegion.Location = new System.Drawing.Point(3, 71);
			this.labelRegion.Name = "labelRegion";
			this.labelRegion.Size = new System.Drawing.Size(81, 13);
			this.labelRegion.TabIndex = 4;
			this.labelRegion.Text = "Region";
			// 
			// lblRegionValue
			// 
			this.lblRegionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRegionValue.AutoSize = true;
			this.lblRegionValue.Location = new System.Drawing.Point(90, 71);
			this.lblRegionValue.Name = "lblRegionValue";
			this.lblRegionValue.Size = new System.Drawing.Size(255, 13);
			this.lblRegionValue.TabIndex = 5;
			this.lblRegionValue.Text = "(region)";
			// 
			// lblNote
			// 
			this.lblNote.AutoSize = true;
			this.lblNote.Location = new System.Drawing.Point(12, 147);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(82, 13);
			this.lblNote.TabIndex = 10;
			this.lblNote.Text = "F0BF is index 0.";
			// 
			// btnLaunchTextEditor
			// 
			this.btnLaunchTextEditor.Enabled = false;
			this.btnLaunchTextEditor.Location = new System.Drawing.Point(191, 142);
			this.btnLaunchTextEditor.Name = "btnLaunchTextEditor";
			this.btnLaunchTextEditor.Size = new System.Drawing.Size(88, 23);
			this.btnLaunchTextEditor.TabIndex = 11;
			this.btnLaunchTextEditor.Text = "&Go To Entry...";
			this.btnLaunchTextEditor.UseVisualStyleBackColor = true;
			this.btnLaunchTextEditor.Click += new System.EventHandler(this.btnLaunchTextEditor_Click);
			// 
			// lblMode
			// 
			this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMode.AutoSize = true;
			this.lblMode.Location = new System.Drawing.Point(3, 102);
			this.lblMode.Name = "lblMode";
			this.lblMode.Size = new System.Drawing.Size(81, 13);
			this.lblMode.TabIndex = 6;
			this.lblMode.Text = "&Mode";
			// 
			// flpMode
			// 
			this.flpMode.Controls.Add(this.rbVPW2);
			this.flpMode.Controls.Add(this.rbNoMercy);
			this.flpMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpMode.Location = new System.Drawing.Point(90, 96);
			this.flpMode.Name = "flpMode";
			this.flpMode.Size = new System.Drawing.Size(255, 25);
			this.flpMode.TabIndex = 7;
			// 
			// rbVPW2
			// 
			this.rbVPW2.AutoSize = true;
			this.rbVPW2.Location = new System.Drawing.Point(3, 3);
			this.rbVPW2.Name = "rbVPW2";
			this.rbVPW2.Size = new System.Drawing.Size(56, 17);
			this.rbVPW2.TabIndex = 8;
			this.rbVPW2.TabStop = true;
			this.rbVPW2.Text = "&VPW2";
			this.rbVPW2.UseVisualStyleBackColor = true;
			this.rbVPW2.CheckedChanged += new System.EventHandler(this.rbVPW2_CheckedChanged);
			// 
			// rbNoMercy
			// 
			this.rbNoMercy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rbNoMercy.AutoSize = true;
			this.rbNoMercy.Location = new System.Drawing.Point(65, 3);
			this.rbNoMercy.Name = "rbNoMercy";
			this.rbNoMercy.Size = new System.Drawing.Size(71, 17);
			this.rbNoMercy.TabIndex = 9;
			this.rbNoMercy.TabStop = true;
			this.rbNoMercy.Text = "&No Mercy";
			this.rbNoMercy.UseVisualStyleBackColor = true;
			this.rbNoMercy.CheckedChanged += new System.EventHandler(this.rbNoMercy_CheckedChanged);
			// 
			// TextIndexTool
			// 
			this.AcceptButton = this.btnUpdate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 177);
			this.Controls.Add(this.btnLaunchTextEditor);
			this.Controls.Add(this.lblNote);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.btnUpdate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TextIndexTool";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Text Index Tool";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextIndexTool_KeyDown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flpMode.ResumeLayout(false);
			this.flpMode.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.TextBox tbInputValue;
		private System.Windows.Forms.TextBox tbOutputValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblInput;
		private System.Windows.Forms.Label lblOutput;
		private System.Windows.Forms.Label labelRegion;
		private System.Windows.Forms.Label lblRegionValue;
		private System.Windows.Forms.Label lblNote;
		private System.Windows.Forms.Button btnLaunchTextEditor;
		private System.Windows.Forms.Label lblMode;
		private System.Windows.Forms.FlowLayoutPanel flpMode;
		private System.Windows.Forms.RadioButton rbVPW2;
		private System.Windows.Forms.RadioButton rbNoMercy;
	}
}