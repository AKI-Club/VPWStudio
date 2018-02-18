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
	public partial class WrestlerEdit_VPW2 : UserControl
	{
		public GameSpecific.VPW2.WrestlerDefinition CurWrestlerDef;

		public WrestlerEdit_VPW2()
		{
			InitializeComponent();
		}

		public void LoadData(GameSpecific.VPW2.WrestlerDefinition wdef)
		{
			this.CurWrestlerDef = wdef;

			tbWrestlerID4.Text = String.Format("{0:X4}", this.CurWrestlerDef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", this.CurWrestlerDef.WrestlerID2);
			cbThemeMusic.SelectedIndex = this.CurWrestlerDef.ThemeSong;
			cbNameCall.SelectedIndex = this.CurWrestlerDef.NameCall;
			cbVoice1.SelectedIndex = this.CurWrestlerDef.Voice1;
			cbVoice2.SelectedIndex = this.CurWrestlerDef.Voice2;
			tbMovesetIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.AppearanceIndex);
			tbProfileIndex.Text = String.Format("{0:X4}", this.CurWrestlerDef.ProfileIndex);
		}
	}
}
