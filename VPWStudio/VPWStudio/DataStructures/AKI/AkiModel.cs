using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace VPWStudio
{
	// quick note on UV values:
	// 0 = 0.0
	// 31 = 1.0
	// 32 = (closest negative value to 0)
	// 63 = -1.0
	// scale accordingly, I suppose.

	// if UV > 31 then UV = (UV - 32) * -1;

	/// <summary>
	/// Vertex Data
	/// </summary>
	public class AkiVertex
	{
		#region Members
		/// <summary>
		/// X position
		/// </summary>
		public SByte X;
		/// <summary>
		/// Y position
		/// </summary>
		public SByte Y;
		/// <summary>
		/// Z position
		/// </summary>
		public SByte Z;
		/// <summary>
		/// Texture horizontal offset
		/// </summary>
		public SByte U;
		/// <summary>
		/// Texture vertical offset
		/// </summary>
		public SByte V;
		/// <summary>
		/// Vertex color
		/// </summary>
		public Color VertexColor;
		#endregion

		#region Constructors
		/// <summary>
		/// Default Constructor
		/// </summary>
		public AkiVertex()
		{
			X = 0;
			Y = 0;
			Z = 0;
			U = 0;
			V = 0;
			VertexColor = Color.White;
		}

		/// <summary>
		/// XYZ Constructor
		/// </summary>
		/// <param name="x">X position</param>
		/// <param name="y">Y position</param>
		/// <param name="z">Z position</param>
		public AkiVertex(int x, int y, int z)
		{
			X = (SByte)x;
			Y = (SByte)y;
			Z = (SByte)z;
			U = 0;
			V = 0;
			VertexColor = Color.White;
		}

		/// <summary>
		/// XYZUV Constructor
		/// </summary>
		/// <param name="x">X position</param>
		/// <param name="y">Y position</param>
		/// <param name="z">Z position</param>
		/// <param name="u">Texture Map Horizontal offset</param>
		/// <param name="v">Texture Map Vertical offset</param>
		public AkiVertex(int x, int y, int z, int u, int v)
		{
			X = (SByte)x;
			Y = (SByte)y;
			Z = (SByte)z;
			U = (SByte)u;
			V = (SByte)v;
			VertexColor = Color.White;
		}

		/// <summary>
		/// XYZUVC Constructor
		/// </summary>
		/// <param name="x">X position</param>
		/// <param name="y">Y position</param>
		/// <param name="z">Z position</param>
		/// <param name="u">Texture Map Horizontal offset</param>
		/// <param name="v">Texture Map Vertical offset</param>
		/// <param name="c">Vertex color</param>
		public AkiVertex(int x, int y, int z, int u, int v, Color c)
		{
			X = (SByte)x;
			Y = (SByte)y;
			Z = (SByte)z;
			U = (SByte)u;
			V = (SByte)v;
			VertexColor = c;
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AkiVertex(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			X = (SByte)br.ReadByte();
			Y = (SByte)br.ReadByte();
			Z = (SByte)br.ReadByte();
			// todo: convert UV values (63,0,31) -> (-1.0, 0.0, 1.0)
			U = (SByte)br.ReadByte();
			V = (SByte)br.ReadByte();
			int red = br.ReadByte();
			int green = br.ReadByte();
			int blue = br.ReadByte();
			VertexColor = Color.FromArgb(1, red, green, blue);
		}

		/// <summary>
		/// Write data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write((byte)X);
			bw.Write((byte)Y);
			bw.Write((byte)Z);
			// todo: convert UV values (-1.0, 0.0, 1.0) -> (63,0,31)
			bw.Write((SByte)U);
			bw.Write((SByte)V);
			bw.Write(VertexColor.R);
			bw.Write(VertexColor.G);
			bw.Write(VertexColor.B);
		}
		#endregion

		#region Helpers
		public float[] UVToFloat()
		{
			float[] values = new float[2];

			if (U > 31)
			{
				// negative
				values[0] = ((U - 32) / 31) * -1;
			}
			else
			{
				// positive
				values[0] = (U / 31);
			}

			if (V > 31)
			{
				// negative
				values[1] = ((V - 32) / 31) * -1;
			}
			else
			{
				// positive
				values[1] = (V / 31);
			}

			return values;
		}

		public void FloatToUV(float _u, float _v)
		{
			// todo.
		}
		#endregion
	}

	/// <summary>
	/// Face Data
	/// </summary>
	public class AkiFace
	{
		#region Members
		public int Vertex1;
		public int Vertex2;
		public int Vertex3;
		#endregion

		#region Constructors
		/// <summary>
		/// Default Constructor
		/// </summary>
		public AkiFace()
		{
			Vertex1 = 0;
			Vertex2 = 0;
			Vertex3 = 0;
		}

		/// <summary>
		/// Specific Constructor
		/// </summary>
		/// <param name="v1">Vertex Index 1</param>
		/// <param name="v2">Vertex Index 2</param>
		/// <param name="v3">Vertex Index 3</param>
		public AkiFace(int v1, int v2, int v3)
		{
			Vertex1 = v1;
			Vertex2 = v2;
			Vertex3 = v3;
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AkiFace(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			Vertex1 = br.ReadByte();
			Vertex2 = br.ReadByte();
			Vertex3 = br.ReadByte();
		}

		/// <summary>
		/// Write data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write((byte)Vertex1);
			bw.Write((byte)Vertex2);
			bw.Write((byte)Vertex3);
		}
		#endregion
	}

	/// <summary>
	/// 3D Model Data
	/// </summary>
	public class AkiModel
	{
		#region Members
		/// <summary>
		/// Scale value
		/// </summary>
		/// todo: the top bit of this means something, but not sure what.
		public int Scale;

		/// <summary>
		/// Number of vertices in this model.
		/// </summary>
		/// The top bit of this possibly determines model type:
		/// 0x00 - normal model
		/// 0x80 - body part model?
		public int NumVertices;

		/// <summary>
		/// Number of faces in this model.
		/// </summary>
		public int NumFaces;

		/// <summary>
		/// Currently unknown purpose.
		/// </summary>
		/// Most models seem to have 0x00 here. Some don't.
		public int UnknownValue;

		/// <summary>
		/// X location offset
		/// </summary>
		public int OffsetX;
		/// <summary>
		/// Y location offset
		/// </summary>
		public int OffsetY;
		/// <summary>
		/// Z location offset
		/// </summary>
		public int OffsetZ;
		/// <summary>
		/// Texture Map location offset
		/// </summary>
		/// possibly stored as nibbles (perhaps "uuuu vvvv" format?)
		public int OffsetTexture;

		/// <summary>
		/// Collection of Vertices in this polygon.
		/// </summary>
		public List<AkiVertex> Vertices;

		/// <summary>
		/// Collection of Faces in this polygon.
		/// </summary>
		public List<AkiFace> Faces;

		public byte ModelType;
		#endregion

		#region Constructors
		/// <summary>
		/// Default Constructor
		/// </summary>
		public AkiModel()
		{
			this.Scale = 1;
			this.NumVertices = 0;
			this.NumFaces = 0;
			this.UnknownValue = 0;
			this.OffsetX = 0;
			this.OffsetY = 0;
			this.OffsetZ = 0;
			this.OffsetTexture = 0;
			this.Vertices = new List<AkiVertex>();
			this.Faces = new List<AkiFace>();

			this.ModelType = 0;
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AkiModel(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			Scale = br.ReadByte();
			byte numVerts = br.ReadByte();
			NumVertices = numVerts & 0x7F;
			ModelType = (byte)(numVerts & 0x80);
			NumFaces = br.ReadByte() & 0x7F;
			UnknownValue = br.ReadByte();
			OffsetX = (SByte)br.ReadByte();
			OffsetY = (SByte)br.ReadByte();
			OffsetZ = (SByte)br.ReadByte();
			OffsetTexture = br.ReadByte();

			Vertices = new List<AkiVertex>();
			for (int v = 0; v < this.NumVertices; v++)
			{
				Vertices.Add(new AkiVertex(br));
			}

			Faces = new List<AkiFace>();
			for (int f = 0; f < NumFaces; f++)
			{
				Faces.Add(new AkiFace(br));
			}
		}

		/// <summary>
		/// Write data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write((byte)Scale);
			bw.Write((byte)Vertices.Count);
			bw.Write((byte)Faces.Count);
			bw.Write((byte)UnknownValue);
			bw.Write((byte)OffsetX);
			bw.Write((byte)OffsetY);
			bw.Write((byte)OffsetZ);
			bw.Write((byte)OffsetTexture);
			foreach (AkiVertex v in Vertices)
			{
				v.WriteData(bw);
			}
			foreach (AkiFace f in Faces)
			{
				f.WriteData(bw);
			}
		}
		#endregion

		// wip shite
		public void WriteWavefrontObj(StreamWriter sw)
		{
			// todo: this does not apply texture map offset value
			// todo: obj format doesn't officially support vertex colors

			sw.WriteLine();
			sw.WriteLine(String.Format("# Scale Value: {0}", Scale));
			sw.WriteLine();

			sw.WriteLine(String.Format("# Vertices: {0}", Vertices.Count));
			foreach (AkiVertex v in Vertices)
			{
				sw.WriteLine(String.Format("v {0} {1} {2}",
					(float)((v.X + OffsetX) * (Scale+1)),
					(float)((v.Y + OffsetY) * (Scale+1)),
					(float)((v.Z + OffsetZ) * (Scale+1))
					)
				);
			}
			sw.WriteLine();

			sw.WriteLine("# Texture/UV");
			foreach (AkiVertex v in Vertices)
			{
				float[] fUV = v.UVToFloat();

				sw.WriteLine(String.Format("vt {0} {1}",
					fUV[0],
					fUV[1]
					)
				);
			}
			sw.WriteLine();

			sw.WriteLine(String.Format("# Faces: {0}", Faces.Count));
			foreach (AkiFace f in Faces)
			{
				//sw.WriteLine(String.Format("f {0} {1} {2}", f.Vertex1+1, f.Vertex2+1, f.Vertex3+1));
				sw.WriteLine(String.Format("f {0}/{0} {1}/{1} {2}/{2}", f.Vertex1 + 1, f.Vertex2 + 1, f.Vertex3 + 1));
			}
			sw.WriteLine();
			sw.Flush();
		}
	}
}
