using System;
using System.IO;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// WCW/nWo Revenge Costume Definition
	/// </summary>
	public class CostumeDef
	{
		#region Class Members
		/// <summary>
		/// Unknown purpose.
		/// </summary>
		public byte Unknown;

		/// <summary>
		/// Body type (determines the models used)
		/// </summary>
		public byte BodyType;

		public UInt16 PelvisPalette;
		public UInt16 PelvisTexture;
		public UInt16 StomachPalette;
		public UInt16 StomachTexture;
		public UInt16 ChestPalette;
		public UInt16 ChestTexture;

		#region Left Side
		public UInt16 LeftBootPalette;
		public UInt16 LeftBootTexture;
		public UInt16 LeftLegPalette;
		public UInt16 LeftLegTexture;
		public UInt16 LeftFootPalette;
		public UInt16 LeftFootTexture;
		public UInt16 LeftPalmPalette;
		public UInt16 LeftPalmTexture;
		public UInt16 LeftFingersPalette;
		public UInt16 LeftFingersTexture;
		public UInt16 LeftForearmPalette;
		public UInt16 LeftForearmTexture;
		public UInt16 LeftUpperArmPalette;
		public UInt16 LeftUpperArmTexture;
		#endregion

		#region Right Side
		public UInt16 RightBootPalette;
		public UInt16 RightBootTexture;
		public UInt16 RightLegPalette;
		public UInt16 RightLegTexture;
		public UInt16 RightFootPalette;
		public UInt16 RightFootTexture;
		public UInt16 RightPalmPalette;
		public UInt16 RightPalmTexture;
		public UInt16 RightFingersPalette;
		public UInt16 RightFingersTexture;
		public UInt16 RightForearmPalette;
		public UInt16 RightForearmTexture;
		public UInt16 RightUpperArmPalette;
		public UInt16 RightUpperArmTexture;
		#endregion

		public UInt16 Terminator = 0;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CostumeDef()
		{
			Unknown = 0;
			BodyType = 0;
			PelvisPalette = 0;
			PelvisTexture = 0;
			StomachPalette = 0;
			StomachTexture = 0;
			ChestPalette = 0;
			ChestTexture = 0;
			LeftBootPalette = 0;
			LeftBootTexture = 0;
			LeftLegPalette = 0;
			LeftLegTexture = 0;
			LeftFootPalette = 0;
			LeftFootTexture = 0;
			LeftPalmPalette = 0;
			LeftPalmTexture = 0;
			LeftFingersPalette = 0;
			LeftFingersTexture = 0;
			LeftForearmPalette = 0;
			LeftForearmTexture = 0;
			LeftUpperArmPalette = 0;
			LeftUpperArmTexture = 0;
			RightBootPalette = 0;
			RightBootTexture = 0;
			RightLegPalette = 0;
			RightLegTexture = 0;
			RightFootPalette = 0;
			RightFootTexture = 0;
			RightPalmPalette = 0;
			RightPalmTexture = 0;
			RightFingersPalette = 0;
			RightFingersTexture = 0;
			RightForearmPalette = 0;
			RightForearmTexture = 0;
			RightUpperArmPalette = 0;
			RightUpperArmTexture = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public CostumeDef(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read helper.
		/// </summary>
		/// <param name="br"></param>
		/// <returns></returns>
		private UInt16 ReadElement(BinaryReader br)
		{
			byte[] rByte = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(rByte);
			}
			return BitConverter.ToUInt16(rByte, 0);
		}

		/// <summary>
		/// Read CostumeDef_Early data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Unknown = br.ReadByte();
			BodyType = br.ReadByte();
			PelvisPalette = ReadElement(br);
			PelvisTexture = ReadElement(br);
			StomachPalette = ReadElement(br);
			StomachTexture = ReadElement(br);
			ChestPalette = ReadElement(br);
			ChestTexture = ReadElement(br);
			LeftBootPalette = ReadElement(br);
			LeftBootTexture = ReadElement(br);
			LeftLegPalette = ReadElement(br);
			LeftLegTexture = ReadElement(br);
			LeftFootPalette = ReadElement(br);
			LeftFootTexture = ReadElement(br);
			LeftPalmPalette = ReadElement(br);
			LeftPalmTexture = ReadElement(br);
			LeftFingersPalette = ReadElement(br);
			LeftFingersTexture = ReadElement(br);
			LeftForearmPalette = ReadElement(br);
			LeftForearmTexture = ReadElement(br);
			LeftUpperArmPalette = ReadElement(br);
			LeftUpperArmTexture = ReadElement(br);
			RightBootPalette = ReadElement(br);
			RightBootTexture = ReadElement(br);
			RightLegPalette = ReadElement(br);
			RightLegTexture = ReadElement(br);
			RightFootPalette = ReadElement(br);
			RightFootTexture = ReadElement(br);
			RightForearmPalette = ReadElement(br);
			RightForearmTexture = ReadElement(br);
			RightPalmPalette = ReadElement(br);
			RightPalmTexture = ReadElement(br);
			RightFingersPalette = ReadElement(br);
			RightFingersTexture = ReadElement(br);
			RightUpperArmPalette = ReadElement(br);
			RightUpperArmTexture = ReadElement(br);
			Terminator = ReadElement(br);
		}

		/// <summary>
		/// Write helper.
		/// </summary>
		/// <param name="bw"></param>
		/// <param name="val"></param>
		private void WriteElement(BinaryWriter bw, UInt16 val)
		{
			byte[] wByte = BitConverter.GetBytes(val);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wByte);
			}
			bw.Write(wByte);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bw"></param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(Unknown);
			bw.Write(BodyType);
			WriteElement(bw, PelvisPalette);
			WriteElement(bw, PelvisTexture);
			WriteElement(bw, StomachPalette);
			WriteElement(bw, StomachTexture);
			WriteElement(bw, ChestPalette);
			WriteElement(bw, ChestTexture);
			WriteElement(bw, LeftBootPalette);
			WriteElement(bw, LeftBootTexture);
			WriteElement(bw, LeftLegPalette);
			WriteElement(bw, LeftLegTexture);
			WriteElement(bw, LeftFootPalette);
			WriteElement(bw, LeftFootTexture);
			WriteElement(bw, LeftPalmPalette);
			WriteElement(bw, LeftPalmTexture);
			WriteElement(bw, LeftFingersPalette);
			WriteElement(bw, LeftFingersTexture);
			WriteElement(bw, LeftForearmPalette);
			WriteElement(bw, LeftForearmTexture);
			WriteElement(bw, LeftUpperArmPalette);
			WriteElement(bw, LeftUpperArmTexture);
			WriteElement(bw, RightBootPalette);
			WriteElement(bw, RightBootTexture);
			WriteElement(bw, RightLegPalette);
			WriteElement(bw, RightLegTexture);
			WriteElement(bw, RightFootPalette);
			WriteElement(bw, RightFootTexture);
			WriteElement(bw, RightPalmPalette);
			WriteElement(bw, RightPalmTexture);
			WriteElement(bw, RightFingersPalette);
			WriteElement(bw, RightFingersTexture);
			WriteElement(bw, RightForearmPalette);
			WriteElement(bw, RightForearmTexture);
			WriteElement(bw, RightUpperArmPalette);
			WriteElement(bw, RightUpperArmTexture);
			WriteElement(bw, Terminator);
		}
		#endregion
	}
}
