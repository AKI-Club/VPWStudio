using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio.Editors.WM2K
{
	public partial class DefaultCostume_WM2K : Form
	{
		/// <summary>
		/// Costume Data to view/edit.
		/// </summary>
		public DefaultCostumeData DefaultCostume = new DefaultCostumeData();

		public DefaultCostume_WM2K(uint _ptr)
		{
			InitializeComponent();

			LoadData_ROM(_ptr);
		}

		private void LoadData_ROM(uint _pointer)
		{
			uint romLoc = Z64Rom.PointerToRom(_pointer);
			byte[] costumeData = Program.GetRomSlice((int)romLoc, DefaultCostumeData.COSTUME_DATA_LENGTH);
			
			MemoryStream ms = new MemoryStream(costumeData);
			BinaryReader br = new BinaryReader(ms);
			DefaultCostume.ReadData(br);
			PopulateData();
			br.Close();
		}

		private void PopulateData()
		{
			cbHeadShape.SelectedIndex = DefaultCostume.HeadShape;
			cccHairColor.nudColor.Value = DefaultCostume.HairColor;
			nudUnknown1.Value = DefaultCostume.Unknown1;
			cbFaceNumber.SelectedIndex = DefaultCostume.FaceNumber;
			cbMainHair.SelectedIndex = DefaultCostume.Hair1;
			cbFrontHair.SelectedIndex = DefaultCostume.Hair2;
			cbFacialHair.SelectedIndex = DefaultCostume.FacialHair;
			cbMasksEtc.SelectedIndex = DefaultCostume.MasksEtc;
			cbBodySize.SelectedIndex = DefaultCostume.BodySize;
			cbSkinColor.SelectedIndex = DefaultCostume.SkinColor;
			cbRingAttire.SelectedIndex = DefaultCostume.RingAttire;
			cccRingAttire1.SetColorNum(DefaultCostume.RingAttireColor1);
			cccRingAttire2.SetColorNum(DefaultCostume.RingAttireColor2);
			cbUpperAttire.SelectedIndex = DefaultCostume.UpperAttire;
			cccUpperAttire1.SetColorNum(DefaultCostume.UpperAttireColor1);
			cccUpperAttire2.SetColorNum(DefaultCostume.UpperAttireColor2);
			cbGloves.SelectedIndex = DefaultCostume.Gloves;
			cccGloves1.SetColorNum(DefaultCostume.GlovesColor1);
			cccGloves2.SetColorNum(DefaultCostume.GlovesColor2);
			cbTattoo.SelectedIndex = DefaultCostume.Tattoo;
			nudUnknown2.Value = DefaultCostume.Unknown2;
			cbWristband.SelectedIndex = DefaultCostume.Wristband;
			cccWristband.SetColorNum(DefaultCostume.WristbandColor);
			cbElbowPadL.SelectedIndex = DefaultCostume.LeftElbowPad;
			cccElbowPadL.SetColorNum(DefaultCostume.LeftElbowPadColor);
			cbElbowPadR.SelectedIndex = DefaultCostume.RightElbowPad;
			cccElbowPadR.SetColorNum(DefaultCostume.RightElbowPadColor);
			cbKneePadL.SelectedIndex = DefaultCostume.LeftKneePad;
			cccKneePadL.SetColorNum(DefaultCostume.LeftKneePadColor);
			cbKneePadR.SelectedIndex = DefaultCostume.RightKneePad;
			cccKneePadR.SetColorNum(DefaultCostume.RightKneePadColor);
			cbFeet.SelectedIndex = DefaultCostume.Boots;
			cccFeet1.SetColorNum(DefaultCostume.BootsColor1);
			cccFeet2.SetColorNum(DefaultCostume.BootsColor2);
			cbEntranceAttire.SelectedIndex = DefaultCostume.EntranceAttire;
			cbWeapons.SelectedIndex = DefaultCostume.EntranceWeapon;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// write data back to DefaultCostume

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
