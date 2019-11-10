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

			for (int i = 0; i < IntroAnimations.Count; i++)
			{
				IntroSequenceAnimation_Later curAnim = IntroAnimations[i];
				tbAnimations.AppendText(string.Format("[anim {0:D3}]\n",i));
				tbAnimations.AppendText(string.Format("wrestler ID4: 0x{0:X4}\n",curAnim.WrestlerID4));
				tbAnimations.AppendText(string.Format("timing A: {0}\n",curAnim.TimingA));
				tbAnimations.AppendText(string.Format("animation ID: 0x{0:X4}\n",curAnim.AnimationID));
				tbAnimations.AppendText(string.Format("timing B: {0}\n",curAnim.TimingB));
				tbAnimations.AppendText(string.Format("x pos: 0x{0:X4}\n",curAnim.XPosition));
				tbAnimations.AppendText(string.Format("y pos: 0x{0:X4}\n",curAnim.YPosition));
				tbAnimations.AppendText(string.Format("z pos: 0x{0:X4}\n",curAnim.ZPosition));
				tbAnimations.AppendText(string.Format("rotation: 0x{0:X4}\n",curAnim.Rotation));
				tbAnimations.AppendText(string.Format("flags: 0x{0:X2}\n", curAnim.AnimFlags));
				tbAnimations.AppendText(string.Format("move speed: 0x{0:X2}\n", curAnim.MoveSpeed));
				tbAnimations.AppendText(string.Format("unknown: 0x{0:X2}\n", curAnim.Unknown));
				tbAnimations.AppendText(string.Format("costume number: 0x{0:X2}\n", curAnim.CostumeNum));
				tbAnimations.AppendText("\n");
			}
			tbAnimations.ReadOnly = true;

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

				tbImages.AppendText(string.Format("[image {0}]\n", i));
				tbImages.AppendText(string.Format("File ID: 0x{0:X4}\n", curImage.FileID));
				tbImages.AppendText(string.Format("Width: {0}\n", curImage.Width));
				tbImages.AppendText(string.Format("Height: {0}\n", curImage.Height));
				tbImages.AppendText(string.Format("Vertical Displacement: {0}\n", curImage.VertDisplacement));
				tbImages.AppendText(string.Format("Horizontal Stretch: {0}\n", curImage.HorizStretch));
				tbImages.AppendText(string.Format("Flags: 0x{0:X2}\n", curImage.Flags1));
				tbImages.AppendText(string.Format("Scroll Speed: 0x{0:X2}\n", curImage.ScrollSpeed));
				tbImages.AppendText(string.Format("Unknown: 0x{0:X2}\n", curImage.Unknown));
				tbImages.AppendText("\n");

				
			}
			tbImages.ReadOnly = true;

			for (int i = 0; i < IntroSequenceItems.Count; i++)
			{
				IntroSequence_Later curSeq = IntroSequenceItems[i];
				tbSequence.AppendText(string.Format("[seq entry {0:D3}]\n", i));
				tbSequence.AppendText(string.Format("main sequence number 0x{0:X2}\n", curSeq.MainSequence));
				tbSequence.AppendText(string.Format("sub sequence number 0x{0:X2}\n", curSeq.SubSequence));
				tbSequence.AppendText(string.Format("flags 0x{0:X2}\n", curSeq.Flags));
				tbSequence.AppendText(string.Format("transition 0x{0:X2}\n", curSeq.Transition));
				tbSequence.AppendText(string.Format("scene time {0}\n", curSeq.SceneTime));
				tbSequence.AppendText(string.Format("camera motion 0x{0:X4}\n", curSeq.CameraMotion));
				tbSequence.AppendText(string.Format("unknown 0x{0:X4}\n", curSeq.Unknown));
				tbSequence.AppendText(string.Format("stage number 0x{0:X4}\n", curSeq.StageNum));
				tbSequence.AppendText(string.Format("pointer 1 0x{0:X8}\n", curSeq.Pointer1));
				tbSequence.AppendText(string.Format("pointer 2 0x{0:X8}\n", curSeq.Pointer2));
				tbSequence.AppendText(string.Format("pointer 3 0x{0:X8}\n", curSeq.Pointer3));
				tbSequence.AppendText(string.Format("pointer 4 0x{0:X8}\n", curSeq.Pointer4));
				tbSequence.AppendText("\n");
			}
			tbSequence.ReadOnly = true;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			// ugh I have to parse a DataGridView again?? fuck.

			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
