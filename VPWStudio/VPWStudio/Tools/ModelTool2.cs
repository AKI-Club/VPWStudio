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

		#region SharpDX-related Members
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
		#endregion

		public ModelTool2(int fileID)
		{
			InitializeComponent();
			LoadModel(fileID);
			InitSharpDX();

			tbFileID.Text = String.Format("{0:X4}", fileID);
			tbModelScale.Text = String.Format("{0} (0x{0:X2})", CurModel.Scale);
			tbNumVerts.Text = String.Format("{0} (0x{0:X2})", CurModel.NumVertices);
			tbNumFaces.Text = String.Format("{0} (0x{0:X2})", CurModel.NumFaces);
			tbUnknown.Text = String.Format("{0} (0x{0:X2})", CurModel.UnknownValue);
			tbOffsetX.Text = String.Format("{0} (0x{0:X2})", (sbyte)CurModel.OffsetX);
			tbOffsetY.Text = String.Format("{0} (0x{0:X2})", (sbyte)CurModel.OffsetY);
			tbOffsetZ.Text = String.Format("{0} (0x{0:X2})", (sbyte)CurModel.OffsetZ);

			int offsetU = (CurModel.OffsetTexture & 0xF0) >> 4;
			int offsetV = (CurModel.OffsetTexture & 0x0F);
			tbOffsetUV.Text = String.Format("{1}, {2} (0x{0:X2})", (byte)CurModel.OffsetTexture, offsetU, offsetV);

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
				OutputHandle = pbPreview.Handle,
				SampleDescription = new SampleDescription(1, 0),
				SwapEffect = SwapEffect.Discard,
				Usage = Usage.RenderTargetOutput
			};

			SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, SwapChainDesc, out D3D11Device, out CurSwapChain);
			CurDeviceContext = D3D11Device.ImmediateContext;

			CurFactory = CurSwapChain.GetParent<Factory>();
			CurFactory.MakeWindowAssociation(pbPreview.Handle, WindowAssociationFlags.IgnoreAll);

			BackBuffer = Texture2D.FromSwapChain<Texture2D>(CurSwapChain, 0);
			CurRenderTargetView = new RenderTargetView(D3D11Device, BackBuffer);

			// I hate shaders sooooo much!
			ShaderBytecode BytecodeVS = ShaderBytecode.Compile(VPWStudio.Properties.Resources.DefaultShader, "VS", "vs_4_0", ShaderFlags.None, EffectFlags.None);
			ShaderBytecode BytecodePS = ShaderBytecode.Compile(VPWStudio.Properties.Resources.DefaultShader, "PS", "ps_4_0", ShaderFlags.None, EffectFlags.None);

			CurVertexShader = new VertexShader(D3D11Device, BytecodeVS);
			CurPixelShader = new PixelShader(D3D11Device, BytecodePS);

			BytecodePS.Dispose();
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
			}
		}
	}
}
