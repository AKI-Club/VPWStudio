using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Introduction sequence animation data entry (WCW/nWo Revenge and later games)
	/// </summary>
	public class IntroSequenceAnimation_Later
	{
		public ushort WrestlerID4;
		public short TimingA;
		public ushort AnimationID;
		public short TimingB;
		public short XPosition;
		public short YPosition;
		public short ZPosition;
		public short Rotation;
		public byte AnimFlags;
		public byte MoveSpeed;
		public byte Unknown;
		public byte CostumeNum;

		public IntroSequenceAnimation_Later()
		{
			WrestlerID4 = 0;
			TimingA = 0;
			AnimationID = 0;
			TimingB = 0;
			XPosition = 0;
			YPosition = 0;
			ZPosition = 0;
			Rotation = 0;
			AnimFlags = 0;
			MoveSpeed = 0;
			Unknown = 0;
			CostumeNum = 0;
		}

		public IntroSequenceAnimation_Later(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read IntroSequenceAnimation_Later data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			WrestlerID4 = BitConverter.ToUInt16(id4,0);

			byte[] timingA = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(timingA);
			}
			TimingA = BitConverter.ToInt16(timingA, 0);

			byte[] animID = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(animID);
			}
			AnimationID = BitConverter.ToUInt16(animID, 0);

			byte[] timingB = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(timingB);
			}
			TimingB = BitConverter.ToInt16(timingB, 0);

			byte[] xpos = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(xpos);
			}
			XPosition = BitConverter.ToInt16(xpos, 0);

			byte[] ypos = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ypos);
			}
			YPosition = BitConverter.ToInt16(ypos, 0);

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

			AnimFlags = br.ReadByte();
			MoveSpeed = br.ReadByte();
			Unknown = br.ReadByte();
			CostumeNum = br.ReadByte();
		}

		/// <summary>
		/// Write IntroSequenceAnimation_Later data using a BinaryWriter.
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

			byte[] timingA = BitConverter.GetBytes(TimingA);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(timingA);
			}
			bw.Write(timingA);

			byte[] animID = BitConverter.GetBytes(AnimationID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(animID);
			}
			bw.Write(animID);

			byte[] timingB = BitConverter.GetBytes(TimingB);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(timingB);
			}
			bw.Write(timingB);

			byte[] xpos = BitConverter.GetBytes(XPosition);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(xpos);
			}
			bw.Write(xpos);

			byte[] ypos = BitConverter.GetBytes(YPosition);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ypos);
			}
			bw.Write(ypos);

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

			bw.Write(AnimFlags);
			bw.Write(MoveSpeed);
			bw.Write(Unknown);
			bw.Write(CostumeNum);
		}
		#endregion
	}

	/// <summary>
	/// Introduction sequence graphic data entry (WCW/nWo Revenge and later games)
	/// </summary>
	public class IntroSequenceGraphic_Later
	{
		public ushort FileID;
		public ushort Width;
		public ushort Height;
		public ushort VertDisplacement;
		public ushort HorizStretch;
		public ushort Flags1;
		public short ScrollSpeed;
		public ushort Unknown;

		public IntroSequenceGraphic_Later()
		{
			FileID = 0;
			Width = 0;
			Height = 0;
			VertDisplacement = 0;
			HorizStretch = 0;
			Flags1 = 0;
			ScrollSpeed = 0;
			Unknown = 0;
		}

		public IntroSequenceGraphic_Later(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read IntroSequenceGraphic_Later data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] fileID = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fileID);
			}
			FileID = BitConverter.ToUInt16(fileID, 0);

			byte[] width = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(width);
			}
			Width = BitConverter.ToUInt16(width, 0);

			byte[] height = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(height);
			}
			Height = BitConverter.ToUInt16(height, 0);

			byte[] vertD = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(vertD);
			}
			VertDisplacement = BitConverter.ToUInt16(vertD, 0);

			byte[] hStretch = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(hStretch);
			}
			HorizStretch = BitConverter.ToUInt16(hStretch, 0);

			byte[] flags = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(flags);
			}
			Flags1 = BitConverter.ToUInt16(flags, 0);

			byte[] scroll = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(scroll);
			}
			ScrollSpeed = BitConverter.ToInt16(scroll, 0);

			byte[] unk = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			Unknown = BitConverter.ToUInt16(unk, 0);
		}

		/// <summary>
		/// Write IntroSequenceGraphic_Later data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] fileID = BitConverter.GetBytes(FileID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fileID);
			}
			bw.Write(fileID);

			byte[] width = BitConverter.GetBytes(Width);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(width);
			}
			bw.Write(width);

			byte[] height = BitConverter.GetBytes(Height);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(height);
			}
			bw.Write(height);

			byte[] vertD = BitConverter.GetBytes(VertDisplacement);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(vertD);
			}
			bw.Write(vertD);

			byte[] hStretch = BitConverter.GetBytes(HorizStretch);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(hStretch);
			}
			bw.Write(hStretch);

			byte[] flags = BitConverter.GetBytes(Flags1);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(flags);
			}
			bw.Write(flags);

			byte[] scroll = BitConverter.GetBytes(ScrollSpeed);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(scroll);
			}
			bw.Write(scroll);

			byte[] unk = BitConverter.GetBytes(Unknown);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			bw.Write(unk);
		}
		#endregion
	}
	
	/// <summary>
	/// Introduction sequence data used in WCW/nWo Revenge and later games.
	/// </summary>
	public class IntroSequence_Later
	{
		public byte MainSequence;
		public byte SubSequence;
		public byte Flags;
		public byte Transition;
		public ushort SceneTime;
		public ushort CameraMotion;
		public ushort Unknown;
		public ushort StageNum;
		public uint Pointer1;
		public uint Pointer2;
		public uint Pointer3;
		public uint Pointer4;

		public IntroSequence_Later()
		{
			MainSequence = 0;
			SubSequence = 0;
			Flags = 0;
			Transition = 0;
			SceneTime = 0;
			CameraMotion = 0;
			Unknown = 0;
			StageNum = 0;
			Pointer1 = 0;
			Pointer2 = 0;
			Pointer3 = 0;
			Pointer4 = 0;
		}

		public IntroSequence_Later(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read IntroSequence_Later data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			MainSequence = br.ReadByte();
			SubSequence = br.ReadByte();
			Flags = br.ReadByte();
			Transition = br.ReadByte();

			byte[] sceneTime = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(sceneTime);
			}
			SceneTime = BitConverter.ToUInt16(sceneTime,0);

			byte[] camMotion = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(camMotion);
			}
			CameraMotion = BitConverter.ToUInt16(camMotion, 0);

			byte[] unk = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			Unknown = BitConverter.ToUInt16(unk, 0);

			byte[] stage = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(stage);
			}
			StageNum = BitConverter.ToUInt16(stage, 0);

			byte[] pointer1 = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer1);
			}
			Pointer1 = BitConverter.ToUInt32(pointer1, 0);

			byte[] pointer2 = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer2);
			}
			Pointer2 = BitConverter.ToUInt32(pointer2, 0);

			byte[] pointer3 = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer3);
			}
			Pointer3 = BitConverter.ToUInt32(pointer3, 0);

			byte[] pointer4 = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer4);
			}
			Pointer4 = BitConverter.ToUInt32(pointer4, 0);
		}

		/// <summary>
		/// Write IntroSequence_Later data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(MainSequence);
			bw.Write(SubSequence);
			bw.Write(Flags);
			bw.Write(Transition);

			byte[] sceneTime = BitConverter.GetBytes(SceneTime);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(sceneTime);
			}
			bw.Write(sceneTime);

			byte[] camMotion = BitConverter.GetBytes(CameraMotion);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(camMotion);
			}
			bw.Write(camMotion);

			byte[] unk = BitConverter.GetBytes(Unknown);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk);
			}
			bw.Write(unk);

			byte[] stage = BitConverter.GetBytes(StageNum);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(stage);
			}
			bw.Write(stage);

			byte[] pointer1 = BitConverter.GetBytes(Pointer1);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer1);
			}
			bw.Write(pointer1);

			byte[] pointer2 = BitConverter.GetBytes(Pointer2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer2);
			}
			bw.Write(pointer2);

			byte[] pointer3 = BitConverter.GetBytes(Pointer3);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer3);
			}
			bw.Write(pointer3);

			byte[] pointer4 = BitConverter.GetBytes(Pointer4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(pointer4);
			}
			bw.Write(pointer4);
		}
		#endregion
	}
}
