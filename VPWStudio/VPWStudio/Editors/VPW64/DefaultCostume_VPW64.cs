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
		/// <summary>
		/// Every default costume defined in VPW64.
		/// </summary>
		public List<DefaultCostumeData> AllCostumes = new List<DefaultCostumeData>();

		public DefaultCostume_VPW64()
		{
			InitializeComponent();

			ReadCostumes_ROM();
			cbCostumes.SelectedIndex = 0;
		}

		public void ReadCostumes_ROM()
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["WrestlerDefaultCostumeDefs"]);
				if (sdEntry != null)
				{
					romReader.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Wrestler Default Costume Definitions location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW64_NTSC_J].Locations["WrestlerDefaultCostumeDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of costume defs
			for (int i = 0; i < 106; i++)
			{
				AllCostumes.Add(new DefaultCostumeData(romReader));
				cbCostumes.Items.Add(String.Format("Costume Set 0x{0:X2}",i));
			}
			romReader.Dispose();
		}

		public void UpdateOutput()
		{
			DefaultCostumeData cs = AllCostumes[cbCostumes.SelectedIndex];

			tbCos1Head.Text = String.Format("0x{0:X2}", cs.Costumes[0].Head);
			tbCos1Costume.Text = String.Format("0x{0:X2}", cs.Costumes[0].Costume);
			cccCos1Color1.SetColorNum(cs.Costumes[0].GetColor(0));
			cccCos1Color2.SetColorNum(cs.Costumes[0].GetColor(1));
			cccCos1Color3.SetColorNum(cs.Costumes[0].GetColor(2));

			tbCos2Head.Text = String.Format("0x{0:X2}", cs.Costumes[1].Head);
			tbCos2Costume.Text = String.Format("0x{0:X2}", cs.Costumes[1].Costume);
			cccCos2Color1.SetColorNum(cs.Costumes[1].GetColor(0));
			cccCos2Color2.SetColorNum(cs.Costumes[1].GetColor(1));
			cccCos2Color3.SetColorNum(cs.Costumes[1].GetColor(2));

			tbCos3Head.Text = String.Format("0x{0:X2}", cs.Costumes[2].Head);
			tbCos3Costume.Text = String.Format("0x{0:X2}", cs.Costumes[2].Costume);
			cccCos3Color1.SetColorNum(cs.Costumes[2].GetColor(0));
			cccCos3Color2.SetColorNum(cs.Costumes[2].GetColor(1));
			cccCos3Color3.SetColorNum(cs.Costumes[2].GetColor(2));

			tbCos4Head.Text = String.Format("0x{0:X2}", cs.Costumes[3].Head);
			tbCos4Costume.Text = String.Format("0x{0:X2}", cs.Costumes[3].Costume);
			cccCos4Color1.SetColorNum(cs.Costumes[3].GetColor(0));
			cccCos4Color2.SetColorNum(cs.Costumes[3].GetColor(1));
			cccCos4Color3.SetColorNum(cs.Costumes[3].GetColor(2));
		}

		private void cbCostumes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbCostumes.SelectedIndex < 0)
			{
				return;
			}
			UpdateOutput();
		}

		private void DefaultCostume_VPW64_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
