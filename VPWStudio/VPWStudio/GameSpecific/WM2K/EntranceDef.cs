using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 entrance definition.
	/// </summary>
	public class EntranceDef
	{
		#region Class Members
		/// <summary>
		/// Pointer to frame list.
		/// </summary>
		public UInt32 FramePointer;

		/// <summary>
		/// Matching theme song index (or 0xFFFF if none)
		/// </summary>
		public UInt16 ThemeSong;

		/// <summary>
		/// Name index used in menus.
		/// </summary>
		public UInt16 NameIndex;

		/// <summary>
		/// Unknown value 1
		/// </summary>
		public UInt16 Unknown1;

		/// <summary>
		/// Lighting type to use.
		/// </summary>
		/// First nibble  (____xxxx): in ring
		/// Second nibble (xxxx____): on ramp
		public byte Lighting;

		/// <summary>
		/// How long the Titantron should run before the wrestler enters.
		/// </summary>
		public byte EntranceDelay;

		/// <summary>
		/// List of frames used in this TitanTron.
		/// </summary>
		public SortedList<int, TitantronFrame> Frames;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public EntranceDef()
		{
			FramePointer = 0;
			ThemeSong = 0xFFFF;
			NameIndex = 0;
			Unknown1 = 0;
			Lighting = 0;
			EntranceDelay = 0;
			Frames = new SortedList<int, TitantronFrame>();
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read EntranceDef data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// part 1: data
			byte[] ptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ptr);
			}
			FramePointer = BitConverter.ToUInt32(ptr, 0);

			byte[] theme = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(theme);
			}
			ThemeSong = BitConverter.ToUInt16(theme, 0);

			byte[] nidx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(nidx);
			}
			NameIndex = BitConverter.ToUInt16(nidx, 0);

			byte[] unk2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk2);
			}
			Unknown1 = BitConverter.ToUInt16(unk2, 0);

			Lighting = br.ReadByte();
			EntranceDelay = br.ReadByte();

			// keep track of current position
			long curPos = br.BaseStream.Position;

			// part 2: frames
			bool readFrames = true;
			int frameNum = 0;

			// todo: properly handle the seeking
			//br.BaseStream.Seek(Z64Rom.PointerToRom(FramePointer), SeekOrigin.Begin);

			while (readFrames)
			{
				TitantronFrame frame = new TitantronFrame(br);
				Frames.Add(frameNum, frame);
				frameNum++;

				// read until frame file ID is 0xFFFF.
				// yes, we want to store the terminator in the frame list, since
				// it could contain additional information that I haven't figured out yet.
				if (frame.FrameID == TitantronFrame.TITANTRON_END_FRAME_ID)
				{
					readFrames = false;
				}
			}

			// remember to rewind
			br.BaseStream.Seek(curPos, SeekOrigin.Begin);
		}

		// todo: public void WriteData(BinaryWriter bw)
		#endregion
	}
}
