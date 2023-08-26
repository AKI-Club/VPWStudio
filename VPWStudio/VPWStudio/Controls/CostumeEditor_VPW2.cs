using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
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
		/// Indexes of copy/pasted costume data that are not used.
		/// </summary>
		/// See comment in ToString/FromString region below for full offset list.
		private readonly List<int> SkipList = new List<int>()
		{
			2, 0x0D, 0x0E, 0x10, 0x11, 0x19, 0x1A, 0x1C, 0x1D, 0x23, 0x26, 0x28, 0x29, 0x2C, 0x2F, 0x32
		};

		/// <summary>
		/// Costume to display/edit.
		/// </summary>
		public DefaultCostumeData Costume;

		/// <summary>
		/// Used to build the Costume Data clipboard string.
		/// </summary>
		protected StringBuilder ClipboardStringBuilder = new StringBuilder();

		public CostumeEditor_VPW2()
		{
			InitializeComponent();
		}

		public void SetCostume(DefaultCostumeData _c)
		{
			Costume = _c;
			LoadValues();
		}

		/// <summary>
		/// Load UI values from Costume data.
		/// </summary>
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
			cccHairColor.nudColor.Value = Costume.HairColor;
			nudFrontHair.Value = Costume.FrontHair;
			nudUnknown2.Value = Costume.Unknown2;
			nudFacialHair.Value = Costume.FacialHair;
			nudFacepaint.Value = Costume.Facepaint;
			nudAccessory.Value = Costume.Accessory;

			nudMaskHeadShape.Value = Costume.MaskHeadShape;
			nudMaskNumber.Value = Costume.MaskNumber;
			cccMaskColor1.SetColorNum(Costume.MaskColor1);
			cccMaskColor2.SetColorNum(Costume.MaskColor2);
			cccMaskColor3.SetColorNum(Costume.MaskColor3);
			cccMaskColor4.SetColorNum(Costume.MaskColor4);
			nudMaskHairType.Value = Costume.MaskHairType;
			nudMaskAccessory1.Value = Costume.MaskAccessory1;
			nudMaskAccessory2.Value = Costume.MaskAccessory2;
		}

		/// <summary>
		/// Save UI values to Costume data.
		/// </summary>
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
			Costume.HairColor = (byte)cccHairColor.nudColor.Value;
			Costume.FrontHair = (byte)nudFrontHair.Value;
			Costume.Unknown2 = (byte)nudUnknown2.Value;
			Costume.FacialHair = (byte)nudFacialHair.Value;
			Costume.Facepaint = (byte)nudFacepaint.Value;
			Costume.Accessory = (byte)nudAccessory.Value;

			Costume.MaskHeadShape = (byte)nudMaskHeadShape.Value;
			Costume.MaskNumber = (byte)nudMaskNumber.Value;
			Costume.MaskColor1 = (byte)cccMaskColor1.GetColorNum();
			Costume.MaskColor2 = (byte)cccMaskColor2.GetColorNum();
			Costume.MaskColor3 = (byte)cccMaskColor3.GetColorNum();
			Costume.MaskColor4 = (byte)cccMaskColor4.GetColorNum();
			Costume.MaskHairType = (byte)nudMaskHairType.Value;
			Costume.MaskAccessory1 = (byte)nudMaskAccessory1.Value;
			Costume.MaskAccessory2 = (byte)nudMaskAccessory2.Value;
		}

		// internal format game uses during edit mode (0x3A bytes)
		// addresses:
		// - 8024DE80
		// - 8024DEBE (conducive to editing)
		// 0x00 - Body Type
		// 0x01 - Skin Color
		// 0x02 - ?
		// 0x03 - Ring Attire Item
		// 0x04 - Ring Attire Color 1
		// 0x05 - Ring Attire Color 2
		// 0x06 - Upper Attire Item
		// 0x07 - Upper Attire Color 1
		// 0x08 - Upper Attire Color 2
		// 0x09 - Head Shape
		// 0x0A - Hair Color
		// 0x0B - "Using Mask" flag
		// 0x0C - Face/Mask Number
		// 0x0D - ?
		// 0x0E - ?
		// 0x0F - Hair Type
		// 0x10 - ?
		// 0x11 - ?
		// 0x12 - Front Hair/Mask Extra 1
		// 0x13 - Mask Color 1
		// 0x14 - Mask Color 2
		// 0x15 - Facial Hair/Mask Extra 2
		// 0x16 - Mask Color 3
		// 0x17 - Mask Color 4
		// 0x18 - Facepaint
		// 0x19 - ?
		// 0x1A - ?
		// 0x1B - Face Accessory
		// 0x1C - ?
		// 0x1D - ?
		// 0x1E - Gloves Item
		// 0x1F - Gloves Color 1
		// 0x20 - Gloves Color 2
		// 0x21 - Left Elbow Pad Item
		// 0x22 - Left Elbow Pad Color
		// 0x23 - ?
		// 0x24 - Right Elbow Pad Item
		// 0x25 - Right Elbow Pad Color
		// 0x26 - ?
		// 0x27 - Tattoo
		// 0x28 - ?
		// 0x29 - ?
		// 0x2A - Wristband Item
		// 0x2B - Wristband Color
		// 0x2C - ?
		// 0x2D - Left Knee Pad Item
		// 0x2E - Left Knee Pad Color
		// 0x2F - ?
		// 0x30 - Right Knee Pad Item
		// 0x31 - Right Knee Pad Color
		// 0x32 - ?
		// 0x33 - Boots Item
		// 0x34 - Boots Color 1
		// 0x35 - Boots Color 2
		// 0x36 - Entrance Attire Item
		// 0x37 - Entrance Attire Color 1
		// 0x38 - Entrance Attire Color 2
		// 0x39 - Entrance Weapon

		public string ToClipboardString()
		{
			ClipboardStringBuilder.Clear();
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudBodyType.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudSkinColor.Value));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudRingAttire.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccRingAttireColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccRingAttireColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudUpperAttire.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccUpperAttireColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccUpperAttireColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudHeadShape.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccHairColor.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbUsingMask.Checked ? 1 : 0));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudFaceNumber.Value));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudHairType.Value));
			ClipboardStringBuilder.Append("0000");

			// annoyance: some values are used for different purposes depending on if the wrestler is masked or not
			if (cbUsingMask.Checked)
			{
				// "Mask Extra 1"
				ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudMaskAccessory1.Value));
			}
			else
			{
				// front hair
				ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudFrontHair.Value));
			}

			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccMaskColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccMaskColor2.GetColorNum()));

			if (cbUsingMask.Checked)
			{
				// "Mask Extra 2"
				ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudMaskAccessory2.Value));
			}
			else
			{
				// facial hair
				ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudFacialHair.Value));
			}

			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccMaskColor3.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccMaskColor4.GetColorNum()));

			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudFacepaint.Value));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudAccessory.Value));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudGloves.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccGlovesColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccGlovesColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudLeftElbowPad.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccLeftElbowPadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudRightElbowPad.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccRightElbowPadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudTattoo.Value));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudWristband.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccWristbandColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudLeftKneePad.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccLeftKneePadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudRightKneePad.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccRightKneePadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudBoots.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccBootsColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccBootsColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudEntranceAttire.Value));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccEntranceAttireColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cccEntranceAttireColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (int)nudEntranceWeapon.Value));

			return ClipboardStringBuilder.ToString();
		}

		public bool FromString(string input)
		{
			string costumeHex = Clipboard.GetText();
			// todo: validate input (should only contain character ranges 0-9, A-F, whitespace)

			// remove any whitespace that may have been added
			costumeHex = costumeHex.Replace(" ", String.Empty);
			costumeHex = costumeHex.Replace("\n", String.Empty);
			costumeHex = costumeHex.Replace("\r", String.Empty);
			costumeHex = costumeHex.Replace("\t", String.Empty);

			// after normalization, string should be 116 chars
			if (costumeHex.Length != 116)
			{
				return false;
			}

			// parsing is trickier than No Mercy
			for (int i = 0; i < costumeHex.Length/2; i++)
			{
				// skip any value that doesn't get used
				if (SkipList.Contains(i))
				{
					continue;
				}

				string s = costumeHex.Substring(i * 2, 2);
				int value;
				if (int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value))
				{
					// great! but now we have to figure out where this actually belongs
					switch (i)
					{
						case 0: nudBodyType.Value = value; break;
						case 1: nudSkinColor.Value = value; break;
						case 3: nudRingAttire.Value = value; break;
						case 4: cccRingAttireColor1.SetColorNum(value); break;
						case 5: cccRingAttireColor2.SetColorNum(value); break;
						case 6: nudUpperAttire.Value = value; break;
						case 7: cccUpperAttireColor1.SetColorNum(value); break;
						case 8: cccUpperAttireColor2.SetColorNum(value); break;
						case 9: nudHeadShape.Value = value; break;
						case 10: cccHairColor.SetColorNum(value); break;
						case 11: cbUsingMask.Checked = (value == 1); break;
						case 12: nudFaceNumber.Value = value; break;
						case 15: nudHairType.Value = value; break;
						case 18:
							// used for two purposes; fill both (hopefully causes no issues)
							nudMaskAccessory1.Value = value;
							nudFrontHair.Value = value;
							break;
						case 19: cccMaskColor1.SetColorNum(value); break;
						case 20: cccMaskColor2.SetColorNum(value); break;
						case 21:
							// like 18, used for two purposes; fill both
							nudMaskAccessory2.Value = value;
							nudFacialHair.Value = value;
							break;
						case 22: cccMaskColor3.SetColorNum(value); break;
						case 23: cccMaskColor4.SetColorNum(value); break;
						case 24: nudFacepaint.Value = value; break;
						case 27: nudAccessory.Value = value; break;
						case 30: nudGloves.Value = value; break;
						case 31: cccGlovesColor1.SetColorNum(value); break;
						case 32: cccGlovesColor2.SetColorNum(value); break;
						case 33: nudLeftElbowPad.Value = value; break;
						case 34: cccLeftElbowPadColor.SetColorNum(value); break;
						case 36: nudRightElbowPad.Value = value; break;
						case 37: cccRightElbowPadColor.SetColorNum(value); break;
						case 39: nudTattoo.Value = value; break;
						case 42: nudWristband.Value = value; break;
						case 43: cccWristbandColor.SetColorNum(value); break;
						case 45: nudLeftKneePad.Value = value; break;
						case 46: cccLeftKneePadColor.SetColorNum(value); break;
						case 48: nudRightKneePad.Value = value; break;
						case 49: cccRightKneePadColor.SetColorNum(value); break;
						case 51: nudBoots.Value = value; break;
						case 52: cccBootsColor1.SetColorNum(value); break;
						case 53: cccBootsColor2.SetColorNum(value); break;
						case 54: nudEntranceAttire.Value = value; break;
						case 55: cccEntranceAttireColor1.SetColorNum(value); break;
						case 56: cccEntranceAttireColor2.SetColorNum(value); break;
						case 57: nudEntranceWeapon.Value = value; break;
					};
				}
			}

			return true; // ok
		}
	}
}
