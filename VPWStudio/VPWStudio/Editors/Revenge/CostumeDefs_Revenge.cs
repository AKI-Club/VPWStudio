using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors.Revenge
{
	public partial class CostumeDefs_Revenge : Form
	{
		/// <summary>
		/// Costume definitions
		/// </summary>
		private List<CostumeDef_Early> CostumeDefs = new List<CostumeDef_Early>();

		/// <summary>
		/// Mask/Head definitions
		/// </summary>
		private List<MaskDef_Early> MaskDefs = new List<MaskDef_Early>();

		public CostumeDefs_Revenge()
		{
			InitializeComponent();

			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			LoadCostumeDefs(br);
			LoadMaskDefs(br);

			br.Close();

			// populate lists
			PopulateCostumes();
			PopulateMasks();
		}

		#region Data Load
		private void LoadCostumeDefs(BinaryReader br)
		{
			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry cdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["CostumeDefs"]);
				if (cdEntry != null)
				{
					br.BaseStream.Seek(cdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardedcoded offset
				/*
				MessageBox.Show(
					"Costume Definition location not found; using hardcoded offset instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				long offset = 0;
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.Revenge_NTSC_U:
						//DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["HeadDefs"]
						offset = 0x33744;
						break;
					case SpecificGame.Revenge_PAL:
						
						offset = 0;
						break;
				}
				br.BaseStream.Seek(offset, SeekOrigin.Begin);
				*/

				// if you thought mask defs were a pain, this is worse.
			}
		}

		/// <summary>
		/// Load Mask/Head Definitions.
		/// </summary>
		/// <param name="br"></param>
		private void LoadMaskDefs(BinaryReader br)
		{
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
						//DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["HeadDefs"]
						offset = 0x33744;
						break;
					case SpecificGame.Revenge_PAL:
						offset = 0x30E94;
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
					this.MaskDefs.Add(new MaskDef_Early(br));
					br.BaseStream.Seek(curMaskPointerPos, SeekOrigin.Begin);
				}

				br.BaseStream.Seek(curWrestlerPos, SeekOrigin.Begin);
			}
		}
		#endregion

		#region ListBox Population
		/// <summary>
		/// Populate the Costumes listbox.
		/// </summary>
		private void PopulateCostumes()
		{
			lbCostumes.Items.Clear();
			lbCostumes.BeginUpdate();
			int counter = 1;
			foreach (CostumeDef_Early cdef in CostumeDefs)
			{
				lbCostumes.Items.Add(String.Format("Costume {0}", counter));
				counter++;
			}
			lbCostumes.EndUpdate();
		}

		/// <summary>
		/// Populate the Mask/Head listbox.
		/// </summary>
		private void PopulateMasks()
		{
			lbHeadsMasks.Items.Clear();
			lbHeadsMasks.BeginUpdate();
			int counter = 1;
			foreach (MaskDef_Early mdef in MaskDefs)
			{
				lbHeadsMasks.Items.Add(String.Format("Mask {0}", counter));
				counter++;
			}
			lbHeadsMasks.EndUpdate();
		}
		#endregion

		#region Costumes
		private void LoadCostumeDefinition(CostumeDef_Early cdef)
		{
			// lots of shit.
		}

		private void lbCostumes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbCostumes.SelectedIndex < 0)
			{
				return;
			}

			LoadCostumeDefinition(CostumeDefs[lbCostumes.SelectedIndex]);
		}
		#endregion

		#region Masks/Heads
		private void LoadMaskDefinition(MaskDef_Early mdef)
		{
			tbNeckModel.Text = String.Format("{0:X4}", mdef.NeckModel);
			tbNeckPalette.Text = String.Format("{0:X4}", mdef.NeckPalette);
			tbNeckTexture.Text = String.Format("{0:X4}", mdef.NeckTexture);

			tbFaceModel.Text = String.Format("{0:X4}", mdef.HeadModel);
			tbFacePalette.Text = String.Format("{0:X4}", mdef.HeadPalette);
			tbFaceTexture.Text = String.Format("{0:X4}", mdef.HeadTexture);

			tbExtraModel.Text = String.Format("{0:X4}", mdef.ExtraModel);
			tbExtraPalette.Text = String.Format("{0:X4}", mdef.ExtraPalette);
			tbExtraTexture.Text = String.Format("{0:X4}", mdef.ExtraTexture);

			tbRipMaskPalette.Text = String.Format("{0:X4}", mdef.RippedMaskPalette);
			tbRipMaskTexture.Text = String.Format("{0:X4}", mdef.RippedMaskTexture);
			tbSkinColor.Text = String.Format("{0:X4}", mdef.SkinColor);

			// todo: load textures.
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// neck is usually CI4
			Ci4Palette neckPal = new Ci4Palette();
			MemoryStream neckPalStream = new MemoryStream();
			BinaryWriter neckPalWriter = new BinaryWriter(neckPalStream);
			BinaryReader neckPalReader = new BinaryReader(neckPalStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, neckPalWriter, mdef.NeckPalette);
			neckPalStream.Seek(0, SeekOrigin.Begin);
			neckPal.ReadData(neckPalReader);
			neckPalStream.Dispose();

			Ci4Texture neckTex = new Ci4Texture();
			MemoryStream neckTexStream = new MemoryStream();
			BinaryWriter neckTexWriter = new BinaryWriter(neckTexStream);
			BinaryReader neckTexReader = new BinaryReader(neckTexStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, neckTexWriter, mdef.NeckTexture);
			neckTexStream.Seek(0, SeekOrigin.Begin);
			neckTex.ReadData(neckTexReader);
			neckTexStream.Dispose();

			pbNeck.Image = neckTex.GetBitmap(neckPal);

			// face is usually CI8
			// CI4 entries: 60, 106
			// xxx: hack; this needs to be determined in a better way.
			MemoryStream facePalStream = new MemoryStream();
			BinaryWriter facePalWriter = new BinaryWriter(facePalStream);
			BinaryReader facePalReader = new BinaryReader(facePalStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, facePalWriter, mdef.HeadPalette);

			MemoryStream faceTexStream = new MemoryStream();
			BinaryWriter faceTexWriter = new BinaryWriter(faceTexStream);
			BinaryReader faceTexReader = new BinaryReader(faceTexStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, faceTexWriter, mdef.HeadTexture);

			if (facePalWriter.BaseStream.Position == 0x200)
			{
				// CI8
				facePalStream.Seek(0, SeekOrigin.Begin);
				Ci8Palette facePal = new Ci8Palette();
				facePal.ReadData(facePalReader);
				facePalStream.Dispose();
				Ci8Texture faceTex = new Ci8Texture();
				
				faceTexStream.Seek(0, SeekOrigin.Begin);
				faceTex.ReadData(faceTexReader);
				faceTexStream.Dispose();
				pbFace.Image = faceTex.GetBitmap(facePal);
			}
			else
			{
				// CI4
				facePalStream.Seek(0, SeekOrigin.Begin);
				Ci4Palette facePal = new Ci4Palette();
				facePal.ReadData(facePalReader);
				facePalStream.Dispose();
				Ci4Texture faceTex = new Ci4Texture();

				faceTexStream.Seek(0, SeekOrigin.Begin);
				faceTex.ReadData(faceTexReader);
				faceTexStream.Dispose();
				pbFace.Image = faceTex.GetBitmap(facePal);
			}

			// extra is either CI4 or CI8 depending on who you try editing
			if (mdef.ExtraPalette != 0 && mdef.ExtraTexture != 0)
			{
				MemoryStream extraPalStream = new MemoryStream();
				BinaryWriter extraPalWriter = new BinaryWriter(extraPalStream);
				BinaryReader extraPalReader = new BinaryReader(extraPalStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extraPalWriter, mdef.ExtraPalette);

				MemoryStream extraTexStream = new MemoryStream();
				BinaryWriter extraTexWriter = new BinaryWriter(extraTexStream);
				BinaryReader extraTexReader = new BinaryReader(extraTexStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extraTexWriter, mdef.ExtraTexture);

				if (extraPalWriter.BaseStream.Position == 0x200)
				{
					// CI8
					extraPalStream.Seek(0, SeekOrigin.Begin);
					Ci8Palette extraPal = new Ci8Palette();
					extraPal.ReadData(extraPalReader);
					extraPalStream.Dispose();

					Ci8Texture extraTex = new Ci8Texture();
					extraTexStream.Seek(0, SeekOrigin.Begin);
					extraTex.ReadData(extraTexReader);
					extraTexStream.Dispose();

					pbExtra.Image = extraTex.GetBitmap(extraPal);
				}
				else
				{
					// CI4
					extraPalStream.Seek(0, SeekOrigin.Begin);
					Ci4Palette extraPal = new Ci4Palette();
					extraPal.ReadData(extraPalReader);
					extraPalStream.Dispose();

					Ci4Texture extraTex = new Ci4Texture();
					extraTexStream.Seek(0, SeekOrigin.Begin);
					extraTex.ReadData(extraTexReader);
					extraTexStream.Dispose();

					pbExtra.Image = extraTex.GetBitmap(extraPal);
				}
			}
			else
			{
				pbExtra.Image = null;
			}

			// ripped mask is probably CI8, but we'll never know,
			// since it wasn't implemented in Revenge.
			if (mdef.RippedMaskPalette != 0 && mdef.RippedMaskTexture != 0)
			{
				
			}

			romReader.Close();
		}

		private void lbHeadsMasks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbHeadsMasks.SelectedIndex < 0)
			{
				return;
			}

			LoadMaskDefinition(MaskDefs[lbHeadsMasks.SelectedIndex]);
		}
		#endregion
	}
}
