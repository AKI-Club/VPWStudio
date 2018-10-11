using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	public partial class WrestlerMain_VPW2 : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();

		private AkiText DefaultNames;

		private const UInt16 VPW2_DEFAULT_COSTUME_FILE = 0x006B;
		private const UInt16 VPW2_DEFAULT_NAMES_FILE = 0x006C;

		public WrestlerMain_VPW2()
		{
			InitializeComponent();

			FileTableEntry defWrestlerNames = Program.CurrentProject.ProjectFileTable.Entries[VPW2_DEFAULT_NAMES_FILE];

			if (defWrestlerNames.ReplaceFilePath != null && defWrestlerNames.ReplaceFilePath != String.Empty)
			{
				LoadNames_File(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath));
			}
			else
			{
				LoadNames_ROM();
			}

			LoadDefs_Rom(); // temporary
			PopulateList();
		}

		/// <summary>
		/// Load default names AkiText entry
		/// </summary>
		private void LoadNames_ROM()
		{
			// default names are in file 006C
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, VPW2_DEFAULT_NAMES_FILE);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			DefaultNames = new AkiText(outReader);

			outReader.Close();
			outWriter.Close();
		}

		private void LoadNames_File(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			DefaultNames = new AkiText(br);
			br.Close();
		}

		#region Load Wrestler Definitions
		private void LoadDefs_Rom()
		{
			// load from rom
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
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StableDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			for (int i = 0; i < 0x82; i++)
			{
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
				// profile index + 1 = short name entry
				lbWrestlers.Items.Add(String.Format("{0:X4} {1}", wd.WrestlerID4, DefaultNames.Entries[wd.ProfileIndex+1].Text));
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
			cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			cbNameCall.SelectedIndex = wdef.NameCall;

			// todo: handle "???" strings/values; 3 for height (small/medium/large), 1 for weight
			tbHeight.Text = String.Format("0x{0:X2} ({1}cm)", wdef.Height, wdef.Height + 150);
			tbWeight.Text = String.Format("0x{0:X2} ({1}kg)", wdef.Weight, wdef.Weight + 70);

			cbVoiceA.SelectedIndex = wdef.Voice1;
			cbVoiceB.SelectedIndex = wdef.Voice2;
			tbMovesetIndex.Text = String.Format("{0:X4}", wdef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", wdef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", wdef.AppearanceIndex);
			tbProfileIndex.Text = String.Format("{0:X4}", wdef.ProfileIndex);
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

		private void buttonAppearance_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			DefaultCostume_VPW2 dcEditor;
			FileTableEntry dCosEntry = Program.CurrentProject.ProjectFileTable.Entries[VPW2_DEFAULT_COSTUME_FILE];
			string dcosReplacePath = dCosEntry.ReplaceFilePath;

			if (dcosReplacePath != null && dcosReplacePath != String.Empty)
			{
				dcEditor = new DefaultCostume_VPW2(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex, Program.ConvertRelativePath(dcosReplacePath));
			}
			else
			{
				dcEditor = new DefaultCostume_VPW2(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex);
			}

			if (dcEditor.ShowDialog() == DialogResult.OK)
			{
				if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
				{
					// we need to have saved in order to actually... save.
					Program.ErrorMessageBox("Can not save default costume changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
					return;
				}

				if (dCosEntry.HasReplacementFile())
				{
					// use existing file.
					using (FileStream fs = new FileStream(Program.ConvertRelativePath(dCosEntry.ReplaceFilePath), FileMode.Open))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							fs.Seek(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex * DefaultCostumeData.COSTUME_DATA_LENGTH, SeekOrigin.Begin);
							for (int i = 0; i < dcEditor.Costumes.Length; i++)
							{
								dcEditor.Costumes[i].WriteData(bw);
							}
						}
					}
				}
				else
				{
					// make new file for 0x006B
					string filename = String.Format("{0}\\{1:X4}.bin", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), VPW2_DEFAULT_COSTUME_FILE);

					// step 1: get original data from ROM
					MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(ms);

					MemoryStream outStream = new MemoryStream();
					BinaryWriter outWriter = new BinaryWriter(outStream);

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, VPW2_DEFAULT_COSTUME_FILE);
					romReader.Close();

					// step 2: write updated data
					outStream.Seek(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex * DefaultCostumeData.COSTUME_DATA_LENGTH, SeekOrigin.Begin);
					for (int i = 0; i < dcEditor.Costumes.Length; i++)
					{
						dcEditor.Costumes[i].WriteData(outWriter);
					}
					outStream.Seek(0, SeekOrigin.Begin);

					// step 3: write to file
					using (FileStream fs = new FileStream(filename, FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							bw.Write(outStream.ToArray());
						}
					}
					outStream.Close();

					// step 4: set ReplaceFilePath
					dCosEntry.ReplaceFilePath = Program.ShortenAbsolutePath(filename);
					Program.InfoMessageBox(String.Format("Wrote new Default Costume Data file to {0}.", filename));

					Program.UnsavedChanges = true;
					((MainForm)MdiParent).UpdateTitleBar();
				}
			}
		}

		private void buttonProfile_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			FileTableEntry defWrestlerNames = Program.CurrentProject.ProjectFileTable.Entries[VPW2_DEFAULT_NAMES_FILE];
			AkiTextEditor ate;

			if (defWrestlerNames.ReplaceFilePath != null && defWrestlerNames.ReplaceFilePath != String.Empty)
			{
				ate = new AkiTextEditor(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath), WrestlerDefs[lbWrestlers.SelectedIndex].ProfileIndex);
			}
			else
			{
				// request AkiText viewer, index 0x006C
				ate = new AkiTextEditor(VPW2_DEFAULT_NAMES_FILE, WrestlerDefs[lbWrestlers.SelectedIndex].ProfileIndex);
			}

			if (ate.ShowDialog() == DialogResult.OK)
			{
				// check to see if this file existed...
			}
		}

	}
}
