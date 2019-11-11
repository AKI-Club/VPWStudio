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
	public partial class GameIntroEditor_Later : Form
	{
		public List<IntroSequenceAnimation_Later> IntroAnimations = new List<IntroSequenceAnimation_Later>();
		public List<IntroSequenceGraphic_Later> IntroImages = new List<IntroSequenceGraphic_Later>();
		public List<IntroSequence_Later> IntroSequenceItems = new List<IntroSequence_Later>();

		public GameIntroEditor_Later()
		{
			InitializeComponent();
			LoadIntroData();
		}

		private void LoadIntroData()
		{
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
			if (!hasAnimLocation)
			{
				animLocation = 0x7C710;
				numAnims = 218;
			}

			if (!hasImageLocation)
			{
				imgLocation = 0x7DEA8;
				numImages = 12;
			}

			if (!hasSeqLocation)
			{
				seqLocation = 0x7E098;
				numSeqEntries = 81;
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

			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
