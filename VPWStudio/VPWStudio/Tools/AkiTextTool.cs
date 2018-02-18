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
	public partial class AkiTextTool : Form
	{
		public AkiText CurAkiText = new AkiText();

		public AkiTextTool()
		{
			InitializeComponent();

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open AKI Text File";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				this.CurAkiText.Decode(br);
				br.Close();

				StringBuilder sb = new StringBuilder();
				foreach (KeyValuePair<int, AkiTextEntry> ate in this.CurAkiText.Entries)
				{
					int sjisLen = Encoding.GetEncoding("shift_jis").GetBytes(ate.Value.Text).Length + 1;
					sb.AppendLine(String.Format("[{0:X4}] loc:{1:X4} size:{3} = {2}", ate.Key, ate.Value.Location, ate.Value.Text, sjisLen));
				}
				tbInfoDump.Text = sb.ToString();
			}

			// now i don't need the immediate re-encoding step
			/*
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Test your conversion code, dumbass";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
				BinaryWriter bw = new BinaryWriter(fs);

				this.CurAkiText.Encode(bw);

				bw.Close();
				fs.Close();
			}
			*/
		}
	}
}
