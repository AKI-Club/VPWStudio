using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	public class PackedArchiveEntry
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

		public PackedArchiveEntry(Int32 _addr)
		{
			this.StartAddr = _addr;
			this.Size = -1;
		}
	}

	/// <summary>
	/// An archive of files.
	/// </summary>
	public class PackedArchiveFile
	{
		// 0x00-0x03: number of entries
		// 0x04: entries begin; "DW aligned with 0xFFs"

		/// <summary>
		/// Number of files in this archive.
		/// </summary>
		public int NumFiles;

		public Dictionary<int, PackedArchiveEntry> FileEntries;

		public PackedArchiveFile()
		{
			this.NumFiles = 0;
			this.FileEntries = new Dictionary<int, PackedArchiveEntry>();
		}

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
			this.NumFiles = BitConverter.ToInt32(numFiles, 0);

			// get file offsets
			for (int i = 0; i < this.NumFiles; i++)
			{
				byte[] addr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(addr);
				}
				PackedArchiveEntry pae = new PackedArchiveEntry(BitConverter.ToInt32(addr, 0));
				this.FileEntries.Add(i, pae);
			}

			// todo: better size setting code.
			// * Some archives claim to have more files than they actually do.
			//   This is denoted by an address of 0...
			/*
			for (int i = 0; i < this.FileEntries.Count; i++)
			{
				if (this.FileEntries[i].StartAddr == 0)
				{
					this.FileEntries[i].Size = 0;
				}
				else
				{
					if (i < this.FileEntries.Count - 1)
					{
						if (this.FileEntries[i + 1].StartAddr > 0)
						{
							this.FileEntries[i].Size = this.FileEntries[i + 1].StartAddr - this.FileEntries[i].StartAddr;
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
			for (int i = (this.FileEntries.Count - 2); i > 0; i--)
			{
				if (this.FileEntries[i].StartAddr == 0)
				{
					this.FileEntries[i].Size = 0;
				}
				else
				{
					this.FileEntries[i].Size = this.FileEntries[i + 1].StartAddr - this.FileEntries[i].StartAddr;
				}
			}
			// index 0 requires a hack
			this.FileEntries[0].Size = this.FileEntries[1].StartAddr - this.FileEntries[0].StartAddr;

			// as does the last index...
			// however, there are issues regarding unused files...
			if (this.FileEntries[this.NumFiles - 1].StartAddr != 0)
			{
				br.BaseStream.Seek(0, SeekOrigin.End);
				long fileSize = br.BaseStream.Position;
				this.FileEntries[this.NumFiles - 1].Size = (int)(fileSize - this.FileEntries[this.NumFiles - 1].StartAddr);
			}

			// read data
			for (int i = 0; i < this.FileEntries.Count; i++)
			{
				br.BaseStream.Seek(this.FileEntries[i].StartAddr, SeekOrigin.Begin);
				this.FileEntries[i].Data = br.ReadBytes((int)this.FileEntries[i].Size);
			}

			br.Close();
		}

		public bool WriteFile(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);

			// number of files
			byte[] numFile = BitConverter.GetBytes(this.NumFiles);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numFile);
			}
			bw.Write(numFile);

			// file table
			for (int i = 0; i < this.NumFiles; i++)
			{
				byte[] addr = BitConverter.GetBytes(this.FileEntries[i].StartAddr);
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
			for (int i = 0; i < this.NumFiles; i++)
			{
				bw.Write(this.FileEntries[i].Data);
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

			bw.Write(this.FileEntries[_fileNum].Data);

			bw.Flush();
			bw.Close();
		}
	}
}
