using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
    public partial class MoveAnimPropTestDialog : Form
    {
        /// <summary>
        /// List of animation values.
        /// </summary>
        private List<short> Animations;

        /// <summary>
        /// List of animation properties.
        /// </summary>
        private List<short> Properties;

        public MoveAnimPropTestDialog()
        {
            InitializeComponent();
            LoadData();
            PopulateEntries();
        }

        private void LoadData()
        {
            MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
            BinaryReader romReader = new BinaryReader(romStream);

            MemoryStream animStream = new MemoryStream();
            BinaryWriter animWriter = new BinaryWriter(animStream);

            Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, animWriter, DefaultGameData.DefaultFileTableIDs["MoveAnimationFileID"][Program.CurrentProject.Settings.GameType]);
            int animFileSize = (int)animStream.Position;
            animStream.Seek(0, SeekOrigin.Begin);

            BinaryReader animBr = new BinaryReader(animStream);
            Animations = new List<short>();
            for (int i = 0; i < animFileSize / 2; i++)
            {
                byte[] val = animBr.ReadBytes(2);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(val);
                }
                Animations.Add(BitConverter.ToInt16(val,0));
            }
            animStream.Dispose();

            MemoryStream propStream = new MemoryStream();
            BinaryWriter propWriter = new BinaryWriter(propStream);
            Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, propWriter, DefaultGameData.DefaultFileTableIDs["MovePropertiesFileID"][Program.CurrentProject.Settings.GameType]);
            int propFileSize = (int)propStream.Position;
            propStream.Seek(0,SeekOrigin.Begin);

            BinaryReader propBr = new BinaryReader(propStream);
            Properties = new List<short>();
            for (int i = 0; i < propFileSize / 2; i++)
            {
                byte[] val = propBr.ReadBytes(2);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(val);
                }
                Properties.Add(BitConverter.ToInt16(val, 0));
            }
            propStream.Dispose();
            romStream.Dispose();
        }

        private void PopulateEntries()
        {
            cbMoves.BeginUpdate();
            for (int i = 0; i < Animations.Count; i++)
            {
				cbMoves.Items.Add(string.Format("[0x{1:X4}] {0:X4}", Animations[i], i));
			}
            cbMoves.EndUpdate();
            cbMoves.SelectedIndex = 0;
        }

        private void cbMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMoves.SelectedIndex < 0)
            {
                return;
            }

            tbOutput.Clear();
            int i = cbMoves.SelectedIndex;
            int firstMoveAnim = DefaultGameData.DefaultFileTableIDs["FirstMoveAnimationID"][Program.CurrentProject.Settings.GameType];
			tbOutput.Text = string.Format("anim 0x{0:X4} (0x{1:X4}) | prop 0x{2:X4}"+Environment.NewLine+"{3}",
                Animations[i],
                Animations[i] + firstMoveAnim,
                Properties[i],
                Program.CurrentProject.ProjectFileTable.Entries[firstMoveAnim + Animations[i]].Comment
            );
        }
    }
}
