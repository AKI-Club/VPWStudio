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
using VPWStudio.GameSpecific;

namespace VPWStudio
{
	public partial class FileTableDialog : Form
	{
		#region Column constants
		// update these any time you update a new column, which is hopefully never!!!
		private const int FILE_ID_COLUMN = 0;
		private const int LOCATION_COLUMN = 1;
		private const int ROM_ADDR_COLUMN = 2;
		private const int FILE_TYPE_COLUMN = 3;
		private const int LZSS_COLUMN = 4;
		private const int COMMENT_COLUMN = 5;
		#endregion

		public FileTableDialog(int focusEntry = 0)
		{
			InitializeComponent();
			SetupSetTypeMenu();

			if (Program.CurrentProject != null)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries.Count == 0)
				{
					// project filetable was not created.
					Program.InfoMessageBox(SharedStrings.FileTableDialog_AttemptRomTableBuild);
					MakeFileTableFromRom();

					Program.UnsavedChanges = true;

					// this is hacky as fuck but it's the only way I know how to do it without crashing.
					(Application.OpenForms["MainForm"] as MainForm).UpdateTitleBar();
				}
				UpdateEntryList();

				// check to see if a specific file was requested, and scroll to it if so.
				if (focusEntry != 0)
				{
					ListViewItem requestedFile = lvFileList.FindItemWithText(String.Format("{0:X4}", focusEntry), true, 0);
					lvFileList.FocusedItem = requestedFile;
					lvFileList.EnsureVisible(requestedFile.Index);
				}
			}
		}

		/// <summary>
		/// Icons for each filetype
		/// </summary>
		private Dictionary<FileTypes, Image> FileTypeIcons = new Dictionary<FileTypes, Image>()
		{
			{ FileTypes.AkiArchive, Properties.Resources.FileType_AkiArchive },
			{ FileTypes.AkiLargeFont, Properties.Resources.FileType_AkiLargeFont },
			{ FileTypes.AkiModel, Properties.Resources.FileType_AkiModel },
			{ FileTypes.AkiSmallFont, Properties.Resources.FileType_AkiSmallFont },
			{ FileTypes.AkiText, Properties.Resources.FileType_AkiText },
			{ FileTypes.AkiTexture, Properties.Resources.FileType_AkiTexture },
			{ FileTypes.Binary, Properties.Resources.FileType_Binary },
			{ FileTypes.Ci4Palette, Properties.Resources.FileType_Ci4Palette },
			{ FileTypes.Ci4Texture, Properties.Resources.FileType_Ci4Texture },
			{ FileTypes.Ci8Palette, Properties.Resources.FileType_Ci8Palette },
			{ FileTypes.Ci8Texture, Properties.Resources.FileType_Ci8Texture },
			{ FileTypes.DoubleTex, Properties.Resources.FileType_DoubleTex },
			{ FileTypes.I4Texture, Properties.Resources.FileType_I4Texture },
			{ FileTypes.MenuBackground, Properties.Resources.FileType_MenuBackground },
		};

		/// <summary>
		/// Create the "Set Type" menu sub-items.
		/// </summary>
		private void SetupSetTypeMenu()
		{
			SortedList<FileTypes, ToolStripMenuItem> types = new SortedList<FileTypes, ToolStripMenuItem>();
			for (int i = 0; i < Enum.GetValues(typeof(FileTypes)).Length; i++)
			{
				FileTypes curType = (FileTypes)i;

				#region Per-Game Hacks
				// AkiText is only available in WM2K and later
				if (curType == FileTypes.AkiText && Program.CurrentProject.Settings.BaseGame < VPWGames.WM2K)
				{
					continue;
				}

				// NoMercyText is only available in No Mercy (<sarcasm>really???? you think?!</sarcasm>)
				if (curType == FileTypes.NoMercyText && Program.CurrentProject.Settings.BaseGame != VPWGames.NoMercy)
				{
					continue;
				}
				#endregion

				ToolStripMenuItem tsmi = new ToolStripMenuItem()
				{
					Name = String.Format("SetType{0}", curType),
					Tag = curType.ToString(),
					Text = curType.ToString(),
				};
				tsmi.Click += new EventHandler(SetTypeItemHandler);
				if (FileTypeIcons.ContainsKey(curType))
				{
					tsmi.Image = FileTypeIcons[curType];
				}
				types.Add(curType, tsmi);
			}
			foreach (KeyValuePair<FileTypes, ToolStripMenuItem> entry in types)
			{
				setTypeToolStripMenuItem.DropDownItems.Add(entry.Value);
			}
		}

		/// <summary>
		/// Load FileTable from current input ROM and assign the result to the ProjectFile.
		/// </summary>
		private void MakeFileTableFromRom()
		{
			Program.CurrentProject.ProjectFileTable = new FileTable();
			bool hasLocation = false;
			bool hasLength = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry ftEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["FileTable"]);
				if (ftEntry != null)
				{
					Program.CurrentProject.CreateProjectFileTable(ftEntry.Address, ftEntry.Length);
					Program.CurrentProject.ProjectFileTable.Location = ftEntry.Address;
					hasLocation = true;
					hasLength = true;
				}
			}
			if (!hasLocation || !hasLength)
			{
				// fallback to hardcoded offset and length.
				Program.InfoMessageBox(SharedStrings.FileTableDialog_UsingHardcodedValues);

				uint offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FileTable"].Offset;
				uint length = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FileTable"].Length;

				if (offset != 0 && length != 0)
				{
					Program.CurrentProject.CreateProjectFileTable(offset, (int)length);
					Program.CurrentProject.ProjectFileTable.Location = offset;
				}
			}
			LoadFileTableDB();
		}

		/// <summary>
		/// Load the file table database.
		/// </summary>
		private void LoadFileTableDB()
		{
			// read relevant file from FileTableDB
			FileTableDB ftdb;

			string dbFilePath = Program.GetFileTableDBPath();
			// make sure it exists before we go and start adding things
			if (!File.Exists(dbFilePath))
			{
				// well you've gone and beefed it now.
				MessageBox.Show(
					"Unable to find the requested FileTable Database in the 'FileTableDB' directory.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			else
			{
				ftdb = new FileTableDB(dbFilePath);
				foreach (KeyValuePair<UInt16, FileTableDBEntry> entry in ftdb.Entries)
				{
					Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].FileType = entry.Value.FileType;
					Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].Comment = entry.Value.Comment;
				}
			}
		}

		/// <summary>
		/// Reload the FileTableDB.
		/// </summary>
		private void ReloadFileTableDB()
		{
			// this one is tricky because we don't want to kill any comments that were entered in the program.
			string dbFilePath = Program.GetFileTableDBPath();

			if (!File.Exists(dbFilePath))
			{
				// well you've gone and beefed it now.
				MessageBox.Show(
					"Unable to find the requested FileTable Database in the 'FileTableDB' directory.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			else
			{
				bool changesMade = false;
				FileTableDB ftdb = new FileTableDB(dbFilePath);

				bool replaceComments = false;
				if (MessageBox.Show("Do you want to overwrite your comments with comments from the FileTable Database?", SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					replaceComments = true;
				}

				foreach (KeyValuePair<UInt16, FileTableDBEntry> entry in ftdb.Entries)
				{
					if (Program.CurrentProject.ProjectFileTable.Entries.ContainsKey(entry.Value.FileID))
					{
						// only replace filetype if it doesn't match current
						if (Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].FileType != entry.Value.FileType)
						{
							Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].FileType = entry.Value.FileType;
							changesMade = true;
						}

						// only replace comment if it's empty, or we were requested to.
						if (Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].Comment == String.Empty || replaceComments == true)
						{
							Program.CurrentProject.ProjectFileTable.Entries[entry.Value.FileID].Comment = entry.Value.Comment;
							changesMade = true;
						}
					}
				}

				if (changesMade)
				{
					Program.UnsavedChanges = true;
					((MainForm)(MdiParent)).UpdateTitleBar();
				}
			}
		}

		/// <summary>
		/// Update the ListView with the file table entries.
		/// </summary>
		private void UpdateEntryList()
		{
			uint offset = 0;
			bool hasOffset = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry ffEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["FirstFile"]);
				if (ffEntry != null)
				{
					offset = ffEntry.Address;
					hasOffset = true;
				}
			}
			if (!hasOffset)
			{
				offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["FirstFile"].Offset;
			}
			Program.CurrentProject.ProjectFileTable.FirstFile = offset;

			lvFileList.Items.Clear();
			lvFileList.BeginUpdate();
			int i = 0;
			foreach (KeyValuePair<int, FileTableEntry> fte in Program.CurrentProject.ProjectFileTable.Entries)
			{
				ListViewItem lvi = new ListViewItem(new string[] {
					String.Format("{0:X4}",fte.Value.FileID),
					String.Format("{0:X8}",fte.Value.Location),
					String.Format("{0:X8}",fte.Value.Location + offset),
					fte.Value.FileType.ToString(),
					fte.Value.IsEncoded.ToString(),
					fte.Value.Comment
				});
				lvi.UseItemStyleForSubItems = false;
				Color rowColor = (i % 2 == 0) ? Color.White : Color.FromArgb(240, 240, 240);
				foreach (ListViewItem.ListViewSubItem subitem in lvi.SubItems)
				{
					subitem.BackColor = rowColor;
				}

				Font regular = new Font(FontFamily.GenericSansSerif, 8.25f);
				Font mono = new Font(FontFamily.GenericMonospace, 10.0f);
				lvi.SubItems[FILE_ID_COLUMN].Font = mono;
				lvi.SubItems[LOCATION_COLUMN].Font = mono;
				lvi.SubItems[ROM_ADDR_COLUMN].Font = mono;
				lvi.SubItems[FILE_TYPE_COLUMN].Font = regular;
				lvi.SubItems[LZSS_COLUMN].Font = regular;
				lvi.SubItems[COMMENT_COLUMN].Font = regular;
				lvFileList.Items.Add(lvi);

				i++;
			}
			lvFileList.EndUpdate();
		}

		#region Context Menu
		/// <summary>
		/// Modify the context menu
		/// </summary>
		private void cmsFileEntry_Opening(object sender, CancelEventArgs e)
		{
			if (lvFileList.SelectedItems.Count > 1)
			{
				extractFileToolStripMenuItem.Text = SharedStrings.FileTableDialog_ExtractFiles;
			}
			else if (lvFileList.SelectedItems.Count == 1)
			{
				extractFileToolStripMenuItem.Text = SharedStrings.FileTableDialog_ExtractFile;

				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				extractRawToolStripMenuItem.Enabled = Program.CurrentProject.ProjectFileTable.Entries[key].IsEncoded;
			}
		}

		/// <summary>
		/// Change the item type of the selected item(s).
		/// </summary>
		private void SetTypeItemHandler(object sender, EventArgs e)
		{
			// don't do this without a selection
			if (lvFileList.SelectedItems.Count == 0)
			{
				return;
			}

			ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
			if (tsmi != null)
			{
				FileTypes targetType = (FileTypes)Enum.Parse(typeof(FileTypes), tsmi.Tag.ToString());
				lvFileList.BeginUpdate();
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					Program.CurrentProject.ProjectFileTable.Entries[key].FileType = targetType;
					lvFileList.SelectedItems[i].SubItems[FILE_TYPE_COLUMN].Text = targetType.ToString();
				}
				lvFileList.EndUpdate();
				Program.UnsavedChanges = true;
				((MainForm)(MdiParent)).UpdateTitleBar();
			}
		}

		/// <summary>
		/// Call the hex viewer
		/// </summary>
		private void viewHexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// easy
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				((MainForm)this.MdiParent).RequestHexViewer(key);
			}
			else
			{
				// hard, since RequestHexViewer only allows for one dialog.
				Program.ErrorMessageBox("multi select sucks, i haven't handled it yet");
				return;
			}
		}

		/// <summary>
		/// Edit the information of the selected FileTable entry/entries.
		/// </summary>
		private void editInformationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				LoadEditInfoDialog();
			}
			else
			{
				Program.ErrorMessageBox("multi select sucks, i haven't handled it yet");
				return;
			}
		}

		/// <summary>
		/// Extract the selected FileTable entry/entries.
		/// </summary>
		private void extractFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				Program.ErrorMessageBox("Please select at least one item to extract.");
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// only one file; no need to go through rigmarole
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Extract File";
				sfd.Filter = SharedStrings.FileFilter_None;

				// generate filename
				string fileExt = ".bin";
				if (FileTypeInfo.DefaultFileTypeExtensions.ContainsKey(Program.CurrentProject.ProjectFileTable.Entries[key].FileType))
				{
					fileExt = FileTypeInfo.DefaultFileTypeExtensions[Program.CurrentProject.ProjectFileTable.Entries[key].FileType];
				}
				sfd.FileName = String.Format("{0:X4}{1}", key, fileExt);

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, key);

					outWriter.Flush();
					outWriter.Close();
					romReader.Close();
				}
			}
			else
			{
				// more than one file
				List<int> ExtractIDs = new List<int>();
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					ExtractIDs.Add(key);
				}

				FileTable_ExtractFilesDialog efd = new FileTable_ExtractFilesDialog(ExtractIDs);
				if (efd.ShowDialog() == DialogResult.OK)
				{
					// set output directory
					SaveFileDialog sfd = new SaveFileDialog();
					sfd.Title = "Select Export Directory";
					sfd.Filter = SharedStrings.FileFilter_None;
					sfd.CheckFileExists = false;
					sfd.FileName = "(choose a directory)";
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						string outPath = Path.GetDirectoryName(sfd.FileName);
						MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
						BinaryReader romReader = new BinaryReader(romStream);

						foreach (KeyValuePair<int, string> extractFile in efd.ExtractFiles)
						{
							FileStream outFile = new FileStream(String.Format("{0}\\{1}", outPath, extractFile.Value), FileMode.Create);
							BinaryWriter outWriter = new BinaryWriter(outFile);
							Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, extractFile.Key);
							outWriter.Flush();
							outWriter.Close();
						}

						romReader.Close();
					}
				}
			}
		}

		/// <summary>
		/// Raw export (do not de-LZSS file)
		/// </summary>
		private void extractRawToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				Program.ErrorMessageBox("Please select at least one item to extract.");
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// only one file; no need to go through rigmarole
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Extract File (Raw)";
				sfd.Filter = SharedStrings.FileFilter_None;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, key, true);

					outWriter.Flush();
					outWriter.Close();
					romReader.Close();
				}
			}
			else
			{
				// more than one file
				Program.ErrorMessageBox("Haven't implemented multiple raw extraction yet.");
			}
		}
		#endregion

		/// <summary>
		/// Load the Edit Information dialog for a single FileTable entry.
		/// </summary>
		private void LoadEditInfoDialog()
		{
			int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
			FileTableEditEntryInfoDialog editInfoDialog = new FileTableEditEntryInfoDialog(Program.CurrentProject.ProjectFileTable.Entries[key]);
			if (editInfoDialog.ShowDialog() == DialogResult.OK)
			{
				Program.CurrentProject.ProjectFileTable.Entries[key].DeepCopy(editInfoDialog.CurEntry);
				lvFileList.SelectedItems[0].SubItems[FILE_TYPE_COLUMN].Text = editInfoDialog.CurEntry.FileType.ToString();
				lvFileList.SelectedItems[0].SubItems[COMMENT_COLUMN].Text = editInfoDialog.CurEntry.Comment;
				Program.UnsavedChanges = true;
				((MainForm)(MdiParent)).UpdateTitleBar();
			}
		}

		/// <summary>
		/// Load an item preview (or the hex viewer).
		/// </summary>
		private void LoadItemPreview()
		{
			if (lvFileList.SelectedItems.Count == 0)
			{
				return;
			}

			// preview is not allowed for multiple selection...
			if (lvFileList.SelectedItems.Count > 1)
			{
				return;
			}

			int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
			FileTableEntry fte = Program.CurrentProject.ProjectFileTable.Entries[key];

			switch (fte.FileType)
			{
				// "TEX" files
				case FileTypes.AkiTexture:
					{
						FileTable_TexPreviewDialog tpd = new FileTable_TexPreviewDialog(key);
						tpd.ShowDialog();
					}
					break;
				
				// I4 textures
				case FileTypes.I4Texture:
					{
						FileTable_ITexturePreviewDialog ipd = new FileTable_ITexturePreviewDialog(key);
						ipd.ShowDialog();
					}
					break;

				// CI4/CI8 textures
				case FileTypes.Ci4Texture:
				case FileTypes.Ci8Texture:
					{
						FileTable_CiTexturePreviewDialog citd = new FileTable_CiTexturePreviewDialog(key);
						citd.ShowDialog();
					}
					break;

				// CI4/CI8 palettes
				case FileTypes.Ci4Palette:
				case FileTypes.Ci8Palette:
					{
						Editors.CiPaletteEditor cipe = new Editors.CiPaletteEditor(key);
						if (cipe.ShowDialog() == DialogResult.OK)
						{
							// commit changes... somehow.
						}
					}
					break;

				// AkiText archive
				case FileTypes.AkiText:
					{
						// act upon working file if it exists
						Editors.AkiTextEditor ate;
						if (fte.ReplaceFilePath != null && fte.ReplaceFilePath != String.Empty)
						{
							// load file
							ate = new Editors.AkiTextEditor(Program.ConvertRelativePath(fte.ReplaceFilePath));
						}
						else
						{
							// load rom
							ate = new Editors.AkiTextEditor(key);
						}

						if (ate.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save AkiText changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							if (fte.ReplaceFilePath == null || fte.ReplaceFilePath == String.Empty)
							{
								// situation 1: editing for the first time (make new file)
								string filename = String.Format("{0}\\{1:X4}.akitext", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), key);
								using (FileStream fs = new FileStream(filename, FileMode.Create))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										ate.CurTextArchive.WriteData(bw);
									}
								}

								// set new ReplaceFilePath
								fte.ReplaceFilePath = Program.ShortenAbsolutePath(filename);
								Program.InfoMessageBox(String.Format("Wrote new AkiText archive to {0}.", filename));

								Program.UnsavedChanges = true;
								((MainForm)(MdiParent)).UpdateTitleBar();
							}
							else if (Path.GetExtension(fte.ReplaceFilePath) == ".csv")
							{
								Program.WarningMessageBox("todo: have not implemented CSV ReplaceFile case; changes not saved.");
								// situation 2: csv file in ReplaceFilePath (make new akitext binary file)
								// ProjectFiles/(key).akitext

								// set new ReplaceFilePath
							}
							else if (Path.GetExtension(fte.ReplaceFilePath) == ".akitext")
							{
								// situation 3: akitext binary in ReplaceFilePath (overwrite existing file)
								using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										ate.CurTextArchive.WriteData(bw);
									}
								}
							}
						}
					}
					break;

				// Menu Backgrounds
				case FileTypes.MenuBackground:
					{
						FileTable_MenuBackgoundPreviewDialog mbgp = new FileTable_MenuBackgoundPreviewDialog(key);
						mbgp.ShowDialog();
					}
					break;

				// Fonts
				case FileTypes.AkiSmallFont:
				case FileTypes.AkiLargeFont:
					{
						List<int> fontCharFiles = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.AkiFontChars);
						if (fontCharFiles.Count == 0)
						{
							// we don't have FontChars defined... use fallback charset in FontDialog.
							Editors.FontDialog fd = new Editors.FontDialog(key);
							fd.ShowDialog();
						}
						else if (fontCharFiles.Count > 1)
						{
							// multiple FontChars files defined; need to select which one to use.
							FileTable_SelectFontCharsDialog sfcd = new FileTable_SelectFontCharsDialog(fontCharFiles);
							if (sfcd.ShowDialog() == DialogResult.OK)
							{
								Editors.FontDialog fd = new Editors.FontDialog(key, sfcd.SelectedFileID);
								fd.ShowDialog();
							}
						}
						else
						{
							// the easy way out
							Editors.FontDialog fd = new Editors.FontDialog(key, fontCharFiles[0]);
							fd.ShowDialog();
						}
					}
					break;

				// TEMPORARY
				case FileTypes.AkiModel:
					{
						ModelTool2 mt2 = new ModelTool2(key);
						mt2.ShowDialog();
					}
					break;

				case FileTypes.AkiAnimation:
					{
						AnimTest t = new AnimTest(key);
						t.ShowDialog();
					}
					break;
				// end temporary

				// no default handler; show the hex viewer.
				default:
					((MainForm)this.MdiParent).RequestHexViewer(key);
					break;
			}
		}

		/// <summary>
		/// Double clicking on an item
		/// </summary>
		private void lvFileList_DoubleClick(object sender, EventArgs e)
		{
			LoadItemPreview();
		}

		/// <summary>
		/// Pressing Enter on an item
		/// </summary>
		private void lvFileList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				LoadItemPreview();
			}
		}

		#region Navigation Menu Items
		/// <summary>
		/// Go to a specific file ID.
		/// </summary>
		private void goToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileTable_GoToDialog gtd = new FileTable_GoToDialog();
			if (gtd.ShowDialog() == DialogResult.OK)
			{
				lvFileList.FocusedItem = lvFileList.Items[gtd.DestinationFileID-1];
				lvFileList.EnsureVisible(gtd.DestinationFileID-1);
				foreach (ListViewItem lvi in lvFileList.Items)
				{
					lvi.Selected = (lvi.Index == gtd.DestinationFileID - 1);
				}
			}
		}

		/// <summary>
		/// Go to the top of the FileTable.
		/// </summary>
		private void goToTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lvFileList.FocusedItem = lvFileList.Items[0];
			lvFileList.EnsureVisible(0);
		}

		/// <summary>
		/// Go to the bottom of the FileTable.
		/// </summary>
		private void goToBottomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lvFileList.FocusedItem = lvFileList.Items[lvFileList.Items.Count-1];
			lvFileList.EnsureVisible(lvFileList.Items.Count-1);
		}
		#endregion

		#region Database Menu Items
		private void reloadFileTableDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// save previous position
			ListViewItem prevItem = lvFileList.FocusedItem;
			int prevIndex = prevItem.Index;

			ReloadFileTableDB();
			UpdateEntryList();

			// reload previous position
			lvFileList.EnsureVisible(prevIndex);
			lvFileList.FocusedItem = prevItem;
		}
		#endregion

		#region Export Menu Items
		/// <summary>
		/// Export the FileTable as a Midwaydec File List.
		/// </summary>
		private void exportMidwaydecFileListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Midwaydec File List";
			sfd.Filter = SharedStrings.FileFilter_Text;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
				StreamWriter sw = new StreamWriter(fs);
				Program.CurrentProject.ProjectFileTable.WriteMidwaydec(sw);
				sw.Flush();
				sw.Close();
			}
		}
		#endregion
	}
}
