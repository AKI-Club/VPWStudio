using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	/// <summary>
	/// Body Type, Costume, and Head/Mask Form for Virtual Pro-Wrestling 2.
	/// </summary>
	public partial class CostumeDefs_VPW2 : Form
	{
		//public List<CostumeTextures> Textures;

		public CostumeDefs_VPW2()
		{
			InitializeComponent();
		}

		#region Body Types
		private void LoadBodyTypes()
		{
			// $BODYTYPE_MODELS
			// $BODYTYPE_TEXTURES
		}

		private void lbBodyTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbBodyTypes.SelectedIndex < 0)
			{
				return;
			}

			// new body type selected
		}
		#endregion

		#region Costumes
		private void LoadCostumes()
		{
			// lower attire models, textures
			// upper attire models, textures
			// entrance attire models, textures
			// glove models, textures
			// textures for elbowpad, wristband, kneepad, boot
		}

		private void cbCostumeBodyType_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cbCostumeCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbCostumeCategory.SelectedIndex < 0)
			{
				return;
			}

			// new costume category
		}

		private void lbCostumeItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbCostumeItems.SelectedIndex < 0)
			{
				return;
			}

			// new costume item
		}
		#endregion

		#region Heads/Masks
		private void LoadHeadsMasks()
		{
		}

		private void cbHeadCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbHeadCategory.SelectedIndex < 0)
			{
				return;
			}

			// new head category
		}

		private void lbHeadEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbHeadEntries.SelectedIndex < 0)
			{
				return;
			}

			// new head item
		}

		private void cbMaskCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMaskCategory.SelectedIndex < 0)
			{
				return;
			}

			// new mask category
		}

		private void lbMaskEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbMaskEntries.SelectedIndex < 0)
			{
				return;
			}

			// new mask item
		}
		#endregion
	}
}
