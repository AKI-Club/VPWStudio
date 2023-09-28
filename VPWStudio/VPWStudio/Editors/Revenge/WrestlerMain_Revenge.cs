using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.Revenge;

namespace VPWStudio.Editors.Revenge
{
	public partial class WrestlerMain_Revenge : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();
		public WrestlerMain_Revenge()
		{
			InitializeComponent();

			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.WrestlerDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath))
			)
			{
				// load stable definitions from external file
				LoadDefs_File(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
			}
			else
			{
				// load stable definitions from Revenge ROM
				LoadDefs_Rom();
			}

			PopulateList();
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

			for (int i = 0; i < DefaultGameData.WrestlerCount[VPWGames.Revenge]; i++)
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
			}

			br.Close();
		}

		private void LoadDefs_File(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.Revenge);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs = wdf.WrestlerDefs_Revenge;

			// various strings are not stored in WrestlerDefs file, read them from ROM instead
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			foreach (KeyValuePair<int, WrestlerDefinition> wdef in WrestlerDefs)
			{
				wdef.Value.Name = wdef.Value.GetName(br);
				wdef.Value.HeightString = wdef.Value.GetHeightString(br);
				wdef.Value.WeightString = wdef.Value.GetWeightString(br);
			}

			br.Close();
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
				lbWrestlers.Items.Add(String.Format("{0:X4}", wd.WrestlerID4));
			}
			lbWrestlers.EndUpdate();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wdef"></param>
		private void LoadEntryData(WrestlerDefinition wdef)
		{
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			tbUnknown1.Text = String.Format("{0:X2}", wdef.Unknown1);
			tbUnknown2.Text = String.Format("{0:X4}", wdef.Unknown2);
			tbUnknown3.Text = String.Format("{0:X4}", wdef.Unknown3);

			tbWrestlerNamePointer.Text = String.Format("{0:X8}", wdef.NamePointer);
			tbWrestlerName.Text = wdef.Name;

			tbHeightPointer.Text = String.Format("{0:X8}", wdef.HeightPointer);
			tbWrestlerHeight.Text = wdef.HeightString;

			tbWeightPointer.Text = String.Format("{0:X8}", wdef.WeightPointer);
			tbWrestlerWeight.Text = wdef.WeightString;

			tbUnknown4.Text = String.Format("{0:X2}", wdef.Unknown4);
			tbManagerID2.Text = String.Format("{0:X2}", wdef.ManagerID2);
			tbUnknown5.Text = String.Format("{0:X2}", wdef.Unknown5);
			tbUnknown6.Text = String.Format("{0:X2}", wdef.Unknown6);
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

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
