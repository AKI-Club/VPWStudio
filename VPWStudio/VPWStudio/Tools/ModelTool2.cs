using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL;

namespace VPWStudio
{
	/// <summary>
	/// ModelTool2, an attempt to test SharpDX
	/// </summary>
	public partial class ModelTool2 : Form
	{
		private AkiModel CurModel = new AkiModel();

		private int FileID;

		private bool ValidGL = false;

		// todo: 3d stuff

		public ModelTool2(int fileID)
		{ 
			InitializeComponent();
			FileID = fileID;

			LoadModel(FileID);

			// do the simple shit first
			tbFileID.Text = String.Format("{0:X4}", fileID);
			tbModelScale.Text = String.Format("{0} (0x{0:X2})", CurModel.Scale);
			tbNumVerts.Text = String.Format("{0} (0x{0:X2})", CurModel.NumVertices);
			tbNumVertsTopBit.Text = String.Format("{0}", CurModel.ModelType >> 7);
			tbNumFaces.Text = String.Format("{0} (0x{0:X2})", CurModel.NumFaces);
			tbNumFacesTopBit.Text = String.Format("{0}", CurModel.UnknownFacesTopBit >> 7);
			tbUnknown.Text = String.Format("{0} (0x{0:X2})", CurModel.UnknownValue);
			tbOffsetX.Text = String.Format("{0} (0x{0:X2})", (sbyte)CurModel.OffsetX);
			tbOffsetY.Text = String.Format("{0} (0x{0:X2})", (sbyte)CurModel.OffsetY);
			tbOffsetZ.Text = String.Format("{0} (0x{0:X2})", (sbyte)CurModel.OffsetZ);

			int texSizeH = ((CurModel.TextureSize & 0xF0) >> 4) * 8;
			int texSizeV = ((CurModel.TextureSize & 0x0F)) * 8;
			if (texSizeH == 0)
			{
				texSizeH = Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy ? 64 : 128;
			}
			if (texSizeV == 0)
			{
				texSizeV = Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy ? 64 : 128;
			}
			tbTextureSize.Text = String.Format("{1}x{2} (0x{0:X2})", (byte)CurModel.TextureSize, texSizeH, texSizeV);

			// then do the hard shit (preferably in its own function)
		}

		/// <summary>
		/// Load model data from ROM.
		/// </summary>
		/// <param name="fileID">File ID of model data to load.</param>
		private void LoadModel(int fileID)
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream modelStream = new MemoryStream();
			BinaryWriter modelWriter = new BinaryWriter(modelStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, modelWriter, fileID);
			romReader.Close();
			modelStream.Seek(0, SeekOrigin.Begin);
			BinaryReader modelReader = new BinaryReader(modelStream);
			CurModel.ReadData(modelReader, Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy);
			modelReader.Close();
		}

		private void buttonExportWavefrontOBJ_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Wavefront OBJ";
			sfd.Filter = "Wavefront OBJ File (*.obj)|*.obj";
			sfd.FileName = String.Format("{0:X4}", FileID);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter sw = new StreamWriter(sfd.FileName))
				{
					CurModel.WriteWavefrontObj(sw);
					sw.Flush();
				}
			}
		}

		private void glControl1_Load(object sender, EventArgs e)
		{
			glControl1.MakeCurrent();
			GL.ClearColor(Color.CornflowerBlue);
			ValidGL = true;
		}

		private void glControl1_Resize(object sender, EventArgs e)
		{
			GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
			glControl1.Invalidate();
		}

		private void glControl1_Paint(object sender, PaintEventArgs e)
		{
			if (!ValidGL)
			{
				return;
			}

			GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
			GL.Clear(ClearBufferMask.ColorBufferBit);

			// draw!

			GL.Flush();
			glControl1.SwapBuffers();
		}

		/// <summary>
		/// Render the model to the preview image.
		/// </summary>
		private void RenderModel()
		{
		}
	}
}
