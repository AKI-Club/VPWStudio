using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// A single frame of a wrestler's Titantron.
	/// </summary>
	public class TitantronFrame
	{
		/// <summary>
		/// Value used to signify the end of the TitanTron script.
		/// </summary>
		public const UInt16 TITANTRON_END_FRAME_ID = 0xFFFF;

		#region Class Members
		/// <summary>
		/// File ID to show during this frame.
		/// </summary>
		public UInt16 FrameID;

		/// <summary>
		/// How long to show the frame for.
		/// Valid Values are 0 to 0x7FFF.
		/// </summary>
		public UInt16 FrameLength;

		/// <summary>
		/// Determines if the frame fades to the next image or not.
		/// </summary>
		public bool FadeFrame;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TitantronFrame()
		{
			FrameID = 0xFFFF;
			FrameLength = 0;
			FadeFrame = false;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id">File ID to display.</param>
		/// <param name="_length">Length to display frame.</param>
		/// <param name="_fade">Should this frame fade?</param>
		public TitantronFrame(UInt16 _id, UInt16 _length, bool _fade)
		{
			FrameID = _id;
			FrameLength = _length;
			FadeFrame = _fade;
		}

		/// <summary>
		/// Constructor using BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TitantronFrame(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read TitantronFrame data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <returns>true if not the final frame, false if it is the final frame.</returns>
		public bool ReadData(BinaryReader br)
		{
			byte[] fid = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fid);
			}
			FrameID = BitConverter.ToUInt16(fid, 0);

			byte[] flen = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(flen);
			}
			FrameLength = (UInt16)(BitConverter.ToUInt16(flen,0) & 0x7FFF);
			FadeFrame = (BitConverter.ToUInt16(flen, 0) & 0x8000) != 0;

			return FrameID != TITANTRON_END_FRAME_ID;
		}

		/// <summary>
		/// Write TitantronFrame data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] fid = BitConverter.GetBytes(FrameID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fid);
			}
			bw.Write(fid);

			byte[] flen = BitConverter.GetBytes(FrameLength);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(flen);
			}

			if (FadeFrame)
			{
				flen[0] |= 0x80;
			}
			bw.Write(flen);
		}
		#endregion
	}
}
