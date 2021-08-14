using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL;

namespace VPWStudio
{
	/// <summary>
	/// ModelTool2, an attempt to test OpenTK
	/// </summary>
	public partial class ModelTool2 : Form
	{
		private Timer RedrawTimer = new Timer();

		private AkiModel CurModel = new AkiModel();

		private int FileID;

		/// <summary>
		/// Determine if the GL context is valid. True if we can issue GL commands.
		/// </summary>
		private bool ValidGL = false;

		// shaders stuff
		public int VertexShader;
		public int FragmentShader;
		public int ShaderProgram;

		// VBO, VAO
		public int VertexBufferObject;
		public int VertexArrayObject;

		// Element Buffer Object (read: list of vertices that define faces)
		public int ElementBufferObject;

		// gl texture unit
		//public int TextureObject;

		/// <summary>
		/// Model coordinate values, converted to Normalized Device Coordinates.
		/// Also stores some other information, because shaders.
		/// </summary>
		private float[] ModelCoords;

		/// <summary>
		/// Yes I could just use CurModel.GetFacesList, but we need to have this info in multiple places
		/// </summary>
		private int[] ModelFaces;

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

			RedrawTimer.Interval = 16; // just about 1/60th of a second; can't use floating point values, so I had to round down
			RedrawTimer.Tick += new EventHandler(RenderScene);
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
			modelWriter.Close();
		}

		private void exportWavefrontOBJToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void SetupGLResources()
		{
			Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("VPWStudio.Resources.DefaultShader.vert");
			if (s != null)
			{
				StreamReader sr = new StreamReader(s);
				string vert = sr.ReadToEnd();

				VertexShader = GL.CreateShader(ShaderType.VertexShader);
				GL.ShaderSource(VertexShader, vert);
				GL.CompileShader(VertexShader);
				sr.Close();
			}
			else
			{
				Program.ErrorMessageBox("Unable to load default vertex shader.");
			}
			// todo: GL.GetShaderInfoLog

			s = Assembly.GetExecutingAssembly().GetManifestResourceStream("VPWStudio.Resources.DefaultShader.frag");
			if (s != null)
			{
				StreamReader sr = new StreamReader(s);
				string frag = sr.ReadToEnd();

				FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
				GL.ShaderSource(FragmentShader, frag);
				GL.CompileShader(FragmentShader);
				sr.Close();
			}
			else
			{
				Program.ErrorMessageBox("Unable to load default fragment shader.");
			}
			// todo: GL.GetShaderInfoLog

			ShaderProgram = GL.CreateProgram();
			GL.AttachShader(ShaderProgram, VertexShader);
			GL.AttachShader(ShaderProgram, FragmentShader);
			GL.LinkProgram(ShaderProgram);

			// do the VBO and VAO stuff too
			VertexBufferObject = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
			ModelCoords = CurModel.GetNormalizedCoords();
			GL.BufferData(BufferTarget.ArrayBuffer, ModelCoords.Length * sizeof(float), ModelCoords, BufferUsageHint.StaticDraw);

			// grab params from vertex shader
			var positionLocation = GL.GetAttribLocation(ShaderProgram, "position");
			var uvCoordsLocation = GL.GetAttribLocation(ShaderProgram, "uvCoords");
			var colorDataLocation = GL.GetAttribLocation(ShaderProgram, "colorData");

			// VAO schwartz
			VertexArrayObject = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayObject);
			GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
			GL.EnableVertexAttribArray(positionLocation);
			GL.VertexAttribPointer(uvCoordsLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
			GL.EnableVertexAttribArray(uvCoordsLocation);
			GL.VertexAttribPointer(colorDataLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 5 * sizeof(float));
			GL.EnableVertexAttribArray(colorDataLocation);

			// EBO
			ElementBufferObject = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
			ModelFaces = CurModel.GetFacesList();
			GL.BufferData(BufferTarget.ElementArrayBuffer, ModelFaces.Length * sizeof(uint), ModelFaces, BufferUsageHint.StaticDraw);

			//TextureObject = GL.GenTexture();
			//GL.BindTexture(TextureTarget.Texture2D, TextureObject);
		}

		private void glControl1_Load(object sender, EventArgs e)
		{
			glControl1.MakeCurrent();
			GL.ClearColor(Color.CornflowerBlue);
			ValidGL = true;

			SetupGLResources();
			GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
			RedrawTimer.Start();
		}

		private void glControl1_Resize(object sender, EventArgs e)
		{
			if (!ValidGL)
			{
				return;
			}

			GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
			glControl1.Invalidate();
		}

		private void glControl1_Paint(object sender, PaintEventArgs e)
		{
			RenderScene(sender,e);
		}

		/// <summary>
		/// Render the scene to the preview panel.
		/// </summary>
		private void RenderScene(object sender, EventArgs e)
		{
			if (!ValidGL)
			{
				return;
			}
			if (glControl1 == null)
			{
				return;
			}

			GL.Clear(ClearBufferMask.ColorBufferBit);

			// bind necessary resources
			GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
			GL.UseProgram(ShaderProgram);
			GL.BindVertexArray(VertexArrayObject);
			// and draw that sucker
			GL.DrawElements(PrimitiveType.Triangles, ModelFaces.Length, DrawElementsType.UnsignedInt, 0);

			GL.Flush();
			glControl1.SwapBuffers();
		}

		private void ModelTool2_FormClosing(object sender, FormClosingEventArgs e)
		{
			RedrawTimer.Stop();
			if (ValidGL)
			{
				GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
				GL.BindVertexArray(0);
				GL.UseProgram(0);

				GL.DeleteBuffer(VertexBufferObject);
				GL.DeleteVertexArray(VertexArrayObject);
				GL.DeleteBuffer(ElementBufferObject);

				GL.DeleteProgram(ShaderProgram);
				GL.DeleteShader(FragmentShader);
				GL.DeleteShader(VertexShader);
			}
		}

		private void loadTextureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// new dialog for super bullshittery
			Dialogs.SelectTextureDialog std = new Dialogs.SelectTextureDialog();
			if (std.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("oh I was only kidding; actually setting a texture takes work");
			}
		}
	}
}
