using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW64;

namespace VPWStudio.Editors.VPW64
{
	public partial class WrestlerMain_VPW64 : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();

		public WrestlerMain_VPW64()
		{
			InitializeComponent();
			LoadDefs_Rom();
			PopulateList();
		}

		private void LoadDefs_Rom()
		{
			// load from rom
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			int baseLocation = -1;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry wdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["WrestlerDefs"]);
				if (wdEntry != null)
				{
					baseLocation = (int)wdEntry.Address;
					br.BaseStream.Seek(baseLocation, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Wrestler Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["WrestlerDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			// xxx2: skips duplicate entries used for junior heavyweight roster
			for (int i = 0; i < 99; i++)
			{
				br.BaseStream.Seek(baseLocation + (i * 4), SeekOrigin.Begin);
				byte[] ptrBytes = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptrBytes);
				}
				UInt32 wPtr = Z64Rom.PointerToRom(BitConverter.ToUInt32(ptrBytes, 0));
				br.BaseStream.Seek(wPtr, SeekOrigin.Begin);
				WrestlerDefinition wdef = new WrestlerDefinition(br);
				WrestlerDefs.Add(i, wdef);
				//Program.CurrentProject.WrestlerDefs.Entries.Add(wdef);
			}

			br.Close();
		}

		/// <summary>
		/// Populate the list of wrestler definitions
		/// </summary>
		private void PopulateList()
		{
			lbWrestlers.BeginUpdate();
			for (int i = 0; i < WrestlerDefs.Count; i++)
			{
				WrestlerDefinition wd = WrestlerDefs[i];
				lbWrestlers.Items.Add(String.Format("{0:X4}", wd.WrestlerID4));
			}
			lbWrestlers.EndUpdate();
		}

		private void lbWrestlers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefinition wdef = WrestlerDefs[lbWrestlers.SelectedIndex];

			tbUnknown1.Text = String.Format("{0:X4}", wdef.Unknown1);
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			tbFlags1.Text = String.Format("{0:X2}", wdef.Flags1);
			tbUnknown2.Text = String.Format("{0:X4}", wdef.Unknown2);

			// pointers and jointers
			tbNamePointer.Text = String.Format("{0:X8}", wdef.NamePointer);
			tbProfilePointer.Text = String.Format("{0:X8}", wdef.ProfilePointer);
			tbHeightPointer.Text = String.Format("{0:X8}", wdef.HeightPointer);
			tbWeightPointer.Text = String.Format("{0:X8}", wdef.WeightPointer);

			// then read the actual text from ROM
			Encoding euc = Encoding.GetEncoding("EUC-JP");
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms, euc);

			ms.Seek(Z64Rom.PointerToRom(wdef.NamePointer), SeekOrigin.Begin);
			List<byte> wName = new List<byte>();
			while (br.PeekChar() != 0)
			{
				wName.Add(br.ReadByte());
			}
			tbNameString.Text = euc.GetString(wName.ToArray());

			ms.Seek(Z64Rom.PointerToRom(wdef.ProfilePointer), SeekOrigin.Begin);
			List<byte> profile = new List<byte>();
			while (br.PeekChar() != 0)
			{
				profile.Add(br.ReadByte());
			}
			string profileText = euc.GetString(profile.ToArray());
			profileText = profileText.Replace("\n","\r\n");
			tbProfileText.Text = profileText;

			ms.Seek(Z64Rom.PointerToRom(wdef.HeightPointer), SeekOrigin.Begin);
			List<byte> wHeight = new List<byte>();
			while (br.PeekChar() != 0)
			{
				wHeight.Add(br.ReadByte());
			}
			tbHeightString.Text = euc.GetString(wHeight.ToArray());

			ms.Seek(Z64Rom.PointerToRom(wdef.WeightPointer), SeekOrigin.Begin);
			List<byte> wWeight = new List<byte>();
			while (br.PeekChar() != 0)
			{
				wWeight.Add(br.ReadByte());
			}
			tbWeightString.Text = euc.GetString(wWeight.ToArray());

			br.Close();
		}
	}
}
