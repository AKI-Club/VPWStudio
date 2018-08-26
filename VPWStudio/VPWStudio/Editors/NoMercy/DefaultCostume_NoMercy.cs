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
			tbBodyType.Text = String.Format("0x{0:X2}", CostumeData.BodyType);
			cbSkinColor.SelectedIndex = CostumeData.SkinColor;
			tbRingAttire.Text = String.Format("0x{0:X2}", CostumeData.RingAttire);
			tbRingAttireColor1.Text = String.Format("0x{0:X2}", CostumeData.RingAttireColor1);
			tbRingAttireColor2.Text = String.Format("0x{0:X2}", CostumeData.RingAttireColor2);
			tbUpperAttire.Text = String.Format("0x{0:X2}", CostumeData.UpperAttire);
			tbUpperAttireColor1.Text = String.Format("0x{0:X2}", CostumeData.UpperAttireColor1);
			tbUpperAttireColor2.Text = String.Format("0x{0:X2}", CostumeData.UpperAttireColor2);
			tbEntranceAttire.Text = String.Format("0x{0:X2}", CostumeData.EntranceAttire);
			tbEntranceAttireColor1.Text = String.Format("0x{0:X2}", CostumeData.EntranceAttireColor1);
			tbEntranceAttireColor2.Text = String.Format("0x{0:X2}", CostumeData.EntranceAttireColor2);
			tbEntranceWeapon.Text = String.Format("0x{0:X2}", CostumeData.EntranceWeapon);
			tbGloves.Text = String.Format("0x{0:X2}", CostumeData.Gloves);
			tbGlovesColor.Text = String.Format("0x{0:X2}", CostumeData.GlovesColor);
			tbTattoo.Text = String.Format("0x{0:X2}", CostumeData.Tattoo);
			tbWristband.Text = String.Format("0x{0:X2}", CostumeData.Wristband);
			tbWristbandColor.Text = String.Format("0x{0:X2}", CostumeData.WristbandColor);
			tbLeftElbowPad.Text = String.Format("0x{0:X2}", CostumeData.LeftElbowPad);
			tbLeftElbowPadColor.Text = String.Format("0x{0:X2}", CostumeData.LeftElbowPadColor);
			tbRightElbowPad.Text = String.Format("0x{0:X2}", CostumeData.RightElbowPad);
			tbRightElbowPadColor.Text = String.Format("0x{0:X2}", CostumeData.RightElbowPadColor);
			tbLeftKneepad.Text = String.Format("0x{0:X2}", CostumeData.LeftKneePad);
			tbLeftKneepadColor.Text = String.Format("0x{0:X2}", CostumeData.LeftKneePadColor);
			tbRightKneepad.Text = String.Format("0x{0:X2}", CostumeData.RightKneePad);
			tbRightKneepadColor.Text = String.Format("0x{0:X2}", CostumeData.RightKneePadColor);
			tbBoots.Text = String.Format("0x{0:X2}", CostumeData.Boots);
			tbBootsColor1.Text = String.Format("0x{0:X2}", CostumeData.BootsColor1);
			tbBootsColor2.Text = String.Format("0x{0:X2}", CostumeData.BootsColor2);
			tbHeadShape.Text = String.Format("0x{0:X2}", CostumeData.HeadShape);
			tbFaceNumber.Text = String.Format("0x{0:X2}", CostumeData.FaceNumber);
			tbHairType.Text = String.Format("0x{0:X2}", CostumeData.HairType);
			tbHairColor.Text = String.Format("0x{0:X2}", CostumeData.HairColor);
			tbFrontHair.Text = String.Format("0x{0:X2}", CostumeData.FrontHair);
			tbFacialHair.Text = String.Format("0x{0:X2}", CostumeData.FacialHair);
			tbMasksEtc.Text = String.Format("0x{0:X2}", CostumeData.MasksEtc);
			tbHatsCaps.Text = String.Format("0x{0:X2}", CostumeData.HatsCaps);
			tbHatsCapsColor.Text = String.Format("0x{0:X2}", CostumeData.HatsCapsColor);
			tbPortrait.Text = String.Format("0x{0:X2}", CostumeData.Portrait);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// make changes based on values

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
