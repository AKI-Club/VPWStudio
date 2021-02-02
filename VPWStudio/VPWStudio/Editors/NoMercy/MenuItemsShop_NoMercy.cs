using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors.NoMercy
{
	public partial class MenuItemsShop_NoMercy : Form
	{
		public GameSpecific.NoMercy.MenuItems_Shop ShopItems;

		public MenuItemsShop_NoMercy(int fileID)
		{
			InitializeComponent();
			ShopItems = new GameSpecific.NoMercy.MenuItems_Shop();
			LoadData_ROM(fileID);
		}

		public MenuItemsShop_NoMercy(string path)
		{
			InitializeComponent();
			ShopItems = new GameSpecific.NoMercy.MenuItems_Shop();
			LoadData_File(path);
		}

		public void LoadData_File(string path)
		{
			// read data from file
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			ShopItems.ReadData(br);
			br.Close();

			UpdateDropdown();
		}

		public void LoadData_ROM(int fileID)
		{
			// read data from ROM
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fileID);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			ShopItems.ReadData(outReader);

			outReader.Close();
			outWriter.Close();

			UpdateDropdown();
		}

		private void UpdateDropdown()
		{
			cbEntries.Items.Clear();
			cbEntries.BeginUpdate();
			foreach (GameSpecific.NoMercy.ShopItemEntry entry in ShopItems.Entries)
			{
				cbEntries.Items.Add(entry.ItemName);
			}
			cbEntries.EndUpdate();
		}

		private void cbEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbEntries.SelectedIndex < 0 || cbEntries.SelectedIndex > ShopItems.Entries.Count)
			{
				tbHeaderData.Text = string.Empty;
				tbName.Text = string.Empty;
				tbDescription.Text = string.Empty;
				return;
			}

			GameSpecific.NoMercy.ShopItemEntry entry = ShopItems.Entries[cbEntries.SelectedIndex];

			string s = string.Empty;
			for (int i = 0; i < entry.HeaderData.Length; i++)
			{
				s += string.Format("{0:X2}", entry.HeaderData[i]);
				if (i < entry.HeaderData.Length - 1)
				{
					s += " ";
				}
			}
			tbHeaderData.Text = s;

			tbName.Text = entry.ItemName;
			tbDescription.Text = entry.ItemDescription;
		}
	}
}
