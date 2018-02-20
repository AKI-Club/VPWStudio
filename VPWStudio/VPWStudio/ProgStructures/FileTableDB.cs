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

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableDBEntry()
		{
			this.FileID = 0;
			this.FileType = FileTypes.Binary;
			this.Comment = String.Empty;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id">File ID.</param>
		/// <param name="_type">File type.</param>
		/// <param name="_comment">Comment for this entry.</param>
		public FileTableDBEntry(UInt16 _id, FileTypes _type, string _comment)
		{
			this.FileID = _id;
			this.FileType = _type;
			this.Comment = _comment;
		}

		/// <summary>
		/// Constructor from a string (FileTableDB)
		/// </summary>
		/// <param name="_in"></param>
		public FileTableDBEntry(string _in)
		{
			this.ReadString(_in);
		}

		/// <summary>
		/// Read values from a string.
		/// </summary>
		/// <param name="_in"></param>
		public void ReadString(string _in)
		{
			string[] tokens = _in.Split(new char[] { '=', ';' });
			this.FileID = UInt16.Parse(tokens[0], NumberStyles.HexNumber);
			this.FileType = (FileTypes)Enum.Parse(typeof(FileTypes), tokens[1]);
			this.Comment = tokens[2];
		}

		/// <summary>
		/// Get the string representing this entry.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("{0:X4}={1};{2}", this.FileID, this.FileType.ToString(), this.Comment );
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
	/// 
	/// MAJOR TODO: support read/write of filelists for Zoinkity's Midwaydec.
	/// * determine first file location via LocationFile
	/// * make assumptions that the first entry is 0x0001 and the last entry is the index before "filetable.bin".
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
			this.Entries = new Dictionary<ushort, FileTableDBEntry>();
		}

		/// <summary>
		/// Constructor from file.
		/// </summary>
		/// <param name="_file"></param>
		public FileTableDB(string _file)
		{
			this.Entries = new Dictionary<ushort, FileTableDBEntry>();
			this.ReadFile(_file);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_path"></param>
		public void ReadFile(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();

				// ignore comments
				if (line.StartsWith("#"))
				{
					continue;
				}

				FileTableDBEntry ftdbe = new FileTableDBEntry(line);
				this.Entries.Add(ftdbe.FileID, ftdbe);
			}

			sr.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_path"></param>
		public void WriteFile(string _path, string _topLine)
		{
			FileStream fs = new FileStream(_path, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			if (!_topLine.Equals(String.Empty))
			{
				sw.WriteLine(String.Format("# {0}", _topLine));
			}

			foreach (KeyValuePair<UInt16,FileTableDBEntry> ftdbe in this.Entries)
			{
				ftdbe.Value.ToString();
			}

			sw.Flush();
			sw.Close();
		}
	}
}
