using System.IO;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// Default costume data for WWF WrestleMania 2000 wrestlers.
	/// </summary>
	public class DefaultCostumeData
	{
		/// <summary>
		/// Number of bytes in a DefaultCostumeData entry.
		/// </summary>
		public static int COSTUME_DATA_LENGTH = 36;

		#region Members
		public byte HeadShape;
		public byte HairColor;
		public byte Unknown1;
		public byte FaceNumber;
		public byte Hair1;
		public byte Hair2;
		public byte FacialHair;
		public byte MasksEtc;
		public byte BodySize;
		public byte SkinColor;
		public byte RingAttire;
		public byte RingAttireColor1;
		public byte RingAttireColor2;
		public byte UpperAttire;
		public byte UpperAttireColor1;
		public byte UpperAttireColor2;
		public byte Gloves;
		public byte GlovesColor1;
		public byte GlovesColor2;
		public byte Tattoo;
		public byte Unknown2;
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
		public byte EntranceAttire;
		public byte EntranceWeapon;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultCostumeData()
		{
			HeadShape = 0;
			HairColor = 0;
			Unknown1 = 0;
			FaceNumber = 0;
			Hair1 = 0;
			Hair2 = 0;
			FacialHair = 0;
			MasksEtc = 0;
			BodySize = 0;
			SkinColor = 0;
			RingAttire = 0;
			RingAttireColor1 = 0;
			RingAttireColor2 = 0;
			UpperAttire = 0;
			UpperAttireColor1 = 0;
			UpperAttireColor2 = 0;
			Gloves = 0;
			GlovesColor1 = 0;
			GlovesColor2 = 0;
			Tattoo = 0;
			Unknown2 = 0;
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
			EntranceAttire = 0;
			EntranceWeapon = 0;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read DefaultCostumeData using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			HeadShape = br.ReadByte();
			HairColor = br.ReadByte();
			Unknown1 = br.ReadByte();
			FaceNumber = br.ReadByte();
			Hair1 = br.ReadByte();
			Hair2 = br.ReadByte();
			FacialHair = br.ReadByte();
			MasksEtc = br.ReadByte();
			BodySize = br.ReadByte();
			SkinColor = br.ReadByte();
			RingAttire = br.ReadByte();
			RingAttireColor1 = br.ReadByte();
			RingAttireColor2 = br.ReadByte();
			UpperAttire = br.ReadByte();
			UpperAttireColor1 = br.ReadByte();
			UpperAttireColor2 = br.ReadByte();
			Gloves = br.ReadByte();
			GlovesColor1 = br.ReadByte();
			GlovesColor2 = br.ReadByte();
			Tattoo = br.ReadByte();
			Unknown2 = br.ReadByte();
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
			EntranceAttire = br.ReadByte();
			EntranceWeapon = br.ReadByte();
		}

		/// <summary>
		/// Write DefaultCostumeData using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(HeadShape);
			bw.Write(HairColor);
			bw.Write(Unknown1);
			bw.Write(FaceNumber);
			bw.Write(Hair1);
			bw.Write(Hair2);
			bw.Write(FacialHair);
			bw.Write(MasksEtc);
			bw.Write(BodySize);
			bw.Write(SkinColor);
			bw.Write(RingAttire);
			bw.Write(RingAttireColor1);
			bw.Write(RingAttireColor2);
			bw.Write(UpperAttire);
			bw.Write(UpperAttireColor1);
			bw.Write(UpperAttireColor2);
			bw.Write(Gloves);
			bw.Write(GlovesColor1);
			bw.Write(GlovesColor2);
			bw.Write(Tattoo);
			bw.Write(Unknown2);
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
			bw.Write(EntranceAttire);
			bw.Write(EntranceWeapon);
		}
		#endregion

	}
}
