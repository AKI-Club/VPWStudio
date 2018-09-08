using System;
using System.IO;

namespace VPWStudio.GameSpecific.NoMercy
{
	/// <summary>
	/// WWF No Mercy Costume Textures Definition.
	/// </summary>
	public class CostumeTextures
	{
		#region Members
		// [Values]
		public UInt16 RightPelvis;
		public UInt16 LeftPelvis;
		public UInt16 Stomach;
		public UInt16 LowerBack;
		public UInt16 Chest;
		public UInt16 UpperBack;
		public UInt16 LeftUpperArm;
		public UInt16 LeftLowerArm;
		public UInt16 LeftUpperLeg;
		public UInt16 LeftLowerLeg;
		public UInt16 LeftFoot;
		public UInt16 RightUpperArm;
		public UInt16 RightLowerArm;
		public UInt16 RightUpperLeg;
		public UInt16 RightLowerLeg;
		public UInt16 RightFoot;
		public UInt16 BackOfNeck;
		public UInt16 ExtraModel;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CostumeTextures()
		{
			RightPelvis = 0;
			LeftPelvis = 0;
			Stomach = 0;
			LowerBack = 0;
			Chest = 0;
			UpperBack = 0;
			LeftUpperArm = 0;
			LeftLowerArm = 0;
			LeftUpperLeg = 0;
			LeftLowerLeg = 0;
			LeftFoot = 0;
			RightUpperArm = 0;
			RightLowerArm = 0;
			RightUpperLeg = 0;
			RightLowerLeg = 0;
			RightFoot = 0;
			BackOfNeck = 0;
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
		/// <summary>
		/// Read CostumeTextures data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
		}

		/// <summary>
		/// Write CostumeTextures data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{

		}
		#endregion
	}
}
