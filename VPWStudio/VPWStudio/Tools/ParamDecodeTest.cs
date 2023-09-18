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
			3,4,3,4,4,3,3,3,5,6,4,4,4,4,4,4,4,4,4,4,3,5,3,3,4,3,3,9,4,4,9,4,3,3,4,4,3,12,12,12,12,3,3,3,3,32,1,1,4
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

		/// <summary>
		/// Handle 30-byte Parameter blocks. (used in WrestleMania 2000, Virtual Pro-Wrestling 2)
		/// </summary>
		private void ParseParams_30()
		{
			tbParamsOut.Clear();
			StringBuilder sb = new StringBuilder();

			// make large string of 0-padded binary values
			for (int i = 0; i < ParamData.Length; i++)
			{
				string binVal = Convert.ToString(ParamData[i], 2);
				if (binVal.Length < 8)
				{
					for (int j = (8 - binVal.Length); j > 0 ; j--)
					{
						binVal = String.Format("0{0}", binVal);
					}
				}
				sb.Append(binVal);
				tbParamsOut.Text += string.Format("{1:X2}: b{0}\r\n", binVal, i);
			}

			tbParamsOut.Text += "\r\n";

			int curPoint = 0;
			string fullBin = sb.ToString();
			for (int i = 0; i < Params30_BitWidths.Length; i++)
			{
				if (i < Params30_BitWidths.Length-1)
				{
					string binVal = fullBin.Substring(curPoint, Params30_BitWidths[i]);
					tbParamsOut.Text += String.Format("{0} (0x{1:X})\r\n", binVal, Convert.ToUInt32(binVal,2));
				}
				else
				{
					// this may be a bit sketchy...
					string outBin = fullBin.Substring(curPoint);
					for (int j = Params30_BitWidths[i] - fullBin.Substring(curPoint).Length; j > 0; j--)
					{
						outBin = String.Format("0{0}", outBin);
					}

					tbParamsOut.Text += String.Format("{0}\r\n", outBin);
				}
				curPoint += Params30_BitWidths[i];
			}

			/*
			MemoryStream ms = new MemoryStream(ParamData);
			BinaryReader br = new BinaryReader(ms);

			PackedBitsHandler.UnpackBits(br, 0, 0);
			int param0 = PackedBitsHandler.UnpackBits(br, 3, 1);
			tbParamsOut.Text = String.Format("[0x00] {0:X} ({1})\r\n", param0, Convert.ToString(param0,2));

			int param1 = PackedBitsHandler.UnpackBits(br, 4, 1);
			tbParamsOut.Text += String.Format("[0x01] {0:X} ({1})\r\n", param1, Convert.ToString(param1, 2));

			br.Close();
			*/
		}

		/// <summary>
		/// Handle 32-byte Parameter blocks. (used in No Mercy)
		/// </summary>
		private void ParseParams_32()
		{
			tbParamsOut.Clear();
			StringBuilder sb = new StringBuilder();

			// make large string of 0-padded binary values
			for (int i = 0; i < ParamData.Length; i++)
			{
				string binVal = Convert.ToString(ParamData[i], 2);
				if (binVal.Length < 8)
				{
					for (int j = (8 - binVal.Length); j > 0; j--)
					{
						binVal = String.Format("0{0}", binVal);
					}
				}
				sb.Append(binVal);
				tbParamsOut.Text += string.Format("{1:X2}: b{0}\r\n", binVal, i);
			}

			tbParamsOut.Text += "\r\n";

			int curPoint = 0;
			string fullBin = sb.ToString();
			for (int i = 0; i < Params32_BitWidths.Length; i++)
			{
				if (i < Params32_BitWidths.Length - 1)
				{
					tbParamsOut.Text += String.Format("{0}\r\n", fullBin.Substring(curPoint, Params32_BitWidths[i]));
				}
				else
				{
					// this may be a bit sketchy...
					string outBin = fullBin.Substring(curPoint);
					for (int j = Params32_BitWidths[i] - fullBin.Substring(curPoint).Length; j > 0; j--)
					{
						outBin = String.Format("0{0}", outBin);
					}

					tbParamsOut.Text += String.Format("{0}\r\n", outBin);
				}
				curPoint += Params32_BitWidths[i];
			}
		}
	}
}
