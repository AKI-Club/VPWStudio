using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace VPWStudio
{
	/// <summary>
	/// I need to test 3D stuff and I don't want to break working code.
	/// </summary>
	public partial class TestScene3D : Form
	{
		/// <summary>
		/// Timer for poking the Update routine.
		/// </summary>
		private Timer RedrawTimer = new Timer();

		private bool Active;

		/// <summary>
		/// Background clear color.
		/// </summary>
		private Color BackgroundColor = Color.CornflowerBlue;

		#region GL-specific
		/// <summary>
		/// Determine if the GL context is valid. True if we can issue GL commands.
		/// </summary>
		private bool ValidGL = false;

		// shaders stuff
		public int VertexShader;
		public int FragmentShader;
		public int ShaderProgram;

		// shader attribs
		public int PositionLoc;
		public int UVCoordsLoc;
		public int ColorDataLoc;

		public int ModelViewLoc;
		public int ModelViewObject;

		// VBO, VAO
		public int VertexBufferObject;
		public int VertexArrayObject;

		// Element Buffer Object (read: list of vertices that define faces)
		public int ElementBufferObject;

		// gl texture unit
		public int TextureObject;
		#endregion

		/// <summary>
		/// Full list of scene coordinates.
		/// </summary>
		public float[] SceneCoords;

		/// <summary>
		/// Full list of scene faces.
		/// </summary>
		public int[] SceneFaces;

		/// <summary>
		/// Renderable scene contents.
		/// </summary>
		public List<RenderableN64> SceneModels = new List<RenderableN64>();

		/// <summary>
		/// A 1x1 full brightness fallback texture.
		/// </summary>
		private readonly byte[] FallbackTexture = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };

		public TestScene3D()
		{
			InitializeComponent();
			cbEnableTexture.Enabled = false;
			Active = true;

			RedrawTimer.Interval = 16; // just about 1/60th of a second; can't use floating point values, so I had to round down
			RedrawTimer.Tick += new EventHandler(UpdateScene);
		}

		/// <summary>
		/// Update the Scene Items ListBox.
		/// </summary>
		private void UpdateSceneList()
		{
			lvSceneItems.BeginUpdate();
			lvSceneItems.Clear();

			for (int i = 0; i < SceneModels.Count; i++)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = SceneModels[i].Name;
				lvi.Tag = i;
				lvi.Checked = SceneModels[i].Visible;
				lvSceneItems.Items.Add(lvi);
			}

			lvSceneItems.EndUpdate();
		}

		#region Item Buttons
		/// <summary>
		/// Brings up a dialog for adding a new model to the scene.
		/// </summary>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			TestScene3D_AddEditDialog addDialog = new TestScene3D_AddEditDialog();
			if (addDialog.ShowDialog() == DialogResult.OK)
			{
				RenderableN64 newObj = new RenderableN64(addDialog.ModelFileID, addDialog.PaletteFileID, addDialog.TextureFileID);
				newObj.Name = String.Format("{0}", SceneModels.Count);
				SceneModels.Add(newObj);
				UpdateSceneList();
				glControl1.Invalidate();
			}
		}

		/// <summary>
		/// Remove the currently selected object from the scene.
		/// </summary>
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count < 0)
			{
				return;
			}

			SceneModels.RemoveAt(lvSceneItems.SelectedItems[0].Index);

			UpdateSceneList();
			glControl1.Invalidate();
		}

		/// <summary>
		/// Clear all objects from the scene.
		/// </summary>
		private void btnClear_Click(object sender, EventArgs e)
		{
			SceneModels.Clear();
			UpdateSceneList();
			glControl1.Invalidate();

			tbObjectName.Text = String.Empty;
			tbPosX.Text = String.Empty;
			tbPosY.Text = String.Empty;
			tbPosZ.Text = String.Empty;
			tbRotX.Text = String.Empty;
			tbRotY.Text = String.Empty;
			tbRotZ.Text = String.Empty;
			tbModelFileID.Text = String.Empty;
			tbPalFileID.Text = String.Empty;
			tbTexFileID.Text = String.Empty;
		}
		#endregion

		#region GLControl
		private void SetupGLResources()
		{
			#region Shaders
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
			// todo: GL.GetShaderInfoLog(VertexShader, output string)

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
			// todo: GL.GetShaderInfoLog(FragmentShader, output string)

			ShaderProgram = GL.CreateProgram();
			GL.AttachShader(ShaderProgram, VertexShader);
			GL.AttachShader(ShaderProgram, FragmentShader);
			GL.LinkProgram(ShaderProgram);
			#endregion

			GL.GenBuffers(1, out VertexBufferObject);

			// grab params from vertex shader
			PositionLoc = GL.GetAttribLocation(ShaderProgram, "position");
			UVCoordsLoc = GL.GetAttribLocation(ShaderProgram, "uvCoords");
			ColorDataLoc = GL.GetAttribLocation(ShaderProgram, "colorData");
			ModelViewLoc = GL.GetUniformLocation(ShaderProgram, "modelView");

			GL.GenBuffers(1, out ModelViewObject);

			GL.GenBuffers(1, out VertexArrayObject);

			// element/index buffer
			GL.GenBuffers(1, out ElementBufferObject);

			// texture buffer
			GL.GenBuffers(1, out TextureObject);
		}

		private void glControl1_Load(object sender, EventArgs e)
		{
			glControl1.MakeCurrent();
			GL.ClearColor(BackgroundColor);
			ValidGL = true;

			SetupGLResources();
			GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
			RedrawTimer.Start();
		}

		/// <summary>
		/// Disable 3D stuff when moving away from this form
		/// </summary>
		private void TestScene3D_Leave(object sender, EventArgs e)
		{
			if (!ValidGL)
			{
				return;
			}
			if (glControl1 == null)
			{
				return;
			}

			Active = false;
			RedrawTimer.Stop();
			glControl1.Context.MakeCurrent(null);
		}

		/// <summary>
		/// Enable 3D stuff when moving back to this form
		/// </summary>
		private void TestScene3D_Enter(object sender, EventArgs e)
		{
			if (!ValidGL)
			{
				return;
			}
			if (glControl1 == null)
			{
				return;
			}

			Active = true;
			glControl1.MakeCurrent();
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
			if (!Active)
			{
				return;
			}

			RenderScene(sender, e);
		}

		private void UpdateScene(object sender, EventArgs e)
		{
			List<float> coordsList = new List<float>();
			List<int> faceList = new List<int>();

			int numVerts = 0;
			foreach (RenderableN64 obj in SceneModels)
			{
				coordsList.AddRange(obj.Model.GetNormalizedCoords());
				faceList.AddRange(obj.Model.GetFacesList(numVerts));
				numVerts += obj.Model.Vertices.Count;
			}

			// convert lists to arrays
			SceneCoords = coordsList.ToArray();
			SceneFaces = faceList.ToArray();

			// bind buffers
			GL.BindBuffer(BufferTarget.ArrayBuffer, VertexArrayObject);
			GL.BufferData(BufferTarget.ArrayBuffer, SceneCoords.Length * sizeof(float), SceneCoords, BufferUsageHint.StaticDraw);

			GL.BindVertexArray(VertexArrayObject);
			GL.VertexAttribPointer(PositionLoc, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
			GL.EnableVertexAttribArray(PositionLoc);
			GL.VertexAttribPointer(UVCoordsLoc, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
			GL.EnableVertexAttribArray(UVCoordsLoc);
			GL.VertexAttribPointer(ColorDataLoc, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 5 * sizeof(float));
			GL.EnableVertexAttribArray(ColorDataLoc);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
			GL.BufferData(BufferTarget.ElementArrayBuffer, SceneFaces.Length * sizeof(uint), SceneFaces, BufferUsageHint.StaticDraw);

			foreach (RenderableN64 obj in SceneModels)
			{
				obj.CalculateModelMatrix();
				obj.ViewProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(1.3f, glControl1.Width / (float)glControl1.Height, 1.0f, 40.0f);
				obj.ModelViewProjectionMatrix = obj.ModelMatrix * obj.ViewProjectionMatrix;
			}

			GL.ActiveTexture(TextureUnit.Texture0);

			// texture settings
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

			GL.BindTexture(TextureTarget.Texture2D, TextureObject);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 1, 1, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, FallbackTexture);

			GL.UseProgram(ShaderProgram);

			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			glControl1.Invalidate();
		}

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

			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.Enable(EnableCap.DepthTest);

			GL.BindVertexArray(VertexArrayObject);

			int curIndex = 0;
			foreach (RenderableN64 obj in SceneModels)
			{
				GL.UniformMatrix4(ModelViewLoc, false, ref obj.ModelViewProjectionMatrix);
				if (obj.Visible)
				{
					// todo: this needs to be defined on a per-object basis
					//GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, GetTextureRepeatMode(horizontalMirrorToolStripMenuItem));
					//GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, GetTextureRepeatMode(verticalMirrorToolStripMenuItem));

					if (obj.EnableTexture)
					{
						GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, obj.Texture.Width, obj.Texture.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, obj.PixelData);
					}
					else
					{
						GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 1, 1, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, FallbackTexture);
					}
					GL.DrawElements(PrimitiveType.Triangles, obj.Model.Faces.Count*3, DrawElementsType.UnsignedInt, curIndex * sizeof(uint));
				}
				curIndex += obj.Model.Faces.Count*3;
			}

			GL.DisableVertexAttribArray(VertexArrayObject);

			GL.Flush();
			glControl1.SwapBuffers();
		}
		#endregion

		private void TestScene3D_FormClosing(object sender, FormClosingEventArgs e)
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
				GL.DeleteTexture(TextureObject);

				GL.DeleteProgram(ShaderProgram);
				GL.DeleteShader(FragmentShader);
				GL.DeleteShader(VertexShader);
			}
		}

		// textbox numeric handling
		private void TextBoxNumeric_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// only accept control characters, digits, '-', and '.'
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}

			// only allow one of each of the non-digit characters in the input
			if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf(e.KeyChar) > -1)
			{
				e.Handled = true;
			}
			if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf(e.KeyChar) > -1)
			{
				e.Handled = true;
			}

			// only allow '-' at the beginning of input
			if (e.KeyChar == '-' && (sender as TextBox).SelectionStart != 0)
			{
				e.Handled = true;
			}
		}

		#region Position/Rotation buttons
		private void btnUpdatePosRot_Click(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			int objIndex = lvSceneItems.SelectedItems[0].Index;

			SceneModels[objIndex].Position = new Vector3(
				float.Parse(tbPosX.Text),
				float.Parse(tbPosY.Text),
				float.Parse(tbPosZ.Text)
			);

			SceneModels[objIndex].Rotation = new Vector3(
				float.Parse(tbRotX.Text),
				float.Parse(tbRotY.Text),
				float.Parse(tbRotZ.Text)
			);

			glControl1.Invalidate();
		}

		private void btnResetPosRot_Click(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			// reset the values in the text boxes
			int objIndex = lvSceneItems.SelectedItems[0].Index;

			tbPosX.Text = String.Format("{0}", SceneModels[objIndex].Position.X);
			tbPosY.Text = String.Format("{0}", SceneModels[objIndex].Position.Y);
			tbPosZ.Text = String.Format("{0}", SceneModels[objIndex].Position.Z);
			tbRotX.Text = String.Format("{0}", SceneModels[objIndex].Rotation.X);
			tbRotY.Text = String.Format("{0}", SceneModels[objIndex].Rotation.Y);
			tbRotZ.Text = String.Format("{0}", SceneModels[objIndex].Rotation.Z);
		}
		#endregion

		#region File ID buttons
		private void btnEditModelFileID_Click(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			int objIndex = lvSceneItems.SelectedItems[0].Index;

			TestScene3D_AddEditDialog editDialog = new TestScene3D_AddEditDialog(
				(int)SceneModels[objIndex].ModelFileID,
				(int)SceneModels[objIndex].TexFileID,
				(int)SceneModels[objIndex].PalFileID
			);
			if (editDialog.ShowDialog() == DialogResult.OK)
			{
				SceneModels[objIndex] = new RenderableN64(editDialog.ModelFileID, editDialog.PaletteFileID, editDialog.TextureFileID);
				SceneModels[objIndex].ResetPosRotScale();
				UpdateSceneList();
				glControl1.Invalidate();
			}
		}
		#endregion

		private void lbSceneItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			// update yon display values
			int objIndex = lvSceneItems.SelectedItems[0].Index;

			tbObjectName.Text = SceneModels[objIndex].Name;

			tbPosX.Text = String.Format("{0}", SceneModels[objIndex].Position.X);
			tbPosY.Text = String.Format("{0}", SceneModels[objIndex].Position.Y);
			tbPosZ.Text = String.Format("{0}", SceneModels[objIndex].Position.Z);
			tbRotX.Text = String.Format("{0}", SceneModels[objIndex].Rotation.X);
			tbRotY.Text = String.Format("{0}", SceneModels[objIndex].Rotation.Y);
			tbRotZ.Text = String.Format("{0}", SceneModels[objIndex].Rotation.Z);

			tbModelFileID.Text = String.Format("{0:X4}", SceneModels[objIndex].ModelFileID);
			tbTexFileID.Text = String.Format("{0:X4}", SceneModels[objIndex].TexFileID);
			tbPalFileID.Text = String.Format("{0:X4}", SceneModels[objIndex].PalFileID);
			cbEnableTexture.Enabled = true;
			cbEnableTexture.Checked = SceneModels[objIndex].EnableTexture;
		}

		private void cbEnableTexture_CheckedChanged(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			int objIndex = lvSceneItems.SelectedItems[0].Index;
			SceneModels[objIndex].EnableTexture = cbEnableTexture.Checked;
		}

		private void btnBackgroundColor_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				BackgroundColor = cd.Color;
				GL.ClearColor(BackgroundColor);
				glControl1.Invalidate();
			}
		}

		private void btnRename_Click(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			int objIndex = lvSceneItems.SelectedItems[0].Index;
			SceneModels[objIndex].Name = tbObjectName.Text;
			UpdateSceneList();
		}

		private void lvSceneItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvSceneItems.SelectedItems.Count <= 0)
			{
				return;
			}

			int sceneModelsIndex = lvSceneItems.SelectedItems[0].Index;
			// update yon display values
			tbObjectName.Text = SceneModels[sceneModelsIndex].Name;

			tbPosX.Text = String.Format("{0}", SceneModels[sceneModelsIndex].Position.X);
			tbPosY.Text = String.Format("{0}", SceneModels[sceneModelsIndex].Position.Y);
			tbPosZ.Text = String.Format("{0}", SceneModels[sceneModelsIndex].Position.Z);
			tbRotX.Text = String.Format("{0}", SceneModels[sceneModelsIndex].Rotation.X);
			tbRotY.Text = String.Format("{0}", SceneModels[sceneModelsIndex].Rotation.Y);
			tbRotZ.Text = String.Format("{0}", SceneModels[sceneModelsIndex].Rotation.Z);

			tbModelFileID.Text = String.Format("{0:X4}", SceneModels[sceneModelsIndex].ModelFileID);
			tbTexFileID.Text = String.Format("{0:X4}", SceneModels[sceneModelsIndex].TexFileID);
			tbPalFileID.Text = String.Format("{0:X4}", SceneModels[sceneModelsIndex].PalFileID);
			cbEnableTexture.Enabled = true;
			cbEnableTexture.Checked = SceneModels[sceneModelsIndex].EnableTexture;
		}

		private void lvSceneItems_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			SceneModels[e.Item.Index].Visible = e.Item.Checked;
		}
	}
}
