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

namespace VPWStudio
{
	/// <summary>
	/// Game introduction sequence editor for WCW/nWo Revenge and later.
	/// </summary>
	/// todo: in the future, this may handle the ending sequence for WM2K, VPW2, and No Mercy?
	public partial class GameIntroEditor_Later : Form
	{
		/// <summary>
		/// Introduction animation entries
		/// </summary>
		public List<IntroSequenceAnimation_Later> IntroAnimations;

		/// <summary>
		/// Introduction image entries
		/// </summary>
		public List<IntroSequenceGraphic_Later> IntroImages;

		/// <summary>
		/// Introduction sequence entries
		/// </summary>
		public List<IntroSequence_Later> IntroSequenceItems;

		/// <summary>
		/// Camera motion entries
		/// </summary>
		public List<CameraDef> CameraMotionDefs;

		public bool AnyChangesSubmitted = false;

		/// <summary>
		/// Starting ROM address of the animation entries.
		/// </summary>
		private uint AnimStartLocation;

		/// <summary>
		/// Starting ROM address of the image entries.
		/// </summary>
		private uint ImgStartLocation;

		/// <summary>
		/// Starting ROM address of the sequence entries.
		/// </summary>
		private uint SeqStartLocation;

		/// <summary>
		/// Starting ROM address of the camera motion data.
		/// </summary>
		private uint CameraMotionStartLocation;

		private StringBuilder StrBuilder;

		public GameIntroEditor_Later()
		{
			InitializeComponent();

			IntroAnimations = new List<IntroSequenceAnimation_Later>();
			IntroImages = new List<IntroSequenceGraphic_Later>();
			IntroSequenceItems = new List<IntroSequence_Later>();
			CameraMotionDefs = new List<CameraDef>();
			StrBuilder = new StringBuilder();

			LoadIntroData();
		}

		private void LoadIntroData()
		{
			Program.ReloadBaseRom();
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasAnimLocation = false;
			bool hasImageLocation = false;
			bool hasSeqLocation = false;
			bool hasCameraMotionLocation = false;

			AnimStartLocation = 0;
			int numAnims = 0;

			ImgStartLocation = 0;
			int numImages = 0;

			SeqStartLocation = 0;
			int numSeqEntries = 0;

			CameraMotionStartLocation = 0;
			int numCameraMotionDefs = 0;

			// xxx: non-image values don't take the credits sequence into account
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry animEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_Anims"]);
				if (animEntry != null)
				{
					AnimStartLocation = animEntry.Address;
					numAnims = animEntry.Length / 20;
					hasAnimLocation = true;
				}

				LocationFileEntry imgEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_Images"]);
				if (imgEntry != null)
				{
					ImgStartLocation = imgEntry.Address;
					numImages = imgEntry.Length / 16;
					hasImageLocation = true;
				}

				LocationFileEntry seqEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_Sequence"]);
				if (seqEntry != null)
				{
					SeqStartLocation = seqEntry.Address;
					numSeqEntries = seqEntry.Length / 28;
					hasSeqLocation = true;
				}

				LocationFileEntry camEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_CameraMotion"]);
				if (camEntry != null)
				{
					CameraMotionStartLocation = camEntry.Address;
					numCameraMotionDefs = camEntry.Length / 8;
					hasCameraMotionLocation = true;
				}
			}

			// if no values were found in the location file, use hardcoded values
			if (!hasAnimLocation)
			{
				DefaultGameData.DefaultLocationDataEntry anims = DefaultGameData.GetEntry(Program.CurrentProject.Settings.GameType, "IntroDefs_Later_Anims");
				if (anims != null)
				{
					AnimStartLocation = anims.Offset; // 0x7C710
					numAnims = (int)(anims.Length / 20); // 218;
					hasAnimLocation = true;
				}
			}

			if (!hasImageLocation)
			{
				DefaultGameData.DefaultLocationDataEntry imgs = DefaultGameData.GetEntry(Program.CurrentProject.Settings.GameType, "IntroDefs_Later_Images");
				if (imgs != null)
				{
					ImgStartLocation = imgs.Offset; // 0x7DEA8;
					numImages = (int)(imgs.Length / 16); // 12;
					hasImageLocation = true;
				}
			}

			if (!hasSeqLocation)
			{
				DefaultGameData.DefaultLocationDataEntry seqs = DefaultGameData.GetEntry(Program.CurrentProject.Settings.GameType, "IntroDefs_Later_Sequence");
				if (seqs != null)
				{
					SeqStartLocation = seqs.Offset; // 0x7E098;
					numSeqEntries = (int)(seqs.Length / 28); // 81;
					hasSeqLocation = true;
				}
			}

