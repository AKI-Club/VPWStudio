using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// An entry in an AKI Archive.
	/// </summary>
	public class AkiArchiveEntry
	{
		/// <summary>
		/// Start address in the archive.
		/// </summary>
		public Int32 StartAddr;

		/// <summary>
		/// Size of this file entry.
		/// </summary>
		public Int32 Size;

		/// <summary>
		/// Data from this file entry.
		/// </summary>
		public byte[] Data;

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="_addr">Address for this AkiArchiveEntry.</param>
		public AkiArchiveEntry(Int32 _addr)
		{
			StartAddr = _addr;
			Size = -1;
		}
	}

	/// <summary>
	/// An archive of files.
	/// </summary>
	public class AkiArchive
	{
		// 0x00-0x03: number of entries
		// 0x04: entries begin; "DW aligned with 0xFFs"

		/// <summary>
		/// Number of files in the archive, according to the header.
		/// </summary>
		/// How many files are actually in the archive is up for debate...
		public int NumFiles;

		/// <summary>
		/// Files in the archive.
		/// </summary>
		public Dictionary<int, AkiArchiveEntry> FileEntries;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiArchive()
		{
			NumFiles = 0;
			FileEntries = new Dictionary<int, AkiArchiveEntry>();
		}

		// routines in this section are incomplete.
		#region Binary Read/Write
		// somewhat implemented... not the best way of doing things?
		public void ReadData(BinaryReader br)
		{
			// get number of files
			byte[] numFiles = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numFiles);
			}
			NumFiles = BitConverter.ToInt32(numFiles, 0);

			// get file offsets
			for (int i = 0; i < NumFiles; i++)
			{
				byte[] addr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(addr);
				}
				FileEntries.Add(i, new AkiArchiveEntry(BitConverter.ToInt32(addr, 0)));
			}

			long curPos = br.BaseStream.Position;
			br.BaseStream.Seek(0, SeekOrigin.End);
			long arcLength = br.BaseStream.Position;
			br.BaseStream.Seek(curPos, SeekOrigin.Begin);

			// todo: everything else
			for (int i = 0; i < NumFiles; i++)
			{
				// go to location
				br.BaseStream.Seek(FileEntries[i].StartAddr, SeekOrigin.Begin);

				int fileSize = 0;
				// todo: start address of next entry may be behind this entry (e.g. when next entry is all 0)
				if (i < NumFiles - 1)
				{
					// find end point (start of next file)
					fileSize = FileEntries[i + 1].StartAddr - FileEntries[i].StartAddr;
				}
				else
				{
					// note: last file will use arcLength - curPos
					fileSize = (int)(arcLength - FileEntries[i].StartAddr);
				}

				// attempt to fix up certain archives
				if (fileSize < -1)
				{
					fileSize = (int)(arcLength - FileEntries[i].StartAddr);
					//Console.WriteLine(string.Format("new filesize for file {0}: {1}", i, fileSize));
				}
				// don't bother with 0-sized files.
				else if (fileSize == 0 || fileSize == -1)
				{
					continue;
				}

				// update size
				FileEntries[i].Size = fileSize;
				FileEntries[i].Data = br.ReadBytes(fileSize);
			}
		}

		// todo: copy and pasted from the file path version
		public void WriteData(BinaryWriter bw)
		{
			// number of files
			byte[] numFile = BitConverter.GetBytes(NumFiles);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numFile);
			}
			bw.Write(numFile);

			// file table
			for (int i = 0; i < NumFiles; i++)
			{
				byte[] addr = BitConverter.GetBytes(FileEntries[i].StartAddr);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(addr);
				}
				bw.Write(addr);
			}

			// export 0xFF bytes as needed to align to 0x00 and 0x08
			long alignTest = bw.BaseStream.Position & 0x0000000F;
			if (alignTest != 0 && alignTest != 8)
			{
				// determine where we are and how many bytes we need to fill.
				int fillCount = (8 - (int)alignTest);

				if (alignTest > 8)
				{
					fillCount = (16 - (int)alignTest);
				}

				for (int f = 0; f < fillCount; f++)
				{
					bw.Write((byte)0xFF);
				}
			}

			// write file data
			for (int i = 0; i < NumFiles; i++)
			{
				bw.Write(FileEntries[i].Data);
			}
		}
		#endregion

		#region old "to/from File" code
		/// <summary>
		/// Read a packed file archive.
		/// </summary>
		/// <param name="_path">Path to archive.</param>
		public void ReadFile(string _path)
		{
			FileStream fs = new FileStream(_path,FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			// get number of files
			byte[] numFiles = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numFiles);
			}
			NumFiles = BitConverter.ToInt32(numFiles, 0);

			// get file offsets
			for (int i = 0; i < NumFiles; i++)
			{
				byte[] addr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(addr);
				}
				FileEntries.Add(i, new AkiArchiveEntry(BitConverter.ToInt32(addr, 0)));
			}

			// todo: better size setting code.
			// * Some archives claim to have more files than they actually do.
			//   This is denoted by an address of 0...
			/*
			for (int i = 0; i < FileEntries.Count; i++)
			{
				if (FileEntries[i].StartAddr == 0)
				{
					FileEntries[i].Size = 0;
				}
				else
				{
					if (i < FileEntries.Count - 1)
					{
						if (FileEntries[i + 1].StartAddr > 0)
						{
							FileEntries[i].Size = FileEntries[i + 1].StartAddr - FileEntries[i].StartAddr;
						}
						else
						{
							// oh no
						}
					}
					else
					{
						// the last file
					}
				}
			}
			*/

			// old-ish code
			// set sizes for most files
			for (int i = (FileEntries.Count - 2); i > 0; i--)
			{
				if (FileEntries[i].StartAddr == 0)
				{
					FileEntries[i].Size = 0;
				}
				else
				{
					FileEntries[i].Size = FileEntries[i + 1].StartAddr - FileEntries[i].StartAddr;
				}
			}
			// index 0 requires a hack
			FileEntries[0].Size = FileEntries[1].StartAddr - FileEntries[0].StartAddr;

			// as does the last index...
			// however, there are issues regarding unused files...
			if (FileEntries[NumFiles - 1].StartAddr != 0)
			{
				br.BaseStream.Seek(0, SeekOrigin.End);
				long fileSize = br.BaseStream.Position;
				FileEntries[NumFiles - 1].Size = (int)(fileSize - FileEntries[NumFiles - 1].StartAddr);
			}

			// read data
			for (int i = 0; i < FileEntries.Count; i++)
			{
				br.BaseStream.Seek(FileEntries[i].StartAddr, SeekOrigin.Begin);
				FileEntries[i].Data = br.ReadBytes(FileEntries[i].Size);
			}

			br.Close();
		}

		public bool WriteFile(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);

			// number of files
			byte[] numFile = BitConverter.GetBytes(NumFiles);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numFile);
			}
			bw.Write(numFile);

			// file table
			for (int i = 0; i < NumFiles; i++)
			{
				byte[] addr = BitConverter.GetBytes(FileEntries[i].StartAddr);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(addr);
				}
				bw.Write(addr);
			}

			// export 0xFF bytes as needed to align to 0x00 and 0x08
			long alignTest = bw.BaseStream.Position & 0x0000000F;
			if (alignTest != 0 && alignTest != 8)
			{
				// determine where we are and how many bytes we need to fill.
				int fillCount = (8 - (int)alignTest);

				if (alignTest > 8)
				{
					fillCount = (16 - (int)alignTest);
				}

				for (int f = 0; f < fillCount; f++)
				{
					bw.Write((byte)0xFF);
				}
			}

			// write file data
			for (int i = 0; i < NumFiles; i++)
			{
				bw.Write(FileEntries[i].Data);
			}

			bw.Close();
			return true;
		}

		/// <summary>
		/// Extract a single file from the archive.
		/// </summary>
		/// <param name="_fileNum">File index to extract</param>
		/// <param name="_path">Output path</param>
		public void ExtractSingleFile(int _fileNum, string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);

			bw.Write(FileEntries[_fileNum].Data);

			bw.Flush();
			bw.Close();
		}
		#endregion
	}
}
