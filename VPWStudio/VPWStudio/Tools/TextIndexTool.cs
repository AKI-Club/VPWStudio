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
		#region VPW2 Constants/Values
		// This relies on rollover;
		// actual index = 0xFFFF0F41 + index value
		private readonly uint VPW2_START_VALUE = 0xFFFF0F41;

		/// <summary>
		/// First value in VPW2 that will result in an index of 0.
		/// </summary>
		private readonly uint VPW2_FIRST_VALUE = 0xF0BF;

		/// <summary>
		/// Runtime location where VPW2's global text pointers start.
		/// </summary>
		private readonly uint VPW2_POINTERS_START_RUNTIME = 0x80105090;

		/// <summary>
		/// Number of entries in VPW2's global text table.
		/// </summary>
		private readonly int VPW2_MAX_GLOBALTEXT_ENTRIES = 0x136;

		// runtime location 80105820 (when menus are loaded)
		public readonly List<TextValueRange> TextRanges_VPW2 = new List<TextValueRange>()
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
		#endregion

		#region No Mercy Constants/Values
		// This relies on rollover;
		// actual index = 0xFFFF0F32 + index value
		private readonly uint NOMERCY_START_VALUE = 0xFFFF0F32;

		/// <summary>
		/// First value in No Mercy that will result in an index of 0.
		/// </summary>
		/// 0xF0CF is the first real entry
		private readonly uint NOMERCY_FIRST_VALUE = 0xF0CE;

		/// <summary>
		/// Runtime location where No Mercy's global text pointers start.
		/// </summary>
		/// xxx: NTSC-U v1.0 value!!
		private readonly uint NOMERCY_POINTERS_START_RUNTIME = 0x800F4790;

		/// <summary>
		/// Number of entries in No Mercy's global text table.
		/// </summary>
		private readonly int NOMERCY_MAX_GLOBALTEXT_ENTRIES = 0xFD;

		// runtime location 800F4E38 (when menus are loaded)
		// xxx: above comment is for NTSC-U v1.0 only
		public readonly List<TextValueRange> TextRanges_NoMercy = new List<TextValueRange>()
		{
			new TextValueRange(0xF1CC, 0xF50F, 0x0039, "vpw2 edit mode leftover"),
			new TextValueRange(0xF511, 0xF5C0, 0x0071, "credits"),
			new TextValueRange(0xF5C2, 0xF665, 0x4476, "various strings"),
			new TextValueRange(0xF667, 0xF68E, 0x4474, "match options text"),
			new TextValueRange(0xF690, 0xF69A, 0x4475, "mode instructions"),
			new TextValueRange(0xF69C, 0xF6AF, 0x01DC, "story main"),
			new TextValueRange(0xF6B1, 0xF7FD, 0x01DD, "story chapter titles"),
			new TextValueRange(0xF7FF, 0xF832, 0x01DE, "story world heavy match info"),
			new TextValueRange(0xF834, 0xF86B, 0x01DF, "story tag team match info"),
			new TextValueRange(0xF86D, 0xF8AF, 0x01E0, "story IC match info"),
			new TextValueRange(0xF8B1, 0xF8E1, 0x01E1, "story euro match info"),
			new TextValueRange(0xF8E3, 0xF91A, 0x01E2, "story hardcore match info"),
			new TextValueRange(0xF91C, 0xF934, 0x01E3, "story light heavy match info"),
			new TextValueRange(0xF936, 0xF949, 0x01E4, "story women's match info"),
			new TextValueRange(0xF94B, 0xF952, 0x01E5, "story GBC match info"),
		};
		#endregion

		#region WM2K Constants/Values
		// This relies on rollover;
		// actual index = 0xFFFF01A7 + index value
		private readonly uint WM2K_START_VALUE = 0xFFFF01A7;

		/// <summary>
		/// First value in WM2K that will result in an index of 0.
		/// </summary>
		private readonly uint WM2K_FIRST_VALUE = 0xFE59;

		/// <summary>
		/// Runtime location where WrestleMania 2000's global text pointers start, indexed by game type.
		/// </summary>
		public readonly Dictionary<SpecificGame, uint> RuntimePointers_WM2K = new Dictionary<SpecificGame, uint>()
		{
			{ SpecificGame.WM2K_NTSC_U, 0x800FFB88 },
			{ SpecificGame.WM2K_PAL,    0x800FFBA8 },
			{ SpecificGame.WM2K_NTSC_J, 0x800FABC8 },
		};

		/// <summary>
		/// Number of entries in WM2K's global text table.
		/// </summary>
		private readonly int WM2K_MAX_GLOBALTEXT_ENTRIES = 0x162;

		/*
		 * NTSC-U ROM loc 0x6A998
		 * PAL ROM loc    0x6A9B8
		 * NTSC-J ROM loc 0x650D8
		 */
		public readonly List<TextValueRange> TextRanges_WM2K = new List<TextValueRange>()
		{
			new TextValueRange(0x030A, 0x0413, 0x0004, "edit mode"),
			new TextValueRange(0x0415, 0x0450, 0x0005, "story mode"),
			new TextValueRange(0x0452, 0x04B4, 0x0006, "general strings"),
			new TextValueRange(0x04B6, 0x0548, 0x0007, "credits"),
		};
		#endregion

		protected int AkiTextFileID;

		protected int TargetIndex;

		public TextIndexTool()
		{
			InitializeComponent();
			AkiTextFileID = 0;
			TargetIndex = 0;

			if (Program.CurrentProject != null)
			{
				if (Program.CurrentProject.Settings.BaseGame >= VPWGames.WM2K)
				{
					rbVPW2.Enabled = false;
					rbNoMercy.Enabled = false;

					if (Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy)
					{
						lblNote.Text = String.Format("{0:X} is index 0.", NOMERCY_FIRST_VALUE);
					}
					else if (Program.CurrentProject.Settings.BaseGame == VPWGames.WM2K)
					{
						lblNote.Text = String.Format("{0:X} is index 0.", WM2K_FIRST_VALUE);
					}
				}
				else
				{
					// not currently supported; fallback to VPW2
					rbVPW2.Enabled = true;
					rbNoMercy.Enabled = true;
					rbVPW2.Checked = true;
				}
			}
			else
			{
				// no project open; fallback to vpw2
				rbVPW2.Enabled = true;
				rbNoMercy.Enabled = true;
				rbVPW2.Checked = true;
			}
		}

		/// <summary>
		/// Convert VPW2 text index values.
		/// </summary>
		/// <param name="inValue"></param>
		/// <returns>True if a valid region was found, false otherwise.</returns>
		protected bool ConvertVPW2(ushort inValue)
		{
			uint internalIndex = VPW2_START_VALUE;
			uint outValue = (uint)(internalIndex + inValue);

			if (outValue < VPW2_MAX_GLOBALTEXT_ENTRIES)
			{
				lblRegionValue.Text = "Global Text";
				tbOutputValue.Text = String.Format("0x{0:X} ({0}; pointer at 0x{1:X})", outValue, VPW2_POINTERS_START_RUNTIME + (outValue * 4));
				btnLaunchTextEditor.Enabled = false;
				return true;
			}
			else
			{
				foreach (TextValueRange tvr in TextRanges_VPW2)
				{
					if (inValue >= tvr.StartValue && inValue <= tvr.EndValue)
					{
						AkiTextFileID = tvr.FileID;
						TargetIndex = inValue - tvr.StartValue;
						lblRegionValue.Text = String.Format("File ID {0:X4} ({1})", tvr.FileID, tvr.Description);
						tbOutputValue.Text = String.Format("0x{0:X} ({0})", TargetIndex);
						btnLaunchTextEditor.Enabled = true;
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Convert No Mercy text index values.
		/// </summary>
		/// <param name="inValue"></param>
		/// <returns>True if a valid region was found, false otherwise.</returns>
		protected bool ConvertNoMercy(ushort inValue)
		{
			uint internalIndex = NOMERCY_START_VALUE;
			uint outValue = (uint)(internalIndex + inValue);

			if (outValue < NOMERCY_MAX_GLOBALTEXT_ENTRIES)
			{
				lblRegionValue.Text = "Global Text";
				tbOutputValue.Text = String.Format("0x{0:X} ({0}; pointer at 0x{1:X})", outValue, NOMERCY_POINTERS_START_RUNTIME + (outValue * 4));
				btnLaunchTextEditor.Enabled = false;
				return true;
			}
			else
			{
				foreach (TextValueRange tvr in TextRanges_NoMercy)
				{
					if (inValue >= tvr.StartValue && inValue <= tvr.EndValue)
					{
						AkiTextFileID = tvr.FileID;
						TargetIndex = inValue - tvr.StartValue;
						lblRegionValue.Text = String.Format("File ID {0:X4} ({1})", tvr.FileID, tvr.Description);
						tbOutputValue.Text = String.Format("0x{0:X} ({0})", TargetIndex);
						btnLaunchTextEditor.Enabled = true;
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Convert WM2K text index values.
		/// </summary>
		/// <param name="inValue"></param>
		/// <returns>True if a valid region was found, false otherwise.</returns>
		protected bool ConvertWM2K(ushort inValue, SpecificGame variant)
		{
			uint internalIndex = WM2K_START_VALUE;
			uint outValue = (uint)(internalIndex + inValue);

			if (outValue < WM2K_MAX_GLOBALTEXT_ENTRIES)
			{
				lblRegionValue.Text = "Global Text";
				tbOutputValue.Text = String.Format("0x{0:X} ({0}; pointer at {1:X})", outValue, RuntimePointers_WM2K[variant] + (outValue * 4));
				btnLaunchTextEditor.Enabled = false;
				return true;
			}
			else
			{
				foreach (TextValueRange tvr in TextRanges_WM2K)
				{
					if (inValue >= tvr.StartValue && inValue <= tvr.EndValue)
					{
						AkiTextFileID = tvr.FileID;
						TargetIndex = inValue - tvr.StartValue;
						lblRegionValue.Text = String.Format("File ID {0:X4} ({1})", tvr.FileID, tvr.Description);
						tbOutputValue.Text = String.Format("0x{0:X} ({0})", TargetIndex);
						btnLaunchTextEditor.Enabled = true;
						return true;
					}
				}
			}

			return false;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			// todo: split out code
			// check input
			ushort inValue;
			if (ushort.TryParse(tbInputValue.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out inValue))
			{
				if (Program.CurrentProject != null)
				{
					switch (Program.CurrentProject.Settings.BaseGame)
					{
						case VPWGames.WM2K:
							if (!ConvertWM2K(inValue, Program.CurrentProject.Settings.GameType))
							{
								lblRegionValue.Text = "unknown region";
							}
							break;

						case VPWGames.VPW2:
							if (!ConvertVPW2(inValue))
							{
								lblRegionValue.Text = "unknown region";
							}
							break;

						case VPWGames.NoMercy:
							if (!ConvertNoMercy(inValue))
							{
								lblRegionValue.Text = "unknown region";
							}
							break;

						default:
							// unsupported.
							break;
					}
				}
				else
				{
					// depends on radio buttons
					if (rbVPW2.Checked)
					{
						if (!ConvertVPW2(inValue))
						{
							lblRegionValue.Text = "unknown region";
						}
					}
					else if (rbNoMercy.Checked)
					{
						if (!ConvertNoMercy(inValue))
						{
							lblRegionValue.Text = "unknown region";
						}
					}
					else
					{
						// wait, how
						Program.ErrorMessageBox("wot");
					}

					btnLaunchTextEditor.Enabled = false;
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

		private void rbVPW2_CheckedChanged(object sender, EventArgs e)
		{
			if (rbVPW2.Checked)
			{
				lblNote.Text = String.Format("{0:X} is index 0.", VPW2_FIRST_VALUE);
			}
		}

		private void rbNoMercy_CheckedChanged(object sender, EventArgs e)
		{
			if (rbNoMercy.Checked)
			{
				lblNote.Text = String.Format("{0:X} is index 0.", NOMERCY_FIRST_VALUE);
			}
		}
	}
}
