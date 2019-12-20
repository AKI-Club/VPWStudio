using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// A single build cache entry.
	/// </summary>
	public class BuildCacheEntry
	{
		/// <summary>
		/// Absolute path to the file this entry represents.
		/// </summary>
		public string FilePath;

		/// <summary>
		/// Time of last modification to file.
		/// </summary>
		public DateTime LastModified;

		/// <summary>
		/// FileType of this cache entry.
		/// </summary>
		public FileTypes TargetFormat;

		/// <summary>
		/// Is this entry meant to be LZSS'd?
		/// </summary>
		public bool IsLzss;

		/// <summary>
		/// Constructor with file path and type.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="targetType"></param>
		public BuildCacheEntry(string path, FileTypes targetType, bool lzss = false)
		{
			FilePath = path;
			TargetFormat = targetType;
			LastModified = Directory.GetLastWriteTime(path);
			IsLzss = lzss;
		}

		/// <summary>
		/// Constructor from text version of BuildCacheEntry.
		/// </summary>
		/// <param name="s">String representing a BuildCacheEntry.</param>
		public BuildCacheEntry(string s)
		{
			FromString(s);
		}

		/// <summary>
		/// Update the modified time for this BuildCacheEntry.
		/// </summary>
		public void UpdateModifiedTime()
		{
			DateTimeFormatInfo dtfi = DateTimeFormatInfo.InvariantInfo;
			LastModified = DateTime.Parse(File.GetLastWriteTime(FilePath).ToString(DateTimeFormatInfo.InvariantInfo));
		}

		/// <summary>
		/// Check if this entry's last modified date is newer than the current entry date.
		/// </summary>
		/// <param name="lastBuild">DateTime of last build</param>
		/// <returns></returns>
		public bool IsNewer(DateTime lastBuild)
		{
			return DateTime.Compare(LastModified, lastBuild) > 0;
		}

		/// <summary>
		/// Get the file extension for this BuildCacheEntry.
		/// </summary>
		/// <returns>String with file extension.</returns>
		public string GetFileExtension()
		{
			if (IsLzss)
			{
				return string.Format("{0}.lzss",FileTypeInfo.DefaultFileTypeExtensions[TargetFormat]);
			}

			return FileTypeInfo.DefaultFileTypeExtensions[TargetFormat];
		}

		/// <summary>
		/// Get the string representation for this BuildCacheEntry.
		/// </summary>
		/// <returns>String representing this BuildCacheEntry.</returns>
		public override string ToString()
		{
			DateTimeFormatInfo dtfi = DateTimeFormatInfo.InvariantInfo;
			return string.Format(
				"{0}|{1}|{2}|{3}",
				FilePath,
				TargetFormat.ToString(),
				IsLzss,
				LastModified.ToString(dtfi.UniversalSortableDateTimePattern)
			);
		}

		/// <summary>
		/// Parse the string representation of a BuildCacheEntry.
		/// </summary>
		/// <param name="entry">String representing a BuildCacheEntry.</param>
		public void FromString(string entry)
		{
			// path | format | lzss | last modified date (invariant, universal sortable format)
			string[] values = entry.Split('|');
			FilePath = values[0];
			TargetFormat = (FileTypes)Enum.Parse(typeof(FileTypes), values[1]);
			IsLzss = bool.Parse(values[2]);
			LastModified = DateTime.Parse(values[3], DateTimeFormatInfo.InvariantInfo);
		}
	}

	/// <summary>
	/// Build Cache is meant to store pre-converted items, instead of remaking them each time.
	/// </summary>
	public class BuildCache
	{
		#region Members
		/// <summary>
		/// Cache entries. File ID is used as the key.
		/// </summary>
		public Dictionary<int, BuildCacheEntry> Entries;

		/// <summary>
		/// Time of last project build.
		/// </summary>
		public DateTime LastBuildTime;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public BuildCache()
		{
			Entries = new Dictionary<int, BuildCacheEntry>();
		}

		/// <summary>
		/// Constructor used when loading a file
		/// </summary>
		/// <param name="path">Path to cache.idx</param>
		public BuildCache(string path)
		{
			Entries = new Dictionary<int, BuildCacheEntry>();
			StreamReader sr = new StreamReader(path);
			ReadFile(sr);
			sr.Dispose();
		}
		#endregion

		/// <summary>
		/// Determine if a specific file ID has been cached.
		/// </summary>
		/// <param name="fileID">File ID to check.</param>
		/// <returns>True if file has been cached.</returns>
		public bool IsEntryCached(int fileID)
		{
			return Entries.ContainsKey(fileID) && File.Exists(Entries[fileID].FilePath);
		}

		/// <summary>
		/// Determine if a file needs a cache update.
		/// </summary>
		/// <param name="fileID">File ID to check.</param>
		/// <returns>True if cached file needs update.</returns>
		public bool NeedCacheUpdate(int fileID)
		{
			return Entries[fileID].IsNewer(LastBuildTime);
		}

		public void UpdateCacheEntryTime(int fileID)
		{
			Entries[fileID].UpdateModifiedTime();
		}

		/// <summary>
		/// Add a BuildCacheEntry for the specified file.
		/// </summary>
		/// <param name="fileID">File ID</param>
		/// <param name="targetType">File type</param>
		/// <param name="filePath">Path to file</param>
		public void AddCacheEntry(int fileID, FileTypes targetType, string filePath)
		{
			if (Entries.ContainsKey(fileID))
			{
				// overwrite existing
				Entries[fileID] = new BuildCacheEntry(filePath, targetType);
			}
			else
			{
				// make new
				Entries.Add(fileID, new BuildCacheEntry(filePath, targetType));
			}
			
		}

		public string GetCachedFilePath(int fileID)
		{
			return string.Format("{0}\\{1:X4}{2}",
				Program.ConvertRelativePath(Program.CurrentProject.Settings.CachePath),
				fileID,
				Entries[fileID].GetFileExtension()
			);
		}

		public void WriteCachedFileData(int fileID, byte[] data)
		{
			string cacheFilePath = GetCachedFilePath(fileID);

			FileStream fs = new FileStream(cacheFilePath, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);
			bw.Write(data);
			bw.Flush();
			bw.Dispose();
		}

		/// <summary>
		/// Read cache from file.
		/// </summary>
		/// <param name="sr">StreamReader instance pointing to cache.idx</param>
		public void ReadFile(StreamReader sr)
		{
			while (!sr.EndOfStream)
			{
				string entryString = sr.ReadLine();
				string[] entryData = entryString.Split('=');
				if (entryData.Length > 0)
				{
					int fileID = int.Parse(entryData[0], NumberStyles.HexNumber);
					Entries.Add(fileID, new BuildCacheEntry(entryData[1]));
				}
			}
		}

		/// <summary>
		/// Write cache index data.
		/// </summary>
		/// <param name="sw">StreamWriter instance pointing to cache.idx</param>
		public void WriteFile(StreamWriter sw)
		{
			foreach (KeyValuePair<int,BuildCacheEntry> entry in Entries)
			{
				sw.WriteLine(string.Format("{0:X4}={1}", entry.Key, entry.Value.ToString()));
			}
		}
	}
}