			if (!hasCameraMotionLocation)
			{
                DefaultGameData.DefaultLocationDataEntry cams = DefaultGameData.GetEntry(Program.CurrentProject.Settings.GameType, "IntroDefs_Later_CameraMotion");
				if (cams != null)
				{
					CameraMotionStartLocation = cams.Offset;
					numCameraMotionDefs = (int)(cams.Length / 8);
					hasCameraMotionLocation = true;
				}
            }

			// FINALLY get to reading the damned data
			if (hasAnimLocation)
			{
				ms.Seek(AnimStartLocation, SeekOrigin.Begin);
				for (int i = 0; i < numAnims; i++)
				{
					IntroAnimations.Add(new IntroSequenceAnimation_Later(br));
				}
			}

			if(hasImageLocation)
			{
				ms.Seek(ImgStartLocation, SeekOrigin.Begin);
				for (int i = 0; i < numImages; i++)
				{
					IntroImages.Add(new IntroSequenceGraphic_Later(br));
				}
			}

			if (hasSeqLocation)
			{
				ms.Seek(SeqStartLocation, SeekOrigin.Begin);
				for (int i = 0; i < numSeqEntries; i++)
				{
					IntroSequenceItems.Add(new IntroSequence_Later(br));
				}
			}

			if (hasCameraMotionLocation)
			{
                ms.Seek(CameraMotionStartLocation, SeekOrigin.Begin);
				for (int i = 0; i < numCameraMotionDefs; i++)
				{
					CameraMotionDefs.Add(new CameraDef(br));
					cbCameraMotionList.Items.Add(string.Format("Entry {0}",i));
				}
            }


			br.Close();
			PopulateRows(hasAnimLocation, hasImageLocation, hasSeqLocation);
		}

