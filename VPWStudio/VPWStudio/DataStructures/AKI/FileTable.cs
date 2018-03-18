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
		/// Default constructor.
		/// </summary>
		public FileTableEntryExtraData()
		{
			ImageWidth = INVALID_DATA;
			ImageHeight = INVALID_DATA;
			TransparentColorIndex = INVALID_DATA;
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

		/// <summary>
		/// Replacement file encoding.
		/// </summary>
		public FileTableReplaceEncoding ReplaceEncoding;

		/// <summary>
		/// Replacement file path.
		/// </summary>
		public string ReplaceFilePath;

		public FileTableEntryExtraData ExtraData;
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
			this.ReplaceEncoding = FileTableReplaceEncoding.PickBest;
			this.ReplaceFilePath = String.Empty;
			this.ExtraData = new FileTableEntryExtraData();
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
			this.ReplaceEncoding = (_enc == true) ? FileTableReplaceEncoding.ForceLzss : FileTableReplaceEncoding.PickBest;
			this.ReplaceFilePath = String.Empty;
			this.ExtraData = new FileTableEntryExtraData();
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
			this.ReplaceEncoding = (_enc == true) ? FileTableReplaceEncoding.ForceLzss : FileTableReplaceEncoding.PickBest;
			this.ReplaceFilePath = String.Empty;
			this.ExtraData = new FileTableEntryExtraData();
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
			this.ReplaceEncoding = _src.ReplaceEncoding;
			this.ReplaceFilePath = _src.ReplaceFilePath;
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
			this.ReplaceEncoding = (this.IsEncoded) ? FileTableReplaceEncoding.ForceLzss : FileTableReplaceEncoding.PickBest;
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
						this.Comment = xr.Value;
					}
				}

				if (xr.Name == "ReplaceEncoding" && xr.NodeType == XmlNodeType.Element)
				{
					xr.Read();
					this.ReplaceEncoding = (FileTableReplaceEncoding)Enum.Parse(typeof(FileTableReplaceEncoding), xr.Value);
				}

				if (xr.Name == "ReplaceFilePath" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
						this.ReplaceFilePath = xr.Value;
					}
				}

				if (xr.Name == "ExtraData" && xr.NodeType == XmlNodeType.Element)
				{
					if (!xr.IsEmptyElement)
					{
						xr.Read();
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
			xw.WriteAttributeString("id", String.Format("{0:X4}", this.FileID));
			xw.WriteAttributeString("loc", String.Format("{0:X8}", this.Location));
			xw.WriteAttributeString("type", this.FileType.ToString());
			xw.WriteAttributeString("lzss", this.IsEncoded.ToString());

			xw.WriteElementString("Comment", this.Comment);
			xw.WriteElementString("ReplaceEncoding", this.ReplaceEncoding.ToString());
			xw.WriteElementString("ReplaceFilePath", this.ReplaceFilePath);

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
				this.Entries.Add(fte.Key, fte.Value);
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

		#region FileTable replacement
		/// <summary>
		/// Return code for file replacement routine.
		/// </summary>
		public enum ReplaceFileReturnCode
		{
			/// <summary>
			/// The (former) name of this enum (DotNetTransparencyHandlingSucks) is self-explanatory.
			/// </summary>
			/// Basically if you try importing a paletted image with transparency,
			/// .NET will "helpfully" convert the PixelFormat to Format32bppArgb.
			DotNetTransparencyHandlingSucks = -5,

			/// <summary>
			/// Invalid PixelFormat for this entry.
			/// </summary>
			/// Example: trying to load a CI8 (256 colors) image into a CI4 (16 colors) slot
			InvalidPixelFormat = -4,

			/// <summary>
			/// Invalid FileType set for this entry.
			/// </summary>
			/// Example: trying to load a PNG into AkiText
			InvalidFileType = -3,

			/// <summary>
			/// Replacement file does not exist.
			/// </summary>
			FileDoesNotExist = -2,

			/// <summary>
			/// Generic error.
			/// </summary>
			Error = -1,

			/// <summary>
			/// Everything went ok. (New file size == old file size)
			/// </summary>
			OK = 0,

			/// <summary>
			/// New file is smaller than the older file.
			/// </summary>
			NewFileSmaller = 1,

			/// <summary>
			/// New file is bigger than the older file.
			/// </summary>
			NewFileBigger = 2,
		}

		/// <summary>
		/// ReplaceFile return information.
		/// </summary>
		public struct ReplaceFileReturnData
		{
			/// <summary>
			/// Difference in filesize between old and new files.
			/// </summary>
			public int Difference;
			public ReplaceFileReturnCode ReturnCode;
		}

		/// <summary>
		/// Attempt file replacement.
		/// </summary>
		/// <param name="romData">A List of bytes containing the output ROM data.</param>
		/// <param name="fte">FileTableEntry of file to replace.</param>
		/// <param name="projectPath">Project file path. (used for relative path resolution)</param>
		/// <param name="gameType">VPW Game Type. (used for font conversion)</param>
		/// <returns>ReplaceFileReturnData describing the result.</returns>
		public ReplaceFileReturnData ReplaceFile(List<byte> romData, FileTableEntry fte, string projectPath, VPWGames gameType)
		{
			ReplaceFileReturnData rd = new ReplaceFileReturnData();

			// determine path type for replacement file and act accordingly
			string replaceFilePath = String.Empty;
			if (!Path.IsPathRooted(fte.ReplaceFilePath))
			{
				// relative to projectPath
				replaceFilePath = String.Format("{0}\\{1}", projectPath, fte.ReplaceFilePath);
			}
			else
			{
				// absolute
				replaceFilePath = fte.ReplaceFilePath;
			}

			// make sure replacement file exists
			if (!File.Exists(replaceFilePath))
			{
				rd.ReturnCode = ReplaceFileReturnCode.FileDoesNotExist;
				rd.Difference = 0;
				return rd;
			}

			// determine start and end points of the existing file at this location
			int start = (int)fte.Location;
			int end = (int)Entries[fte.FileID + 1].Location;

			// todo: this is the part of the routine that needs fixing
			// AND requires the most attention.

			// what happens during replacement depends on multiple factors:
			// - is the original file slot compressed?
			// - replacement file type (could be pre-lzss'd, could be data that needs compressing, could even be data that needs conversion)
			// - what type of slot are we replacing?

			// of these, I believe the slot filetype is the most important, as it will define how we handle the data.
			// there is the minor issue that someone will want to replace data in a slot that's marked as "Binary".

			// The replacement file's extension plays a big part in how data is handled.
			string replaceFileExtension = Path.GetExtension(replaceFilePath);
			// we can shortcut the FileType handling if the input data is already compressed/encoded.
			bool alreadyCompressed = (replaceFileExtension == "lzss");

			// todo: we don't always want to do this, do we?
			// some files are better served with StreamReader...
			FileStream replaceFileStream = new FileStream(replaceFilePath, FileMode.Open);
			BinaryReader replaceFileReader = new BinaryReader(replaceFileStream);

			// these, however, are pretty much required.
			MemoryStream outFileStream = new MemoryStream();
			BinaryWriter outFileWriter = new BinaryWriter(outFileStream);

			if (!alreadyCompressed)
			{
				#region FileType handling
				switch (fte.FileType)
				{
					case FileTypes.Binary:
						{
							// well, fuck.
						}
						break;

					#region todo: sort me
					case FileTypes.AkiArchive:
						{
							// "akiarc" is the only accepted type
						}
						break;

					case FileTypes.AkiModel:
						{
							// "model" and "obj" types
						}
						break;
					#endregion

					#region Palette Types
					case FileTypes.Ci4Palette:
						{
							Ci4Palette ci4pal = new Ci4Palette();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.Ci4Palette])
							{
								// Ci4Palette, uncompressed/unencoded
								ci4pal.ReadData(replaceFileReader);
							}
							else if (replaceFileExtension == "pal")
							{
								// JASC Paint Shop Pro Palette, needs conversion
								FileStream fs = new FileStream(replaceFilePath, FileMode.Open);
								StreamReader sr = new StreamReader(fs);
								if (ci4pal.ImportJasc(sr) == false)
								{
									sr.Close();
									rd.Difference = 0;
									rd.ReturnCode = ReplaceFileReturnCode.Error;
									return rd;
								}
								sr.Close();
							}
							else
							{
								// invalid Ci4Palette input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}

							// handle transparent color
							if (fte.ExtraData.TransparentColorIndex != -1)
							{
								// todo: argh this probably isn't right because lol endianness
								ci4pal.Entries[fte.ExtraData.TransparentColorIndex] &= 0xFFFE;
							}

							ci4pal.WriteData(outFileWriter);
						}
						break;

					case FileTypes.Ci8Palette:
						{
							Ci8Palette ci8pal = new Ci8Palette();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.Ci8Palette])
							{
								// Ci8Palette, uncompressed/unencoded
								ci8pal.ReadData(replaceFileReader);
							}
							else if (replaceFileExtension == "pal")
							{
								// JASC Paint Shop Pro Palette, needs conversion
								FileStream fs = new FileStream(replaceFilePath, FileMode.Open);
								StreamReader sr = new StreamReader(fs);
								if (ci8pal.ImportJasc(sr) == false)
								{
									sr.Close();
									rd.Difference = 0;
									rd.ReturnCode = ReplaceFileReturnCode.Error;
									return rd;
								}
								sr.Close();
							}
							else
							{
								// invalid Ci8Palette input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}

							// handle transparent color
							if (fte.ExtraData.TransparentColorIndex != -1)
							{
								// todo: argh this probably isn't right because lol endianness
								ci8pal.Entries[fte.ExtraData.TransparentColorIndex] &= 0xFFFE;
							}

							ci8pal.WriteData(outFileWriter);
						}
						break;
					#endregion // Palette Types

					#region Texture Types
					// AKI "TEX" format
					case FileTypes.AkiTexture:
						{
							AkiTexture akitex = new AkiTexture();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.AkiTexture])
							{
								// AkiTexture, uncompressed/unencoded
								akitex.ReadData(replaceFileReader);
							}
							else if (replaceFileExtension == "png")
							{
								// PNG image, needs conversion
								Bitmap png = new Bitmap(replaceFilePath);
								akitex.FromBitmap(png);
							}
							else
							{
								// invalid AkiTexture input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}

							// handle transparent color
							if (fte.ExtraData.TransparentColorIndex != -1)
							{
								// todo: argh this probably isn't right because lol endianness
								akitex.Palette[fte.ExtraData.TransparentColorIndex] &= 0xFFFE;
							}

							akitex.WriteData(outFileWriter);
						}
						break;

					case FileTypes.DoubleTex:
						{
						}
						break;

					// CI4 Textures (16 colors)
					case FileTypes.Ci4Texture:
						{
							Ci4Texture ci4tex = new Ci4Texture();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.Ci4Texture])
							{
								// CI4 texture, uncompressed/unencoded
								ci4tex.ReadData(replaceFileReader);
							}
							else if (replaceFileExtension == "png")
							{
								// PNG image, needs conversion
								Bitmap png = new Bitmap(replaceFilePath);
								if (png.PixelFormat == PixelFormat.Format4bppIndexed)
								{
									// ok
								}
								else if (png.PixelFormat == PixelFormat.Format32bppArgb)
								{
									rd.ReturnCode = ReplaceFileReturnCode.DotNetTransparencyHandlingSucks;
									rd.Difference = 0;
									return rd;
								}
								else
								{
									rd.ReturnCode = ReplaceFileReturnCode.InvalidPixelFormat;
									rd.Difference = 0;
									return rd;
								}
							}
							else
							{
								// invalid CI4 input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}
						}
						break;

					// CI8 Textures (256 colors)
					case FileTypes.Ci8Texture:
						{
							Ci8Texture ci8tex = new Ci8Texture();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.Ci8Texture])
							{
								// CI8 texture, uncompressed/unencoded
								ci8tex.ReadData(replaceFileReader);
							}
							else if (replaceFileExtension == "png")
							{
								// PNG image, needs conversion
								Bitmap png = new Bitmap(replaceFilePath);
								if (png.PixelFormat == PixelFormat.Format8bppIndexed)
								{
									// ok
								}
								else if (png.PixelFormat == PixelFormat.Format32bppArgb)
								{
									rd.ReturnCode = ReplaceFileReturnCode.DotNetTransparencyHandlingSucks;
									rd.Difference = 0;
									return rd;
								}
								else
								{
									rd.ReturnCode = ReplaceFileReturnCode.InvalidPixelFormat;
									rd.Difference = 0;
									return rd;
								}
							}
							else
							{
								// invalid CI8 input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}
						}
						break;

					// I4 Textures (16 indices)
					case FileTypes.I4Texture:
						{
							I4Texture i4tex = new I4Texture();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.I4Texture])
							{
								// I4 texture, uncompressed/unencoded
							}
							else if (replaceFileExtension == "png")
							{
								// PNG image, needs conversion.
							}
							else
							{
								// invalid I4 input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}
						}
						break;
					#endregion // Texture Data

					#region Font Types
					case FileTypes.AkiFontChars:
						{
							// this could really be done as Binary, I guess.
						}
						break;

					case FileTypes.AkiLargeFont:
						{
							// fun!
							AkiFont largeFont = new AkiFont(AkiFontType.AkiLargeFont, gameType);
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.AkiLargeFont])
							{
								// AkiLargeFont, uncompressed/unencoded
							}
							else if (replaceFileExtension == "png")
							{
								// PNG image, needs conversion.
							}
							else
							{
								// invalid AkiLargeFont input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}
						}
						break;

					case FileTypes.AkiSmallFont:
						{
							// fun!
							AkiFont smallFont = new AkiFont(AkiFontType.AkiSmallFont, gameType);
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.AkiSmallFont])
							{
								// AkiSmallFont, uncompressed/unencoded
							}
							else if (replaceFileExtension == "png")
							{
								// PNG image, needs conversion.
							}
							else
							{
								// invalid AkiSmallFont input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}
						}
						break;
					#endregion // Font Types

					#region Text Types
					case FileTypes.AkiText:
						{
							AkiText textData = new AkiText();
							if (replaceFileExtension == FileTypeInfo.DefaultFileTypeExtensions[FileTypes.AkiText])
							{
								// AkiText, uncompressed/unencoded
								textData.ReadData(replaceFileReader);
							}
							else if (replaceFileExtension == "csv")
							{
								// todo: CSV conversion not yet supported
							}
							else
							{
								// invalid AkiText input
								rd.ReturnCode = ReplaceFileReturnCode.InvalidFileType;
								rd.Difference = 0;
								return rd;
							}

							textData.WriteData(outFileWriter);
						}
						break;

					case FileTypes.NoMercyText:
						{
							//GameSpecific.NoMercy.NoMercyText nmText = new GameSpecific.NoMercy.NoMercyText();
						}
						break;
						#endregion // Text Types
				}
				#endregion
			}

			// handle output data
			outFileStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outFileReader = new BinaryReader(outFileStream);

			if (!fte.IsEncoded)
			{
				// insert raw
			}
			else
			{
				if (alreadyCompressed)
				{
					// insert pre-compressed data
				}
				else
				{
					// compress and insert compressed
					AsmikLzss.Encode(outFileReader, outFileWriter);
				}
			}

			// handle alignment
			if ((outFileWriter.BaseStream.Position % 2) != 0)
			{
				outFileWriter.Write((byte)0);
			}

			// do file size comparison
			rd.Difference = (int)outFileWriter.BaseStream.Position - (end - start);
			if (rd.Difference > 0)
			{
				rd.ReturnCode = ReplaceFileReturnCode.NewFileBigger;
			}
			else if (rd.Difference < 0)
			{
				rd.ReturnCode = ReplaceFileReturnCode.NewFileSmaller;
			}
			else
			{
				rd.ReturnCode = ReplaceFileReturnCode.OK;
			}

			// update all FileTable entries after this one with the difference.
			for (int i = fte.FileID + 1; i < Entries.Count; i++)
			{
				if (rd.Difference < 0)
				{
					Entries[i].Location = (UInt32)(Entries[i].Location - Math.Abs(rd.Difference));
				}
				else
				{
					Entries[i].Location = (UInt32)(Entries[i].Location + rd.Difference);
				}
			}

			// todo: insert data into rom, handling differences as needed.

			// !! everything below this point needs to be re-thought. !!

			// determine filesize
			replaceFileReader.BaseStream.Seek(0, SeekOrigin.End);
			int replaceFileLen = (int)replaceFileReader.BaseStream.Position;
			replaceFileReader.BaseStream.Seek(0, SeekOrigin.Begin);
			byte[] replaceFileData = replaceFileReader.ReadBytes(replaceFileLen);
			replaceFileReader.Close();

			MemoryStream outDataStream = new MemoryStream();
			BinaryWriter outDataWriter = new BinaryWriter(outDataStream);

			// todo: handle replacement.
			// this depends on a number of variables...
			// - file extension
			// - FileTableEntry's FileType value
			// - FileTableEntry's IsEncoded value

			outDataWriter.Close();
			replaceFileReader.Close();

			return rd;
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
		/// Write filetable data using a BinaryWriter.
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
