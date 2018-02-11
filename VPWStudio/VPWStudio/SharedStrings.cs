using System;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// Strings shared throughout the program.
	/// </summary>
	public static class SharedStrings
	{
		public static string MainForm_Title = "VPW Studio";

		#region Save/Load Dialog Filter Strings
		public static string FileFilter_None = "All Files (*.*)|*.*";
		public static string FileFilter_Text = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		public static string FileFilter_N64Rom = "Z64 format N64 ROMs (*.z64)|*.z64|All Files (*.*)|*.*";
		public static string FileFilter_Project = "VPW Studio Project File (*.vpwsproj)|*.vpwsproj|All Files (*.*)|*.*";
		public static string FileFilter_GameSharkCodes = "GameShark Code File (*.gscodes)|*.gscodes|All Files (*.*)|*.*";
		#endregion
	}
}
