using System;
using System.Collections.Generic;

namespace VPWStudio
{
	// note: this list is in flux until all formats are known
	public enum FileTypes
	{
		Binary = 0, // also used for any "Unknown" format

		// AKI-developed formats
		AkiArchive,    // Archive of files ("TEXarc" counts as this)
		AkiModel,      // Model data
		AkiTexture,    // "TEX" file, AKI's wrapper around some N64 texture types
		AkiText,       // Text bank
		AkiLargeFont,  // Large font (24x21px character cells)
		AkiSmallFont,  // Small font (16x13px character cells)
		AkiFontChars,  // (not yet implemented; Shift-JIS encoded text file with all font characters)

		// N64 standard textures and palettes
		Ci4Palette, // raw CI4 palette data (32 bytes)
		Ci8Palette, // raw CI8 palette data (512 bytes)
		Ci4Texture, // CI4 texture data (with header)
		Ci8Texture, // CI8 texture data (with header)
		I4Texture,  // raw I4 texture data
		// todo: IA8, IA4, I8, others

		// "special" formats
		#region Game-Specific
		// note: this section contains things like movesets, etc. that change per game.
		// it also includes (possible) one-off formats.

		#region WCW/nWo Revenge
		DoubleTex,  // two TEX files, one after another, no headers or anything.
		#endregion

		#region WWF No Mercy
		NoMercyText, // WWF No Mercy text archives (used for move names)
		#endregion

		#endregion
	}

	public class FileTypeInfo
	{
		/// <summary>
		/// Mapping of FileTypes enum values to extracted file extensions.
		/// </summary>
		public static Dictionary<FileTypes, string> DefaultFileTypeExtensions = new Dictionary<FileTypes, string>()
		{
			{ FileTypes.Binary, "bin" },
			{ FileTypes.AkiArchive, "akiarc" }, // formerly "packed"
			{ FileTypes.AkiModel, "model" },
			{ FileTypes.AkiTexture, "tex" },
			{ FileTypes.AkiText, "akitext" },
			{ FileTypes.AkiLargeFont, "largefont" },
			{ FileTypes.AkiSmallFont, "smallfont" },
			{ FileTypes.AkiFontChars, "txt" },
			{ FileTypes.Ci4Palette, "ci4pal" },
			{ FileTypes.Ci8Palette, "ci8pal" },
			{ FileTypes.Ci4Texture, "ci4tex" },
			{ FileTypes.Ci8Texture, "ci8tex" },
			{ FileTypes.I4Texture, "i4tex" },
			{ FileTypes.DoubleTex, "tex" }, // note: exports as two files
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
			FileTypes.DoubleTex
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
	}

}
