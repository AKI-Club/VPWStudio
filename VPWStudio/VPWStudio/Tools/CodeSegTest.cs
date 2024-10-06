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

		/// <summary>
		/// Main segment BSS start address.
		/// </summary>
		public UInt32 MainSegBssStart = 0;

		/// <summary>
		/// Length of main segment BSS data.
		/// </summary>
		public UInt32 MainSegBssLength = 0;

		public CodeSegTest()
		{
			InitializeComponent();

			if (!DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations.ContainsKey("CodeSegDefs"))
			{
				// you shouldn't have been able to get in here anyways.
				return;
			}

			// todo: move romstream and romreader here

			// todo: load code segment defs properly
			/*
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry codeSegDefsEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["CodeSegDefs"]);
				int segCount = 0;
				if (codeSegDefsEntry != null)
				{
					//romStream.Seek(codeSegDefsEntry.Address, SeekOrigin.Begin);
					//segCount = (codeSegDefsEntry.Length / 36);
				}
				else
				{
					// fallback to hardcoded data
				}
			}
			else
			{
				Program.InfoMessageBox("Location data not found; using hardcoded offsets and lengths instead.");
				// fallback to hardcoded data
			}
			*/

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

					// xxx: cheeky hack to read BSS address and size
					if (Program.CurrentProject.Settings.BaseGame >= VPWGames.Revenge)
					{
						// Revenge and later

						// VPW2 example:
						/* 001000 80000400 3C088005 |  lui   $t0, % hi(0x8004B2A0) # $t0, 0x8005 */
						/* 001004 80000404 2508B2A0 |  addiu $t0, % lo(0x8004B2A0) # addiu $t0, $t0, -0x4d60 */
						/* 001008 80000408 3C090007 |  lui   $t1, % hi(0x06B050) # $t1, 7 */
						/* 00100C 8000040C 2529B050 |  addiu $t1, % lo(0x06B050) # addiu $t1, $t1, -0x4fb0 */

						// "8005B2A0" needs to become 0x8004B2A0
						romReader.BaseStream.Seek(0x1002, SeekOrigin.Begin);
						byte[] tmpH = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpH);
						}
						UInt16 addrH = BitConverter.ToUInt16(tmpH, 0);

						romReader.BaseStream.Seek(0x1006, SeekOrigin.Begin);
						byte[] tmpL = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpL);
						}
						UInt16 addrL = BitConverter.ToUInt16(tmpL, 0);
						if (addrL > 0x7FFF)
						{
							addrH -= 1;
						}
						MainSegBssStart = (UInt32)((addrH << 16) | (addrL));

						// "0007B050" needs to become 0x06B050
						romReader.BaseStream.Seek(0x100A, SeekOrigin.Begin);
						tmpH = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpH);
						}
						UInt16 sizeH = BitConverter.ToUInt16(tmpH, 0);

						romReader.BaseStream.Seek(0x100E, SeekOrigin.Begin);
						tmpL = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpL);
						}
						UInt16 sizeL = BitConverter.ToUInt16(tmpL, 0);
						if (sizeL > 0x7FFF)
						{
							sizeH -= 1;
						}
						MainSegBssLength = (UInt32)((sizeH << 16) | (sizeL));
					}
					else
					{
						// World Tour and VPW64

						// world tour NTSC-U v1.0 example
						// 001000 3C088004 | lui t0, 0x8004
						// 001004 3C090002 | lui t1, 2
						// 001008 250887F0 | addiu t0,t0,0x87f0
						// 00100C 352998A0 | ori t1, t1, 0x98A0
						// "800487F0" needs to become 0x800387F0
						// 0x298A0 does not need correction

						// vpw64 example
						// 001000 3C088005 | lui t0, 0x8005
						// 001004 3C090002 | lui t1, 2
						// 001008 2508A060 | addiu t0,t0,0xA060
						// 00100C 35298C60 | ori t1,t1, 0x8C60
						// "8005A060" needs to become 0x8004A060
						// 0x28C60 does not need correction

						// convert address
						romReader.BaseStream.Seek(0x1002, SeekOrigin.Begin);
						byte[] tmpH = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpH);
						}
						UInt16 addrH = BitConverter.ToUInt16(tmpH, 0);

						romReader.BaseStream.Seek(0x100A, SeekOrigin.Begin);
						byte[] tmpL = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpL);
						}
						UInt16 addrL = BitConverter.ToUInt16(tmpL, 0);
						if (addrL > 0x7FFF)
						{
							addrH -= 1;
						}
						MainSegBssStart = (UInt32)((addrH << 16) | (addrL));

						// convert size
						romReader.BaseStream.Seek(0x1006, SeekOrigin.Begin);
						tmpH = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpH);
						}
						UInt16 sizeH = BitConverter.ToUInt16(tmpH, 0);

						romReader.BaseStream.Seek(0x100E, SeekOrigin.Begin);
						tmpL = romReader.ReadBytes(2);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(tmpL);
						}
						// subtraction is not performed since the other part of the value is OR'd into place.
						// this bypasses whatever carry bit magic happens with ADDIU.
						MainSegBssLength = (UInt32)((sizeH << 16) | BitConverter.ToUInt16(tmpL, 0));
					}
				}
			}
			cbCodeSegs.EndUpdate();
			cbCodeSegs.SelectedIndex = 0;
			lblMainBssInfo.Text = String.Format("Main seg BSS at {0:X}; length 0x{1:X} (end addr {2:X})", MainSegBssStart, MainSegBssLength, MainSegBssStart+ MainSegBssLength);
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
				else if (inValue < CodeSegmentDefs[0].SegmentStart)
				{
					// any pointers before the first segment are in the global area.

					// check for main BSS region
					if (inValue >= MainSegBssStart && inValue <= MainSegBssStart+MainSegBssLength)
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
