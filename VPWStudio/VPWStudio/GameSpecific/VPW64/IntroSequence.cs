using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio.GameSpecific.VPW64
{
	// VPW64's intro format is a bit limited, but easier to deal with compared to World Tour.
	// Only two wrestlers can be on screen at once

	/// <summary>
	/// Introduction sequence animation data entry (Virtual Pro-Wrestling 64)
	/// </summary>
	/// Despite the name, it is also used for non-wrestler content (i.e. when WrestlerID4 == 0xFFFF)
	public class IntroSequenceWrestlerAnim
	{
		#region Class Members
		/// <summary>
		/// Wrestler ID4 to use.
		/// </summary>
		public ushort WrestlerID4;

		/// <summary>
		/// Animation File ID. A value of 0xFFFF means "use idle stance"?
		/// </summary>
		public ushort AnimationID;

		public short Unknown1;
		public short Timing;
		public short XPosition;
		public short ZPosition;
		public short Rotation;
		public short MoveSpeed;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public IntroSequenceWrestlerAnim()
		{
			WrestlerID4 = 0xFFFF;
			AnimationID = 0xFFFF;
			Unknown1 = 0;
			Timing = 0;
			XPosition = 0;
			ZPosition = 0;
			Rotation = 0;
			MoveSpeed = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public IntroSequenceWrestlerAnim(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			byte[] anim = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(anim);
			}
			AnimationID = BitConverter.ToUInt16(anim, 0);

			byte[] unk1 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			Unknown1 = BitConverter.ToInt16(unk1, 0);

			byte[] time = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(time);
			}
			Timing = BitConverter.ToInt16(time, 0);

			byte[] xpos = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(xpos);
			}
			XPosition = BitConverter.ToInt16(xpos, 0);

			byte[] zpos = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(zpos);
			}
			ZPosition = BitConverter.ToInt16(zpos, 0);

			byte[] rot = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(rot);
			}
			Rotation = BitConverter.ToInt16(rot, 0);

			byte[] speed = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(speed);
			}
			MoveSpeed = BitConverter.ToInt16(speed, 0);
		}

		/// <summary>
		/// Write data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] id4 = BitConverter.GetBytes(WrestlerID4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			bw.Write(id4);

			byte[] animID = BitConverter.GetBytes(AnimationID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(animID);
			}
			bw.Write(animID);

			byte[] unk1 = BitConverter.GetBytes(Unknown1);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			bw.Write(unk1);

			byte[] timing = BitConverter.GetBytes(Timing);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(timing);
			}
			bw.Write(timing);

			byte[] xpos = BitConverter.GetBytes(XPosition);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(xpos);
			}
			bw.Write(xpos);

			byte[] zpos = BitConverter.GetBytes(ZPosition);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(zpos);
			}
			bw.Write(zpos);

			byte[] rot = BitConverter.GetBytes(Rotation);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(rot);
			}
			bw.Write(rot);

			byte[] speed = BitConverter.GetBytes(MoveSpeed);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(speed);
			}
			bw.Write(speed);
		}
		#endregion
	}

	/// <summary>
	/// Introduction sequence entry (Virtual Pro-Wrestling 64)
	/// </summary>
	public class IntroSequenceEntry
	{
		#region Class Members
		/// <summary>
		/// Animation sequence for the first wrestler (or the sequence in general, if wrestler ID4 is 0xFFFF)
		/// </summary>
		public IntroSequenceWrestlerAnim Wrestler1;

		/// <summary>
		/// Animation sequence for the second wrestler (if applicable)
		/// </summary>
		public IntroSequenceWrestlerAnim Wrestler2;

		/// <summary>
		/// unknown value somehow related to the camera
		/// </summary>
		public short Unknown1;

		/// <summary>
		/// Defines the movement of the camera.
		/// </summary>
		public short CameraMovement;

		/// <summary>
		/// Unknown value, usually 0x0000. Terminator or padding?
		/// </summary>
		public short Unknown2;

		/// <summary>
		/// Unknown value, usually 0x0000. Terminator or padding?
		/// </summary>
		public short Unknown3;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public IntroSequenceEntry()
		{
			Wrestler1 = new IntroSequenceWrestlerAnim();
			Wrestler2 = new IntroSequenceWrestlerAnim();
			Unknown1 = 0;
			CameraMovement = 0;
			Unknown2 = 0;
			Unknown3 = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public IntroSequenceEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Wrestler1 = new IntroSequenceWrestlerAnim(br);
			Wrestler2 = new IntroSequenceWrestlerAnim(br);

			byte[] unk1 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			Unknown1 = BitConverter.ToInt16(unk1, 0);

			byte[] cam = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(cam);
			}
			CameraMovement = BitConverter.ToInt16(cam, 0);

			byte[] unk2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			Unknown2 = BitConverter.ToInt16(unk2, 0);

			byte[] unk3 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk3);
			}
			Unknown3 = BitConverter.ToInt16(unk3, 0);
		}

		/// <summary>
		/// Write data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			Wrestler1.WriteData(bw);
			Wrestler2.WriteData(bw);

			byte[] unk1 = BitConverter.GetBytes(Unknown1);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			bw.Write(unk1);

			byte[] cam = BitConverter.GetBytes(CameraMovement);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(cam);
			}
			bw.Write(cam);

			byte[] unk2 = BitConverter.GetBytes(Unknown2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			bw.Write(unk2);

			byte[] unk3 = BitConverter.GetBytes(Unknown3);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk3);
			}
			bw.Write(unk3);
		}
		#endregion
	}
}
