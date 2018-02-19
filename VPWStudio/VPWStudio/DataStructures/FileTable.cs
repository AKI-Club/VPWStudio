using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio
{
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

		/// <summary>
		/// Is this file encoded?
		/// </summary>
		public bool IsEncoded;

		/// <summary>
		/// Comment about this file entry.
		/// </summary>
		public string Comment;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FileTableEntry()
		{
			this.FileID = 0;
			this.Location = 0;
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

		public void DeepCopy(FileTableEntry _src)
		{
			this.FileID = _src.FileID;
			this.Location = _src.Location;
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

		// Format: <Entry id={id} loc={loc}>{comment}</Entry>

		/// <summary>
		/// 
		/// </summary>
		/// <param name="xr"></param>
		public void ReadXml(XmlReader xr)
		{
			//xr.ReadToFollowing("Entry");
			if (!xr.IsEmptyElement)
			{
				this.Comment = xr.Value;
			}
			else
			{
				this.Comment = String.Empty;
			}

			if (xr.HasAttributes)
			{
				this.FileID = UInt16.Parse(xr.GetAttribute("id"), NumberStyles.HexNumber);
				this.Location = UInt32.Parse(xr.GetAttribute("loc"), NumberStyles.HexNumber);
				this.IsEncoded = bool.Parse(xr.GetAttribute("lzss"));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="xw"></param>
		public void WriteXml(XmlWriter xw)
		{
			xw.WriteStartElement("Entry");
			xw.WriteAttributeString("id", String.Format("{0:X4}", this.FileID));
			xw.WriteAttributeString("loc", String.Format("{0:X8}", this.Location));
			xw.WriteAttributeString("lzss", this.IsEncoded.ToString());
			xw.WriteString(this.Comment);
			xw.WriteEndElement();
		}
		#endregion
	}

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
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public FileTable()
		{
			this.Entries = new SortedList<int, FileTableEntry>();
		}
		#endregion

		/// <summary>
		/// Deep copy an existing FileTable instance.
		/// </summary>
		/// <param name="_src">FileTable instance to copy.</param>
		public void DeepCopy(FileTable _src)
		{
			this.Entries.Clear();
			foreach (KeyValuePair<int, FileTableEntry> fte in _src.Entries)
			{
				this.Entries.Add(fte.Key, fte.Value);
			}
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

			// entries
			for (int i = 1; i < this.Entries.Count; i++)
			{
				this.Entries[i].WriteXml(xw);
			}

			// end tag
			xw.WriteEndElement();
		}
		#endregion
	}
}
