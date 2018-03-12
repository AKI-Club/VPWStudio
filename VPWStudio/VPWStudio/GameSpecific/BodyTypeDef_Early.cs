using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Shared Body Type definition for World Tour, VPW64, and Revenge.
	/// </summary>
	public class BodyTypeDef_Early
	{
		/*
		 0x00: pelvis
		0x02: stomach
		0x04: chest
		0x06: left lower leg
		0x08: left upper leg
		0x0A: left foot
		0x0C: left palm
		0x0E: left fingers
		0x10: left forearm
		0x12: left upper arm
		0x14: right lower leg
		0x16: right upper leg
		0x18: right right foot
		0x1A: right forearm
		0x1C: right palm
		0x1E: right fingers
		0x20: right upper arm
		0x22: terminator
		 */

		public UInt16 PelvisModel;

		public UInt16 StomachModel;

		public UInt16 ChestModel;

		public UInt16 LeftLowerLegModel;

		public UInt16 LeftUpperLegModel;

		public UInt16 LeftFootModel;

		public UInt16 LeftPalmModel;

		public UInt16 LeftFingersModel;

		public UInt16 LeftForearmModel;

		public UInt16 LeftUpperArmModel;

		public UInt16 RightLowerLegModel;

		public UInt16 RightUpperLegModel;

		public UInt16 RightFootModel;

		public UInt16 RightForearmModel;

		public UInt16 RightPalmModel;

		public UInt16 RightFingersModel;

		public UInt16 RightUpperArmModel;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BodyTypeDef_Early()
		{
			PelvisModel = 0;
			StomachModel = 0;
			ChestModel = 0;
			LeftLowerLegModel = 0;
			LeftUpperLegModel = 0;
			LeftFootModel = 0;
			LeftPalmModel = 0;
			LeftFingersModel = 0;
			LeftForearmModel = 0;
			LeftUpperArmModel = 0;
			RightLowerLegModel = 0;
			RightUpperLegModel = 0;
			RightFootModel = 0;
			RightForearmModel = 0;
			RightPalmModel = 0;
			RightFingersModel = 0;
			RightUpperArmModel = 0;
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public BodyTypeDef_Early(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read helper.
		/// </summary>
		/// <param name="br"></param>
		/// <returns></returns>
		private UInt16 ReadHelper(BinaryReader br)
		{
			byte[] valBytes = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(valBytes);
			}
			return BitConverter.ToUInt16(valBytes, 0);
		}

		/// <summary>
		/// Read BodyTypeDef_Early data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			PelvisModel = ReadHelper(br);
			StomachModel = ReadHelper(br);
			ChestModel = ReadHelper(br);
			LeftLowerLegModel = ReadHelper(br);
			LeftUpperLegModel = ReadHelper(br);
			LeftFootModel = ReadHelper(br);
			LeftPalmModel = ReadHelper(br);
			LeftFingersModel = ReadHelper(br);
			LeftForearmModel = ReadHelper(br);
			LeftUpperArmModel = ReadHelper(br);
			RightLowerLegModel = ReadHelper(br);
			RightUpperLegModel = ReadHelper(br);
			RightFootModel = ReadHelper(br);
			RightForearmModel = ReadHelper(br);
			RightPalmModel = ReadHelper(br);
			RightFingersModel = ReadHelper(br);
			RightUpperArmModel = ReadHelper(br);
			ReadHelper(br); // terminator
		}

		/// <summary>
		/// Write helper.
		/// </summary>
		/// <param name="bw"></param>
		/// <param name="val"></param>
		private void WriteHelper(BinaryWriter bw, UInt16 val)
		{
			byte[] valBytes = BitConverter.GetBytes(val);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(valBytes);
			}
			bw.Write(valBytes);
		}

		/// <summary>
		/// Write BodyTypeDef_Early data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			WriteHelper(bw, PelvisModel);
			WriteHelper(bw, StomachModel);
			WriteHelper(bw, ChestModel);
			WriteHelper(bw, LeftLowerLegModel);
			WriteHelper(bw, LeftUpperLegModel);
			WriteHelper(bw, LeftFootModel);
			WriteHelper(bw, LeftPalmModel);
			WriteHelper(bw, LeftFingersModel);
			WriteHelper(bw, LeftForearmModel);
			WriteHelper(bw, LeftUpperArmModel);
			WriteHelper(bw, RightLowerLegModel);
			WriteHelper(bw, RightUpperLegModel);
			WriteHelper(bw, RightFootModel);
			WriteHelper(bw, RightForearmModel);
			WriteHelper(bw, RightPalmModel);
			WriteHelper(bw, RightFingersModel);
			WriteHelper(bw, RightUpperArmModel);
			bw.Write((UInt16)0); // terminator
		}
		#endregion
	}
}