		private void PopulateRows(bool _anim, bool _img, bool _seq)
		{
			if (_anim)
			{
				dgvAnimations.Rows.Add(IntroAnimations.Count);
				for (int i = 0; i < IntroAnimations.Count; i++)
				{
					IntroSequenceAnimation_Later curAnim = IntroAnimations[i];
					dgvAnimations.Rows[i].Cells[0].Value = string.Format("{0:X4}", curAnim.WrestlerID4);
					dgvAnimations.Rows[i].Cells[1].Value = curAnim.TimingA;
					dgvAnimations.Rows[i].Cells[2].Value = string.Format("{0:X4}", curAnim.AnimationID);
					dgvAnimations.Rows[i].Cells[3].Value = curAnim.TimingB;
					dgvAnimations.Rows[i].Cells[4].Value = curAnim.XPosition;
					dgvAnimations.Rows[i].Cells[5].Value = curAnim.YPosition;
					dgvAnimations.Rows[i].Cells[6].Value = curAnim.ZPosition;
					dgvAnimations.Rows[i].Cells[7].Value = curAnim.Rotation;
					dgvAnimations.Rows[i].Cells[8].Value = string.Format("{0:X2}", curAnim.AnimFlags);
					dgvAnimations.Rows[i].Cells[9].Value = string.Format("{0:X2}", curAnim.MoveSpeed);
					dgvAnimations.Rows[i].Cells[10].Value = string.Format("{0:X2}", curAnim.Unknown);
					dgvAnimations.Rows[i].Cells[11].Value = string.Format("{0:X2}", curAnim.CostumeNum);
				}
			}

			if (_img)
			{
				dgvImages.Rows.Add(IntroImages.Count);
				for (int i = 0; i < IntroImages.Count; i++)
				{
					IntroSequenceGraphic_Later curImage = IntroImages[i];
					dgvImages.Rows[i].Cells[0].Value = string.Format("{0:X4}", curImage.FileID);
					dgvImages.Rows[i].Cells[1].Value = curImage.Width;
					dgvImages.Rows[i].Cells[2].Value = curImage.Height;
					dgvImages.Rows[i].Cells[3].Value = curImage.VertDisplacement;
					dgvImages.Rows[i].Cells[4].Value = curImage.HorizStretch;
					dgvImages.Rows[i].Cells[5].Value = string.Format("{0:X2}", curImage.Flags1);
					dgvImages.Rows[i].Cells[6].Value = curImage.ScrollSpeed;
					dgvImages.Rows[i].Cells[7].Value = string.Format("{0:X2}", curImage.Unknown);
				}
			}

			if (_seq)
			{
				dgvSequence.Rows.Add(IntroSequenceItems.Count);
				for (int i = 0; i < IntroSequenceItems.Count; i++)
				{
					IntroSequence_Later curSeq = IntroSequenceItems[i];
					dgvSequence.Rows[i].Cells[0].Value = curSeq.MainSequence;
					dgvSequence.Rows[i].Cells[1].Value = curSeq.SubSequence;
					dgvSequence.Rows[i].Cells[2].Value = string.Format("{0:X2}", curSeq.Flags);
					dgvSequence.Rows[i].Cells[3].Value = string.Format("{0:X2}", curSeq.Transition);
					dgvSequence.Rows[i].Cells[4].Value = curSeq.SceneTime;
					dgvSequence.Rows[i].Cells[5].Value = string.Format("{0:X2}", curSeq.CameraMotion);
					dgvSequence.Rows[i].Cells[6].Value = string.Format("{0:X4}", curSeq.Unknown);
					dgvSequence.Rows[i].Cells[7].Value = string.Format("{0:X4}", curSeq.StageNum);
					dgvSequence.Rows[i].Cells[8].Value = string.Format("{0:X8}", curSeq.Pointer1);
					dgvSequence.Rows[i].Cells[9].Value = string.Format("{0:X8}", curSeq.Pointer2);
					dgvSequence.Rows[i].Cells[10].Value = string.Format("{0:X8}", curSeq.Pointer3);
					dgvSequence.Rows[i].Cells[11].Value = string.Format("{0:X8}", curSeq.Pointer4);
				}
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			// ugh I have to parse DataGridViews again?? fuck.

			for (int i = 0; i < dgvAnimations.Rows.Count; i++)
			{
				// wrestler id4
				// timing a
				// animation id
				// timing b
				// xpos, ypos, zpos, rotation
				// flags, movespeed, unknown, costume
			}

			for (int i = 0; i < dgvImages.Rows.Count; i++)
			{
				// file id
				// width, height
				// vert. displacement
				// horiz. stretch
				// flags
				// scroll speed
				// unknown
			}

			for (int i = 0; i < dgvSequence.Rows.Count; i++)
			{
			}

			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			AnyChangesSubmitted = false; // shouldn't need this but just in case
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void dgvAnimations_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{

		}

		private void dgvImages_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{

		}

		private void dgvSequence_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{

		}

		private void btnReloadRom_Click(object sender, EventArgs e)
		{
			IntroAnimations.Clear();
			IntroImages.Clear();
			IntroSequenceItems.Clear();

			dgvAnimations.Rows.Clear();
			dgvImages.Rows.Clear();
			dgvSequence.Rows.Clear();
			LoadIntroData();
		}

		// todo: properly calculate the offsets

		private void dgvAnimations_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvAnimations.SelectedCells.Count <= 0)
			{
				tsslblCurAddressAnim.Text = "No Anim. cell selected";
			}
			else
			{
				// each row is 20 bytes
				// most entries are 2 bytes, except for the 4 bytes at the end (cols 8-11)
				int offset = dgvAnimations.SelectedCells[0].RowIndex * 20;
				if (dgvAnimations.SelectedCells[0].ColumnIndex >= 8)
				{
					// fixerator
					offset += 16 + (dgvAnimations.SelectedCells[0].ColumnIndex-8);
				}
				else
				{
					// 2 bytes
					offset += (dgvAnimations.SelectedCells[0].ColumnIndex*2);
				}

				tsslblCurAddressAnim.Text = String.Format("Anim. ROM Address: 0x{0:X}", AnimStartLocation+offset);
			}
		}

