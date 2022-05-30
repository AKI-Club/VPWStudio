using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	public partial class WrestlerMain_VPW2 : Form
	{
		// height in edit mode 802B5635 (range 0x96-0xFD) (250cm max displayed + three "???")
		// weight in edit mode 802B56BC (range 0x0046-0x012D) (300kg max displayed + one "???")

		// height: 0x64 is the last valid value (250cm); 0x65-0x67 are the three "???" values.
		// weight: 0xE6 is the last valid value (300kg); 0xE7 is the "???" value.

		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();

		private AkiText DefaultNames;

		private const UInt16 VPW2_DEFAULT_COSTUME_FILE = 0x006B;
		private const UInt16 VPW2_DEFAULT_NAMES_FILE = 0x006C;

		public WrestlerMain_VPW2()
		{
			InitializeComponent();

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.WrestlerDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath))
			){
				// load stable definitions from external file
				LoadDefs_File(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
			}
			else
			{
				// load stable definitions from VPW2 ROM
				LoadDefs_Rom(romReader);
			}

			// wrestler names
			FileTableEntry defWrestlerNames = Program.CurrentProject.ProjectFileTable.Entries[VPW2_DEFAULT_NAMES_FILE];

			if (!String.IsNullOrEmpty(defWrestlerNames.ReplaceFilePath))
			{
				LoadNames_File(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath));
			}
			else
			{
				LoadNames_ROM(romReader);
			}
			romReader.Close();

			PopulateList();
		}

		#region Load Wrestler Names
		/// <summary>
		/// Load default names AkiText entry
		/// </summary>
		private void LoadNames_ROM(BinaryReader romReader)
		{
			// default names are in file 006C
			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, VPW2_DEFAULT_NAMES_FILE);

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
		#endregion

		#region Load Wrestler Definitions
		private void LoadDefs_Rom(BinaryReader br)
		{
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
				WrestlerDefinition wdef = new WrestlerDefinition(br);
				WrestlerDefs.Add(i, wdef);
			}
		}

		private void LoadDefs_File(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.VPW2);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs = wdf.WrestlerDefs_VPW2;
		}
		#endregion

		/// <summary>
		/// Populate the list of wrestler definitions
		/// </summary>
		private void PopulateList()
		{
			lbWrestlers.Items.Clear();
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
		/// Load data for the selected wrestler.
		/// </summary>
		/// <param name="wdef">Wrestler data to read from.</param>
		private void LoadEntryData(WrestlerDefinition wdef)
		{
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			cbNameCall.SelectedIndex = wdef.NameCall;
			nudHeight.Value = wdef.Height;
			nudWeight.Value = wdef.Weight;
			cbVoiceA.SelectedIndex = wdef.Voice1;
			cbVoiceB.SelectedIndex = wdef.Voice2;
			tbMovesetIndex.Text = String.Format("{0:X4}", wdef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", wdef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", wdef.AppearanceIndex);
			nudProfileIndex.Value = wdef.ProfileIndex;

			// hacky crap for wrestlers who are 70kg
			if (wdef.Weight == 0)
			{
				nudWeight_ValueChanged(this, null);
			}
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
		private void cbThemeMusic_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].ThemeSong = (byte)cbThemeMusic.SelectedIndex;
		}

		private void cbNameCall_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].NameCall = (byte)cbNameCall.SelectedIndex;
		}

		private void nudHeight_ValueChanged(object sender, EventArgs e)
		{
			int height = (int)nudHeight.Value;
			if (height > 100)
			{
				labelHeightValue.Text = String.Format("??? {0}", height - 100);
			}
			else
			{
				labelHeightValue.Text = String.Format("{0}cm", height + 150);
			}
			WrestlerDefs[lbWrestlers.SelectedIndex].Height = (byte)nudHeight.Value;
		}

		private void nudHeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				e.Cancel = true;
			}
		}

		private void nudWeight_ValueChanged(object sender, EventArgs e)
		{
			int weight = (int)nudWeight.Value;
			if (weight > 230)
			{
				labelWeightValue.Text = "???";
			}
			else
			{
				labelWeightValue.Text = String.Format("{0}kg", weight + 70);
			}
			WrestlerDefs[lbWrestlers.SelectedIndex].Weight = (byte)nudWeight.Value;
		}

		private void nudWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				e.Cancel = true;
			}
		}

		private void cbVoiceA_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].Voice1 = (byte)cbVoiceA.SelectedIndex;
		}

		private void cbVoiceB_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].Voice2 = (byte)cbVoiceB.SelectedIndex;
		}

		private void buttonMoveset_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			Program.AppMainForm.RequestHexViewer(WrestlerDefs[lbWrestlers.SelectedIndex].MovesetFileIndex);
		}

		private void buttonParams_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			Program.AppMainForm.RequestHexViewer(WrestlerDefs[lbWrestlers.SelectedIndex].ParamsFileIndex);
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

			if (!String.IsNullOrEmpty(dcosReplacePath))
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

		private void nudProfileIndex_ValueChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].ProfileIndex = (ushort)nudProfileIndex.Value;
		}

		private void nudProfileIndex_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
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

			if (!String.IsNullOrEmpty(defWrestlerNames.ReplaceFilePath))
			{
				ate = new AkiTextEditor(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath), (ushort)nudProfileIndex.Value);
			}
			else
			{
				// request AkiText viewer, index 0x006C
				ate = new AkiTextEditor(VPW2_DEFAULT_NAMES_FILE, (ushort)nudProfileIndex.Value);
			}

			if (ate.ShowDialog() == DialogResult.OK)
			{
				if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
				{
					// we need to have saved in order to actually... save.
					Program.ErrorMessageBox("Can not save AkiText changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
					return;
				}

				if (defWrestlerNames.ReplaceFilePath == null || defWrestlerNames.ReplaceFilePath == String.Empty)
				{
					// editing for the first time (make new file)
					string filename = String.Format("{0}\\{1:X4}.akitext", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), VPW2_DEFAULT_NAMES_FILE);
					using (FileStream fs = new FileStream(filename, FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							ate.CurTextArchive.WriteData(bw);
						}
					}

					// set new ReplaceFilePath
					defWrestlerNames.ReplaceFilePath = Program.ShortenAbsolutePath(filename);
					Program.InfoMessageBox(String.Format("Wrote new AkiText archive to {0}.", filename));

					Program.UnsavedChanges = true;
					((MainForm)(MdiParent)).UpdateTitleBar();
				}
				else if (Path.GetExtension(defWrestlerNames.ReplaceFilePath) == ".akitext")
				{
					// akitext binary in ReplaceFilePath (overwrite existing file)
					using (FileStream fs = new FileStream(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath), FileMode.Open))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							ate.CurTextArchive.WriteData(bw);
						}
					}
				}

				// might want to update the list to show the updated names too
				DefaultNames.DeepCopy(ate.CurTextArchive);
				PopulateList();
			}
		}
		#endregion

		private void buttonRefreshList_Click(object sender, EventArgs e)
		{
			int oldIndex = lbWrestlers.SelectedIndex;
			PopulateList();
			lbWrestlers.SelectedIndex = oldIndex;
		}
	}
}
