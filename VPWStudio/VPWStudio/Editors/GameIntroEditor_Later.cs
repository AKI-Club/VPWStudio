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

		public bool AnyChangesSubmitted = false;

		public GameIntroEditor_Later()
		{
			InitializeComponent();

			IntroAnimations = new List<IntroSequenceAnimation_Later>();
			IntroImages = new List<IntroSequenceGraphic_Later>();
			IntroSequenceItems = new List<IntroSequence_Later>();

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

			uint animLocation = 0;
			int numAnims = 0;

			uint imgLocation = 0;
			int numImages = 0;

			uint seqLocation = 0;
			int numSeqEntries = 0;

			// xxx: non-image values don't take the credits sequence into account
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry animEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_Anims"]);
				if (animEntry != null)
				{
					animLocation = animEntry.Address;
					numAnims = animEntry.Length / 20;
					hasAnimLocation = true;
				}

				LocationFileEntry imgEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_Images"]);
				if (imgEntry != null)
				{
					imgLocation = imgEntry.Address;
					numImages = imgEntry.Length / 16;
					hasImageLocation = true;
				}

				LocationFileEntry seqEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_Later_Sequence"]);
				if (seqEntry != null)
				{
					seqLocation = seqEntry.Address;
					numSeqEntries = seqEntry.Length / 28;
					hasSeqLocation = true;
				}
			}

			// if no values were found in the location file, use hardcoded values
			// xxx: these are VPW2 specific!! use Program.CurrentProject.Settings.GameType
			if (!hasAnimLocation)
			{
				DefaultGameData.DefaultLocationDataEntry anims = DefaultGameData.GetEntry(SpecificGame.VPW2_NTSC_J, "IntroDefs_Later_Anims");
				animLocation = anims.Offset; // 0x7C710
				numAnims = (int)(anims.Length / 20); // 218;
			}

			if (!hasImageLocation)
			{
				DefaultGameData.DefaultLocationDataEntry imgs = DefaultGameData.GetEntry(SpecificGame.VPW2_NTSC_J, "IntroDefs_Later_Images");
				imgLocation = imgs.Offset; // 0x7DEA8;
				numImages = (int)(imgs.Length / 16); // 12;
			}

			if (!hasSeqLocation)
			{
				DefaultGameData.DefaultLocationDataEntry seqs = DefaultGameData.GetEntry(SpecificGame.VPW2_NTSC_J, "IntroDefs_Later_Sequence");
				seqLocation = seqs.Offset; // 0x7E098;
				numSeqEntries = (int)(seqs.Length / 28); // 81;
			}

			// FINALLY get to reading the damned data
			ms.Seek(animLocation, SeekOrigin.Begin);
			for (int i = 0; i < numAnims; i++)
			{
				IntroAnimations.Add(new IntroSequenceAnimation_Later(br));
			}

			ms.Seek(imgLocation, SeekOrigin.Begin);
			for (int i = 0; i < numImages; i++)
			{
				IntroImages.Add(new IntroSequenceGraphic_Later(br));
			}

			ms.Seek(seqLocation, SeekOrigin.Begin);
			for (int i = 0; i < numSeqEntries; i++)
			{
				IntroSequenceItems.Add(new IntroSequence_Later(br));
			}

			br.Close();

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
	}
}
