using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Controls
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Costume Editor control.
	/// </summary>
	public partial class CostumeEditor_VPW2 : UserControl
	{
		/// <summary>
		/// Costume to display/edit.
		/// </summary>
		public DefaultCostumeData Costume;

		public CostumeEditor_VPW2()
		{
			InitializeComponent();
		}

		public void SetCostume(DefaultCostumeData _c)
		{
			Costume = _c;
			LoadValues();
		}

		public void LoadValues()
		{
			if (Costume == null)
			{
				return;
			}

			nudBodyType.Value = Costume.BodyType;
			nudSkinColor.Value = Costume.SkinColor;

			nudRingAttire.Value = Costume.RingAttire;
			cccRingAttireColor1.SetColorNum(Costume.RingAttireColor1);
			cccRingAttireColor2.SetColorNum(Costume.RingAttireColor2);

			nudUpperAttire.Value = Costume.UpperAttire;
			cccUpperAttireColor1.SetColorNum(Costume.UpperAttireColor1);
			cccUpperAttireColor2.SetColorNum(Costume.UpperAttireColor2);

			nudEntranceAttire.Value = Costume.EntranceAttire;
			cccEntranceAttireColor1.SetColorNum(Costume.EntranceAttireColor1);
			cccEntranceAttireColor2.SetColorNum(Costume.EntranceAttireColor2);
			nudEntranceWeapon.Value = Costume.EntranceWeapon;

			nudGloves.Value = Costume.Gloves;
			cccGlovesColor1.SetColorNum(Costume.GlovesColor1);
			cccGlovesColor2.SetColorNum(Costume.GlovesColor2);

			nudTattoo.Value = Costume.Tattoo;

			nudWristband.Value = Costume.Wristband;
			cccWristbandColor.SetColorNum(Costume.WristbandColor);

			nudLeftElbowPad.Value = Costume.LeftElbowPad;
			cccLeftElbowPadColor.SetColorNum(Costume.LeftElbowPadColor);
			nudRightElbowPad.Value = Costume.RightElbowPad;
			cccRightElbowPadColor.SetColorNum(Costume.RightElbowPadColor);

			nudLeftKneePad.Value = Costume.LeftKneePad;
			cccLeftKneePadColor.SetColorNum(Costume.LeftKneePadColor);
			nudRightKneePad.Value = Costume.RightKneePad;
			cccRightKneePadColor.SetColorNum(Costume.RightKneePadColor);

			nudBoots.Value = Costume.Boots;
			cccBootsColor1.SetColorNum(Costume.BootsColor1);
			cccBootsColor2.SetColorNum(Costume.BootsColor2);

			cbUsingMask.Checked = (Costume.Mask == 1);

			nudHeadShape.Value = Costume.HeadShape;
			nudUnknown1.Value = Costume.Unknown1;
			nudFaceNumber.Value = Costume.FaceNumber;
			nudHairType.Value = Costume.HairType;
			nudHairColor.Value = Costume.HairColor;
			nudFrontHair.Value = Costume.FrontHair;
			nudUnknown2.Value = Costume.Unknown2;
			nudFacialHair.Value = Costume.FacialHair;
			nudFacepaint.Value = Costume.Facepaint;
			nudAccessory.Value = Costume.Accessory;

			nudMaskNumber.Value = Costume.MaskNumber;
			cccMaskColor1.SetColorNum(Costume.MaskColor1);
			cccMaskColor2.SetColorNum(Costume.MaskColor2);
			cccMaskColor3.SetColorNum(Costume.MaskColor3);
			cccMaskColor4.SetColorNum(Costume.MaskColor4);
			nudMaskHairType.Value = Costume.MaskHairType;
			nudMaskAccessory1.Value = Costume.MaskAccessory1;
			nudMaskAccessory2.Value = Costume.MaskAccessory2;
		}

		public void WriteValues()
		{
			Costume.BodyType = (byte)nudBodyType.Value;
			Costume.SkinColor = (byte)nudSkinColor.Value;

			Costume.RingAttire = (byte)nudRingAttire.Value;
			Costume.RingAttireColor1 = (byte)cccRingAttireColor1.GetColorNum();
			Costume.RingAttireColor2 = (byte)cccRingAttireColor2.GetColorNum();

			Costume.UpperAttire = (byte)nudUpperAttire.Value;
			Costume.UpperAttireColor1 = (byte)cccUpperAttireColor1.GetColorNum();
			Costume.UpperAttireColor2 = (byte)cccUpperAttireColor2.GetColorNum();

			Costume.EntranceAttire = (byte)nudEntranceAttire.Value;
			Costume.EntranceAttireColor1 = (byte)cccEntranceAttireColor1.GetColorNum();
			Costume.EntranceAttireColor2 = (byte)cccEntranceAttireColor2.GetColorNum();
			Costume.EntranceWeapon = (byte)nudEntranceWeapon.Value;

			Costume.Gloves = (byte)nudGloves.Value;
			Costume.GlovesColor1 = (byte)cccGlovesColor1.GetColorNum();
			Costume.GlovesColor2 = (byte)cccGlovesColor2.GetColorNum();

			Costume.Tattoo = (byte)nudTattoo.Value;

			Costume.Wristband = (byte)nudWristband.Value;
			Costume.WristbandColor = (byte)cccWristbandColor.GetColorNum();

			Costume.LeftElbowPad = (byte)nudLeftElbowPad.Value;
			Costume.LeftElbowPadColor = (byte)cccLeftElbowPadColor.GetColorNum();
			Costume.RightElbowPad = (byte)nudRightElbowPad.Value;
			Costume.RightElbowPadColor = (byte)cccRightElbowPadColor.GetColorNum();

			Costume.LeftKneePad = (byte)nudLeftKneePad.Value;
			Costume.LeftKneePadColor = (byte)cccLeftKneePadColor.GetColorNum();
			Costume.RightKneePad = (byte)nudRightKneePad.Value;
			Costume.RightKneePadColor = (byte)cccRightKneePadColor.GetColorNum();

			Costume.Boots = (byte)nudBoots.Value;
			Costume.BootsColor1 = (byte)cccBootsColor1.GetColorNum();
			Costume.BootsColor2 = (byte)cccBootsColor2.GetColorNum();

			Costume.Mask = (cbUsingMask.Checked == true) ? (byte)1 : (byte)0;

			Costume.HeadShape = (byte)nudHeadShape.Value;
			Costume.Unknown1 = (byte)nudUnknown1.Value;
			Costume.FaceNumber = (byte)nudFaceNumber.Value;
			Costume.HairType = (byte)nudHairType.Value;
			Costume.HairColor = (byte)nudHairColor.Value;
			Costume.FrontHair = (byte)nudFrontHair.Value;
			Costume.Unknown2 = (byte)nudUnknown2.Value;
			Costume.FacialHair = (byte)nudFacialHair.Value;
			Costume.Facepaint = (byte)nudFacepaint.Value;
			Costume.Accessory = (byte)nudAccessory.Value;

			Costume.MaskNumber = (byte)nudMaskNumber.Value;
			Costume.MaskColor1 = (byte)cccMaskColor1.GetColorNum();
			Costume.MaskColor2 = (byte)cccMaskColor2.GetColorNum();
			Costume.MaskColor3 = (byte)cccMaskColor3.GetColorNum();
			Costume.MaskColor4 = (byte)cccMaskColor4.GetColorNum();
			Costume.MaskHairType = (byte)nudMaskHairType.Value;
			Costume.MaskAccessory1 = (byte)nudMaskAccessory1.Value;
			Costume.MaskAccessory2 = (byte)nudMaskAccessory2.Value;
		}
	}
}
