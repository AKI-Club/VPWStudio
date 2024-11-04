using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class CodeSegTest : Form
	{
		private StringBuilder SegInfoStrBuilder;

		public CodeSegTest()
		{
			InitializeComponent();

			if (!DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations.ContainsKey("CodeSegDefs"))
			{
				// you shouldn't have been able to get in here anyways.
				return;
			}

			SegInfoStrBuilder = new StringBuilder();
			cbCodeSegs.BeginUpdate();
			for (int i = 0; i < Program.CurrentCodeSegDefs.Count; i++)
			{
				cbCodeSegs.Items.Add(String.Format("Code Segment {0}", i));
			}
			cbCodeSegs.EndUpdate();
			cbCodeSegs.SelectedIndex = 0;
			lblMainBssInfo.Text = String.Format("Main seg BSS at {0:X}; length 0x{1:X} (end addr {2:X})", Program.MainSegBssStart, Program.MainSegBssLength, Program.MainSegBssStart + Program.MainSegBssLength);
		}

		private void cbCodeSegs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbCodeSegs.SelectedIndex < 0)
			{
				return;
			}

			tbCodeSegInfo.Clear();
			CodeSegDef curSeg = Program.CurrentCodeSegDefs[cbCodeSegs.SelectedIndex];
			SegInfoStrBuilder.Clear();
			SegInfoStrBuilder.AppendLine(String.Format("ROM start address:              0x{0:X}", curSeg.SegmentRomStart));
			SegInfoStrBuilder.AppendLine(String.Format("ROM end address:                0x{0:X}", curSeg.SegmentRomEnd));
			SegInfoStrBuilder.AppendLine(String.Format("Segment RAM start address:      0x{0:X}", curSeg.SegmentStart));
			SegInfoStrBuilder.AppendLine(String.Format("Segment RAM code start address: 0x{0:X}", curSeg.SegmentTextStart));
			SegInfoStrBuilder.AppendLine(String.Format("Segment RAM code end address:   0x{0:X}", curSeg.SegmentTextEnd));
			SegInfoStrBuilder.AppendLine(String.Format("Segment RAM data start address: 0x{0:X}", curSeg.SegmentDataStart));
			SegInfoStrBuilder.AppendLine(String.Format("Segment RAM data end address:   0x{0:X}", curSeg.SegmentDataEnd));
			SegInfoStrBuilder.AppendLine(String.Format("Segment BSS vars start address: 0x{0:X}", curSeg.SegmentBssStart));
			SegInfoStrBuilder.Append(String.Format("Segment BSS vars end address:   0x{0:X}", curSeg.SegmentBssEnd));
			tbCodeSegInfo.Text = SegInfoStrBuilder.ToString();
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			if (cbCodeSegs.SelectedIndex < 0)
			{
				return;
			}

			if (tbPtrIn.Text.Equals(String.Empty))
			{
				return;
			}

			UInt32 inValue = 0;
			if (!UInt32.TryParse(tbPtrIn.Text, NumberStyles.HexNumber, null, out inValue))
			{
				return;
			}

			CodeSegDef curSeg = Program.CurrentCodeSegDefs[cbCodeSegs.SelectedIndex];

			// todo: checks here need to be a bit smarter
			// - anything within a BSS segment has no inherent ROM address
			// - check if pointer is in active segment; if not, it may be a part of the always-loaded segment

			if (inValue >= curSeg.SegmentBssStart && inValue <= curSeg.SegmentBssEnd)
			{
				// defines in BSS have no inherent ROM address
				tbPtrOut.Text = "(BSS; no ROM address)";
			}
			else
			{
				if (curSeg.IsAddressInSeg(inValue))
				{
					// pointer is within the currently selected segment
					UInt32 offset = inValue - curSeg.SegmentTextStart;
					tbPtrOut.Text = String.Format("{0:X}", curSeg.SegmentRomStart + offset);
				}
				else if (inValue < Program.CurrentCodeSegDefs[0].SegmentStart)
				{
					// any pointers before the first segment are in the global area.

					// check for main BSS region
					if (inValue >= Program.MainSegBssStart && inValue <= Program.MainSegBssStart + Program.MainSegBssLength)
					{
						tbPtrOut.Text = "(main BSS; no ROM address)";
					}
					else
					{
						tbPtrOut.Text = String.Format("{0:X}", Z64Rom.PointerToRom(inValue));
					}
				}
				else
				{
					// this pointer is in a different code segment than the one selected
					// pointer values can also clash between segments
					tbPtrOut.Text = "(not in cur segment)";
				}
			}
		}
	}
}
