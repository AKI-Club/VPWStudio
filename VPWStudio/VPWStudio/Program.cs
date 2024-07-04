using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	static class Program
	{
		#region Program-Specific Variables

		#region Main Project File-related
		/// <summary>
		/// Current Project data.
		/// </summary>
		public static ProjectFile CurrentProject = null;

		/// <summary>
		/// Path to the Current Project file.
		/// </summary>
		public static string CurProjectPath = String.Empty;

		/// <summary>
		/// Are there unsaved changes to the current project?
		/// </summary>
		public static bool UnsavedChanges = false;

		/// <summary>
		/// Current input ROM file.
		/// </summary>
		public static Z64Rom CurrentInputROM = null;

		/// <summary>
		/// Current output ROM file.
		/// </summary>
		public static Z64Rom CurrentOutputROM = null;
		#endregion

		#region Project Sub-Files
		/// <summary>
		/// Currently loaded location file.
		/// </summary>
		public static LocationFile CurLocationFile = null;

		/// <summary>
		/// Path to Current Location File.
		/// </summary>
		public static string CurLocationFilePath = String.Empty;
		#endregion

		#region Project Build-related
		/// <summary>
		/// Are we in the process of building a ROM?
		/// </summary>
		public static bool RomBuildActive = false;

		/// <summary>
		/// Build log publisher.
		/// </summary>
		public static BuildLogEventPublisher BuildLogPub = new BuildLogEventPublisher();

		/// <summary>
		/// Build Warning and Error messages.
		/// </summary>
		public static List<BuildWarnErr> BuildMessages = new List<BuildWarnErr>();
		#endregion

		#region Dialog Managers
		/// <summary>
		/// HexViewer Manager
		/// </summary>
		public static HexViewerManager HexViewManager = new HexViewerManager();

		/// <summary>
		/// AkiTextEditor Manager
		/// </summary>
		//public static AkiTextEditorManager TextEditManager = new AkiTextEditorManager();
		#endregion

		/// <summary>
		/// Application main form, defined as a variable to get around some hacky crap
		/// regarding the HexViewerManager.
		/// </summary>
		public static MainForm AppMainForm;

		/// <summary>
		/// AkiArchive File Database.
		/// </summary>
		public static ArchiveFileDB AkiArchiveFileDB;

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Crc32.GenerateTable();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			AppMainForm = new MainForm(args);
			Application.Run(AppMainForm);
		}

		#region Helpers
		public static string GetVersionString()
		{
			return String.Format("v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
		}

		/// <summary>
		/// Special cases where a separate FileTableDB is required.
		/// </summary>
		static Dictionary<SpecificGame, string> FileTableDB_Overrides = new Dictionary<SpecificGame, string>()
		{
			// WWF WrestleMania 2000 NTSC-J
			{ SpecificGame.WM2K_NTSC_J, "WM2K-J.txt" },

			// WWF No Mercy (June 2000 E3 prototype)
			{ SpecificGame.NoMercy_Proto_NTSC_June2000, "NoMercy_Jun2000.txt" },

			// WWF No Mercy (July 2000 prototype)
			{ SpecificGame.NoMercy_Proto_NTSC_July2000, "NoMercy_Jul2000.txt" },

			// WWF No Mercy (August 2000 prototype)
			{ SpecificGame.NoMercy_Proto_NTSC_August2000, "NoMercy_Aug2000.txt" },

			// WWF No Mercy (September 2000 prototype)
			{ SpecificGame.NoMercy_Proto_NTSC_September2000, "NoMercy_Sep2000.txt" }
		};

		/// <summary>
		/// Get the path to the default FileTableDB for the loaded game type.
		/// </summary>
		/// <returns></returns>
		public static string GetFileTableDBPath()
		{
			if (CurrentProject == null)
			{
				return String.Empty;
			}

			if (Program.CurrentProject.Settings.UseCustomFileTableDB)
			{
				if (Path.IsPathRooted(Program.CurrentProject.Settings.CustomFileTableDBPath))
				{
					return Program.CurrentProject.Settings.CustomFileTableDBPath;
				}
				else
				{
					// path is not rooted. assume it's relative to the program's FileTableDB directory
					return String.Format("{0}\\FileTableDB\\{1}",
						Path.GetDirectoryName(Application.ExecutablePath),
						Program.CurrentProject.Settings.CustomFileTableDBPath);
				}
			}

			string dbFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\FileTableDB\\";

			if (FileTableDB_Overrides.ContainsKey(Program.CurrentProject.Settings.GameType))
			{
				dbFilePath += FileTableDB_Overrides[Program.CurrentProject.Settings.GameType];
			}
			else
			{
				dbFilePath += String.Format("{0}.txt", CurrentProject.Settings.BaseGame.ToString());
			}

			return dbFilePath;
		}

		/// <summary>
		/// Special cases where a separate ArchiveFileDB is required.
		/// </summary>
		/*
		static Dictionary<SpecificGame, string> ArchiveFileDB_Overrides = new Dictionary<SpecificGame, string>()
		{
			// WWF No Mercy (September 2000 prototype)
			//{ SpecificGame.NoMercy_Proto_NTSC_September2000, "NoMercy_Sep2000.txt" }
		};
		*/

		public static string GetArchiveFileDBPath()
		{
			if (CurrentProject == null)
			{
				return String.Empty;
			}

			string dbFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ArchiveFileDB\\";

			// xxx: does not handle override cases (No Mercy Sept. 2000 pre-release)
			dbFilePath += String.Format("{0}.txt", CurrentProject.Settings.BaseGame.ToString());

			return dbFilePath;
		}

		#region MessageBoxes
		/// <summary>
		/// Show an information message dialog.
		/// </summary>
		/// <param name="msg">Message to show.</param>
		public static void InfoMessageBox(string msg)
		{
			MessageBox.Show(msg, SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Show a warning message dialog.
		/// </summary>
		/// <param name="msg">Warning message to show.</param>
		public static void WarningMessageBox(string msg)
		{
			MessageBox.Show(msg, SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Show an error message dialog.
		/// </summary>
		/// <param name="msg">Error message to show.</param>
		public static void ErrorMessageBox(string msg)
		{
			MessageBox.Show(msg, SharedStrings.MainForm_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Show a Yes/No question dialog.
		/// </summary>
		/// <param name="msg">Question to ask.</param>
		/// <returns>True if the reply to the question was "Yes", false otherwise.</returns>
		public static bool QuestionMessageBox_YesNo(string msg, MessageBoxIcon icon)
		{
			return MessageBox.Show(msg, SharedStrings.MainForm_Title, MessageBoxButtons.YesNo, icon) == DialogResult.Yes;
		}
		#endregion

		#region Relative and Absolute Paths
		/// <summary>
		/// Convert a relative path to an absolute path using the current project file's path.
		/// </summary>
		/// <param name="relPath">Relative path to resolve.</param>
		/// <returns>Full path string, or null if Project Path not set.</returns>
		public static string ConvertRelativePath(string relPath)
		{
			// somehow already passed in an absolute path
			if (Path.IsPathRooted(relPath))
			{
				return relPath;
			}

			// We NEED the Project File to be saved to handle relative paths.
			if (CurProjectPath == null || CurProjectPath == String.Empty)
			{
				return null;
			}

			return String.Format("{0}\\{1}", Path.GetDirectoryName(CurProjectPath), relPath);
		}

		/// <summary>
		/// Attempt to shorten an absolute path to a project file-relative one.
		/// </summary>
		/// <param name="absPath">Absolute path to shorten.</param>
		/// <returns>Project File-relative path name, or null if unable to create one.</returns>
		public static string ShortenAbsolutePath(string absPath)
		{
			// somehow already passed in a relative path
			if (!Path.IsPathRooted(absPath))
			{
				return absPath;
			}

			// We NEED the Project File to be saved to handle relative paths.
			if (CurProjectPath == null || CurProjectPath == String.Empty)
			{
				return null;
			}

			// Check if it's even possible to convert this to a relative path
			if (!absPath.Contains(Path.GetDirectoryName(CurProjectPath)))
			{
				return null;
			}

			// if we've made it here, it SHOULD work.
			return absPath.Remove(0, Path.GetDirectoryName(CurProjectPath).Length+1);

		}
		#endregion

		#region Manual Helpers
		/// <summary>
		/// Attempt to launch the program Manual.
		/// </summary>
		public static void LaunchManual()
		{
			string manualPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Manual/index.html";
			if (!File.Exists(manualPath))
			{
				ErrorMessageBox("This is awkward... I can't find the Manual.\nIt should be located in the \"Manual\" folder as \"index.html\".");
				return;
			}

			System.Diagnostics.Process.Start(manualPath);

		}

		/// <summary>
		/// Launch game-specific documentation based on the currently opened project.
		/// </summary>
		public static void LaunchGameDoc()
		{
			if (CurrentProject != null)
			{
				string manualBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Manual/";
				string gameDocFile = string.Empty;
				switch (CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour: gameDocFile = "worldtour.html"; break;
					case VPWGames.VPW64:     gameDocFile = "vpw64.html"; break;
					case VPWGames.Revenge:   gameDocFile = "revenge.html"; break;
					case VPWGames.WM2K:      gameDocFile = "wm2k.html"; break;
					case VPWGames.VPW2:      gameDocFile = "vpw2.html"; break;
					case VPWGames.NoMercy:   gameDocFile = "nomercy.html"; break;

					case VPWGames.VPW:
					case VPWGames.WCWvsWorld:
						gameDocFile = "vpw_ps1.html";
						break;

					default:
						ErrorMessageBox(String.Format("Unknown BaseGame type {0}; no game-specific documentation available", CurrentProject.Settings.BaseGame.ToString()));
						break;
				}

				if (!gameDocFile.Equals(string.Empty))
				{
					string gameDocPath = Path.Combine(manualBasePath, gameDocFile);
					if (!File.Exists(gameDocPath))
					{
						ErrorMessageBox(string.Format("This is awkward... I can't find the game-specific documentation for {0}.\nIt should be located in the \"Manual\" folder as \"{1}\".", CurrentProject.Settings.BaseGame.ToString(), gameDocPath));
						return;
					}

					System.Diagnostics.Process.Start(manualBasePath + gameDocFile);
				}
			}
		}
		#endregion

		public static void ReloadBaseRom()
		{
			if (CurrentProject != null)
			{
				string baseRomPath = CurrentProject.Settings.InputRomPath;
				if (!Path.IsPathRooted(baseRomPath))
				{
					baseRomPath = String.Format("{0}\\{1}", Path.GetDirectoryName(Program.CurProjectPath), baseRomPath);
				}
				CurrentInputROM.LoadFile(baseRomPath);
			}
		}

		/// <summary>
		/// Get a slice of ROM data.
		/// </summary>
		/// <param name="offset">Offset to grab data from.</param>
		/// <param name="length">Length of data to grab.</param>
		/// <returns>Byte array with the requested data.</returns>
		public static byte[] GetRomSlice(int offset, int length)
		{
			byte[] slice = new byte[length];
			Array.Copy(CurrentInputROM.Data, offset, slice, 0, length);
			return slice;
		}

		/// <summary>
		/// Get a slice of data from a FileTable entry.
		/// </summary>
		/// <param name="fileID">File ID to get data slice of.</param>
		/// <param name="offset">Offset to grab data from.</param>
		/// <param name="length">Length of data to grab.</param>
		/// <returns>Byte array with the requested data.</returns>
		public static byte[] GetFileSlice(int fileID, int offset, int length)
		{
			byte[] slice = new byte[length];

			// need to extract file first
			MemoryStream romStream = new MemoryStream(CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(romStream);
			MemoryStream outData = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(outData);
			CurrentProject.ProjectFileTable.ExtractFile(br, bw, fileID);
			br.Close();

			// then do the other thing
			Array.Copy(outData.ToArray(), offset, slice, 0, length);
			bw.Close();

			return slice;
		}
		#endregion // helpers

		#region ROM Building
		/*
		 * addr2hws(a1, a2)
		 *     h = int.from_bytes(rom[a1:a1+2], byteorder='big') << 16
		 *     v = h + int.from_bytes(rom[a2:a2+2], byteorder='big')
		 *     v += difference;
		 *     h = (v>>16)
		 *     if(v & 0x8000) h += 1
		 *     l = v & 0xFFFF
		 *     rom[a1:a1+2] = h.to_bytes(2, byteorder='big')
		 *     rom[a2:a2+2] = l.to_bytes(2, byteorder='big')
		 */
		/// <summary>
		/// My version of Zoinkity's addr2hws.
		/// </summary>
		/// <param name="romData">ROM data</param>
		/// <param name="addr1">Address 1</param>
		/// <param name="addr2">Address 2</param>
		/// <param name="difference">Difference</param>
		public static void FixAddresses(List<byte> romData, int addr1, int addr2, int difference)
		{
			byte[] high = new byte[]
			{
				romData[addr1],
				romData[addr1+1]
			};
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(high);
			}
			Int32 h = BitConverter.ToInt16(high, 0) << 16;

			byte[] low = new byte[]
			{
				romData[addr2],
				romData[addr2+1]
			};
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(low);
			}
			Int32 v = h + BitConverter.ToInt16(low, 0);

			// add difference
			v += difference;
			h = (v >> 16);

			// perform correction
			if ((v & 0x8000) != 0)
			{
				h += 1;
			}

			// mask low
			Int16 l = (Int16)(v & 0xFFFF);

			// write new values

			byte[] high2 = BitConverter.GetBytes((Int16)h);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(high2);
			}
			romData[addr1] = high2[0];
			romData[addr1 + 1] = high2[1];

			byte[] low2 = BitConverter.GetBytes((Int16)l);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(low2);
			}
			romData[addr2] = low2[0];
			romData[addr2 + 1] = low2[1];
		}

		/// <summary>
		/// (todo)
		/// </summary>
		/// <param name="fileID"></param>
		/// <returns></returns>
		/// this routine should only be called if the file extension is not "lzss" or the intended extension.
		/// todo: running this for FileTypes.Binary is dumb
		public static byte[] ConvertFile(int fileID)
		{
			// Get replacement file information
			FileTableEntry fte = CurrentProject.ProjectFileTable.Entries[fileID];
			string ReplaceFileExtension = Path.GetExtension(fte.ReplaceFilePath);
			string ReplaceFilePath = fte.ReplaceFilePath;
			if (!Path.IsPathRooted(fte.ReplaceFilePath))
			{
				ReplaceFilePath = String.Format("{0}\\{1}", Path.GetDirectoryName(CurProjectPath), fte.ReplaceFilePath);
			}

			using (MemoryStream ms = new MemoryStream())
			{
				using (BinaryWriter bw = new BinaryWriter(ms))
				{
					// perform action based on filetype
					switch (fte.FileType)
					{
						#region AkiTexture conversion
						case FileTypes.AkiTexture:
							{
								if (ReplaceFileExtension == ".png")
								{
									AkiTexture at = new AkiTexture();
									System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);

									if (at.FromBitmap(bm))
									{
										at.WriteData(bw);
										bm.Dispose();
									}
									else
									{
										bm.Dispose();
										BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert image to AkiTexture."));
										return null;
									}
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported type '{0}' for AkiTexture conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						#endregion

						#region Ci4Texture conversion
						case FileTypes.Ci4Texture:
							{
								if (ReplaceFileExtension == ".png")
								{
									Ci4Texture ci4tex = new Ci4Texture();
									System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
									if (!ci4tex.FromBitmap(bm))
									{
										bm.Dispose();
										BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert image to Ci4Texture."));
										return null;
									}

									// todo: handle number of palette entries.
									// this is tricky...
									// we want to check if a replacement palette has been set
									/*
									if (fte.ExtraData.IntendedPaletteFileID != -1)
									{
										FileTableEntry palEntry = CurrentProject.ProjectFileTable.Entries[fte.ExtraData.IntendedPaletteFileID];
										if (palEntry.FileType == FileTypes.Ci4Palette)
										{
											// check if the path is valid
											string palPath = palEntry.ReplaceFilePath;
											if (!Path.IsPathRooted(palPath))
											{
												palPath = String.Format("{0}\\{1}", Path.GetDirectoryName(CurProjectPath), palEntry.ReplaceFilePath);
											}
										}
										else
										{
											// entry pointed to is not CI4 palette...
											// add warning, but don't stop build.
										}
									}
									*/

									// handle mirroring values
									if (fte.ExtraData.HorizMirror)
									{
										ci4tex.HorizMirror = 1;
									}
									if (fte.ExtraData.VertMirror)
									{
										ci4tex.VertMirror = 1;
									}

									ci4tex.WriteData(bw);
									bm.Dispose();
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported type '{0}' for Ci4Texture conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						
						// Ci4Background is Ci4Texture with pre-set header values
						case FileTypes.Ci4Background:
							{
								if (ReplaceFileExtension == ".png")
								{
									Ci4Texture ci4bg = new Ci4Texture();
									System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
									if (bm.Width != 320 && bm.Height != 240)
									{
										bm.Dispose();
										BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Ci4Backgrounds must have a resolution of 320x240."));
										return null;
									}

									if (!ci4bg.FromBitmap(bm))
									{
										bm.Dispose();
										BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert image to Ci4Background."));
										return null;
									}

									ci4bg.WriteCi4BackgroundData(bw);
									bm.Dispose();
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported type '{0}' for Ci4Background conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						#endregion

						#region Ci8Texture conversion
						case FileTypes.Ci8Texture:
							{
								if (ReplaceFileExtension == ".png")
								{
									Ci8Texture ci8tex = new Ci8Texture();
									System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
									if (!ci8tex.FromBitmap(bm))
									{
										bm.Dispose();
										BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert image to Ci8Texture."));
										return null;
									}

									// handle mirroring values
									if (fte.ExtraData.HorizMirror)
									{
										ci8tex.HorizMirror = 1;
									}
									if (fte.ExtraData.VertMirror)
									{
										ci8tex.VertMirror = 1;
									}

									ci8tex.WriteData(bw);
									bm.Dispose();
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported type '{0}' for Ci8Texture conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						#endregion

						#region Ci4Palette Conversion
						case FileTypes.Ci4Palette:
							{
								if (ReplaceFileExtension == ".vpwspal")
								{
									// VPW Studio Palette
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											Ci4Palette ci4pal = new Ci4Palette();
											if (!ci4pal.ImportVpwsPal(sr))
											{
												BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert VPW Studio palette to Ci4Palette."));
												return null;
											}
											ci4pal.WriteData(bw);
										}
									}
								}
								else if (ReplaceFileExtension == ".pal")
								{
									// JASC Paint Shop Pro Palette

									// todo: sub-palettes!!
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											Ci4Palette ci4pal = new Ci4Palette();
											if (!ci4pal.ImportJasc(sr))
											{
												BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert JASC PSP palette to Ci4Palette."));
												return null;
											}
											ci4pal.WriteData(bw);
										}
									}
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported type '{0}' for Ci4Palette conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						#endregion

						#region Ci8Palette Conversion
						case FileTypes.Ci8Palette:
							{
								if (ReplaceFileExtension == ".vpwspal")
								{
									// VPW Studio Palette
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											Ci8Palette ci8pal = new Ci8Palette();
											if (!ci8pal.ImportVpwsPal(sr))
											{
												BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert VPW Studio palette to Ci8Palette."));
												return null;
											}
											ci8pal.WriteData(bw);
										}
									}
								}
								else if (ReplaceFileExtension == ".pal")
								{
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											Ci8Palette ci8pal = new Ci8Palette();
											if (!ci8pal.ImportJasc(sr))
											{
												BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, "Unable to convert JASC PSP palette to Ci8Palette."));
												return null;
											}
											ci8pal.WriteData(bw);
										}
									}
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported type '{0}' for Ci8Palette conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						#endregion

						#region AkiText Conversion
						case FileTypes.AkiText:
							{
								if (ReplaceFileExtension == ".txt")
								{
									// akitext command line format
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											AkiText textArc = new AkiText();
											textArc.ReadToolImport(sr);
											textArc.WriteData(bw);
										}
									}
								}
								else if (ReplaceFileExtension == ".csv")
								{
									// zoinkity's tab-delimited csv format
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											AkiText textArc = new AkiText();
											textArc.ReadCsv(sr);
											textArc.WriteData(bw);
										}
									}
								}
								else
								{
									// unsupported type for conversions
									BuildMessages.Add(new BuildWarnErr(fte.FileID, BuildMessageTypes.Warning, String.Format("Unsupported filetype '{0}' for AkiText conversion.", ReplaceFileExtension)));
									return null;
								}
							}
							break;
						#endregion

						// todo: other filetypes.
					}

					// return data
					int outFileLen = (int)ms.Position;
					ms.Seek(0, SeekOrigin.Begin);
					byte[] outData = new byte[outFileLen];
					ms.Read(outData, 0, outFileLen);
					return outData;
				}
			}
		}

		/// <summary>
		/// Builds the Output ROM using the Input ROM as a base, applying changes as necessary.
		/// </summary>
		/// a.k.a. the giant fuckoff routine
		public static void BuildRom()
		{
			RomBuildActive = true;

			CurrentOutputROM = new Z64Rom();
			// The Output ROM may be bigger (or smaller!) than the Input ROM, so use a List.
			List<byte> outRomData = new List<byte>();
			// The Input ROM could have changed since the previous build, so reload it.
			string baseRomPath = CurrentProject.Settings.InputRomPath;
			if (!Path.IsPathRooted(baseRomPath))
			{
				baseRomPath = String.Format("{0}\\{1}", Path.GetDirectoryName(CurProjectPath), baseRomPath);
			}
			CurrentInputROM.LoadFile(baseRomPath);
			outRomData.AddRange(CurrentInputROM.Data);

			// Reset any build messages from a previous build.
			BuildMessages = new List<BuildWarnErr>();

			#region Internal Game Name
			string intName = CurrentProject.Settings.OutputRomInternalName;
			if (intName.Length > 20)
			{
				//  truncate
				intName = intName.Substring(0, 20);
			}
			else if (intName.Length < 20)
			{
				// pad
				intName = intName.PadRight(20);
			}

			byte[] nameBytes = Encoding.GetEncoding("Shift-JIS").GetBytes(intName);
			for (int i = 0; i < 20; i++)
			{
				outRomData[0x20 + i] = nameBytes[i];
			}

			BuildLogPub.AddLine(String.Format("Internal Name: {0}", intName), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
			#endregion

			#region ROM Region
			// offset 0x3E
			if (CurrentProject.Settings.OutputRomRegion == GameRegion.Custom)
			{
				outRomData[0x3E] = (byte)CurrentProject.Settings.OutputRomCustomRegion;
				BuildLogPub.AddLine(String.Format("Game Region: Custom ({0})", CurrentProject.Settings.OutputRomCustomRegion), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
			}
			else
			{
				outRomData[0x3E] = (byte)((char)CurrentProject.Settings.OutputRomRegion);
				BuildLogPub.AddLine(String.Format("Game Region: {0}", CurrentProject.Settings.OutputRomRegion), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
			}
			#endregion

			BuildLogPub.AddLine();

			#region non-FileTable Changes
			/*
			 * this is where changes should be written for items like...
			 * - Wrestler Definitions
			 * - Stable Definitions
			 * - Costume Definitions
			 * - Championship Belts
			 * - Story Mode
			 * - Menus
			 * - Arenas
			 * - Weapons
			 * and anything else not involving the FileTable.
			 */

			#region Wrestler Definitions
			if (!String.IsNullOrEmpty(CurrentProject.Settings.WrestlerDefinitionFilePath) &&
				File.Exists(ConvertRelativePath(CurrentProject.Settings.WrestlerDefinitionFilePath))
			){
				WrestlerDefFile wdf = new WrestlerDefFile();
				FileStream wdStream = new FileStream(ConvertRelativePath(CurrentProject.Settings.WrestlerDefinitionFilePath), FileMode.Open);
				StreamReader wdReader = new StreamReader(wdStream);
				wdf.ReadFile(wdReader);
				wdReader.Close();

				// make sure the external wrestlerdefs are for the right game
				if (wdf.GameType == CurrentProject.Settings.BaseGame)
				{
					// get wrestler def location in ROM
					bool hasLocation = false;
					int wrestlerDefLoc = 0;
					if (CurLocationFile != null)
					{
						LocationFileEntry wdEntry = CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["WrestlerDefs"]);
						if (wdEntry != null)
						{
							wrestlerDefLoc = (int)wdEntry.Address;
							hasLocation = true;
						}
					}
					if (!hasLocation)
					{
						// fallback to hardcoded offset
						wrestlerDefLoc = (int)DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["WrestlerDefs"].Offset;
					}

					// the per-game nightmare.
					MemoryStream ms = new MemoryStream(outRomData.ToArray());
					BinaryWriter bw = new BinaryWriter(ms);
					bw.Seek(wrestlerDefLoc, SeekOrigin.Begin);
					BuildLogPub.AddLine("Re-building wrestler data...", true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
					BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Minimal);

					bool writeData = false;

					// "WrestlerDefs" means something different based on the game.
					if (CurrentProject.Settings.BaseGame == VPWGames.VPW2 || CurrentProject.Settings.BaseGame == VPWGames.NoMercy)
					{
						// linear wrestler data: vpw2, no mercy
						switch (CurrentProject.Settings.BaseGame)
						{
							case VPWGames.VPW2:
								foreach (KeyValuePair<int, GameSpecific.VPW2.WrestlerDefinition> wdef in wdf.WrestlerDefs_VPW2)
								{
									wdef.Value.WriteData(bw);
								}
								writeData = true;
								break;

							case VPWGames.NoMercy:
								foreach (KeyValuePair<int, GameSpecific.NoMercy.WrestlerDefinition> wdef in wdf.WrestlerDefs_NoMercy)
								{
									wdef.Value.WriteData(bw);
								}
								writeData = true;
								break;
						}
					}
					else
					{
						// list of pointers to wrestler data: worldtour, vpw64, revenge, wm2k
						long curPos;
						int wrestlerCount = 0;
						switch (CurrentProject.Settings.BaseGame)
						{
							case VPWGames.WorldTour:
							case VPWGames.VPW64:
								wrestlerCount = wdf.WrestlerDefs_Early.Count;
								break;

							case VPWGames.Revenge:
								wrestlerCount = wdf.WrestlerDefs_Revenge.Count;
								break;

							case VPWGames.WM2K:
								wrestlerCount = wdf.WrestlerDefs_WM2K.Count;
								break;
						}

						if (wrestlerCount > 0)
						{
							for (int i = 0; i < wrestlerCount; i++)
							{
								// 1) get pointer value
								byte[] wPtr = new byte[4];
								bw.BaseStream.Read(wPtr, 0, 4);
								if (BitConverter.IsLittleEndian)
								{
									Array.Reverse(wPtr);
								}

								// 2) save current location in stream
								curPos = bw.BaseStream.Position;

								// 3) follow pointer
								bw.BaseStream.Seek(Z64Rom.PointerToRom(BitConverter.ToUInt32(wPtr, 0)), SeekOrigin.Begin);

								// 4) write data
								switch (CurrentProject.Settings.BaseGame)
								{
									case VPWGames.WorldTour:
									case VPWGames.VPW64:
										wdf.WrestlerDefs_Early[i].WriteData(bw);
										break;

									case VPWGames.Revenge:
										wdf.WrestlerDefs_Revenge[i].WriteData(bw);
										break;

									case VPWGames.WM2K:
										wdf.WrestlerDefs_WM2K[i].WriteData(bw);
										break;
								}

								// 5) restore location from step 2 before going back to step 1
								bw.BaseStream.Seek(curPos, SeekOrigin.Begin);
							}
							writeData = true;
						}
					}

					if (writeData)
					{
						outRomData = new List<byte>(ms.ToArray());
					}
					bw.Close();
				}
				else
				{
					BuildLogPub.AddLine(String.Format("Wrestler Definition file is for a different game. (Found '{0}', expected '{1}')", wdf.GameType, CurrentProject.Settings.BaseGame), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
					BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Quiet);
				}
			}
			#endregion

			#region Stable Definitions
			if (!String.IsNullOrEmpty(CurrentProject.Settings.StableDefinitionFilePath) &&
				File.Exists(ConvertRelativePath(CurrentProject.Settings.StableDefinitionFilePath))
			){
				StableDefFile sdf = new StableDefFile();
				FileStream sdStream = new FileStream(ConvertRelativePath(CurrentProject.Settings.StableDefinitionFilePath), FileMode.Open);
				StreamReader sdReader = new StreamReader(sdStream);
				sdf.ReadFile(sdReader);
				sdReader.Close();

				// make sure the external stabledefs are for the right game
				if (sdf.GameType == CurrentProject.Settings.BaseGame)
				{
					// get stable def location in ROM
					bool hasLocation = false;
					int stableDefLoc = 0;
					if (CurLocationFile != null)
					{
						LocationFileEntry sdEntry = CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StableDefs"]);
						if (sdEntry != null)
						{
							stableDefLoc = (int)sdEntry.Address;
							hasLocation = true;
						}
					}
					if (!hasLocation)
					{
						// fallback to hardcoded offset
						stableDefLoc = (int)DefaultGameData.DefaultLocations[CurrentProject.Settings.GameType].Locations["StableDefs"].Offset;
					}

					MemoryStream ms = new MemoryStream(outRomData.ToArray());
					BinaryWriter bw = new BinaryWriter(ms);
					bw.Seek(stableDefLoc, SeekOrigin.Begin);
					BuildLogPub.AddLine("Re-building stables...", true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
					BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Minimal);

					bool writeData = false;

					switch (CurrentProject.Settings.BaseGame)
					{
						case VPWGames.WM2K:
							foreach (KeyValuePair<int, GameSpecific.WM2K.StableDefinition> sdef in sdf.StableDefs_WM2K)
							{
								sdef.Value.WriteData(bw);
							}
							writeData = true;
							break;
						case VPWGames.VPW2:
							foreach (KeyValuePair<int, GameSpecific.VPW2.StableDefinition> sdef in sdf.StableDefs_VPW2)
							{
								sdef.Value.WriteData(bw);
							}
							writeData = true;
							break;
						case VPWGames.NoMercy:
							foreach (KeyValuePair<int, GameSpecific.NoMercy.StableDefinition> sdef in sdf.StableDefs_NoMercy)
							{
								sdef.Value.WriteData(bw);
							}
							writeData = true;
							break;
						default:
							BuildLogPub.AddLine(String.Format("Stable re-building not yet implemented for {0}.", CurrentProject.Settings.BaseGame), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
							BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Quiet);
							break;
					}

					if (writeData)
					{
						outRomData = new List<byte>(ms.ToArray());
					}
					bw.Close();
				}
				else
				{
					BuildLogPub.AddLine(String.Format("Stable Definition file is for a different game. (Found '{0}', expected '{1}')", sdf.GameType, CurrentProject.Settings.BaseGame), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
					BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Quiet);
				}
			}
			#endregion

			#endregion

			#region Filetable Changes
			// This portion of the Build ROM process is the most involved.
			// 0) Make a copy of the FileTable so the Project FileTable doesn't get changed.
			FileTable buildFileTable = new FileTable();
			buildFileTable.DeepCopy(CurrentProject.ProjectFileTable);

			// keep a running total of differences in file sizes.
			int totalDifference = 0;

			// (File IDs start at 0x0001, and Entries is a SortedList with the file ID as Key.)
			for (int i = 1; i <= buildFileTable.Entries.Count; i++)
			{
				FileTableEntry fte = buildFileTable.Entries[i];
				byte[] outData = null;
				bool AlreadyCompressed = false;
				string replaceFilePath = String.Empty;
				int start = 0;
				int end = 0;
				int oldFileSize = 0;
				
				// 0) check if a replacement file is set
				if (fte.ReplaceFilePath != null && !fte.ReplaceFilePath.Equals(String.Empty))
				{
					replaceFilePath = ConvertRelativePath(fte.ReplaceFilePath);
					if (replaceFilePath == null)
					{
						// unable to convert relative path
						BuildLogPub.AddLine(String.Format("[File {0:X4}] Error: Unable to convert '{1}' to relative path; skipping.", i, fte.ReplaceFilePath), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
						continue;
					}

					// ensure the file exists, otherwise we can't do anything.
					if (!File.Exists(replaceFilePath))
					{
						BuildLogPub.AddLine(String.Format("[File {0:X4}] Error: Replacement file '{1}' does not exist; skipping.", i, replaceFilePath), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
						continue;
					}

					BuildLogPub.AddLine(String.Format("[File {0:X4}] Replace with {1}", i, replaceFilePath), true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
					BuildLogPub.AddLine(String.Format("Target FileType: {0} | LZSS = {1} | ReplaceEncoding = {2}", fte.FileType, fte.IsEncoded, fte.ReplaceEncoding), true, BuildLogEventPublisher.BuildLogVerbosity.Normal);

					// get the start and end points of this entry
					// xxx: some files in WWF No Mercy's filetable break this assumption
					start = fte.Location;
					end = buildFileTable.Entries[i + 1].Location;
					oldFileSize = buildFileTable.GetEntrySize(i);
					// todo: does this fix the assumption?
					if (start > end)
					{
						oldFileSize = start - end;
					}

					BuildLogPub.AddLine(String.Format("old location {0:X} ({1:X})",
						CurrentProject.ProjectFileTable.Entries[i].Location,
						CurrentProject.ProjectFileTable.Entries[i].Location + CurrentProject.ProjectFileTable.FirstFile
					), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
					BuildLogPub.AddLine(String.Format("new location {0:X} ({1:X})",
						buildFileTable.Entries[i].Location,
						buildFileTable.Entries[i].Location + buildFileTable.FirstFile
					), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);

					// 1) use file extension to determine action
					outData = null;
					AlreadyCompressed = Path.GetExtension(replaceFilePath) == ".lzss";
					if (!AlreadyCompressed)
					{
						// hacks:
						// - read MenuBackground as binary.
						// - if a file lacks an extension, treat it as binary.
						if (Path.GetExtension(replaceFilePath) == FileTypeInfo.DefaultFileTypeExtensions[fte.FileType]
							|| fte.FileType == FileTypes.MenuBackground
							|| Path.GetExtension(replaceFilePath) == String.Empty)
						{
							// matched type, read raw data
							using (FileStream fs = new FileStream(replaceFilePath, FileMode.Open))
							{
								using (BinaryReader br = new BinaryReader(fs))
								{
									fs.Seek(0, SeekOrigin.End);
									int fileLen = (int)fs.Position;
									fs.Seek(0, SeekOrigin.Begin);
									outData = br.ReadBytes(fileLen);
								}
							}
						}
						else
						{
							// try conversion
							outData = ConvertFile(i);
						}
					}
					else
					{
						// read pre-LZSS'd data
						using (FileStream fs = new FileStream(replaceFilePath, FileMode.Open))
						{
							using (BinaryReader br = new BinaryReader(fs))
							{
								fs.Seek(0, SeekOrigin.End);
								int fileLen = (int)fs.Position;
								fs.Seek(0, SeekOrigin.Begin);
								outData = br.ReadBytes(fileLen);
							}
						}
					}

					// if we were unable to get output data, then there's no point in continuing.
					if (outData == null)
					{
						BuildLogPub.AddLine(String.Format("[File {0:X4}] Error: Unable to load replacement file data for this entry; skipping.", i), true, BuildLogEventPublisher.BuildLogVerbosity.Quiet);
						continue;
					}

					// 3) perform final transforms
					if (fte.ReplaceEncoding != FileTableReplaceEncoding.ForceRaw)
					{
						// xxx: this condition is not final but it's better than it was before
						if (!AlreadyCompressed)
						{
							// LZSS it
							MemoryStream inFileMS = new MemoryStream(outData);
							BinaryReader inFileBR = new BinaryReader(inFileMS);

							MemoryStream lzssMS = new MemoryStream();
							BinaryWriter lzssBW = new BinaryWriter(lzssMS);

							AsmikLzss.Encode(inFileBR, lzssBW);
							lzssBW.Flush();
							inFileBR.Close();
							outData = lzssMS.ToArray();
							lzssBW.Close();
							fte.IsEncoded = true;
						}
					}

					// create final output data and add 0x00 pad byte if needed
					List<byte> finalOutData = new List<byte>(outData);
					if ((finalOutData.Count % 2) != 0)
					{
						finalOutData.Add(0);
					}

					// 4) fix up filetable refs
					int difference = (finalOutData.Count - oldFileSize);
					//BuildLogPub.AddLine(String.Format("old file/new file difference: {0}", difference));
					for (int j = i + 1; j <= buildFileTable.Entries.Count; j++)
					{
						buildFileTable.Entries[j].Location += difference;
					}
					totalDifference += difference;

					if (difference > 0)
					{
						BuildLogPub.AddLine(String.Format("old file size {0} < new file size {1}", oldFileSize, finalOutData.Count), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
					}
					else if (difference < 0)
					{
						BuildLogPub.AddLine(String.Format("old file size {0} > new file size {1}", oldFileSize, finalOutData.Count), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
					}
					else
					{
						BuildLogPub.AddLine(String.Format("old file size {0} = new file size {1}", oldFileSize, finalOutData.Count), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
					}

					// 5) offset the data
					outRomData.RemoveRange((int)(start + CurrentProject.ProjectFileTable.FirstFile), oldFileSize);
					outRomData.InsertRange((int)(start + CurrentProject.ProjectFileTable.FirstFile), finalOutData);

					BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Minimal);
				}
			}

			// write new filetable data
			MemoryStream finalTableMS = new MemoryStream();
			BinaryWriter finalTableBW = new BinaryWriter(finalTableMS);
			buildFileTable.Write(finalTableBW);

			BuildLogPub.AddLine(String.Format("TotalDifference final: {0}", totalDifference), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
			BuildLogPub.AddLine(String.Format("old ft location {0:X}", CurrentProject.ProjectFileTable.Location), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
			BuildLogPub.AddLine(String.Format("new ft location {0:X}", buildFileTable.Location + totalDifference), true, BuildLogEventPublisher.BuildLogVerbosity.Detailed);
			BuildLogPub.AddLine(BuildLogEventPublisher.BuildLogVerbosity.Detailed);

			// rewrite filetable
			outRomData.RemoveRange((int)(CurrentProject.ProjectFileTable.Location + totalDifference), (CurrentProject.ProjectFileTable.Entries.Count * 4));
			outRomData.InsertRange((int)(CurrentProject.ProjectFileTable.Location + totalDifference), finalTableMS.ToArray());

			finalTableBW.Close();
			#endregion

			#region Update Game Code
			bool FoundFileTableLocValues = false;
			bool HasSoundLocations = false;

			bool NeedsCodeLoadChanges = (CurrentProject.Settings.BaseGame == VPWGames.VPW64 || CurrentProject.Settings.BaseGame == VPWGames.WorldTour);
			bool HasCodeLoadChanges = false;

			if (CurLocationFile != null)
			{
				// try getting addresses from the Location File.

				#region SetupFiletable
				LocationFileEntry ftLoc = CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["SetupFileTable_FtLocation"]);
				if (ftLoc != null)
				{
					// use %SETUPFT_FTLOCATION
					FoundFileTableLocValues = true;
					FixAddresses(outRomData, (int)(ftLoc.Address), (int)(ftLoc.Address + ftLoc.Length), totalDifference);
				}
				#endregion

				#region GetFileLocation
				// todo: we don't currently support adding/removing entries from the filetable.
				#endregion

				#region LoadFile
				// todo: we don't currently support adding/removing entries from the filetable.
				#endregion

				#region Audio Stuff
				// and then deal with all the audio junk, which is different per-game...
				List<LocationFileEntry> SoundEntries = CurLocationFile.GetSoundEntries();
				if (SoundEntries.Count > 0)
				{
					foreach (LocationFileEntry lfe in SoundEntries)
					{
						FixAddresses(outRomData, (int)lfe.Address, (int)(lfe.Address + lfe.Length), totalDifference);
					}
					HasSoundLocations = true;
				}
				else
				{
					HasSoundLocations = false;
				}
				#endregion

				// fixing up World Tour and VPW64, location file
				if (NeedsCodeLoadChanges)
				{
					// RelocatableCodeAddress1 through RelocatableCodeAddress4
					List<LocationFileEntry> RcaEntries = CurLocationFile.GetEntriesStartingWith("%RELOCATABLECODEADDRESS");
					if (RcaEntries.Count > 0)
					{
						foreach (LocationFileEntry lfe in RcaEntries)
						{
							byte[] loc = outRomData.GetRange((int)lfe.Address, (int)lfe.Length).ToArray();
							if (BitConverter.IsLittleEndian)
							{
								Array.Reverse(loc);
							}
							int codeLoc1 = BitConverter.ToInt32(loc, 0) + totalDifference;
							loc = BitConverter.GetBytes(codeLoc1);
							if (BitConverter.IsLittleEndian)
							{
								Array.Reverse(loc);
							}
							int startOffset = (int)lfe.Address;
							outRomData[startOffset] = loc[0];
							outRomData[startOffset + 1] = loc[1];
							outRomData[startOffset + 2] = loc[2];
							outRomData[startOffset + 3] = loc[3];
						}

						HasCodeLoadChanges = true;
					}
					else
					{
						HasCodeLoadChanges = false;
					}
				}
			}

			// didn't find anything from the location file; use hardcoded values (ugh)
			if (!FoundFileTableLocValues)
			{
				// [SetupFiletable]
				// fix filetable location
				DefaultGameData.DefaultLocationDataEntry dlde = DefaultGameData.DefaultLocations[CurrentProject.Settings.GameType].Locations["SetupFT_FTLocation"];
				FixAddresses(outRomData, (int)dlde.Offset, (int)(dlde.Offset + dlde.Length), totalDifference);

				// [GetFileLocation]
				// todo: we don't currently support adding/removing entries from the filetable.

				// [LoadFile]
				// todo: we don't currently support adding/removing entries from the filetable.
			}

			// didn't find audio information from LocationFile; use hardcoded values.
			if (!HasSoundLocations)
			{
				// [Audio Stuff]
				if (DefaultGameData.SoundOffsets[CurrentProject.Settings.GameType].Locations.Count > 0)
				{
					foreach (DefaultGameData.DefaultLocationDataEntry soundLoc in DefaultGameData.SoundOffsets[CurrentProject.Settings.GameType].Locations.Values)
					{
						FixAddresses(outRomData, (int)soundLoc.Offset, (int)(soundLoc.Offset + soundLoc.Length), totalDifference);
					}
					HasSoundLocations = true;
				}
				else
				{
					HasSoundLocations = false;
				}
			}

			// requires RelocatableCodeAddress entries in LocationFile but didn't find any; use hardcoded values.
			if (NeedsCodeLoadChanges && !HasCodeLoadChanges)
			{
				foreach (DefaultGameData.DefaultLocationDataEntry dlde in DefaultGameData.GetEntriesStartingWith(CurrentProject.Settings.GameType, "RelocatableCodeAddress"))
				{
					if (dlde != null)
					{
						byte[] loc = outRomData.GetRange((int)dlde.Offset, (int)dlde.Length).ToArray();
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(loc);
						}
						int codeLoc1 = BitConverter.ToInt32(loc, 0) + totalDifference;
						loc = BitConverter.GetBytes(codeLoc1);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(loc);
						}
						int startOffset = (int)dlde.Offset;
						outRomData[startOffset] = loc[0];
						outRomData[startOffset + 1] = loc[1];
						outRomData[startOffset + 2] = loc[2];
						outRomData[startOffset + 3] = loc[3];
					}
				}
			}
			#endregion

			// now put it all together in one big ROM.
			#region Create Output ROM
			// determine if the new output ROM is too big to run on console
			if (outRomData.Count >= 0x4000000)
			{
				BuildLogPub.AddLine("WARNING: This ROM exceeds 512Mbits and *will not* run on console.", true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
			}

			// BIG TODO: pad ROM to proper boundary
			// ...how do we determine that, exactly?

			// todo2: we don't properly support 64M ROMs because there weren't any AKI games released using 64M ROMs

			// todo3: it's possible to build a ROM that goes past these limits, but shouldn't be doing so...

			/*
			if (outRomData.Count > 0x1000000 && outRomData.Count < 0x2000000)
			{
				// 32M (WM2K, VPW2, No Mercy) | 0x2000000
				int diff = 0x2000000 - outRomData.Count;
				for (int i = 0; i < diff; i++)
				{
					outRomData.Add(0xFF);
				}
			}
			else if (outRomData.Count > 0xC00000 && outRomData.Count < 0x1000000)
			{
				// 16M (VPW64, Revenge) | 0x1000000
				int diff = 0x1000000 - outRomData.Count;
				for (int i = 0; i < diff; i++)
				{
					outRomData.Add(0xFF);
				}
			}
			else if(outRomData.Count < 0xC00000)
			{
				// 12M (World Tour) | 0xC00000
			}
			*/

			// write outRomData to Program.CurrentOutputROM.Data
			CurrentOutputROM.Data = outRomData.ToArray();

			// fix checksums
			CurrentOutputROM.FixChecksums();

			// determine output ROM path (may be relative to project file)
			string outRomPath = CurrentProject.Settings.OutputRomPath;
			string prevWorkDir = Environment.CurrentDirectory;
			bool resetWorkDir = false;
			if (!Path.IsPathRooted(outRomPath))
			{
				Environment.CurrentDirectory = Path.GetDirectoryName(CurProjectPath);
				resetWorkDir = true;
			}

			// write ROM
			FileStream outRomFS = new FileStream(outRomPath, FileMode.Create);
			BinaryWriter outRomBW = new BinaryWriter(outRomFS);
			outRomBW.Write(CurrentOutputROM.Data);
			outRomBW.Flush();
			outRomBW.Dispose();

			if (resetWorkDir)
			{
				Environment.CurrentDirectory = prevWorkDir;
			}
			#endregion

			RomBuildActive = false;
		}
		#endregion

	}
}
