using System;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// Strings shared throughout the program.
	/// </summary>
	public static class SharedStrings
	{
		// [ja] バープロスタジオ
		public static string MainForm_Title = "VPW Studio";

		#region Save/Load Dialog Filter Strings
		public static string FileFilter_None = "All Files (*.*)|*.*";
		public static string FileFilter_Text = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		public static string FileFilter_N64Rom = "Z64 format N64 ROMs (*.z64)|*.z64|All Files (*.*)|*.*";
		public static string FileFilter_Project = "VPW Studio Project File (*.vpwsproj)|*.vpwsproj|All Files (*.*)|*.*";
		public static string FileFilter_GameSharkCodes = "GameShark Code File (*.gscodes)|*.gscodes|All Files (*.*)|*.*";
		#endregion

		#region Error Message Content
		public static string PlayRomError_NoProjectLoaded = "No project is loaded, so no ROM can be played.";
		public static string PlayRomError_EmuPathNotSet = "The Emulator Path has not been set in the Program Options.";
		public static string PlayRomError_EmuPathNotExist = "The emulator you are attempting to use has not been found. Please check the Emulator Path in the Program Options.";
		#endregion
	}
}
