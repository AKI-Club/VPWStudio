using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace VPWStudio
{
	/// <summary>
	/// A single open HexViewer.
	/// </summary>
	public struct HexViewerEntry
	{
		/// <summary>
		/// HexViewer form associated with this entry.
		/// </summary>
		public HexViewer Form;

		/// <summary>
		/// SHA256 hash of the data displayed in the hex editor.
		/// </summary>
		public byte[] DataHash;

		public HexViewerEntry(HexViewer f, byte[] h)
		{
			Form = f;
			DataHash = h;
		}
	}

	/// <summary>
	/// Manager class for the HexViewer.
	/// </summary>
	/// The goal of this class is to handle multiple HexViewers while not summoning more views than needed.
	public class HexViewerManager
	{
		/// <summary>
		/// List of active HexViewer windows.
		/// </summary>
		public List<HexViewerEntry> ActiveHexViewers;

		/// <summary>
		/// Constructor
		/// </summary>
		public HexViewerManager()
		{
			ActiveHexViewers = new List<HexViewerEntry>();
		}

		#region Request New Viewer
		/// <summary>
		/// Create a new HexViewer from a FileTable entry.
		/// </summary>
		/// <param name="fileID">ID of file to open in HexViewer.</param>
		/// <returns>HexViewer form with the requested data.</returns>
		public HexViewer NewViewerFileTable(int fileID)
		{
			if (!Program.CurrentProject.ProjectFileTable.Entries.ContainsKey(fileID))
			{
				Program.ErrorMessageBox(String.Format("Error attempting to load file ID {0:X4}", fileID));
				return null;
			}

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream extractStream = new MemoryStream();
			BinaryWriter extractWriter = new BinaryWriter(extractStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, fileID);
			romReader.Close();

			int size = (int)extractStream.Position;
			extractStream.Seek(0, SeekOrigin.Begin);
			BinaryReader br = new BinaryReader(extractStream);
			byte[] data = br.ReadBytes(size);
			br.Close();
			extractWriter.Close();

			SHA256 sha256 = SHA256.Create();
			byte[] hash = sha256.ComputeHash(data);

			// check if data has already been loaded
			int viewerIndex = CheckOpenFile(hash);
			if (viewerIndex != -1)
			{
				// already open
				return ActiveHexViewers[viewerIndex].Form;
			}
			else
			{
				// make it new
				HexViewer f = new HexViewer(HexViewerDataSource.FileTable, data, fileID);
				ActiveHexViewers.Add(new HexViewerEntry(f, hash));
				return f;
			}
		}

		/// <summary>
		/// Create a new HexViewer from an array of bytes.
		/// </summary>
		/// <param name="data">Data to be loaded into the HexView.</param>
		/// <param name="title">(optional) Title for the hex editor form.</param>
		/// <returns>HexViewer form with the requested data.</returns>
		public HexViewer NewViewerData(byte[] data, string title = "")
		{
			SHA256 sha256 = SHA256.Create();
			byte[] hash = sha256.ComputeHash(data);

			// check if data has already been loaded
			int viewerIndex = CheckOpenFile(hash);
			if (viewerIndex != -1)
			{
				// already open
				return ActiveHexViewers[viewerIndex].Form;
			}
			else
			{
				// make it new
				HexViewer f = new HexViewer(HexViewerDataSource.ExternalData, data, -1, title);
				ActiveHexViewers.Add(new HexViewerEntry(f, sha256.ComputeHash(data)));
				return f;
			}
		}

		/// <summary>
		/// Create a new HexViewer from an external file.
		/// </summary>
		/// <param name="filePath">Path to file to open in the HexView.</param>
		/// <param name="title">(optional) Title for the hex editor form.</param>
		/// <returns>HexViewer form with the requested data.</returns>
		public HexViewer HexViewerExternalFile(string filePath, string title = "")
		{
			byte[] fileData = File.ReadAllBytes(filePath);
			SHA256 sha256 = SHA256.Create();
			byte[] hash = sha256.ComputeHash(fileData);
			int viewerIndex = CheckOpenFile(hash);
			if (viewerIndex != -1)
			{
				return ActiveHexViewers[viewerIndex].Form;
			}
			else
			{
				HexViewer f = new HexViewer(HexViewerDataSource.ExternalData, fileData, -1, title);
				ActiveHexViewers.Add(new HexViewerEntry(f, hash));
				return f;
			}
		}
		#endregion

		/// <summary>
		/// Check if the requested data is already open in a hex editor.
		/// </summary>
		/// <param name="hash">Data hash to check.</param>
		/// <returns>Index of active hex viewer, or -1 if none found.</returns>
		public int CheckOpenFile(byte[] hash)
		{
			foreach (HexViewerEntry hve in ActiveHexViewers)
			{
				// this probably isn't the best way of doing it, but the other ways I tried didn't work...
				bool match = true;
				for (int i = 0; i < hash.Length; i++)
				{
					if (hash[i] != hve.DataHash[i])
					{
						match = false;
					}
				}
				if (match)
				{
					return ActiveHexViewers.IndexOf(hve);
				}
			}
			return -1;
		}

		/// <summary>
		/// Action taken upon closing of a HexViewer form.
		/// </summary>
		/// <param name="closing">HexViewer to be closed.</param>
		public void FormClosed(HexViewer closing)
		{
			RemoveEntry(closing);
		}

		/// <summary>
		/// Attempt to remove a HexViewerEntry from the active hex viewers list.
		/// </summary>
		/// <param name="closing">Form being closed</param>
		private void RemoveEntry(HexViewer closing)
		{
			foreach (HexViewerEntry hve in ActiveHexViewers)
			{
				if (hve.Form.Equals(closing))
				{
					ActiveHexViewers.Remove(hve);
					return;
				}
			}
		}
	}
}
