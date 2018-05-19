using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// todo: what am I even doing here
using SharpDX;
using SharpDX.D3DCompiler;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Win32;
using SharpDX.Windows;

namespace VPWStudio
{
	/// <summary>
	/// ModelTool2, an attempt to test SharpDX
	/// </summary>
	public partial class ModelTool2 : Form
	{
		private AkiModel CurModel = new AkiModel();

		private int FileID;

		#region SharpDX-related Members
		private RenderControl CurRenderControl = new RenderControl();

		/// <summary>
		/// Swap Chain Description
		/// </summary>
		private SwapChainDescription SwapChainDesc;

		/// <summary>
		/// Direct3D 11 Device
		/// </summary>
		private SharpDX.Direct3D11.Device D3D11Device;

		/// <summary>
		/// Current SwapChain
		/// </summary>
		private SwapChain CurSwapChain;

		/// <summary>
		/// Current Device Context
		/// </summary>
		private DeviceContext CurDeviceContext;

		private Factory CurFactory;

		/// <summary>
		/// Back Buffer.
		/// </summary>
		private Texture2D BackBuffer;

		/// <summary>
		/// RenderTargetView for the BackBuffer
		/// </summary>
		private RenderTargetView CurRenderTargetView;

		/// <summary>
		/// Vertex shader
		/// </summary>
		private VertexShader CurVertexShader;

		/// <summary>
		/// Pixel/Fragment shader
		/// </summary>
		private PixelShader CurPixelShader;

		private InputLayout CurInputLayout;
		#endregion

		public ModelTool2(int fileID)
		{
			InitializeComponent();
			FileID = fileID;

			LoadModel(FileID);
			InitSharpDX();

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

			int offsetU = (CurModel.OffsetTexture & 0xF0) >> 4;
			int offsetV = (CurModel.OffsetTexture & 0x0F);
			tbOffsetUV.Text = String.Format("{1}, {2} (0x{0:X2})", (byte)CurModel.OffsetTexture, offsetU, offsetV);

			RenderModel();

			DisposeSharpDX();
		}

		#region SharpDX Housekeeping
		/// <summary>
		/// Initialize anything using SharpDX
		/// </summary>
		private void InitSharpDX()
		{
			SwapChainDesc = new SwapChainDescription()
			{
				BufferCount = 1,
				ModeDescription = new ModeDescription(pbPreview.Width, pbPreview.Height, new Rational(60, 1), Format.R8G8B8A8_UNorm),
				IsWindowed = true,
				OutputHandle = Handle,
				SampleDescription = new SampleDescription(1, 0),
				SwapEffect = SwapEffect.Discard,
				Usage = Usage.RenderTargetOutput
			};

			SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, SwapChainDesc, out D3D11Device, out CurSwapChain);
			CurDeviceContext = D3D11Device.ImmediateContext;

			CurFactory = CurSwapChain.GetParent<Factory>();
			CurFactory.MakeWindowAssociation(CurRenderControl.Handle, WindowAssociationFlags.IgnoreAll);

			BackBuffer = Texture2D.FromSwapChain<Texture2D>(CurSwapChain, 0);
			CurRenderTargetView = new RenderTargetView(D3D11Device, BackBuffer);

			// I hate shaders sooooo much!
			ShaderBytecode BytecodeVS = ShaderBytecode.Compile(Properties.Resources.DefaultShader, "VS", "vs_4_0", ShaderFlags.None, EffectFlags.None);
			ShaderBytecode BytecodePS = ShaderBytecode.Compile(Properties.Resources.DefaultShader, "PS", "ps_4_0", ShaderFlags.None, EffectFlags.None);

			CurVertexShader = new VertexShader(D3D11Device, BytecodeVS);
			CurPixelShader = new PixelShader(D3D11Device, BytecodePS);

			CurInputLayout = new InputLayout(
				D3D11Device,
				ShaderSignature.GetInputSignature(BytecodeVS),
				new[]
				{
					new InputElement("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
					new InputElement("COLOR", 0, Format.R32G32B32A32_Float, 16, 0)
				}
			);

			BytecodeVS.Dispose();
			BytecodePS.Dispose();

			// everything else is left to other functions.
		}

		/// <summary>
		/// Dispose of all SharpDX resources
		/// </summary>
		private void DisposeSharpDX()
		{
			if (CurVertexShader != null)
			{
				CurVertexShader.Dispose();
			}
			if (CurPixelShader != null)
			{
				CurPixelShader.Dispose();
			}

			// vertices
			// layout
			CurRenderTargetView.Dispose();
			BackBuffer.Dispose();
			CurDeviceContext.ClearState();
			CurDeviceContext.Flush();
			D3D11Device.Dispose();
			CurDeviceContext.Dispose();
			CurSwapChain.Dispose();
			CurSwapChain.Dispose();
			CurFactory.Dispose();
		}
		#endregion

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
			CurModel.ReadData(modelReader);
			modelReader.Close();
		}

		/// <summary>
		/// Render the model to the preview image.
		/// </summary>
		private void RenderModel()
		{
			if (CurModel == null)
			{
				pbPreview.Image = null;
			}
			else
			{
				// do a lot of shit

				// convert AkiModel data to { Vector4{XYZ?}, Vector4{RGBA} }
				List<Vector4> VertexList = new List<Vector4>();
				foreach (AkiVertex av in CurModel.Vertices)
				{
					// point data
					VertexList.Add(new Vector4(av.X, av.Y, av.Z, 1.0f));

					// color data
					float red = ((av.VertexColor.R) / 255);
					float grn = ((av.VertexColor.G) / 255);
					float blu = ((av.VertexColor.B) / 255);
					VertexList.Add(new Vector4(red, grn, blu, 1.0f));
				}
				var Vertices = SharpDX.Direct3D11.Buffer.Create(D3D11Device, BindFlags.VertexBuffer, VertexList.ToArray());

				// set up device context
				CurDeviceContext.InputAssembler.InputLayout = CurInputLayout;
				CurDeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
				CurDeviceContext.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(Vertices, 32, 0));
				CurDeviceContext.VertexShader.Set(CurVertexShader);
				CurDeviceContext.Rasterizer.SetViewport(new Viewport(0, 0, pbPreview.Width, pbPreview.Height, 0.0f, 1.0f));
				CurDeviceContext.PixelShader.Set(CurPixelShader);
				CurDeviceContext.OutputMerger.SetTargets(CurRenderTargetView);

				CurDeviceContext.ClearRenderTargetView(CurRenderTargetView, new SharpDX.Mathematics.Interop.RawColor4(0f, 0f, 0f, 1.0f));
				CurDeviceContext.Draw(CurModel.NumVertices, 0);
				CurSwapChain.Present(0, PresentFlags.None);

				Bitmap b = new Bitmap(pbPreview.Width, pbPreview.Height);
				CurRenderControl.DrawToBitmap(b, new System.Drawing.Rectangle(0, 0, pbPreview.Width, pbPreview.Height));
				pbPreview.Image = b;
				b.Dispose();
			}
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
	}
}
