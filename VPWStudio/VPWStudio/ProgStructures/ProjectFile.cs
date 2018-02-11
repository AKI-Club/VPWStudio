using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProjectSettings()
		{
			this.ProjectName = "Untitled Project";
			this.BaseGame = VPWGames.Invalid;
			this.GameType = SpecificGame.Invalid;
			this.Authors = String.Empty;
			this.Notes = String.Empty;
			this.InputRomPath = String.Empty;
			this.OutputRomPath = String.Empty;
			this.UseCustomLocationFile = false;
			this.CustomLocationFilePath = String.Empty;
			this.ProjectGSCodeFilePath = String.Empty;
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
			this.ProjectName = _name;
			this.BaseGame = _baseGame;
			this.GameType = _gameType;
			this.Authors = _authors;
			this.Notes = _notes;
			this.InputRomPath = _inROM;
			this.OutputRomPath = _outROM;
			this.UseCustomLocationFile = !_locPath.Equals(String.Empty);
			this.CustomLocationFilePath = _locPath;
			this.ProjectGSCodeFilePath = _gscPath;
		}

		/// <summary>
		/// Constructor from an existing ProjectSettings instance.
		/// </summary>
		/// <param name="_src"></param>
		public ProjectSettings(ProjectSettings _src)
		{
			this.DeepCopy(_src);
		}

		/// <summary>
		/// Deep copy an existing ProjectSettings instance.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(ProjectSettings _src)
		{
			this.ProjectName = _src.ProjectName;
			this.BaseGame = _src.BaseGame;
			this.GameType = _src.GameType;
			this.Authors = _src.Authors;
			this.Notes = _src.Notes;
			this.InputRomPath = _src.InputRomPath;
			this.OutputRomPath = _src.OutputRomPath;
			this.UseCustomLocationFile = _src.UseCustomLocationFile;
			this.CustomLocationFilePath = _src.CustomLocationFilePath;
			this.ProjectGSCodeFilePath = _src.ProjectGSCodeFilePath;
		}
	}

	/// <summary>
	/// VPW Studio Project File.
	/// </summary>
	[Serializable]
	public class ProjectFile
	{
		/// <summary>
		/// Settings for this ProjectFile.
		/// </summary>
		public ProjectSettings Settings;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ProjectFile()
		{
			this.Settings = new ProjectSettings();
		}

		/// <summary>
		/// Deep copy and existing ProjectFile instance.
		/// </summary>
		/// <param name="_src">Source ProjectFile to copy.</param>
		public void DeepCopy(ProjectFile _src)
		{
			this.Settings.DeepCopy(_src.Settings);
		}

		#region Project File Load/Save
		/// <summary>
		/// Save Project File to XML.
		/// </summary>
		/// <param name="_path">Path to project file.</param>
		/// <returns>true if successful, false otherwise.</returns>
		public bool SaveFile(string _path)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ProjectFile));
			FileStream fs = new FileStream(_path, FileMode.Create);
			xs.Serialize(fs, this);
			fs.Flush();
			fs.Close();
			return true;
		}

		/// <summary>
		/// Load Project File from XML.
		/// </summary>
		/// <param name="_path">Path to project file.</param>
		public void LoadFile(string _path)
		{
			XmlSerializer xs = new XmlSerializer(typeof(ProjectFile));
			FileStream fs = new FileStream(_path, FileMode.Open);
			ProjectFile temp = (ProjectFile)xs.Deserialize(fs);
			fs.Close();
			this.DeepCopy(temp);
		}
		#endregion

	}
}
