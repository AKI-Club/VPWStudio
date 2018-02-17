using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Controls
{
	public partial class WrestlerEdit_NoMercy : UserControl
	{
		public GameSpecific.NoMercy.WrestlerDefinition CurWrestlerDef;

		public WrestlerEdit_NoMercy()
		{
			InitializeComponent();
		}

		public void LoadData(GameSpecific.NoMercy.WrestlerDefinition wdef)
		{
			this.CurWrestlerDef = wdef;

			tbWrestlerID4.Text = String.Format("{0:X4}", this.CurWrestlerDef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", this.CurWrestlerDef.WrestlerID2);
			//cbThemeMusic.SelectedIndex = this.CurWrestlerDef.ThemeSong;
			//cbEntranceVideo.SelectedIndex = this.CurWrestlerDef.EntranceVideo;
			tbUnknown.Text = String.Format("0x{0:X2}", wdef.Unknown);
			tbMovesetIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.AppearanceIndex);
			tbProfileIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.ProfileIndex);
		}
	}
}
