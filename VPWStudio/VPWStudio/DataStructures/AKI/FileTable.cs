using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio
{
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
		public UInt32 Location;

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
		#endregion // program-specific
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableEntry()
		{
			this.FileID = 0;
			this.Location = 0;
			this.FileType = FileTypes.Binary;
			this.IsEncoded = false;
			this.Comment = String.Empty;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_loc">Location (do not add 1 for encoded files)</param>
		/// <param name="_enc">Is this file (LZSS) encoded?</param>
		public FileTableEntry(UInt16 _id, UInt32 _loc, bool _enc)
		{
			this.FileID = _id;
			this.Location = _loc;
			this.FileType = FileTypes.Binary;
			this.IsEncoded = _enc;
			this.Comment = String.Empty;
		}

		/// <summary>
		/// Specific constructor with comment.
		/// </summary>
		/// <param name="_loc"></param>
		/// <param name="_enc"></param>
		public FileTableEntry(UInt16 _id, UInt32 _loc, bool _enc, string _comment)
		{
			this.FileID = _id;
			this.Location = _loc;
			this.FileType = FileTypes.Binary;
			this.IsEncoded = _enc;
			this.Comment = _comment;
		}

		/// <summary>
		/// Specific constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public FileTableEntry(BinaryReader br)
		{
			this.ReadEntry(br);
		}
		#endregion

		/// <summary>
		/// Deep copy an existing FileTableEntry.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(FileTableEntry _src)
		{
			this.FileID = _src.FileID;
			this.Location = _src.Location;
			this.FileType = _src.FileType;
			this.IsEncoded = _src.IsEncoded;
			this.Comment = _src.Comment;
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
			this.Location = (BitConverter.ToUInt32(loc, 0) & 0xFFFFFFFE);
			this.IsEncoded = (BitConverter.ToUInt32(loc, 0) & 1) != 0;
		}

		/// <summary>
		/// Write file table entry using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteEntry(BinaryWriter bw)
		{
			UInt32 finalLoc = this.Location;
			if (this.IsEncoded)
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
				this.FileID = UInt16.Parse(xr.GetAttribute("id"), NumberStyles.HexNumber);
				this.Location = UInt32.Parse(xr.GetAttribute("loc"), NumberStyles.HexNumber);
				this.FileType = (FileTypes)Enum.Parse(typeof(FileTypes), xr.GetAttribute("type"));
				this.IsEncoded = bool.Parse(xr.GetAttribute("lzss"));
			}

			if (!xr.IsEmptyElement)
			{
				xr.Read();
				this.Comment = xr.Value;
			}
			else
			{
				this.Comment = String.Empty;
			}
		}

		/// <summary>
		/// Write FileTableEntry data to XML.
		/// </summary>
		/// <param name="xw">XmlWriter instance to use.</param>
		public void WriteXml(XmlWriter xw)
		{
			xw.WriteStartElement("Entry");
			xw.WriteAttributeString("id", String.Format("{0:X4}", this.FileID));
			xw.WriteAttributeString("loc", String.Format("{0:X8}", this.Location));
			xw.WriteAttributeString("type", this.FileType.ToString());
			xw.WriteAttributeString("lzss", this.IsEncoded.ToString());
			xw.WriteString(this.Comment);
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
				string typeDef = this.IsEncoded ? String.Format("{0}, {1}", lzss, ftype) : ftype;
				sw.WriteLine(String.Format(
					"0x{0:X}\t{1}\t{2:X4}{{ext}}",
					this.Location + _offset,
					typeDef,
					this.FileID
				));
			}
			else
			{
				// {location}\t("LZSS_0B" or "bin")\tfilename
				sw.WriteLine(String.Format(
					"0x{0:X}\t{1}\t{2:X4}{{ext}}",
					this.Location + _offset,
					this.IsEncoded ? lzss : ftype,
					this.FileID
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
			this.Entries = new SortedList<int, FileTableEntry>();
			this.Location = 0;
			this.FirstFile = 0;
		}

		/// <summary>
		/// Specific constructor
		/// </summary>
		/// <param name="_loc">Location of FileTable in ROM.</param>
		public FileTable(UInt32 _loc, UInt32 _firstFile)
		{
			this.Entries = new SortedList<int, FileTableEntry>();
			this.Location = _loc;
			this.FirstFile = _firstFile;
		}
		#endregion

		/// <summary>
		/// Deep copy an existing FileTable instance.
		/// </summary>
		/// <param name="_src">FileTable instance to copy.</param>
		public void DeepCopy(FileTable _src)
		{
			this.Location = _src.Location;
			this.FirstFile = _src.FirstFile;
			this.Entries.Clear();
			foreach (KeyValuePair<int, FileTableEntry> fte in _src.Entries)
			{
				this.Entries.Add(fte.Key, fte.Value);
			}
		}

		#region FileTable Entry Routines
		/// <summary>
		/// Find all files of a specified type in the FileTable.
		/// </summary>
		/// <param name="t">FileTypes enum value of file type to find.</param>
		/// <returns>A list containing all the IDs of files matching the specified type.</returns>
		public List<int> GetFilesOfType(FileTypes t)
		{
			List<int> files = new List<int>();

			foreach (KeyValuePair<int, FileTableEntry> fte in this.Entries)
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
		public uint GetEntrySize(int id)
		{
			if (id == this.Entries.Count)
			{
				// last entry needs different calculation
				return (this.Location - this.Entries[id].Location) - this.FirstFile;
			}
			else
			{
				return (this.Entries[id + 1].Location - this.Entries[id].Location);
			}
		}

		/// <summary>
		/// Get the ROM location of the specified file ID.
		/// </summary>
		/// <param name="id">File ID to get location for.</param>
		/// <returns>ROM location of the specified file ID.</returns>
		public uint GetRomLocation(int id)
		{
			return this.Entries[id].Location + this.FirstFile;
		}

		/// <summary>
		/// Extract a file from the filetable.
		/// </summary>
		/// <param name="id">File ID to extract.</param>
		/// <param name="forceRaw">Force raw export</param>
		public void ExtractFile(BinaryReader _in, BinaryWriter _out, int id, bool forceRaw = false)
		{
			uint loc = this.GetRomLocation(id);
			uint size = this.GetEntrySize(id);

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
				if (this.Entries[id].IsEncoded)
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
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read filetable using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="size">Size of the filetable.</param>
		public void Read(BinaryReader br, int size)
		{
			// number of entries = size >> 2;
			for (int i = 1; i < size >> 2; i++)
			{
				FileTableEntry fte = new FileTableEntry(br);
				fte.FileID = (UInt16)i;
				this.Entries.Add(i, fte);
			}
		}

		/// <summary>
		/// Write filetable using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void Write(BinaryWriter bw)
		{
			for (int i = 1; i < this.Entries.Count; i++)
			{
				this.Entries[i].WriteEntry(bw);
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
