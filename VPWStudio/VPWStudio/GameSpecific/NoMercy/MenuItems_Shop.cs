using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.NoMercy
{
	// todo: each entry has:
	// 10? bytes of unknown data
	// string for name
	// string for item type
	public struct ShopItemEntry
	{
		public byte[] HeaderData;
		public string ItemName;
		public string ItemDescription;

		public void ReadData(BinaryReader br)
		{
			HeaderData = br.ReadBytes(10);

			ItemName = string.Empty;
			while (br.PeekChar() != 0)
			{
				ItemName += br.ReadChar();
			}

			br.ReadByte();

			ItemDescription = string.Empty;
			while (br.PeekChar() != 0)
			{
				ItemDescription += br.ReadChar();
			}

			br.ReadByte();
		}

		public void WriteData(BinaryWriter bw)
		{
			bw.Write(HeaderData);
			bw.Write(ItemName.ToCharArray());
			bw.Write(ItemDescription.ToCharArray());
		}
	}

	/// <summary>
	/// WWF No Mercy Shop Item Lists.
	/// </summary>
	/// File IDs: 4AA9 to 4AAB, inclusive
	public class MenuItems_Shop
	{
		/// <summary>
		/// Number of entries in this menu.
		/// </summary>
		public byte NumEntries;

		/// <summary>
		/// Actual entries in this menu.
		/// </summary>
		public List<ShopItemEntry> Entries;

		public MenuItems_Shop()
		{
			Entries = new List<ShopItemEntry>();
			NumEntries = (byte)Entries.Count;
		}

		public void ReadData(BinaryReader br)
		{
			NumEntries = br.ReadByte();
			ShopItemEntry sie = new ShopItemEntry();
			for (int i = 0; i < NumEntries; i++)
			{
				sie = new ShopItemEntry();
				sie.ReadData(br);
				Entries.Add(sie);
			}
		}

		public void WriteData(BinaryWriter bw)
		{
			NumEntries = (byte)Entries.Count;
			bw.Write(NumEntries);
			for (int i = 0; i < NumEntries; i++)
			{
				Entries[i].WriteData(bw);
			}
		}
	}
}
