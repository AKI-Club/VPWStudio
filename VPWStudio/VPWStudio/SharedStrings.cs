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
		public static string FileFilter_None = "All Files (*.*)|*.*";
		public static string FileFilter_Text = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		public static string FileFilter_N64Rom = "Z64 format N64 ROMs (*.z64)|*.z64|All Files (*.*)|*.*";
		public static string FileFilter_Project = "VPW Studio Project File (*.vpwsproj)|*.vpwsproj|All Files (*.*)|*.*";
		public static string FileFilter_GameSharkCodes = "GameShark Code File (*.gscodes)|*.gscodes|All Files (*.*)|*.*";
		#endregion

		#region Unsaved Project Strings
		public static string UnsavedProject_NewProject = "";
		public static string UnsavedProject_OpenProject = "";
		public static string UnsavedProject_CloseProject = "";
		public static string UnsavedProject_ExitProgram = "";
		#endregion

		#region Error Message Content
		public static string PlayRomError_NoProjectLoaded = "No project is loaded, so no ROM can be played.";
		public static string PlayRomError_EmuPathNotSet = "The Emulator Path has not been set in the Program Options.";
		public static string PlayRomError_EmuPathNotExist = "The emulator you are attempting to use has not been found. Please check the Emulator Path in the Program Options.";
		#endregion

		#region File Table dialog
		public static string FileTableDialog_ExtractFile = "&Extract File...";
		public static string FileTableDialog_ExtractFiles = "&Extract Files...";
		#endregion
	}
}
