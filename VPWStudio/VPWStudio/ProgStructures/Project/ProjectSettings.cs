using System;

namespace VPWStudio
{
	/// <summary>
	/// ProjectFile settings.
	/// </summary>
	[Serializable]
	public class ProjectSettings
	{
		#region Class Members
		/// <summary>
		/// Name of the project.
		/// </summary>
		public string ProjectName;

		/// <summary>
		/// List of authors on this project.
		/// </summary>
		public string Authors;

		/// <summary>
		/// Base Game Type
		/// </summary>
		public VPWGames BaseGame;

		/// <summary>
		/// Game Type with Version
		/// </summary>
		public SpecificGame GameType;

		/// <summary>
		/// Notes about the project.
		/// </summary>
		public string Notes;

		/// <summary>
		/// ROM file to use with this project.
		/// </summary>
		public string InputRomPath;

		/// <summary>
		/// Path to exported ROM file.
		/// </summary>
		public string OutputRomPath;

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

		/// <summary>
		/// Use a custom location file?
		/// </summary>
		public bool UseCustomLocationFile;

		/// <summary>
		/// Path to custom location file.
		/// </summary>
		public string CustomLocationFilePath;

		/// <summary>
		/// Path to GameSharkCodeFile for this project.
		/// </summary>
		public string ProjectGSCodeFilePath;

		/// <summary>
		/// Output ROM internal name.
		/// </summary>
		/// Typically copied from the input ROM
		public string OutputRomInternalName;

		/// <summary>
		/// Output ROM game code.
		/// </summary>
		/// Four characters total: 'N' + game code + region code
		/// 
		/// todo: this should only be two characters;
		/// 'N' should be hardcoded, and the last letter set from OutputRomRegion and/or OutputRomCustomRegion
		public string OutputRomGameCode;

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

		/// <summary>
		/// Path to custom Stable Definition file.
		/// </summary>
		public string StableDefinitionFilePath;
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
			ProjectGSCodeFilePath = String.Empty;
			OutputRomInternalName = String.Empty;
			OutputRomGameCode = String.Empty;
			OutputRomRegion = GameRegion.NorthAmerica;
			OutputRomCustomRegion = '0';
			StableDefinitionFilePath = String.Empty;
		}

		/// <summary>
		/// Full constructor.
		/// </summary>
		/// <param name="_name">Project name</param>
		/// <param name="_baseGame"></param>
		/// <param name="_gameType"></param>
		/// <param name="_authors">Project Authors</param>
		/// <param name="_notes">Project notes</param>
		/// <param name="_inROM">Input ROM path</param>
		/// <param name="_outROM">Output ROM path</param>
		/// <param name="_locPath">Custom Location File path</param>
		/// <param name="_gscPath">GameShark Code File path</param>
		public ProjectSettings(string _name, VPWGames _baseGame, SpecificGame _gameType, string _authors, string _notes, string _inROM, string _outROM, string _locPath, string _gscPath)
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
			ProjectGSCodeFilePath = _gscPath;
			OutputRomInternalName = String.Empty;
			OutputRomGameCode = String.Empty;
			OutputRomRegion = GameInformation.GameDefs[_gameType].Region;
			OutputRomCustomRegion = '0';
			StableDefinitionFilePath = String.Empty;
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
			ProjectGSCodeFilePath = _src.ProjectGSCodeFilePath;
			OutputRomInternalName = _src.OutputRomInternalName;
			OutputRomGameCode = _src.OutputRomGameCode;
			OutputRomRegion = _src.OutputRomRegion;
			OutputRomCustomRegion = _src.OutputRomCustomRegion;
			StableDefinitionFilePath = _src.StableDefinitionFilePath;
		}
	}
}
