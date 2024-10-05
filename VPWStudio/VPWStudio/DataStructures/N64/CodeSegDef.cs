using System;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// N64 Code segment definition.
	/// </summary>
	public class CodeSegDef
	{
		#region Class Members
		/// <summary>
		/// Starting location of this segment in ROM.
		/// </summary>
		public UInt32 SegmentRomStart;

		/// <summary>
		/// Ending location of this segment in ROM.
		/// </summary>
		public UInt32 SegmentRomEnd;

		/// <summary>
		/// Starting location of this segment in RAM.
		/// </summary>
		public UInt32 SegmentStart;

		/// <summary>
		/// Starting location of this segment's code in RAM.
		/// </summary>
		public UInt32 SegmentTextStart;

		/// <summary>
		/// Ending location of this segment's code in RAM.
		/// </summary>
		public UInt32 SegmentTextEnd;

		/// <summary>
		/// Starting location of this segment's data in RAM.
		/// </summary>
		public UInt32 SegmentDataStart;

		/// <summary>
		/// Ending location of this segment's code in RAM.
		/// </summary>
		public UInt32 SegmentDataEnd;

		/// <summary>
		/// Starting location of BSS variables in RAM.
		/// </summary>
		public UInt32 SegmentBssStart;

		/// <summary>
		/// Ending location of BSS variables in RAM.
		/// </summary>
		public UInt32 SegmentBssEnd;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CodeSegDef()
		{
			SegmentRomStart = 0;
			SegmentRomEnd = 0;
			SegmentStart = 0;
			SegmentTextStart = 0;
			SegmentTextEnd = 0;
			SegmentDataStart = 0;
			SegmentDataEnd = 0;
			SegmentBssStart = 0;
			SegmentBssEnd = 0;
		}

		/// <summary>
		/// Constructor using specific values.
		/// </summary>
		/// <param name="_romStart"></param>
		/// <param name="_romEnd"></param>
		/// <param name="_segStart"></param>
		/// <param name="_textStart"></param>
		/// <param name="_textEnd"></param>
		/// <param name="_dataStart"></param>
		/// <param name="_dataEnd"></param>
		/// <param name="_bssStart"></param>
		/// <param name="_bssEnd"></param>
		public CodeSegDef(UInt32 _romStart, UInt32 _romEnd, UInt32 _segStart,
			UInt32 _textStart, UInt32 _textEnd, UInt32 _dataStart,
			UInt32 _dataEnd, UInt32 _bssStart, UInt32 _bssEnd)
		{
			SegmentRomStart = _romStart;
			SegmentRomEnd = _romEnd;
			SegmentStart = _segStart;
			SegmentTextStart = _textStart;
			SegmentTextEnd = _textEnd;
			SegmentDataStart = _dataStart;
			SegmentDataEnd = _dataEnd;
			SegmentBssStart = _bssStart;
			SegmentBssEnd = _bssEnd;
		}

		public CodeSegDef(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Check if a virtual address is within this segment.
		/// </summary>
		/// <param name="_addr">Virtual address to check.</param>
		/// <param name="_bss">Should the BSS region be checked as well?</param>
		/// <returns>True if this address is in this segment; false otherwise.</returns>
		public bool IsAddressInSeg(UInt32 _addr, bool _bss = false)
		{
			if (_bss)
			{
				return _addr >= SegmentStart && _addr <= SegmentBssEnd;
			}
			return _addr >= SegmentStart && _addr <= SegmentDataEnd;
		}

		/// <summary>
		/// Read CodeSegDef values using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>

		public void ReadData(BinaryReader br)
		{
			byte[] tmp = new byte[4];

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentRomStart = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentRomEnd = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentStart = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentTextStart = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentTextEnd = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentDataStart = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentDataEnd = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentBssStart = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			SegmentBssEnd = BitConverter.ToUInt32(tmp, 0);
		}
	}
}
