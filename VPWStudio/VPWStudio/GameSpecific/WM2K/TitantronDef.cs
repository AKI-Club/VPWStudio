using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WWF WrestleMania 2000 TitanTron definition.
	/// </summary>
	public class TitantronDef
	{
		#region Class Members
		/// <summary>
		/// Pointer to frame list.
		/// </summary>
		public UInt32 FramePointer;

		/// <summary>
		/// Unknown value 1
		/// </summary>
		public UInt16 Unknown1;

		/// <summary>
		/// Name index used in menus.
		/// </summary>
		public UInt16 NameIndex;

		/// <summary>
		/// Unknown value 2
		/// </summary>
		public UInt16 Unknown2;

		/// <summary>
		/// Unknown value 3
		/// </summary>
		public UInt16 Unknown3;

		/// <summary>
		/// List of frames used in this TitanTron.
		/// </summary>
		public SortedList<int, TitantronFrame> Frames;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TitantronDef()
		{
			FramePointer = 0;
			Unknown1 = 0;
			NameIndex = 0;
			Unknown2 = 0;
			Unknown3 = 0;
			Frames = new SortedList<int, TitantronFrame>();
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			// part 1: data
			byte[] ptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ptr);
			}
			FramePointer = BitConverter.ToUInt32(ptr, 0);

			byte[] unk1 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk1);
			}
			Unknown1 = BitConverter.ToUInt16(unk1, 0);

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
			Unknown2 = BitConverter.ToUInt16(unk2, 0);

			byte[] unk3 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(unk3);
			}
			Unknown3 = BitConverter.ToUInt16(unk3, 0);

			// keep track of current position
			long curPos = br.BaseStream.Position;

			// part 2: frames
			bool readFrames = true;
			int frameNum = 0;
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
