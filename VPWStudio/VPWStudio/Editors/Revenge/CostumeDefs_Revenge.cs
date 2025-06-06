﻿using System;
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
	/// <summary>
	/// Body Type, Costume, and Head/Mask Form for WCW/nWo Revenge
	/// </summary>
	public partial class CostumeDefs_Revenge : Form
	{
		/// <summary>
		/// Body type definitions
		/// </summary>
		private List<BodyModelDef_Early> BodyTypeDefs = new List<BodyModelDef_Early>();

		/// <summary>
		/// Costume definitions
		/// </summary>
		private List<GameSpecific.Revenge.CostumeDef> CostumeDefs = new List<GameSpecific.Revenge.CostumeDef>();

		/// <summary>
		/// Mask/Head definitions
		/// </summary>
		private List<MaskDef_Early> MaskDefs = new List<MaskDef_Early>();

		/// <summary>
		/// Determine if the subpalette should be shown.
		/// </summary>
		private bool Costume_UseSubpalette = false;

		public CostumeDefs_Revenge()
		{
			InitializeComponent();
			cbCostumesAltPalette.Checked = Costume_UseSubpalette;

			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			LoadBodyTypeDefs(br);
			LoadCostumeDefs(br);
			LoadMaskDefs(br);

			br.Close();

			// populate lists
			PopulateBodyTypes();
			PopulateCostumes();
			PopulateMasks();
		}

		#region Data Load
		/// <summary>
		/// Load Body Type Definitions.
		/// </summary>
		/// <param name="br"></param>
		private void LoadBodyTypeDefs(BinaryReader br)
		{
			bool hasLocation = false;
			int numBodyDefs = 52;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry btdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["BodyTypeDefs"]);
				if (btdEntry != null)
				{
					br.BaseStream.Seek(btdEntry.Address, SeekOrigin.Begin);
					numBodyDefs = btdEntry.Length/4;
					hasLocation = true;
				}
			}

			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Body Type Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["BodyTypeDefs"].Offset, SeekOrigin.Begin);
			}

			// read pointer, go to address, read values, return to pointer list
			long curBodyTypePos = br.BaseStream.Position;

			for (int i = 0; i < numBodyDefs; i++)
			{
				byte[] bodytypePtr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(bodytypePtr);
				}
				curBodyTypePos = br.BaseStream.Position;
				UInt32 bodyTypePointer = BitConverter.ToUInt32(bodytypePtr, 0);

				// get data
				br.BaseStream.Seek(Z64Rom.PointerToRom(bodyTypePointer), SeekOrigin.Begin);
				this.BodyTypeDefs.Add(new BodyModelDef_Early(br));

				// next
				br.BaseStream.Seek(curBodyTypePos, SeekOrigin.Begin);
			}
		}

		/// <summary>
		/// Load WCW/nWo Revenge Costume Definitions.
		/// </summary>
		/// <param name="br"></param>
		private void LoadCostumeDefs(BinaryReader br)
		{
			bool hasLocation = false;
			int numCostumes = 147;

			if (Program.CurLocationFile != null)
			{
				LocationFileEntry cdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["CostumeDefs"]);
				if (cdEntry != null)
				{
					br.BaseStream.Seek(cdEntry.Address, SeekOrigin.Begin);

					switch (Program.CurrentProject.Settings.GameType)
					{
						case SpecificGame.Revenge_NTSC_U:
						case SpecificGame.Revenge_PAL:
							numCostumes = (cdEntry.Length / 4) - 1;
							break;
					}

					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Costume Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["CostumeDefs"].Offset, SeekOrigin.Begin);
			}

			// if you thought mask defs were a pain, this is worse.

			// each pointer in the main list goes to another list containing three pointers.
			// usually, the three pointers are the same, and we don't have to worry about anything.

			// $COSTUMEDEFS is a cheat, as it points to the first defined costume.
			// The main costume pointers work in reverse (the last pointer is
			// for the first set of costumes), so we don't use that.

			long curCostumePos = br.BaseStream.Position;

			for (int i = 0; i < numCostumes; i++)
			{
				byte[] cosPtr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(cosPtr);
				}
				curCostumePos = br.BaseStream.Position;
				UInt32 costumePointer = BitConverter.ToUInt32(cosPtr, 0);

				// main pointer has been read; now deal with the pointer at that location
				br.BaseStream.Seek(Z64Rom.PointerToRom(costumePointer), SeekOrigin.Begin);
				byte[] ccPtr = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ccPtr);
				}
				br.BaseStream.Seek(Z64Rom.PointerToRom(BitConverter.ToUInt32(ccPtr, 0)), SeekOrigin.Begin);
				this.CostumeDefs.Add(new GameSpecific.Revenge.CostumeDef(br));

				// next
				br.BaseStream.Seek(curCostumePos, SeekOrigin.Begin);
			}
		}

		/// <summary>
		/// Load Mask/Head Definitions.
		/// </summary>
		/// <param name="br"></param>
		private void LoadMaskDefs(BinaryReader br)
		{
			bool hasLocation = false;
			int numHeadDefs = 90;
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
				// fallback to hardcoded offset
				Program.InfoMessageBox("Head/Mask Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["HeadDefs"].Offset, SeekOrigin.Begin);
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

			// cheating helper:
			// maskdef list is pointers to first wrestler in group.
			// this pointer leads to the mask list pointer for that wrestler.
			long curMaskPointerPos = 0;
			for (int i = 0; i < numHeadDefs; i++)
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
		private void PopulateBodyTypes()
		{
			lbBodyTypes.Items.Clear();
			lbBodyTypes.BeginUpdate();
			for (int i = 0; i < BodyTypeDefs.Count; i++)
			{
				lbBodyTypes.Items.Add(String.Format("Body Type {0:X2}", i));
			}
			lbBodyTypes.EndUpdate();
		}

		/// <summary>
		/// Populate the Costumes listbox.
		/// </summary>
		private void PopulateCostumes()
		{
			lbCostumes.Items.Clear();
			lbCostumes.BeginUpdate();
			for (int i = 0; i < CostumeDefs.Count; i++)
			{
				lbCostumes.Items.Add(String.Format("Costume {0:X2}", i));
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
			for (int i = 0; i < MaskDefs.Count; i++)
			{
				lbHeadsMasks.Items.Add(String.Format("Mask {0:X2}", i));
			}
			lbHeadsMasks.EndUpdate();
		}
		#endregion

		/// <summary>
		/// Helper routine because I write a lot of the same looking code.
		/// </summary>
		/// <param name="tb">TextBox that gets updated.</param>
		/// <param name="value">File ID to be displayed in the text box.</param>
		private void SetTextBoxContentsHex4(TextBox tb, UInt16 value)
		{
			tb.Text = String.Format("{0:X4}", value);
		}

		/// <summary>
		/// Helper routine for loading a CI4 image.
		/// </summary>
		/// <param name="romStream">ROM stream to read data from.</param>
		/// <param name="pb">PictureBox to set the Image for.</param>
		/// <param name="palID">CI4 Palette file ID.</param>
		/// <param name="texID">CI4 Texture file ID.</param>
		private void LoadPreview_CI4(BinaryReader romStream, PictureBox pb, UInt16 palID, UInt16 texID, int subPalette = 0)
		{
			Ci4Palette previewPal = new Ci4Palette();
			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);
			BinaryReader palReader = new BinaryReader(palStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romStream, palWriter, palID);
			palStream.Seek(0, SeekOrigin.Begin);
			previewPal.ReadData(palReader, true);
			palStream.Dispose();

			Ci4Texture previewTex = new Ci4Texture();
			MemoryStream texStream = new MemoryStream();
			BinaryWriter texWriter = new BinaryWriter(texStream);
			BinaryReader texReader = new BinaryReader(texStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romStream, texWriter, texID);
			texStream.Seek(0, SeekOrigin.Begin);
			previewTex.ReadData(texReader);
			texStream.Dispose();

			pb.Image = previewTex.ToBitmap(previewPal, subPalette);
		}

		#region Body Types
		private void LoadBodyTypeDefinition(BodyModelDef_Early btdef)
		{
			SetTextBoxContentsHex4(tbPelvisModel, btdef.PelvisModel);
			SetTextBoxContentsHex4(tbStomachModel, btdef.StomachModel);
			SetTextBoxContentsHex4(tbChestModel, btdef.ChestModel);

			SetTextBoxContentsHex4(tbLeftLowerLegModel, btdef.LeftLowerLegModel);
			SetTextBoxContentsHex4(tbLeftUpperLegModel, btdef.LeftUpperLegModel);
			SetTextBoxContentsHex4(tbLeftFootModel, btdef.LeftFootModel);
			SetTextBoxContentsHex4(tbLeftPalmModel, btdef.LeftPalmModel);
			SetTextBoxContentsHex4(tbLeftFingersModel, btdef.LeftFingersModel);
			SetTextBoxContentsHex4(tbLeftForearmModel, btdef.LeftForearmModel);
			SetTextBoxContentsHex4(tbLeftUpperArmModel, btdef.LeftUpperArmModel);

			SetTextBoxContentsHex4(tbRightLowerLegModel, btdef.RightLowerLegModel);
			SetTextBoxContentsHex4(tbRightUpperLegModel, btdef.RightUpperLegModel);
			SetTextBoxContentsHex4(tbRightFootModel, btdef.RightFootModel);
			SetTextBoxContentsHex4(tbRightForearmModel, btdef.RightForearmModel);
			SetTextBoxContentsHex4(tbRightPalmModel, btdef.RightPalmModel);
			SetTextBoxContentsHex4(tbRightFingersModel, btdef.RightFingersModel);
			SetTextBoxContentsHex4(tbRightUpperArmModel, btdef.RightUpperArmModel);
		}

		private void lbBodyTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbBodyTypes.SelectedIndex < 0)
			{
				return;
			}

			LoadBodyTypeDefinition(BodyTypeDefs[lbBodyTypes.SelectedIndex]);
		}
		#endregion

		#region Costumes
		private void LoadCostumeDefinition(GameSpecific.Revenge.CostumeDef cdef)
		{
			// lots of shit.
			tbCostumeUnknown.Text = String.Format("{0:X2}", cdef.Unknown);
			tbBodyType.Text = String.Format("{0:X2} ({1:X2})", cdef.BodyType, cdef.BodyType & 0x7F);

			SetTextBoxContentsHex4(tbPelvisPalette, cdef.PelvisPalette);
			SetTextBoxContentsHex4(tbPelvisTexture, cdef.PelvisTexture);
			SetTextBoxContentsHex4(tbStomachPalette, cdef.StomachPalette);
			SetTextBoxContentsHex4(tbStomachTexture, cdef.StomachTexture);
			SetTextBoxContentsHex4(tbChestPalette, cdef.ChestPalette);
			SetTextBoxContentsHex4(tbChestTexture, cdef.ChestTexture);

			SetTextBoxContentsHex4(tbLeftBootPalette, cdef.LeftBootPalette);
			SetTextBoxContentsHex4(tbLeftBootTexture, cdef.LeftBootTexture);
			SetTextBoxContentsHex4(tbLeftLegPalette, cdef.LeftLegPalette);
			SetTextBoxContentsHex4(tbLeftLegTexture, cdef.LeftLegTexture);
			SetTextBoxContentsHex4(tbLeftFootPalette, cdef.LeftFootPalette);
			SetTextBoxContentsHex4(tbLeftFootTexture, cdef.LeftFootTexture);
			SetTextBoxContentsHex4(tbLeftPalmPalette, cdef.LeftPalmPalette);
			SetTextBoxContentsHex4(tbLeftPalmTexture, cdef.LeftPalmTexture);
			SetTextBoxContentsHex4(tbLeftFingersPalette, cdef.LeftFingersPalette);
			SetTextBoxContentsHex4(tbLeftFingersTexture, cdef.LeftFingersTexture);
			SetTextBoxContentsHex4(tbLeftForearmPalette, cdef.LeftForearmPalette);
			SetTextBoxContentsHex4(tbLeftForearmTexture, cdef.LeftForearmTexture);
			SetTextBoxContentsHex4(tbLeftUpperArmPalette, cdef.LeftUpperArmPalette);
			SetTextBoxContentsHex4(tbLeftUpperArmTexture, cdef.LeftUpperArmTexture);

			SetTextBoxContentsHex4(tbRightBootPalette, cdef.RightBootPalette);
			SetTextBoxContentsHex4(tbRightBootTexture, cdef.RightBootTexture);
			SetTextBoxContentsHex4(tbRightLegPalette, cdef.RightLegPalette);
			SetTextBoxContentsHex4(tbRightLegTexture, cdef.RightLegTexture);
			SetTextBoxContentsHex4(tbRightFootPalette, cdef.RightFootPalette);
			SetTextBoxContentsHex4(tbRightFootTexture, cdef.RightFootTexture);
			SetTextBoxContentsHex4(tbRightForearmPalette, cdef.RightForearmPalette);
			SetTextBoxContentsHex4(tbRightForearmTexture, cdef.RightForearmTexture);
			SetTextBoxContentsHex4(tbRightPalmPalette, cdef.RightPalmPalette);
			SetTextBoxContentsHex4(tbRightPalmTexture, cdef.RightPalmTexture);
			SetTextBoxContentsHex4(tbRightFingersPalette, cdef.RightFingersPalette);
			SetTextBoxContentsHex4(tbRightFingersTexture, cdef.RightFingersTexture);
			SetTextBoxContentsHex4(tbRightUpperArmPalette, cdef.RightUpperArmPalette);
			SetTextBoxContentsHex4(tbRightUpperArmTexture, cdef.RightUpperArmTexture);

			// drawing textures is fun, not!!
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			LoadPreview_CI4(romReader, pbPelvis, cdef.PelvisPalette, cdef.PelvisTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbStomach, cdef.StomachPalette, cdef.StomachTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbChest, cdef.ChestPalette, cdef.ChestTexture, (Costume_UseSubpalette ? 1 : 0));

			LoadPreview_CI4(romReader, pbLeftBoot, cdef.LeftBootPalette, cdef.LeftBootTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbLeftLeg, cdef.LeftLegPalette, cdef.LeftLegTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbLeftFoot, cdef.LeftFootPalette, cdef.LeftFootTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbLeftPalm, cdef.LeftPalmPalette, cdef.LeftPalmTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbLeftFingers, cdef.LeftFingersPalette, cdef.LeftFingersTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbLeftForearm, cdef.LeftForearmPalette, cdef.LeftForearmTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbLeftUpperArm, cdef.LeftUpperArmPalette, cdef.LeftUpperArmTexture, (Costume_UseSubpalette ? 1 : 0));

			LoadPreview_CI4(romReader, pbRightBoot, cdef.RightBootPalette, cdef.RightBootTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbRightLeg, cdef.RightLegPalette, cdef.RightLegTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbRightFoot, cdef.RightFootPalette, cdef.RightFootTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbRightPalm, cdef.RightPalmPalette, cdef.RightPalmTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbRightFingers, cdef.RightFingersPalette, cdef.RightFingersTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbRightForearm, cdef.RightForearmPalette, cdef.RightForearmTexture, (Costume_UseSubpalette ? 1 : 0));
			LoadPreview_CI4(romReader, pbRightUpperArm, cdef.RightUpperArmPalette, cdef.RightUpperArmTexture, (Costume_UseSubpalette ? 1 : 0));

			romReader.Close();
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
			SetTextBoxContentsHex4(tbNeckModel, mdef.NeckModel);
			SetTextBoxContentsHex4(tbNeckPalette, mdef.NeckPalette);
			SetTextBoxContentsHex4(tbNeckTexture, mdef.NeckTexture);

			SetTextBoxContentsHex4(tbFaceModel, mdef.HeadModel);
			SetTextBoxContentsHex4(tbFacePalette, mdef.HeadPalette);
			SetTextBoxContentsHex4(tbFaceTexture, mdef.HeadTexture);

			SetTextBoxContentsHex4(tbExtraModel, mdef.ExtraModel);
			SetTextBoxContentsHex4(tbExtraPalette, mdef.ExtraPalette);
			SetTextBoxContentsHex4(tbExtraTexture, mdef.ExtraTexture);

			SetTextBoxContentsHex4(tbRipMaskPalette, mdef.RippedMaskPalette);
			SetTextBoxContentsHex4(tbRipMaskTexture, mdef.RippedMaskTexture);
			SetTextBoxContentsHex4(tbSkinColor, mdef.SkinColor);

			// load textures and palettes
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// neck is usually CI4, but not always...
			// xxx: hacky; this needs to be determined in a better way.
			MemoryStream neckPalStream = new MemoryStream();
			BinaryWriter neckPalWriter = new BinaryWriter(neckPalStream);
			BinaryReader neckPalReader = new BinaryReader(neckPalStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, neckPalWriter, mdef.NeckPalette);

			MemoryStream neckTexStream = new MemoryStream();
			BinaryWriter neckTexWriter = new BinaryWriter(neckTexStream);
			BinaryReader neckTexReader = new BinaryReader(neckTexStream);
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, neckTexWriter, mdef.NeckTexture);

			if (neckPalWriter.BaseStream.Position == 0x200)
			{
				// CI8
				neckPalStream.Seek(0, SeekOrigin.Begin);
				Ci8Palette neckPal = new Ci8Palette();
				neckPal.ReadData(neckPalReader);
				neckPalStream.Dispose();
				Ci8Texture neckTex = new Ci8Texture();

				neckTexStream.Seek(0, SeekOrigin.Begin);
				neckTex.ReadData(neckTexReader);
				neckTexStream.Dispose();
				pbNeck.Image = neckTex.ToBitmap(neckPal);
			}
			else
			{
				// CI4
				neckPalStream.Seek(0, SeekOrigin.Begin);
				Ci4Palette neckPal = new Ci4Palette();
				neckPal.ReadData(neckPalReader);
				neckPalStream.Dispose();
				Ci4Texture neckTex = new Ci4Texture();

				neckTexStream.Seek(0, SeekOrigin.Begin);
				neckTex.ReadData(neckTexReader);
				neckTexStream.Dispose();
				pbNeck.Image = neckTex.ToBitmap(neckPal);
			}

			// face is usually CI8, but not always.
			// WCW/nWo Revenge CI4 entries: 60, 106
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
				pbFace.Image = faceTex.ToBitmap(facePal);
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
				pbFace.Image = faceTex.ToBitmap(facePal);
			}

			// extra is either CI4 or CI8
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

					pbExtra.Image = extraTex.ToBitmap(extraPal);
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

					pbExtra.Image = extraTex.ToBitmap(extraPal);
				}
			}
			else
			{
				pbExtra.Image = null;
			}

			// ripped mask is probably CI8
			if (mdef.RippedMaskPalette != 0 && mdef.RippedMaskTexture != 0)
			{
				MemoryStream ripMaskPalStream = new MemoryStream();
				BinaryWriter ripMaskPalWriter = new BinaryWriter(ripMaskPalStream);
				BinaryReader ripMaskPalReader = new BinaryReader(ripMaskPalStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, ripMaskPalWriter, mdef.RippedMaskPalette);

				MemoryStream ripMaskTexStream = new MemoryStream();
				BinaryWriter ripMaskTexWriter = new BinaryWriter(ripMaskTexStream);
				BinaryReader ripMaskTexReader = new BinaryReader(ripMaskTexStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, ripMaskTexWriter, mdef.RippedMaskTexture);

				if (ripMaskPalWriter.BaseStream.Position == 0x200)
				{
					// CI8
					ripMaskPalStream.Seek(0, SeekOrigin.Begin);
					Ci8Palette ripMaskPal = new Ci8Palette();
					ripMaskPal.ReadData(ripMaskPalReader);
					ripMaskPalStream.Dispose();
					Ci8Texture ripMaskTex = new Ci8Texture();

					ripMaskTexStream.Seek(0, SeekOrigin.Begin);
					ripMaskTex.ReadData(ripMaskTexReader);
					ripMaskTexStream.Dispose();
					pbRippedMask.Image = ripMaskTex.ToBitmap(ripMaskPal);
				}
				else
				{
					// CI4
					ripMaskPalStream.Seek(0, SeekOrigin.Begin);
					Ci4Palette ripMaskPal = new Ci4Palette();
					ripMaskPal.ReadData(ripMaskPalReader);
					ripMaskPalStream.Dispose();
					Ci4Texture ripMaskTex = new Ci4Texture();

					ripMaskTexStream.Seek(0, SeekOrigin.Begin);
					ripMaskTex.ReadData(ripMaskTexReader);
					ripMaskTexStream.Dispose();
					pbRippedMask.Image = ripMaskTex.ToBitmap(ripMaskPal);
				}
			}
			else
			{
				pbRippedMask.Image = null;
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

		/// <summary>
		/// Toggle the use of the subpalette for Costume items.
		/// </summary>
		private void cbCostumesAltPalette_Click(object sender, EventArgs e)
		{
			Costume_UseSubpalette = cbCostumesAltPalette.Checked;

			if (lbCostumes.SelectedIndex < 0)
			{
				return;
			}

			LoadCostumeDefinition(CostumeDefs[lbCostumes.SelectedIndex]);
		}

		
	}
}
