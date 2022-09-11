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
		private const UInt16 NOMERCY_DEFAULT_COSTUME_FILE = 1;

		/// <summary>
		/// Costume Data to view/edit.
		/// </summary>
		public DefaultCostumeData CostumeData = new DefaultCostumeData();

		public DefaultCostume_NoMercy(int _costumeIndex, string _path = null)
		{
			InitializeComponent();
			Text = String.Format("Default Costume Data - Entry {0}", _costumeIndex);

			if (!String.IsNullOrEmpty(_path))
			{
				LoadData_File(_path, _costumeIndex);
			}
			else
			{
				LoadData_ROM(_costumeIndex);
			}
			PopulateData();
		}

		/// <summary>
		/// Load default costume data from ROM.
		/// </summary>
		/// <param name="_costumeIndex">Costume number to read.</param>
		private void LoadData_ROM(int _costumeIndex)
		{
			// read slice from file 0x0001
			byte[] appearanceData = Program.GetFileSlice(NOMERCY_DEFAULT_COSTUME_FILE, _costumeIndex * DefaultCostumeData.COSTUME_DATA_LENGTH, DefaultCostumeData.COSTUME_DATA_LENGTH);
			MemoryStream ms = new MemoryStream(appearanceData);
			BinaryReader br = new BinaryReader(ms);
			CostumeData.ReadData(br);
			br.Close();
		}

		/// <summary>
		/// Load default costume data from an external file.
		/// </summary>
		/// <param name="_path">Path to default costume data file.</param>
		/// <param name="_costumeIndex">Costume number to read.</param>
		private void LoadData_File(string _path, int _costumeIndex)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			// advance forward to desired location
			fs.Seek(_costumeIndex * DefaultCostumeData.COSTUME_DATA_LENGTH, SeekOrigin.Begin);
			CostumeData.ReadData(br);
			br.Close();
		}

		private void PopulateData()
		{
			cbBodyType.SelectedIndex = CostumeData.BodyType;
			cbSkinColor.SelectedIndex = CostumeData.SkinColor;
			cbRingAttire.SelectedIndex = CostumeData.RingAttire;
			cccRingAttireColor1.SetColorNum(CostumeData.RingAttireColor1);
			cccRingAttireColor2.SetColorNum(CostumeData.RingAttireColor2);
			cbUpperAttire.SelectedIndex = CostumeData.UpperAttire;
			cccUpperAttireColor1.SetColorNum(CostumeData.UpperAttireColor1);
			cccUpperAttireColor2.SetColorNum(CostumeData.UpperAttireColor2);
			cbEntranceAttire.SelectedIndex = CostumeData.EntranceAttire;
			cccEntranceAttireColor1.SetColorNum(CostumeData.EntranceAttireColor1);
			cccEntranceAttireColor2.SetColorNum(CostumeData.EntranceAttireColor2);
			cbEntranceWeapon.SelectedIndex = CostumeData.EntranceWeapon;
			cbGloves.SelectedIndex = CostumeData.Gloves;
			cccGlovesColor.SetColorNum(CostumeData.GlovesColor);
			cbTattoo.SelectedIndex = CostumeData.Tattoo;
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
			cccHairColor.nudColor.Value = CostumeData.HairColor;
			cbFrontHair.SelectedIndex = CostumeData.FrontHair;
			cbFacialHair.SelectedIndex = CostumeData.FacialHair;
			cbMasksEtc.SelectedIndex = CostumeData.MasksEtc;
			cbHatsCaps.SelectedIndex = CostumeData.HatsCaps;
			cccHatsCaps.SetColorNum(CostumeData.HatsCapsColor);
			cbPortrait.SelectedIndex = CostumeData.Portrait;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			CostumeData.BodyType = (byte)cbBodyType.SelectedIndex;
			CostumeData.SkinColor = (byte)cbSkinColor.SelectedIndex;
			CostumeData.RingAttire = (byte)cbRingAttire.SelectedIndex;
			CostumeData.RingAttireColor1 = (byte)cccRingAttireColor1.GetColorNum();
			CostumeData.RingAttireColor2 = (byte)cccRingAttireColor2.GetColorNum();

			CostumeData.UpperAttire = (byte)cbUpperAttire.SelectedIndex;
			CostumeData.UpperAttireColor1 = (byte)cccUpperAttireColor1.GetColorNum();
			CostumeData.UpperAttireColor2 = (byte)cccUpperAttireColor2.GetColorNum();

			CostumeData.EntranceAttire = (byte)cbEntranceAttire.SelectedIndex;
			CostumeData.EntranceAttireColor1 = (byte)cccEntranceAttireColor1.GetColorNum();
			CostumeData.EntranceAttireColor2 = (byte)cccEntranceAttireColor2.GetColorNum();
			CostumeData.EntranceWeapon = (byte)cbEntranceWeapon.SelectedIndex;

			CostumeData.Gloves = (byte)cbGloves.SelectedIndex;
			CostumeData.GlovesColor = (byte)cccGlovesColor.GetColorNum();

			CostumeData.Tattoo = (byte)cbTattoo.SelectedIndex;

			CostumeData.Wristband = (byte)cbWristband.SelectedIndex;
			CostumeData.WristbandColor = (byte)cccWristbandColor.GetColorNum();

			CostumeData.LeftElbowPad = (byte)cbRightElbowPad.SelectedIndex;
			CostumeData.LeftElbowPadColor = (byte)cccRightElbowPadColor.GetColorNum();
			CostumeData.RightElbowPad = (byte)cbRightElbowPad.SelectedIndex;
			CostumeData.RightElbowPadColor = (byte)cccRightElbowPadColor.GetColorNum();

			CostumeData.LeftKneePad = (byte)cbLeftKneepad.SelectedIndex;
			CostumeData.LeftKneePadColor = (byte)cccLeftKneePadColor.GetColorNum();
			CostumeData.RightKneePad = (byte)cbRightKneepad.SelectedIndex;
			CostumeData.RightKneePadColor = (byte)cccRightKneePadColor.GetColorNum();
		
			CostumeData.Boots = (byte)cbBoots.SelectedIndex;
			CostumeData.BootsColor1 = (byte)cccBootsColor1.GetColorNum();
			CostumeData.BootsColor2 = (byte)cccBootsColor2.GetColorNum();

			CostumeData.HeadShape = (byte)cbHeadShape.SelectedIndex;
			CostumeData.FaceNumber = (byte)cbFaces.SelectedIndex;
			CostumeData.HairType = (byte)cbHairType.SelectedIndex;
			CostumeData.HairColor = (byte)cccHairColor.nudColor.Value;
			CostumeData.FrontHair = (byte)cbFrontHair.SelectedIndex;
			CostumeData.FacialHair = (byte)cbFacialHair.SelectedIndex;

			CostumeData.MasksEtc = (byte)cbMasksEtc.SelectedIndex;
			CostumeData.HatsCaps = (byte)cbHatsCaps.SelectedIndex;
			CostumeData.HatsCapsColor = (byte)cccHatsCaps.GetColorNum();

			CostumeData.Portrait = (byte)cbPortrait.SelectedIndex;

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
