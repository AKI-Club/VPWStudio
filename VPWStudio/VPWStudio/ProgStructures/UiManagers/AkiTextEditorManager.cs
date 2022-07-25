using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using VPWStudio.Editors;

namespace VPWStudio
{
	/// <summary>
	/// A single open AkiTextEditor.
	/// </summary>
	public class AkiTextEditorEntry
	{
		/// <summary>
		/// AkiTextEditor form associated with this entry.
		/// </summary>
		public AkiTextEditor Form;

		/// <summary>
		/// SHA256 hash of the data in the text editor.
		/// </summary>
		public byte[] DataHash;

		public AkiTextEditorEntry(AkiTextEditor f, byte[] h)
		{
			Form = f;
			DataHash = h;
		}
	}

	/// <summary>
	/// Manager class for AkiTextEditor.
	/// </summary>
	/// The goal of this class is to handle multiple AkiTextEditors while not summoning more editors than needed.
	public class AkiTextEditorManager
	{
		public List<AkiTextEditorEntry> ActiveTextEditors;

		public AkiTextEditorManager()
		{
			ActiveTextEditors = new List<AkiTextEditorEntry>();
		}

		#region Request New Editor
		/// <summary>
		/// Create a new AkiTextEditor from a FileTable entry.
		/// </summary>
		/// <param name="fileID">ID of file to open in AkiTextEditor.</param>
		/// <returns>AkiTextEditor form with the requested data.</returns>
		public AkiTextEditor NewEditor_FileTable(int fileID)
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
				return ActiveTextEditors[viewerIndex].Form;
			}
			else
			{
				// make it new
				AkiTextEditor f = new AkiTextEditor(fileID);
				ActiveTextEditors.Add(new AkiTextEditorEntry(f, hash));
				return f;
			}
		}

		/// <summary>
		/// Create a new AkiTextEditor from an external file.
		/// </summary>
		/// <param name="path">Path to file to load</param>
		/// <returns>AkiTextEditor form with the requested data.</returns>
		public AkiTextEditor NewEditor_ExtFile(string path)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader fr = new BinaryReader(fs);

			fs.Seek(0, SeekOrigin.End);
			int size = (int)fs.Position;
			fs.Seek(0, SeekOrigin.Begin);
			byte[] data = fr.ReadBytes(size);
			fr.Close();

			SHA256 sha256 = SHA256.Create();
			byte[] hash = sha256.ComputeHash(data);

			// check if data has already been loaded
			int viewerIndex = CheckOpenFile(hash);
			if (viewerIndex != -1)
			{
				// already open
				return ActiveTextEditors[viewerIndex].Form;
			}
			else
			{
				// make it new
				AkiTextEditor f = new AkiTextEditor(path);
				ActiveTextEditors.Add(new AkiTextEditorEntry(f, hash));
				return f;
			}
		}
		#endregion

		/// <summary>
		/// Check if the requested data is already open in an AkiTextEditor.
		/// </summary>
		/// <param name="hash">Data hash to check.</param>
		/// <returns>Index of active AkiTextEditor, or -1 if none found.</returns>
		public int CheckOpenFile(byte[] hash)
		{
			foreach (AkiTextEditorEntry ate in ActiveTextEditors)
			{
				bool match = Array.Equals(ate.DataHash, ate.Form.CurTextArchive.Sha256Hash);
				if (match)
				{
					return ActiveTextEditors.IndexOf(ate);
				}
			}
			return -1;
		}

		/// <summary>
		/// Action taken upon closing of an AkiTextEditor form.
		/// </summary>
		/// <param name="closing">AkiTextEditor to be closed.</param>
		public void FormClosed(AkiTextEditor closing)
		{
			RemoveEntry(closing);
		}

		/// <summary>
		/// Attempt to remove an AkiTextEditor from the active editors list.
		/// </summary>
		/// <param name="closing">Form being closed</param>
		private void RemoveEntry(AkiTextEditor closing)
		{
			foreach (AkiTextEditorEntry ate in ActiveTextEditors)
			{
				if (ate.Form.Equals(closing))
				{
					ActiveTextEditors.Remove(ate);
					return;
				}
			}
		}
	}
}
