using System;
using System.Drawing;

namespace VPWStudio
{
	public class N64Colors
	{
		/// <summary>
		/// Convert a UInt16 to an RGBA 5551 color.
		/// </summary>
		/// <param name="cv">Value to convert.</param>
		/// <returns>Converted Color.</returns>
		public static Color ValueToColor5551(UInt16 cv)
		{
			return Color.FromArgb(
				((cv & 0x0001) > 0) ? 0xFF : 0,
				((cv & 0xF800) >> 11) * 8,
				((cv & 0x07C0) >> 6) * 8,
				((cv & 0x003E) >> 1) * 8
			);
		}
	}
}
