﻿using System;
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
		/// Possible color modes. Mainly affects what color palette is used.
		/// </summary>
		public enum ColorMode
		{
			/// <summary>
			/// WWF WrestleMania 2000 and later (costume items)
			/// </summary>
			Modern,

			/// <summary>
			/// Virtual Pro-Wrestling 64
			/// </summary>
			VPW64,

			/// <summary>
			/// WCW/nWo Revenge
			/// </summary>
			Revenge,

			/// <summary>
			/// WWF WrestleMania 2000 (hair)
			/// </summary>
			Hair_WM2K,

			/// <summary>
			/// Virtual Pro-Wrestling 2 (hair)
			/// </summary>
			Hair_VPW2,

			/// <summary>
			/// WWF No Mercy (hair)
			/// </summary>
			Hair_NoMercy
		};

		#region Color Palettes
		/// <summary>
		/// Costume colors for Virtual Pro-Wrestling 64.
		/// </summary>
		/// "Index" is the internal value, "Color" is the in-game displayed value.
		private readonly Color[] VPW64Colors = new Color[]
		{
			Color.FromArgb(255,24,40,56),    // Index  0/Color  1: Black
			Color.FromArgb(255,248,0,0),     // Index  1/Color  2: Red
			Color.FromArgb(255,0,0,248),     // Index  2/Color  3: Blue
			Color.FromArgb(255,184,0,184),   // Index  3/Color  4: Purple
			Color.FromArgb(255,248,72,0),    // Index  4/Color  5: Orange
			Color.FromArgb(255,248,248,0),   // Index  5/Color  6: Yellow
			Color.FromArgb(255,0,184,248),   // Index  6/Color  7: Light Blue
			Color.FromArgb(255,248,72,184),  // Index  7/Color  8: Pink
			Color.FromArgb(255,0,248,0),     // Index  8/Color  9: Light Green
			Color.FromArgb(255,248,248,152), // Index  9/Color 10: Gold
			Color.FromArgb(255,216,216,216), // Index 10/Color 11: Silver
			Color.FromArgb(255,0,0,120),     // Index 11/Color 12: Navy Blue
			Color.FromArgb(255,0,120,0),     // Index 12/Color 13: Dark Green
			Color.FromArgb(255,72,72,120),   // Index 13/Color 14: Dark Gray
			Color.FromArgb(255,184,184,184), // Index 14/Color 15: Gray
			Color.FromArgb(255,248,248,248)  // Index 15/Color 16: White
		};

		/// <summary>
		/// Representational color strings, matching the order of VPW64Colors.
		/// </summary>
		private readonly string[] VPW64ColorNames = new string[16]
		{
			"Black",
			"Red",
			"Blue",
			"Purple",
			"Orange",
			"Yellow",
			"Light Blue",
			"Pink",
			"Light Green",
			"Gold",
			"Silver",
			"Navy Blue",
			"Dark Green",
			"Dark Gray",
			"Gray",
			"White"
		};

		/// <summary>
		/// Costume colors for WCW/nWo Revenge.
		/// </summary>
		private readonly Color[] RevengeColors = new Color[]
		{
			Color.Transparent, // Index 0: default costume color
			Color.FromArgb(255,205,41,41),   // Index 1: Red
			Color.FromArgb(255,82,90,180),   // Index 2: Blue
			Color.FromArgb(255,16,148,57),   // Index 3: Green
			Color.FromArgb(255,255,180,0),   // Index 4: Yellow
			Color.FromArgb(255,255,115,57),  // Index 5: Orange
			Color.FromArgb(255,139,49,148),  // Index 6: Purple
			Color.FromArgb(255,246,115,148), // Index 7: Pink
			Color.FromArgb(255,24,115,139),  // Index 8: Cyan
			Color.FromArgb(255,65,57,123),   // Index 9: Dark Purple
			Color.FromArgb(255,65,180,123),  // Index 10: Light Cyan
			Color.FromArgb(255,139,197,82),  // Index 11: Light Green
			Color.FromArgb(255,16,164,246),  // Index 12: Light Blue
			Color.FromArgb(255,189,156,74),  // Index 13: Gold
			Color.FromArgb(255,213,213,222), // Index 14: White
			Color.FromArgb(255,41,41,41),    // Index 15: Black
		};

		/// <summary>
		/// Representational color strings, matching the order of RevengeColors.
		/// </summary>
		private readonly string[] RevengeColorNames = new string[16]
		{
			"Default",
			"Red",
			"Blue",
			"Green",
			"Yellow",
			"Orange",
			"Purple",
			"Pink",
			"Cyan",
			"Dark Purple",
			"Light Cyan",
			"Light Green",
			"Light Blue",
			"Gold",
			"White",
			"Black"
		};

		/// <summary>
		/// Costume colors for WrestleMania 2000, VPW2, and No Mercy.
		/// </summary>
		private readonly Color[] ModernColors = new Color[]
		{
			Color.Transparent,       // Color 00: default costume colors
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

			Color.FromArgb(255,164,164,197)  // Color 1F: Silver
		};

		/// <summary>
		/// Representational color strings, matching the order of ModernColors.
		/// </summary>
		private readonly string[] ModernColorNames = new string[32]
		{
			"Default",
			"Black",
			"White",
			"Red",
			"Blue",
			"Green",
			"Yellow",
			"Orange",
			"Purple",
			"Pink",
			"Gold",
			"Light Black",
			"Light White",
			"Light Red",
			"Light Blue",
			"Light Green",
			"Light Yellow",
			"Light Orange",
			"Light Purple",
			"Light Pink",
			"Light Gold",
			"Dark Black",
			"Dark White",
			"Dark Red",
			"Dark Blue",
			"Dark Green",
			"Dark Yellow",
			"Dark Orange",
			"Dark Purple",
			"Dark Pink",
			"Dark Gold",
			"Silver"
		};

		/// <summary>
		/// Hair colors for WWF WrestleMania 2000.
		/// </summary>
		private readonly Color[] HairColors_WM2K = new Color[]
		{
			Color.FromArgb(255,16,8,8),		 // Hair Color 00: black
			Color.FromArgb(255,56,24,16),	 // Hair Color 01: brown
			Color.FromArgb(255,104,80,40),	 // Hair Color 02: blonde1
			Color.FromArgb(255,104,64,32),	 // Hair Color 03: blonde2
			Color.FromArgb(255,120,112,104), // Hair Color 04: white
			Color.FromArgb(255,32,32,56),	 // Hair Color 05: blue
			Color.FromArgb(255,88,16,16),	 // Hair Color 06: red
		};

		/// <summary>
		/// Hair colors for Virtual Pro-Wrestling 2.
		/// </summary>
		/// (same as WM2K, but with purple)
		private readonly Color[] HairColors_VPW2 = new Color[]
		{
			Color.FromArgb(255,16,8,8),      // Hair Color 00: black
			Color.FromArgb(255,56,24,16),    // Hair Color 01: brown
			Color.FromArgb(255,104,80,40),   // Hair Color 02: blonde1
			Color.FromArgb(255,104,64,32),   // Hair Color 03: blonde2
			Color.FromArgb(255,120,112,104), // Hair Color 04: white
			Color.FromArgb(255,32,32,56),    // Hair Color 05: blue
			Color.FromArgb(255,88,16,16),    // Hair Color 06: red
			Color.FromArgb(255,104,64,96),   // Hair Color 07: purple
		};

		/// <summary>
		/// Shared color names for WM2K and VPW2.
		/// </summary>
		private readonly string[] HairColorNames_Old = new string[]
		{
			"Black",
			"Brown",
			"Blonde 1",
			"Blonde 2",
			"White",
			"Blue",
			"Red",
			"Purple" // vpw2 only
		};

		/// <summary>
		/// Hair colors for WWF No Mercy.
		/// </summary>
		private readonly Color[] HairColors_NoMercy = new Color[]
		{
			// 8 colors, but not the same as vpw2
			Color.FromArgb(255,192,184,184), // Hair Color 00: white/silver
			Color.FromArgb(255,208,176,104), // Hair Color 01: blonde1
			Color.FromArgb(255,224,176,96),  // Hair Color 02: blonde2
			Color.FromArgb(255,152,80,32),   // Hair Color 03: brown1
			Color.FromArgb(255,112,56,24),   // Hair Color 04: brown2
			Color.FromArgb(255,64,32,32),    // Hair Color 05: dark brown
			Color.FromArgb(255,0,120,224),   // Hair Color 06: blue
			Color.FromArgb(255,184,64,64),   // Hair Color 07: red
		};

		/// <summary>
		/// Color names for WWF No Mercy.
		/// </summary>
		private readonly string[] HairColorNames_NoMercy = new string[]
		{
			"White/Silver",
			"Blonde 1",
			"Blonde 2",
			"Brown 1",
			"Brown 2",
			"Brown 2",
			"Dark Brown",
			"Blue",
			"Red"
		};

		/// <summary>
		/// ToolTip that shows up when hovering over the color swatch.
		/// </summary>
		private ToolTip ColorToolTip;

		private ColorMode colorModeType;

		private bool readOnly;
		#endregion

		/// <summary>
		/// Color mode used by this CostumeColorControl.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(ColorMode.Modern)]
		[Description("Color mode used by this CostumeColorControl."), Category("Behavior")]
		public ColorMode ColorModeType { get => colorModeType; set => colorModeType = value; }

		/// <summary>
		/// Determine if the color can be changed or not.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(false)]
		[Description("Read-only mode."), Category("Behavior")]
		public bool ReadOnly { get => readOnly; set => readOnly = value; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CostumeColorControl()
		{
			InitializeComponent();
			ColorToolTip = new ToolTip();
			UpdateColor();
		}

		/// <summary>
		/// Update the color of the CostumeColorControl.
		/// </summary>
		/// <param name="color">New color value.</param>
		public void SetColorNum(int color)
		{
			nudColor.Value = color;
			UpdateColor();
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
			switch (ColorModeType)
			{
				case ColorMode.VPW64:
					panelColorPreview.BackColor = VPW64Colors[(int)nudColor.Value];
					ColorToolTip.SetToolTip(panelColorPreview, VPW64ColorNames[(int)nudColor.Value]);
					break;

				case ColorMode.Revenge:
					panelColorPreview.BackColor = RevengeColors[(int)nudColor.Value];
					ColorToolTip.SetToolTip(panelColorPreview, RevengeColorNames[(int)nudColor.Value]);
					break;

				case ColorMode.Hair_WM2K:
					panelColorPreview.BackColor = HairColors_WM2K[(int)nudColor.Value];
					ColorToolTip.SetToolTip(panelColorPreview, HairColorNames_Old[(int)nudColor.Value]);
					break;

				case ColorMode.Hair_VPW2:
					panelColorPreview.BackColor = HairColors_VPW2[(int)nudColor.Value];
					ColorToolTip.SetToolTip(panelColorPreview, HairColorNames_Old[(int)nudColor.Value]);
					break;

				case ColorMode.Hair_NoMercy:
					panelColorPreview.BackColor = HairColors_NoMercy[(int)nudColor.Value];
					ColorToolTip.SetToolTip(panelColorPreview, HairColorNames_NoMercy[(int)nudColor.Value]);
					break;

				case ColorMode.Modern:
				default:
					panelColorPreview.BackColor = ModernColors[(int)nudColor.Value];
					ColorToolTip.SetToolTip(panelColorPreview, ModernColorNames[(int)nudColor.Value]);
					break;
			}
		}

		private void nudColor_ValueChanged(object sender, EventArgs e)
		{
			UpdateColor();
		}

		private void panelColorPreview_MouseHover(object sender, EventArgs e)
		{
			ColorToolTip.Show("test", this);
		}

		private void panelColorPreview_MouseLeave(object sender, EventArgs e)
		{
			ColorToolTip.Hide(this);
		}

		private void CostumeColorControl_Load(object sender, EventArgs e)
		{
			// set proper max value
			switch (ColorModeType)
			{
				case ColorMode.Hair_WM2K:
					nudColor.Maximum = 6;
					break;

				case ColorMode.Hair_VPW2:
				case ColorMode.Hair_NoMercy:
					nudColor.Maximum = 7;
					break;

				case ColorMode.VPW64:
				case ColorMode.Revenge:
					nudColor.Maximum = 15;
					break;

				case ColorMode.Modern:
				default:
					nudColor.Maximum = 31;
					break;
			}

			// disable editing if necessary
			nudColor.Enabled = !readOnly;
			nudColor.ReadOnly = readOnly;
		}
	}
}
