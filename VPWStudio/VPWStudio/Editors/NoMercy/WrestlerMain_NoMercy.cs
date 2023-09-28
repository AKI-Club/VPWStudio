using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.NoMercy;

namespace VPWStudio.Editors.NoMercy
{
	public partial class WrestlerMain_NoMercy : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();

		private AkiText DefaultNames;
		private AkiTextEditor ate;

		private const UInt16 NOMERCY_DEFAULT_COSTUME_FILE = 1;
		private const UInt16 NOMERCY_DEFAULT_NAMES_FILE = 2;

		private Dictionary<int, string> CustomHeightValues = new Dictionary<int, string>()
		{
			{ 0x24, "??"  },
			{ 0x25, "???" },
			{ 0x26, "!!!" },
			{ 0x27, "6'6\" (Crash Holly)" }
		};

		private Dictionary<int, string> CustomWeightValues = new Dictionary<int, string>()
		{
			{ 0x01F4, "?? (Light Heavy)" },
			{ 0x01F5, "??? (Heavy)" },
			{ 0x01F6, "!!! (Super Heavy)" },
			{ 0x01F7, "400 lbs. (Crash Holly)" },
		};

		public WrestlerMain_NoMercy()
		{
			InitializeComponent();

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.WrestlerDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.WrestlerDefinitionFilePath))
			)
			{
				// load stable definitions from external file
				LoadDefs_File(Program.CurrentProject.Settings.WrestlerDefinitionFilePath);
			}
			else
			{
				// load stable definitions from No Mercy ROM
				LoadDefs_Rom(romReader);
			}

			// wrestler names
			FileTableEntry defWrestlerNames = Program.CurrentProject.ProjectFileTable.Entries[NOMERCY_DEFAULT_NAMES_FILE];

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
		/// Load default names AkiText entry using a BinaryReader.
		/// </summary>
		/// <param name="romReader">BinaryReader instance to use.</param>
		private void LoadNames_ROM(BinaryReader romReader)
		{
			// default names are in file 0002
			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, NOMERCY_DEFAULT_NAMES_FILE);

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			DefaultNames = new AkiText(outReader);

			outReader.Close();
			outWriter.Close();
		}

		/// <summary>
		/// Load default names from an external AkiText file.
		/// </summary>
		/// <param name="_path">Path to AkiText file with wrestler names.</param>
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
				// depends on game
				long offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["WrestlerDefs"].Offset;
				br.BaseStream.Seek(offset, SeekOrigin.Begin);
			}

			for (int i = 0; i < (DefaultGameData.WrestlerCount[VPWGames.NoMercy] * 4) + 0x25; i++)
			{
				WrestlerDefinition wdef = new WrestlerDefinition(br);
				WrestlerDefs.Add(i, wdef);
			}
		}

		private void LoadDefs_File(string _path)
		{
			WrestlerDefFile wdf = new WrestlerDefFile(VPWGames.NoMercy);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			wdf.ReadFile(sr);
			sr.Close();
			WrestlerDefs = wdf.WrestlerDefs_NoMercy;
		}
		#endregion

		/// <summary>
		/// Populate the list of wrestler definitions.
		/// </summary>
		private void PopulateList()
		{
			lbWrestlers.Items.Clear();
			lbWrestlers.BeginUpdate();
			for (int i = 0; i < WrestlerDefs.Count; i++)
			{
				WrestlerDefinition wd = WrestlerDefs[i];
				if (wd.WrestlerID2 <= 0x40)
				{
					int costume = i % 4;
					lbWrestlers.Items.Add(String.Format("{0:X4}-{1} {2}", wd.WrestlerID4, costume, DefaultNames.Entries[wd.ProfileIndex + 1].Text));
				}
				else
				{
					lbWrestlers.Items.Add(String.Format("{0:X4}", wd.WrestlerID4));
				}
			}
			lbWrestlers.EndUpdate();
		}

		/// <summary>
		/// Show a wrestler's data in the form's controls.
		/// </summary>
		/// <param name="wdef">Wrestler to show data for.</param>
		private void LoadEntryData(WrestlerDefinition wdef)
		{
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			cbEntranceVideo.SelectedIndex = wdef.EntranceVideo;

			nudHeight.Value = wdef.Height;
			tbUnknown.Text = String.Format("0x{0:X2}", wdef.Unknown);
			nudWeight.Value = wdef.Weight;

			tbMovesetIndex.Text = String.Format("{0:X4}", wdef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", wdef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", wdef.AppearanceIndex);
			nudProfileIndex.Value = wdef.ProfileIndex;
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
		private void cbThemeMusic_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].ThemeSong = (byte)cbThemeMusic.SelectedIndex;
		}

		private void cbEntranceVideo_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].EntranceVideo = (byte)cbEntranceVideo.SelectedIndex;
		}

		private void nudHeight_ValueChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].Height = (byte)nudHeight.Value;
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
				return;
			}
		}

		private void nudWeight_ValueChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].Weight = (ushort)nudWeight.Value;
			if (CustomWeightValues.ContainsKey(WrestlerDefs[lbWrestlers.SelectedIndex].Weight))
			{
				labelWeightValue.Text = CustomWeightValues[WrestlerDefs[lbWrestlers.SelectedIndex].Weight];
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
				return;
			}
		}

		private void buttonMoveset_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			Program.AppMainForm.RequestHexViewer(this.WrestlerDefs[lbWrestlers.SelectedIndex].MovesetFileIndex);
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

			DefaultCostume_NoMercy dcEditor;
			FileTableEntry dCosEntry = Program.CurrentProject.ProjectFileTable.Entries[NOMERCY_DEFAULT_COSTUME_FILE];
			string dcosReplacePath = dCosEntry.ReplaceFilePath;

			if (!String.IsNullOrEmpty(dcosReplacePath))
			{
				dcEditor = new DefaultCostume_NoMercy(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex, Program.ConvertRelativePath(dcosReplacePath));
			}
			else
			{
				dcEditor = new DefaultCostume_NoMercy(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex);
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
							dcEditor.CostumeData.WriteData(bw);
						}
					}
				}
				else
				{
					// make new file for 1
					string filename = String.Format("{0}\\{1:X4}.bin", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), NOMERCY_DEFAULT_COSTUME_FILE);

					// step 1: get original data from ROM
					MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(ms);

					MemoryStream outStream = new MemoryStream();
					BinaryWriter outWriter = new BinaryWriter(outStream);

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, NOMERCY_DEFAULT_COSTUME_FILE);
					romReader.Close();

					// step 2: write updated data
					outStream.Seek(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex * DefaultCostumeData.COSTUME_DATA_LENGTH, SeekOrigin.Begin);
					dcEditor.CostumeData.WriteData(outWriter);
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
					Program.AppMainForm.UpdateTitleBar();
				}
			}
		}

		private void buttonProfile_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}
			int oldIndex = lbWrestlers.SelectedIndex;

			FileTableEntry defWrestlerNames = Program.CurrentProject.ProjectFileTable.Entries[NOMERCY_DEFAULT_NAMES_FILE];

			if (!String.IsNullOrEmpty(defWrestlerNames.ReplaceFilePath))
			{
				ate = new AkiTextEditor(Program.ConvertRelativePath(defWrestlerNames.ReplaceFilePath), (int)nudProfileIndex.Value);
			}
			else
			{
				// request AkiText viewer, index 2
				ate = new AkiTextEditor(NOMERCY_DEFAULT_NAMES_FILE, (int)nudProfileIndex.Value);
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
					string filename = String.Format("{0}\\{1:X4}.akitext", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), NOMERCY_DEFAULT_NAMES_FILE);
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
					Program.AppMainForm.UpdateTitleBar();
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
				lbWrestlers.SelectedIndex = oldIndex;
			}
			ate = null;
		}

		private void nudProfileIndex_ValueChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			WrestlerDefs[lbWrestlers.SelectedIndex].ProfileIndex = (ushort)nudProfileIndex.Value;
		}

		private void nudProfileIndex_Validating(object sender, CancelEventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				e.Cancel = true;
				return;
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
