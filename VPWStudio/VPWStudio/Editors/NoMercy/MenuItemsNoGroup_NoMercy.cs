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
	public partial class MenuItemsNoGroup_NoMercy : Form
	{
		public GameSpecific.NoMercy.MenuItems_NoGroup MenuItemData;

		public MenuItemsNoGroup_NoMercy(int fileID)
		{
			InitializeComponent();
			MenuItemData = new GameSpecific.NoMercy.MenuItems_NoGroup();
			LoadData_ROM(fileID);
		}

		public MenuItemsNoGroup_NoMercy(string _path)
		{
			InitializeComponent();
			MenuItemData = new GameSpecific.NoMercy.MenuItems_NoGroup();
			LoadData_File(_path);
		}

		public void LoadData_File(string path)
		{
			// read data from file
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			MenuItemData.ReadData(br);
			br.Close();

			PopulateDataGridView();
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
			MenuItemData.ReadData(outReader);

			outReader.Close();
			outWriter.Close();

			PopulateDataGridView();
		}

		private void PopulateDataGridView()
		{
			dgvMenuItems.Rows.Clear();
			foreach (KeyValuePair<byte, string> entry in MenuItemData.Entries)
			{
				dgvMenuItems.Rows.Add(entry.Key, entry.Value);
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// ensure data doesn't fuck up
			foreach (DataGridViewRow r in dgvMenuItems.Rows)
			{
				// column 0 values must be integers
				if (!Byte.TryParse(r.Cells[0].Value.ToString(), out byte _))
				{
					MessageBox.Show(String.Format("A non-byte value is in row {0}. Please fix it before continuing.", r.Index+1));
					return;
				}
			}

			// update MenuItemData from DataGridView contents
			MenuItemData.Entries.Clear();
			foreach (DataGridViewRow r in dgvMenuItems.Rows)
			{
				byte value = Byte.Parse(r.Cells[0].Value.ToString());
				MenuItemData.Entries.Add(value, r.Cells[1].Value.ToString());
			}

			DialogResult = DialogResult.OK;

			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void dgvMenuItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				if (!Byte.TryParse(dgvMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out byte _))
				{
					dgvMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Non-byte value";
					dgvMenuItems.UpdateRowErrorText(e.RowIndex);
				}
				else
				{
					dgvMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = String.Empty;
					dgvMenuItems.UpdateRowErrorText(e.RowIndex);
				}
			}
		}
	}
}
