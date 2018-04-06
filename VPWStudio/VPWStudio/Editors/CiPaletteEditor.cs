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
	/// <summary>
	/// CI4/CI8 Palette Editor.
	/// </summary>
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

		/// <summary>
		/// List of all colors in this palette.
		/// </summary>
		private List<UInt16> ColorList = new List<UInt16>();

		// I need this hack because of how NumericUpDown handles ValueChanged events...
		private bool ChangingColors = false;

		private int FileID;

		public CiPaletteEditor(int fileID)
		{
			InitializeComponent();
			FileID = fileID;

			// todo:
			// - determine if a replacement file is set
			//   - if so, determine the data type (could be raw, could be JASC) and load it
			//   - if not, load from ROM (see current code)

			string replaceFile = Program.CurrentProject.ProjectFileTable.Entries[FileID].ReplaceFilePath;
			if (replaceFile != null && replaceFile != String.Empty)
			{
				// load replacement file (might be raw, might be jasc psp palette)
			}
			else
			{
				// business as usual
			}

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);

			if (Program.CurrentProject.ProjectFileTable.Entries[FileID].FileType == FileTypes.Ci4Palette)
			{
				CurEditMode = CiEditorModes.Ci4;
				CurPaletteCI8 = null;

				CurPaletteCI4 = new Ci4Palette();
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, FileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(palStream);
				CurPaletteCI4.ReadData(fr, true);
				fr.Close();
				ColorList.AddRange(CurPaletteCI4.Entries);
				if (CurPaletteCI4.SubPalettes.Count > 0)
				{
					foreach (Ci4Palette sub in CurPaletteCI4.SubPalettes)
					{
						ColorList.AddRange(sub.Entries);
					}
				}
			}
			else if (Program.CurrentProject.ProjectFileTable.Entries[FileID].FileType == FileTypes.Ci8Palette)
			{
				CurEditMode = CiEditorModes.Ci8;
				CurPaletteCI4 = null;

				CurPaletteCI8 = new Ci8Palette();
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, FileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(palStream);
				CurPaletteCI8.ReadData(fr);
				fr.Close();
				ColorList.AddRange(CurPaletteCI8.Entries);
			}
			/*
			else if (Program.CurrentProject.ProjectFileTable.Entries[FileID].FileType == FileTypes.AkiTexture)
			{
				// ugh ok maybe I can support this
				AkiTexture tex = new AkiTexture();
				using (MemoryStream texStream = new MemoryStream())
				{
					using (BinaryWriter texWriter = new BinaryWriter(texStream))
					{
						Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, texWriter, FileID);
						texStream.Seek(0, SeekOrigin.Begin);
						using (BinaryReader br = new BinaryReader(texStream))
						{
							tex.ReadData(br);
						}

						switch (tex.ImageFormat)
						{
							case AkiTexture.AkiTextureFormat.Ci4:
								{
									CurEditMode = CiEditorModes.Ci4;
									CurPaletteCI8 = null;
								}
								break;
							case AkiTexture.AkiTextureFormat.Ci8:
								{
									CurEditMode = CiEditorModes.Ci8;
									CurPaletteCI4 = null;
								}
								break;
						}
					}
				}
			}
			*/

			Text = String.Format("CI{0} Palette Editor - File {1:X4}", CurEditMode == CiEditorModes.Ci4 ? 4 : 8, FileID);

			PopulateList();
			UpdatePreview();

			cbColorEntries.SelectedIndex = 0;
			cbColorEntries_SelectionChangeCommitted(this, new EventArgs());
		}

		#region OK and Cancel
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
		#endregion

		/// <summary>
		/// Populate the drop-down list with all of the palette colors.
		/// </summary>
		private void PopulateList()
		{
			cbColorEntries.Items.Clear();
			cbColorEntries.BeginUpdate();
			for (int i = 0; i < ColorList.Count; i++)
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
		/// Update the palette preview.
		/// </summary>
		private void UpdatePreview()
		{
			// depends on CurEditMode
			PalPreviewBitmap = new Bitmap(pbPalettePreview.Width, pbPalettePreview.Height);
			Graphics g = Graphics.FromImage(PalPreviewBitmap);

			int curRow = 0;
			int curCol = 0;
			int swatchWidth = pbPalettePreview.Width / 16;
			int swatchHeight = pbPalettePreview.Height;
			Pen curPen;

			// CI8 is easy
			// CI4 depends on how many subpalettes we have
			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					{
						if (CurPaletteCI4.SubPalettes.Count > 0)
						{
							// worst case scenario is having enough subpalettes to fill all 256 entries
							swatchHeight = pbPalettePreview.Height / (CurPaletteCI4.SubPalettes.Count + 1);

							// draw main
							for (int i = 0; i < CurPaletteCI4.Entries.Length; i++)
							{
								curPen = new Pen(N64Colors.Value5551ToColor(ColorList[i]));
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
									curPen = new Pen(N64Colors.Value5551ToColor(ColorList[16+(spn*16)+spc]));
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
							swatchHeight = pbPalettePreview.Height;

							for (int i = 0; i < CurPaletteCI4.Entries.Length; i++)
							{
								curPen = new Pen(N64Colors.Value5551ToColor(ColorList[i]));
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
						swatchHeight = pbPalettePreview.Height/16;
						for (int i = 0; i < CurPaletteCI8.Entries.Length; i++)
						{
							curPen = new Pen(N64Colors.Value5551ToColor(ColorList[i]));
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
			panelCurColor.BackColor = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
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
			Color converted = N64Colors.Value5551ToColor(ColorList[colorNum]);
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

			Color tmp = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
			Color changed = Color.FromArgb((cbTransparent.Checked ? 0 : 255), tmp.R, tmp.G, tmp.B);
			ColorList[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
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
				Color tmp = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
				Color changed = Color.FromArgb(tmp.A, (int)(nudRed.Value * 8), tmp.G, tmp.B);
				ColorList[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
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
				Color tmp = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
				Color changed = Color.FromArgb(tmp.A, tmp.R, (int)(nudGreen.Value * 8), tmp.B);
				ColorList[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
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
				Color tmp = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
				Color changed = Color.FromArgb(tmp.A, tmp.R, tmp.G, (int)(nudBlue.Value * 8));
				ColorList[cbColorEntries.SelectedIndex] = N64Colors.ColorToValue5551(changed);
				UpdateCurColorSwatch();
				UpdatePreview();
			}
		}
		#endregion

		#region Import/Export
		private void buttonImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import Palette";
			string filters = String.Empty;
			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					filters = "CI4 Palette (*.ci4pal)|*.ci4pal|";
					break;
				case CiEditorModes.Ci8:
					filters = "CI8 Palette (*.ci8pal)|*.ci8pal|";
					break;
			}
			ofd.Filter = filters + "JASC Paint Shop Pro Palette (*.pal)|*.pal|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				// load that
				using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
				{
					switch (CurEditMode)
					{
						case CiEditorModes.Ci4:
							{
								Ci4Palette import = new Ci4Palette();
								if (Path.GetExtension(ofd.FileName) == ".pal")
								{
									// import JASC Paint Shop Pro palette

									// todo: subpalettes suuuuuuck
									MessageBox.Show("Paint Shop Pro Palette Import not yet implemented");
								}
								else if (Path.GetExtension(ofd.FileName) == ".ci4pal")
								{
									using (BinaryReader br = new BinaryReader(fs))
									{
										import.ReadData(br, true);
										// temporary; move this down later
										CurPaletteCI4 = import;
										ColorList.Clear();
										ColorList.AddRange(import.Entries);
										UpdateCurColorSwatch();
										UpdatePreview();
									}
								}
							}
							break;
						case CiEditorModes.Ci8:
							{
								Ci8Palette import = new Ci8Palette();
								if (Path.GetExtension(ofd.FileName) == ".pal")
								{
									// import JASC Paint Shop Pro palette
									using (StreamReader sr = new StreamReader(fs))
									{
										import.ImportJasc(sr);
										
									}
								}
								else if (Path.GetExtension(ofd.FileName) == ".ci8pal")
								{
									using (BinaryReader br = new BinaryReader(fs))
									{
										import.ReadData(br);
									}
								}
								CurPaletteCI8 = import;
								ColorList.Clear();
								ColorList.AddRange(import.Entries);
								UpdateCurColorSwatch();
								UpdatePreview();
							}
							break;
					}
				}
			}
		}

		private void buttonExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Palette";
			sfd.FileName = String.Format("{0:X4}", FileID);
			string filters = String.Empty;
			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					filters = "CI4 Palette (*.ci4pal)|*.ci4pal|";
					break;
				case CiEditorModes.Ci8:
					filters = "CI8 Palette (*.ci8pal)|*.ci8pal|";
					break;
			}
			sfd.Filter = filters + "JASC Paint Shop Pro Palette (*.pal)|*.pal|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				// save that
				using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
				{
					switch (CurEditMode)
					{
						case CiEditorModes.Ci4:
							{
								Ci4Palette export = new Ci4Palette();
								export.ImportList(ColorList);

								if (Path.GetExtension(sfd.FileName) == ".pal")
								{
									// export JASC Paint Shop Pro palette

									using (StreamWriter sw = new StreamWriter(fs))
									{
										export.ExportJasc(sw);

										if (export.SubPalettes.Count > 0)
										{
											MessageBox.Show("CI4 subpalette export not yet implemented");
											/*
											int subPal = 1;
											foreach (Ci4Palette s in export.SubPalettes)
											{
												subPal++;
											}
											*/
										}
									}
								}
								else
								{
									// export .ci4pal
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										export.WriteData(bw);
									}
								}
							}
							break;
						case CiEditorModes.Ci8:
							{
								Ci8Palette export = new Ci8Palette();
								export.ImportList(ColorList);

								if (Path.GetExtension(sfd.FileName) == ".pal")
								{
									// export JASC Paint Shop Pro palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										export.ExportJasc(sw);
									}
								}
								else
								{
									// export .ci8pal
									using (BinaryWriter bw = new BinaryWriter(fs))
									{
										export.WriteData(bw);
									}
								}
							}
							break;
					}
				}
			}
		}
		#endregion
	}
}
