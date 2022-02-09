using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio
{
	// warning: this is very hacky

	/// <summary>
	/// Dialog for selecting a wrestler based on ID2 or ID4 values.
	/// </summary>
	public partial class SelectWrestlerDialog : Form
	{
		public enum WrestlerIDMode
		{
			ID2 = 0,
			ID4
		}

		public WrestlerIDMode Mode;

		#region Game-Specific stuff
		// Note: skips duplicate entries used for junior heavyweight roster
		private Dictionary<VPWGames, int> NumWrestlers = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 43 },
			{ VPWGames.VPW64, 99 }
		};

		public SortedList<int, WrestlerDefinition_Early> WrestlerDefs_Early = new SortedList<int, WrestlerDefinition_Early>();

		public SortedList<int, GameSpecific.Revenge.WrestlerDefinition> WrestlerDefs_Revenge = new SortedList<int, GameSpecific.Revenge.WrestlerDefinition>();

		public SortedList<int, GameSpecific.WM2K.WrestlerDefinition> WrestlerDefs_WM2K = new SortedList<int, GameSpecific.WM2K.WrestlerDefinition>();

		public SortedList<int, GameSpecific.VPW2.WrestlerDefinition> WrestlerDefs_VPW2 = new SortedList<int, GameSpecific.VPW2.WrestlerDefinition>();

		public SortedList<int, GameSpecific.NoMercy.WrestlerDefinition> WrestlerDefs_NoMercy = new SortedList<int, GameSpecific.NoMercy.WrestlerDefinition>();

		/// <summary>
		/// Used for wrestler names in VPW2 and No Mercy.
		/// </summary>
		private AkiText DefaultNames;
		#endregion

		public int ReturnID = -1;

		public SelectWrestlerDialog(WrestlerIDMode _mode)
		{
			InitializeComponent();
			Mode = _mode;
			Text += (Mode == WrestlerIDMode.ID2) ? " (ID2)" : " (ID4)";
			LoadWrestlers();
			PopulateWrestlerList();
			cbWrestlers.SelectedIndex = 0;
		}

		private void LoadWrestlers()
		{
			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.WrestlerDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath)))
			{
				// load wrestlers from wrestler definition file
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour:
					case VPWGames.VPW64:
						LoadWrestlerDef_Early(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath));
						break;

					case VPWGames.Revenge:
						LoadWrestlerDef_Revenge(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath));
						break;

					case VPWGames.WM2K:
						LoadWrestlerDef_WM2K(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath));
						break;

					case VPWGames.VPW2:
						LoadWrestlerDef_VPW2(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath));
						break;

					case VPWGames.NoMercy:
						LoadWrestlerDef_NoMercy(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath));
						break;
				}
			}
			else
			{
				// load wrestlers from ROM
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour:
					case VPWGames.VPW64:
						LoadWrestlersRom_Early(); break;

					case VPWGames.Revenge: LoadWrestlersRom_Revenge(); break;

					case VPWGames.WM2K: LoadWrestlersRom_WM2K(); break;

					case VPWGames.VPW2: LoadWrestlersRom_VPW2(); break;

					case VPWGames.NoMercy: LoadWrestlersRom_NoMercy(); break;
				}
			}

			// for games with AkiText, load wrestler names
			if (Program.CurrentProject.Settings.BaseGame == VPWGames.VPW2 || Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy)
			{
				LoadWrestlerNames();
			}
		}

		private void LoadWrestlerNames()
		{
			//DefaultNames
			int nameFileID = DefaultGameData.DefaultFileTableIDs["DefaultNameData"][Program.CurrentProject.Settings.GameType];
			FileTableEntry fte = Program.CurrentProject.ProjectFileTable.Entries[nameFileID];
			if (!String.IsNullOrEmpty(fte.ReplaceFilePath))
			{
				FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				DefaultNames = new AkiText(br);
				br.Close();
			}
			else
			{
				MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
				BinaryReader romReader = new BinaryReader(romStream);

				MemoryStream outStream = new MemoryStream();
				BinaryWriter outWriter = new BinaryWriter(outStream);

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, nameFileID);

				outStream.Seek(0, SeekOrigin.Begin);
				BinaryReader outReader = new BinaryReader(outStream);
				DefaultNames = new AkiText(outReader);

				outReader.Close();
				outWriter.Close();

				romReader.Close();
			}
		}

		#region Load Wrestlers from ROM
		private void LoadWrestlersRom_Early()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms, Encoding.GetEncoding("EUC-JP"));

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
				WrestlerDefs_Early.Add(i, wdef);
			}

			br.Close();
		}

		private void LoadWrestlersRom_Revenge()
		{
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
			for (int i = 0; i < 90; i++)
			{
				br.BaseStream.Seek(baseLocation + (i * 4), SeekOrigin.Begin);
				byte[] ptrBytes = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptrBytes);
				}
				UInt32 wPtr = Z64Rom.PointerToRom(BitConverter.ToUInt32(ptrBytes, 0));
				br.BaseStream.Seek(wPtr, SeekOrigin.Begin);
				GameSpecific.Revenge.WrestlerDefinition wdef = new GameSpecific.Revenge.WrestlerDefinition(br);
				WrestlerDefs_Revenge.Add(i, wdef);
			}

			br.Close();
		}

		private void LoadWrestlersRom_WM2K()
		{
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
				br.BaseStream.Seek(baseLocation + (i * 4), SeekOrigin.Begin);
				byte[] ptrBytes = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptrBytes);
				}
				UInt32 wPtr = Z64Rom.PointerToRom(BitConverter.ToUInt32(ptrBytes, 0));
				br.BaseStream.Seek(wPtr, SeekOrigin.Begin);
				GameSpecific.WM2K.WrestlerDefinition wdef = new GameSpecific.WM2K.WrestlerDefinition(br);
				WrestlerDefs_WM2K.Add(i, wdef);
			}

			br.Close();
		}

		private void LoadWrestlersRom_VPW2()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			// load from rom
			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry wdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["WrestlerDefs"]);
				if (wdEntry != null)
				{
					br.BaseStream.Seek(wdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Wrestler Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StableDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			for (int i = 0; i < 0x82; i++)
			{
				GameSpecific.VPW2.WrestlerDefinition wdef = new GameSpecific.VPW2.WrestlerDefinition(br);
				WrestlerDefs_VPW2.Add(i, wdef);
			}
		}

		private void LoadWrestlersRom_NoMercy()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry wdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["WrestlerDefs"]);
				if (wdEntry != null)
				{
					br.BaseStream.Seek(wdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Wrestler Definition location not found; using hardcoded offset instead.");
				// depends on game
				long offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["WrestlerDefs"].Offset;
				br.BaseStream.Seek(offset, SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			for (int i = 0; i < (0x40 * 4) + 0x25; i++)
			{
				GameSpecific.NoMercy.WrestlerDefinition wdef = new GameSpecific.NoMercy.WrestlerDefinition(br);
				WrestlerDefs_NoMercy.Add(i, wdef);
			}
		}
		#endregion

		#region Load Wrestlers from Wrestler Definition File
		private void LoadWrestlerDef_Early(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(Program.CurrentProject.Settings.BaseGame);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs_Early = wdf.WrestlerDefs_Early;

			// various strings are not stored in WrestlerDefs file, read them from ROM instead
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			foreach (KeyValuePair<int, WrestlerDefinition_Early> wdef in WrestlerDefs_Early)
			{
				wdef.Value.Name = wdef.Value.GetName(br);
				wdef.Value.ProfileString = wdef.Value.GetProfileString(br);
				wdef.Value.HeightString = wdef.Value.GetHeightString(br);
				wdef.Value.WeightString = wdef.Value.GetWeightString(br);
			}

			br.Close();
		}

		private void LoadWrestlerDef_Revenge(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.Revenge);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs_Revenge = wdf.WrestlerDefs_Revenge;

			// various strings are not stored in WrestlerDefs file, read them from ROM instead
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			foreach (KeyValuePair<int, GameSpecific.Revenge.WrestlerDefinition> wdef in WrestlerDefs_Revenge)
			{
				wdef.Value.Name = wdef.Value.GetName(br);
				wdef.Value.HeightString = wdef.Value.GetHeightString(br);
				wdef.Value.WeightString = wdef.Value.GetWeightString(br);
			}

			br.Close();
		}

		private void LoadWrestlerDef_WM2K(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.WM2K);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs_WM2K = wdf.WrestlerDefs_WM2K;

			// wrestler names are not stored in WrestlerDefs file, read them from ROM instead
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			foreach (KeyValuePair<int, GameSpecific.WM2K.WrestlerDefinition> wdef in WrestlerDefs_WM2K)
			{
				wdef.Value.Name = wdef.Value.GetName(br);
			}

			br.Close();
		}

		private void LoadWrestlerDef_VPW2(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.VPW2);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs_VPW2 = wdf.WrestlerDefs_VPW2;
		}

		private void LoadWrestlerDef_NoMercy(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.NoMercy);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs_NoMercy = wdf.WrestlerDefs_NoMercy;
		}
		#endregion

		private void PopulateWrestlerList()
		{
			cbWrestlers.BeginUpdate();
			if (Mode == WrestlerIDMode.ID4)
			{
				// ID4
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour:
					case VPWGames.VPW64:
						{
							foreach (KeyValuePair<int, WrestlerDefinition_Early> wdef in WrestlerDefs_Early)
							{
								cbWrestlers.Items.Add(string.Format("{0:X4} {1}", wdef.Value.WrestlerID4, NameHandler.DecodeName(wdef.Value.Name)[0]));
							}
						}
						break;

					case VPWGames.Revenge:
						{
							foreach (KeyValuePair<int, GameSpecific.Revenge.WrestlerDefinition> wdef in WrestlerDefs_Revenge)
							{
								cbWrestlers.Items.Add(string.Format("{0:X4} {1}", wdef.Value.WrestlerID4, NameHandler.DecodeName(wdef.Value.Name)[0]));
							}
						}
						break;

					case VPWGames.WM2K:
						{
							foreach (KeyValuePair<int, GameSpecific.WM2K.WrestlerDefinition> wdef in WrestlerDefs_WM2K)
							{
								cbWrestlers.Items.Add(string.Format("{0:X4} {1}", wdef.Value.WrestlerID4, wdef.Value.Name));
							}
						}
						break;

					case VPWGames.VPW2:
						{
							foreach (KeyValuePair<int, GameSpecific.VPW2.WrestlerDefinition> wdef in WrestlerDefs_VPW2)
							{
								cbWrestlers.Items.Add(string.Format("{0:X4} {1}", wdef.Value.WrestlerID4, DefaultNames.Entries[wdef.Value.ProfileIndex].Text));
							}
						}
						break;

					case VPWGames.NoMercy:
						{
							foreach (KeyValuePair<int, GameSpecific.NoMercy.WrestlerDefinition> wdef in WrestlerDefs_NoMercy)
							{
								if (wdef.Value.WrestlerID2 <= 0x40)
								{
									if (wdef.Key % 4 == 0)
									{
										cbWrestlers.Items.Add(string.Format("{0:X4} {1}", wdef.Value.WrestlerID4, DefaultNames.Entries[wdef.Value.ProfileIndex].Text));
									}
								}
								else
								{
									cbWrestlers.Items.Add(string.Format("{0:X4} (ID2 0x{1:X2})", wdef.Value.WrestlerID4, wdef.Value.WrestlerID2));
								}
							}
						}
						break;
				}
			}
			else
			{
				// ID2
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour:
					case VPWGames.VPW64:
						{
							foreach (KeyValuePair<int, WrestlerDefinition_Early> wdef in WrestlerDefs_Early)
							{
								cbWrestlers.Items.Add(string.Format("{0:X2} {1}", wdef.Value.WrestlerID2, NameHandler.DecodeName(wdef.Value.Name)[0]));
							}
						}
						break;

					case VPWGames.Revenge:
						{
							foreach (KeyValuePair<int, GameSpecific.Revenge.WrestlerDefinition> wdef in WrestlerDefs_Revenge)
							{
								cbWrestlers.Items.Add(string.Format("{0:X2} {1}", wdef.Value.WrestlerID2, NameHandler.DecodeName(wdef.Value.Name)[0]));
							}
						}
						break;

					case VPWGames.WM2K:
						{
							foreach (KeyValuePair<int, GameSpecific.WM2K.WrestlerDefinition> wdef in WrestlerDefs_WM2K)
							{
								cbWrestlers.Items.Add(string.Format("{0:X2} {1}", wdef.Value.WrestlerID2, wdef.Value.Name));
							}
						}
						break;

					case VPWGames.VPW2:
						{
							foreach (KeyValuePair<int, GameSpecific.VPW2.WrestlerDefinition> wdef in WrestlerDefs_VPW2)
							{
								cbWrestlers.Items.Add(string.Format("{0:X2} {1}", wdef.Value.WrestlerID2, DefaultNames.Entries[wdef.Value.ProfileIndex].Text));
							}
						}
						break;

					case VPWGames.NoMercy:
						{
							foreach (KeyValuePair<int, GameSpecific.NoMercy.WrestlerDefinition> wdef in WrestlerDefs_NoMercy)
							{
								if (wdef.Value.WrestlerID2 <= 0x40)
								{
									if (wdef.Key % 4 == 0)
									{
										cbWrestlers.Items.Add(string.Format("{0:X2} {1}", wdef.Value.WrestlerID2, DefaultNames.Entries[wdef.Value.ProfileIndex].Text));
									}
								}
								else
								{
									cbWrestlers.Items.Add(string.Format("{0:X2} (ID4 0x{1:X4})", wdef.Value.WrestlerID2, wdef.Value.WrestlerID4));
								}
							}
						}
						break;
				}
			}
			cbWrestlers.EndUpdate();
		}

		private int GetSelectedID()
		{
			return int.Parse(cbWrestlers.Items[cbWrestlers.SelectedIndex].ToString().Substring(0, Mode == WrestlerIDMode.ID2 ? 2 : 4), NumberStyles.HexNumber);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			ReturnID = GetSelectedID();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
