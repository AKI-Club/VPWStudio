using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.NoMercy;

namespace VPWStudio.Editors.NoMercy
{
	public partial class MenuItemsMoves_NoMercy : Form
	{
		public MenuItems_Moves Names;

		public MenuItemsMoves_NoMercy(int fileID)
		{
			InitializeComponent();
			LoadData_ROM(fileID);
			UpdateDropdown();
		}

		public MenuItemsMoves_NoMercy(string path)
		{
			InitializeComponent();
			LoadData_File(path);
			UpdateDropdown();
		}

		public void LoadData_File(string path)
		{
			// read data from file
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			Names = new MenuItems_Moves(br);
			br.Close();
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
			Names = new MenuItems_Moves(outReader);

			outReader.Close();
			outWriter.Close();
		}

		private void UpdateDropdown()
		{
			cbMoves.Items.Clear();
			cbMoves.BeginUpdate();
			foreach (MoveMenuEntry entry in Names.Entries)
			{
				cbMoves.Items.Add(entry.MoveName);
			}
			cbMoves.EndUpdate();
			cbMoves.SelectedIndex = 0;
		}

		private void cbMoves_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMoves.SelectedIndex < 0)
			{
				return;
			}

			// update display
			MoveMenuEntry entry = Names.Entries[cbMoves.SelectedIndex];
			tbDamage.Text = string.Format("{0:X2}", entry.DamageInfo);
			tbPreview.Text = string.Format("{0:X4}", entry.PreviewPos);
			tbMoveLink.Text = string.Format("{0:X4}", entry.MoveLink);
			tbAnimID.Text = string.Format("{0:X4}", entry.AnimID);
			tbRepeatID.Text = string.Format("{0:X4}", entry.RepeatAnimID);
			tbMasterMoveID.Text = string.Format("{0:X4}", entry.MasterMoveID);
			tbName.Text = entry.MoveName;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnUpdateEntry_Click(object sender, EventArgs e)
		{
			if (cbMoves.SelectedIndex < 0)
			{
				return;
			}

		}
	}
}
