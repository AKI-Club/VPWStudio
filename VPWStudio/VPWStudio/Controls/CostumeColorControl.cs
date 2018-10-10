using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Controls
{
	public partial class CostumeColorControl : UserControl
	{
		/// <summary>
		/// Possible color modes. Mainly effects what color palette is used.
		/// </summary>
		public enum ColorMode
		{
			VPW64,
			Revenge,
			Modern/*,
			Hair*/
		};

		#region Color Palettes
		/// <summary>
		/// Colors for WrestleMania 2000, VPW2, and No Mercy.
		/// </summary>
		private Color[] ModernColors = new Color[]
		{
			Color.FromArgb(255,0,0,0),       // Color 00: default costume colors
			/* Default Color Shades */
			Color.FromArgb(255,57,57,57),    // Color 01: Black
			Color.FromArgb(255,246,246,246), // Color 02: White
			Color.FromArgb(255,197,24,24),   // Color 03: Red
			Color.FromArgb(255,57,90,189),   // Color 04: Blue
			Color.FromArgb(255,16,148,57),   // Color 05: Green
			Color.FromArgb(255,230,156,49),  // Color 06: Yellow
			Color.FromArgb(255,255,90,41),   // Color 07: Orange
			Color.FromArgb(255,139,49,148),  // Color 08: Purple
			Color.FromArgb(255,205,49,205),  // Color 09: Pink
			Color.FromArgb(255,238,189,74),  // Color 0A: Gold

			/* Light Color Shades */
			Color.FromArgb(255,82,82,90),    // Color 0B: Light Black
			Color.FromArgb(255,238,238,255), // Color 0C: Light White
			Color.FromArgb(255,213,106,106), // Color 0D: Light Red
			Color.FromArgb(255,123,156,222), // Color 0E: Light Blue
			Color.FromArgb(255,65,180,123),  // Color 0F: Light Green
			Color.FromArgb(255,238,205,106), // Color 10: Light Yellow
			Color.FromArgb(255,230,131,90),  // Color 11: Light Orange
			Color.FromArgb(255,172,115,197), // Color 12: Light Purple
			Color.FromArgb(255,205,115,172), // Color 13: Light Pink
			Color.FromArgb(255,246,213,106), // Color 14: Light Gold

			/* Dark Color Shades */
			Color.FromArgb(255,65,74,65),    // Color 15: Dark Black
			Color.FromArgb(255,255,255,238), // Color 16: Dark White
			Color.FromArgb(255,131,16,8),    // Color 17: Dark Red
			Color.FromArgb(255,49,57,106),   // Color 18: Dark Blue
			Color.FromArgb(255,16,82,49),    // Color 19: Dark Green
			Color.FromArgb(255,139,74,0),    // Color 1A: Dark Yellow
			Color.FromArgb(255,156,41,24),   // Color 1B: Dark Orange
			Color.FromArgb(255,98,49,98),    // Color 1C: Dark Purple
			Color.FromArgb(255,139,41,115),  // Color 1D: Dark Pink
			Color.FromArgb(255,213,189,74),  // Color 1E: Dark Gold

			Color.FromArgb(255,164,164,197),  // Color 1F: Silver
		};

		/* todo: Hair colors, I guess. */
		#endregion

		/// <summary>
		/// Color mode used by this CostumeColorControl.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(ColorMode.Modern)]
		[Description("Color mode used by this CostumeColorControl."), Category("Behavior")]
		public ColorMode ColorModeType { get; set; }

		public CostumeColorControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Update the color of the CostumeColorControl.
		/// </summary>
		/// <param name="color">New color value.</param>
		public void SetColorNum(int color)
		{
			nudColor.Value = color;
		}

		public int GetColorNum()
		{
			return (int)nudColor.Value;
		}

		/// <summary>
		/// Update the color swatch preview.
		/// </summary>
		private void UpdateColor()
		{
			// update panelColorPreview based on nudColor.Value
			// todo: different games have different color IDs.
			// this currently assumes WM2K,VPW2,No Mercy; they have sane values.
			// Revenge and VPW64 are different.
			switch (ColorModeType)
			{
				case ColorMode.Modern:
				default:
					panelColorPreview.BackColor = ModernColors[(int)nudColor.Value];
					break;
			}
		}

		private void nudColor_ValueChanged(object sender, EventArgs e)
		{
			UpdateColor();
		}
	}
}
