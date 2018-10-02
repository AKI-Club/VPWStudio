using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio
{
	#region File Table Entry Extra Data
	/// <summary>
	/// Extra Information for FileTableEntry items.
	/// </summary>
	public class FileTableEntryExtraData : IXmlSerializable
	{
		/// <summary>
		/// "Not used" value.
		/// </summary>
		private const int INVALID_DATA = -1;

		#region Class Members
		/// <summary>
		/// Image Width, when not provided by the file.
		/// </summary>
		public int ImageWidth;

		/// <summary>
		/// Image Height, when not provided by the file.
		/// </summary>
		public int ImageHeight;

		/// <summary>
		/// Index of transparent color.
		/// </summary>
		public int TransparentColorIndex;

		/// <summary>
		/// Intended palette file for an image.
		/// </summary>
		public int IntendedPaletteFileID;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableEntryExtraData()
		{
			ImageWidth = INVALID_DATA;
			ImageHeight = INVALID_DATA;
			TransparentColorIndex = INVALID_DATA;
			IntendedPaletteFileID = INVALID_DATA;
		}

		#region XML Read/Write
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Read FileTableEntryExtraData using an XmlReader.
		/// </summary>
		/// <param name="xr">XmlReader instance to use.</param>
		public void ReadXml(XmlReader xr)
		{
			while (true)
			{
				xr.Read();

				if (xr.Name == "ExtraData" && xr.NodeType == XmlNodeType.EndElement)
				{
					break;
				}

				if (xr.Name == "ImageWidth" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						this.ImageWidth = int.Parse(xr.Value);
					}
				}

				if (xr.Name == "ImageHeight" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						this.ImageHeight = int.Parse(xr.Value);
					}
				}

				if (xr.Name == "TransparentColorIndex" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						this.TransparentColorIndex = int.Parse(xr.Value);
					}
				}

				if (xr.Name == "IntendedPaletteFile" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						this.IntendedPaletteFileID = int.Parse(xr.Value);
					}
				}
			}
		}

		/// <summary>
		/// Element write helper.
		/// </summary>
		/// <param name="xw">XmlWriter instance to use.</param>
		/// <param name="name">Name of element to write.</param>
		/// <param name="value">Value to write to element.</param>
		private void WriteElement(XmlWriter xw, string name, int value)
		{
			// Only bother writing data if it's not invalid.
			// We don't need the project files ballooning in file size unnecessarily.
			if (value != INVALID_DATA)
			{
				xw.WriteElementString(name, value.ToString());
			}
		}

		/// <summary>
		/// Write FileTableEntryExtraData using an XmlWriter.
		/// </summary>
		/// <param name="xw">XmlWriter instance to use.</param>
		public void WriteXml(XmlWriter xw)
		{
			xw.WriteStartElement("ExtraData");

			WriteElement(xw, "ImageWidth", ImageWidth);
			WriteElement(xw, "ImageHeight", ImageHeight);
			WriteElement(xw, "TransparentColorIndex", TransparentColorIndex);
			WriteElement(xw, "IntendedPaletteFile", IntendedPaletteFileID);

			xw.WriteEndElement();
		}
		#endregion
	}
	#endregion

	/// <summary>
	/// Possible encoding states for FileTableReplacement entries.
	/// </summary>
	public enum FileTableReplaceEncoding
	{
		/// <summary>
		/// Pick the best fit between Raw and LZSS.
		/// </summary>
		PickBest = 0,

		/// <summary>
		/// Force raw.
		/// </summary>
		ForceRaw = 1,

		/// <summary>
		/// Force LZSS encoding.
		/// </summary>
		ForceLzss = 2
	}

	#region File Table Entry
	/// <summary>
	/// A single entry in the filetable.
	/// </summary>
	public class FileTableEntry : IXmlSerializable
	{
		#region Class Members
		/// <summary>
		/// Two byte ID for this file.
		/// </summary>
		/// Normally, this would be up to the container to handle, but...
		public UInt16 FileID;

		/// <summary>
		/// Location of this file (relative to the beginning of the files).
		/// </summary>
		public Int32 Location;

		#region Program-Specific
		/// <summary>
		/// FileType for this item.
		/// </summary>
		public FileTypes FileType;

		/// <summary>
		/// Is this file encoded?
		/// </summary>
		public bool IsEncoded;

		/// <summary>
		/// Comment about this file entry.
		/// </summary>
		public string Comment;

		/// <summary>
		/// Replacement file encoding.
		/// </summary>
		public FileTableReplaceEncoding ReplaceEncoding;

		/// <summary>
		/// Replacement file path.
		/// </summary>
		public string ReplaceFilePath;

		/// <summary>
		/// Does this entry specify a different filetype than the original FileTable entry?
		/// </summary>
		public bool OverrideFileType;

		/// <summary>
		/// Extra Data about this FileTable entry.
		/// </summary>
		public FileTableEntryExtraData ExtraData;
		#endregion // program-specific
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableEntry()
		{
			FileID = 0;
			Location = 0;
			FileType = FileTypes.Binary;
			IsEncoded = false;
			Comment = String.Empty;
			ReplaceEncoding = FileTableReplaceEncoding.PickBest;
			ReplaceFilePath = String.Empty;
			OverrideFileType = false;
			ExtraData = new FileTableEntryExtraData();
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_loc">Location (do not add 1 for encoded files)</param>
		/// <param name="_enc">Is this file (LZSS) encoded?</param>
		public FileTableEntry(UInt16 _id, Int32 _loc, bool _enc)
		{
			FileID = _id;
			Location = _loc;
			FileType = FileTypes.Binary;
			IsEncoded = _enc;
			Comment = String.Empty;
			ReplaceEncoding = (_enc == true) ? FileTableReplaceEncoding.ForceLzss : FileTableReplaceEncoding.PickBest;
			ReplaceFilePath = String.Empty;
			OverrideFileType = false;
			ExtraData = new FileTableEntryExtraData();
		}

		/// <summary>
		/// Specific constructor with comment.
		/// </summary>
		/// <param name="_loc"></param>
		/// <param name="_enc"></param>
		public FileTableEntry(UInt16 _id, Int32 _loc, bool _enc, string _comment)
		{
			FileID = _id;
			Location = _loc;
			FileType = FileTypes.Binary;
			IsEncoded = _enc;
			Comment = _comment;
			ReplaceEncoding = (_enc == true) ? FileTableReplaceEncoding.ForceLzss : FileTableReplaceEncoding.PickBest;
			ReplaceFilePath = String.Empty;
			OverrideFileType = false;
			ExtraData = new FileTableEntryExtraData();
		}

		/// <summary>
		/// Specific constructor from an existing FileTableEntry instance.
		/// </summary>
		/// <param name="_existing">FileTableEntry instance to clone.</param>
		public FileTableEntry(FileTableEntry _existing)
		{
			DeepCopy(_existing);
		}

		/// <summary>
		/// Specific constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public FileTableEntry(BinaryReader br)
		{
			ReadEntry(br);
		}
		#endregion

		/// <summary>
		/// Deep copy an existing FileTableEntry.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(FileTableEntry _src)
		{
			FileID = _src.FileID;
			Location = _src.Location;
			FileType = _src.FileType;
			IsEncoded = _src.IsEncoded;
			Comment = _src.Comment;
			ReplaceEncoding = _src.ReplaceEncoding;
			ReplaceFilePath = _src.ReplaceFilePath;
			OverrideFileType = _src.OverrideFileType;
			ExtraData = _src.ExtraData;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read file table entry using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadEntry(BinaryReader br)
		{
			byte[] loc = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(loc);
			}
			Location = (int)(BitConverter.ToInt32(loc, 0) & 0xFFFFFFFE);
			IsEncoded = (BitConverter.ToUInt32(loc, 0) & 1) != 0;
			ReplaceEncoding = (this.IsEncoded) ? FileTableReplaceEncoding.ForceLzss : FileTableReplaceEncoding.ForceRaw;
		}

		/// <summary>
		/// Write file table entry using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteEntry(BinaryWriter bw)
		{
			Int32 finalLoc = Location;
			if (IsEncoded)
			{
				finalLoc |= 1;
			}

			byte[] loc = BitConverter.GetBytes(finalLoc);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(loc);
			}
			bw.Write(loc);
		}
		#endregion

		#region XML Read/Write
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Read FileTableEntry data from XML.
		/// </summary>
		/// <param name="xr">XmlReader instance to use.</param>
		public void ReadXml(XmlReader xr)
		{
			if (xr.HasAttributes)
			{
				FileID = UInt16.Parse(xr.GetAttribute("id"), NumberStyles.HexNumber);
				Location = Int32.Parse(xr.GetAttribute("loc"), NumberStyles.HexNumber);
				FileType = (FileTypes)Enum.Parse(typeof(FileTypes), xr.GetAttribute("type"));
				IsEncoded = bool.Parse(xr.GetAttribute("lzss"));
			}

			while (true)
			{
				xr.Read();

				if (xr.Name == "Entry" && xr.NodeType == XmlNodeType.EndElement)
				{
					break;
				}

				if (xr.Name == "Comment" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						Comment = xr.Value;
					}
				}

				if (xr.Name == "ReplaceEncoding" && xr.NodeType == XmlNodeType.Element)
				{
					xr.Read();
					ReplaceEncoding = (FileTableReplaceEncoding)Enum.Parse(typeof(FileTableReplaceEncoding), xr.Value);
				}

				if (xr.Name == "ReplaceFilePath" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						ReplaceFilePath = xr.Value;
					}
				}

				if (xr.Name == "OverrideFileType" && xr.NodeType == XmlNodeType.Element)
				{
					xr.Read();
					OverrideFileType = bool.Parse(xr.Value);
				}

				if (xr.Name == "ExtraData" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						ExtraData.ReadXml(xr);
					}
				}
			}
		}

		/// <summary>
		/// Write FileTableEntry data to XML.
		/// </summary>
		/// <param name="xw">XmlWriter instance to use.</param>
		public void WriteXml(XmlWriter xw)
		{
			xw.WriteStartElement("Entry");
			xw.WriteAttributeString("id", String.Format("{0:X4}", FileID));
			xw.WriteAttributeString("loc", String.Format("{0:X8}", Location));
			xw.WriteAttributeString("type", FileType.ToString());
			xw.WriteAttributeString("lzss", IsEncoded.ToString());

			xw.WriteElementString("Comment", Comment);
			xw.WriteElementString("ReplaceEncoding", ReplaceEncoding.ToString());
			xw.WriteElementString("ReplaceFilePath", ReplaceFilePath);
			xw.WriteElementString("OverrideFileType", OverrideFileType.ToString());

			ExtraData.WriteXml(xw);

			xw.WriteEndElement();
		}
		#endregion

		#region Midwaydec Read/Write
		/// <summary>
		/// haven't really finished this yet
		/// </summary>
		/// <param name="sr"></param>
		public void ReadMidwaydecEntry(StreamReader sr)
		{
			// xxx: this should be elsewhere
			string line = sr.ReadLine();
			// skip comments
			if (line.StartsWith("#"))
			{
				return;
			}

			string[] tokens = line.Split(new char[] { '\t' });

			if (tokens[0].Contains(","))
			{
				// file length is included

				// 0x1310F40, 0xCC8C	bin	filetable.bin
				// there is a SPACE after the comma
			}

			// filetype can be tricky too
			// 0x18542E	bin	font.txt
			// 0x188F3A	LZSS_0B, AKItext
		}

		/// <summary>
		/// Write a Midwaydec File Table entry.
		/// </summary>
		/// <param name="sw">StreamWriter instance to use.</param>
		/// <param name="_offset"></param>
		public void WriteMidwaydecEntry(StreamWriter sw, UInt32 _offset)
		{
			string lzss = String.Empty;
			string ftype = String.Empty;

			if (this.IsEncoded)
			{
				lzss = "LZSS_0B"; // or "Asmic" if you so prefer, but I think both do the same thing.
			}

			// types Midwaydec can handle
			switch (this.FileType)
			{
				case FileTypes.AkiSmallFont:
					ftype = "smallAKIfnt";
					break;
				case FileTypes.AkiLargeFont:
					ftype = "largeAKIfnt";
					break;
				case FileTypes.AkiText:
					ftype = "AKItext";
					break;
				case FileTypes.AkiTexture:
					ftype = "TEX";
					break;
				default: // fallback for everything else
					ftype = "bin";
					break;
			}

			if (!ftype.Equals("bin"))
			{
				// the main wrench here is that ftype can be appended to the LZSS string
				// {location}\t("LZSS_0B", ftype)\tfilename
				string typeDef = IsEncoded ? String.Format("{0}, {1}", lzss, ftype) : ftype;
				sw.WriteLine(String.Format(
					"0x{0:X}\t{1}\t{2:X4}{{ext}}",
					Location + _offset,
					typeDef,
					FileID
				));
			}
			else
			{
				// {location}\t("LZSS_0B" or "bin")\tfilename
				sw.WriteLine(String.Format(
					"0x{0:X}\t{1}\t{2:X4}{{ext}}",
					Location + _offset,
					IsEncoded ? lzss : ftype,
					FileID
				));
			}
		}
		#endregion
	}
	#endregion

	/// <summary>
	/// FileTable representation
	/// </summary>
	public class FileTable : IXmlSerializable
	{
		#region Class Members
		/// <summary>
		/// Entries in this filetable.
		/// </summary>
		public SortedList<int, FileTableEntry> Entries;

		/// <summary>
		/// Location of the filetable in ROM.
		/// </summary>
		public UInt32 Location;

		/// <summary>
		/// ROM location of the first file in the FileTable.
		/// </summary>
		public UInt32 FirstFile;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public FileTable()
		{
			Entries = new SortedList<int, FileTableEntry>();
			Location = 0;
			FirstFile = 0;
		}

		/// <summary>
		/// Specific constructor
		/// </summary>
		/// <param name="_loc">Location of FileTable in ROM.</param>
		public FileTable(UInt32 _loc, UInt32 _firstFile)
		{
			Entries = new SortedList<int, FileTableEntry>();
			Location = _loc;
			FirstFile = _firstFile;
		}

		/// <summary>
		/// Create a new FileTable from an existing FileTable instance.
		/// </summary>
		/// <param name="_existing">FileTable instance to clone.</param>
		public FileTable(FileTable _existing)
		{
			DeepCopy(_existing);
		}
		#endregion

		/// <summary>
		/// Deep copy an existing FileTable instance.
		/// </summary>
		/// <param name="_src">FileTable instance to copy.</param>
		public void DeepCopy(FileTable _src)
		{
			Location = _src.Location;
			FirstFile = _src.FirstFile;
			Entries = new SortedList<int, FileTableEntry>();
			Entries.Clear();
			foreach (KeyValuePair<int, FileTableEntry> fte in _src.Entries)
			{
				FileTableEntry cloneEntry = new FileTableEntry();
				cloneEntry.DeepCopy(fte.Value);
				Entries.Add(fte.Key, cloneEntry);
			}
		}

		#region FileTable Entry Routines
		/// <summary>
		/// Find all files of a specified type in the FileTable.
		/// </summary>
		/// <param name="t">FileTypes enum value of file type to find.</param>
		/// <returns>A List containing all the IDs of files matching the specified type.</returns>
		public List<int> GetFilesOfType(FileTypes t)
		{
			List<int> files = new List<int>();

			foreach (KeyValuePair<int, FileTableEntry> fte in Entries)
			{
				if (fte.Value.FileType == t)
				{
					files.Add(fte.Key);
				}
			}

			return files;
		}

		/// <summary>
		/// Get the file size of the specified entry.
		/// </summary>
		/// <param name="id">File ID to get size of.</param>
		/// <returns></returns>
		/// Note: This calculates the size based on the filetable
		/// entries, not the files themselves.
		public int GetEntrySize(int id)
		{
			if (id == Entries.Count)
			{
				// last entry needs different calculation
				return (int)((Location - Entries[id].Location) - FirstFile);
			}
			else
			{
				// a certain file in WWF No Mercy's filetable (ID 4C03)
				// requires me to make this otherwise unnecessary check...

				if (Entries[id].Location > Entries[id + 1].Location)
				{
					return (Entries[id].Location - Entries[id + 1].Location);
				}
				else
				{
					return (Entries[id + 1].Location - Entries[id].Location);
				}
			}
		}

		/// <summary>
		/// Get the ROM location of the specified file ID.
		/// </summary>
		/// <param name="id">File ID to get location for.</param>
		/// <returns>ROM location of the specified file ID.</returns>
		public int GetRomLocation(int id)
		{
			return (int)(Entries[id].Location + FirstFile);
		}
		#endregion

		/// <summary>
		/// Extract a file from the filetable.
		/// </summary>
		/// <param name="_in">BinaryReader instance with ROM loaded.</param>
		/// <param name="_out">BinaryWriter instance to write data to.</param>
		/// <param name="id">File ID to extract.</param>
		/// <param name="forceRaw">Force raw export.</param>
		public void ExtractFile(BinaryReader _in, BinaryWriter _out, int id, bool forceRaw = false)
		{
			int loc = GetRomLocation(id);
			int size = GetEntrySize(id);

			_in.BaseStream.Seek(loc, SeekOrigin.Begin);
			byte[] data = _in.ReadBytes((int)size);

			if (forceRaw)
			{
				// always export raw
				_out.Write(data);
			}
			else
			{
				// act on this.Entries[id].IsEncoded
				if (Entries[id].IsEncoded)
				{
					// de-LZSS
					MemoryStream ms = new MemoryStream(data);
					BinaryReader br = new BinaryReader(ms);
					AsmikLzss.Decode(br, _out);
				}
				else
				{
					// export raw
					_out.Write(data);
				}
			}
		}

		/// <summary>
		/// Extract a MenuBackground from the FileTable.
		/// </summary>
		/// <param name="_in">BinaryReader instance with ROM loaded.</param>
		/// <param name="firstID">First File ID of the MenuBackground.</param>
		/// <param name="gameType"></param>
		/// <returns>MenuBackground item with the extracted data.</returns>
		public MenuBackground ExtractMenuBackground(BinaryReader _in, int firstID, VPWGames gameType)
		{
			MenuBackground mb = new MenuBackground(firstID, gameType);
			List<byte> bgData = new List<byte>();

			// extract all files
			for (int i = 0; i < (mb.ChunkColumns * mb.ChunkRows); i++)
			{
				int curID = firstID + i;
				int loc = GetRomLocation(curID);
				int size = GetEntrySize(curID);

				_in.BaseStream.Seek(loc, SeekOrigin.Begin);
				byte[] data = _in.ReadBytes((int)size);

				if (Entries[curID].IsEncoded)
				{
					// de-lzss
					MemoryStream tempOut = new MemoryStream();
					BinaryWriter tempWriter = new BinaryWriter(tempOut);

					MemoryStream ms = new MemoryStream(data);
					BinaryReader br = new BinaryReader(ms);
					AsmikLzss.Decode(br, tempWriter);
					bgData.AddRange(tempOut.ToArray());
					br.Close();
					tempWriter.Close();
				}
				else
				{
					// monday night raw
					bgData.AddRange(data);
				}
			}

			mb.Data = bgData.ToArray();
			mb.ReadData();
			return mb;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read filetable using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="size">Size of the filetable.</param>
		public void Read(BinaryReader br, int size)
		{
			// number of entries = size >> 2;
			for (int i = 1; i <= size >> 2; i++)
			{
				FileTableEntry fte = new FileTableEntry(br);
				fte.FileID = (UInt16)i;
				Entries.Add(i, fte);
			}
		}

		/// <summary>
		/// Write filetable data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void Write(BinaryWriter bw)
		{
			for (int i = 1; i <= Entries.Count; i++)
			{
				Entries[i].WriteEntry(bw);
			}
		}
		#endregion

		#region XML Read/Write
		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader xr)
		{
			xr.ReadToFollowing("FileTable");

			xr.ReadToFollowing("Location");
			xr.Read();
			this.Location = UInt32.Parse(xr.Value, NumberStyles.HexNumber);

			xr.ReadToFollowing("FirstFile");
			xr.Read();
			this.FirstFile = UInt32.Parse(xr.Value, NumberStyles.HexNumber);

			xr.ReadToFollowing("Entries");
			while (xr.ReadToFollowing("Entry"))
			{
				FileTableEntry fte = new FileTableEntry();
				fte.ReadXml(xr);
				this.Entries.Add(fte.FileID, fte);
			}
		}

		public void WriteXml(XmlWriter xw)
		{
			// start tag
			xw.WriteStartElement("FileTable");

			xw.WriteElementString("Location", String.Format("{0:X}", this.Location));
			xw.WriteElementString("FirstFile", String.Format("{0:X}", this.FirstFile));

			// entries
			xw.WriteStartElement("Entries");
			foreach (KeyValuePair<int, FileTableEntry> fte in this.Entries)
			{
				fte.Value.WriteXml(xw);
			}
			xw.WriteEndElement();

			// end tag
			xw.WriteEndElement();
		}
		#endregion

		#region Midwaydec Read/Write
		/// <summary>
		/// Something about attempting to load filetypes and filenames (as comments) from Midwaydec File Lists.
		/// </summary>
		/// <param name="sr"></param>
		public void ReadMidwaydec(StreamReader sr)
		{
			// todo: what
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				if (line.StartsWith("#"))
				{
					continue;
				}

				// we're mainly here to check a few things...
				// * does the location in the midwaydec file match a ROM location in the filelist?
				// * is the filetype in the midwaydec file different, and NOT "bin"
				// * use filename as comment *IF* comment not available in our filelist.
			}
		}

		/// <summary>
		/// Export FileTable to Midwaydec File List format.
		/// </summary>
		/// <param name="sw">StreamWriter instance to use.</param>
		/// <param name="_ftOffset">Offset where filetable is located.</param>
		public void WriteMidwaydec(StreamWriter sw)
		{
			sw.WriteLine("# Midwaydec file list generated by VPW Studio.");
			sw.WriteLine("# This is an incomplete list, only covering the game's internal filetable.");
			foreach (KeyValuePair<int, FileTableEntry> fte in this.Entries)
			{
				fte.Value.WriteMidwaydecEntry(sw, this.FirstFile);
			}

			// filetable entry
			sw.WriteLine(String.Format("# Add 0x{0:X} to each entry for actual offset.", this.FirstFile));
			sw.WriteLine(String.Format(
				"0x{0:X}, 0x{1:X}\tbin\tfiletable.bin",
				this.Location,
				(this.Entries.Count << 2) + 4
			));
		}
		#endregion
	}
}
