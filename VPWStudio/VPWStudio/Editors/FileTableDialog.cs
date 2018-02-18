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
	public partial class FileTableDialog : Form
	{
		protected FileTable CurrentFileTable;

		public FileTableDialog()
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.Revenge:
						LoadFileTable_Revenge();
						UpdateInfo_Revenge();
						break;
					case VPWGames.VPW2:
						LoadFileTable_VPW2();
						UpdateInfo_VPW2();
						break;
					default:
						MessageBox.Show(String.Format("not implemented for {0}", Program.CurrentProject.Settings.BaseGame));
						break;
				}
			}
		}

		#region Game-Specific Loading
		private void LoadFileTable_Revenge()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			this.CurrentFileTable = new FileTable();

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.FileTable != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.FileTable.Address, SeekOrigin.Begin);
					this.CurrentFileTable.Load(br, Program.CurLocationFile.FileTable.Width);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardedcoded offset
				MessageBox.Show(
					"File Table location not found; using hardcoded offset and length instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.Revenge_NTSC_U:
						br.BaseStream.Seek(0xCE2752, SeekOrigin.Begin);
						break;
					case SpecificGame.Revenge_PAL:
						br.BaseStream.Seek(0xCDFCE2, SeekOrigin.Begin);
						break;
				}
				this.CurrentFileTable.Load(br, 52364);
			}
			br.Close();
		}

		private void LoadFileTable_VPW2()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			this.CurrentFileTable = new FileTable();

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.FileTable != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.FileTable.Address, SeekOrigin.Begin);
					this.CurrentFileTable.Load(br, Program.CurLocationFile.FileTable.Width);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardedcoded offset
				MessageBox.Show(
					"File Table location not found; using hardcoded offset and length instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				br.BaseStream.Seek(0x1310F40, SeekOrigin.Begin);
				this.CurrentFileTable.Load(br, 52364);
			}

			br.Close();
		}
		#endregion

		#region temp info dump
		private void UpdateInfo_Revenge()
		{
			StringBuilder sb = new StringBuilder();

			uint offset = 0;
			switch (Program.CurrentProject.Settings.GameType)
			{
				case SpecificGame.Revenge_NTSC_U:
					offset = 0xDAC50;
					break;
				case SpecificGame.Revenge_PAL:
					offset = 0xD81E0;
					break;
			}

			for (int i = 1; i < this.CurrentFileTable.Entries.Count; i++)
			{
				FileTableEntry fte = this.CurrentFileTable.Entries[i];
				sb.AppendLine(
					String.Format(
						"[{0:X4}]{1} {2:X8} (ROM addr: {3:X8})",
						i,
						fte.IsEncoded ? "*" : " ",
						fte.Location,
						fte.Location + offset
					)
				);
			}

			tbInfoDump.Text = sb.ToString();
		}

		private void UpdateInfo_VPW2()
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 1; i < this.CurrentFileTable.Entries.Count; i++)
			{
				FileTableEntry fte = this.CurrentFileTable.Entries[i];
				sb.AppendLine(
					String.Format(
						"[{0:X4}]{1} {2:X8} (ROM addr: {3:X8})",
						i,
						fte.IsEncoded ? "*" : " ",
						fte.Location,
						fte.Location + 0x152DF0
					)
				);
			}

			tbInfoDump.Text = sb.ToString();
		}
		#endregion
	}
}
