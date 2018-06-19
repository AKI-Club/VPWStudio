using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.NoMercy
{
	// todo: which format will this be used for?
	// * single selection (music, titantron, pictures) - simplest
	// * multiple selection (costume items, smackdown mall) - harder, can involve sections (costume items)
	// * a shitton of files for moves, which need a different format from the above two.

	// simple format reading:
	// 1) read byte to get value
	// 2) read null/0x00 terminated string

	public class NoMercyText
	{
		// byte 00: number of categories or total entries
		public byte NumCategories;
		// byte 01: number of total entries if nonzero
		public byte NumEntries;

		public List<string> Entries;

		public NoMercyText()
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
