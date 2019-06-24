using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// Combined Pivot and Rotation values. (4 bytes)
	/// </summary>
	public class PivotRotation
	{
		/// <summary>
		/// X Pivot
		/// </summary>
		public short PivotX; // 12 bits

		/// <summary>
		/// Rotation
		/// </summary>
		public sbyte Rotation;

		/// <summary>
		/// Z Pivot
		/// </summary>
		public short PivotZ; // 12 bits

		/// <summary>
		/// Default constructor.
		/// </summary>
		public PivotRotation()
		{
			PivotX = 0;
			Rotation = 0;
			PivotZ = 0;
		}

		/// <summary>
		/// Specific constructor
		/// </summary>
		/// <param name="_x">Pivot X</param>
		/// <param name="_r">Rotation</param>
		/// <param name="_z">Pivot Z</param>
		public PivotRotation(short _x, sbyte _r, short _z)
		{
			PivotX = _x;
			Rotation = _r;
			PivotZ = _z;
		}

		/// <summary>
		/// BinaryData constructor
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public PivotRotation(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read PivotRotation data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// 3,2,3 format
			byte[] temp = br.ReadBytes(4);
			// XX_XX_XX_XX
			// XX_X|X_X|X_XX

			//PivotX: temp[0], temp[1]&0xF0
			PivotX = (short)(temp[0] << 4 | ((temp[1] & 0xF0) >> 4));

			//Rotation: temp[1]&0x0F, temp[2]&0xF0
			Rotation = (sbyte)((temp[1]&0x0F) << 4 | (temp[2]&0xF0) >> 4);

			//PivotZ: temp[2]&0x0F, temp[3]
			PivotZ = (short)((temp[2]&0x0F) << 8 | temp[3]);
		}

		/// <summary>
		/// Write PivotRotation data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] px = BitConverter.GetBytes(PivotX);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(px);
			}
			byte[] pz = BitConverter.GetBytes(PivotZ);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pz);
			}

			bw.Write((byte)((px[0] & 0x0F) << 4 | ((px[1] & 0xF0) >> 4)));
			bw.Write((byte)((px[1] & 0x0F) << 4 | (Rotation & 0xF0)>>4));
			bw.Write((byte)((Rotation & 0x0F) << 4 | (pz[0] & 0x0F)));
			bw.Write((pz[1]));
		}

		/// <summary>
		/// Returns PivotRotation data as a hex string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);
			WriteData(bw);
			string output = string.Empty;
			ms.Seek(0, SeekOrigin.Begin);
			for (int i = 0; i < 4; i++)
			{
				output += string.Format("{0:X2} ", ms.ReadByte());
			}
			bw.Close();
			return output;
		}
	}

	/// <summary>
	/// "Overall Movement" (shared displacement? 4 bytes)
	/// </summary>
	public class OverallMovementXYZ
	{
		/// <summary>
		/// Overall X movement
		/// </summary>
		public short OverallX; // 12 bits

		/// <summary>
		/// Overall Y movement
		/// </summary>
		public byte OverallY;

		/// <summary>
		/// Overall Z movement
		/// </summary>
		public short OverallZ; // 12 bits

		/// <summary>
		/// Default constructor.
		/// </summary>
		public OverallMovementXYZ()
		{
			OverallX = 0;
			OverallY = 0;
			OverallZ = 0;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_x">Overall X movement</param>
		/// <param name="_y">Overall Y movement</param>
		/// <param name="_z">Overall Z movement</param>
		public OverallMovementXYZ(short _x, byte _y, short _z)
		{
			OverallX = _x;
			OverallY = _y;
			OverallZ = _z;
		}

		/// <summary>
		/// BinaryReader constructor.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public OverallMovementXYZ(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read OverallMovementXYZ data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// 3,2,3 format
			byte[] temp = br.ReadBytes(4);
			// XX_XX_XX_XX
			// XX_X|X_X|X_XX

			//OverallX: temp[0], temp[1]&0xF0
			OverallX = (short)(temp[0] << 4 | ((temp[1] & 0xF0) >> 4));

			//OverallY: temp[1]&0x0F, temp[2]&0xF0
			OverallY = (byte)((temp[1] & 0x0F) << 4 | (temp[2] & 0xF0) >> 4);

			//OverallZ: temp[2]&0x0F, temp[3]
			OverallZ = (short)((temp[2] & 0x0F) << 8 | temp[3]);
		}

		/// <summary>
		/// Write OverallMovementXYZ data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] ox = BitConverter.GetBytes(OverallX);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ox);
			}
			byte[] oz = BitConverter.GetBytes(OverallZ);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(oz);
			}

			bw.Write((byte)((ox[0] & 0x0F) << 4 | ((ox[1] & 0xF0) >> 4)));
			bw.Write((byte)((ox[1] & 0x0F) << 4 | (OverallY & 0xF0) >> 4));
			bw.Write((byte)((OverallY & 0x0F) << 4 | (oz[0] & 0x0F)));
			bw.Write((oz[1]));
		}

		/// <summary>
		/// Returns OverallMovementXYZ data as a hex string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);
			WriteData(bw);
			string output = string.Empty;
			ms.Seek(0, SeekOrigin.Begin);
			for (int i = 0; i < 4; i++)
			{
				output += string.Format("{0:X2} ", ms.ReadByte());
			}
			bw.Close();
			return output;
		}
	}

	/// <summary>
	/// Movement X/Y/Z (3 bytes)
	/// </summary>
	public class MovementXYZ
	{
		/// <summary>
		/// X movement
		/// </summary>
		public byte X;

		/// <summary>
		/// Y movement
		/// </summary>
		public byte Y;

		/// <summary>
		/// Z movement
		/// </summary>
		public byte Z;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MovementXYZ()
		{
			X = 0;
			Y = 0;
			Z = 0;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_x">X movement</param>
		/// <param name="_y">Y movement</param>
		/// <param name="_z">Z movement</param>
		public MovementXYZ(byte _x, byte _y, byte _z)
		{
			X = _x;
			Y = _y;
			Z = _z;
		}

		/// <summary>
		/// Constructor using BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MovementXYZ(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read MovementXYZ data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			X = br.ReadByte();
			Y = br.ReadByte();
			Z = br.ReadByte();
		}

		/// <summary>
		/// Write MovementXYZ data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(X);
			bw.Write(Y);
			bw.Write(Z);
		}

		/// <summary>
		/// Returns MovementXYZ data as a hex string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0:X2} {1:X2} {2:X2} ", X, Y, Z);
		}
	}

	/// <summary>
	/// A single frame of animation data.
	/// </summary>
	public class AnimationFrame
	{
		// 0x62 bytes of data
		#region Class Members
		public PivotRotation Pelvis;
		public OverallMovementXYZ OverallMovement;
		public PivotRotation LowerAb;
		public MovementXYZ LowerAbMovement;
		public PivotRotation UpperBody;
		public MovementXYZ UpperBodyMovement;
		public PivotRotation Neck;
		public PivotRotation Head;
		public PivotRotation LowerLeftLeg;
		public PivotRotation UpperLeftLeg;
		public MovementXYZ LeftLegMovement;
		public PivotRotation LeftFoot;
		public PivotRotation LeftHand;
		public PivotRotation LeftFingers;
		public PivotRotation LowerLeftArm;
		public PivotRotation UpperLeftArm;
		public MovementXYZ LeftArmMovement;
		public PivotRotation LowerRightLeg;
		public PivotRotation UpperRightLeg;
		public MovementXYZ RightLegMovement;
		public PivotRotation RightFoot;
		public PivotRotation LowerRightArm;
		public PivotRotation RightHand;
		public PivotRotation RightFingers;
		public PivotRotation UpperRightArm;
		public MovementXYZ RightArmMovement;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AnimationFrame()
		{
			Pelvis = new PivotRotation();
			OverallMovement = new OverallMovementXYZ();
			LowerAb = new PivotRotation();
			LowerAbMovement = new MovementXYZ();
			UpperBody = new PivotRotation();
			UpperBodyMovement = new MovementXYZ();
			Neck = new PivotRotation();
			Head = new PivotRotation();
			LowerLeftLeg = new PivotRotation();
			UpperLeftLeg = new PivotRotation();
			LeftLegMovement = new MovementXYZ();
			LeftFoot = new PivotRotation();
			LeftHand = new PivotRotation();
			LeftFingers = new PivotRotation();
			LowerLeftArm = new PivotRotation();
			UpperLeftArm = new PivotRotation();
			LeftArmMovement = new MovementXYZ();
			LowerRightLeg = new PivotRotation();
			UpperRightLeg = new PivotRotation();
			RightLegMovement = new MovementXYZ();
			RightFoot = new PivotRotation();
			LowerRightArm = new PivotRotation();
			RightHand = new PivotRotation();
			RightFingers = new PivotRotation();
			UpperRightArm = new PivotRotation();
			RightArmMovement = new MovementXYZ();
		}

		/// <summary>
		/// Read AnimationFrame data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Pelvis.ReadData(br);
			OverallMovement.ReadData(br);
			LowerAb.ReadData(br);
			LowerAbMovement.ReadData(br);
			UpperBody.ReadData(br);
			UpperBodyMovement.ReadData(br);
			Neck.ReadData(br);
			Head.ReadData(br);
			LowerLeftLeg.ReadData(br);
			UpperLeftLeg.ReadData(br);
			LeftLegMovement.ReadData(br);
			LeftFoot.ReadData(br);
			LeftHand.ReadData(br);
			LeftFingers.ReadData(br);
			LowerLeftArm.ReadData(br);
			UpperLeftArm.ReadData(br);
			LeftArmMovement.ReadData(br);
			LowerRightLeg.ReadData(br);
			UpperRightLeg.ReadData(br);
			RightLegMovement.ReadData(br);
			RightFoot.ReadData(br);
			LowerRightArm.ReadData(br);
			RightHand.ReadData(br);
			RightFingers.ReadData(br);
			UpperRightArm.ReadData(br);
			RightArmMovement.ReadData(br);
		}

		/// <summary>
		/// Write AnimationFrame data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			Pelvis.WriteData(bw);
			OverallMovement.WriteData(bw);
			LowerAb.WriteData(bw);
			LowerAbMovement.WriteData(bw);
			UpperBody.WriteData(bw);
			UpperBodyMovement.WriteData(bw);
			Neck.WriteData(bw);
			Head.WriteData(bw);
			LowerLeftLeg.WriteData(bw);
			UpperLeftLeg.WriteData(bw);
			LeftLegMovement.WriteData(bw);
			LeftFoot.WriteData(bw);
			LeftHand.WriteData(bw);
			LeftFingers.WriteData(bw);
			LowerLeftArm.WriteData(bw);
			UpperLeftArm.WriteData(bw);
			LeftArmMovement.WriteData(bw);
			LowerRightLeg.WriteData(bw);
			UpperRightLeg.WriteData(bw);
			RightLegMovement.WriteData(bw);
			RightFoot.WriteData(bw);
			LowerRightArm.WriteData(bw);
			RightHand.WriteData(bw);
			RightFingers.WriteData(bw);
			UpperRightArm.WriteData(bw);
			RightArmMovement.WriteData(bw);
		}

		/// <summary>
		/// Returns AnimationFrame data as a hex string.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string output = Pelvis.ToString();
			output += OverallMovement.ToString();
			output += LowerAb.ToString();
			output += LowerAbMovement.ToString();
			output += UpperBody.ToString();
			output += UpperBodyMovement.ToString();
			output += Neck.ToString();
			output += Head.ToString();
			output += LowerLeftLeg.ToString();
			output += UpperLeftLeg.ToString();
			output += LeftLegMovement.ToString();
			output += LeftFoot.ToString();
			output += LeftHand.ToString();
			output += LeftFingers.ToString();
			output += LowerLeftArm.ToString();
			output += UpperLeftArm.ToString();
			output += LeftArmMovement.ToString();
			output += LowerRightLeg.ToString();
			output += UpperRightLeg.ToString();
			output += RightLegMovement.ToString();
			output += RightFoot.ToString();
			output += LowerRightArm.ToString();
			output += RightHand.ToString();
			output += RightFingers.ToString();
			output += UpperRightArm.ToString();
			return output += RightArmMovement.ToString();
		}
	}

	/// <summary>
	/// Animation data.
	/// </summary>
	public class AkiAnimation
	{
		/// <summary>
		/// Toki 2 values (4 bytes)
		/// </summary>
		public byte[] Toki2;
		// what ARE the Toki2 values?
		// 00 - 
		// 01 - 
		// 02 - 
		// 03 - (number of frames * 2)? (divide by 2 and add 1 to get actual number of frames)

		/// <summary>
		/// List of frames in this animation.
		/// </summary>
		public List<AnimationFrame> FrameData;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiAnimation()
		{
			Toki2 = new byte[4];
			FrameData = new List<AnimationFrame>();
		}

		/// <summary>
		/// Read AkiAnimation data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Toki2 = br.ReadBytes(4);

			// determine how many frames are in the animation
			// todo: this is meant to be calculated from the Toki2 values, but...
			long curPos = br.BaseStream.Position;
			br.BaseStream.Seek(0, SeekOrigin.End);
			long endPos = br.BaseStream.Position;
			br.BaseStream.Seek(curPos, SeekOrigin.Begin);

			int numBytes = (int)(endPos - curPos);
			int numFrames = numBytes / 0x62;
			for (int i = 0; i < numFrames; i++)
			{
				AnimationFrame frame = new AnimationFrame();
				frame.ReadData(br);
				FrameData.Add(frame);
			}
		}

		/// <summary>
		/// Write AkiAnimation data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// toki2
			bw.Write(Toki2[0]);
			bw.Write(Toki2[1]);
			bw.Write(Toki2[2]);
			bw.Write(Toki2[3]);

			// anim data
			for (int i = 0; i < FrameData.Count; i++)
			{
				FrameData[i].WriteData(bw);
			}
		}
	}
}
