using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// Entry in FileTableDB.
	/// </summary>
	public class FileTableDBEntry
	{
		public UInt16 FileID;
		public FileTypes FileType;
		public string Comment;

		// (w:#),(h:#),(t:#),(p:#)
		public string ExtraData;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableDBEntry()
		{
			FileID = 0;
			FileType = FileTypes.Binary;
			Comment = String.Empty;
			ExtraData = String.Empty;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id">File ID.</param>
		/// <param name="_type">File type.</param>
		/// <param name="_comment">Comment for this entry.</param>
		public FileTableDBEntry(UInt16 _id, FileTypes _type, string _comment)
		{
			FileID = _id;
			FileType = _type;
			Comment = _comment;
			ExtraData = String.Empty;
		}

		/// <summary>
		/// Specific constructor with ExtraData.
		/// </summary>
		/// <param name="_id">File ID.</param>
		/// <param name="_type">File type.</param>
		/// <param name="_comment">Comment for this entry.</param>
		/// <param name="_extra">Extra Data string for this entry.</param>
		public FileTableDBEntry(UInt16 _id, FileTypes _type, string _comment, string _extra)
		{
			FileID = _id;
			FileType = _type;
			Comment = _comment;
			ExtraData = _extra;
		}

		/// <summary>
		/// Constructor from a string (FileTableDB)
		/// </summary>
		/// <param name="_in"></param>
		public FileTableDBEntry(string _in)
		{
			ReadString(_in);
		}
		#endregion

		/// <summary>
		/// Read values from a string.
		/// </summary>
		/// <param name="_in"></param>
		public void ReadString(string _in)
		{
			string[] tokens = _in.Split(new char[] { '=', ';', '|' });
			FileID = UInt16.Parse(tokens[0], NumberStyles.HexNumber);
			FileType = (FileTypes)Enum.Parse(typeof(FileTypes), tokens[1]);
			Comment = tokens[2];
			if (tokens.Length == 4)
			{
				ExtraData = tokens[3];
			}
		}

		/// <summary>
		/// Get the string representing this entry.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string entryLine = String.Format("{0:X4}={1};{2}", FileID, FileType.ToString(), Comment);

			if (ExtraData != string.Empty)
			{
				entryLine += String.Format("|{0}", ExtraData);
			}

			return entryLine;
		}
	}

	// default filetable entries
	// the act of filling this data is a perpetual WIP...
	// the act of making a class to handle it shouldn't be.

	// {ID}={type};{comment}
	// remember: ID values start at 0x0001, because 0x0000 means "no file".

	/// <summary>
	/// File table database.
	/// Used as a helper when populating the project's FileTable from ROM data.
	/// </summary>
	public class FileTableDB
	{
		/// <summary>
		/// Map of entries in the FileTableDB.
		/// </summary>
		public Dictionary<UInt16,FileTableDBEntry> Entries;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableDB()
		{
			Entries = new Dictionary<ushort, FileTableDBEntry>();
		}

		/// <summary>
		/// Constructor from file.
		/// </summary>
		/// <param name="_file"></param>
		public FileTableDB(string _file)
		{
			Entries = new Dictionary<ushort, FileTableDBEntry>();
			ReadFile(_file);
		}

		/// <summary>
		/// Read FileTableDB from file.
		/// </summary>
		/// <param name="_path">Path to input FileTableDB.</param>
		public void ReadFile(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			int lineNumber = 1;
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();

				// ignore comments
				if (line.StartsWith("#"))
				{
					lineNumber++;
					continue;
				}

				// xxx: showing message boxes here is not good form
				FileTableDBEntry ftdbe = new FileTableDBEntry(line);
				try
				{
					Entries.Add(ftdbe.FileID, ftdbe);
				}
				catch (ArgumentException aex)
				{
					if (Entries.ContainsKey(ftdbe.FileID))
					{
						// duplicate entry
						System.Windows.Forms.MessageBox.Show(String.Format("Error on line {0}: Duplicate entry for FileID {1:X4}", lineNumber, ftdbe.FileID));
					}
					else
					{
						// undefined error
						System.Windows.Forms.MessageBox.Show(String.Format("Error on line {0}: {1}", lineNumber, aex.ToString()));
					}
				}
				finally
				{
					lineNumber++;
				}
			}

			sr.Close();
		}

		/// <summary>
		/// Write FileTableDB to file.
		/// </summary>
		/// <param name="_path">Path to output FileTableDB.</param>
		/// <param name="_topLine">Optional top line comment.</param>
		public void WriteFile(string _path, string _topLine)
		{
			FileStream fs = new FileStream(_path, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			if (!_topLine.Equals(String.Empty))
			{
				sw.WriteLine(String.Format("# {0}", _topLine));
			}

			foreach (KeyValuePair<UInt16,FileTableDBEntry> ftdbe in Entries)
			{
				ftdbe.Value.ToString();
			}

			sw.Flush();
			sw.Close();
		}
	}
}
