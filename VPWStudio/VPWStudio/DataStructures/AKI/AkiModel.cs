using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace VPWStudio
{
	/*
	 * [excel.jpg]
	 * So here you can see that the UV values have been converted to decimal.
	 * To calculate the values needed for the .obj file, I divided the values
	 * under "U" by the highest value (which is equivalent to 1) in that
	 * column. I did the same for the values under "V".
	 */

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
		public byte U;
		
		/// <summary>
		/// Texture vertical offset
		/// </summary>
		public byte V;
		
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
			U = (byte)u;
			V = (byte)v;
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
			U = (byte)u;
			V = (byte)v;
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
			U = br.ReadByte();
			V = br.ReadByte();
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
			bw.Write(U);
			bw.Write(V);
			bw.Write(VertexColor.R);
			bw.Write(VertexColor.G);
			bw.Write(VertexColor.B);
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
		/// the top bit of this means U/V values are set in the vertex color data...
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
		/// Texture Size (multiplied by 8 in-game)
		/// </summary>
		/// stored as nibbles ("wwww hhhh" format)
		/// a value of 0x00 probably means "use binded texture size"
		public int TextureSize;

		private int TextureSizeX;
		private int TextureSizeY;

		/// <summary>
		/// Collection of Vertices in this polygon.
		/// </summary>
		public List<AkiVertex> Vertices;

		/// <summary>
		/// Collection of Faces in this polygon.
		/// </summary>
		public List<AkiFace> Faces;

		// top bit of NumVertices
		public byte ModelType;

		// top bit of NumFaces
		public byte UnknownFacesTopBit;

		private bool FromNoMercy = false;
		#endregion

		#region Constructors
		/// <summary>
		/// Default Constructor
		/// </summary>
		public AkiModel()
		{
			Scale = 1;
			NumVertices = 0;
			NumFaces = 0;
			UnknownValue = 0;
			OffsetX = 0;
			OffsetY = 0;
			OffsetZ = 0;
			TextureSize = 0;
			Vertices = new List<AkiVertex>();
			Faces = new List<AkiFace>();

			ModelType = 0;
			UnknownFacesTopBit = 0;
			TextureSizeX = 0;
			TextureSizeY = 0;
		}

		/// <summary>
		/// Constructor that allows setting the FromNoMercy value
		/// </summary>
		/// <param name="_noMercy">True if this model is from WWF No Mercy</param>
		public AkiModel(bool _noMercy) : base()
		{
			FromNoMercy = _noMercy;
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

		#region Utility Routines
		/// <summary>
		/// Convert the List of AkiFaces to an array of the actual indices.
		/// </summary>
		/// <returns>Array of integers with the indices for face mappings</returns>
		public int[] GetFacesList()
		{
			List<int> faces = new List<int>();
			foreach (AkiFace f in Faces)
			{
				faces.Add(f.Vertex1);
				faces.Add(f.Vertex2);
				faces.Add(f.Vertex3);
			}
			return faces.ToArray();
		}

		static float Map(float a1, float a2, float b1, float b2, float s) => b1 + (s - a1) * (b2 - b1) / (a2 - a1);

		/// <summary>
		/// Get a list of normalized vertices, as well as their UV and vertex color values.
		/// </summary>
		/// <returns>Array of floats</returns>
		public float[] GetNormalizedCoords()
		{
			List<float> result = new List<float>();

			// get min/max values
			int minValue = 0;
			int maxValue = 0;

			foreach (AkiVertex v in Vertices)
			{
				minValue = Math.Min(v.X, minValue);
				minValue = Math.Min(v.Y, minValue);
				minValue = Math.Min(v.Z, minValue);

				maxValue = Math.Max(v.X, maxValue);
				maxValue = Math.Max(v.Y, maxValue);
				maxValue = Math.Max(v.Z, maxValue);
			}

			// get actual verts
			foreach (AkiVertex v in Vertices)
			{
				// XYZ (the clamping to -0.5f/0.5f is intentional)
				result.Add(Map(minValue,maxValue, -0.5f,0.5f, v.X));
				result.Add(Map(minValue,maxValue, -0.5f,0.5f, v.Y));
				result.Add(Map(minValue,maxValue, -0.5f,0.5f, v.Z));

				// UV
				result.Add((float)v.U / TextureSizeX);
				result.Add((float)(TextureSizeY - v.V) / TextureSizeY);

				// Vertex color
				result.Add(v.VertexColor.R/255.0f);
				result.Add(v.VertexColor.G/255.0f);
				result.Add(v.VertexColor.B/255.0f);
			}

			return result.ToArray();
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br, bool isNoMercy = false)
		{
			FromNoMercy = isNoMercy;
			Scale = br.ReadByte();

			byte numVerts = br.ReadByte();
			NumVertices = numVerts & 0x7F;
			ModelType = (byte)(numVerts & 0x80);

			byte numFaces = br.ReadByte();
			NumFaces = numFaces & 0x7F;
			UnknownFacesTopBit = (byte)(numFaces & 0x80);

			UnknownValue = br.ReadByte();
			OffsetX = (SByte)br.ReadByte();
			OffsetY = (SByte)br.ReadByte();
			OffsetZ = (SByte)br.ReadByte();

			TextureSize = br.ReadByte();

			TextureSizeX = ((TextureSize & 0xF0)>>4) * 8;
			if (TextureSizeX == 0)
			{
				TextureSizeX = isNoMercy ? 64 : 128;
			}

			TextureSizeY = ((TextureSize & 0x0F)) * 8;
			if (TextureSizeY == 0)
			{
				TextureSizeY = isNoMercy ? 64 : 128;
			}

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
			bw.Write((byte)Vertices.Count | ModelType);
			bw.Write((byte)Faces.Count | UnknownFacesTopBit);
			bw.Write((byte)UnknownValue);
			bw.Write((byte)OffsetX);
			bw.Write((byte)OffsetY);
			bw.Write((byte)OffsetZ);
			bw.Write((byte)TextureSize);
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

			sw.WriteLine("# Wavefront OBJ file exported from VPW Studio");
			sw.WriteLine(string.Format("# Scale Value: {0}", Scale));
			sw.WriteLine(string.Format("# Model Type? (num verts top bit): 0x{0:X2}", ModelType));
			sw.WriteLine(string.Format("# unknown value 1 (num faces top bit): 0x{0:X2}", UnknownFacesTopBit));
			sw.WriteLine(string.Format("# unknown value 2: 0x{0:X2}", UnknownValue));
			sw.WriteLine(string.Format("# texture size: {0}x{1}", TextureSizeX, TextureSizeY));
			sw.WriteLine();

			sw.WriteLine(string.Format("# Vertices: {0}", Vertices.Count));
			// todo: X/Y/Z offset is shifted left and right on model load in-game
			// do we need to do that here?
			//int loadedOffsetX = (OffsetX << 0x18) >> 0x14;
			//int loadedOffsetY = (OffsetY << 0x18) >> 0x14;
			//int loadedOffsetZ = (OffsetZ << 0x18) >> 0x14;

			foreach (AkiVertex v in Vertices)
			{
				sw.WriteLine(string.Format("v {0} {1} {2}",
					(float)((v.X + OffsetX) * (Scale+1)),
					(float)((v.Y + OffsetY) * (Scale+1)),
					(float)((v.Z + OffsetZ) * (Scale+1))
					)
				);
			}
			sw.WriteLine();

			sw.WriteLine("# Texture/UV");

			// todo: there are still other issues with texture mapping, possibly related to the "unknown" values
			/*
			 * vpw2 file IDs and their unknown values
			 * 0941 - 0x97 (pelvis - fat body type)
			 * 0979 - 0x99 
			 * 097A - 0x33 (pelvis)
			 * 097E - 0x57 (left leg)
			 * 0985 - 0x57 (right leg)
			 * 
			 * no mercy file IDs and their unknown values
			 * 10F6 - 0x60 (skinny chest)
			 */

			// todo: figure out how the alternate UV style actually works
			// VPW2 (also VPW64 and Revenge; presumably World Tour and WM2K): number of vertices top bit?
			// No Mercy: related to the Unknown value, but not sure which bit(s) controls it

			if (/*ModelType != 0*/ false)
			{
				// use values from the vertex colors
				foreach (AkiVertex v in Vertices)
				{
					sw.WriteLine(string.Format("vt {0} {1}",
						(float)v.VertexColor.R / TextureSizeX,
						(float)(TextureSizeY - v.VertexColor.B) / TextureSizeY
						)
					);
				}
			}
			else
			{
				foreach (AkiVertex v in Vertices)
				{
					sw.WriteLine(string.Format("vt {0} {1}",
						(float)v.U / TextureSizeX,
						(float)(TextureSizeY - v.V) / TextureSizeY
						)
					);
				}
			}
			sw.WriteLine();

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
