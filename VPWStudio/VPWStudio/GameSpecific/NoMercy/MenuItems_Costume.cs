using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.NoMercy
{
	/// <summary>
	/// Determines limitations on selectable items.
	/// </summary>
	public enum CostumeItemSelectableGroup
	{
		/// <summary>
		/// Probably unselectable?
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Male characters only
		/// </summary>
		MaleOnly,

		/// <summary>
		/// Female characters only
		/// </summary>
		FemaleOnly,

		/// <summary>
		/// No restrictions
		/// </summary>
		Any
	}

	/// <summary>
	/// Item definition.
	/// </summary>
	public struct MenuItemListCostumeEntry
	{
		/// <summary>
		/// Value for this item.
		/// </summary>
		public byte Value;

		/// <summary>
		/// Name of this item.
		/// </summary>
		public string Name;

		/// <summary>
		/// Which genders can select this item?
		/// </summary>
		public CostumeItemSelectableGroup Selectable;

		// item name+2: 0x00 terminator/padding (not stored, but read and written)

		public void ReadData(BinaryReader br)
		{
			Value = br.ReadByte();
			Name = String.Empty;
			while (br.PeekChar() != 0)
			{
				Name += br.ReadByte();
			}
			Selectable = (CostumeItemSelectableGroup)br.ReadByte();
			br.ReadByte(); // dummy
		}

		public void WriteData(BinaryWriter bw)
		{
			bw.Write(Value);

			// name
			bw.Write(Name.ToCharArray());

			bw.Write((byte)Selectable);
			bw.Write(0);
		}
	}

	/// <summary>
	/// Group definition
	/// </summary>
	public struct GroupListEntry
	{
		/// <summary>
		/// Group name. Sometimes in Shift-JIS.
		/// </summary>
		public string Name;

		/// <summary>
		/// Total number of items in this group.
		/// </summary>
		public byte NumItems;

		/// <summary>
		/// Number of male-selectable items.
		/// </summary>
		public byte MaleItems;

		/// <summary>
		/// Number of female-selectable items.
		/// </summary>
		public byte FemaleItems;

		/// <summary>
		/// The items in this group.
		/// </summary>
		List<MenuItemListCostumeEntry> Items;

		public void ReadData(BinaryReader br)
		{
			Name = String.Empty;
			while (br.PeekChar() != 0)
			{
				Name += br.ReadByte();
			}
			NumItems = br.ReadByte();
			MaleItems = br.ReadByte();
			FemaleItems = br.ReadByte();

			// item list
			Items = new List<MenuItemListCostumeEntry>();
			for (int i = 0; i < NumItems; i++)
			{
				MenuItemListCostumeEntry milce = new MenuItemListCostumeEntry();
				milce.ReadData(br);
				Items.Add(milce);
			}
		}

		public void WriteData(BinaryWriter bw)
		{
			// name
			bw.Write(Name.ToCharArray());

			bw.Write(NumItems);
			bw.Write(MaleItems);
			bw.Write(FemaleItems);

			// items in this group
			for (int i = 0; i < NumItems; i++)
			{
				Items[i].WriteData(bw);
			}
		}
	}

	/// <summary>
	/// WWF No Mercy Costume Item Lists.
	/// </summary>
	public class MenuItems_Costume
	{
		// offset 0x00: number of groups
		public byte NumGroups;

		// offset 0x01: total number of items in list
		public byte TotalNumItems;

		List<GroupListEntry> Groups;

		public MenuItems_Costume()
		{
			NumGroups = 0;
			TotalNumItems = 0;
			Groups = new List<GroupListEntry>();
		}

		public void ReadData(BinaryReader br)
		{
			NumGroups = br.ReadByte();
			TotalNumItems = br.ReadByte();

			for (int i = 0; i < NumGroups; i++)
			{
				GroupListEntry gle = new GroupListEntry();
				gle.ReadData(br);
				Groups.Add(gle);
			}
		}

		public void WriteData(BinaryWriter bw)
		{

		}
	}
}
