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
				LoadFileTable();
				UpdateInfoDump();
			}
		}

		private void LoadFileTable()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			this.CurrentFileTable = new FileTable();

			bool hasLocation = false;
			bool hasLength = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.FileTable != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.FileTable.Address, SeekOrigin.Begin);
					this.CurrentFileTable.Load(br, Program.CurLocationFile.FileTable.Width);
					hasLocation = true;
					hasLength = true;
				}
			}
			if (!hasLocation || !hasLength)
			{
				// fallback to hardedcoded offset and length.
				MessageBox.Show(
					"File Table location not found; using hardcoded offset and length instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				int offset = 0;
				int length = 0;
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.WorldTour_NTSC_U_10:
						offset = 0x7C1A78;
						length = 21996;
						break;
					case SpecificGame.WorldTour_NTSC_U_11:
						offset = 0x7C1C70;
						length = 21996;
						break;
					case SpecificGame.WorldTour_PAL:
						offset = 0x7C1C00;
						length = 21996;
						break;
					case SpecificGame.VPW64_NTSC_J:
						offset = 0xC7B578;
						length = 37432;
						break;
					case SpecificGame.Revenge_NTSC_U:
						offset = 0xCE2752;
						length = 30632;
						break;
					case SpecificGame.Revenge_PAL:
						offset = 0xCDFCE2;
						length = 30632;
						break;
					case SpecificGame.WM2K_NTSC_U:
						offset = 0x11778BE;
						length = 41248;
						break;
					case SpecificGame.WM2K_NTSC_J:
						offset = 0x116F3C2;
						length = 41480;
						break;
					case SpecificGame.WM2K_PAL:
						offset = 0x11778BE;
						length = 41248;
						break;
					case SpecificGame.VPW2_NTSC_J:
						offset = 0x1310F40;
						length = 52364;
						break;
					case SpecificGame.NoMercy_NTSC_U_10:
						break;
					case SpecificGame.NoMercy_NTSC_U_11:
						break;
					case SpecificGame.NoMercy_PAL_10:
						break;
					case SpecificGame.NoMercy_PAL_11:
						break;
				}
				if (offset != 0 && length != 0)
				{
					br.BaseStream.Seek(offset, SeekOrigin.Begin);
					this.CurrentFileTable.Load(br, length);
				}
				else
				{
					MessageBox.Show(String.Format("Well I guess I didn't implement {0} yet...", Program.CurrentProject.Settings.GameType));
				}
			}
			br.Close();
		}

		#region temp info dump
		private void UpdateInfoDump()
		{
			StringBuilder sb = new StringBuilder();

			uint offset = 0;
			bool hasOffset = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.FirstFile != null)
				{
					offset = Program.CurLocationFile.FirstFile.Address;
					hasOffset = true;
				}
			}
			if (!hasOffset)
			{
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.WorldTour_NTSC_U_10:
					case SpecificGame.WorldTour_PAL:
						offset = 0x39490;
						break;
					case SpecificGame.WorldTour_NTSC_U_11:
						offset = 0x39500;
						break;
					case SpecificGame.VPW64_NTSC_J:
						offset = 0x4AD00;
						break;
					case SpecificGame.Revenge_NTSC_U:
						offset = 0xDAC50;
						break;
					case SpecificGame.Revenge_PAL:
						offset = 0xD81E0;
						break;
					case SpecificGame.WM2K_NTSC_U:
						offset = 0x144AA0;
						break;
					case SpecificGame.WM2K_NTSC_J:
						offset = 0x12C070;
						break;
					case SpecificGame.WM2K_PAL:
						offset = 0x144AC0;
						break;
					case SpecificGame.VPW2_NTSC_J:
						offset = 0x152DF0;
						break;
					// all wwf no mercy
				}
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
		#endregion
	}
}
