using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// WCW/nWo Revenge Stable Definition
	/// </summary>
	public class StableDefinition
	{
		#region Class Members
		/// <summary>
		/// Pointer to Wrestler Definitions for this Stable.
		/// </summary>
		public UInt32 WrestlerPointerStart;

		/// <summary>
		/// Number of wrestlers in this Stable.
		/// </summary>
		public UInt16 NumWrestlers;

		/// <summary>
		/// Header graphic used for this Stable.
		/// </summary>
		public UInt16 HeaderGraphicFile;
		#endregion

		#region Program-Specific
		/// <summary>
		/// Pointers to wrestler definitions used in this Stable.
		/// </summary>
		public UInt32[] WrestlerPointers;
		#endregion

		/// <summary>
		/// Generic constructor.
		/// </summary>
		public StableDefinition()
		{
			this.WrestlerPointerStart = 0;
			this.NumWrestlers = 0;
			this.HeaderGraphicFile = 0;
			this.WrestlerPointers = null;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_wresPtr">Pointer to wrestlers</param>
		/// <param name="_numWres">Number of wrestlers</param>
		/// <param name="_headGraphic">Header graphic file index</param>
		public StableDefinition(UInt32 _wresPtr, UInt16 _numWres, UInt16 _headGraphic)
		{
			this.WrestlerPointerStart = _wresPtr;
			this.NumWrestlers = _numWres;
			this.HeaderGraphicFile = _headGraphic;
			this.WrestlerPointers = null;
		}

		/// <summary>
		/// Constructor using BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StableDefinition(BinaryReader br)
		{
			this.ReadData(br);
		}

		/// <summary>
		/// Deep copy an existing StableDefinition.
		/// </summary>
		/// <param name="_src">StableDefinition to copy from.</param>
		public void DeepCopy(StableDefinition _src)
		{
			this.WrestlerPointerStart = _src.WrestlerPointerStart;
			this.NumWrestlers = _src.NumWrestlers;
			this.HeaderGraphicFile = _src.HeaderGraphicFile;

			// hm, not sure if this is the best of ideas.
			if (_src.WrestlerPointers != null)
			{
				Array.Copy(_src.WrestlerPointers, this.WrestlerPointers, this.NumWrestlers);
			}
		}

		#region Read/Write Binary
		/// <summary>
		/// Read StableDefinition data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] wptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wptr);
			}
			this.WrestlerPointerStart = BitConverter.ToUInt32(wptr, 0);

			byte[] numw = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numw);
			}
			this.NumWrestlers = BitConverter.ToUInt16(numw, 0);
			this.WrestlerPointers = new UInt32[this.NumWrestlers];

			byte[] head = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(head);
			}
			this.HeaderGraphicFile = BitConverter.ToUInt16(head, 0);

			// get wrestler pointers
			long curLoc = br.BaseStream.Position;
			this.PopulateWrestlerPointers(br);
			br.BaseStream.Seek(curLoc, SeekOrigin.Begin);
		}

		/// <summary>
		/// Write StableDefinition data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		/// <param name="updatePointers">Update Wrestler pointers. Assumes BinaryWriter is pointing to an output ROM stream.</param>
		public void WriteData(BinaryWriter bw, bool updatePointers = false)
		{
			byte[] wresStart = BitConverter.GetBytes(this.WrestlerPointerStart);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wresStart);
			}
			bw.Write(wresStart);

			// should this be WrestlerPointers.Count instead?
			byte[] numWres = BitConverter.GetBytes(this.NumWrestlers);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numWres);
			}
			bw.Write(numWres);

			byte[] headerFile = BitConverter.GetBytes(this.HeaderGraphicFile);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(headerFile);
			}
			bw.Write(headerFile);

			if (updatePointers == true)
			{
				// write this.WrestlerPointers at this.WrestlerPointerStart
				long curLoc = bw.BaseStream.Position;
				bw.BaseStream.Seek(Z64Rom.PointerToRom(this.WrestlerPointerStart), SeekOrigin.Begin);
				for (int i = 0; i < this.NumWrestlers; i++)
				{
					byte[] wptr = BitConverter.GetBytes(this.WrestlerPointers[i]);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(wptr);
					}
					bw.Write(wptr);
				}
				bw.BaseStream.Seek(curLoc, SeekOrigin.Begin);
			}
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Populate the list of Wrestler pointers.
		/// </summary>
		/// <param name="br">BinaryReader instance with the Input ROM loaded.</param>
		public void PopulateWrestlerPointers(BinaryReader br)
		{
			if (this.WrestlerPointers == null)
			{
				this.WrestlerPointers = new UInt32[this.NumWrestlers];
			}

			br.BaseStream.Seek(Z64Rom.PointerToRom(this.WrestlerPointerStart), SeekOrigin.Begin);
			for (int i = 0; i < this.NumWrestlers; i++)
			{
				byte[] ptr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptr);
				}
				this.WrestlerPointers[i] = BitConverter.ToUInt32(ptr, 0);
			}
		}
		#endregion
	}
}
