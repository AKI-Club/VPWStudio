using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// A single entry in the filetable.
	/// </summary>
	public class FileTableEntry
	{
		/// <summary>
		/// Location of this file (relative to the beginning of the files).
		/// </summary>
		public UInt32 Location;

		/// <summary>
		/// Is this file encoded?
		/// </summary>
		public bool IsEncoded;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableEntry()
		{
			this.Location = 0;
			this.IsEncoded = false;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_loc">Location (do not add 1 for encoded files)</param>
		/// <param name="_enc">Is this file (LZSS) encoded?</param>
		public FileTableEntry(UInt32 _loc, bool _enc)
		{
			this.Location = _loc;
			this.IsEncoded = _enc;
		}

		public FileTableEntry(BinaryReader br)
		{
			this.ReadEntry(br);
		}

		public void ReadEntry(BinaryReader br)
		{
			byte[] loc = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(loc);
			}
			this.Location = (BitConverter.ToUInt32(loc, 0) & 0xFFFFFFFE);
			this.IsEncoded = (BitConverter.ToUInt32(loc, 0) & 1) != 0;
		}

		public void WriteEntry(BinaryWriter bw)
		{
			UInt32 finalLoc = this.Location;
			if (this.IsEncoded)
			{
				finalLoc |= 1;
			}

			byte[] loc = BitConverter.GetBytes(finalLoc);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(loc);
			}
			bw.Write(loc);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class FileTable
	{
		/// <summary>
		/// Entries in this filetable.
		/// </summary>
		public SortedList<int, FileTableEntry> Entries = new SortedList<int, FileTableEntry>();

		public FileTable()
		{
		}

		public void Load(BinaryReader br, int size)
		{
			// number of entries = size >> 2;
			for (int i = 1; i < size >> 2; i++)
			{
				this.Entries.Add(i, new FileTableEntry(br));
			}
		}
	}
}
