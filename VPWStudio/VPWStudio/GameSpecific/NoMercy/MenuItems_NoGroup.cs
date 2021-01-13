using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio.GameSpecific.NoMercy
{
	// single selection (music, titantron, pictures) - simplest

	// simple format reading:
	// 1) read byte to get value
	// 2) read null/0x00 terminated string

	public class MenuItems_NoGroup
	{
		// byte 00: number of categories or total entries
		public byte NumCategories;
		// byte 01: number of total entries if nonzero
		public byte NumEntries;

		public List<string> Entries;

		public MenuItems_NoGroup()
		{
			NumCategories = 0;
			NumEntries = 0;
			Entries = new List<string>();
		}

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			NumCategories = br.ReadByte();
			NumEntries = br.ReadByte();
		}
		#endregion
	}
}
