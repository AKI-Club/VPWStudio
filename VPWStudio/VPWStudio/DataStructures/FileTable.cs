using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
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
	}

	public class FileTable
	{
	}
}
