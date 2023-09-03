using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace VPWStudio
{
	// todo: should split out some of the common stuff into an interface called IRenderable or something
	public class RenderableN64
	{
		/// <summary>
		/// Object position
		/// </summary>
		public Vector3 Position = new Vector3(0, 0, -1);

		/// <summary>
		/// Object rotation
		/// </summary>
		public Vector3 Rotation = Vector3.Zero;

		/// <summary>
		/// Object scale
		/// </summary>
		public Vector3 Scale = Vector3.One;

		public Matrix4 ModelMatrix = Matrix4.Identity;
		public Matrix4 ViewProjectionMatrix = Matrix4.Identity;
		public Matrix4 ModelViewProjectionMatrix = Matrix4.Identity;

		/// <summary>
		/// Name of this object.
		/// </summary>
		public string Name;

		/// <summary>
		/// Is this object visible in the preview?
		/// </summary>
		public bool Visible;

		/// <summary>
		/// Texture enable/disable flag
		/// </summary>
		public bool EnableTexture;

		#region File IDs
		/// <summary>
		/// Model data File ID
		/// </summary>
		public uint ModelFileID;

		/// <summary>
		/// (CI4) Palette data File ID
		/// </summary>
		public uint PalFileID;

		/// <summary>
		/// (CI4) Texture data File ID
		/// </summary>
		public uint TexFileID;
		#endregion

		#region Internal Stuff
		/// <summary>
		/// N64 mesh
		/// </summary>
		public AkiModel Model;

		public Ci4Palette Palette_CI4;
		public Ci4Texture Texture_CI4;
		public Ci8Palette Palette_CI8;
		public Ci8Texture Texture_CI8;

		/// <summary>
		/// Texture bitmap data
		/// </summary>
		public Bitmap Texture;

		/// <summary>
		/// Texture pixel data for OpenGL texture binding.
		/// </summary>
		public byte[] PixelData;
		#endregion

		#region Constructors
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RenderableN64()
		{
			Name = String.Empty;
			Visible = true;
			EnableTexture = true;
			ModelFileID = 0;
			PalFileID = 0;
			TexFileID = 0;
			Model = new AkiModel();
		}

		/// <summary>
		/// Constructor with file IDs.
		/// </summary>
		/// <param name="modelID">Model File ID</param>
		/// <param name="palID">Palette File ID</param>
		/// <param name="texID">Texture File ID</param>
		public RenderableN64(uint modelID, uint palID, uint texID)
		{
			Name = String.Empty;
			Visible = true;
			EnableTexture = true;

			ModelFileID = modelID;
			PalFileID = palID;
			TexFileID = texID;

			LoadData();
		}
		#endregion

		/// <summary>
		/// Reset Position, Rotation, and Scale to the default values.
		/// </summary>
		public void ResetPosRotScale()
		{
			Position = new Vector3(0, 0, -1);
			Rotation = Vector3.Zero;
			Scale = Vector3.One;
		}

		public void LoadData()
		{
			// don't bother if we don't have the data
			if (ModelFileID == 0 || PalFileID == 0 || TexFileID == 0)
			{
				return;
			}

			// load model
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream modelStream = new MemoryStream();
			BinaryWriter modelWriter = new BinaryWriter(modelStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, modelWriter, (int)ModelFileID);
			modelStream.Seek(0, SeekOrigin.Begin);
			BinaryReader modelReader = new BinaryReader(modelStream);
			Model = new AkiModel();
			Model.ReadData(modelReader, Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy);
			modelReader.Close();
			modelWriter.Close();

			// todo: determine palette and texture types separately, since VPW64 has some weird shit where it uses a CI4 palette with a CI8 texture
			if (Program.CurrentProject.ProjectFileTable.Entries[(int)PalFileID].FileType == FileTypes.Ci4Palette)
			{
				LoadTexPalCI4(romReader);
			}
			else if (Program.CurrentProject.ProjectFileTable.Entries[(int)PalFileID].FileType == FileTypes.Ci8Palette)
			{
				LoadTexPalCI8(romReader);
			}
			romReader.Close();
		}

		/// <summary>
		/// Load CI4 texture and palette data.
		/// </summary>
		/// <param name="romReader">BinaryReader instance to use.</param>
		public void LoadTexPalCI4(BinaryReader romReader)
		{
			// load palette and texture
			MemoryStream imgStream = new MemoryStream();
			BinaryWriter imgWriter = new BinaryWriter(imgStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, (int)TexFileID);
			imgStream.Seek(0, SeekOrigin.Begin);
			BinaryReader texfr = new BinaryReader(imgStream);
			Texture_CI4 = new Ci4Texture();
			Texture_CI4.ReadData(texfr);
			texfr.Close();

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, (int)PalFileID);
			palStream.Seek(0, SeekOrigin.Begin);
			BinaryReader palfr = new BinaryReader(palStream);
			Palette_CI4 = new Ci4Palette(palfr);
			palfr.Close();

			// convert to ye olde bitmappe
			Texture = new Bitmap(Texture_CI4.Width, Texture_CI4.Height, System.Drawing.Imaging.PixelFormat.Format4bppIndexed);
			Texture = Texture_CI4.ToBitmap(Palette_CI4);

			// and get bytes for GL texturing
			BitmapData textureData = Texture.LockBits(new Rectangle(0, 0, Texture.Width, Texture.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			IntPtr imageDataPtr = textureData.Scan0;
			int numBytes = Math.Abs(textureData.Stride) * Texture.Height;
			PixelData = new byte[numBytes];
			Marshal.Copy(imageDataPtr, PixelData, 0, numBytes);
			Texture.UnlockBits(textureData);
		}

		/// <summary>
		/// Load CI8 texture and palette data.
		/// </summary>
		/// <param name="romReader">BinaryReader instance to use.</param>
		public void LoadTexPalCI8(BinaryReader romReader)
		{
			// load palette and texture
			MemoryStream imgStream = new MemoryStream();
			BinaryWriter imgWriter = new BinaryWriter(imgStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, (int)TexFileID);
			imgStream.Seek(0, SeekOrigin.Begin);
			BinaryReader texfr = new BinaryReader(imgStream);
			Texture_CI8 = new Ci8Texture();
			Texture_CI8.ReadData(texfr);
			texfr.Close();

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, (int)PalFileID);
			palStream.Seek(0, SeekOrigin.Begin);
			BinaryReader palfr = new BinaryReader(palStream);
			Palette_CI8 = new Ci8Palette(palfr);
			palfr.Close();

			// convert to ye olde bitmappe
			Texture = new Bitmap(Texture_CI8.Width, Texture_CI8.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
			Texture = Texture_CI8.ToBitmap(Palette_CI8);

			// and get bytes for GL texturing
			BitmapData textureData = Texture.LockBits(new Rectangle(0, 0, Texture.Width, Texture.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			IntPtr imageDataPtr = textureData.Scan0;
			int numBytes = Math.Abs(textureData.Stride) * Texture.Height;
			PixelData = new byte[numBytes];
			Marshal.Copy(imageDataPtr, PixelData, 0, numBytes);
			Texture.UnlockBits(textureData);
		}

		/// <summary>
		/// Calculate Model Matrix from Position/Rotation/Scale vectors.
		/// </summary>
		public void CalculateModelMatrix()
		{
			ModelMatrix = Matrix4.CreateScale(Scale) * Matrix4.CreateRotationX(Rotation.X)
				* Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z)
				* Matrix4.CreateTranslation(Position);
		}
	}
}
