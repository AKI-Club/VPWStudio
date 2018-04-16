using System;
using System.Collections.Generic;
using System.IO;
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

		/// <summary>
		/// Currently loaded GameSharkCodeFile.
		/// </summary>
		public static GameSharkCodeFile CurrentGSCodeFile = null;

		/// <summary>
		/// Path to currently loaded GameSharkCodeFile.
		/// </summary>
		public static string CurGSCFPath = String.Empty;
		#endregion

		/// <summary>
		/// Build log publisher.
		/// </summary>
		public static BuildLogEventPublisher BuildLogPub = new BuildLogEventPublisher();

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
			Application.Run(new MainForm(args));
		}

		#region Helpers
		/// <summary>
		/// Get the path to the default FileTableDB for the loaded game type.
		/// </summary>
		/// <returns></returns>
		public static string GetFileTableDBPath()
		{
			if (Program.CurrentProject == null)
			{
				return String.Empty;
			}

			string dbFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\FileTableDB\\";

			// special case: WWF WrestleMania 2000 NTSC-J has a different FileTable
			// than the NTSC-U and PAL versions... Haven't figured out the actual changes yet.
			if (Program.CurrentProject.Settings.GameType == SpecificGame.WM2K_NTSC_J)
			{
				dbFilePath += "WM2K-J.txt";
			}
			else
			{
				dbFilePath += String.Format("{0}.txt", CurrentProject.Settings.BaseGame.ToString());
			}

			return dbFilePath;
		}

		#region MessageBoxes
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
		#endregion

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
			FileTableEntry fte = Program.CurrentProject.ProjectFileTable.Entries[fileID];
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
									at.FromBitmap(bm);
									at.WriteData(bw);
								}
								else
								{
									// unsupported type for conversions
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
										return null;
									}
									ci4tex.WriteData(bw);
								}
								else
								{
									// unsupported type for conversions
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
										return null;
									}
									ci8tex.WriteData(bw);
								}
								else
								{
									// unsupported type for conversions
									return null;
								}
							}
							break;
						#endregion

						#region Ci4Palette Conversion
						case FileTypes.Ci4Palette:
							{
								if (ReplaceFileExtension == ".pal")
								{
									// todo: sub-palettes!!
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											Ci4Palette ci4pal = new Ci4Palette();
											if (!ci4pal.ImportJasc(sr))
											{
												return null;
											}
											ci4pal.WriteData(bw);
										}
									}
								}
								else
								{
									// unsupported type for conversions
									return null;
								}
							}
							break;
						#endregion

						#region Ci8Palette Conversion
						case FileTypes.Ci8Palette:
							{
								if (ReplaceFileExtension == ".pal")
								{
									using (FileStream fs = new FileStream(ReplaceFilePath, FileMode.Open))
									{
										using (StreamReader sr = new StreamReader(fs))
										{
											Ci8Palette ci8pal = new Ci8Palette();
											if (!ci8pal.ImportJasc(sr))
											{
												return null;
											}
											ci8pal.WriteData(bw);
										}
									}
								}
								else
								{
									// unsupported type for conversions
									return null;
								}
							}
							break;
						#endregion

						#region MenuBackground Conversion
						case FileTypes.MenuBackground:
							{
								if (ReplaceFileExtension == ".png")
								{
									System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
									MenuBackground mbg = new MenuBackground(-1, CurrentProject.Settings.BaseGame);
									if (!mbg.FromBitmap(bm))
									{
										return null;
									}
									return mbg.WriteData();
								}
								else
								{
									// unsupported type for conversions
									return null;
								}
							}
						#endregion

						// todo: other filetypes.

						#region AkiText Conversion
						case FileTypes.AkiText:
							{
								/*
								if (ReplaceFileExtension == ".csv")
								{
									// not implemented error
									return null;
								}
								else
								{
									// unsupported type for conversions
									return null;
								}
								*/
								return null;
							}
							//break;
						#endregion
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
		public static void BuildRom()
		{
			CurrentOutputROM = new Z64Rom();
			// The Output ROM may be bigger (or smaller!) than the Input ROM, so use a List.
			List<byte> outRomData = new List<byte>();
			// The Input ROM could have changed since the previous build, so reload it.
			CurrentInputROM.LoadFile(CurrentProject.Settings.InputRomPath);
			outRomData.AddRange(CurrentInputROM.Data);

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

			BuildLogPub.AddLine(String.Format("Internal Name: {0}", intName), true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
			BuildLogPub.AddLine();
			#endregion

			#region Product/Game Code
			// - game code
			string intCode = CurrentProject.Settings.OutputRomGameCode;
			if (intCode.Length != 4)
			{
				// error
			}
			if (!intCode.StartsWith("N"))
			{
				// not error, but fix
			}
			#endregion


			#region Filetable Changes
			// This portion of the Build ROM process is the most involved.
			// 0) Make a copy of the FileTable so the Project FileTable doesn't get changed.
			FileTable buildFileTable = new FileTable();
			buildFileTable.DeepCopy(CurrentProject.ProjectFileTable);

			// keep a running total of differences in file sizes.
			int totalDifference = 0;

			// special background parsing
			/*
			bool MenuBackgroundMode = false;
			int MenuBackgroundNumber = 0;
			MenuBackground CurMenuBackground = null;
			int MenuBgNumChunks = 0;
			int MenuBgChunkPixels = 0;
			*/

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

				// MenuBackgroundMode changes how this works; it would be simpler otherwise.
				/*
				// determine if we need to start MenuBackgroundMode
				if (fte.FileType == FileTypes.MenuBackground)
				{
					if (fte.ReplaceFilePath != null && !fte.ReplaceFilePath.Equals(String.Empty))
					{
						replaceFilePath = ConvertRelativePath(fte.ReplaceFilePath);
						if (replaceFilePath == null)
						{
							// unable to convert relative path
							MenuBackgroundMode = false;
							CurMenuBackground = null;
							MenuBgNumChunks = 0;
							MenuBgChunkPixels = 0;
							continue;
						}

						// ensure the file exists, otherwise we can't do anything.
						if (!File.Exists(replaceFilePath))
						{
							MenuBackgroundMode = false;
							CurMenuBackground = null;
							MenuBgNumChunks = 0;
							MenuBgChunkPixels = 0;
							continue;
						}

						outData = ConvertFile(fte.FileID);
						if (outData == null)
						{
							MenuBackgroundMode = false;
							CurMenuBackground = null;
							MenuBgNumChunks = 0;
							MenuBgChunkPixels = 0;
							continue;
						}

						MenuBackgroundMode = true;
						MenuBackgroundNumber = 0;

						CurMenuBackground = new MenuBackground(fte.FileID, CurrentProject.Settings.BaseGame);
						Array.Copy(outData, CurMenuBackground.Data, outData.Length);

						MenuBgNumChunks = CurMenuBackground.ChunkColumns * CurMenuBackground.ChunkRows;
						MenuBgChunkPixels = CurMenuBackground.ChunkWidth * CurMenuBackground.ChunkHeight;

						// todo: make this log message unique
						BuildLogPub.AddLine(String.Format("[File {0:X4}] Replace with {1}", i, replaceFilePath));
						BuildLogPub.AddLine(String.Format("Target FileType: {0} | LZSS = {1} | ReplaceEncoding = {2}",
						fte.FileType, fte.IsEncoded, fte.ReplaceEncoding));
					}
				}

				if (MenuBackgroundMode == true)
				{
					// handling menu background...

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

					//
					outData = CurMenuBackground.GetChunkBytes(MenuBackgroundNumber);

					// housekeeping
					MenuBackgroundNumber++;
					// perform check
					if (MenuBackgroundNumber == MenuBgNumChunks)
					{
						MenuBackgroundMode = false;
						CurMenuBackground = null;
					}
				}
				else
				{
					// continue as normal
				}
				*/

				// 0) check if a replacement file is set
				if (fte.ReplaceFilePath != null && !fte.ReplaceFilePath.Equals(String.Empty))
				{
					replaceFilePath = ConvertRelativePath(fte.ReplaceFilePath);
					if (replaceFilePath == null)
					{
						// unable to convert relative path
						continue;
					}

					// ensure the file exists, otherwise we can't do anything.
					if (!File.Exists(replaceFilePath))
					{
						continue;
					}

					BuildLogPub.AddLine(String.Format("[File {0:X4}] Replace with {1}", i, replaceFilePath), true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
					BuildLogPub.AddLine(String.Format("Target FileType: {0} | LZSS = {1} | ReplaceEncoding = {2}",
						fte.FileType, fte.IsEncoded, fte.ReplaceEncoding));

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
						if (Path.GetExtension(replaceFilePath) == FileTypeInfo.DefaultFileTypeExtensions[fte.FileType])
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
						BuildLogPub.AddLine("Unable to load replacement file data for this entry. Skipping.", true, BuildLogEventPublisher.BuildLogVerbosity.Minimal);
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

					BuildLogPub.AddLine();
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
				foreach (DefaultGameData.DefaultLocationDataEntry soundLoc in DefaultGameData.SoundOffsets[CurrentProject.Settings.GameType].Locations.Values)
				{
					FixAddresses(outRomData, (int)soundLoc.Offset, (int)(soundLoc.Offset + soundLoc.Length), totalDifference);
				}
				HasSoundLocations = true;
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
		}
		#endregion

	}
}
