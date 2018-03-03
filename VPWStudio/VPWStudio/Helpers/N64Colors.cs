using System;
using System.Drawing;

namespace VPWStudio
{
	public class N64Colors
	{
		/// <summary>
		/// Convert a UInt16 RGBA 5551 value to a Color.
		/// </summary>
		/// <param name="cv">Value to convert.</param>
		/// <returns>Converted Color.</returns>
		public static Color Value5551ToColor(UInt16 cv)
		{
			// old color calculation
			return Color.FromArgb(
				((cv & 0x0001) > 0) ? 0xFF : 0,
				((cv & 0xF800) >> 11) * 8,
				((cv & 0x07C0) >> 6) * 8,
				((cv & 0x003E) >> 1) * 8
			);

			// new color calculation from offsetter
			/*
			int red = ((cv & 0xF800) >> 8);
			red |= red >> 5;
			int grn = ((cv & 0x07C0) >> 3);
			grn |= grn >> 5;
			int blu = ((cv & 0x003E) << 2);
			blu |= blu >> 5;

			return Color.FromArgb(
				((cv & 0x0001) > 0) ? 0xFF : 0,
				red,
				grn,
				blu
			);
			*/
		}

		/// <summary>
		/// Convert a Color to UInt16 RGBA 5551 value.
		/// </summary>
		/// <param name="c">Color to convert.</param>
		/// <returns>Converted value.</returns>
		public static UInt16 ColorToValue5551(Color c)
		{
			UInt16 result = (UInt16)((c.A > 0) ? 1 : 0);
			result |= (UInt16)((c.R >> 3) << 11);
			result |= (UInt16)((c.G >> 3) << 6);
			result |= (UInt16)((c.B >> 3) << 1);
			return result;
		}
	}
}
