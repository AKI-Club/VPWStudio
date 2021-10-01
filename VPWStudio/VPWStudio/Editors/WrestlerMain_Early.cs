using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors
{
	public partial class WrestlerMain_Early : Form
	{
		public SortedList<int, WrestlerDefinition_Early> WrestlerDefs = new SortedList<int, WrestlerDefinition_Early>();

		// Note: skips duplicate entries used for junior heavyweight roster
		private Dictionary<VPWGames, int> NumWrestlers = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 43 },
			{ VPWGames.VPW64, 99 }
		};

		public WrestlerMain_Early()
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

			// xxx: default number of wrestler defs
			for (int i = 0; i < NumWrestlers[Program.CurrentProject.Settings.BaseGame]; i++)
			{
				br.BaseStream.Seek(baseLocation + (i * 4), SeekOrigin.Begin);
				byte[] ptrBytes = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptrBytes);
				}
				UInt32 wPtr = Z64Rom.PointerToRom(BitConverter.ToUInt32(ptrBytes, 0));
				br.BaseStream.Seek(wPtr, SeekOrigin.Begin);
				WrestlerDefinition_Early wdef = new WrestlerDefinition_Early(br);
				WrestlerDefs.Add(i, wdef);
				//Program.CurrentProject.WrestlerDefs.Entries.Add(wdef);
			}

			br.Close();
		}

		private void LoadDefs_File(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs = wdf.WrestlerDefs_Early;

			// various strings are not stored in WrestlerDefs file, read them from ROM instead
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			foreach (KeyValuePair<int, WrestlerDefinition_Early> wdef in WrestlerDefs)
			{
				wdef.Value.Name = wdef.Value.GetName(br);
				wdef.Value.ProfileString = wdef.Value.GetProfileString(br);
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
				WrestlerDefinition_Early wd = WrestlerDefs[i];
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

			WrestlerDefinition_Early wdef = WrestlerDefs[lbWrestlers.SelectedIndex];

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
