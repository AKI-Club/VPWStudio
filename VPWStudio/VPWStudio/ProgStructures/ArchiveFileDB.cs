using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// Entry in ArchiveFileDB.
	/// </summary>
	public class ArchiveFileEntry
	{
		public UInt16 FileID;
		public FileTypes FileType;
		public string Comment;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ArchiveFileEntry()
		{
			FileID = 0;
			FileType = FileTypes.Binary;
			Comment = String.Empty;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_ft"></param>
		/// <param name="_comment"></param>
		public ArchiveFileEntry(ushort _id, FileTypes _ft, string _comment)
		{
			FileID = _id;
			FileType = _ft;
			Comment = _comment;
		}

		/// <summary>
		/// Constructor from a string.
		/// </summary>
		/// <param name="_input"></param>
		public ArchiveFileEntry(string _input)
		{
			FromString(_input);
		}
		#endregion

		/// <summary>
		/// Get the string representing this entry.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("{0:X4}={1};{2}", FileID, FileType.ToString(), Comment);
		}

		/// <summary>
		/// Read values from a string.
		/// </summary>
		/// <param name="_in"></param>
		public void FromString(string _in)
		{
			string[] tokens = _in.Split(new char[] { '=', ';' });
			FileID = UInt16.Parse(tokens[0], NumberStyles.HexNumber);
			FileType = (FileTypes)Enum.Parse(typeof(FileTypes), tokens[1]);
			Comment = tokens[2];
		}
	}

	/// <summary>
	/// Database of file entries in AkiArchive files.
	/// </summary>
	public class ArchiveFileDB
	{
		public Dictionary<int, List<ArchiveFileEntry>> Entries;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ArchiveFileDB()
		{
			Entries = new Dictionary<int, List<ArchiveFileEntry>>();
		}

		/// <summary>
		/// Constructor from an external file.
		/// </summary>
		/// <param name="_path">Path to external file to load.</param>
		public ArchiveFileDB(string _path)
		{
			Entries = new Dictionary<int, List<ArchiveFileEntry>>();
			ReadFile(_path);
		}
		#endregion

		public void ReadFile(string _path)
		{
			ushort curFileID = 0;
			using (FileStream fs = new FileStream(_path,FileMode.Open))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();

						// ignore comments
						if (line.StartsWith("#"))
						{
							continue;
						}

						// ignore blank lines
						if (string.IsNullOrEmpty(line))
						{
							continue;
						}

						if (line.StartsWith("["))
						{
							// update curFileID
							curFileID = UInt16.Parse(line.Substring(1, line.IndexOf(']')-1), NumberStyles.HexNumber);
							Entries[curFileID] = new List<ArchiveFileEntry>();
						}
						else
						{
							// attempt to parse as entry
							Entries[curFileID].Add(new ArchiveFileEntry(line));
						}
					}
				}
			}
		}
	}
}
