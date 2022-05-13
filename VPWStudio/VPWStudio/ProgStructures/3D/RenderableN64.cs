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
		public Vector3 Position = new Vector3(0, 0, -1);
		public Vector3 Rotation = Vector3.Zero;
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

		#region Internal Stuff
		public AkiModel Model;

		// todo: only supports ci4 right now
		public Ci4Palette Palette_CI4;
		public Ci4Texture Texture_CI4;

		public Bitmap Texture;

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
		/// Constructor with file IDs
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

			// load palette and texture
			Palette_CI4 = new Ci4Palette();
			Texture_CI4 = new Ci4Texture();

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

			romReader.Close();

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
