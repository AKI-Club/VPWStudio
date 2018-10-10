using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	/// <summary>
	/// VPW2 Default Costume Editor
	/// </summary>
	public partial class DefaultCostume_VPW2 : Form
	{
		private const UInt16 VPW2_DEFAULT_COSTUME_FILE = 0x006B;

		/// <summary>
		/// First costume entry to show/edit. The remaining costumes are derived from this number.
		/// </summary>
		public int FirstCostumeEntry;

		/// <summary>
		/// Costume editor controls for each costume.
		/// </summary>
		private Controls.CostumeEditor_VPW2[] CostumeEditors = new Controls.CostumeEditor_VPW2[4];

		/// <summary>
		/// All costumes for selected wrestler.
		/// </summary>
		public DefaultCostumeData[] Costumes = new DefaultCostumeData[4];

		public DefaultCostume_VPW2(int _costumeIndex, string _path = null)
		{
			InitializeComponent();
			FirstCostumeEntry = _costumeIndex;

			// this works out by pure happenstance.
			// however, all Edits/Original character slots use the same index.
			Text = String.Format("Default Costumes for ID2 0x{0:X2}", (_costumeIndex / 4) + 1);

			CostumeEditors[0] = cosEditCostume1;
			CostumeEditors[1] = cosEditCostume2;
			CostumeEditors[2] = cosEditCostume3;
			CostumeEditors[3] = cosEditCostume4;

			if (_path != null)
			{
				LoadData_File(_path);
			}
			else
			{
				LoadData_ROM();
			}
		}

		/// <summary>
		/// Load default costume data from ROM.
		/// </summary>
		private void LoadData_ROM()
		{
			// costume data is in file 006B
			// file is 0x4BCC long. each wrestler has 4 costumes at 49 bytes each (total 196 bytes).
			// start reading at FirstCostumeEntry
			byte[] appearanceData = Program.GetFileSlice(VPW2_DEFAULT_COSTUME_FILE, FirstCostumeEntry * DefaultCostumeData.COSTUME_DATA_LENGTH, DefaultCostumeData.COSTUME_DATA_LENGTH * 4);
			MemoryStream ms = new MemoryStream(appearanceData);
			BinaryReader br = new BinaryReader(ms);

			for (int i = 0; i < Costumes.Length; i++)
			{
				Costumes[i] = new DefaultCostumeData();
				Costumes[i].ReadData(br);
				UpdateDisplay(i);
			}

			br.Close();
		}

		/// <summary>
		/// Load default costume data from an external file.
		/// </summary>
		/// <param name="_path">Path to default costume data file.</param>
		private void LoadData_File(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			// advance forward to desired location
			fs.Seek(FirstCostumeEntry * DefaultCostumeData.COSTUME_DATA_LENGTH, SeekOrigin.Begin);

			for (int i = 0; i < Costumes.Length; i++)
			{
				Costumes[i] = new DefaultCostumeData();
				Costumes[i].ReadData(br);
				UpdateDisplay(i);
			}

			br.Close();
		}

		private void UpdateDisplay(int cosNumber)
		{
			if (cosNumber < 0 || cosNumber >= Costumes.Length)
			{
				return;
			}

			DefaultCostumeData curCostume = Costumes[cosNumber];
			CostumeEditors[cosNumber].SetCostume(curCostume);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < CostumeEditors.Length; i++)
			{
				CostumeEditors[i].WriteValues();
				Costumes[i] = CostumeEditors[i].Costume;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
