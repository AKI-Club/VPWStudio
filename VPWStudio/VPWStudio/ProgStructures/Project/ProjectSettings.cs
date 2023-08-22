using System;
using System.Xml.Serialization;

namespace VPWStudio
{
	/// <summary>
	/// ProjectFile settings.
	/// </summary>
	[Serializable]
	public class ProjectSettings
	{
		#region Class Members - Common
		/// <summary>
		/// Name of the project.
		/// </summary>
		public string ProjectName;

		/// <summary>
		/// List of authors on this project.
		/// </summary>
		public string Authors;

		/// <summary>
		/// Notes about the project.
		/// </summary>
		public string Notes;

		/// <summary>
		/// Base Game Type
		/// </summary>
		public VPWGames BaseGame;

		/// <summary>
		/// Game Type with Version
		/// </summary>
		public SpecificGame GameType;

		/// <summary>
		/// Path to files in the project.
		/// </summary>
		/// This typically means "data (almost) ready for insertion".
		public string ProjectFilesPath;

		/// <summary>
		/// Path to project assets.
		/// </summary>
		/// This typically means "formats normal human beings use".
		public string AssetsPath;
		#endregion

		#region Class Members - N64-specific
		/// <summary>
		/// ROM file to use with this project.
		/// </summary>
		public string InputRomPath;

		/// <summary>
		/// Path to exported ROM file.
		/// </summary>
		public string OutputRomPath;

		/// <summary>
		/// Output ROM internal name.
		/// </summary>
		/// Typically copied from the input ROM
		public string OutputRomInternalName;

		/// <summary>
		/// Output ROM game region.
		/// </summary>
		/// Intended use: cast to char to get the letter necessary.
		public GameRegion OutputRomRegion;

		/// <summary>
		/// Custom region character.
		/// </summary>
		/// Only used if OutputRomRegion is set to GameRegion.Custom
		public char OutputRomCustomRegion;
		#endregion

		#region Class Members - PS1-specific
		/// <summary>
		/// Path to extracted file data to use with this project.
		/// </summary>
		[XmlElement(IsNullable = true)]
		public string InputDataPath;

		/// <summary>
		/// Path to generated output file data.
		/// </summary>
		[XmlElement(IsNullable = true)]
		public string OutputDataPath;
		#endregion

		#region Class Members - Custom Location File
		/// <summary>
		/// Use a custom location file?
		/// </summary>
		public bool UseCustomLocationFile;

		/// <summary>
		/// Path to custom location file.
		/// </summary>
		public string CustomLocationFilePath;
		#endregion

		#region Class Members - Custom FileTableDB
		/// <summary>
		/// Use a custom FileTableDB file?
		/// </summary>
		public bool UseCustomFileTableDB;

		/// <summary>
		/// Path to custom FileTableDB file.
		/// </summary>
		public string CustomFileTableDBPath;
		#endregion

		#region Class Members - Ancillary Files
		/// <summary>
		/// Path to custom Wrestler Definition file.
		/// </summary>
		public string WrestlerDefinitionFilePath;

		/// <summary>
		/// Path to custom Stable Definition file.
		/// </summary>
		public string StableDefinitionFilePath;

		/// <summary>
		/// Path to Wrestler Name mapping file.
		/// </summary>
		/// Currently unused, and unsure if this will stick around
		public string WrestlerNameFilePath;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProjectSettings()
		{
			ProjectName = "Untitled Project";
			BaseGame = VPWGames.Invalid;
			GameType = SpecificGame.Invalid;
			Authors = String.Empty;
			Notes = String.Empty;
			InputRomPath = String.Empty;
			OutputRomPath = String.Empty;
			ProjectFilesPath = String.Empty;
			AssetsPath = String.Empty;

			UseCustomLocationFile = false;
			CustomLocationFilePath = String.Empty;
			UseCustomFileTableDB = false;
			CustomFileTableDBPath = String.Empty;

			#region N64-specific
			OutputRomInternalName = String.Empty;
			OutputRomRegion = GameRegion.NorthAmerica;
			OutputRomCustomRegion = '0';
			#endregion

			#region PS1-specific
			InputDataPath = null;
			OutputDataPath = null;
			#endregion

			#region Ancillary Files
			WrestlerDefinitionFilePath = String.Empty;
			StableDefinitionFilePath = String.Empty;
			WrestlerNameFilePath = String.Empty;
			#endregion
		}

