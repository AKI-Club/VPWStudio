using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// This class houses routines for dealing with packed bits.
	/// Packed bits are found in WrestleMania 2000 and later, used for wrestler Parameters and Moves.
	/// </summary>
	public class PackedBitsHandler
	{
		// Addresses in these variable names are for VPW2
		#region Bit Packing Variables
		public static UInt16 bssMain_800571F0;
		public static UInt16 bssMain_800571F2;
		#endregion

		#region Bit Unpacking Variables
		public static UInt16 bssMain_800571F4;
		public static UInt16 bssMain_800571F6;
		#endregion

		// VPW2 relevant locations of interest:
		// tbl_8003C8E0 (pro-wrestler), tbl_8003CEDC (combo), tbl_8003D4EC (shootfighting) - move slot definitions
		// tbl_8003D930 - number of bits required for each move category (add 5 to value for real number of bits)
		// PackBits routine (runtime 80004D60, Z64 ROM offset 0x005960)
		// UnpackBits routine 

		// $a0=address, $a2=shiftVal1, $a3=shiftVal2, 0x10($sp)=numBits -> 0x18($sp), 0x14($sp)=mode -> 0x1C($sp)
		/// <summary>
		/// Bit packing routine.
		/// </summary>
		/// <param name="numBits">Number of bits to pack.</param>
		/// <param name="mode">0 for setup, 1 for actual bit packing.</param>
		/// <returns>Packed value, or 0 in certain circumstances (mode==0; numBits <=0).</returns>
		public static int PackBits(/* uint address, uint shiftVal1, uint shiftVal2, */ int numBits, int mode)
		{
			if (mode == 0)
			{
				// perform setup
				bssMain_800571F0 = 0;
				bssMain_800571F2 = 0;
				return 0;
			}

			// can't pack 0 or less bits
			if (numBits <= 0) { return 0; }

			// actual bit packing
			return 0;
		}

		/// <summary>
		/// Bit unpacking routine.
		/// </summary>
		/// VPW2 locations: runtime 80004F64, Z64 ROM offset 0x005B64
		/// <param name="numBits">Number of bits to unpack.</param>
		/// <param name="mode">0 for setup, 1 for actual bit unpacking.</param>
		/// <returns>Unpacked value, or 0 in certain circumstances (mode==0; numBits <=0).</returns>
		public static int UnpackBits(/* uint address, */ int numBits, int mode)
		{
			if (mode == 0)
			{
				// perform setup
				bssMain_800571F4 = 0;
				bssMain_800571F6 = 0;
				return 0;
			}

			// can't unpack 0 or less bits
			if (numBits <= 0) { return 0; }

			// actual bit unpacking
			return 0;
		}
	}
}
