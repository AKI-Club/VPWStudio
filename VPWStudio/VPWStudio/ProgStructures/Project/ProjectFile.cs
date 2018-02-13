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
