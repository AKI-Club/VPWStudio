using System;
using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Costume Texture Definition.
	/// </summary>
	/// The models use a similar format...
	public class CostumeTextures
	{
		#region Members
		public UInt16 Pelvis;
		public UInt16 Stomach;
		public UInt16 Chest;
		public UInt16 LeftLowerLeg;
		public UInt16 LeftUpperLeg;
		public UInt16 LeftFoot;
		public UInt16 Unused1;
		public UInt16 Unused2;
		public UInt16 LeftLowerArm;
		public UInt16 LeftUpperArm;
		public UInt16 RightLowerLeg;
		public UInt16 RightUpperLeg;
		public UInt16 RightFoot;
		public UInt16 RightLowerArm;
		public UInt16 Unused3;
		public UInt16 Unused4;
		public UInt16 RightUpperArm;
		public UInt16 ExtraModel;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CostumeTextures()
		{
			Pelvis = 0;
			Stomach = 0;
			Chest = 0;
			LeftLowerLeg = 0;
			LeftUpperLeg = 0;
			LeftFoot = 0;
			Unused1 = 0;
			Unused2 = 0;
			LeftLowerArm = 0;
			LeftUpperArm = 0;
			RightLowerLeg = 0;
			RightUpperLeg = 0;
			RightFoot = 0;
			RightLowerArm = 0;
			Unused3 = 0;
			Unused4 = 0;
			RightUpperArm = 0;
			ExtraModel = 0;
		}

		#region Helpers
		/// <summary>
		/// Read a CostumeTexture element.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <returns>Value of CostumeTexture element.</returns>
		private UInt16 ReadElement(BinaryReader br)
		{
			byte[] v = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(v);
			}
			return BitConverter.ToUInt16(v, 0);
		}

		/// <summary>
		/// Write a CostumeTexture element.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		/// <param name="val">Value of CostumeTexture element to write.</param>
		private void WriteElement(BinaryWriter bw, UInt16 val)
		{
			byte[] v = BitConverter.GetBytes(val);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(v);
			}
			bw.Write(v);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			Pelvis = ReadElement(br);
			Stomach = ReadElement(br);
			Chest = ReadElement(br);
			LeftLowerLeg = ReadElement(br);
			LeftUpperLeg = ReadElement(br);
			LeftFoot = ReadElement(br);
			Unused1 = ReadElement(br);
			Unused2 = ReadElement(br);
			LeftLowerArm = ReadElement(br);
			LeftUpperArm = ReadElement(br);
			RightLowerLeg = ReadElement(br);
			RightUpperLeg = ReadElement(br);
			RightFoot = ReadElement(br);
			RightLowerArm = ReadElement(br);
			Unused3 = ReadElement(br);
			Unused4 = ReadElement(br);
			RightUpperArm = ReadElement(br);
			ExtraModel = ReadElement(br);
		}

		public void WriteData(BinaryWriter bw)
		{
			WriteElement(bw, Pelvis);
			WriteElement(bw, Stomach);
			WriteElement(bw, Chest);
			WriteElement(bw, LeftLowerLeg);
			WriteElement(bw, LeftUpperLeg);
			WriteElement(bw, LeftFoot);
			WriteElement(bw, Unused1);
			WriteElement(bw, Unused2);
			WriteElement(bw, LeftLowerArm);
			WriteElement(bw, LeftUpperArm);
			WriteElement(bw, RightLowerLeg);
			WriteElement(bw, RightUpperLeg);
			WriteElement(bw, RightFoot);
			WriteElement(bw, RightLowerArm);
			WriteElement(bw, Unused3);
			WriteElement(bw, Unused4);
			WriteElement(bw, RightUpperArm);
			WriteElement(bw, ExtraModel);
		}
		#endregion
	}
}