		private void dgvImages_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvImages.SelectedCells.Count <= 0)
			{
				tsslblCurAddressImg.Text = "No Image cell selected";
			}
			else
			{
				// each row is 16 bytes, each entry is 2 bytes
				int offset = (dgvImages.SelectedCells[0].RowIndex * 16) + (dgvImages.SelectedCells[0].ColumnIndex * 2);
				tsslblCurAddressImg.Text = String.Format("Image ROM Address: 0x{0:X}", ImgStartLocation+offset);
			}
		}

		private void dgvSequence_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvSequence.SelectedCells.Count <= 0)
			{
				tsslblCurAddressSeq.Text = "No Seq. cell selected";
			}
			else
			{
				// each row is 28 bytes
				int offset = dgvSequence.SelectedCells[0].RowIndex * 28;

				if (dgvSequence.SelectedCells[0].ColumnIndex <= 3)
				{
					// 4 bytes (cols 0-3)
					offset += dgvSequence.SelectedCells[0].ColumnIndex;
				}
				else if (dgvSequence.SelectedCells[0].ColumnIndex <= 7)
				{
					// add 4 bytes; 4*2 bytes (cols 4-7)
					offset += 4 + ((dgvSequence.SelectedCells[0].ColumnIndex-4)*2);
				}
				else
				{
					// add 12 bytes; 4*4 bytes (cols 8-11)
					offset += 12 + ((dgvSequence.SelectedCells[0].ColumnIndex - 8) * 4);
				}

				tsslblCurAddressSeq.Text = String.Format("Seq. ROM Address: 0x{0:X})", SeqStartLocation+offset);
			}
		}

        private void cbCameraMotionList_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (cbCameraMotionList.SelectedIndex < 0)
			{
				return;
			}

			int index = cbCameraMotionList.SelectedIndex;
			StrBuilder.Clear();
			StrBuilder.AppendLine(string.Format("Camera Motion Entry #{0} (Z64 ROM addr 0x{1:X})", index, CameraMotionStartLocation + (8*index)));

			StrBuilder.AppendLine(string.Format("Data Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].DataPointer, Program.PointerToRomAddr(CameraMotionDefs[index].DataPointer, 1)));
            StrBuilder.AppendLine(string.Format("Unknown Value: 0x{0:X4}", CameraMotionDefs[index].UnknownValue));
            StrBuilder.AppendLine(string.Format("Camera Motion ID: 0x{0:X4}", CameraMotionDefs[index].ID));
            StrBuilder.AppendLine();

            StrBuilder.AppendLine(string.Format("X Values Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].ValuePointerX, Program.PointerToRomAddr(CameraMotionDefs[index].ValuePointerX, 1)));
			foreach (CameraValuePair cvp in CameraMotionDefs[index].X)
			{
				StrBuilder.AppendLine(string.Format("value 0x{0:X2} ({0}) at frame 0x{1:X2} ({1})", cvp.Value, cvp.FrameNumber));
			}
            StrBuilder.AppendLine();

            StrBuilder.AppendLine(string.Format("Y Values Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].ValuePointerY, Program.PointerToRomAddr(CameraMotionDefs[index].ValuePointerY, 1)));
            foreach (CameraValuePair cvp in CameraMotionDefs[index].Y)
            {
                StrBuilder.AppendLine(string.Format("value 0x{0:X2} ({0}) at frame 0x{1:X2} ({1})", cvp.Value, cvp.FrameNumber));
            }
            StrBuilder.AppendLine();

            StrBuilder.AppendLine(string.Format("Z Values Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].ValuePointerZ, Program.PointerToRomAddr(CameraMotionDefs[index].ValuePointerZ, 1)));
            foreach (CameraValuePair cvp in CameraMotionDefs[index].Z)
            {
                StrBuilder.AppendLine(string.Format("value 0x{0:X2} ({0}) at frame 0x{1:X2} ({1})", cvp.Value, cvp.FrameNumber));
            }
            StrBuilder.AppendLine();

            StrBuilder.AppendLine(string.Format("Pitch Values Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].ValuePointerPitch, Program.PointerToRomAddr(CameraMotionDefs[index].ValuePointerPitch, 1)));
            foreach (CameraValuePair cvp in CameraMotionDefs[index].Pitch)
            {
                StrBuilder.AppendLine(string.Format("value 0x{0:X2} ({0}) at frame 0x{1:X2} ({1})", cvp.Value, cvp.FrameNumber));
            }
            StrBuilder.AppendLine();

            StrBuilder.AppendLine(string.Format("Pan Values Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].ValuePointerPan, Program.PointerToRomAddr(CameraMotionDefs[index].ValuePointerPan, 1)));
            foreach (CameraValuePair cvp in CameraMotionDefs[index].Pan)
            {
                StrBuilder.AppendLine(string.Format("value 0x{0:X2} ({0}) at frame 0x{1:X2} ({1})", cvp.Value, cvp.FrameNumber));
            }
            StrBuilder.AppendLine();

            StrBuilder.AppendLine(string.Format("Roll Values Pointer: 0x{0:X} (Z64 ROM addr 0x{1:X})", CameraMotionDefs[index].ValuePointerRoll, Program.PointerToRomAddr(CameraMotionDefs[index].ValuePointerRoll, 1)));
            foreach (CameraValuePair cvp in CameraMotionDefs[index].Roll)
            {
                StrBuilder.AppendLine(string.Format("value 0x{0:X2} ({0}) at frame 0x{1:X2} ({1})", cvp.Value, cvp.FrameNumber));
            }

            tbCameraMotion.Text = StrBuilder.ToString();
        }
    }
}
