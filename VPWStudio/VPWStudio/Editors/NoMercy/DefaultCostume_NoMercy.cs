using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Globalization;
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
		#region Constants
		/// <summary>
		/// Indexes of copy/pasted costume data that are not used.
		/// </summary>
		/// See comment in Copy/Paste region below for full offset list.
		private readonly List<int> SkipList = new List<int>()
		{
			2, 0x0D, 0x0E, 0x10, 0x11, 0x14, 0x16, 0x17, 0x19, 0x1A, 0x1C, 0x1D, 0x20, 0x23, 0x26, 0x29, 0x2C, 0x2F, 0x34, 0x35, 0x38, 0x3A, 0x3B
		};

		/// <summary>
		/// File ID of default costume data.
		/// </summary>
		private const UInt16 NOMERCY_DEFAULT_COSTUME_FILE = 1;
		#endregion

		/// <summary>
		/// Costume Data to view/edit.
		/// </summary>
		public DefaultCostumeData CostumeData = new DefaultCostumeData();

		/// <summary>
		/// Used to build the Costume Data clipboard string.
		/// </summary>
		protected StringBuilder ClipboardStringBuilder = new StringBuilder();

		/// <summary>
		/// Standard constructor.
		/// </summary>
		/// <param name="_costumeIndex">Costume index to load.</param>
		/// <param name="_path">Path to replacement default costumes file (optional).</param>
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

		#region Load Data
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
		#endregion

		/// <summary>
		/// Sets control values based on CostumeData.
		/// </summary>
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

		/// <summary>
		/// Writes all dialog data to CostumeData structure.
		/// </summary>
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

		#region Copy/Paste
		// in-game Smackdown Mall costume data; 0x3D bytes long
		// NTSC-U v1.0 addresses:
		// - 80297250 (not conducive to being edited)
		// - 8029728F (conducive to being edited)
		// 0x00 body type
		// 0x01 skin color
		// 0x02 ?
		// 0x03 ring attire
		// 0x04 ring attire color 1
		// 0x05 ring attire color 2
		// 0x06 upper attire
		// 0x07 upper attire color 1
		// 0x08 upper attire color 2
		// 0x09 entrance attire
		// 0x0A entrance attire color 1
		// 0x0B entrance attire color 2
		// 0x0C head type
		// 0x0D ?
		// 0x0E ?
		// 0x0F face number
		// 0x10 ?
		// 0x11 ?
		// 0x12 hair type
		// 0x13 hair color
		// 0x14 ?
		// 0x15 front hair type
		// 0x16 ?
		// 0x17 ?
		// 0x18 facial hair
		// 0x19 ?
		// 0x1A ?
		// 0x1B mask
		// 0x1C ?
		// 0x1D ?
		// 0x1E gloves
		// 0x1F gloves color
		// 0x20 ?
		// 0x21 elbow pad L
		// 0x22 elbow pad L color
		// 0x23 ?
		// 0x24 elbow pad R
		// 0x25 elbow pad R color
		// 0x26 ?
		// 0x27 wrist band
		// 0x28 wrist band color
		// 0x29 ?
		// 0x2A knee pad L
		// 0x2B knee pad L color
		// 0x2C ?
		// 0x2D knee pad R
		// 0x2E knee pad R color
		// 0x2F ?
		// 0x30 boots
		// 0x31 boots color 1
		// 0x32 boots color 2
		// 0x33 tattoo
		// 0x34 ?
		// 0x35 ?
		// 0x36 hats/caps
		// 0x37 hats/caps color
		// 0x38 ?
		// 0x39 entrance weapon
		// 0x3A ?
		// 0x3B ?
		// 0x3C picture/portrait

		/// <summary>
		/// Copy costume data (as hex) to clipboard.
		/// </summary>
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClipboardStringBuilder.Clear();
			ClipboardStringBuilder.Append(string.Format("{0:X2}",cbBodyType.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}",cbSkinColor.SelectedIndex));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbRingAttire.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccRingAttireColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccRingAttireColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbUpperAttire.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccUpperAttireColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccUpperAttireColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbEntranceAttire.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccEntranceAttireColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccEntranceAttireColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbHeadShape.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbFaces.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbHairType.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccHairColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbFrontHair.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbFacialHair.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbMasksEtc.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbGloves.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccGlovesColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbLeftElbowPad.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccLeftElbowPadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbRightElbowPad.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccRightElbowPadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbWristband.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccWristbandColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbLeftKneepad.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccLeftKneePadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbRightKneepad.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccRightKneePadColor.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbBoots.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccBootsColor1.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccBootsColor2.GetColorNum()));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbTattoo.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbHatsCaps.SelectedIndex));
			ClipboardStringBuilder.Append(string.Format("{0:X2}", (byte)cccHatsCaps.GetColorNum()));
			ClipboardStringBuilder.Append("00");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbEntranceWeapon.SelectedIndex));
			ClipboardStringBuilder.Append("0000");
			ClipboardStringBuilder.Append(string.Format("{0:X2}", cbPortrait.SelectedIndex));
			Clipboard.SetText(ClipboardStringBuilder.ToString());
		}

		/// <summary>
		/// Paste costume data (as hex) from clipboard.
		/// </summary>
		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string costumeHex = Clipboard.GetText();
			// todo: validate input (should only contain character ranges 0-9, A-F, whitespace)

			// remove any whitespace that may have been added
			costumeHex = costumeHex.Replace(" ", String.Empty);
			costumeHex = costumeHex.Replace("\n", String.Empty);
			costumeHex = costumeHex.Replace("\r", String.Empty);
			costumeHex = costumeHex.Replace("\t", String.Empty);

			// after normalization, string should be 122 chars
			if (costumeHex.Length != 122)
			{
				Program.ErrorMessageBox("Clipboard input not in expected format for Costume Data.");
				return;
			}

			// parsing is tricky
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
						case 0: cbBodyType.SelectedIndex = value; break;
						case 1: cbSkinColor.SelectedIndex = value; break;
						case 3: cbRingAttire.SelectedIndex = value; break;
						case 4: cccRingAttireColor1.SetColorNum(value); break;
						case 5: cccRingAttireColor2.SetColorNum(value); break;
						case 6: cbUpperAttire.SelectedIndex = value; break;
						case 7: cccUpperAttireColor1.SetColorNum(value); break;
						case 8: cccUpperAttireColor2.SetColorNum(value); break;
						case 9: cbEntranceAttire.SelectedIndex = value; break;
						case 10: cccEntranceAttireColor1.SetColorNum(value); break;
						case 11: cccEntranceAttireColor2.SetColorNum(value); break;
						case 12: cbHeadShape.SelectedIndex = value; break;
						case 15: cbFaces.SelectedIndex = value; break;
						case 18: cbHairType.SelectedIndex = value; break;
						case 19: cccHairColor.SetColorNum(value); break;
						case 21: cbFrontHair.SelectedIndex = value; break;
						case 24: cbFacialHair.SelectedIndex = value; break;
						case 27: cbMasksEtc.SelectedIndex = value; break;
						case 30: cbGloves.SelectedIndex = value; break;
						case 31: cccGlovesColor.SetColorNum(value); break;
						case 33: cbLeftElbowPad.SelectedIndex = value; break;
						case 34: cccLeftElbowPadColor.SetColorNum(value); break;
						case 36: cbRightElbowPad.SelectedIndex = value; break;
						case 37: cccRightElbowPadColor.SetColorNum(value); break;
						case 39: cbWristband.SelectedIndex = value; break;
						case 40: cccWristbandColor.SetColorNum(value); break;
						case 42: cbLeftKneepad.SelectedIndex = value; break;
						case 43: cccLeftKneePadColor.SetColorNum(value); break;
						case 45: cbRightKneepad.SelectedIndex = value; break;
						case 46: cccRightKneePadColor.SetColorNum(value); break;
						case 48: cbBoots.SelectedIndex = value; break;
						case 49: cccBootsColor1.SetColorNum(value); break;
						case 50: cccBootsColor2.SetColorNum(value); break;
						case 51: cbTattoo.SelectedIndex = value; break;
						case 54: cbHatsCaps.SelectedIndex = value; break;
						case 55: cccHatsCaps.SetColorNum(value); break;
						case 57: cbEntranceWeapon.SelectedIndex = value; break;
						case 60: cbPortrait.SelectedIndex = value; break;
						default: break;
					}
				}
			}
			
		}
		#endregion
	}
}
