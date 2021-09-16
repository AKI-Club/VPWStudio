using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio.Editors.WM2K
{
	public partial class WrestlerMain_WM2K : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();

		private Dictionary<int, string> CustomHeightValues = new Dictionary<int, string>()
		{
			{ 0x24, "??? 1 (Short)"  },
			{ 0x25, "??? 2 (Medium)" },
			{ 0x26, "??? 3 (Tall)" }
		};

		public WrestlerMain_WM2K()
		{
			InitializeComponent();

			LoadDefs_Rom(); // temporary
			PopulateList(); // not so temporary
		}

		#region Load Wrestler Definitions
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
			for (int i = 0; i < 76; i++)
			{
				br.BaseStream.Seek(baseLocation + (i*4), SeekOrigin.Begin);
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

		private void LoadDefs_Project()
		{
			// load from project file
		}
		#endregion

		/// <summary>
		/// Populate the list of wrestler definitions
		/// </summary>
		private void PopulateList()
		{
			lbWrestlers.BeginUpdate();
			for (int i = 0; i < WrestlerDefs.Count; i++)
			{
				WrestlerDefinition wd = WrestlerDefs[i];
				lbWrestlers.Items.Add(String.Format("{0:X4} {1}", wd.WrestlerID4, NameHandler.DecodeName(wd.Name)[1]));
			}
			lbWrestlers.EndUpdate();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wdef"></param>
		private void LoadEntryData(WrestlerDefinition wdef)
		{
			tbWrestlerName.Text = wdef.Name;
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);

			if (CustomHeightValues.ContainsKey(wdef.Height))
			{
				tbHeight.Text = String.Format("0x{0:X2} ({1})", wdef.Height, CustomHeightValues[wdef.Height]);
			}
			else
			{
				// 0x00 = 5'0"; 0x0C = 6'0"; 0x18 = 7'0"; 0x23 = 7'11"
				int inches = wdef.Height % 12;
				int feet = (wdef.Height / 12) + 5;
				tbHeight.Text = String.Format("0x{0:X2} ({1}'{2}\")", wdef.Height, feet, inches);
			}

			if (wdef.Weight + 100 > 699)
			{
				tbWeight.Text = String.Format("0x{0:X2} ('???')", wdef.Weight);
			}
			else
			{
				tbWeight.Text = String.Format("0x{0:X2} ({1} lbs.)", wdef.Weight, wdef.Weight + 100);
			}
			cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			cbEntranceVideo.SelectedIndex = wdef.EntranceVideo;
			tbUnknown.Text = String.Format("0x{0:X4}", wdef.Unknown);
			tbMovesetIndex.Text = String.Format("{0:X4}", wdef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", wdef.ParamsFileIndex);
			tbCosPointer1.Text = String.Format("{0:X8}", wdef.CostumePointers[0]);
			tbCosPointer2.Text = String.Format("{0:X8}", wdef.CostumePointers[1]);
			tbCosPointer3.Text = String.Format("{0:X8}", wdef.CostumePointers[2]);
			tbCosPointer4.Text = String.Format("{0:X8}", wdef.CostumePointers[3]);
		}

		/// <summary>
		/// 
		/// </summary>
		private void lbWrestlers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			// load data
			LoadEntryData(WrestlerDefs[lbWrestlers.SelectedIndex]);
		}

		private void buttonMoveset_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			((MainForm)(MdiParent)).RequestHexViewer(WrestlerDefs[lbWrestlers.SelectedIndex].MovesetFileIndex);
		}

		private void buttonParams_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			((MainForm)(MdiParent)).RequestHexViewer(WrestlerDefs[lbWrestlers.SelectedIndex].ParamsFileIndex);
		}
	}
}
