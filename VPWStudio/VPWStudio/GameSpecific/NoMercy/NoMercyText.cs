using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.NoMercy
{
	public class NoMercyText
	{
		// byte 00: number of entries
		// then each entry follows.
		public List<string> Entries;

		public NoMercyText()
		{
			Entries = new List<string>();
		}

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			int numEntries = br.ReadByte();
			// 20 00 00 00 - ??
			// 00 87 FF FF - ??
			// 00 0A - related to string length?

			// 20 00 00 00
			// 00 8F FF FF
			// 00 1E

			// 21 00 00 00
			// 00 67 FF FF
			// 00 28
		}
		#endregion
	}
}
