using System;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// Strings shared throughout the program.
	/// </summary>
	/// todo: these should really be in the per-language Resources
	public static class SharedStrings
	{
		// [ja] バープロ スタジオ
		public static string MainForm_Title = "VPW Studio";

		#region Save/Load Dialog Filter Strings
		// generic
		public static string FileFilter_None = "All Files (*.*)|*.*";
		public static string FileFilter_N64Rom = "Z64 format N64 ROMs (*.z64)|*.z64|All Files (*.*)|*.*";
		public static string FileFilter_Project = "VPW Studio Project File (*.vpwsproj)|*.vpwsproj|All Files (*.*)|*.*";

		// todo: split these out into save/load
		// for example, we might want to have a filter that catches all relevant formats.
		public static string FileFilter_CSV = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
		public static string FileFilter_PNG = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
		public static string FileFilter_Text = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		public static string FileFilter_GameSharkCodes = "GameShark Code File (*.gscodes)|*.gscodes|All Files (*.*)|*.*";
		public static string FileFilter_Palettes = "VPW Studio Palette File (*.vpwspal)|*.vpwspal|JASC Paint Shop Pro Palette File (*.pal)|*.pal|GIMP Palette File (*.gpl)|*.gpl|All Files (*.*)|*.*";

		// palette load/import
		public static string FileLoadFilter_PaletteCi4 = "All CI4 Palette Formats|*.ci4pal;*.vpwspal;*.pal|CI4 Palettes (*.ci4pal)|*.ci4pal|VPW Studio Palette File (*.vpwspal)|*.vpwspal|JASC Paint Shop Pro Palette File (*.pal)|*.pal|All Files (*.*)|*.*";
		public static string FileLoadFilter_PaletteCi8 = "All CI8 Palette Formats|*.ci8pal;*.vpwspal;*.pal|CI8 Palettes (*.ci8pal)|*.ci8pal|VPW Studio Palette File (*.vpwspal)|*.vpwspal|JASC Paint Shop Pro Palette File (*.pal)|*.pal|All Files (*.*)|*.*";

		public static string FileLoadFilter_TextureCi4 = "All CI4 Texture Formats|*.ci4tex;*.png|CI4 Textures (*.ci4tex)|*.ci4tex|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
		public static string FileLoadFilter_TextureCi8 = "All CI8 Texture Formats|*.ci8tex;*.png|CI8 Textures (*.ci8tex)|*.ci8tex|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
		public static string FileLoadFilter_TextureAki = "All AKI Texture Formats|*.tex;*.png|AKI Textures (*.tex)|*.tex|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
		#endregion

		#region Unsaved Project Strings
		private static string UnsavedProjectChanges_SharedIntro = "There are unsaved project changes.";
		public static string UnsavedProject_NewProject   = String.Format("{0}\n{1}", UnsavedProjectChanges_SharedIntro, "Do you want to discard the changes and start a new project?");
		public static string UnsavedProject_OpenProject  = String.Format("{0}\n{1}", UnsavedProjectChanges_SharedIntro, "Do you want to discard the changes and open another project?");
		public static string UnsavedProject_CloseProject = String.Format("{0}\n{1}", UnsavedProjectChanges_SharedIntro, "Do you want to discard the changes and close the project?");
		public static string UnsavedProject_ExitProgram  = String.Format("{0}\n{1}", UnsavedProjectChanges_SharedIntro, "Do you want to discard the changes and exit?");
		#endregion

		#region Error Message Content
		public static string PlayRomError_NoProjectLoaded = "No project is loaded, so no ROM can be played.";
		public static string PlayRomError_EmuPathNotSet = "The Emulator Path has not been set in the Program Options.";
		public static string PlayRomError_EmuPathNotExist = "The emulator you are attempting to use has not been found. Please check the Emulator Path in the Program Options.";
		#endregion

		#region File Table dialog
		public static string FileTableDialog_ExtractFile = "&Extract File...";
		public static string FileTableDialog_ExtractFiles = "&Extract Files...";

		public static string FileTableDialog_AttemptRomTableBuild = "Project FileTable not found. Attempting to create from ROM.";
		public static string FileTableDialog_UsingHardcodedValues = "File Table location not found; using hardcoded offset and length instead.";
		#endregion
	}
}
