using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class MoveAnimProp_SearchDialog : Form
	{
		/// <summary>
		/// Possible search types.
		/// </summary>
		public enum MoveAnimPropSearchType
		{
			/// <summary>
			/// Search for "corrected" file ID
			/// </summary>
			FileID,

			/// <summary>
			/// Search for raw animation offset
			/// </summary>
			AnimOffset,

			/// <summary>
			/// Search for damage index value
			/// </summary>
			DamageIndex
		};

		// todo: set maximum possible values for each game?

		/// <summary>
		/// The desired search type.
		/// </summary>
		public MoveAnimPropSearchType SearchType;

		/// <summary>
		/// The desired search value.
		/// </summary>
		public short SearchValue = 0;

		public MoveAnimProp_SearchDialog()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			SearchValue = (short)nudSearchNum.Value;
			if (rbAnimID.Checked)
			{
				SearchType = MoveAnimPropSearchType.FileID;
			}
			else if (rbAnimOffset.Checked)
			{
				SearchType = MoveAnimPropSearchType.AnimOffset;
			}
			else if (rbDamageIndex.Checked)
			{
				SearchType = MoveAnimPropSearchType.DamageIndex;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
