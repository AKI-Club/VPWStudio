using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.NoMercy
{
	/*
		randymanfoo: on the attire listing on shop menu (4AA9), the format is
		0x00 - 00
		0x01 - Price part 1
		0x02 - Price part 2
		0x03 - Price part 3
		0x04 - Unlock ID
		0x05 - Item type shown (43: attire item, 57: wrestler, 4D: move)
		0x06 - (If 43: Item Shown in 4AAC 1, 57: Wrestler ID1)
		0x07 - (If 43: Item Shown in 4AAC 2, 57: Wrestler ID2)
		0x08 - 00
		0x09 - 00
		0x0A - Words begin.
	 */
	public struct ShopItemEntry
	{
		// thanks to randymanfoo for figuring the header data out

		#region Header Data
		/// <summary>
		/// Price of this item.
		/// </summary>
		/// Header data offsets 0-3
		public UInt32 Price;

		/// <summary>
		/// Unlock ID associated with this item.
		/// </summary>
		/// Header data offset 4
		public byte UnlockID;

		/// <summary>
		/// Type of this item.
		/// (Known values: 0x41/'A' = arena, 0x43/'C' = costume, 0x4D/'M' = move, 0x57/'W' = wrestler)
		/// </summary>
		/// Header data offset 5
		public byte ItemType;

		// offset 6 and 7 meaning depends on item type
		// for type 0x43: entry in file 4AAC?
		// for type 0x57: wrestler ID4
		public UInt16 ItemData;

		// offset 8 and 9 padding???
		#endregion

		/// <summary>
		/// Name of this item.
		/// </summary>
		public string Name;

		/// <summary>
		/// Description for this item.
		/// </summary>
		public string Description;

		public void ReadData(BinaryReader br)
		{
			byte[] price = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(price);
			}
			Price = BitConverter.ToUInt32(price, 0);

			UnlockID = br.ReadByte();
			ItemType = br.ReadByte();

			byte[] data = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(data);
			}
			ItemData = BitConverter.ToUInt16(data, 0);

			// 2 bytes padding
			br.ReadUInt16();

			Name = string.Empty;
			while (br.PeekChar() != 0)
			{
				Name += br.ReadChar();
			}

			br.ReadByte();

			Description = string.Empty;
			while (br.PeekChar() != 0)
			{
				Description += br.ReadChar();
			}

			br.ReadByte();
		}

		public void WriteData(BinaryWriter bw)
		{
			byte[] price = BitConverter.GetBytes(Price);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(price);
			}
			bw.Write(price);

			bw.Write(UnlockID);
			bw.Write(ItemType);
			bw.Write(ItemData);
			bw.Write((UInt16)0);

			bw.Write(Name.ToCharArray());
			bw.Write((byte)0);
			bw.Write(Description.ToCharArray());
			bw.Write((byte)0);
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
