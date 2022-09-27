
namespace VPWStudio.Editors.NoMercy
{
	partial class Ruleset_NoMercy
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblRulesetIndex = new System.Windows.Forms.Label();
			this.cbRulesets = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblMatchRuleset = new System.Windows.Forms.Label();
			this.lblTimeLimit = new System.Windows.Forms.Label();
			this.lblCountOut = new System.Windows.Forms.Label();
			this.lblPin = new System.Windows.Forms.Label();
			this.lblSubmission = new System.Windows.Forms.Label();
			this.lblTKO = new System.Windows.Forms.Label();
			this.lblRopeBreak = new System.Windows.Forms.Label();
			this.lblDQ = new System.Windows.Forms.Label();
			this.lblBlood = new System.Windows.Forms.Label();
			this.lblInterference = new System.Windows.Forms.Label();
			this.lblTagHelpTime = new System.Windows.Forms.Label();
			this.lblRoyalRumbleTimer = new System.Windows.Forms.Label();
			this.tbMatchRuleset = new System.Windows.Forms.TextBox();
			this.tbTimeLimit = new System.Windows.Forms.TextBox();
			this.tbCountOut = new System.Windows.Forms.TextBox();
			this.tbPin = new System.Windows.Forms.TextBox();
			this.tbSubmission = new System.Windows.Forms.TextBox();
			this.tbTKO = new System.Windows.Forms.TextBox();
			this.tbRopeBreak = new System.Windows.Forms.TextBox();
			this.tbDQ = new System.Windows.Forms.TextBox();
			this.tbBlood = new System.Windows.Forms.TextBox();
			this.tbInterference = new System.Windows.Forms.TextBox();
			this.tbTagHelpTime = new System.Windows.Forms.TextBox();
			this.tbRoyalRumbleTimer = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.Controls.Add(this.lblRulesetIndex, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbRulesets, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 27);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(296, 246);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(377, 246);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.tableLayoutPanel2);
			this.panel1.Location = new System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(440, 195);
			this.panel1.TabIndex = 4;
			// 
			// lblRulesetIndex
			// 
			this.lblRulesetIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRulesetIndex.AutoSize = true;
			this.lblRulesetIndex.Location = new System.Drawing.Point(3, 7);
			this.lblRulesetIndex.Name = "lblRulesetIndex";
			this.lblRulesetIndex.Size = new System.Drawing.Size(82, 13);
			this.lblRulesetIndex.TabIndex = 0;
			this.lblRulesetIndex.Text = "Ruleset Index";
			// 
			// cbRulesets
			// 
			this.cbRulesets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbRulesets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRulesets.FormattingEnabled = true;
			this.cbRulesets.Location = new System.Drawing.Point(91, 3);
			this.cbRulesets.Name = "cbRulesets";
			this.cbRulesets.Size = new System.Drawing.Size(346, 21);
			this.cbRulesets.TabIndex = 1;
			this.cbRulesets.SelectedIndexChanged += new System.EventHandler(this.cbRulesets_SelectedIndexChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.Controls.Add(this.lblMatchRuleset, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblTimeLimit, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblCountOut, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.lblPin, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.lblSubmission, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.lblTKO, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.lblRopeBreak, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.lblDQ, 0, 7);
			this.tableLayoutPanel2.Controls.Add(this.lblBlood, 0, 8);
			this.tableLayoutPanel2.Controls.Add(this.lblInterference, 0, 9);
			this.tableLayoutPanel2.Controls.Add(this.lblTagHelpTime, 0, 10);
			this.tableLayoutPanel2.Controls.Add(this.lblRoyalRumbleTimer, 0, 11);
			this.tableLayoutPanel2.Controls.Add(this.tbMatchRuleset, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbTimeLimit, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.tbCountOut, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.tbPin, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.tbSubmission, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.tbTKO, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.tbRopeBreak, 1, 6);
			this.tableLayoutPanel2.Controls.Add(this.tbDQ, 1, 7);
			this.tableLayoutPanel2.Controls.Add(this.tbBlood, 1, 8);
			this.tableLayoutPanel2.Controls.Add(this.tbInterference, 1, 9);
			this.tableLayoutPanel2.Controls.Add(this.tbTagHelpTime, 1, 10);
			this.tableLayoutPanel2.Controls.Add(this.tbRoyalRumbleTimer, 1, 11);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 12;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(417, 316);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// lblMatchRuleset
			// 
			this.lblMatchRuleset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMatchRuleset.AutoSize = true;
			this.lblMatchRuleset.Location = new System.Drawing.Point(3, 6);
			this.lblMatchRuleset.Name = "lblMatchRuleset";
			this.lblMatchRuleset.Size = new System.Drawing.Size(119, 13);
			this.lblMatchRuleset.TabIndex = 0;
			this.lblMatchRuleset.Text = "Match Ruleset";
			// 
			// lblTimeLimit
			// 
			this.lblTimeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTimeLimit.AutoSize = true;
			this.lblTimeLimit.Location = new System.Drawing.Point(3, 32);
			this.lblTimeLimit.Name = "lblTimeLimit";
			this.lblTimeLimit.Size = new System.Drawing.Size(119, 13);
			this.lblTimeLimit.TabIndex = 1;
			this.lblTimeLimit.Text = "Time Limit";
			// 
			// lblCountOut
			// 
			this.lblCountOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCountOut.AutoSize = true;
			this.lblCountOut.Location = new System.Drawing.Point(3, 58);
			this.lblCountOut.Name = "lblCountOut";
			this.lblCountOut.Size = new System.Drawing.Size(119, 13);
			this.lblCountOut.TabIndex = 2;
			this.lblCountOut.Text = "Count Out";
			// 
			// lblPin
			// 
			this.lblPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPin.AutoSize = true;
			this.lblPin.Location = new System.Drawing.Point(3, 84);
			this.lblPin.Name = "lblPin";
			this.lblPin.Size = new System.Drawing.Size(119, 13);
			this.lblPin.TabIndex = 3;
			this.lblPin.Text = "Pin";
			// 
			// lblSubmission
			// 
			this.lblSubmission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSubmission.AutoSize = true;
			this.lblSubmission.Location = new System.Drawing.Point(3, 110);
			this.lblSubmission.Name = "lblSubmission";
			this.lblSubmission.Size = new System.Drawing.Size(119, 13);
			this.lblSubmission.TabIndex = 4;
			this.lblSubmission.Text = "Submission";
			// 
			// lblTKO
			// 
			this.lblTKO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTKO.AutoSize = true;
			this.lblTKO.Location = new System.Drawing.Point(3, 136);
			this.lblTKO.Name = "lblTKO";
			this.lblTKO.Size = new System.Drawing.Size(119, 13);
			this.lblTKO.TabIndex = 5;
			this.lblTKO.Text = "TKO";
			// 
			// lblRopeBreak
			// 
			this.lblRopeBreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRopeBreak.AutoSize = true;
			this.lblRopeBreak.Location = new System.Drawing.Point(3, 162);
			this.lblRopeBreak.Name = "lblRopeBreak";
			this.lblRopeBreak.Size = new System.Drawing.Size(119, 13);
			this.lblRopeBreak.TabIndex = 6;
			this.lblRopeBreak.Text = "Rope Break";
			// 
			// lblDQ
			// 
			this.lblDQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDQ.AutoSize = true;
			this.lblDQ.Location = new System.Drawing.Point(3, 188);
			this.lblDQ.Name = "lblDQ";
			this.lblDQ.Size = new System.Drawing.Size(119, 13);
			this.lblDQ.TabIndex = 7;
			this.lblDQ.Text = "DQ";
			// 
			// lblBlood
			// 
			this.lblBlood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblBlood.AutoSize = true;
			this.lblBlood.Location = new System.Drawing.Point(3, 214);
			this.lblBlood.Name = "lblBlood";
			this.lblBlood.Size = new System.Drawing.Size(119, 13);
			this.lblBlood.TabIndex = 8;
			this.lblBlood.Text = "Blood";
			// 
			// lblInterference
			// 
			this.lblInterference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInterference.AutoSize = true;
			this.lblInterference.Location = new System.Drawing.Point(3, 240);
			this.lblInterference.Name = "lblInterference";
			this.lblInterference.Size = new System.Drawing.Size(119, 13);
			this.lblInterference.TabIndex = 9;
			this.lblInterference.Text = "Interference";
			// 
			// lblTagHelpTime
			// 
			this.lblTagHelpTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTagHelpTime.AutoSize = true;
			this.lblTagHelpTime.Location = new System.Drawing.Point(3, 266);
			this.lblTagHelpTime.Name = "lblTagHelpTime";
			this.lblTagHelpTime.Size = new System.Drawing.Size(119, 13);
			this.lblTagHelpTime.TabIndex = 10;
			this.lblTagHelpTime.Text = "Tag Help Time";
			// 
			// lblRoyalRumbleTimer
			// 
			this.lblRoyalRumbleTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRoyalRumbleTimer.AutoSize = true;
			this.lblRoyalRumbleTimer.Location = new System.Drawing.Point(3, 294);
			this.lblRoyalRumbleTimer.Name = "lblRoyalRumbleTimer";
			this.lblRoyalRumbleTimer.Size = new System.Drawing.Size(119, 13);
			this.lblRoyalRumbleTimer.TabIndex = 11;
			this.lblRoyalRumbleTimer.Text = "Royal Rumble Timer";
			// 
			// tbMatchRuleset
			// 
			this.tbMatchRuleset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbMatchRuleset.Location = new System.Drawing.Point(128, 3);
			this.tbMatchRuleset.Name = "tbMatchRuleset";
			this.tbMatchRuleset.ReadOnly = true;
			this.tbMatchRuleset.Size = new System.Drawing.Size(286, 20);
			this.tbMatchRuleset.TabIndex = 12;
			// 
			// tbTimeLimit
			// 
			this.tbTimeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTimeLimit.Location = new System.Drawing.Point(128, 29);
			this.tbTimeLimit.Name = "tbTimeLimit";
			this.tbTimeLimit.ReadOnly = true;
			this.tbTimeLimit.Size = new System.Drawing.Size(286, 20);
			this.tbTimeLimit.TabIndex = 13;
			// 
			// tbCountOut
			// 
			this.tbCountOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCountOut.Location = new System.Drawing.Point(128, 55);
			this.tbCountOut.Name = "tbCountOut";
			this.tbCountOut.ReadOnly = true;
			this.tbCountOut.Size = new System.Drawing.Size(286, 20);
			this.tbCountOut.TabIndex = 14;
			// 
			// tbPin
			// 
			this.tbPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPin.Location = new System.Drawing.Point(128, 81);
			this.tbPin.Name = "tbPin";
			this.tbPin.ReadOnly = true;
			this.tbPin.Size = new System.Drawing.Size(286, 20);
			this.tbPin.TabIndex = 15;
			// 
			// tbSubmission
			// 
			this.tbSubmission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSubmission.Location = new System.Drawing.Point(128, 107);
			this.tbSubmission.Name = "tbSubmission";
			this.tbSubmission.ReadOnly = true;
			this.tbSubmission.Size = new System.Drawing.Size(286, 20);
			this.tbSubmission.TabIndex = 16;
			// 
			// tbTKO
			// 
			this.tbTKO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTKO.Location = new System.Drawing.Point(128, 133);
			this.tbTKO.Name = "tbTKO";
			this.tbTKO.ReadOnly = true;
			this.tbTKO.Size = new System.Drawing.Size(286, 20);
			this.tbTKO.TabIndex = 17;
			// 
			// tbRopeBreak
			// 
			this.tbRopeBreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRopeBreak.Location = new System.Drawing.Point(128, 159);
			this.tbRopeBreak.Name = "tbRopeBreak";
			this.tbRopeBreak.ReadOnly = true;
			this.tbRopeBreak.Size = new System.Drawing.Size(286, 20);
			this.tbRopeBreak.TabIndex = 18;
			// 
			// tbDQ
			// 
			this.tbDQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDQ.Location = new System.Drawing.Point(128, 185);
			this.tbDQ.Name = "tbDQ";
			this.tbDQ.ReadOnly = true;
			this.tbDQ.Size = new System.Drawing.Size(286, 20);
			this.tbDQ.TabIndex = 19;
			// 
			// tbBlood
			// 
			this.tbBlood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBlood.Location = new System.Drawing.Point(128, 211);
			this.tbBlood.Name = "tbBlood";
			this.tbBlood.ReadOnly = true;
			this.tbBlood.Size = new System.Drawing.Size(286, 20);
			this.tbBlood.TabIndex = 20;
			// 
			// tbInterference
			// 
			this.tbInterference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInterference.Location = new System.Drawing.Point(128, 237);
			this.tbInterference.Name = "tbInterference";
			this.tbInterference.ReadOnly = true;
			this.tbInterference.Size = new System.Drawing.Size(286, 20);
			this.tbInterference.TabIndex = 21;
			// 
			// tbTagHelpTime
			// 
			this.tbTagHelpTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTagHelpTime.Location = new System.Drawing.Point(128, 263);
			this.tbTagHelpTime.Name = "tbTagHelpTime";
			this.tbTagHelpTime.ReadOnly = true;
			this.tbTagHelpTime.Size = new System.Drawing.Size(286, 20);
			this.tbTagHelpTime.TabIndex = 22;
			// 
			// tbRoyalRumbleTimer
			// 
			this.tbRoyalRumbleTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRoyalRumbleTimer.Location = new System.Drawing.Point(128, 291);
			this.tbRoyalRumbleTimer.Name = "tbRoyalRumbleTimer";
			this.tbRoyalRumbleTimer.ReadOnly = true;
			this.tbRoyalRumbleTimer.Size = new System.Drawing.Size(286, 20);
			this.tbRoyalRumbleTimer.TabIndex = 23;
			// 
			// Ruleset_NoMercy
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 281);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(480, 320);
			this.Name = "Ruleset_NoMercy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Match Rulesets";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblRulesetIndex;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbRulesets;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label lblMatchRuleset;
		private System.Windows.Forms.Label lblTimeLimit;
		private System.Windows.Forms.Label lblCountOut;
		private System.Windows.Forms.Label lblPin;
		private System.Windows.Forms.Label lblSubmission;
		private System.Windows.Forms.Label lblTKO;
		private System.Windows.Forms.Label lblRopeBreak;
		private System.Windows.Forms.Label lblDQ;
		private System.Windows.Forms.Label lblBlood;
		private System.Windows.Forms.Label lblInterference;
		private System.Windows.Forms.Label lblTagHelpTime;
		private System.Windows.Forms.Label lblRoyalRumbleTimer;
		private System.Windows.Forms.TextBox tbMatchRuleset;
		private System.Windows.Forms.TextBox tbTimeLimit;
		private System.Windows.Forms.TextBox tbCountOut;
		private System.Windows.Forms.TextBox tbPin;
		private System.Windows.Forms.TextBox tbSubmission;
		private System.Windows.Forms.TextBox tbTKO;
		private System.Windows.Forms.TextBox tbRopeBreak;
		private System.Windows.Forms.TextBox tbDQ;
		private System.Windows.Forms.TextBox tbBlood;
		private System.Windows.Forms.TextBox tbInterference;
		private System.Windows.Forms.TextBox tbTagHelpTime;
		private System.Windows.Forms.TextBox tbRoyalRumbleTimer;
	}
}