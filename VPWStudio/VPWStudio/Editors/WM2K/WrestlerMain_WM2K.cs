using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Globalization;
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

			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.WrestlerDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath))
			)
			{
				// load stable definitions from external file
				LoadDefs_File(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
			}
			else
			{
				// load stable definitions from WM2K ROM
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
			}

			br.Close();
		}

		private void LoadDefs_File(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.WM2K);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs = wdf.WrestlerDefs_WM2K;
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
			tbNamePointer.Text = String.Format("{0:X8}", wdef.NamePointer);
			tbWrestlerName.Text = wdef.Name;
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			nudHeight.Value = wdef.Height;
			nudWeight.Value = wdef.Weight;
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

		#region Wrestler Definition Value Editors
		private void nudHeight_ValueChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].Height = (ushort)nudHeight.Value;
			if (CustomHeightValues.ContainsKey(WrestlerDefs[lbWrestlers.SelectedIndex].Height))
			{
				labelHeightValue.Text = CustomHeightValues[WrestlerDefs[lbWrestlers.SelectedIndex].Height];
			}
			else
			{
				// 0x00 = 5'0"; 0x0C = 6'0"; 0x18 = 7'0"; 0x23 = 7'11"
				int inches = WrestlerDefs[lbWrestlers.SelectedIndex].Height % 12;
				int feet = (WrestlerDefs[lbWrestlers.SelectedIndex].Height / 12) + 5;
				labelHeightValue.Text = String.Format("{0}'{1}\"", feet, inches);
			}
		}

		private void nudHeight_Validating(object sender, CancelEventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				e.Cancel = true;
			}
		}

		private void nudWeight_ValueChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].Weight = (ushort)nudWeight.Value;
			if (WrestlerDefs[lbWrestlers.SelectedIndex].Weight + 100 > 699)
			{
				labelWeightValue.Text = "???";
			}
			else
			{
				labelWeightValue.Text = String.Format("{0} lbs.", WrestlerDefs[lbWrestlers.SelectedIndex].Weight + 100);
			}
		}

		private void nudWeight_Validating(object sender, CancelEventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				e.Cancel = true;
			}
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

		private void cbThemeMusic_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].ThemeSong = (byte)cbThemeMusic.SelectedIndex;
		}

		private void cbEntranceVideo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].EntranceVideo = (byte)cbEntranceVideo.SelectedIndex;
		}

		private void LoadCostumeEditor(int buttonNum)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			string pointerText;
			switch (buttonNum)
			{
				case 1: pointerText = tbCosPointer1.Text; break;
				case 2: pointerText = tbCosPointer2.Text; break;
				case 3: pointerText = tbCosPointer3.Text; break;
				case 4: pointerText = tbCosPointer4.Text; break;
				default:
					Program.ErrorMessageBox(String.Format("Hang on a minute, how did you pass button number {0}? There's no code to handle that.",buttonNum));
					return;
			}
			uint pointerValue = uint.Parse(pointerText, NumberStyles.HexNumber);
			DefaultCostume_WM2K dcEditor = new DefaultCostume_WM2K(pointerValue);
			if (dcEditor.ShowDialog() == DialogResult.OK)
			{
				Program.ErrorMessageBox("Nothing gets written back yet, sorry.");
			}
		}

		private void buttonCostume1_Click(object sender, EventArgs e)
		{
			LoadCostumeEditor(1);
		}

		private void buttonCostume2_Click(object sender, EventArgs e)
		{
			LoadCostumeEditor(2);
		}

		private void buttonCostume3_Click(object sender, EventArgs e)
		{
			LoadCostumeEditor(3);
		}

		private void buttonCostume4_Click(object sender, EventArgs e)
		{
			LoadCostumeEditor(4);
		}
		#endregion
	}
}
