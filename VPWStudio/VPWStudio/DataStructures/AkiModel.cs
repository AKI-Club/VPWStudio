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

		/// <summary>
		/// Default Constructor
		/// </summary>
		public AkiVertex()
		{
			this.X = 0;
			this.Y = 0;
			this.Z = 0;
			this.U = 0;
			this.V = 0;
			this.VertexColor = Color.White;
		}

		/// <summary>
		/// XYZ Constructor
		/// </summary>
		/// <param name="x">X position</param>
		/// <param name="y">Y position</param>
		/// <param name="z">Z position</param>
		public AkiVertex(int x, int y, int z)
		{
			this.X = (SByte)x;
			this.Y = (SByte)y;
			this.Z = (SByte)z;
			this.U = (SByte)0;
			this.V = (SByte)0;
			this.VertexColor = Color.White;
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
			this.X = (SByte)x;
			this.Y = (SByte)y;
			this.Z = (SByte)z;
			this.U = (SByte)u;
			this.V = (SByte)v;
			this.VertexColor = Color.White;
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
			this.X = (SByte)x;
			this.Y = (SByte)y;
			this.Z = (SByte)z;
			this.U = (SByte)u;
			this.V = (SByte)v;
			this.VertexColor = c;
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AkiVertex(BinaryReader br)
		{
			this.X = (SByte)br.ReadByte();
			this.Y = (SByte)br.ReadByte();
			this.Z = (SByte)br.ReadByte();
			// todo: convert UV values (63,0,31) -> (-1.0, 0.0, 1.0)
			this.U = (SByte)br.ReadByte();
			this.V = (SByte)br.ReadByte();
			int red = br.ReadByte();
			int green = br.ReadByte();
			int blue = br.ReadByte();
			this.VertexColor = Color.FromArgb(1, red, green, blue);
		}

		/// <summary>
		/// Write data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteBytes(BinaryWriter bw)
		{
			bw.Write((byte)this.X);
			bw.Write((byte)this.Y);
			bw.Write((byte)this.Z);
			// todo: convert UV values (-1.0, 0.0, 1.0) -> (63,0,31)
			bw.Write((SByte)this.U);
			bw.Write((SByte)this.V);
			bw.Write((byte)this.VertexColor.R);
			bw.Write((byte)this.VertexColor.G);
			bw.Write((byte)this.VertexColor.B);
		}

		public float[] UVToFloat()
		{
			float[] values = new float[2];

			if (this.U > 31)
			{
				// negative
				values[0] = ((this.U - 32) / 31) * -1;
			}
			else
			{
				// positive
				values[0] = (this.U / 31);
			}

			if (this.V > 31)
			{
				// negative
				values[1] = ((this.V - 32) / 31) * -1;
			}
			else
			{
				// positive
				values[1] = (this.V / 31);
			}

			return values;
		}

		public void FloatToUV(float _u, float _v)
		{
			// todo.
		}
	}

	/// <summary>
	/// Face Data
	/// </summary>
	public class AkiFace
	{
		public int Vertex1;
		public int Vertex2;
		public int Vertex3;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public AkiFace()
		{
			this.Vertex1 = 0;
			this.Vertex2 = 0;
			this.Vertex3 = 0;
		}

		/// <summary>
		/// Specific Constructor
		/// </summary>
		/// <param name="v1">Vertex Index 1</param>
		/// <param name="v2">Vertex Index 2</param>
		/// <param name="v3">Vertex Index 3</param>
		public AkiFace(int v1, int v2, int v3)
		{
			this.Vertex1 = v1;
			this.Vertex2 = v2;
			this.Vertex3 = v3;
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AkiFace(BinaryReader br)
		{
			this.Vertex1 = br.ReadByte();
			this.Vertex2 = br.ReadByte();
			this.Vertex3 = br.ReadByte();
		}

		/// <summary>
		/// Write data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteBytes(BinaryWriter bw)
		{
			bw.Write((byte)this.Vertex1);
			bw.Write((byte)this.Vertex2);
			bw.Write((byte)this.Vertex3);
		}
	}

	/// <summary>
	/// 3D Model Data
	/// </summary>
	public class AkiModel
	{
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
			this.Scale = br.ReadByte();
			byte numVerts = br.ReadByte();
			this.NumVertices = numVerts & 0x7F;
			this.ModelType = (byte)(numVerts & 0x80);
			this.NumFaces = br.ReadByte() & 0x7F;
			this.UnknownValue = br.ReadByte();
			this.OffsetX = (SByte)br.ReadByte();
			this.OffsetY = (SByte)br.ReadByte();
			this.OffsetZ = (SByte)br.ReadByte();
			this.OffsetTexture = (SByte)br.ReadByte();

			this.Vertices = new List<AkiVertex>();
			for (int v = 0; v < this.NumVertices; v++)
			{
				this.Vertices.Add(new AkiVertex(br));
			}

			this.Faces = new List<AkiFace>();
			for (int f = 0; f < this.NumFaces; f++)
			{
				this.Faces.Add(new AkiFace(br));
			}
		}

		/// <summary>
		/// Write data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteBytes(BinaryWriter bw)
		{
			bw.Write((byte)this.Scale);
			bw.Write((byte)this.Vertices.Count);
			bw.Write((byte)this.Faces.Count);
			bw.Write((byte)UnknownValue);
			bw.Write((byte)this.OffsetX);
			bw.Write((byte)this.OffsetY);
			bw.Write((byte)this.OffsetZ);
			bw.Write((byte)this.OffsetTexture);
			foreach (AkiVertex v in this.Vertices)
			{
				v.WriteBytes(bw);
			}
			foreach (AkiFace f in this.Faces)
			{
				f.WriteBytes(bw);
			}
		}

		// wip shite
		public void WriteWavefrontObj(StreamWriter sw)
		{
			// todo: this does not apply texture map offset value
			// todo: obj format doesn't officially support vertex colors

			sw.WriteLine();
			sw.WriteLine(String.Format("# Scale Value: {0}", this.Scale));
			sw.WriteLine();

			sw.WriteLine(String.Format("# Vertices: {0}", this.Vertices.Count));
			foreach (AkiVertex v in this.Vertices)
			{
				sw.WriteLine(String.Format("v {0} {1} {2}",
					(float)((v.X + this.OffsetX) * (this.Scale+1)),
					(float)((v.Y + this.OffsetY) * (this.Scale+1)),
					(float)((v.Z + this.OffsetZ) * (this.Scale+1))
					)
				);
			}
			sw.WriteLine();

			sw.WriteLine("# Texture/UV");
			foreach (AkiVertex v in this.Vertices)
			{
				float[] fUV = v.UVToFloat();

				sw.WriteLine(String.Format("vt {0} {1}",
					fUV[0],
					fUV[1]
					)
				);
			}
			sw.WriteLine();

			sw.WriteLine(String.Format("# Faces: {0}", this.Faces.Count));
			foreach (AkiFace f in this.Faces)
			{
				//sw.WriteLine(String.Format("f {0} {1} {2}", f.Vertex1+1, f.Vertex2+1, f.Vertex3+1));
				sw.WriteLine(String.Format("f {0}/{0} {1}/{1} {2}/{2}", f.Vertex1 + 1, f.Vertex2 + 1, f.Vertex3 + 1));
			}
			sw.WriteLine();
			sw.Flush();
		}
	}
}
