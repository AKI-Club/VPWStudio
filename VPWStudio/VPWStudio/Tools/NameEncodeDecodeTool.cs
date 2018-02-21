using System;
using System.Windows.Forms;

namespace VPWStudio
{
	// this is temporary, but the code behind it should be placed elsewhere.
	// note 2: I think VPW64 is harder to deal with here.
	public partial class NameEncodeDecodeTool : Form
	{
		private enum ParseMode
		{
			Normal,
			ShortLong, // <>
			ShortOnly  // {}
		}

		private ParseMode CurParseMode = ParseMode.Normal;

		public NameEncodeDecodeTool()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Encode Long and Short names into a full name string.
		/// </summary>
		private void buttonEncode_Click(object sender, EventArgs e)
		{
			// this one is tougher.
			string full = String.Empty;
			string curShort = tbShort.Text;
			string curLong = tbLong.Text;

			// any characters that appear in short and long names go between <>
			// any characters only appearing in short names go between {}

			if (curLong.Contains(curShort))
			{
				// well gee we have it easy, don't we
				// <John> Cena (short name "John"), or John <Cena> (short name "Cena")

				// figure out where the short name is within the long name
				if (curLong.StartsWith(curShort))
				{
					// well that's even EASIER.
					full = String.Format("<{0}>{1}", curShort, curLong.Substring(curShort.Length));
				}
				else
				{
					// need to do some work, but not as bad as the other case below...
					int shortPos = curLong.IndexOf(curShort);
					full = string.Format("{0}<{1}>", curLong.Substring(0, shortPos), curLong.Substring(shortPos));
				}
			}
			else
			{
				MessageBox.Show("the instance where short name isn't found in long name needs to be worked on, sorry.");
				// a bit more work on our hands.
				// general idea: search for the longest substring of the short name within the long name.

				// sometimes, the short name is a hack of the long name
				// * "<R>ick{.}< Steiner>"; long = "Rick Steiner", short = "R. Steiner"

				// sometimes, the short and long names differ so much, they can't be reconciled.
				// Some examples:
				// * "Diamond Dallas Page{DDP}" (human intervention version: "<D>iamond <D>allas <P>age" uses more bytes)
				// * "Konnan{K-Dawg}" (human intervention version: "<K>onnan{-Dawg}" uses more bytes)
				// * "Juventud Guerrera{Juvi}" (human intervention version: "<Juv>entud Guerrera{i}" uses LESS bytes)
			}

			tbFull.Text = full;
		}

		/// <summary>
		/// Decode a full name string into Long and Short names.
		/// </summary>
		private void buttonDecode_Click(object sender, EventArgs e)
		{
			string full = tbFull.Text;
			string newShort = String.Empty;
			string newLong = String.Empty;

			bool ignore = false;
			foreach (char c in full.ToCharArray())
			{
				if (c.Equals('<'))
				{
					this.CurParseMode = ParseMode.ShortLong;
					ignore = true;
				}
				if (c.Equals('{'))
				{
					this.CurParseMode = ParseMode.ShortOnly;
					ignore = true;
				}

				if (c.Equals('>') || c.Equals('}'))
				{
					this.CurParseMode = ParseMode.Normal;
					ignore = true;
				}

				if (!ignore)
				{
					switch (this.CurParseMode)
					{
						case ParseMode.ShortLong:
							newShort += c;
							newLong += c;
							break;
						case ParseMode.ShortOnly:
							newShort += c;
							break;
						case ParseMode.Normal:
						default:
							newLong += c;
							break;
					}
				}
				ignore = false; // reset
			}

			tbLong.Text = newLong;
			tbShort.Text = newShort;
		}
	}
}
