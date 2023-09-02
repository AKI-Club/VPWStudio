using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VPWStudio.GameSpecific.VPW64;

namespace VPWStudio.Editors.VPW64
{
	public partial class DefaultCostume_VPW64 : Form
	{
		public List<DefaultCostumeData> AllCostumes = new List<DefaultCostumeData>();

		protected StringBuilder InfoBuilder = new StringBuilder();

		public DefaultCostume_VPW64()
		{
			InitializeComponent();

			ReadCostumes_ROM();
			cbCostumes.SelectedIndex = 0;
		}

		public void ReadCostumes_ROM()
		{
			// xxx: hardcoded
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);
			romReader.BaseStream.Seek(0x3F038, SeekOrigin.Begin);
			// 106
			for (int i = 0; i < 106; i++)
			{
				AllCostumes.Add(new DefaultCostumeData(romReader));
				cbCostumes.Items.Add(String.Format("Costume Set 0x{0:X2}",i));
			}
			romReader.Dispose();
		}

		public void UpdateOutput()
		{
			tbCostumeOutput.Clear();
			InfoBuilder.Clear();

			InfoBuilder.AppendLine(String.Format("Information for Costume Set 0x{0:X2}",cbCostumes.SelectedIndex));
			DefaultCostumeData cs = AllCostumes[cbCostumes.SelectedIndex];

			for (int c = 0; c < cs.Costumes.Length; c++)
			{
				InfoBuilder.AppendLine();

				InfoBuilder.AppendLine(String.Format("Costume #{0}",c));
				InfoBuilder.AppendLine(String.Format("Head: 0x{0:X2}", cs.Costumes[c].Head));
				InfoBuilder.AppendLine(String.Format("Costume: 0x{0:X2}", cs.Costumes[c].Costume));
				InfoBuilder.AppendLine(String.Format("Color byte 1: 0x{0:X2}; Color 1 = {1}", cs.Costumes[c].Color1, cs.Costumes[c].GetColor(0)));
				InfoBuilder.AppendLine(String.Format("Color byte 2: 0x{0:X2}; Color 2 = {1}, Color 3 = {2}", cs.Costumes[c].Color2, cs.Costumes[c].GetColor(1), cs.Costumes[c].GetColor(2)));
			}

			if (cs.Unknown1 != 0)
			{
				InfoBuilder.AppendLine();
				InfoBuilder.AppendLine(String.Format("Unknown value 1: 0x{0:X4}", cs.Unknown1));
				InfoBuilder.AppendLine("Extra Data bytes:");
				for (int i = 0; i < cs.ExtraData.Length; i++)
				{
					InfoBuilder.Append(String.Format("0x{0:X2} ", cs.ExtraData[i]));
				}
			}

			tbCostumeOutput.Text = InfoBuilder.ToString();
		}

		private void cbCostumes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbCostumes.SelectedIndex < 0)
			{
				return;
			}
			UpdateOutput();
		}
	}
}
