﻿using System;
using System.Collections.Generic;

namespace VPWStudio
{
	// note: this list is in flux until all formats are known
	public enum FileTypes
	{
		Binary = 0, // also used for any "Unknown" format

		// AKI-developed formats
		AkiAnimation,   // Animation data (moves, taunts)
		AkiArchive,     // Archive of files ("TEXarc" counts as this)
		AkiModel,       // Model data
		AkiTexture,     // "TEX" file, AKI's wrapper around some N64 texture types
		AkiText,        // Text bank
		AkiLargeFont,   // Large font (24px wide character cells)
		AkiSmallFont,   // Small font (16px wide character cells)
		AkiFontChars,   // (not yet implemented; Shift-JIS encoded text file with all font characters)
		MenuBackground, // Menu background image (number and size are determined per-game)

		// N64 standard textures and palettes
		Ci4Palette, // raw CI4 palette data (32 bytes)
		Ci8Palette, // raw CI8 palette data (512 bytes)
		Ci4Texture, // CI4 texture data (with header)
		Ci8Texture, // CI8 texture data (with header)
		I4Texture,  // raw I4 texture data
		// todo: determine if IA8, IA4, and I8 are used in any AKI games
		// I'm assuming some of the others (e.g. JPG, YUV) aren't used.

		// semi-standard, but different enough to be an issue
		RawCi4TexPal,  // no header, but contains palette and CI4 texture data
		RawCi8Texture, // no header or palette, but contains CI8 texture data
		OneBppTexture, // headered 1bpp (example: WWF No Mercy file ID 0x0396)

		// "special" formats
		#region Game-Specific
		// note: this section contains things like movesets, etc. that change per game.
		// it also includes (possible) one-off formats.

		#region WCW vs. nWo World Tour
		// WrestlerParams_WorldTour
		#endregion

		#region Virtual Pro-Wrestling 64
		// WrestlerParams_VPW64
		#endregion

		#region WCW/nWo Revenge
		DoubleTex,  // two TEX files, one after another, no headers or anything.
		// WrestlerParams_Revenge
		#endregion

		#region WWF WrestleMania 2000
		#endregion

		#region Virtual Pro-Wrestling 2
		#endregion

		#region WWF No Mercy
		Ci4Background, // WWF No Mercy Smackdown Mall background
		MenuItems_NoGroup, // WWF No Mercy groupless Items (pictures, titantrons, themes)
		//MenuItems_Costume, // WWF No Mercy Costume Items
		MenuItems_Moves, // WWF No Mercy Move List Items
		MenuItems_Shop, // WWF No Mercy Smackdown Mall Shop Items
		#endregion

		#endregion

		// "split model" format found in AkiArchive files.
		SplitModel_Faces,    // list of faces
		SplitModel_Vertices, // list of vertices
	}

	public class FileTypeInfo
	{
		/// <summary>
		/// Mapping of FileTypes enum values to extracted file extensions.
		/// </summary>
		public static Dictionary<FileTypes, string> DefaultFileTypeExtensions = new Dictionary<FileTypes, string>()
		{
			{ FileTypes.Binary, ".bin" },
			{ FileTypes.AkiAnimation, ".anim" },
			{ FileTypes.AkiArchive, ".akiarc" }, // formerly "packed"
			{ FileTypes.AkiModel, ".model" },
			{ FileTypes.AkiTexture, ".tex" },
			{ FileTypes.AkiText, ".akitext" },
			{ FileTypes.AkiLargeFont, ".largefont" },
			{ FileTypes.AkiSmallFont, ".smallfont" },
			{ FileTypes.AkiFontChars, ".txt" },
			{ FileTypes.Ci4Palette, ".ci4pal" },
			{ FileTypes.Ci8Palette, ".ci8pal" },
			{ FileTypes.Ci4Texture, ".ci4tex" },
			{ FileTypes.Ci8Texture, ".ci8tex" },
			{ FileTypes.I4Texture, ".i4tex" },
			{ FileTypes.RawCi4TexPal, ".ci4raw" },
			{ FileTypes.RawCi8Texture, ".ci8raw" },
			{ FileTypes.OneBppTexture, ".1bpp" },
			{ FileTypes.DoubleTex, ".tex" }, // note: exports as two files
			{ FileTypes.MenuBackground, ".menubg" }, // not really supported yet
			{ FileTypes.Ci4Background, ".ci4bg" }, // this is awkward, freem
			{ FileTypes.MenuItems_NoGroup, ".nmitem0" },
			//{ FileTypes.MenuItems_Costume, ".nmitem1" },
			{ FileTypes.MenuItems_Moves, ".nmitem2" },
			{ FileTypes.MenuItems_Shop, ".nmitem3" },
			{ FileTypes.SplitModel_Faces, ".splitfaces" },
			{ FileTypes.SplitModel_Vertices, ".splitverts" },
		};

		/// <summary>
		/// List of FileTypes containing texture data.
		/// </summary>
		public static List<FileTypes> TextureFileTypes = new List<FileTypes>()
		{
			FileTypes.AkiTexture,
			FileTypes.Ci4Texture,
			FileTypes.Ci8Texture,
			FileTypes.I4Texture,
			FileTypes.DoubleTex,
			FileTypes.RawCi4TexPal,
			FileTypes.RawCi8Texture,
			FileTypes.OneBppTexture
		};

		/// <summary>
		/// List of FileTypes containing palette data.
		/// </summary>
		public static List<FileTypes> PaletteFileTypes = new List<FileTypes>()
		{
			FileTypes.Ci4Palette,
			FileTypes.Ci8Palette
		};

		/// <summary>
		/// List of FileTypes containing font-related data.
		/// </summary>
		public static List<FileTypes> FontFileTypes = new List<FileTypes>()
		{
			FileTypes.AkiFontChars,
			FileTypes.AkiSmallFont,
			FileTypes.AkiLargeFont
		};

		/// <summary>
		/// Return a list of the valid FileTypes for the specified game.
		/// </summary>
		/// <param name="gameType">Base game type</param>
		/// <returns>List of valid FileTypes objects for the specified game.</returns>
		public static List<FileTypes> GetValidFileTypesForGame(VPWGames gameType)
		{
			List<FileTypes> outTypes = new List<FileTypes>();
			foreach (FileTypes ft in Enum.GetValues(typeof(FileTypes)))
			{
				outTypes.Add(ft);
			}

			// FileTypes only found in Revenge and later
			if (gameType <= VPWGames.VPW64)
			{
				outTypes.Remove(FileTypes.SplitModel_Faces);
				outTypes.Remove(FileTypes.SplitModel_Vertices);
			}

			// FileTypes only found in WM2K and later
			if (gameType <= VPWGames.Revenge)
			{
				outTypes.Remove(FileTypes.AkiText);
				outTypes.Remove(FileTypes.MenuBackground);
			}

			// FileTypes only found in WWF No Mercy
			if (gameType < VPWGames.NoMercy)
			{
				outTypes.Remove(FileTypes.MenuItems_NoGroup);
				// eventually MenuItems_Costume
				outTypes.Remove(FileTypes.MenuItems_Moves);
				outTypes.Remove(FileTypes.MenuItems_Shop);
				outTypes.Remove(FileTypes.Ci4Background);
			}

			return outTypes;
		}
	}

}
