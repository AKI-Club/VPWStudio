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
		private enum CiEditorModes
		{
			Ci4,
			Ci8
		}
		private CiEditorModes CurEditMode;

		public Ci4Palette CurPaletteCI4;
		public Ci8Palette CurPaletteCI8;

		private Bitmap PalPreviewBitmap;

		/// <summary>
		/// List of all colors in this palette.
		/// </summary>
		private List<UInt16> ColorList = new List<UInt16>();

		// I need this hack because of how NumericUpDown handles ValueChanged events...
		private bool ChangingColors = false;

		private int FileID;

		private int PaletteNumber = 0;

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

				cbPalettes.Items.Add("Main Palette");
				if (CurPaletteCI4.SubPalettes.Count > 0)
				{
					cbPalettes.BeginUpdate();
					int subPalCount = 1;
					foreach (Ci4Palette sub in CurPaletteCI4.SubPalettes)
					{
						cbPalettes.Items.Add(String.Format("Sub-Palette {0}", subPalCount));
						ColorList.AddRange(sub.Entries);
						subPalCount++;
					}
					cbPalettes.EndUpdate();
				}
				cbPalettes.SelectedIndex = 0;
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

				cbPalettes.Enabled = false;
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

			PopulateColorList();
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
		private void PopulateColorList()
		{
			cbColorEntries.Items.Clear();
			cbColorEntries.BeginUpdate();

			int numEntries = ColorList.Count;
			if (CurEditMode == CiEditorModes.Ci4)
			{
				numEntries = 16;
			}
			for (int i = 0; i < numEntries; i++)
			{
				cbColorEntries.Items.Add(String.Format("Color {0:D3}", i + 1));
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

			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					{
						// CI4 depends on how many subpalettes we have
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
						// CI8 is easy; draw 'em all
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
		/// Update the color textboxes and transparency checkbox.
		/// </summary>
		/// <param name="c"></param>
		private void UpdateColorValues(Color c)
		{
			nudRed.Value = c.R / 8;
			nudGreen.Value = c.G / 8;
			nudBlue.Value = c.B / 8;
			cbTransparent.Checked = (c.A == 0);
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

			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					if (PaletteNumber == 0)
					{
						panelCurColor.BackColor = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
					}
					else
					{
						panelCurColor.BackColor = N64Colors.Value5551ToColor(ColorList[(16*PaletteNumber) + cbColorEntries.SelectedIndex]);
					}
					break;

				case CiEditorModes.Ci8:
					{
						panelCurColor.BackColor = N64Colors.Value5551ToColor(ColorList[cbColorEntries.SelectedIndex]);
					}
					break;
			}
		}

		private int GetColorNumber()
		{
			int colorNum = 0;
			switch (CurEditMode)
			{
				case CiEditorModes.Ci4:
					{
						if (cbPalettes.SelectedIndex <= 0)
						{
							colorNum = cbColorEntries.SelectedIndex;
						}
						else
						{
							colorNum = (cbColorEntries.SelectedIndex) + (cbPalettes.SelectedIndex * 16);
						}
					}
					break;
				case CiEditorModes.Ci8:
					{
						colorNum = cbColorEntries.SelectedIndex;
					}
					break;
			}
			return colorNum;
		}

		/// <summary>
		/// Selected a new palette
		/// </summary>
		private void cbPalettes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbPalettes.SelectedIndex < 0)
			{
				return;
			}
			PaletteNumber = cbPalettes.SelectedIndex;

			ChangingColors = true;

			UpdateCurColorSwatch();
			UpdateColorValues(N64Colors.Value5551ToColor(ColorList[GetColorNumber()]));

			ChangingColors = false;
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

			UpdateCurColorSwatch();
			UpdateColorValues(N64Colors.Value5551ToColor(ColorList[GetColorNumber()]));
			
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
			ofd.Filter = filters + SharedStrings.FileFilter_Palettes;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				// load that
				using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
				{
					switch (CurEditMode)
					{
						case CiEditorModes.Ci4:
							{
								Ci4Palette import = CurPaletteCI4;
								if (Path.GetExtension(ofd.FileName) == ".vpwspal")
								{
									// import VPW Studio palette
									ColorList.Clear();
									ColorList.AddRange(import.Entries);
									using (StreamReader sr = new StreamReader(fs))
									{
										import = new Ci4Palette();
										import.ImportVpwsPal(sr);
										ColorList.Clear();
										ColorList.AddRange(import.Entries);
										if (import.SubPalettes.Count > 0)
										{
											foreach (Ci4Palette sub in import.SubPalettes)
											{
												ColorList.AddRange(sub.Entries);
											}
										}
									}
								}
								else if (Path.GetExtension(ofd.FileName) == ".pal")
								{
									// import JASC Paint Shop Pro palette
									ColorList.Clear();
									ColorList.AddRange(import.Entries);
									using (StreamReader sr = new StreamReader(fs))
									{
										if (cbPalettes.SelectedIndex > 0)
										{
											import.ImportJascSubPal(sr, cbPalettes.SelectedIndex - 1);
											ColorList.RemoveRange((cbPalettes.SelectedIndex * 16), 16);
											ColorList.InsertRange((cbPalettes.SelectedIndex * 16), import.SubPalettes[cbPalettes.SelectedIndex - 1].Entries);
										}
										else
										{
											import.ImportJasc(sr);
											ColorList.RemoveRange(0, 16);
											ColorList.InsertRange(0, import.Entries);
										}
									}
								}
								else if (Path.GetExtension(ofd.FileName) == ".gpl")
								{
									// import GIMP palette
									ColorList.Clear();
									ColorList.AddRange(import.Entries);
									using (StreamReader sr = new StreamReader(fs))
									{
										if (cbPalettes.SelectedIndex > 0)
										{
											Program.ErrorMessageBox("Haven't implemented GIMP subpalette import yet, sorry.");
											return;
										}
										else
										{
											Program.ErrorMessageBox("I do not trust GIMP palette import to work at the moment, sorry.");
											return;
											/*
											import.ImportGimp(sr);
											ColorList.RemoveRange(0, 16);
											ColorList.InsertRange(0, import.Entries);
											*/
										}
									}
								}
								else if (Path.GetExtension(ofd.FileName) == ".ci4pal")
								{
									using (BinaryReader br = new BinaryReader(fs))
									{
										import = new Ci4Palette();
										import.ReadData(br, true);
										ColorList.Clear();
										ColorList.AddRange(import.Entries);
										if (import.SubPalettes.Count > 0)
										{
											foreach (Ci4Palette sub in import.SubPalettes)
											{
												ColorList.AddRange(sub.Entries);
											}
										}
									}
								}
								CurPaletteCI4 = import;
								UpdateCurColorSwatch();
								UpdatePreview();
							}
							break;
						case CiEditorModes.Ci8:
							{
								Ci8Palette import = new Ci8Palette();
								if (Path.GetExtension(ofd.FileName) == ".vpwspal")
								{
									// import VPW Studio Palette
									using (StreamReader sr = new StreamReader(fs))
									{
										import.ImportVpwsPal(sr);
									}
								}
								else if (Path.GetExtension(ofd.FileName) == ".pal")
								{
									// import JASC Paint Shop Pro palette
									using (StreamReader sr = new StreamReader(fs))
									{
										import.ImportJasc(sr);
									}
								}
								else if (Path.GetExtension(ofd.FileName) == ".gpl")
								{
									Program.ErrorMessageBox("GIMP CI8 palette import currently not implemented.");
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
			sfd.Filter = filters + SharedStrings.FileFilter_Palettes;
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

								if (Path.GetExtension(sfd.FileName) == ".vpwspal")
								{
									// export VPW Studio palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										export.ExportVpwsPal(sw);
									}
								}
								else if (Path.GetExtension(sfd.FileName) == ".pal")
								{
									// export JASC Paint Shop Pro palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										// export based on cbPalettes.SelectedIndex
										if (cbPalettes.SelectedIndex > 0)
										{
											export.ExportJascSubPal(sw, cbPalettes.SelectedIndex - 1);
										}
										else
										{
											export.ExportJasc(sw);
										}
									}
								}
								else if (Path.GetExtension(sfd.FileName) == ".gpl")
								{
									// export GIMP palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										// export based on cbPalettes.SelectedIndex
										if (cbPalettes.SelectedIndex > 0)
										{
											export.ExportGimpSubPal(sw, cbPalettes.SelectedIndex - 1, string.Format("{0:X4}", FileID));
										}
										else
										{
											export.ExportGimp(sw, String.Format("File ID 0x{0:X4}", FileID));
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

								if (Path.GetExtension(sfd.FileName) == ".vpwspal")
								{
									// export VPW Studio palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										export.ExportVpwsPal(sw);
									}
								}
								else if (Path.GetExtension(sfd.FileName) == ".pal")
								{
									// export JASC Paint Shop Pro palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										export.ExportJasc(sw);
									}
								}
								else if (Path.GetExtension(sfd.FileName) == ".gpl")
								{
									// export GIMP palette
									using (StreamWriter sw = new StreamWriter(fs))
									{
										export.ExportGimp(sw, String.Format("File ID 0x{0:X4}", FileID));
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
