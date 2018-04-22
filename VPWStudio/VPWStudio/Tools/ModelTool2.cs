using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// todo: what am I doing
using SharpDX;

namespace VPWStudio
{
	/// <summary>
	/// ModelTool2, an attempt to test SharpDX
	/// </summary>
	public partial class ModelTool2 : Form
	{
		private AkiModel CurModel = new AkiModel();

		public ModelTool2(int fileID)
		{
			InitializeComponent();
			LoadModel(fileID);

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
		}

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
	}
}
