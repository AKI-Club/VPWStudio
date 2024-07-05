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
		// freem from 2022/04/18, when he added project comment column: "lol"
		private const int FILE_ID_COLUMN = 0;
		private const int LOCATION_COLUMN = 1;
		private const int ROM_ADDR_COLUMN = 2;
		private const int FILE_TYPE_COLUMN = 3;
		private const int LZSS_COLUMN = 4;
		private const int COMMENT_COLUMN = 5;
		private const int PROJECT_COMMENT_COLUMN = 6;
		#endregion

		#region Row Colors
		/// <summary>
		/// Row color for unmodified odd rows
		/// </summary>
		private readonly Color RowColor_UnmodifiedFirst = Color.White;

		/// <summary>
		/// Row color for unmodified even rows
		/// </summary>
		private readonly Color RowColor_UnmodifiedSecond = Color.FromArgb(240, 240, 240);

		/// <summary>
		/// Row color for modified odd rows
		/// </summary>
		private readonly Color RowColor_ModifiedFirst = Color.FromArgb(255, 224, 224);

		/// <summary>
		/// Row color for modified even rows
		/// </summary>
		private readonly Color RowColor_ModifiedSecond = Color.FromArgb(240, 192, 192);
		#endregion

		#region Search values
		/// <summary>
		/// Possible search types.
		/// </summary>
		public enum SearchType
		{
			/// <summary>
			/// FileTableEntry comment text
			/// </summary>
			Text = 0,

			/// <summary>
			/// FileTableEntry file type
			/// </summary>
			FileType,

			Invalid = -1
		};

		/// <summary>
		/// Current active search type.
		/// </summary>
		public SearchType CurrentSearchType = SearchType.Invalid;

		/// <summary>
		/// Current string to search for.
		/// </summary>
		/// Set via "Search" command, used for "Find Next" (F3?)
		private string CurrentSearchText = String.Empty;

		private FileTypes CurrentFileType;

		/// <summary>
		/// Index of current search hit.
		/// </summary>
		private int CurrentSearchItemNumber = -1;
		#endregion

		// xxx: not synced with FileTable_EditMultiEntryInfoDialog
		protected int MultiEditWindowWidth = 800;

		public FileTableDialog(int focusEntry = 0)
		{
			InitializeComponent();
			SetupSetTypeMenu();
			tssLabelSelectedItems.Text = "0 items selected"; // xxx: hardcoded english

			if (Program.CurrentProject != null)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries.Count == 0)
				{
					// project filetable was not created.
					Program.InfoMessageBox(SharedStrings.FileTableDialog_AttemptRomTableBuild);
					MakeFileTableFromRom();

					Program.UnsavedChanges = true;
					Program.AppMainForm.UpdateTitleBar();
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
			{ FileTypes.AkiAnimation, Properties.Resources.FileType_AkiAnimation },
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
			{ FileTypes.RawCi4TexPal, Properties.Resources.FileType_RawCi4TexPal },
			{ FileTypes.RawCi8Texture, Properties.Resources.FileType_RawCi8Texture },
			{ FileTypes.OneBppTexture, Properties.Resources.FileType_OneBppTexture },
			{ FileTypes.AkiFontChars, Properties.Resources.FileType_AkiFontChars },
		};

		/// <summary>
		/// Create the "Set Type" menu sub-items.
		/// </summary>
		private void SetupSetTypeMenu()
		{
			SortedList<FileTypes, ToolStripMenuItem> types = new SortedList<FileTypes, ToolStripMenuItem>();
			List<FileTypes> validTypes = FileTypeInfo.GetValidFileTypesForGame(Program.CurrentProject.Settings.BaseGame);

			for (int i = 0; i < validTypes.Count; i++)
			{
				FileTypes curType = validTypes[i];
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

				if (ftdb.ErrorList.Count > 0)
				{
					StringBuilder sb = new StringBuilder();
					foreach (string error in ftdb.ErrorList)
					{
						sb.AppendLine(error);
					}
					Program.ErrorMessageBox(sb.ToString());
				}

				Parallel.ForEach(ftdb.Entries, delegate(KeyValuePair<UInt16, FileTableDBEntry> entry)
				{
					int fileID = entry.Value.FileID;
					Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType = entry.Value.FileType;
					Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment = entry.Value.Comment;

					if (entry.Value.ExtraData != string.Empty)
					{
						Program.CurrentProject.ProjectFileTable.Entries[fileID].ParseExtraDataString(entry.Value.ExtraData);
					}
				});
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

				if (ftdb.ErrorList.Count > 0)
				{
					StringBuilder sb = new StringBuilder();
					foreach (string error in ftdb.ErrorList)
					{
						sb.AppendLine(error);
					}
					Program.ErrorMessageBox(sb.ToString());
				}

				bool replaceComments = false;
				if (MessageBox.Show("Do you want to overwrite your comments with comments from the FileTable Database?", SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					replaceComments = true;
				}

				Parallel.ForEach(ftdb.Entries, delegate (KeyValuePair<UInt16, FileTableDBEntry> entry)
				{
					int fileID = entry.Value.FileID;
					if (Program.CurrentProject.ProjectFileTable.Entries.ContainsKey(fileID))
					{
						// if OverrideFileType is set, then whatever's in the game's FileTableDB is not accurate for this project.
						if (!Program.CurrentProject.ProjectFileTable.Entries[fileID].OverrideFileType)
						{
							// only replace filetype if not being overridden to do something else.
							if (Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType != entry.Value.FileType)
							{
								Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType = entry.Value.FileType;
								changesMade = true;
							}

							// only replace comment if it's empty, or we were requested to.
							if (Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment == String.Empty || replaceComments == true)
							{
								Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment = entry.Value.Comment;
								changesMade = true;
							}

							// handle ExtraData
							// todo: doesn't handle situation where ExtraData was null but FileTableDB has ExtraData.
							if (entry.Value.ExtraData != null)
							{
								if (entry.Value.ExtraData != string.Empty)
								{
									Program.CurrentProject.ProjectFileTable.Entries[fileID].ParseExtraDataString(entry.Value.ExtraData);
								}
							}
						}
					}
				});

				if (changesMade)
				{
					Program.UnsavedChanges = true;
					Program.AppMainForm.UpdateTitleBar();
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

			lvFileList.BeginUpdate();
			lvFileList.Items.Clear();
			foreach (KeyValuePair<int, FileTableEntry> fte in Program.CurrentProject.ProjectFileTable.Entries)
			{
				ListViewItem lvi = new ListViewItem(new string[] {
					String.Format("{0:X4}",fte.Value.FileID),
					String.Format("{0:X8}",fte.Value.Location),
					String.Format("{0:X8}",fte.Value.Location + offset),
					fte.Value.FileType.ToString(),
					fte.Value.IsEncoded.ToString(),
					fte.Value.Comment,
					fte.Value.ProjectSpecificComment
				});
				lvi.UseItemStyleForSubItems = false;

				Color rowColor;
				if (fte.Value.FileID % 2 == 0)
				{
					rowColor = (fte.Value.HasReplacementFile()) ? RowColor_ModifiedSecond : RowColor_UnmodifiedSecond;
				}
				else
				{
					rowColor = (fte.Value.HasReplacementFile()) ? RowColor_ModifiedFirst : RowColor_UnmodifiedFirst;
				}

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
				lvi.SubItems[PROJECT_COMMENT_COLUMN].Font = regular;
				lvFileList.Items.Add(lvi);
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

				menuBackgroundReplacementToolStripMenuItem.Enabled = false;
				menuBackgroundReplacementToolStripMenuItem.Visible = false;

				// check if any of the selected items has a replacement file entry

				// todo: this causes lag when selecting a large amount of files
				// how should this actually be handled?
				bool hasReplaceFile = false;
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					if (Program.CurrentProject.ProjectFileTable.Entries[key].HasReplacementFile())
					{
						hasReplaceFile = true;
						break;
					}
				}

				viewHexReplacementFileDataToolStripMenuItem.Enabled = hasReplaceFile;

				// disable multi-png export for now
				extractPNGToolStripMenuItem.Enabled = false;
				extractPNGToolStripMenuItem.Visible = false;
			}
			else if (lvFileList.SelectedItems.Count == 1)
			{
				extractFileToolStripMenuItem.Text = SharedStrings.FileTableDialog_ExtractFile;

				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				extractRawToolStripMenuItem.Enabled = Program.CurrentProject.ProjectFileTable.Entries[key].IsEncoded;

				bool isMenuBGItem = (Program.CurrentProject.ProjectFileTable.Entries[key].FileType == FileTypes.MenuBackground);
				menuBackgroundReplacementToolStripMenuItem.Enabled = isMenuBGItem;
				menuBackgroundReplacementToolStripMenuItem.Visible = isMenuBGItem;
				viewHexReplacementFileDataToolStripMenuItem.Enabled = Program.CurrentProject.ProjectFileTable.Entries[key].HasReplacementFile();

				// PNG export currently only available for AkiTexture
				bool isAkiTexture = (Program.CurrentProject.ProjectFileTable.Entries[key].FileType == FileTypes.AkiTexture);
				extractPNGToolStripMenuItem.Enabled = isAkiTexture;
				extractPNGToolStripMenuItem.Visible = isAkiTexture;
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
				Program.AppMainForm.UpdateTitleBar();
			}
		}

		/// <summary>
		/// Call the hex viewer for ROM data
		/// </summary>
		private void viewHexRomDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// easy
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				((MainForm)MdiParent).RequestHexViewer(key);
			}
			else
			{
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					((MainForm)MdiParent).RequestHexViewer(key);
				}
				return;
			}
		}

		/// <summary>
		/// Call the hex viewer for replacement file data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void viewHexReplacementFileDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				return;
			}

			if (lvFileList.SelectedItems.Count == 1)
			{
				// easy
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				string path = Program.CurrentProject.ProjectFileTable.Entries[key].ReplaceFilePath;
				((MainForm)MdiParent).RequestHexViewer(File.ReadAllBytes(Program.ConvertRelativePath(path)), path);
			}
			else
			{
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					if (Program.CurrentProject.ProjectFileTable.Entries[key].HasReplacementFile())
					{
						string path = Program.CurrentProject.ProjectFileTable.Entries[key].ReplaceFilePath;
						((MainForm)MdiParent).RequestHexViewer(File.ReadAllBytes(Program.ConvertRelativePath(path)), path);
					}
				}
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
				List<FileTableEntry> EditEntries = new List<FileTableEntry>();
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					EditEntries.Add(Program.CurrentProject.ProjectFileTable.Entries[key]);
				}

				FileTable_EditMultiEntryInfoDialog emd = new FileTable_EditMultiEntryInfoDialog(EditEntries, MultiEditWindowWidth);
				if (emd.ShowDialog() == DialogResult.OK)
				{
					if (emd.AnyChangesSubmitted)
					{
						// need to go through emd.Entries and update the FileTable
						foreach (FileTableEntry fte in emd.Entries)
						{
							Program.CurrentProject.ProjectFileTable.Entries[fte.FileID].DeepCopy(fte);
						}
						// also need to update the DataGridView...
						// sadly, this is not the most efficient way, but I'm lazy.

						// save previous position
						ListViewItem prevItem = lvFileList.FocusedItem;
						int prevIndex = prevItem.Index;

						UpdateEntryList();

						// reload previous position
						lvFileList.EnsureVisible(prevIndex);
						lvFileList.FocusedItem = prevItem;

						Program.UnsavedChanges = true;
						Program.AppMainForm.UpdateTitleBar();
					}
				}
				MultiEditWindowWidth = emd.LastWidth;
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
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);

				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Extract File (Raw)";
				sfd.Filter = SharedStrings.FileFilter_None;
				sfd.FileName = String.Format("{0:X4}.lzss", key);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, key, true);

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
							Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, extractFile.Key, true);
							outWriter.Flush();
							outWriter.Close();
						}

						romReader.Close();
					}
				}
			}
		}

		/// <summary>
		/// Replace Menu Background files
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuBackgroundReplacementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count <= 0)
			{
				Program.ErrorMessageBox("Please select a MenuBackground entry to replace.");
				return;
			}

			if (lvFileList.SelectedItems.Count > 1)
			{
				Program.ErrorMessageBox("You only need to select the first MenuBackground entry.");
				return;
			}

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Image to Convert";
			ofd.Filter = SharedStrings.FileFilter_PNG;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				MenuBackground mbg = new MenuBackground(Program.CurrentProject.Settings.BaseGame);
				Bitmap newBG = new Bitmap(ofd.FileName);
				if (!mbg.FromBitmap(newBG))
				{
					if (newBG.Width != 320 || newBG.Height != 240)
					{
						Program.ErrorMessageBox("Menu background images must be 320x240 pixels.");
					}
					else if (newBG.PixelFormat != System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
					{
						Program.ErrorMessageBox(String.Format("Menu background images must be 4BPP (16 colors).\nInput image has PixelFormat '{0}'.",newBG.PixelFormat.ToString()));
					}
					else
					{
						Program.ErrorMessageBox("Unable to convert provided image to a menu background for an undetermined reason.");
					}
					
					newBG.Dispose();
					return;
				}

				string outPath = Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath) + @"\Backgrounds\";
				if (!Directory.Exists(outPath))
				{
					Directory.CreateDirectory(outPath);
				}
				outPath += Path.GetFileNameWithoutExtension(ofd.FileName);
				if (!Directory.Exists(outPath))
				{
					Directory.CreateDirectory(outPath);
				}

				int bgFileID = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
				for (int i = 0; i < mbg.ChunkRows * mbg.ChunkColumns; i++)
				{
					string outFileName = String.Format("{0}\\bg{1:D2}.bin", outPath, i + 1);
					using (FileStream fs = new FileStream(outFileName, FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							bw.Write(mbg.GetChunkBytes(i));
							Program.CurrentProject.ProjectFileTable.Entries[bgFileID].ReplaceFilePath = Program.ShortenAbsolutePath(outFileName);
							bgFileID++;
						}
					}
				}
				Program.UnsavedChanges = true;
				Program.AppMainForm.UpdateTitleBar();
				newBG.Dispose();

				// save previous position
				ListViewItem prevItem = lvFileList.FocusedItem;
				int prevIndex = prevItem.Index;

				UpdateEntryList();

				// reload previous position
				lvFileList.EnsureVisible(prevIndex);
				lvFileList.FocusedItem = prevItem;
			}
		}

		/// <summary>
		/// Extract selected textures as PNG files.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void extractPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count > 1)
			{
				// determine if we have anything we can actually export
				List<int> ExportIDs = new List<int>();
				for (int i = 0; i < lvFileList.SelectedItems.Count; i++)
				{
					int key = int.Parse(lvFileList.SelectedItems[i].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);
					// only supports AkiTexture, CI4Texture, and CI8Texture.
					// the latter two require known palettes to be set in the ExtraData entries.
					if (Program.CurrentProject.ProjectFileTable.Entries[key].FileType == FileTypes.AkiTexture)
					{
						ExportIDs.Add(key);
					}
					/*
					else if (Program.CurrentProject.ProjectFileTable.Entries[key].FileType == FileTypes.Ci4Texture
						&& Program.CurrentProject.ProjectFileTable.Entries[key].ExtraData.IntendedPaletteFileID != -1)
					{
						// CI4 with known palette
						ExportIDs.Add(key);
					}
					else if (Program.CurrentProject.ProjectFileTable.Entries[key].FileType == FileTypes.Ci8Texture
						&& Program.CurrentProject.ProjectFileTable.Entries[key].ExtraData.IntendedPaletteFileID != -1)
					{
						// CI8 with known palette
						ExportIDs.Add(key);
					}
					*/
				}

				if (ExportIDs.Count <= 0)
				{
					Program.ErrorMessageBox("None of the selected files can be exported using this option.");
					return;
				}

				// set output directory
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Select Export Directory";
				sfd.Filter = SharedStrings.FileFilter_None;
				sfd.CheckFileExists = false;
				sfd.FileName = "(choose a directory)";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					Program.ErrorMessageBox("freem's a lazy twat who didn't implement multi-export yet");
					string outPath = Path.GetDirectoryName(sfd.FileName);

					// todo: shared romreader
					//MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					//BinaryReader romReader = new BinaryReader(romStream);

					//MemoryStream outStream = new MemoryStream();
					//BinaryWriter outWriter = new BinaryWriter(outStream);

					//BinaryReader outReader = new BinaryReader(outStream);

					foreach (int fid in ExportIDs)
					{
						//Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fid);
						//outStream.Seek(0, SeekOrigin.Begin);

						if (Program.CurrentProject.ProjectFileTable.Entries[fid].FileType == FileTypes.AkiTexture)
						{
							//AkiTexture outTex = new AkiTexture(outReader);
							//outTex.ToBitmap().Save(String.Format("{0:X4}.png",fid));
						}
						else if (Program.CurrentProject.ProjectFileTable.Entries[fid].FileType == FileTypes.Ci4Texture)
						{
							// need to load Ci4Palette
						}
						else if (Program.CurrentProject.ProjectFileTable.Entries[fid].FileType == FileTypes.Ci8Texture)
						{
							// need to load Ci8Palette
						}
					}

					// todo: cleanup file handles
				}
			}
			else if (lvFileList.SelectedItems.Count == 1)
			{
				int key = int.Parse(lvFileList.SelectedItems[0].SubItems[FILE_ID_COLUMN].Text, NumberStyles.HexNumber);

				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export PNG";
				sfd.Filter = SharedStrings.FileFilter_PNG;
				sfd.FileName = String.Format("{0:X4}.png", key);

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					MemoryStream outStream = new MemoryStream();
					BinaryWriter outWriter = new BinaryWriter(outStream);

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, key);
					romReader.Close();

					BinaryReader outReader = new BinaryReader(outStream);
					outStream.Seek(0, SeekOrigin.Begin);

					AkiTexture outTex = new AkiTexture(outReader);
					outTex.ToBitmap().Save(sfd.FileName);

					romReader.Close();
					outWriter.Close();
				}
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
				lvFileList.SelectedItems[0].SubItems[PROJECT_COMMENT_COLUMN].Text = editInfoDialog.CurEntry.ProjectSpecificComment;

				Color rowColor;
				if (key % 2 == 0)
				{
					rowColor = (editInfoDialog.CurEntry.HasReplacementFile()) ? RowColor_ModifiedSecond : RowColor_UnmodifiedSecond;
				}
				else
				{
					rowColor = (editInfoDialog.CurEntry.HasReplacementFile()) ? RowColor_ModifiedFirst : RowColor_UnmodifiedFirst;
				}
				foreach (ListViewItem.ListViewSubItem subitem in lvFileList.SelectedItems[0].SubItems)
				{
					subitem.BackColor = rowColor;
				}

				Program.UnsavedChanges = true;
				Program.AppMainForm.UpdateTitleBar();
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

			// prevent crashes in a very lazy/hacky/bad way
			if (fte.OverrideFileType)
			{
				Program.ErrorMessageBox("Previewing files with overridden FileTypes is currently disabled because I don't feel like debugging crashes at the moment.");
				return;
			}

			switch (fte.FileType)
			{
				// "TEX" files
				case FileTypes.AkiTexture:
					{
						TexPreviewDialog tpd = new TexPreviewDialog(key);
						tpd.ShowDialog();
					}
					break;
				
				// I4 textures
				case FileTypes.I4Texture:
					{
						ITexturePreviewDialog ipd = new ITexturePreviewDialog(key);
						ipd.ShowDialog();
					}
					break;

				// CI4/CI8 textures
				case FileTypes.Ci4Texture:
				case FileTypes.Ci8Texture:
				case FileTypes.Ci4Background:
				case FileTypes.RawCi4TexPal:
				case FileTypes.RawCi8Texture:
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
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save palette changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							if (String.IsNullOrEmpty(fte.ReplaceFilePath))
							{
								// make new palette file
								string filename = String.Empty;
								if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci4)
								{
									filename = String.Format("{0}\\{1:X4}.ci4pal", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), key);
								}
								else if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci8)
								{
									filename = String.Format("{0}\\{1:X4}.ci8pal", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), key);
								}

								using (FileStream fs = new FileStream(filename, FileMode.Create))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci4)
										{
											cipe.CurPaletteCI4.WriteData(bw);
										}
										else if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci8)
										{
											cipe.CurPaletteCI8.WriteData(bw);
										}
									}
								}

								// set new ReplaceFilePath
								fte.ReplaceFilePath = Program.ShortenAbsolutePath(filename);
								Program.InfoMessageBox(String.Format("Wrote new palette file to {0}.", filename));

								Program.UnsavedChanges = true;
								Program.AppMainForm.UpdateTitleBar();
							}
							else
							{
								// existing file, likely .vpwspal, but sometimes not
								if (Path.GetExtension(fte.ReplaceFilePath) == ".vpwspal")
								{
									// vpw studio format
									using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
									{
										using (StreamWriter sw = new StreamWriter(fs))
										{
											if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci4)
											{
												cipe.CurPaletteCI4.ExportVpwsPal(sw);
											}
											else if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci8)
											{
												cipe.CurPaletteCI8.ExportVpwsPal(sw);
											}
										}
									}
								}
								else if (Path.GetExtension(fte.ReplaceFilePath) == ".ci4pal")
								{
									// ci4 palette binary
									if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci4)
									{
										using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
										{
											using (BinaryWriter bw = new BinaryWriter(fs))
											{
												cipe.CurPaletteCI4.WriteData(bw);
											}
										}
									}
									else
									{
										Program.ErrorMessageBox("Error attempting to save CI4 palette in CI8 mode; this is not supported.");
									}
								}
								else if (Path.GetExtension(fte.ReplaceFilePath) == ".ci8pal")
								{
									// ci8 palette binary
									if (cipe.EditorMode == Editors.CiPaletteEditor.CiEditorModes.Ci8)
									{
										using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
										{
											using (BinaryWriter bw = new BinaryWriter(fs))
											{
												cipe.CurPaletteCI8.WriteData(bw);
											}
										}
									}
									else
									{
										Program.ErrorMessageBox("Error attempting to save CI8 palette in CI4 mode; this is not supported.");
									}
								}
								else
								{
									// not handled yet
									Program.ErrorMessageBox("freem is currently too lazy to hook up palette saving for non-raw CI and non-vpwspal formats.\nConsidering that only raw CI palettes, .vpwspal format, and jasc .pal format are supported for project building, though...");
								}
							}
						}
					}
					break;

				// AkiText archive
				case FileTypes.AkiText:
					{
						// act upon working file if it exists
						Editors.AkiTextEditor ate;
						if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// load file
							ate = new Editors.AkiTextEditor(Program.ConvertRelativePath(fte.ReplaceFilePath));
						}
						else if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && !File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// replacement file defined but nonexistent
							Program.InfoMessageBox(String.Format("Unable to open replacement file {0}, using data from ROM instead.",fte.ReplaceFilePath));
							ate = new Editors.AkiTextEditor(key);
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
								Program.AppMainForm.UpdateTitleBar();
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
							else if (Path.GetExtension(fte.ReplaceFilePath) == ".txt")
							{
								// situation 4: .txt for akitext command line tool (overwrite existing file)
								using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
								{
									using (StreamWriter sw = new StreamWriter(fs))
									{
										ate.CurTextArchive.WriteToolExport(sw);
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

				// WWF No Mercy Groupless Menu Items
				case FileTypes.MenuItems_NoGroup:
					{
						Editors.NoMercy.MenuItemsNoGroup_NoMercy gme;

						if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// load file
							gme = new Editors.NoMercy.MenuItemsNoGroup_NoMercy(Program.ConvertRelativePath(fte.ReplaceFilePath));
						}
						else if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && !File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// replacement file defined but nonexistent
							Program.InfoMessageBox(String.Format("Unable to open replacement file {0}, using data from ROM instead.", fte.ReplaceFilePath));
							gme = new Editors.NoMercy.MenuItemsNoGroup_NoMercy(key);
						}
						else
						{
							// load rom
							gme = new Editors.NoMercy.MenuItemsNoGroup_NoMercy(key);
						}

						if (gme.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save MenuItems_NoGroup changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							if (fte.ReplaceFilePath == null || fte.ReplaceFilePath == String.Empty)
							{
								// make new file
								string filename = String.Format("{0}\\{1:X4}{2}", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), key, FileTypeInfo.DefaultFileTypeExtensions[FileTypes.MenuItems_NoGroup]);
								using (FileStream fs = new FileStream(filename, FileMode.Create))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										gme.MenuItemData.WriteData(bw);
									}
								}

								// set new ReplaceFilePath
								fte.ReplaceFilePath = Program.ShortenAbsolutePath(filename);
								Program.InfoMessageBox(String.Format("Wrote new MenuItems_NoGroup archive to {0}.", filename));

								Program.UnsavedChanges = true;
								Program.AppMainForm.UpdateTitleBar();
							}
							else
							{
								// save existing file
								using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										gme.MenuItemData.WriteData(bw);
									}
								}
							}
						}
					}
					break;

				// WWF No Mercy move names
				case FileTypes.MenuItems_Moves:
					{
						Editors.NoMercy.MenuItemsMoves_NoMercy me;
						if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// load file
							me = new Editors.NoMercy.MenuItemsMoves_NoMercy(Program.ConvertRelativePath(fte.ReplaceFilePath));
						}
						else if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && !File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// replacement file defined but nonexistent
							Program.InfoMessageBox(String.Format("Unable to open replacement file {0}, using data from ROM instead.", fte.ReplaceFilePath));
							me = new Editors.NoMercy.MenuItemsMoves_NoMercy(key);
						}
						else
						{
							// load rom
							me = new Editors.NoMercy.MenuItemsMoves_NoMercy(key);
						}

						if (me.ShowDialog() == DialogResult.OK)
						{
							Program.ErrorMessageBox("hahaha well did you really expect freem to fully implement something immediately?\nsorry, changes not saved");
							return;
						}
					}
					break;

				// WWF No Mercy Smackdown Mall Shop menu items
				case FileTypes.MenuItems_Shop:
						{
						Editors.NoMercy.MenuItemsShop_NoMercy gme;

						if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// load file
							gme = new Editors.NoMercy.MenuItemsShop_NoMercy(Program.ConvertRelativePath(fte.ReplaceFilePath));
						}
						else if (!String.IsNullOrEmpty(fte.ReplaceFilePath) && !File.Exists(Program.ConvertRelativePath(fte.ReplaceFilePath)))
						{
							// replacement file defined but nonexistent
							Program.InfoMessageBox(String.Format("Unable to open replacement file {0}, using data from ROM instead.", fte.ReplaceFilePath));
							gme = new Editors.NoMercy.MenuItemsShop_NoMercy(key);
						}
						else
						{
							// load rom
							gme = new Editors.NoMercy.MenuItemsShop_NoMercy(key);
						}

						if (gme.ShowDialog() == DialogResult.OK)
						{
							if (Program.CurProjectPath == null || Program.CurProjectPath == String.Empty)
							{
								// we need to have saved in order to actually... save.
								Program.ErrorMessageBox("Can not save MenuItems_Shop changes to an unsaved Project File.\n\nPlease save the Project File before continuing.");
								return;
							}

							if (fte.ReplaceFilePath == null || fte.ReplaceFilePath == String.Empty)
							{
								// make new file
								string filename = String.Format("{0}\\{1:X4}{2}", Program.ConvertRelativePath(Program.CurrentProject.Settings.ProjectFilesPath), key, FileTypeInfo.DefaultFileTypeExtensions[FileTypes.MenuItems_Shop]);
								using (FileStream fs = new FileStream(filename, FileMode.Create))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										gme.ShopItems.WriteData(bw);
									}
								}

								// set new ReplaceFilePath
								fte.ReplaceFilePath = Program.ShortenAbsolutePath(filename);
								Program.InfoMessageBox(String.Format("Wrote new MenuItems_Shop archive to {0}.", filename));

								Program.UnsavedChanges = true;
								Program.AppMainForm.UpdateTitleBar();
							}
							else
							{
								// save existing file
								using (FileStream fs = new FileStream(Program.ConvertRelativePath(fte.ReplaceFilePath), FileMode.Open))
								{
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										gme.ShopItems.WriteData(bw);
									}
								}
							}
						}
					}
					break;

				case FileTypes.AkiModel:
					{
						ModelTool2 mt2 = new ModelTool2(key);
						mt2.ShowDialog();
					}
					break;

				// TEMPORARY
				case FileTypes.AkiAnimation:
					{
						AnimTest t = new AnimTest(key);
						t.ShowDialog();
					}
					break;

				case FileTypes.AkiArchive:
					{
						AkiArchiveTool aat = new AkiArchiveTool(key);
						aat.ShowDialog();
					}
					break;
				// end temporary

				// no default handler; show the hex viewer.
				default:
					((MainForm)MdiParent).RequestHexViewer(key);
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
		/// Handle various keyboard inputs
		/// </summary>
		private void lvFileList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// Pressing Enter on an item
				LoadItemPreview();
			}
			if (e.KeyCode == Keys.F3 && e.Shift == true)
			{
				if (CurrentSearchType == SearchType.Invalid || CurrentSearchItemNumber == -1)
				{
					CurrentSearchType = SearchType.Text;
					searchToolStripMenuItem_Click(sender, e);
				}

				int searchResult = 0;
				switch (CurrentSearchType)
				{
					case SearchType.Text:
						searchResult = SearchFile(CurrentSearchText, true);
						if (searchResult > 0)
						{
							PostSearch(searchResult);
						}
						break;

					case SearchType.FileType:
						searchResult = SearchFileType(CurrentFileType, true);
						if (searchResult > 0)
						{
							PostSearch(searchResult);
						}
						break;
				}

				if (searchResult < 0)
				{
					if (searchResult == -1)
					{
						Program.InfoMessageBox("Unable to find any matching entries.");
					}
					else if (searchResult == -2)
					{
						Program.InfoMessageBox("No more matching entries.");
					}
				}
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

		/// <summary>
		/// Search for a file ID based on comment text.
		/// </summary>
		/// <param name="searchText">String to search for in the comment field.</param>
		/// <returns>file ID of matching entry if found; -1 if not found; -2 for some weird edge case I never resolved</returns>
		private int SearchFile(string searchText, bool _backwards = false)
		{
			int startPoint = 1;
			int prevSearchNum = CurrentSearchItemNumber;
			if (CurrentSearchItemNumber != -1)
			{
				if (_backwards)
				{
					// start from current search item number - 1, so "Find Previous" (Shift+F3) works
					startPoint = CurrentSearchItemNumber - 1;
				}
				else
				{
					// start from current search item number + 1, so "Find Next" works
					startPoint = CurrentSearchItemNumber + 1;
				}
			}

			// search file list for comment
			if (_backwards)
			{
				for (int i = startPoint; i > 0; i--)
				{
					if (!String.IsNullOrEmpty(Program.CurrentProject.ProjectFileTable.Entries[i].Comment))
					{
						string fileComment = Program.CurrentProject.ProjectFileTable.Entries[i].Comment.ToLower();
						if (fileComment.Contains(searchText.ToLower()))
						{
							CurrentSearchItemNumber = i;
							return CurrentSearchItemNumber;
						}
					}

					if (!String.IsNullOrEmpty(Program.CurrentProject.ProjectFileTable.Entries[i].ProjectSpecificComment))
					{
						string projComment = Program.CurrentProject.ProjectFileTable.Entries[i].ProjectSpecificComment.ToLower();
						if (projComment.Contains(searchText.ToLower()))
						{
							CurrentSearchItemNumber = i;
							return CurrentSearchItemNumber;
						}
					}
				}
			}
			else
			{
				for (int i = startPoint; i < Program.CurrentProject.ProjectFileTable.Entries.Count; i++)
				{
					if (!String.IsNullOrEmpty(Program.CurrentProject.ProjectFileTable.Entries[i].Comment))
					{
						string fileComment = Program.CurrentProject.ProjectFileTable.Entries[i].Comment.ToLower();
						if (fileComment.Contains(searchText.ToLower()))
						{
							CurrentSearchItemNumber = i;
							return CurrentSearchItemNumber;
						}
					}

					if (!String.IsNullOrEmpty(Program.CurrentProject.ProjectFileTable.Entries[i].ProjectSpecificComment))
					{
						string projComment = Program.CurrentProject.ProjectFileTable.Entries[i].ProjectSpecificComment.ToLower();
						if (projComment.Contains(searchText.ToLower()))
						{
							CurrentSearchItemNumber = i;
							return CurrentSearchItemNumber;
						}
					}
				}
			}

			// todo: does not handle wrapping around to the beginning/end.
			if (CurrentSearchItemNumber == prevSearchNum)
			{
				return -2;
			}

			return -1;
		}

		private int SearchFileType(FileTypes ftype, bool _backwards = false)
		{
			int startPoint = 1;
			int prevSearchNum = CurrentSearchItemNumber;

			if (CurrentSearchItemNumber != -1)
			{
				if (_backwards)
				{
					// start from current search item number - 1, so "Find Previous" (Shift+F3) works
					startPoint = CurrentSearchItemNumber - 1;
				}
				else
				{
					// start from current search item number + 1, so "Find Next" works
					startPoint = CurrentSearchItemNumber + 1;
				}
			}

			if (_backwards)
			{
				for (int i = startPoint; i > 0; i--)
				{
					if (Program.CurrentProject.ProjectFileTable.Entries[i].FileType == ftype)
					{
						CurrentSearchItemNumber = i;
						return CurrentSearchItemNumber;
					}
				}
			}
			else
			{
				for (int i = startPoint; i < Program.CurrentProject.ProjectFileTable.Entries.Count; i++)
				{
					if (Program.CurrentProject.ProjectFileTable.Entries[i].FileType == ftype)
					{
						CurrentSearchItemNumber = i;
						return CurrentSearchItemNumber;
					}
				}
			}

			// todo: does not handle wrapping around to the beginning/end.
			if (CurrentSearchItemNumber == prevSearchNum)
			{
				return -2;
			}

			return -1;
		}

		/// <summary>
		/// Post-search action.
		/// </summary>
		private void PostSearch(int focus)
		{
			lvFileList.BeginUpdate();
			lvFileList.FocusedItem = lvFileList.Items[focus - 1];
			lvFileList.EnsureVisible(focus - 1);

			foreach (ListViewItem lvi in lvFileList.SelectedItems)
			{
				lvi.Selected = false;
			}
			lvFileList.Items[focus - 1].Selected = true;

			lvFileList.EndUpdate();
		}

		/// <summary>
		/// Search for a file based on the comment text.
		/// </summary>
		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileTable_SearchDialog sd = new FileTable_SearchDialog(CurrentSearchText);
			if (sd.ShowDialog() == DialogResult.OK)
			{
				CurrentSearchType = SearchType.Text;

				// Check if this is a new search term
				if (!sd.SearchText.Equals(CurrentSearchText))
				{
					// search from beginning (is this a good idea?)
					CurrentSearchItemNumber = -1;
				}

				CurrentSearchText = sd.SearchText;
				int searchResult = SearchFile(CurrentSearchText);
				switch (searchResult)
				{
					case -1:
						Program.InfoMessageBox(String.Format("Unable to find any entries matching '{0}'.", sd.SearchText));
						break;

					case -2:
						Program.InfoMessageBox(String.Format("No more entries matching '{0}'.", sd.SearchText));
						break;

					default:
						PostSearch(searchResult);
						break;
				}
			}
		}

		/// <summary>
		/// Search for a file based on the FileType.
		/// </summary>
		private void searchFileTypeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileTable_SearchFileTypeDialog sftd = new FileTable_SearchFileTypeDialog();
			if (sftd.ShowDialog() == DialogResult.OK)
			{
				CurrentSearchType = SearchType.FileType;

				CurrentFileType = sftd.SelectedFileType;
				int searchResult = SearchFileType(CurrentFileType);
				switch (searchResult)
				{
					case -1:
						Program.InfoMessageBox(String.Format("Unable to find any entries with filetype '{0}'.", sftd.SelectedFileType));
						break;

					case -2:
						Program.InfoMessageBox(String.Format("No more entries with filetype '{0}'.", sftd.SelectedFileType));
						break;

					default:
						PostSearch(searchResult);
						break;
				}
			}
		}

		private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			switch (CurrentSearchType)
			{
				case SearchType.Text:
					{
						if (CurrentSearchItemNumber == -1)
						{
							searchToolStripMenuItem_Click(sender, e);
						}

						int searchResult = SearchFile(CurrentSearchText);
						switch (searchResult)
						{
							case -1:
								Program.InfoMessageBox(String.Format("Unable to find any entries matching '{0}'.", CurrentSearchText));
								break;

							case -2:
								Program.InfoMessageBox(String.Format("No more entries matching '{0}'.", CurrentSearchText));
								break;

							default:
								PostSearch(searchResult);
								break;
						}
					}
					break;

				case SearchType.FileType:
					{
						if (CurrentSearchItemNumber == -1)
						{
							searchFileTypeToolStripMenuItem_Click(sender, e);
						}

						int searchResult = SearchFileType(CurrentFileType);
						switch (searchResult)
						{
							case -1:
								Program.InfoMessageBox(String.Format("Unable to find any entries with filetype '{0}'.", CurrentFileType));
								break;

							case -2:
								Program.InfoMessageBox(String.Format("No more entries with filetype '{0}'.", CurrentFileType));
								break;

							default:
								PostSearch(searchResult);
								break;
						}
					}
					break;
			}
		}
		#endregion

		#region Database Menu Items
		private void reloadFileTableDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// save previous position
			ListViewItem prevItem = lvFileList.FocusedItem;
			int prevIndex = 0;
			if (prevItem != null)
			{
				prevIndex = prevItem.Index;
			}

			ReloadFileTableDB();
			UpdateEntryList();

			// reload previous position
			lvFileList.EnsureVisible(prevIndex);
			lvFileList.FocusedItem = prevItem;
		}

		// only update CurrentSearchItemNumber if one item has been selected
		private void lvFileList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvFileList.SelectedItems.Count == 1 && CurrentSearchItemNumber != -1)
			{
				CurrentSearchItemNumber = lvFileList.SelectedIndices[0] + 1;
			}
		}

		/// <summary>
		/// Calculate stats for current FileTableDB.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fTDBInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// read relevant file from FileTableDB
			FileTableDB ftdb;

			string dbFilePath = Program.GetFileTableDBPath();
			// make sure it exists
			if (!File.Exists(dbFilePath))
			{
				// it doesn't
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
				uint labeledCount = 0;
				foreach (FileTableDBEntry entry in ftdb.Entries.Values)
				{
					if (!entry.Comment.Equals(String.Empty))
					{
						++labeledCount;
					}
				}
				Program.InfoMessageBox(String.Format("{0} entries labeled",labeledCount));
			}
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

		/// <summary>
		/// Export the FiileTable as a CSV file, meant for a conversion script.
		/// </summary>
		private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export CSV";
			sfd.Filter = SharedStrings.FileFilter_CSV;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
				StreamWriter sw = new StreamWriter(fs);
				Program.CurrentProject.ProjectFileTable.WriteConvertScript(sw);
				sw.Flush();
				sw.Close();
			}
		}

		/// <summary>
		/// Export the FileTable as a FileTableDB file.
		/// </summary>
		private void exportFileTableDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export FileTableDB";
			sfd.Filter = SharedStrings.FileFilter_Text;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						Program.CurrentProject.ProjectFileTable.WriteFTDB(sw);
						sw.Flush();
					}
				}
			}
		}

		private void exportJSONToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save FileTable JSON";
			sfd.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter sw = new StreamWriter(sfd.FileName, false))
				{
					Program.CurrentProject.ProjectFileTable.WriteJSON(sw);
				}
			}
		}
		#endregion

		private void lvFileList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			// xxx: hardcoded english and many assumptions
			string items = lvFileList.SelectedItems.Count == 1 ? "item" : "items";
			tssLabelSelectedItems.Text = String.Format("{0} {1} selected", lvFileList.SelectedItems.Count, items);
		}

		
	}
}
