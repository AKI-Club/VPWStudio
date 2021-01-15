using System;
using System.IO;
using System.Xml.Serialization;

namespace VPWStudio
{
	/// <summary>
	/// VPW Studio Project File.
	/// </summary>
	[Serializable]
	public class ProjectFile
	{
		/// <summary>
		/// Current Project File version.
		/// </summary>
		/// This will remain at 0 until an "official" first version is released.
		public const uint CUR_PROJECTFILE_VER = 0;

		#region Class Members
		/// <summary>
		/// Project File Version
		/// </summary>
		public uint ProjectFileVersion;

		/// <summary>
		/// Settings for this ProjectFile.
		/// </summary>
		public ProjectSettings Settings;

		/// <summary>
		/// FileTable for this project.
		/// </summary>
		public FileTable ProjectFileTable;
		#endregion

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ProjectFile()
		{
			ProjectFileVersion = CUR_PROJECTFILE_VER;
			Settings = new ProjectSettings();
			ProjectFileTable = new FileTable();
		}

		/// <summary>
		/// Constructor from existing file
		/// </summary>
		/// <param name="path"></param>
		public ProjectFile(string path)
		{
			ProjectFileVersion = CUR_PROJECTFILE_VER;
			Settings = new ProjectSettings();
			ProjectFileTable = new FileTable();

			LoadFile(path);
		}

		/// <summary>
		/// Deep copy an existing ProjectFile instance.
		/// </summary>
		/// <param name="_src">Source ProjectFile to copy.</param>
		public void DeepCopy(ProjectFile _src)
		{
			ProjectFileVersion = _src.ProjectFileVersion;
			Settings.DeepCopy(_src.Settings);
			ProjectFileTable.DeepCopy(_src.ProjectFileTable);
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
			DeepCopy(temp);
		}
		#endregion

		/// <summary>
		/// Initializes the Project FileTable using the Input ROM.
		/// </summary>
		/// <param name="addr">FileTable address in ROM</param>
		/// <param name="length">Size of FileTable in bytes.</param>
		public void CreateProjectFileTable(uint addr, int length)
		{
			using (FileStream fs = new FileStream(Settings.InputRomPath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					fs.Seek(addr, SeekOrigin.Begin);

					// sanity check (unsure if needed, but seems like a good idea)
					//if (ProjectFileTable == null)
					//{
					//	ProjectFileTable = new FileTable();
					//}

					ProjectFileTable.Read(br, length);
				}
			}
		}
	}
}
