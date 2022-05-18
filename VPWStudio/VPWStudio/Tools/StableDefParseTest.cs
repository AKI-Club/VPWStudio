using System;
using System.Globalization;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class StableDefParseTest : Form
	{
		public StableDefParseTest()
		{
			InitializeComponent();
			cbGameType.SelectedIndex = 0;
		}

		private void buttonParse_Click(object sender, EventArgs e)
		{
			tbOutput.Clear();

			if (String.IsNullOrEmpty(tbInput.Text))
			{
				Program.ErrorMessageBox("I can't do anything without input.");
				return;
			}

			// take input and display in output
			string[] tokens = tbInput.Text.Split(new char[] { '@', '=' });
			string[] data = tokens[2].Split(new char[] { '{', '}' });
			string[] id2 = data[1].Split(',');

			tbOutput.AppendText(String.Format("Stable {0}\r\nWrestler ID2s at {1:X8}:\r\n", tokens[0], tokens[1]));
			foreach (string w in id2)
			{
				tbOutput.AppendText(w + "\r\n");
			}
			tbOutput.AppendText("Text Index: " + data[2].Substring(1));

			/*
			GameSpecific.VPW2.StableDefinition sd = new GameSpecific.VPW2.StableDefinition();
			sd.WrestlerPointerStart = UInt32.Parse(tokens[1], NumberStyles.HexNumber);
			sd.StableNameIndex = UInt16.Parse(data[2].Substring(1), NumberStyles.HexNumber);

			// wrestlerz
			sd.WrestlerID2s = new byte[id2.Length];
			for (int w = 0; w < sd.WrestlerID2s.Length; w++)
			{
				sd.WrestlerID2s[w] = byte.Parse(id2[w], NumberStyles.HexNumber);
			}
			*/
		}

		private void StableDefParseTest_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
