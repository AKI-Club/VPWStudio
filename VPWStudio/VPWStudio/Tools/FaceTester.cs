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
	public partial class FaceTester : Form
	{
		private UInt16 SkinColor = 0x1745;
		private UInt16 Face = 0x17F0;
		private UInt16 HairColor = 0x17E5;
		private UInt16 FrontHair = 0x185E;
		private UInt16 FacialHair = 0;
		private UInt16 FacialHairColor = 0x17EE;
		private UInt16 FacePaint = 0;
		private UInt16 Accessory = 0;

		private Bitmap FacePreview = new Bitmap(32,64);

		private byte[] DefaultFaceDisplacement_FacialHair = new byte[110];
		private byte[] DefaultFaceDisplacement_PaintAccessories = new byte[110];

		private byte[] Displacement_FacialHair = new byte[32];
		private byte[] Displacement_Paint = new byte[32];
		private byte[] Displacement_Accessories = new byte[32];

		private byte[] FacepaintType = new byte[32];
		private byte[] AccessoryType = new byte[32];

		public FaceTester()
		{
			InitializeComponent();
			InitDisplacementTables();

			cbFace.BeginUpdate();
			cbFrontHair.BeginUpdate();
			cbFrontHair.Items.Add("None");
			for (int i = 0; i < 110; i++)
			{
				cbFace.Items.Add(String.Format("{0:D3}", i+1));
				cbFrontHair.Items.Add(String.Format("{0:D3}", i+1));
			}
			cbFace.EndUpdate();
			cbFrontHair.EndUpdate();

			cbSkinColor.SelectedIndex = 0;
			cbFace.SelectedIndex = 0;
			cbHairColor.SelectedIndex = 0;
			cbFrontHair.SelectedIndex = 0;
			cbFacialHair.SelectedIndex = 0;
			cbPaint.SelectedIndex = 0;
			cbAccessory.SelectedIndex = 0;
		}

		private void InitDisplacementTables()
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// todo: not hardcoded addresses
			
			romStream.Seek(0x469B8, SeekOrigin.Begin);
			DefaultFaceDisplacement_FacialHair = romReader.ReadBytes(110);

			romStream.Seek(0x46A28, SeekOrigin.Begin);
			DefaultFaceDisplacement_PaintAccessories = romReader.ReadBytes(110);

			romStream.Seek(0x46C58, SeekOrigin.Begin);
			Displacement_FacialHair = romReader.ReadBytes(32);

			romStream.Seek(0x46CD8, SeekOrigin.Begin);
			Displacement_Paint = romReader.ReadBytes(32);

			romStream.Seek(0x46CF8, SeekOrigin.Begin);
			Displacement_Accessories = romReader.ReadBytes(32);

			romStream.Seek(0x46D18, SeekOrigin.Begin);
			FacepaintType = romReader.ReadBytes(32);

			romStream.Seek(0x46D38, SeekOrigin.Begin);
			AccessoryType = romReader.ReadBytes(32);

			romReader.Close();
		}

		#region Changing Items!
		private void cbSkinColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbSkinColor.SelectedIndex < 0)
			{
				return;
			}
			SkinColor = (UInt16)(0x1745 + cbSkinColor.SelectedIndex);

			switch (SkinColor)
			{
				case 0x1745:
				case 0x1746:
					// Skin Colors 0,1
					FacialHairColor = 0x17EE;
					break;
				case 0x1747:
				case 0x1748:
					// Skin Colors 2,3
					FacialHairColor = 0x17ED;
					break;
			}

			UpdatePreview();
		}

		private void cbFace_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFace.SelectedIndex < 0)
			{
				return;
			}
			Face = (UInt16)(0x17F0 + cbFace.SelectedIndex);

			// update base displacement values
			//DefaultDisplacement_FacialHair
			//DefaultDisplacement_PaintAccessories

			UpdatePreview();
		}

		private void cbHairColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbHairColor.SelectedIndex < 0)
			{
				return;
			}

			// depends on skin color
			switch (SkinColor)
			{
				case 0x1745:
					// Skin Color 0
					HairColor = (UInt16)(0x17E5 + cbHairColor.SelectedIndex);
					break;
				case 0x1746:
					// Skin Color 1
					HairColor = (UInt16)(0x17DD + cbHairColor.SelectedIndex);
					break;
				case 0x1747:
				case 0x1748:
					// Skin Colors 2,3
					HairColor = (UInt16)(0x17D5 + cbHairColor.SelectedIndex);
					break;
			}
			UpdatePreview();
		}

		private void cbFrontHair_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFrontHair.SelectedIndex < 0)
			{
				return;
			}

			if (cbFrontHair.SelectedIndex == 0)
			{
				FrontHair = 0;
			}
			else
			{
				FrontHair = (UInt16)(0x185E + cbFrontHair.SelectedIndex - 1);
			}
			UpdatePreview();
		}

		private void cbFacialHair_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFacialHair.SelectedIndex < 0)
			{
				return;
			}

			if (cbFacialHair.SelectedIndex == 0)
			{
				FacialHair = 0;
			}
			else
			{
				FacialHair = (UInt16)(0x18CC + (cbFacialHair.SelectedIndex - 1));
			}
			UpdatePreview();
		}

		private void cbPaint_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbPaint.SelectedIndex < 0)
			{
				return;
			}

			if (cbPaint.SelectedIndex == 0)
			{
				FacePaint = 0;
			}
			else
			{
				FacePaint = (UInt16)(0x18EB + (cbPaint.SelectedIndex - 1));
			}
			UpdatePreview();
		}

		private void cbAccessory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbAccessory.SelectedIndex < 0)
			{
				return;
			}

			if (cbAccessory.SelectedIndex == 0)
			{
				Accessory = 0;
			}
			else
			{
				Accessory = (UInt16)(0x190A + (cbAccessory.SelectedIndex - 1));
			}
			UpdatePreview();
		}
		#endregion

		private void UpdatePreview()
		{
			Graphics g = Graphics.FromImage(FacePreview);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// get face color palette
			Ci8Palette SkinPal = new Ci8Palette();
			{
				MemoryStream fpalStream = new MemoryStream();
				BinaryWriter fpalWriter = new BinaryWriter(fpalStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fpalWriter, SkinColor);
				fpalStream.Seek(0, SeekOrigin.Begin);
				BinaryReader br = new BinaryReader(fpalStream);
				SkinPal.ReadData(br);
				br.Close();
				fpalWriter.Close();
			}

			// render face
			Ci8Texture FaceTex = new Ci8Texture();
			{
				MemoryStream faceStream = new MemoryStream();
				BinaryWriter faceWriter = new BinaryWriter(faceStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, faceWriter, Face);
				faceStream.Seek(0, SeekOrigin.Begin);
				BinaryReader br = new BinaryReader(faceStream);
				FaceTex.ReadData(br);
				br.Close();
				faceWriter.Close();
			}
			g.DrawImage(FaceTex.ToBitmap(SkinPal), new Point(0, 0));

			// facial hair
			if (FacialHair != 0)
			{
				Ci8Palette FacialHairPal = new Ci8Palette();
				// facial hair palette
				MemoryStream fhpalStream = new MemoryStream();
				BinaryWriter fhpalWriter = new BinaryWriter(fhpalStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fhpalWriter, FacialHairColor);
				fhpalStream.Seek(0, SeekOrigin.Begin);
				BinaryReader br = new BinaryReader(fhpalStream);
				FacialHairPal.ReadData(br);
				br.Close();
				fhpalWriter.Close();

				Ci8Texture FacialHairTex = new Ci8Texture();
				// facepaint texture
				MemoryStream fhtexStream = new MemoryStream();
				BinaryWriter fhtexWriter = new BinaryWriter(fhtexStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fhtexWriter, FacialHair);
				fhtexStream.Seek(0, SeekOrigin.Begin);
				br = new BinaryReader(fhtexStream);
				FacialHairTex.ReadData(br);
				br.Close();
				fhtexWriter.Close();

				// handle displacement
				int fDisplace = DefaultFaceDisplacement_FacialHair[cbFace.SelectedIndex];
				int hDisplace = Displacement_FacialHair[(cbFacialHair.SelectedIndex)];
				g.DrawImage(FacialHairTex.ToBitmap(FacialHairPal), new Point(0, (sbyte)(32 + (fDisplace - hDisplace))));
			}

			// facepaint
			if (FacePaint != 0)
			{
				Ci8Palette FacePaintPal = new Ci8Palette();
				// facepaint palette 1767
				MemoryStream fpalStream = new MemoryStream();
				BinaryWriter fpalWriter = new BinaryWriter(fpalStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fpalWriter, 0x1767);
				fpalStream.Seek(0, SeekOrigin.Begin);
				BinaryReader br = new BinaryReader(fpalStream);
				FacePaintPal.ReadData(br);
				br.Close();
				fpalWriter.Close();

				Ci8Texture FacePaintTex = new Ci8Texture();
				// facepaint texture
				MemoryStream fptexStream = new MemoryStream();
				BinaryWriter fptexWriter = new BinaryWriter(fptexStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fptexWriter, FacePaint);
				fptexStream.Seek(0, SeekOrigin.Begin);
				br = new BinaryReader(fptexStream);
				FacePaintTex.ReadData(br);
				br.Close();
				fptexWriter.Close();

				// handle displacement
				int selectedFP = cbPaint.SelectedIndex;
				int fDisplace = (sbyte)DefaultFaceDisplacement_PaintAccessories[cbFace.SelectedIndex];
				int pDisplace = (sbyte)Displacement_Paint[selectedFP];
				
				int displace = 0;
				if (FacepaintType[selectedFP] != 0)
				{
					displace = 0;
				}
				else if (pDisplace < 0)
				{
					displace = 0;
				}
				else
				{
					displace = (sbyte)fDisplace - (sbyte)pDisplace;
				}

				labelFValue.Text = String.Format("{0}", fDisplace);
				labelAValue.Text = String.Format("{0}", pDisplace);
				labelDValue.Text = String.Format("{0}", displace);

				g.DrawImage(FacePaintTex.ToBitmap(FacePaintPal), new Point(0, displace));
			}

			// accessory
			if(Accessory != 0)
			{
				Ci8Palette AccessoryPal = new Ci8Palette();
				// accessory palette 17EF
				MemoryStream apalStream = new MemoryStream();
				BinaryWriter apalWriter = new BinaryWriter(apalStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, apalWriter, 0x17EF);
				apalStream.Seek(0, SeekOrigin.Begin);
				BinaryReader br = new BinaryReader(apalStream);
				AccessoryPal.ReadData(br);
				br.Close();
				apalWriter.Close();

				Ci8Texture AccessoryTex = new Ci8Texture();
				// accessory texture
				MemoryStream atexStream = new MemoryStream();
				BinaryWriter atexWriter = new BinaryWriter(atexStream);
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, atexWriter, Accessory);
				atexStream.Seek(0, SeekOrigin.Begin);
				br = new BinaryReader(atexStream);
				AccessoryTex.ReadData(br);
				br.Close();
				atexWriter.Close();

				// todo: fix displacement
				int selectedAcc = cbAccessory.SelectedIndex;
				int fDisplace = (sbyte)DefaultFaceDisplacement_PaintAccessories[cbFace.SelectedIndex];
				int aDisplace = (sbyte)(Displacement_Accessories[selectedAcc]);
				int displace = 0;

				if (AccessoryType[selectedAcc] != 0)
				{
					displace = 0;
				}
				else if (aDisplace < 0)
				{
					displace = 0;
				}
				else
				{
					displace = (sbyte)fDisplace - (sbyte)aDisplace;
				}

				labelFValue.Text = String.Format("{0}", fDisplace);
				labelAValue.Text = String.Format("{0}", aDisplace);
				labelDValue.Text = String.Format("{0}", displace);

				g.DrawImage(AccessoryTex.ToBitmap(AccessoryPal), new Point(0, displace));
			}

			// front hair
			if (FrontHair != 0)
			{
				// hack: file ID 0x186D is CI8 for some dumb reason
				if (FrontHair == 0x186D)
				{
					// CI8 hair palette at file ID 0x192A
					Ci8Palette FrontHairPal = new Ci8Palette();
					MemoryStream fhpalStream = new MemoryStream();
					BinaryWriter fhpalWriter = new BinaryWriter(fhpalStream);
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fhpalWriter, 0x192A);
					fhpalStream.Seek(0, SeekOrigin.Begin);
					BinaryReader br = new BinaryReader(fhpalStream);
					FrontHairPal.ReadData(br);
					br.Close();
					fhpalWriter.Close();

					Ci8Texture FrontHairTex = new Ci8Texture();
					MemoryStream fhtexStream = new MemoryStream();
					BinaryWriter fhtexWriter = new BinaryWriter(fhtexStream);
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fhtexWriter, FrontHair);
					fhtexStream.Seek(0, SeekOrigin.Begin);
					br = new BinaryReader(fhtexStream);
					FrontHairTex.ReadData(br);
					br.Close();
					fhtexWriter.Close();

					g.DrawImage(FrontHairTex.ToBitmap(FrontHairPal), new Point(0, 0));
				}
				else
				{
					Ci4Palette FrontHairPal = new Ci4Palette();
					// front hair palette
					MemoryStream fhpalStream = new MemoryStream();
					BinaryWriter fhpalWriter = new BinaryWriter(fhpalStream);
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fhpalWriter, HairColor);
					fhpalStream.Seek(0, SeekOrigin.Begin);
					BinaryReader br = new BinaryReader(fhpalStream);
					FrontHairPal.ReadData(br);
					br.Close();
					fhpalWriter.Close();

					Ci4Texture FrontHairTex = new Ci4Texture();
					// front hair texture
					MemoryStream fhtexStream = new MemoryStream();
					BinaryWriter fhtexWriter = new BinaryWriter(fhtexStream);
					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, fhtexWriter, FrontHair);
					fhtexStream.Seek(0, SeekOrigin.Begin);
					br = new BinaryReader(fhtexStream);
					FrontHairTex.ReadData(br);
					br.Close();
					fhtexWriter.Close();

					g.DrawImage(FrontHairTex.ToBitmap(FrontHairPal), new Point(0, 0));
				}
			}

			romReader.Close();

			g.Dispose();
			pbFacePreview.Image = FacePreview;
		}

		private void FaceTester_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
