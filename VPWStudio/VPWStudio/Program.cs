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
		#endregion

		#region ROM Building
		/// <summary>
		/// !!! OLD SHIT !!!
		/// </summary>
		public static void BuildRom()
		{
			// create output ROM using input ROM data as base.
			CurrentOutputROM = new Z64Rom();
			// output ROM may be bigger (or smaller!) than input ROM, so use a List.
			List<byte> outRomData = new List<byte>();
			outRomData.AddRange(CurrentInputROM.Data);

			// make changes based on the project file contents

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

			BuildLogPub.AddLine(String.Format("Internal Name: {0}", intName));
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

			#region FileTable
			// Work on a copy of the FileTable.
			// This prevents changes from being made to the Project's FileTable,
			// which messes up the rest of the program.
			FileTable buildFileTable = new FileTable();
			buildFileTable.DeepCopy(CurrentProject.ProjectFileTable);

			// todo: figure out how to properly handle the differences.

			// The total difference from all of the changed files.

			// In Zoinkity's original offsetter code, files are added one at a time,
			// with all relevant code addresses (e.g. WaveTables, PointerTables)
			// being updated on each change.

			// Here, we're remaking the entire FileTable at once,
			// saving the necessary code changes for later.
			int totalDifference = 0;

			// (File IDs start at 0x0001, and Entries is a SortedList with the file ID as Key.)
			for (int i = 1; i < buildFileTable.Entries.Count; i++)
			{
				FileTableEntry fte = buildFileTable.Entries[i];
				if (fte.ReplaceFilePath != String.Empty)
				{
					BuildLogPub.AddLine(String.Format("[File {0:X4}]", fte.FileID));
					/*
					FileTable.ReplaceFileReturnData rd = buildFileTable.ReplaceFile(outRomData, fte, CurProjectPath, CurrentProject.Settings.BaseGame);
					if (rd.ReturnCode >= 0)
					{
						// success
						totalDifference += rd.Difference;
					}
					else
					{
						// failed to replace this file.
						BuildLogPub.AddLine(String.Format("Failed to replace file ID {0:X4}; Return code: {1}", fte.FileID, rd.ReturnCode));
					}
					*/
				}
			}
			#endregion
		}

		#endregion

		#region CLEAR MY HEAD - new offsetter functionality section
		// Routines needed:
		// - overall build rom process
		// * convert file
		// - handle offsetting

		/*
		 * Where we're at - 2018/03/23 edition
		 * - Another attempt has been made to provide offsetter functionality. This is what, #3?
		 *   As expected, it has failed in the general sense. However, some things ARE confirmed
		 *   to work, so it's not an overall loss. Even still, it's better than the old code.
		 * - Notable issues include:
		 *  - inconsistent builds
		 *  - files getting fucked on every build after the first
		 *  - having to return the rom data every time you fix an address
		 */

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
		public static List<byte> FixAddresses(List<byte> romData, int addr1, int addr2, int difference)
		{
			// todo: implement this without streams
			/*
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
				int h = BitConverter.ToInt16(high, 0) << 16;

				byte[] low = new byte[]
				{
					romData[addr2],
					romData[addr2+1]
				};
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(low);
				}
				int v = h + BitConverter.ToInt16(low, 0);

				// add difference
				v += difference;
				h = (v >> 16);

				// perform correction
				if ((v & 0x8000) != 0)
				{
					h += 1;
				}

				// mask low
				int l = (v & 0xFFFF);

				// write new values

				byte[] high2 = BitConverter.GetBytes(h);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(high2);
				}
				romData[addr1] = high2[0];
				romData[addr1+1] = high2[1];

				byte[] low2 = BitConverter.GetBytes(l);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(low2);
				}
				romData[addr2] = low2[0];
				romData[addr2 + 1] = low2[1];
			}
			*/

			MemoryStream romStream = new MemoryStream(romData.ToArray());
			using (BinaryReader br = new BinaryReader(romStream))
			{
				using (BinaryWriter bw = new BinaryWriter(romStream))
				{
					// read values
					romStream.Seek(addr1, SeekOrigin.Begin);
					byte[] high = br.ReadBytes(2);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(high);
					}
					int h = BitConverter.ToInt16(high, 0) << 16;

					romStream.Seek(addr2, SeekOrigin.Begin);
					byte[] low = br.ReadBytes(2);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(low);
					}
					int v = h + BitConverter.ToInt16(low, 0);

					// add difference
					v += difference;
					h = (v >> 16);

					// perform correction
					if ((v & 0x8000) != 0)
					{
						h += 1;
					}

					// mask low
					int l = (v & 0xFFFF);

					// write new values
					romStream.Seek(addr1, SeekOrigin.Begin);
					byte[] newH = BitConverter.GetBytes((Int16)h);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(newH);
					}
					bw.Write(newH);

					romStream.Seek(addr2, SeekOrigin.Begin);
					byte[] newL = BitConverter.GetBytes((Int16)l);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(newL);
					}
					bw.Write(newL);

					return new List<byte>(romStream.ToArray());
				}
			}
		}

		/// <summary>
		/// (formerly ConvertData)
		/// </summary>
		/// <param name="fileID"></param>
		/// <returns></returns>
		/// this routine should only be called if the file extension is not "lzss" or the intended extension.
		/// todo: running this for FileTypes.Binary is dumb
		public static byte[] MotherfuckingConversion(int fileID)
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

						// todo: other filetypes.

						#region Ci4Palette Conversion
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

		public static void MotherfuckingBuildRom()
		{
			// the overall rom building process.

			// copy the input ROM to the output ROM
			CurrentOutputROM = new Z64Rom();
			// output ROM may be bigger (or smaller!) than input ROM, so use a List.
			List<byte> outRomData = new List<byte>();
			// the input rom could have changed between the last build and now,
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

			BuildLogPub.AddLine(String.Format("Internal Name: {0}", intName));
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

			// filetable shit
			// 0) make a copy
			FileTable buildFileTable = new FileTable();
			buildFileTable.DeepCopy(CurrentProject.ProjectFileTable);

			int totalDifference = 0;

			for (int i = 1; i < buildFileTable.Entries.Count; i++)
			{
				FileTableEntry fte = buildFileTable.Entries[i];
				// 0) check if a replacement file is set
				if (fte.ReplaceFilePath != String.Empty)
				{
					// determine if this is relative or absolute
					string replaceFilePath = fte.ReplaceFilePath;
					if (!Path.IsPathRooted(replaceFilePath))
					{
						replaceFilePath = String.Format("{0}\\{1}", Path.GetDirectoryName(CurProjectPath), fte.ReplaceFilePath);
					}

					// ensure the file exists, otherwise we can't do anything.
					if (!File.Exists(replaceFilePath))
					{
						continue;
					}

					BuildLogPub.AddLine(String.Format("[File {0:X4}] {1}", i, replaceFilePath));

					// get the start and end points of this entry
					// xxx: some files in WWF No Mercy's filetable break this assumption

					int start = buildFileTable.Entries[i].Location;
					int end = buildFileTable.Entries[i + 1].Location;
					int oldFileSize = (end - start);
					// todo: does this fix the assumption?
					if (start > end)
					{
						oldFileSize = start - end;
					}

					BuildLogPub.AddLine(String.Format("old location {0:X} ({1:X})",
						CurrentProject.ProjectFileTable.Entries[i].Location,
						CurrentProject.ProjectFileTable.Entries[i].Location + CurrentProject.ProjectFileTable.FirstFile
					));
					BuildLogPub.AddLine(String.Format("new location {0:X} ({1:X})",
						buildFileTable.Entries[i].Location,
						buildFileTable.Entries[i].Location + buildFileTable.FirstFile
					));

					// 1) use file extension to determine action
					byte[] outData = null;
					bool AlreadyCompressed = Path.GetExtension(replaceFilePath) == ".lzss";
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
							outData = MotherfuckingConversion(i);
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
						continue;
					}

					// 3) perform final transforms
					if (fte.ReplaceEncoding != FileTableReplaceEncoding.ForceRaw)
					{
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
					for (int j = i+1; j < buildFileTable.Entries.Count; j++)
					{
						buildFileTable.Entries[j].Location += difference;
					}

					if (difference > 0)
					{
						BuildLogPub.AddLine(String.Format("old file size {0} < new file size {1}", oldFileSize, finalOutData.Count));
					}
					else if (difference < 0)
					{
						BuildLogPub.AddLine(String.Format("old file size {0} > new file size {1}", oldFileSize, finalOutData.Count));
					}
					else
					{
						BuildLogPub.AddLine(String.Format("old file size {0} = new file size {1}", oldFileSize, finalOutData.Count));
					}

					// 5) motherfucking offset the data
					outRomData.RemoveRange((int)(start + CurrentProject.ProjectFileTable.FirstFile), oldFileSize);
					outRomData.InsertRange((int)(start + CurrentProject.ProjectFileTable.FirstFile), finalOutData);

					totalDifference += difference;
				}
			}

			// write new filetable data
			MemoryStream finalTableMS = new MemoryStream();
			BinaryWriter finalTableBW = new BinaryWriter(finalTableMS);
			buildFileTable.Write(finalTableBW);

			//outRomData

			BuildLogPub.AddLine(String.Format("old ft location {0:X}", CurrentProject.ProjectFileTable.Location));
			BuildLogPub.AddLine(String.Format("new ft location {0:X}", buildFileTable.Location + totalDifference));

			// rewrite filetable
			outRomData.RemoveRange((int)(CurrentProject.ProjectFileTable.Location + totalDifference), (CurrentProject.ProjectFileTable.Entries.Count * 4));
			outRomData.InsertRange((int)(CurrentProject.ProjectFileTable.Location + totalDifference), finalTableMS.ToArray());

			finalTableBW.Close();

			// update code offsets
			// xxx: hardcoded for vpw2

			// xxx2: very inefficient method that I wish I could fix
			// probably inline this, and then later, switch to a not terrible method

			// - filetable load
			outRomData = FixAddresses(outRomData, 0x48DA, 0x48DE, totalDifference);

			// - audio stuff
			outRomData = FixAddresses(outRomData, 0x432A, 0x432E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x4336, 0x433A, totalDifference);
			outRomData = FixAddresses(outRomData, 0x4366, 0x436A, totalDifference);
			outRomData = FixAddresses(outRomData, 0x436E, 0x4372, totalDifference);
			outRomData = FixAddresses(outRomData, 0x439A, 0x439E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x43A2, 0x43A6, totalDifference);
			outRomData = FixAddresses(outRomData, 0x43CE, 0x43D2, totalDifference);
			outRomData = FixAddresses(outRomData, 0x43D6, 0x43DA, totalDifference);
			outRomData = FixAddresses(outRomData, 0x4402, 0x4406, totalDifference);
			outRomData = FixAddresses(outRomData, 0x440A, 0x440E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x447A, 0x447E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x44DE, 0x44E6, totalDifference);
			outRomData = FixAddresses(outRomData, 0x4512, 0x451A, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17312, 0x17316, totalDifference);
			outRomData = FixAddresses(outRomData, 0x1731A, 0x1731E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x1732E, 0x17332, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17336, 0x1733A, totalDifference);
			outRomData = FixAddresses(outRomData, 0x173AE, 0x173B2, totalDifference);
			outRomData = FixAddresses(outRomData, 0x173B6, 0x173BA, totalDifference);
			outRomData = FixAddresses(outRomData, 0x173CA, 0x173CE, totalDifference);
			outRomData = FixAddresses(outRomData, 0x173D2, 0x173D6, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17466, 0x1746E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x174AE, 0x174B6, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17772, 0x17776, totalDifference);
			outRomData = FixAddresses(outRomData, 0x1777A, 0x1777E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x177A6, 0x177AA, totalDifference);
			outRomData = FixAddresses(outRomData, 0x177AE, 0x177B2, totalDifference);
			outRomData = FixAddresses(outRomData, 0x177EE, 0x177F6, totalDifference);
			outRomData = FixAddresses(outRomData, 0x179FA, 0x179FE, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A02, 0x17A06, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A22, 0x17A26, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A2A, 0x17A2E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A46, 0x17A4A, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A4E, 0x17A52, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A6A, 0x17A6E, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17A72, 0x17A76, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17B7A, 0x17B82, totalDifference);
			outRomData = FixAddresses(outRomData, 0x17B46, 0x17B4E, totalDifference);

			// now put it all together in one big ROM.
			#region Create Output ROM
			// determine if the new output ROM is too big to run on console
			/*
			if (outRomData.Count >= 0x4000000)
			{
				MessageBox.Show(
					"This ROM exceeds 512Mbits and *will not* run on console.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
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
		}
		#endregion
	}
}
