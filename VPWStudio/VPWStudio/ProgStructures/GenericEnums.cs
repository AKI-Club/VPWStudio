using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	// note: this list is in flux until all formats are known
	public enum FileTypes
	{
		Binary = 0, // also used for any "Unknown" format

		// AKI-developed formats
		AkiArchive,    // Archive of files
		AkiModel,      // Model data
		AkiTexture,    // "TEX" file, AKI's wrapper around some N64 texture types
		AkiTextureArc, // TEX archive; need more information
		AkiText,       // Text bank
		AkiLargeFont,  // (not yet implemented)
		AkiSmallFont,  // (not yet implemented)

		// N64 standard textures and palettes
		Ci4Palette, // raw CI4 palette data (32 bytes)
		Ci8Palette, // raw CI8 palette data (512 bytes)
		Ci4Texture, // raw CI4 texture data
		Ci8Texture, // raw CI8 texture data
		// todo: IA8, IA4, I8, I4, others

		// "special" formats
		#region Game-Specific
		// note: this section contains things like movesets, etc. that change per game.
		// it also includes (possible) one-off formats.

		#region WCW/nWo Revenge
		DoubleTex,  // WCW/nWo Revenge credits faces (two TEX files in one file entry)
		#endregion

		#endregion
	}
}
