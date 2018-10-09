using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Default Costume Data for Virtual Pro-Wrestling 2 wrestlers.
	/// </summary>
	public class DefaultCostumeData
	{
		/// <summary>
		/// Number of bytes in a DefaultCostumeData entry.
		/// </summary>
		public static int COSTUME_DATA_LENGTH = 49;

		#region Members
		public byte BodyType;
		public byte SkinColor;
		public byte RingAttire;
		public byte RingAttireColor1;
		public byte RingAttireColor2;
		public byte UpperAttire;
		public byte UpperAttireColor1;
		public byte UpperAttireColor2;
		public byte EntranceAttire;
		public byte EntranceAttireColor1;
		public byte EntranceAttireColor2;
		public byte EntranceWeapon;
		public byte Gloves;
		public byte GlovesColor1;
		public byte GlovesColor2;
		public byte Tattoo;
		public byte Wristband;
		public byte WristbandColor;
		public byte LeftElbowPad;
		public byte LeftElbowPadColor;
		public byte RightElbowPad;
		public byte RightElbowPadColor;
		public byte LeftKneePad;
		public byte LeftKneePadColor;
		public byte RightKneePad;
		public byte RightKneePadColor;
		public byte Boots;
		public byte BootsColor1;
		public byte BootsColor2;
		public byte Mask;
		public byte HeadShape;
		public byte Unknown1;
		public byte FaceNumber;
		public byte HairType;
		public byte HairColor;
		public byte FrontHair;
		public byte Unknown2;
		public byte FacialHair;
		public byte Facepaint;
		public byte Accessory;
		public byte MaskHeadShape;
		public byte MaskNumber;
		public byte MaskColor1;
		public byte MaskColor2;
		public byte MaskColor3;
		public byte MaskColor4;
		public byte MaskHairType;
		public byte MaskAccessory1;
		public byte MaskAccessory2;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultCostumeData()
		{
			BodyType = 0;
			SkinColor = 0;
			RingAttire = 0;
			RingAttireColor1 = 0;
			RingAttireColor2 = 0;
			UpperAttire = 0;
			UpperAttireColor1 = 0;
			UpperAttireColor2 = 0;
			EntranceAttire = 0;
			EntranceAttireColor1 = 0;
			EntranceAttireColor2 = 0;
			EntranceWeapon = 0;
			Gloves = 0;
			GlovesColor1 = 0;
			GlovesColor2 = 0;
			Tattoo = 0;
			Wristband = 0;
			WristbandColor = 0;
			LeftElbowPad = 0;
			LeftElbowPadColor = 0;
			RightElbowPad = 0;
			RightElbowPadColor = 0;
			LeftKneePad = 0;
			LeftKneePadColor = 0;
			RightKneePad = 0;
			RightKneePadColor = 0;
			Boots = 0;
			BootsColor1 = 0;
			BootsColor2 = 0;
			Mask = 0;
			HeadShape = 0;
			Unknown1 = 0;
			FaceNumber = 0;
			HairType = 0;
			HairColor = 0;
			FrontHair = 0;
			Unknown2 = 0;
			FacialHair = 0;
			Facepaint = 0;
			Accessory = 0;
			MaskHeadShape = 0;
			MaskNumber = 0;
			MaskColor1 = 0;
			MaskColor2 = 0;
			MaskColor3 = 0;
			MaskColor4 = 0;
			MaskHairType = 0;
			MaskAccessory1 = 0;
			MaskAccessory2 = 0;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read DefaultCostumeData using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			BodyType = br.ReadByte();
			SkinColor = br.ReadByte();
			RingAttire = br.ReadByte();
			RingAttireColor1 = br.ReadByte();
			RingAttireColor2 = br.ReadByte();
			UpperAttire = br.ReadByte();
			UpperAttireColor1 = br.ReadByte();
			UpperAttireColor2 = br.ReadByte();
			EntranceAttire = br.ReadByte();
			EntranceAttireColor1 = br.ReadByte();
			EntranceAttireColor2 = br.ReadByte();
			EntranceWeapon = br.ReadByte();
			Gloves = br.ReadByte();
			GlovesColor1 = br.ReadByte();
			GlovesColor2 = br.ReadByte();
			Tattoo = br.ReadByte();
			Wristband = br.ReadByte();
			WristbandColor = br.ReadByte();
			LeftElbowPad = br.ReadByte();
			LeftElbowPadColor = br.ReadByte();
			RightElbowPad = br.ReadByte();
			RightElbowPadColor = br.ReadByte();
			LeftKneePad = br.ReadByte();
			LeftKneePadColor = br.ReadByte();
			RightKneePad = br.ReadByte();
			RightKneePadColor = br.ReadByte();
			Boots = br.ReadByte();
			BootsColor1 = br.ReadByte();
			BootsColor2 = br.ReadByte();
			Mask = br.ReadByte();
			HeadShape = br.ReadByte();
			Unknown1 = br.ReadByte();
			FaceNumber = br.ReadByte();
			HairType = br.ReadByte();
			HairColor = br.ReadByte();
			FrontHair = br.ReadByte();
			Unknown2 = br.ReadByte();
			FacialHair = br.ReadByte();
			Facepaint = br.ReadByte();
			Accessory = br.ReadByte();
			MaskHeadShape = br.ReadByte();
			MaskNumber = br.ReadByte();
			MaskColor1 = br.ReadByte();
			MaskColor2 = br.ReadByte();
			MaskColor3 = br.ReadByte();
			MaskColor4 = br.ReadByte();
			MaskHairType = br.ReadByte();
			MaskAccessory1 = br.ReadByte();
			MaskAccessory2 = br.ReadByte();
		}

		/// <summary>
		/// Write DefaultCostumeData using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(BodyType);
			bw.Write(SkinColor);
			bw.Write(RingAttire);
			bw.Write(RingAttireColor1);
			bw.Write(RingAttireColor2);
			bw.Write(UpperAttire);
			bw.Write(UpperAttireColor1);
			bw.Write(UpperAttireColor2);
			bw.Write(EntranceAttire);
			bw.Write(EntranceAttireColor1);
			bw.Write(EntranceAttireColor2);
			bw.Write(EntranceWeapon);
			bw.Write(Gloves);
			bw.Write(GlovesColor1);
			bw.Write(GlovesColor2);
			bw.Write(Tattoo);
			bw.Write(Wristband);
			bw.Write(WristbandColor);
			bw.Write(LeftElbowPad);
			bw.Write(LeftElbowPadColor);
			bw.Write(RightElbowPad);
			bw.Write(RightElbowPadColor);
			bw.Write(LeftKneePad);
			bw.Write(LeftKneePadColor);
			bw.Write(RightKneePad);
			bw.Write(RightKneePadColor);
			bw.Write(Boots);
			bw.Write(BootsColor1);
			bw.Write(BootsColor2);
			bw.Write(Mask);
			bw.Write(HeadShape);
			bw.Write(Unknown1);
			bw.Write(FaceNumber);
			bw.Write(HairType);
			bw.Write(HairColor);
			bw.Write(FrontHair);
			bw.Write(Unknown2);
			bw.Write(FacialHair);
			bw.Write(Facepaint);
			bw.Write(Accessory);
			bw.Write(MaskHeadShape);
			bw.Write(MaskNumber);
			bw.Write(MaskColor1);
			bw.Write(MaskColor2);
			bw.Write(MaskColor3);
			bw.Write(MaskColor4);
			bw.Write(MaskHairType);
			bw.Write(MaskAccessory1);
			bw.Write(MaskAccessory2);
		}
		#endregion
	}
}
