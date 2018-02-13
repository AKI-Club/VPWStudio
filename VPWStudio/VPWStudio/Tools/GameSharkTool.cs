using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VPWStudio
{
	public partial class GameSharkTool : Form
	{
		/// <summary>
		/// Current active CodeSet.
		/// </summary>
		public GameSharkCodeSet CurrentCodeSet = new GameSharkCodeSet();

		public GameSharkTool()
		{
			InitializeComponent();
			if (Program.CurrentGSCodeFile == null)
			{
				Program.CurrentGSCodeFile = new GameSharkCodeFile();
				Program.CurrentGSCodeFile.AllCodes.Add(new GameSharkCodeSet("New Code"));
				tbCodeFilePath.Text = "(new code file)";
			}
			else
			{
				// populate everything
				tbCodeFilePath.Text = Program.CurGSCFPath;
			}
			UpdateCodeSetComboBox();
			cboxCodeSets.SelectedIndex = 0;
			UpdateCodeListBox();
		}

		/// <summary>
		/// Get the currently selected code as a GameShark code.
		/// </summary>
		/// <returns>Current code value as a string in the format "XXXXXXXX YYYY"</returns>
		private string GetCurrentCodeString()
		{
			return String.Format("{0} {1}", tbCodeAddress.Text, tbCodeValue.Text);
		}

		#region Code File Menu
		private void newCodeFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Program.CurGSCFPath = String.Empty;
			Program.CurrentGSCodeFile = new GameSharkCodeFile();
			Program.CurrentGSCodeFile.AllCodes.Add(new GameSharkCodeSet("New Code"));
			tbCodeFilePath.Text = "(new code file)";
		}

		private void openCodeFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open GameShark Code File";
			ofd.Filter = SharedStrings.FileFilter_GameSharkCodes;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
				XmlReader xr = XmlReader.Create(fs);
				Program.CurrentGSCodeFile = new GameSharkCodeFile();
				Program.CurrentGSCodeFile.LoadFile(xr);
				xr.Close();
				fs.Close();
				Program.CurGSCFPath = ofd.FileName;
				tbCodeFilePath.Text = ofd.FileName;
				this.CurrentCodeSet = Program.CurrentGSCodeFile.AllCodes[0];

				UpdateCodeSetComboBox();
				cboxCodeSets.SelectedIndex = 0;
				UpdateCodeListBox();
			}
		}

		private void saveCodeFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save GameShark Code File";
			sfd.Filter = SharedStrings.FileFilter_GameSharkCodes;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
				XmlWriterSettings xws = new XmlWriterSettings();
				xws.Indent = true;
				xws.IndentChars = "\t";
				xws.Encoding = Encoding.UTF8;

				XmlWriter xw = XmlWriter.Create(fs, xws);
				Program.CurrentGSCodeFile.SaveFile(xw);

				xw.Flush();
				xw.Close();
				fs.Close();

				if (Program.CurGSCFPath == String.Empty)
				{
					Program.CurGSCFPath = sfd.FileName;
					tbCodeFilePath.Text = Program.CurGSCFPath;
				}
			}
		}
		#endregion;

		#region CodeSet Menu
		/// <summary>
		/// Add a new CodeSet to the current CodeFile.
		/// </summary>
		private void addNewCodeSetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Program.CurrentGSCodeFile.AllCodes.Add(new GameSharkCodeSet("New Code"));
			UpdateCodeSetComboBox();
			cboxCodeSets.SelectedIndex = cboxCodeSets.Items.Count - 1;
		}

		/// <summary>
		/// Delete the currently selected CodeSet.
		/// </summary>
		private void deleteCurrentCodeSetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cboxCodeSets.SelectedIndex < 0)
			{
				return;
			}

			Program.CurrentGSCodeFile.AllCodes.RemoveAt(cboxCodeSets.SelectedIndex);
			UpdateCodeSetComboBox();
			if (Program.CurrentGSCodeFile.AllCodes.Count > 0)
			{
				cboxCodeSets.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Clone the currently selected CodeSet.
		/// </summary>
		private void cloneCurrentCodesetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cboxCodeSets.SelectedIndex < 0)
			{
				return;
			}

			GameSharkCodeSet clone = this.CurrentCodeSet;
			Program.CurrentGSCodeFile.AllCodes.Add(clone);
			int curCode = cboxCodeSets.SelectedIndex;
			UpdateCodeSetComboBox();
			cboxCodeSets.SelectedIndex = curCode;
		}
		#endregion

		#region CodeSet ComboBox
		private void cboxCodeSets_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboxCodeSets.SelectedIndex < 0)
			{
				return;
			}
			this.CurrentCodeSet = Program.CurrentGSCodeFile.AllCodes[cboxCodeSets.SelectedIndex];
			UpdateCodeListBox();
			tbCodeSetName.Text = this.CurrentCodeSet.Name;
		}

		/// <summary>
		/// Update the values in the CodeSet ComboBox.
		/// </summary>
		private void UpdateCodeSetComboBox()
		{
			cboxCodeSets.Items.Clear();
			cboxCodeSets.BeginUpdate();
			for (int i = 0; i < Program.CurrentGSCodeFile.AllCodes.Count; i++)
			{
				cboxCodeSets.Items.Add(Program.CurrentGSCodeFile.AllCodes[i].Name);
			}
			cboxCodeSets.EndUpdate();
		}
		#endregion

		#region CodeSet ListBox
		private void UpdateCodeListBox()
		{
			lbCodes.Items.Clear();
			lbCodes.BeginUpdate();
			for (int i = 0; i < this.CurrentCodeSet.Codes.Count; i++)
			{
				lbCodes.Items.Add(this.CurrentCodeSet.Codes[i].ToString());
			}
			lbCodes.EndUpdate();
		}

		/// <summary>
		/// Selected a new code in the current CodeSet.
		/// </summary>
		private void lbCodes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbCodes.SelectedIndex < 0)
			{
				return;
			}

			// load code information
			tbCodeAddress.Text = this.CurrentCodeSet.Codes[lbCodes.SelectedIndex].ToString().Substring(0, 8);
			tbCodeValue.Text = this.CurrentCodeSet.Codes[lbCodes.SelectedIndex].ToString().Substring(9);
		}

		/// <summary>
		/// Delete currently selected Code from the active CodeSet.
		/// </summary>
		private void buttonDeleteCode_Click(object sender, EventArgs e)
		{
			if (lbCodes.SelectedIndex < 0)
			{
				return;
			}

			this.CurrentCodeSet.RemoveCodeAt(lbCodes.SelectedIndex);
			UpdateCodeListBox();
		}

		/// <summary>
		/// Move currently selected code Up.
		/// </summary>
		private void buttonMoveCodeUp_Click(object sender, EventArgs e)
		{
			if (lbCodes.SelectedIndex <= 0)
			{
				return;
			}

			int curIndex = lbCodes.SelectedIndex;
			int destIndex = curIndex - 1;

			SortedList<int, GameSharkCode> newCodeList = new SortedList<int, GameSharkCode>();
			GameSharkCode moveCode = this.CurrentCodeSet.Codes[curIndex];
			GameSharkCode displacedCode = this.CurrentCodeSet.Codes[destIndex];

			for (int i = 0; i < this.CurrentCodeSet.Codes.Count; i++)
			{
				if (i == destIndex)
				{
					newCodeList.Add(i, moveCode);
				}
				else if (i == curIndex)
				{
					newCodeList.Add(i,displacedCode);
				}
				else
				{
					newCodeList.Add(i, this.CurrentCodeSet.Codes[i]);
				}
			}
			this.CurrentCodeSet.Codes = newCodeList;
			UpdateCodeListBox();
			lbCodes.SelectedIndex = destIndex;
		}

		/// <summary>
		/// Move currently selected code Down.
		/// </summary>
		private void buttonMoveCodeDown_Click(object sender, EventArgs e)
		{
			if (lbCodes.SelectedIndex < 0 || lbCodes.SelectedIndex >= lbCodes.Items.Count)
			{
				return;
			}

			int curIndex = lbCodes.SelectedIndex;
			int destIndex = curIndex + 1;

			SortedList<int, GameSharkCode> newCodeList = new SortedList<int, GameSharkCode>();
			GameSharkCode moveCode = this.CurrentCodeSet.Codes[curIndex];
			GameSharkCode displacedCode = this.CurrentCodeSet.Codes[destIndex];

			for (int i = 0; i < this.CurrentCodeSet.Codes.Count; i++)
			{
				if (i == destIndex)
				{
					newCodeList.Add(i, moveCode);
				}
				else if (i == curIndex)
				{
					newCodeList.Add(i, displacedCode);
				}
				else
				{
					newCodeList.Add(i, this.CurrentCodeSet.Codes[i]);
				}
			}
			this.CurrentCodeSet.Codes = newCodeList;
			UpdateCodeListBox();
			lbCodes.SelectedIndex = destIndex;
		}
		#endregion

		#region GameShark Code Editor
		private void buttonAddCode_Click(object sender, EventArgs e)
		{
			// try to add code
			if (tbCodeAddress.Text.Length < 8)
			{
				MessageBox.Show("Invalid address length, must be 8 hex characters");
				return;
			}

			CurrentCodeSet.AddCode(new GameSharkCode(GetCurrentCodeString()));
			UpdateCodeListBox();
		}

		private void buttonModifyCode_Click(object sender, EventArgs e)
		{
			if (lbCodes.SelectedIndex < 0)
			{
				return;
			}

			CurrentCodeSet.Codes[lbCodes.SelectedIndex].SetFromCode(GetCurrentCodeString());
			UpdateCodeListBox();
		}
		#endregion

		private void buttonRenameCodeSet_Click(object sender, EventArgs e)
		{
			if (tbCodeSetName.Text.Equals(String.Empty))
			{
				return;
			}

			this.CurrentCodeSet.Name = tbCodeSetName.Text;
			int curIndex = cboxCodeSets.SelectedIndex;
			UpdateCodeSetComboBox();
			cboxCodeSets.SelectedIndex = curIndex;
		}


		#region Project64 code format Import/Export
		// todo
		#endregion
	}
}
