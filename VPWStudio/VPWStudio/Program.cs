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
		// this routine should only be called if the file extension is not "lzss" or the intended extension.
		// todo: running this for FileTypes.Binary is dumb
		public static byte[] ConvertData(FileTableEntry fte)
		{
			// Get replacement file information
			string ReplaceFileExtension = Path.GetExtension(fte.ReplaceFilePath);
			string ReplaceFilePath = fte.ReplaceFilePath;
			if (!Path.IsPathRooted(fte.ReplaceFilePath))
			{
				ReplaceFilePath = String.Format("{0}\\{1}", Path.GetDirectoryName(CurProjectPath), fte.ReplaceFilePath);
			}

			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);

			// perform action based on filetype
			switch (fte.FileType)
			{
				case FileTypes.AkiTexture:
					{
						if (ReplaceFileExtension == "png")
						{
							AkiTexture at = new AkiTexture();
							System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
							at.FromBitmap(bm);
							at.WriteData(bw);
						}
					}
					break;

				case FileTypes.Ci4Texture:
					{
						if (ReplaceFileExtension == "png")
						{
							Ci4Texture ci4tex = new Ci4Texture();
							System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
							if (!ci4tex.FromBitmap(bm))
							{
								return null;
							}
							ci4tex.WriteData(bw);
						}
					}
					break;

				case FileTypes.Ci8Texture:
					{
						if (ReplaceFileExtension == "png")
						{
							Ci8Texture ci8tex = new Ci8Texture();
							System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ReplaceFilePath);
							if (!ci8tex.FromBitmap(bm))
							{
								return null;
							}
							ci8tex.WriteData(bw);
						}
					}
					break;
			}

			// return data
			int outFileLen = (int)ms.Position;
			ms.Seek(0, SeekOrigin.Begin);
			byte[] outData = new byte[outFileLen];
			ms.Read(outData, 0, outFileLen);
			return outData;
		}

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
				}
			}
			#endregion
		}

		#endregion
	}
}
