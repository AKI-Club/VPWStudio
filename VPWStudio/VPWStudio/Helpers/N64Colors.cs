using System;
using System.Drawing;

namespace VPWStudio
{
	public class N64Colors
	{
		#region Macros from Texture64
		private static int SCALE_5_8(int v)
		{
			return (v * 0xFF) / 0x1F;
		}

		private static byte SCALE_8_5(byte v)
		{
			return (byte)((((v) + 4) * 0x1F) / 0xFF);
		}

		private static byte SCALE_8_3(byte v)
		{
			return (byte)(v / 0x24);
		}

		private static byte SCALE_8_4(byte v)
		{
			return (byte)(v / 0x11);
		}
		#endregion

		/// <summary>
		/// Convert a UInt16 RGBA 5551 value to a Color.
		/// </summary>
		/// <param name="cv">Value to convert.</param>
		/// <returns>Converted Color.</returns>
		public static Color Value5551ToColor(UInt16 cv)
		{
			// old color calculation
			/*
			return Color.FromArgb(
				((cv & 0x0001) > 0) ? 0xFF : 0,
				((cv & 0xF800) >> 11) * 8,
				((cv & 0x07C0) >> 6) * 8,
				((cv & 0x003E) >> 1) * 8
			);
			*/

			// color calc from Texture64
			return Color.FromArgb(
				((cv & 0x0001) > 0) ? 0xFF : 0,
				SCALE_5_8((cv & 0xF800) >> 11),
				SCALE_5_8((cv & 0x07C0) >> 6),
				SCALE_5_8((cv & 0x003E) >> 1)
			);
		}

		/// <summary>
		/// Convert a Color to UInt16 RGBA 5551 value.
		/// </summary>
		/// <param name="c">Color to convert.</param>
		/// <returns>Converted value.</returns>
		public static UInt16 ColorToValue5551(Color c)
		{
			UInt16 result = (UInt16)((c.A > 0) ? 1 : 0);
			result |= (UInt16)((SCALE_8_5(c.R)) << 11);
			result |= (UInt16)((SCALE_8_5(c.G)) << 6);
			result |= (UInt16)((SCALE_8_5(c.B)) << 1);
			return result;
		}
	}
}
