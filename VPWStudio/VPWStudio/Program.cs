using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	static class Program
	{
		#region Program-Specific Variables

		#region Main Project File-related
		/// <summary>
		/// Current Project data.
		/// </summary>
		public static ProjectFile CurrentProject = null;

		/// <summary>
		/// Path to the Current Project file.
		/// </summary>
		public static string CurProjectPath = String.Empty;

		/// <summary>
		/// Are there unsaved changes to the current project?
		/// </summary>
		public static bool UnsavedChanges = false;

		/// <summary>
		/// Current input ROM file.
		/// </summary>
		public static Z64Rom CurrentInputROM = null;

		/// <summary>
		/// Current output ROM file.
		/// </summary>
		public static Z64Rom CurrentOutputROM = null;
		#endregion

		#region Project Sub-Files
		/// <summary>
		/// Currently loaded location file.
		/// </summary>
		public static LocationFile CurLocationFile = null;

		/// <summary>
		/// Path to Current Location File.
		/// </summary>
		public static string CurLocationFilePath = String.Empty;

		/// <summary>
		/// Currently loaded GameSharkCodeFile.
		/// </summary>
		public static GameSharkCodeFile CurrentGSCodeFile = null;

		/// <summary>
		/// Path to currently loaded GameSharkCodeFile.
		/// </summary>
		public static string CurGSCFPath = String.Empty;
		#endregion

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Crc32.GenerateTable();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(args));
		}
	}
}
