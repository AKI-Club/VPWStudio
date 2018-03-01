using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors.Revenge
{
	public partial class MaskDefs_Revenge : Form
	{
		private List<MaskDef_Early> CurMasks = new List<MaskDef_Early>();

		public MaskDefs_Revenge()
		{
			InitializeComponent();
			LoadMasks();
			PopulateMaskList();
		}

		private void LoadMasks()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry hdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["HeadDefs"]);
				if (hdEntry != null)
				{
					br.BaseStream.Seek(hdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardedcoded offset
				MessageBox.Show(
					"Head/Mask Definition location not found; using hardcoded offset instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				long offset = 0;
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.Revenge_NTSC_U:
						offset = 0x33744;
						break;
					case SpecificGame.Revenge_PAL:
						MessageBox.Show("tell freem to find the proper damned offset for Revenge PAL!");
						offset = 0;
						break;
				}
				br.BaseStream.Seek(offset, SeekOrigin.Begin);
			}

			// this is a pain because you have to follow pointers.
			// I'm going to cheat and just follow the first pointer,
			// going down the list until I reach the beginning again.

			byte[] fwptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fwptr);
			}
			UInt32 listPtr = BitConverter.ToUInt32(fwptr, 0);
			br.BaseStream.Seek(Z64Rom.PointerToRom(listPtr), SeekOrigin.Begin);
			long curWrestlerPos = br.BaseStream.Position;

			// cheating helper: there are 90 such pointers.
			// maskdef list is pointers to first wrestler in group.
			// this pointer leads to the mask list pointer for that wrestler.
			long curMaskPointerPos = 0;
			for (int i = 0; i < 90; i++)
			{
				byte[] wmptr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(wmptr);
				}
				curWrestlerPos = br.BaseStream.Position;

				UInt32 wcList = BitConverter.ToUInt32(wmptr, 0);
				br.BaseStream.Seek(Z64Rom.PointerToRom(wcList), SeekOrigin.Begin);
				while (true)
				{
					byte[] curmsk = br.ReadBytes(4);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(curmsk);
					}
					curMaskPointerPos = br.BaseStream.Position;
					UInt32 curPointer = BitConverter.ToUInt32(curmsk, 0);
					if (curPointer == 0)
					{
						break;
					}

					br.BaseStream.Seek(Z64Rom.PointerToRom(curPointer), SeekOrigin.Begin);
					this.CurMasks.Add(new MaskDef_Early(br));
					br.BaseStream.Seek(curMaskPointerPos, SeekOrigin.Begin);
				}

				br.BaseStream.Seek(curWrestlerPos, SeekOrigin.Begin);
			}

			br.Close();
		}

		private void PopulateMaskList()
		{
			lbHeadDefs.Items.Clear();
			lbHeadDefs.BeginUpdate();
			int counter = 1;
			foreach (MaskDef_Early mdef in this.CurMasks)
			{
				lbHeadDefs.Items.Add(String.Format("Mask {0}", counter));
				counter++;
			}
			lbHeadDefs.EndUpdate();
		}

		private void lbHeadDefs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbHeadDefs.SelectedIndex < 0)
			{
				return;
			}

			LoadMaskDefinition(this.CurMasks[lbHeadDefs.SelectedIndex]);
		}

		private void LoadMaskDefinition(MaskDef_Early mdef)
		{
			tbNeckModel.Text = String.Format("{0:X4}", mdef.NeckModel);
			tbNeckPal.Text = String.Format("{0:X4}", mdef.NeckPalette);
			tbNeckTex.Text = String.Format("{0:X4}", mdef.NeckTexture);

			tbHeadModel.Text = String.Format("{0:X4}", mdef.HeadModel);
			tbHeadPal.Text = String.Format("{0:X4}", mdef.HeadPalette);
			tbHeadTex.Text = String.Format("{0:X4}", mdef.HeadTexture);

			tbExtraModel.Text = String.Format("{0:X4}", mdef.ExtraModel);
			tbExtraPal.Text = String.Format("{0:X4}", mdef.ExtraPalette);
			tbExtraTex.Text = String.Format("{0:X4}", mdef.ExtraTexture);

			tbRipMaskPal.Text = String.Format("{0:X4}", mdef.RippedMaskPalette);
			tbRipMaskTex.Text = String.Format("{0:X4}", mdef.RippedMaskTexture);
			tbSkinColor.Text = String.Format("{0:X4}", mdef.SkinColor);
		}
	}
}
