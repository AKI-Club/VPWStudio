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
	}
}
