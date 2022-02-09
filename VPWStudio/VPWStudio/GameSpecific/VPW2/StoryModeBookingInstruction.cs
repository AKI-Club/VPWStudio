using System;
using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Story Mode Booking Instruction, probably specific to VPW2.
	/// </summary>
	public class StoryModeBookingInstruction
	{
		#region Special Values
		/// <summary>
		/// Value used when a slot has no match.
		/// </summary>
		public static readonly UInt16 NO_MATCH = 0xFFFF;

		public static readonly UInt16 CHAMPION_CARNIVAL_FINAL = 7;

		public static readonly UInt16 TAG_LEAGUE_FINAL = 8;

		public static readonly UInt16 BATTLE_ROYAL = 9;

		public static readonly UInt16 SINGLES_TOURNAMENT = 0xA;

		public static readonly UInt16 TAG_TOURNAMENT = 0xB;

		public static readonly UInt16 CHAMPION_CARNIVAL_LEAGUE = 0xC;

		public static readonly UInt16 TAG_LEAGUE = 0xD;
		#endregion

		#region Members
		/// <summary>
		/// Booking values.
		/// </summary>
		public UInt16[] Values;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StoryModeBookingInstruction()
		{
			Values = new UInt16[10]{
				NO_MATCH, NO_MATCH, NO_MATCH, NO_MATCH, NO_MATCH,
				NO_MATCH, NO_MATCH, NO_MATCH, NO_MATCH, NO_MATCH
			};
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StoryModeBookingInstruction(BinaryReader br)
		{
			Values = new UInt16[10];
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read a single element.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <returns>Value of element.</returns>
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
		/// Write an element.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		/// <param name="val">Value to write.</param>
		private void WriteElement(BinaryWriter bw, UInt16 val)
		{
			byte[] v = BitConverter.GetBytes(val);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(v);
			}
			bw.Write(v);
		}

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			for (int i = 0; i < Values.Length; i++)
			{
				Values[i] = ReadElement(br);
			}
		}

		public void WriteData(BinaryWriter bw)
		{
			for (int i = 0; i < Values.Length; i++)
			{
				WriteElement(bw, Values[i]);
			}
		}
		#endregion
	}
}
