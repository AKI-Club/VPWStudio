using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// Vertex format used in TMD models.
	/// </summary>
	public struct TmdVertex
	{
		#region Struct Members
		/// <summary>
		/// X position of this vertex.
		/// </summary>
		public Int16 X;

		/// <summary>
		/// Y position of this vertex.
		/// </summary>
		public Int16 Y;

		/// <summary>
		/// Z position of this vertex.
		/// </summary>
		public Int16 Z;

		/// <summary>
		/// Padding value, since the XYZ coords only take up three 16-bit integers.
		/// (Typically 0, but might not be?)
		/// </summary>
		public Int16 Pad;
		#endregion

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="_x">Vertex X position</param>
		/// <param name="_y">Vertex Y position</param>
		/// <param name="_z">Vertex Z position</param>
		public TmdVertex(Int16 _x, Int16 _y, Int16 _z)
		{
			X = _x;
			Y = _y;
			Z = _z;
			Pad = 0;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read TMD vertex data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] _x = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_x);
			}
			X = BitConverter.ToInt16(_x, 0);

			byte[] _y = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_y);
			}
			Y = BitConverter.ToInt16(_y, 0);

			byte[] _z = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_z);
			}
			Z = BitConverter.ToInt16(_z, 0);

			// should be 0 most of the time, but read it anyways
			byte[] _pad = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_pad);
			}
			Pad = BitConverter.ToInt16(_pad, 0);
		}

		/// <summary>
		/// Write TMD vertex data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] _x = BitConverter.GetBytes(X);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_x);
			}
			bw.Write(_x);

			byte[] _y = BitConverter.GetBytes(Y);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_y);
			}
			bw.Write(_y);

			byte[] _z = BitConverter.GetBytes(Z);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_z);
			}
			bw.Write(_z);

			byte[] _pad = BitConverter.GetBytes(Pad);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_pad);
			}
			bw.Write(_pad);
		}
		#endregion
	}

	/// <summary>
	/// Normal vector format used in TMD models.
	/// </summary>
	public struct TmdNormal
	{
		// Normals use fixed-point coordinates, which looks like this:
		// FEDCBA9876543210
		// ||_||__________|
		// | |       |
		// | |       +------- Decimal (12 bits)
		// | +--------------- Integral (3 bits)
		// +----------------- Sign (positive/negative)
		// A value of 4096 is meant to be +1.0

		#region Struct Members
		/// <summary>
		/// X value for this normal.
		/// </summary>
		public Int16 X;

		/// <summary>
		/// Y value for this normal.
		/// </summary>
		public Int16 Y;

		/// <summary>
		/// Z value for this normal.
		/// </summary>
		public Int16 Z;

		/// <summary>
		/// Padding value, since the XYZ coords only take up three 16-bit integers.
		/// (Typically 0, but might not be?)
		/// </summary>
		public Int16 Pad;
		#endregion

		public TmdNormal(Int16 _x, Int16 _y, Int16 _z)
		{
			X = _x;
			Y = _y;
			Z = _z;
			Pad = 0;
		}

		// todo: conversion to/from fixed point

		#region Binary Read/Write
		/// <summary>
		/// Read TMD normal data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] _x = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_x);
			}
			X = BitConverter.ToInt16(_x, 0);

			byte[] _y = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_y);
			}
			Y = BitConverter.ToInt16(_y, 0);

			byte[] _z = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_z);
			}
			Z = BitConverter.ToInt16(_z, 0);

			// padding should be 0, but read it just in case
			byte[] _pad = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_pad);
			}
			Pad = BitConverter.ToInt16(_pad, 0);
		}

		/// <summary>
		/// Write TMD normal data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] _x = BitConverter.GetBytes(X);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_x);
			}
			bw.Write(_x);

			byte[] _y = BitConverter.GetBytes(Y);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_y);
			}
			bw.Write(_y);

			byte[] _z = BitConverter.GetBytes(Z);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_z);
			}
			bw.Write(_z);

			byte[] _pad = BitConverter.GetBytes(Pad);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_pad);
			}
			bw.Write(_pad);
		}
		#endregion
	}

	public struct TmdPrimitive
	{
		/// <summary>
		/// Length of 2D drawing primitives created by GPU
		/// </summary>
		public byte OutLength;

		/// <summary>
		/// Length of packet section (in words)
		/// </summary>
		public byte InLength;

		/// <summary>
		/// Rendering flags
		/// </summary>
		/// 76543210
		/// 00000|||
		///      ||+-- Lighting/"LGT" (0=lighting performed, 1=lighting NOT performed)
		///      |+--- Face/"FCE" (0=single-sided polygon, 1=double-sided polygon)
		///      +---- Gradient/"GRD" (0=single-color, 1=gradient; only for untextured polys)
		public byte Flags;

		/// <summary>
		/// 
		/// </summary>
		/// 76543210
		/// |_||||||
		///  | ||||+--
		///  | |||+---
		///  | ||+----
		///  | |+-----
		///  | +------
		///  +-------- Code/Type (001=polygon, 010=straight line, 011=sprite; all others undefined?)
		public byte Mode;
	}

	/// <summary>
	/// TMD Object
	/// </summary>
	public class TmdObject
	{
		#region Base Class Members
		/// <summary>
		/// Starting location of vertex data for this object.
		/// (Dependent on the value of Flags in the TMD header.)
		/// </summary>
		public UInt32 VertexTop;

		/// <summary>
		/// Number of vertices in this object.
		/// </summary>
		public UInt32 NumVertices;

		/// <summary>
		/// Starting location of normal data for this object.
		/// (Dependent on the value of Flags in the TMD header.)
		/// </summary>
		public UInt32 NormalTop;

		/// <summary>
		/// Number of normals in this object.
		/// </summary>
		public UInt32 NumNormals;

		/// <summary>
		/// Starting location of primitive data for this object.
		/// (Dependent on the value of Flags in the TMD header.)
		/// </summary>
		public UInt32 PrimitiveTop;

		/// <summary>
		/// Number of primitives in this object.
		/// </summary>
		public UInt32 NumPrimitives;

		/// <summary>
		/// Base scale value for this object.
		/// To get the actual scale, raise this value to the second power.
		/// </summary>
		public Int32 Scale;
		#endregion

		/// <summary>
		/// Vertices in this TIM Object.
		/// </summary>
		public List<TmdVertex> Vertices;

		/// <summary>
		/// Normals in this TIM Object.
		/// </summary>
		public List<TmdNormal> Normals;

		//public List<TmdPrimitive> Primitives;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TmdObject()
		{
			VertexTop = 0;
			NumVertices = 0;
			NormalTop = 0;
			NumNormals = 0;
			PrimitiveTop = 0;
			NumPrimitives = 0;
			Scale = 0;

			Vertices = new List<TmdVertex>();
			Normals = new List<TmdNormal>();
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TmdObject(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read TMD object block data using a BinaryReader.
		/// Does not actually read in the data structures (vertices, normals, primitives)!!
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] _vertTop = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_vertTop);
			}
			VertexTop = BitConverter.ToUInt32(_vertTop, 0);

			byte[] _numVerts = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_numVerts);
			}
			NumVertices = BitConverter.ToUInt32(_numVerts, 0);

			byte[] _normalTop = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_normalTop);
			}
			NormalTop = BitConverter.ToUInt32(_normalTop, 0);

			byte[] _numNormals = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_numNormals);
			}
			NumNormals = BitConverter.ToUInt32(_numNormals, 0);

			byte[] _primTop = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_primTop);
			}
			PrimitiveTop = BitConverter.ToUInt32(_primTop, 0);

			byte[] _numPrims = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_numPrims);
			}
			NumPrimitives = BitConverter.ToUInt32(_numPrims, 0);
		}
		#endregion
	}

	/// <summary>
	/// TMD file, used for storing PlayStation models.
	/// </summary>
	public class TmdFile
	{
		#region Class Members
		/// <summary>
		/// Lowest bit determines if object addresses are "real" addresses (if bit is set/1) or offset from the start of the Object block (if bit is cleared/0)
		/// </summary>
		public UInt32 Flags;

		/// <summary>
		/// Number of objects in this TMD file.
		/// </summary>
		public UInt32 NumObjects;

		/// <summary>
		/// The actual TMD Objects
		/// </summary>
		public List<TmdObject> Objects;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor, not particularly useful.
		/// </summary>
		public TmdFile()
		{
			Flags = 0;
			NumObjects = 0;
			Objects = new List<TmdObject>();
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TmdFile(BinaryReader br)
		{
			Objects = new List<TmdObject>();
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			// offsets 0-3 need to be a specific value (0x41000000 in little endian/PS1 native)
			byte[] _ver = br.ReadBytes(4);
			if(!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_ver);
			}
			if (BitConverter.ToUInt32(_ver, 0) != 0x41)
			{
				return;
			}

			byte[] _flags = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_flags);
			}
			Flags = BitConverter.ToUInt32(_flags, 0);

			byte[] _numObj = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(_numObj);
			}
			NumObjects = BitConverter.ToUInt32(_numObj, 0);

			// parse object list
			long objBasePos = br.BaseStream.Position;

			for (int i = 0; i < NumObjects; i++)
			{
				TmdObject obj = new TmdObject(br);
				Objects.Add(obj);
			}

			// parse all objects
			// data locations depend on the value in Flags!
			// if Flags == 1, addresses are "real"
			// if Flags == 0, addresses are offset from the start of the object block (i.e. offset+objBasePos)

			foreach (TmdObject obj in Objects)
			{
				//obj.VertexTop
				for (int v = 0; v < obj.NumVertices; v++)
				{
				}

				//obj.NormalTop
				for (int n = 0; n < obj.NumNormals; n++)
				{
				}

				//obj.PrimitiveTop
				for (int p = 0; p < obj.NumPrimitives; p++)
				{
				}
			}
		}
		#endregion
	}
}
