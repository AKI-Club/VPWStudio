using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class AnimTest : Form
	{
		public AkiAnimation CurAnim = new AkiAnimation();

		public AnimTest(int fileID)
		{
			InitializeComponent();
			Text = String.Format("AnimTest - File {0:X4}", fileID);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream animStream = new MemoryStream();
			BinaryWriter animWriter = new BinaryWriter(animStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, animWriter, fileID);
			romReader.Close();

			animStream.Seek(0, SeekOrigin.Begin);
			BinaryReader br = new BinaryReader(animStream);
			CurAnim.ReadData(br);
			br.Close();

			cbFrames.Items.Clear();
			cbFrames.BeginUpdate();
			for (int i = 0; i < CurAnim.FrameData.Count; i++)
			{
				cbFrames.Items.Add(i);
			}
			cbFrames.EndUpdate();

			tbToki2.Text = String.Format("{0:X2} {1:X2} {2:X2} {3:X2}", CurAnim.Toki2[0], CurAnim.Toki2[1], CurAnim.Toki2[2], CurAnim.Toki2[3]);

			dgvFrameData.Rows.Add(26);
			dgvFrameData.Rows[0].Cells[0].Value = "Pelvis";
			dgvFrameData.Rows[1].Cells[0].Value = "Overall Movement";
			dgvFrameData.Rows[2].Cells[0].Value = "Lower Abs";
			dgvFrameData.Rows[3].Cells[0].Value = "Lower Abs Movement";
			dgvFrameData.Rows[4].Cells[0].Value = "Upper Body";
			dgvFrameData.Rows[5].Cells[0].Value = "Upper Body Movement";
			dgvFrameData.Rows[6].Cells[0].Value = "Neck";
			dgvFrameData.Rows[7].Cells[0].Value = "Head";
			dgvFrameData.Rows[8].Cells[0].Value = "Lower Left Leg";
			dgvFrameData.Rows[9].Cells[0].Value = "Upper Left Leg";
			dgvFrameData.Rows[10].Cells[0].Value = "Left Leg Movement";
			dgvFrameData.Rows[11].Cells[0].Value = "Left Foot";
			dgvFrameData.Rows[12].Cells[0].Value = "Left Hand";
			dgvFrameData.Rows[13].Cells[0].Value = "Left Fingers";
			dgvFrameData.Rows[14].Cells[0].Value = "Lower Left Arm";
			dgvFrameData.Rows[15].Cells[0].Value = "Upper Left Arm";
			dgvFrameData.Rows[16].Cells[0].Value = "Left Arm Movement";
			dgvFrameData.Rows[17].Cells[0].Value = "Lower Right Leg";
			dgvFrameData.Rows[18].Cells[0].Value = "Upper Right Leg";
			dgvFrameData.Rows[19].Cells[0].Value = "Right Leg Movement";
			dgvFrameData.Rows[20].Cells[0].Value = "Right Foot";
			dgvFrameData.Rows[21].Cells[0].Value = "Lower Right Arm";
			dgvFrameData.Rows[22].Cells[0].Value = "Right Hand";
			dgvFrameData.Rows[23].Cells[0].Value = "Right Fingers";
			dgvFrameData.Rows[24].Cells[0].Value = "Upper Right Arm";
			dgvFrameData.Rows[25].Cells[0].Value = "Right Arm Movement";

			cbFrames.SelectedIndex = 0;
		}

		private void SetRowData(int row, object j)
		{
			string type = j.GetType().ToString();
			int val1, val2, val3;
			switch (type)
			{
				case "VPWStudio.PivotRotation":
					{
						PivotRotation p = (PivotRotation)j;
						val1 = p.PivotX;
						val2 = p.Rotation;
						val3 = p.PivotZ;
					}
					break;
				case "VPWStudio.MovementXYZ":
					{
						MovementXYZ m = (MovementXYZ)j;
						val1 = m.X;
						val2 = m.Y;
						val3 = m.Z;
					}
					break;
				case "VPWStudio.OverallMovementXYZ":
					{
						OverallMovementXYZ o = (OverallMovementXYZ)j;
						val1 = o.OverallX;
						val2 = o.OverallY;
						val3 = o.OverallZ;
					}
					break;
				default:
					{
						val1 = 0;
						val2 = 0;
						val3 = 0;
					}
					break;
			}

			dgvFrameData.Rows[row].Cells[1].Value = String.Format("0x{0:X} ({0})", val1);
			dgvFrameData.Rows[row].Cells[2].Value = String.Format("0x{0:X} ({0})", val2);
			dgvFrameData.Rows[row].Cells[3].Value = String.Format("0x{0:X} ({0})", val3);
		}

		private void UpdateFrameData()
		{
			AnimationFrame f = CurAnim.FrameData[cbFrames.SelectedIndex];
			SetRowData(0, f.Pelvis);
			SetRowData(1, f.OverallMovement);
			SetRowData(2, f.LowerAb);
			SetRowData(3, f.LowerAbMovement);
			SetRowData(4, f.UpperBody);
			SetRowData(5, f.UpperBodyMovement);
			SetRowData(6, f.Neck);
			SetRowData(7, f.Head);
			SetRowData(8, f.LowerLeftLeg);
			SetRowData(9, f.UpperLeftLeg);
			SetRowData(10, f.LeftLegMovement);
			SetRowData(11, f.LeftFoot);
			SetRowData(12, f.LeftHand);
			SetRowData(13, f.LeftFingers);
			SetRowData(14, f.LowerLeftArm);
			SetRowData(15, f.UpperLeftArm);
			SetRowData(16, f.LeftArmMovement);
			SetRowData(17, f.LowerRightLeg);
			SetRowData(18, f.UpperRightLeg);
			SetRowData(19, f.RightLegMovement);
			SetRowData(20, f.RightFoot);
			SetRowData(21, f.LowerRightArm);
			SetRowData(22, f.RightHand);
			SetRowData(23, f.RightFingers);
			SetRowData(24, f.UpperRightArm);
			SetRowData(25, f.RightArmMovement);
		}

		private void cbFrames_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFrames.SelectedIndex < 0)
			{
				return;
			}
			UpdateFrameData();
		}
	}
}
