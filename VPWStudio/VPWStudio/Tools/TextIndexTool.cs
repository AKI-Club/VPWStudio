using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VPWStudio.Editors;

namespace VPWStudio.Tools
{
	public struct TextValueRange
	{
		public ushort StartValue;
		public ushort EndValue;
		public ushort FileID;
		public string Description;

		public TextValueRange(ushort _start, ushort _end, ushort _fid, string _desc)
		{
			StartValue = _start;
			EndValue = _end;
			FileID = _fid;
			Description = _desc;
		}
	}

	public partial class TextIndexTool : Form
	{
		// This relies on rollover;
		// actual index = 0xFFFF0F41 + index value
		// (0xF0BF is index 0)
		// sltiu $v0, $v0, 0x136 # number of entries in global text table

		// runtime location 80105820 (when menus are loaded)
		public List<TextValueRange> TextRanges = new List<TextValueRange>()
		{
			new TextValueRange(0xF1F6, 0xF3AA, 0x0005, "edit mode"),
			new TextValueRange(0xF3AC, 0xF436, 0x0007, "result phrases"),
			new TextValueRange(0xF438, 0xF466, 0x0006, "unlock messages"),
			new TextValueRange(0xF468, 0xF492, 0x0008, "akitext 03"),
			new TextValueRange(0xF494, 0xF4A8, 0x0009, "akitext 04"),
			new TextValueRange(0xF4AA, 0xF4C9, 0x000A, "options help"),
			new TextValueRange(0xF4CB, 0xF4E6, 0x000B, "parameters help"),
			new TextValueRange(0xF4E8, 0xF539, 0x000D, "RRS bulletin board"),
			new TextValueRange(0xF53B, 0xF5A2, 0x000E, "credits"),
			new TextValueRange(0xF5A4, 0xF695, 0x000C, "akitext 07"),
		};

		protected int AkiTextFileID;
		protected int TargetIndex;

		public TextIndexTool()
		{
			InitializeComponent();
			AkiTextFileID = 0;
			TargetIndex = 0;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			// check input
			ushort inValue;
			if (ushort.TryParse(tbInputValue.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out inValue))
			{
				uint internalIndex = 0xFFFF0F41;
				uint outValue = (uint)(internalIndex + inValue);

				if (outValue < 0x136)
				{
					// global text
					lblRegionValue.Text = "Global Text";
					tbOutputValue.Text = String.Format("0x{0:X} ({0}; pointer at 0x{1:X})", outValue, 0x80105090+(outValue*4));
					btnLaunchTextEditor.Enabled = false;
				}
				else
				{
					// region depends on input value
					bool foundRegion = false;
					foreach (TextValueRange tvr in TextRanges)
					{
						if (inValue >= tvr.StartValue && inValue <= tvr.EndValue)
						{
							AkiTextFileID = tvr.FileID;
							TargetIndex = inValue - tvr.StartValue;
							lblRegionValue.Text = String.Format("File ID {0:X4} ({1})", tvr.FileID, tvr.Description);
							tbOutputValue.Text = String.Format("0x{0:X} ({0})", TargetIndex);
							foundRegion = true;
						}
					}

					if (Program.CurrentProject != null && Program.CurrentProject.Settings.BaseGame == VPWGames.VPW2)
					{
						btnLaunchTextEditor.Enabled = foundRegion;
					}
					else
					{
						// don't allow launching text editor without a project open
						btnLaunchTextEditor.Enabled = false;
					}

					if (!foundRegion)
					{
						lblRegionValue.Text = "unknown region";
					}
				}
			}
		}

		private void TextIndexTool_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void btnLaunchTextEditor_Click(object sender, EventArgs e)
		{
			// warning: doesn't save changes, lol oops :|
			AkiTextEditor ate = new AkiTextEditor(AkiTextFileID, TargetIndex);
			ate.ShowDialog();
		}
	}
}
