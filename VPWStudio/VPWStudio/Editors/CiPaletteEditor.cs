using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors
{
	public partial class CiPaletteEditor : Form
	{
		public Ci4Palette CurPaletteCI4;
		public Ci8Palette CurPaletteCI8;

		private Bitmap PalPreviewBitmap;

		private enum CiEditorModes
		{
			Ci4,
			Ci8
		}
		private CiEditorModes CurEditMode;

		private List<UInt16> AllColors = new List<UInt16>();

		// I need this hack because of how NumericUpDown handles ValueChanged events...
		private bool ChangingColors = false;

		public CiPaletteEditor(int fileID)
		{
			InitializeComponent();

			// todo:
			// - determine if a replacement file is set
			//   - if so, determine the data type (could be raw, could be JASC) and load it
			//   - if not, load from ROM (see current code)

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);

			if (Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.Ci4Palette)
			{
				CurEditMode = CiEditorModes.Ci4;
				CurPaletteCI8 = null;

				CurPaletteCI4 = new Ci4Palette();
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, fileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(palStream);
				CurPaletteCI4.ReadData(fr, true);
				fr.Close();
				AllColors.AddRange(CurPaletteCI4.Entries);
				if (CurPaletteCI4.SubPalettes.Count > 0)
				{
					foreach (Ci4Palette sub in CurPaletteCI4.SubPalettes)
					{
						AllColors.AddRange(sub.Entries);
					}
				}
			}
			else if (Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.Ci8Palette)
			{
				CurEditMode = CiEditorModes.Ci8;
				CurPaletteCI4 = null;

				CurPaletteCI8 = new Ci8Palette();
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, fileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(palStream);
				CurPaletteCI8.ReadData(fr);
				fr.Close();
				AllColors.AddRange(CurPaletteCI8.Entries);
			}

			Text = String.Format("CI{0} Palette Editor - File {1:X4}", CurEditMode == CiEditorModes.Ci4 ? 4 : 8, fileID);

			PopulateList();
			UpdatePreview();
			cbColorEntries.SelectedIndex = 0;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// add AllColors back to the working Ci*Palette

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Populate the drop-down list with all of the palette colors.
		/// </summary>
		private void PopulateList()
		{
			cbColorEntries.Items.Clear();
			cbColorEntries.BeginUpdate();
			for (int i = 0; i < AllColors.Count; i++)
			{
				cbColorEntries.Items.Add(String.Format("Color {0:D3}", i+1));
			}
			cbColorEntries.EndUpdate();
		}

		private void pbPalettePreview_MouseClick(object sender, MouseEventArgs e)
		{
			// todo: determine where we clicked
		}

		/// <summary>
		/// 
		/// </summary>
		private void UpdatePreview()
		{
			// depends on CurEditMode
			PalPreviewBitmap = new Bitmap(448, 128);
			Graphics g = Graphics.FromImage(PalPreviewBitmap);

			int curRow = 0;
			int curCol = 0;
			int swatchWidth = 28;
			int swatchHeight = 28;
			Pen curPen;

			// CI8 is easy
			// CI4 depends on how many subpalettes we have
			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					{
						if (CurPaletteCI4.SubPalettes.Count > 0)
						{
							// entry 15b3
							// worst case scenario is having enough subpalettes to fill all 256 entries
							swatchHeight = pbPalettePreview.Height / (CurPaletteCI4.SubPalettes.Count + 1);

							// draw main
							for (int i = 0; i < CurPaletteCI4.Entries.Length; i++)
							{
								curPen = new Pen(N64Colors.Value5551ToColor(AllColors[i]));
								g.FillRectangle(curPen.Brush, new Rectangle(curCol * swatchWidth, curRow * swatchHeight, swatchWidth, swatchHeight));

								curCol++;
								if (curCol >= 16)
								{
									curCol = 0;
									curRow++;
								}
							}

							for (int spn = 0; spn < CurPaletteCI4.SubPalettes.Count; spn++)
							{
								Ci4Palette tmp = CurPaletteCI4.SubPalettes[spn];
								for (int spc = 0; spc < tmp.Entries.Length; spc++)
								{
									curPen = new Pen(N64Colors.Value5551ToColor(AllColors[16+(spn*16)+spc]));
									g.FillRectangle(curPen.Brush, new Rectangle(curCol * swatchWidth, curRow * swatchHeight, swatchWidth, swatchHeight));

									curCol++;
									if (curCol >= 16)
									{
										curCol = 0;
										curRow++;
									}
								}
							}
						}
						else
						{
							// 28x128
							swatchHeight = 128;

							for (int i = 0; i < CurPaletteCI4.Entries.Length; i++)
							{
								curPen = new Pen(N64Colors.Value5551ToColor(AllColors[i]));
								g.FillRectangle(curPen.Brush, new Rectangle(curCol * swatchWidth, curRow, swatchWidth, swatchHeight));

								curCol++;
								if (curCol >= 16)
								{
									curCol = 0;
									curRow++;
								}
							}
						}
					}
					break;

				case CiEditorModes.Ci8:
					{
						// draw 'em all
						swatchHeight = 8;
						for (int i = 0; i < CurPaletteCI8.Entries.Length; i++)
						{
							curPen = new Pen(N64Colors.Value5551ToColor(AllColors[i]));
							g.FillRectangle(curPen.Brush, new Rectangle(curCol * swatchWidth, curRow * swatchHeight, swatchWidth, swatchHeight));

							curCol++;
							if (curCol >= 16)
							{
								curCol = 0;
								curRow++;
							}
						}
					}
					break;
			}

			g.Dispose();
			pbPalettePreview.Image = PalPreviewBitmap;
		}

		/// <summary>
		/// Update the "Currently Editing" color swatch
		/// </summary>
		private void UpdateCurColorSwatch()
		{
			if (cbColorEntries.SelectedIndex < 0)
			{
				return;
			}
			panelCurColor.BackColor = N64Colors.Value5551ToColor(AllColors[cbColorEntries.SelectedIndex]);
		}

		/// <summary>
		/// Selected a new color
		/// </summary>
		private void cbColorEntries_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbColorEntries.SelectedIndex < 0)
			{
				return;
			}

			ChangingColors = true;

			int colorNum = cbColorEntries.SelectedIndex;
			Color converted = N64Colors.Value5551ToColor(AllColors[colorNum]);
			UpdateCurColorSwatch();
			nudRed.Value = converted.R / 8;
			nudGreen.Value = converted.G / 8;
			nudBlue.Value = converted.B / 8;
			cbTransparent.Checked = (converted.A == 0);

			ChangingColors = false;
		}

		#region Changing Values
		private void cbTransparent_Click(object sender, EventArgs e)
		{
			if (cbColorEntries.SelectedIndex < 0)
			{
				return;
			}

			Color tmp = N64Colors.Value5551ToColor(AllColors[cbColorEntries.SelectedIndex]);
			Color changed = Color.FromArgb((cbTransparent.Checked ? 0 : 255), tmp.R, tmp.G, tmp.B);
			AllColors[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
			UpdateCurColorSwatch();
			UpdatePreview();
		}

		private void nudRed_ValueChanged(object sender, EventArgs e)
		{
			if (cbColorEntries.SelectedIndex < 0)
			{
				return;
			}

			if (!ChangingColors)
			{
				Color tmp = N64Colors.Value5551ToColor(AllColors[cbColorEntries.SelectedIndex]);
				Color changed = Color.FromArgb(tmp.A, (int)(nudRed.Value * 8), tmp.G, tmp.B);
				AllColors[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
				UpdateCurColorSwatch();
				UpdatePreview();
			}
		}

		private void nudGreen_ValueChanged(object sender, EventArgs e)
		{
			if (cbColorEntries.SelectedIndex < 0)
			{
				return;
			}

			if (!ChangingColors)
			{
				Color tmp = N64Colors.Value5551ToColor(AllColors[cbColorEntries.SelectedIndex]);
				Color changed = Color.FromArgb(tmp.A, tmp.R, (int)(nudGreen.Value * 8), tmp.B);
				AllColors[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
				UpdateCurColorSwatch();
				UpdatePreview();
			}
		}

		private void nudBlue_ValueChanged(object sender, EventArgs e)
		{
			if (cbColorEntries.SelectedIndex < 0)
			{
				return;
			}

			if (!ChangingColors)
			{
				Color tmp = N64Colors.Value5551ToColor(AllColors[cbColorEntries.SelectedIndex]);
				Color changed = Color.FromArgb(tmp.A, tmp.R, tmp.G, (int)(nudBlue.Value * 8));
				AllColors[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
				UpdateCurColorSwatch();
				UpdatePreview();
			}
		}
		#endregion
	}
}
