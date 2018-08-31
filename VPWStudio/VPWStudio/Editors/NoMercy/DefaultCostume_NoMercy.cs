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
	/// <summary>
	/// WWF No Mercy Default Costume Viewer/Editor
	/// </summary>
	public partial class DefaultCostume_NoMercy : Form
	{
		/// <summary>
		/// Costume Data to view/edit.
		/// </summary>
		public DefaultCostumeData CostumeData = new DefaultCostumeData();

		public DefaultCostume_NoMercy(int costumeNumber)
		{
			InitializeComponent();
			Text = String.Format("Default Costume Data - Entry {0}", costumeNumber);

			// read slice from file 0x0001
			byte[] appearanceData = Program.GetFileSlice(0x0001, costumeNumber * DefaultCostumeData.COSTUME_DATA_LENGTH, DefaultCostumeData.COSTUME_DATA_LENGTH);
			MemoryStream ms = new MemoryStream(appearanceData);
			BinaryReader br = new BinaryReader(ms);
			CostumeData.ReadData(br);
			br.Close();
			PopulateData();
		}

		private void PopulateData()
		{
			cbBodyType.SelectedIndex = CostumeData.BodyType;
			cbSkinColor.SelectedIndex = CostumeData.SkinColor;
			cbRingAttire.SelectedIndex = CostumeData.RingAttire;
			cccRingAttireColor1.SetColorNum(CostumeData.RingAttireColor1);
			cccRingAttireColor2.SetColorNum(CostumeData.RingAttireColor2);
			tbUpperAttire.Text = String.Format("0x{0:X2}", CostumeData.UpperAttire);
			cccUpperAttireColor1.SetColorNum(CostumeData.UpperAttireColor1);
			cccUpperAttireColor2.SetColorNum(CostumeData.UpperAttireColor2);
			cbEntranceAttire.SelectedIndex = CostumeData.EntranceAttire;
			cccEntranceAttireColor1.SetColorNum(CostumeData.EntranceAttireColor1);
			cccEntranceAttireColor2.SetColorNum(CostumeData.EntranceAttireColor2);
			cbEntranceWeapon.SelectedIndex = CostumeData.EntranceWeapon;
			cbGloves.SelectedIndex = CostumeData.Gloves;
			cccGlovesColor.SetColorNum(CostumeData.GlovesColor);
			tbTattoo.Text = String.Format("0x{0:X2}", CostumeData.Tattoo);
			cbWristband.SelectedIndex = CostumeData.Wristband;
			cccWristbandColor.SetColorNum(CostumeData.WristbandColor);
			cbLeftElbowPad.SelectedIndex = CostumeData.LeftElbowPad;
			cccLeftElbowPadColor.SetColorNum(CostumeData.LeftElbowPadColor);
			cbRightElbowPad.SelectedIndex = CostumeData.RightElbowPad;
			cccRightElbowPadColor.SetColorNum(CostumeData.RightElbowPadColor);
			cbLeftKneepad.SelectedIndex = CostumeData.LeftKneePad;
			cccLeftKneePadColor.SetColorNum(CostumeData.LeftKneePadColor);
			cbRightKneepad.SelectedIndex = CostumeData.RightKneePad;
			cccRightKneePadColor.SetColorNum(CostumeData.RightKneePadColor);
			cbBoots.SelectedIndex = CostumeData.Boots;
			cccBootsColor1.SetColorNum(CostumeData.BootsColor1);
			cccBootsColor2.SetColorNum(CostumeData.BootsColor2);
			cbHeadShape.SelectedIndex = CostumeData.HeadShape;
			cbFaces.SelectedIndex = CostumeData.FaceNumber;
			cbHairType.SelectedIndex = CostumeData.HairType;
			cbHairColor.SelectedIndex = CostumeData.HairColor;
			cbFrontHair.SelectedIndex = CostumeData.FrontHair;
			cbFacialHair.SelectedIndex = CostumeData.FacialHair;
			cbMasksEtc.SelectedIndex = CostumeData.MasksEtc;
			cbHatsCaps.SelectedIndex = CostumeData.HatsCaps;
			cccHatsCaps.SetColorNum(CostumeData.HatsCapsColor);
			cbPortrait.SelectedIndex = CostumeData.Portrait;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// make changes based on values
			CostumeData.SkinColor = (byte)cbSkinColor.SelectedIndex;
			CostumeData.HeadShape = (byte)cbHeadShape.SelectedIndex;
			CostumeData.HairType = (byte)cbHairType.SelectedIndex;
			CostumeData.HairColor = (byte)cbHairColor.SelectedIndex;
			CostumeData.HatsCaps = (byte)cbHatsCaps.SelectedIndex;

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
