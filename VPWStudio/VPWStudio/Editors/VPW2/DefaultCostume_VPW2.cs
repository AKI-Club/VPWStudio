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

		public DefaultCostume_VPW2(int _costumeIndex)
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

			// costume data is in file 006B
			// file is 0x4BCC long. each wrestler has 4 costumes at 49 bytes each (total 196 bytes).
			// start reading at FirstCostumeEntry
			byte[] appearanceData = Program.GetFileSlice(0x006B, FirstCostumeEntry * DefaultCostumeData.COSTUME_DATA_LENGTH, DefaultCostumeData.COSTUME_DATA_LENGTH * 4);
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
			// todo: handle changes once I figure out what I'm doing and how i'm doing it

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
