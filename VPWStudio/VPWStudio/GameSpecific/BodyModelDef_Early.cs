using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Shared Body Model definition for World Tour, VPW64, and Revenge.
	/// </summary>
	public class BodyModelDef_Early
	{
		#region Class Members
		/// <summary>
		/// File ID of pelvis model.
		/// </summary>
		public UInt16 PelvisModel;

		/// <summary>
		/// File ID of stomach model.
		/// </summary>
		public UInt16 StomachModel;

		/// <summary>
		/// File ID of chest model.
		/// </summary>
		public UInt16 ChestModel;

		/// <summary>
		/// File ID of left lower leg model.
		/// </summary>
		public UInt16 LeftLowerLegModel;

		/// <summary>
		/// File ID of left upper leg model.
		/// </summary>
		public UInt16 LeftUpperLegModel;

		/// <summary>
		/// File ID of left foot model.
		/// </summary>
		public UInt16 LeftFootModel;

		/// <summary>
		/// File ID of left palm model.
		/// </summary>
		public UInt16 LeftPalmModel;

		/// <summary>
		/// File ID of left fingers model.
		/// </summary>
		public UInt16 LeftFingersModel;

		/// <summary>
		/// File ID of left forearm model.
		/// </summary>
		public UInt16 LeftForearmModel;

		/// <summary>
		/// File ID of left upper arm model.
		/// </summary>
		public UInt16 LeftUpperArmModel;

		/// <summary>
		/// File ID of right lower leg model.
		/// </summary>
		public UInt16 RightLowerLegModel;

		/// <summary>
		/// File ID of right upper leg model.
		/// </summary>
		public UInt16 RightUpperLegModel;

		/// <summary>
		/// File ID of right foot model.
		/// </summary>
		public UInt16 RightFootModel;

		/// <summary>
		/// File ID of right forearm model.
		/// </summary>
		public UInt16 RightForearmModel;

		/// <summary>
		/// File ID of right palm model.
		/// </summary>
		public UInt16 RightPalmModel;

		/// <summary>
		/// File ID of right fingers model.
		/// </summary>
		public UInt16 RightFingersModel;

		/// <summary>
		/// File ID of right upper arm model.
		/// </summary>
		public UInt16 RightUpperArmModel;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public BodyModelDef_Early()
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
		public BodyModelDef_Early(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

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
