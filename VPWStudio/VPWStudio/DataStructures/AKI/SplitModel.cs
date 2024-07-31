using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Windows.Forms.AxHost;

namespace VPWStudio
{
	/// <summary>
	/// Vertex found in split model data.
	/// </summary>
	public class SplitVertex
	{
		#region Class Members
		/// <summary>
		/// X position
		/// </summary>
		public short X;

		/// <summary>
		/// Y position
		/// </summary>
		public short Y;

		/// <summary>
		/// Z position
		/// </summary>
		public short Z;

		// 0x00,0x00 for padding

		public byte Unknown1;
		public byte Unknown2;
		public byte Unknown3;
		public byte Unknown4;

		/// <summary>
		/// Vertex color Red channel
		/// </summary>
		public byte ColorR;

		/// <summary>
		/// Vertex color Green channel
		/// </summary>
		public byte ColorG;

		/// <summary>
		/// Vertex color Blue channel
		/// </summary>
		public byte ColorB;

		/// <summary>
		/// May or may not be Vertex alpha value
		/// </summary>
		public byte ColorA;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SplitVertex()
		{
			X = 0;
			Y = 0;
			Z = 0;
			Unknown1 = 0;
			Unknown2 = 0;
			Unknown3 = 0;
			Unknown4 = 0;
			ColorR = 0;
			ColorG = 0;
			ColorB = 0;
			ColorA = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public SplitVertex(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Read/Write Data
		/// <summary>
		/// Read vertex data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] tmp = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			X = BitConverter.ToInt16(tmp, 0);

			tmp = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			Y = BitConverter.ToInt16(tmp, 0);
			//Y &= 0x00FF; // temporary kludge

			tmp = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			Z = BitConverter.ToInt16(tmp, 0);

			// skip two 0x00 values, presumably used as padding
			br.ReadBytes(2);

			Unknown1 = br.ReadByte();
			Unknown2 = br.ReadByte();
			Unknown3 = br.ReadByte();
			Unknown4 = br.ReadByte();

			ColorR = br.ReadByte();
			ColorG = br.ReadByte();
			ColorB = br.ReadByte();
			ColorA = br.ReadByte();
		}
		#endregion
	}

	/// <summary>
	/// Model data split over two files, as found in AkiArchive files.
	/// </summary>
	public class SplitModel
	{
		#region Constants
		/// <summary>
		/// Number of bytes that make up a split vertex.
		/// </summary>
		public readonly int SPLIT_VERTEX_SIZE = 16;

		/// <summary>
		/// Number of bytes that make up a split face.
		/// </summary>
		public readonly int SPLIT_FACE_SIZE = 4;
		#endregion

		#region Class Members
		/// <summary>
		/// Vertices in this model.
		/// </summary>
		public List<SplitVertex> Vertices;

		/// <summary>
		/// Face connections.
		/// </summary>
		public List<AkiFace> Faces;

		public string VertexPath;

		public string FacePath;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SplitModel()
		{
			Vertices = new List<SplitVertex>();
			Faces = new List<AkiFace>();
			VertexPath = string.Empty;
			FacePath = string.Empty;
		}

		/// <summary>
		/// Constructor using two files.
		/// </summary>
		/// <param name="_vtxFile">Path to vertex file.</param>
		/// <param name="_faceFile">Path to face file.</param>
		public SplitModel(string _vtxFile, string _faceFile)
		{
			Vertices = new List<SplitVertex>();
			Faces = new List<AkiFace>();
			VertexPath = _vtxFile;
			FacePath = _faceFile;
			ReadData(VertexPath, FacePath);
		}
		#endregion

		/// <summary>
		/// Read split model data from two files.
		/// </summary>
		/// <param name="_vtxFile">Path to vertex file.</param>
		/// <param name="_faceFile">Path to face file.</param>
		public void ReadData(string _vtxFile, string _faceFile)
		{
			if (VertexPath.Equals(string.Empty))
			{
				VertexPath = _vtxFile;
			}

			if (FacePath.Equals(string.Empty))
			{
				FacePath = _faceFile;
			}

			using (FileStream vtxFS = new FileStream(_vtxFile,FileMode.Open))
			{
				using (BinaryReader vtxBR = new BinaryReader(vtxFS))
				{
					// xxx: number of verts is actually defined elsewhere in ROM.
					// we just take advantage of the fact that all known vertices use a constant length.
					int numVerts = (int)(vtxFS.Length / SPLIT_VERTEX_SIZE);
					for (int i = 0; i < numVerts; i++)
					{
						Vertices.Add(new SplitVertex(vtxBR));
					}
				}
			}

			using (FileStream faceFS = new FileStream(_faceFile,FileMode.Open))
			{
				using (BinaryReader faceBR = new BinaryReader(faceFS))
				{
					// xxx: number of faces is actually defined elsewhere in ROM.
					// we just take advantage of the fact that all known faces use a constant length.
					int numFaces = (int)(faceFS.Length / SPLIT_FACE_SIZE);
					for (int i = 0; i < numFaces; i++)
					{
						Faces.Add(new AkiFace(faceBR));
						faceBR.ReadByte(); // dummy byte after every entry
					}
				}
			}
		}

		public void WriteWavefrontObj(StreamWriter sw)
		{
			sw.WriteLine("# Wavefront OBJ file exported from VPW Studio");
			sw.WriteLine(string.Format("# Vertex file: {0}", VertexPath));
			sw.WriteLine(string.Format("# Faces file: {0}", FacePath));
			sw.WriteLine();

			sw.WriteLine(string.Format("# Vertices: {0}", Vertices.Count));
			foreach (SplitVertex v in Vertices)
			{
				sw.WriteLine(string.Format("v {0} {1} {2}", v.X, v.Y, v.Z));
			}
			sw.WriteLine();

			// UV values are presumably part of the unknowns, but idk how the hell to handle them

			sw.WriteLine(string.Format("# Faces: {0}", Faces.Count));
			foreach (AkiFace f in Faces)
			{
				//sw.WriteLine(String.Format("f {0} {1} {2}", f.Vertex1+1, f.Vertex2+1, f.Vertex3+1));
				sw.WriteLine(string.Format("f {0}/{0} {1}/{1} {2}/{2}", f.Vertex1 + 1, f.Vertex2 + 1, f.Vertex3 + 1));
			}
			sw.WriteLine();
			sw.Flush();
		}
	}
}