		/// <summary>
		/// Full constructor.
		/// </summary>
		/// <param name="_name">Project name</param>
		/// <param name="_baseGame">Base game type</param>
		/// <param name="_gameType">Specific game variant (e.g. NTSC-U v1.0, PAL v1.1, etc.)</param>
		/// <param name="_authors">Project Authors</param>
		/// <param name="_notes">Project notes</param>
		/// <param name="_inROM">Input ROM path</param>
		/// <param name="_outROM">Output ROM path</param>
		/// <param name="_locPath">Custom Location File path</param>
		/// <param name="_ftdbPath">Custom FileTableDB path</param>
		public ProjectSettings(string _name, VPWGames _baseGame, SpecificGame _gameType, string _authors, string _notes, string _inROM, string _outROM, string _locPath, string _ftdbPath)
		{
			ProjectName = _name;
			BaseGame = _baseGame;
			GameType = _gameType;
			Authors = _authors;
			Notes = _notes;
			InputRomPath = _inROM;
			OutputRomPath = _outROM;
			ProjectFilesPath = String.Empty;
			AssetsPath = String.Empty;

			UseCustomLocationFile = !_locPath.Equals(String.Empty);
			CustomLocationFilePath = _locPath;
			UseCustomFileTableDB = !_ftdbPath.Equals(String.Empty);
			CustomFileTableDBPath = _ftdbPath;

			if (GameInformation.GameDefs[_gameType].TargetConsole == PlatformType.Nintendo64)
			{
				OutputRomInternalName = String.Empty;
				OutputRomRegion = GameInformation.GameDefs[_gameType].Region;
				OutputRomCustomRegion = '0';

				// nullify PS1-specific
				InputDataPath = null;
				OutputDataPath = null;
			}
			else if (GameInformation.GameDefs[_gameType].TargetConsole == PlatformType.PlayStation1)
			{
				InputDataPath = String.Empty;
				OutputDataPath = String.Empty;

				// nullify N64-specific
				OutputRomInternalName = null;
				OutputRomRegion = GameRegion.Custom;
				OutputRomCustomRegion = '0';
			}

			#region Ancillary Files
			WrestlerDefinitionFilePath = String.Empty;
			StableDefinitionFilePath = String.Empty;
			WrestlerNameFilePath = String.Empty;
			#endregion

		}

		/// <summary>
		/// Constructor from an existing ProjectSettings instance.
		/// </summary>
		/// <param name="_src"></param>
		public ProjectSettings(ProjectSettings _src)
		{
			DeepCopy(_src);
		}

		/// <summary>
		/// Deep copy an existing ProjectSettings instance.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(ProjectSettings _src)
		{
			ProjectName = _src.ProjectName;
			BaseGame = _src.BaseGame;
			GameType = _src.GameType;
			Authors = _src.Authors;
			Notes = _src.Notes;
			InputRomPath = _src.InputRomPath;
			OutputRomPath = _src.OutputRomPath;
			ProjectFilesPath = _src.ProjectFilesPath;
			AssetsPath = _src.AssetsPath;

			UseCustomLocationFile = _src.UseCustomLocationFile;
			CustomLocationFilePath = _src.CustomLocationFilePath;
			UseCustomFileTableDB = _src.UseCustomFileTableDB;
			CustomFileTableDBPath = _src.CustomFileTableDBPath;

			#region N64-specific
			OutputRomInternalName = _src.OutputRomInternalName;
			OutputRomRegion = _src.OutputRomRegion;
			OutputRomCustomRegion = _src.OutputRomCustomRegion;
			#endregion

			#region PS1-specific
			InputDataPath = _src.InputDataPath;
			OutputDataPath = _src.OutputDataPath;
			#endregion

			WrestlerDefinitionFilePath = _src.WrestlerDefinitionFilePath;
			StableDefinitionFilePath = _src.StableDefinitionFilePath;
			WrestlerNameFilePath = _src.WrestlerNameFilePath;
		}

		/// <summary>
		/// Get target platform for this project file.
		/// </summary>
		/// <returns>PlatformType value representing the target console for the project's GameType.</returns>
		public PlatformType GetPlatformType()
		{
			return GameInformation.GameDefs[GameType].TargetConsole;
		}
	}
}
