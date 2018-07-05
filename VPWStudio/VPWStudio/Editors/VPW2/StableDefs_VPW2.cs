using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	/// <summary>
	/// VPW2 Stable Definitions editor
	/// </summary>
	public partial class StableDefs_VPW2 : Form
	{
		public SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		private AkiText DefaultNames;

		public StableDefs_VPW2()
		{
			InitializeComponent();

			if (Program.CurrentProject.Settings.StableDefinitionFilePath != null &&
				Program.CurrentProject.Settings.StableDefinitionFilePath != String.Empty &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath))
			){
				// load stable definitions from external file
				StableDefFile sdf = new StableDefFile(VPWGames.VPW2);
				FileStream fs = new FileStream(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath), FileMode.Open);
				StreamReader sr = new StreamReader(fs);
				sdf.ReadFile(sr);
				sr.Close();
				StableDefs = sdf.StableDefs_VPW2;

				// load default names
				// xxx1: this check should be outside this conditional
				// xxx2: the possibility of loading external AkiText...
				MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
				BinaryReader br = new BinaryReader(ms);
				LoadDefaultNames(br);
				br.Close();
			}
			else
			{
				// load stable definitions from VPW2 ROM
				MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
				BinaryReader br = new BinaryReader(ms);

				bool hasLocation = false;
				if (Program.CurLocationFile != null)
				{
					LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StableDefs"]);
					if (sdEntry != null)
					{
						br.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
						hasLocation = true;
					}
				}
				if (!hasLocation)
				{
					// fallback to hardedcoded offset
					Program.InfoMessageBox("Stable Definition location not found; using hardcoded offset instead.");

					br.BaseStream.Seek(0x408BC, SeekOrigin.Begin);
				}

				// xxx: default number of stable defs
				for (int i = 0; i < 17; i++)
				{
					StableDefinition sdef = new StableDefinition(br);
					StableDefs.Add(i, sdef);
				}

				LoadDefaultNames(br);
				br.Close();
			}

			PopulateList();
		}

		/// <summary>
		/// Load default names from external AkiText file.
		/// </summary>
		private void LoadExternalNames()
		{
			// todo
		}

		/// <summary>
		/// Load default names from AkiText in ROM.
		/// </summary>
		private void LoadDefaultNames(BinaryReader romReader)
		{
			// default names are in file 006C
			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, 0x006C);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			DefaultNames = new AkiText();
			DefaultNames.ReadData(outReader);

			outReader.Close();
			outWriter.Close();
		}

		/// <summary>
		/// Populate the list of stables.
		/// </summary>
		private void PopulateList()
		{
			lbStables.BeginUpdate();
			for (int i = 0; i < this.StableDefs.Count; i++)
			{
				lbStables.Items.Add(i);
			}
			lbStables.EndUpdate();
		}

		public void LoadData(StableDefinition _sdef)
		{
			tbWrestlerDefPointer.Text = String.Format("{0:X8}", _sdef.WrestlerPointerStart);
			tbTextIndex.Text = String.Format("{0:X4}", _sdef.StableNameIndex);

			// get default stable name from AkiText
			tbStableName.Text = DefaultNames.Entries[(int)_sdef.StableNameIndex].Text;

			lbWresID2s.Items.Clear();
			lbWresID2s.BeginUpdate();
			for (int i = 0; i < _sdef.WrestlerID2s.Length; i++)
			{
				if (_sdef.WrestlerID2s[i] != 0)
				{
					lbWresID2s.Items.Add(String.Format("{0:X2}", _sdef.WrestlerID2s[i]));
				}
			}
			lbWresID2s.EndUpdate();
		}

		private void UpdateWrestlerList()
		{
			StableDefinition sdef = StableDefs[lbStables.SelectedIndex];

			lbWresID2s.Items.Clear();
			lbWresID2s.BeginUpdate();
			for (int i = 0; i < sdef.WrestlerID2s.Length; i++)
			{
				if (sdef.WrestlerID2s[i] != 0)
				{
					lbWresID2s.Items.Add(String.Format("{0:X2}", sdef.WrestlerID2s[i]));
				}
			}
			lbWresID2s.EndUpdate();
		}

		private void lbStables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			LoadData(StableDefs[lbStables.SelectedIndex]);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			if (lbWresID2s.SelectedIndex <= 0)
			{
				return;
			}

			// swap 'em if you got 'em
			int newIndex = lbWresID2s.SelectedIndex - 1;
			byte oldWres = StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex - 1];
			byte moveWres = StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex];

			StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex - 1] = moveWres;
			StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex] = oldWres;

			UpdateWrestlerList();
			lbWresID2s.SelectedIndex = newIndex;
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			if (lbWresID2s.SelectedIndex < 0)
			{
				return;
			}
			if (lbWresID2s.SelectedIndex == lbWresID2s.Items.Count-1)
			{
				return;
			}
		}

		private void buttonSwitchGroup_Click(object sender, EventArgs e)
		{
			Program.ErrorMessageBox("look what freem hasn't implemented yet!!!");
		}
	}
}
