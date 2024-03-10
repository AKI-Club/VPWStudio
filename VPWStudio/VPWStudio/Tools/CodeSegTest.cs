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
		public List<CodeSegDef> CodeSegmentDefs = new List<CodeSegDef>();

		public CodeSegTest()
		{
			InitializeComponent();

			if (!DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations.ContainsKey("CodeSegDefs"))
			{
				// you shouldn't have been able to get in here anyways.
				return;
			}

			// todo: load code segment defs properly
			cbCodeSegs.BeginUpdate();
			using (MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data))
			{
				using (BinaryReader romReader = new BinaryReader(romStream))
				{
					// use built-in values until I add them to the LocationFiles
					int segCount = (int)(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["CodeSegDefs"].Length / 36);
					romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["CodeSegDefs"].Offset, SeekOrigin.Begin);
					for (int i = 0; i < segCount; i++)
					{
						CodeSegmentDefs.Add(new CodeSegDef(romReader));
						cbCodeSegs.Items.Add(String.Format("Code Segment {0}",i));
					}
				}
			}
			cbCodeSegs.EndUpdate();
			cbCodeSegs.SelectedIndex = 0;
		}

		private void cbCodeSegs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbCodeSegs.SelectedIndex < 0)
			{
				return;
			}

			tbCodeSegInfo.Clear();
			CodeSegDef curSeg = CodeSegmentDefs[cbCodeSegs.SelectedIndex];
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(String.Format("ROM start address:              0x{0:X}", curSeg.SegmentRomStart));
			sb.AppendLine(String.Format("ROM end address:                0x{0:X}", curSeg.SegmentRomEnd));
			sb.AppendLine(String.Format("Segment RAM start address:      0x{0:X}", curSeg.SegmentStart));
			sb.AppendLine(String.Format("Segment RAM code start address: 0x{0:X}", curSeg.SegmentTextStart));
			sb.AppendLine(String.Format("Segment RAM code end address:   0x{0:X}", curSeg.SegmentTextEnd));
			sb.AppendLine(String.Format("Segment RAM data start address: 0x{0:X}", curSeg.SegmentDataStart));
			sb.AppendLine(String.Format("Segment RAM data end address:   0x{0:X}", curSeg.SegmentDataEnd));
			sb.AppendLine(String.Format("Segment BSS vars start address: 0x{0:X}", curSeg.SegmentBssStart));
			sb.Append(String.Format("Segment BSS vars end address:   0x{0:X}", curSeg.SegmentBssEnd));
			tbCodeSegInfo.Text = sb.ToString();
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

			CodeSegDef curSeg = CodeSegmentDefs[cbCodeSegs.SelectedIndex];

			UInt32 offset = inValue - curSeg.SegmentTextStart;
			tbPtrOut.Text = String.Format("{0:X}", curSeg.SegmentRomStart+offset);
		}
	}
}
