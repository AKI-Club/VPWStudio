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
		public WrestlerEdit_VPW2()
		{
			InitializeComponent();
		}

		public void LoadData(GameSpecific.VPW2.WrestlerDefinition wdef)
		{
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			cbNameCall.SelectedIndex = wdef.NameCall;
			cbVoice1.SelectedIndex = wdef.Voice1;
			cbVoice2.SelectedIndex = wdef.Voice2;
			tbMovesetIndex.Text = String.Format("{0:X4}",wdef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", wdef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", wdef.AppearanceIndex);
			tbProfileIndex.Text = String.Format("{0:X4}", wdef.ProfileIndex);
		}
	}
}
