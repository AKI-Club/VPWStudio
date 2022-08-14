using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class ParamDecodeTest : Form
	{
		public byte[] ParamData = new byte[32];

		/// <summary>
		/// Length of Param data per game
		/// </summary>
		private Dictionary<VPWGames, int> ParamDataLength = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WM2K, 30 },
			{ VPWGames.VPW2, 30 },
			{ VPWGames.NoMercy, 32}
		};

		private readonly byte[] Params30_BitWidths = {
			3,4,3,4,4,3,3,3,5,4,4,4,4,4,4,4,4,4,4,4,3,5,3,3,4,3,3,9,4,4,9,4,3,3,4,4,3,12,12,12,12,32,32
		};

		private readonly byte[] Params32_BitWidths = {
			3,4,3,4,4,3,3,3,5,6,4,4,4,4,4,4,4,4,4,4,3,4,1,3,4,3,3,9,4,4,9,4,3,3,4,4,3,12,12,12,12,32,32
		};

		public ParamDecodeTest()
		{
			InitializeComponent();
		}

		private void btnTryParse_Click(object sender, EventArgs e)
		{
			int fileID = (int)nudParamID.Value;
			if (fileID > Program.CurrentProject.ProjectFileTable.Entries.Count)
			{
				return;
			}

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream extractStream = new MemoryStream();
			BinaryWriter extractWriter = new BinaryWriter(extractStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, fileID);
			romReader.Close();

			BinaryReader br = new BinaryReader(extractStream);
			br.BaseStream.Seek(0, SeekOrigin.Begin);
			ParamData = new byte[32];
			ParamData = br.ReadBytes(ParamDataLength[Program.CurrentProject.Settings.BaseGame]);
			br.Close();

			if (Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy)
			{
				ParseParams_32();
			}
			else
			{
				ParseParams_30();
			}
		}

		private void ParseParams_30()
		{
			tbParamsOut.Clear();
			MemoryStream ms = new MemoryStream(ParamData);
			BinaryReader br = new BinaryReader(ms);

			PackedBitsHandler.UnpackBits(br, 0, 0);
			int param0 = PackedBitsHandler.UnpackBits(br, 3, 1);
			tbParamsOut.Text = String.Format("[0x00] {0:X}\r\n", param0);

			int param1 = PackedBitsHandler.UnpackBits(br, 4, 1);
			tbParamsOut.Text += String.Format("[0x01] {0:X}\r\n", param1);

			br.Close();
		}

		private void ParseParams_32()
		{
			tbParamsOut.Clear();
		}
	}
}
