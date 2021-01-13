using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio.GameSpecific.NoMercy
{
	// single selection (music, titantron, pictures)

	/// <summary>
	/// Groupless menu items (used for Music, Pictures, Titantron)
	/// </summary>
	public class MenuItems_NoGroup
	{
		// 0x00: number of total entries
		public byte NumEntries;

		public Dictionary<byte, string> Entries;

		public MenuItems_NoGroup()
		{
			NumEntries = 0;
			Entries = new Dictionary<byte, string>();
		}

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			NumEntries = br.ReadByte();

			Entries.Clear();
			for (int i = 0; i < NumEntries; i++)
			{
				byte key = br.ReadByte();
				string name = string.Empty;
				while (br.PeekChar() != 0)
				{
					name += br.ReadChar();
				}
				br.ReadByte();
				Entries.Add(key, name);
			}
		}

		public void WriteData(BinaryWriter bw)
		{
			bw.Write((byte)Entries.Count);
			foreach (KeyValuePair<byte,string> entry in Entries)
			{
				bw.Write(entry.Key);
				bw.Write(entry.Value.ToCharArray());
				bw.Write((byte)0);
			}
		}
		#endregion
	}
}
