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

		private void UpdateDropdown(bool resetIndex = true)
		{
			cbEntries.Items.Clear();
			cbEntries.BeginUpdate();
			foreach (GameSpecific.NoMercy.ShopItemEntry entry in ShopItems.Entries)
			{
				cbEntries.Items.Add(entry.Name);
			}
			cbEntries.EndUpdate();
			if (resetIndex)
			{
				cbEntries.SelectedIndex = 0;
			}
		}

		private void cbEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbEntries.SelectedIndex < 0 || cbEntries.SelectedIndex > ShopItems.Entries.Count)
			{
				tbName.Text = string.Empty;
				tbDescription.Text = string.Empty;
				nudPrice.Value = 0;
				tbItemType.Text = string.Empty;
				tbItemData.Text = string.Empty;
				return;
			}

			GameSpecific.NoMercy.ShopItemEntry entry = ShopItems.Entries[cbEntries.SelectedIndex];
			tbName.Text = entry.Name;
			tbDescription.Text = entry.Description;
			nudPrice.Value = entry.Price;
			tbUnlockID.Text = String.Format("0x{0:X2}", entry.UnlockID);
			tbItemType.Text = String.Format("0x{0:X2} ('{1}')", entry.ItemType, (char)entry.ItemType);
			tbItemData.Text = String.Format("0x{0:X4}", entry.ItemData);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnUpdateEntry_Click(object sender, EventArgs e)
		{
			// commit whatever changes have been made to the current item
			if (cbEntries.SelectedIndex < 0)
			{
				return;
			}

			GameSpecific.NoMercy.ShopItemEntry curEntry = ShopItems.Entries[cbEntries.SelectedIndex];
			curEntry.Name = tbName.Text;
			curEntry.Description = tbDescription.Text;
			curEntry.Price = (uint)nudPrice.Value;
			// the other values can't be edited at the moment
			ShopItems.Entries[cbEntries.SelectedIndex] = curEntry;

			// update dropdown with new item name
			cbEntries.Items[cbEntries.SelectedIndex] = tbName.Text;
		}
	}
}
