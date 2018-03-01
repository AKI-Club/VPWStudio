using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors.Revenge
{
	public partial class CostumeDefs_Revenge : Form
	{
		/// <summary>
		/// Costume definitions
		/// </summary>
		private List<CostumeDef_Early> CostumeDefs;

		/// <summary>
		/// Mask/Head definitions
		/// </summary>
		private List<MaskDef_Early> MaskDefs;

		public CostumeDefs_Revenge()
		{
			InitializeComponent();

			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			LoadCostumeDefs(br);
			LoadMaskDefs(br);

			br.Close();

			// populate lists
		}

		#region Data Load
		public void LoadCostumeDefs(BinaryReader br)
		{
			//
		}

		public void LoadMaskDefs(BinaryReader br)
		{
			// 
		}
		#endregion

		#region ListBox Population
		#endregion

		#region Costumes
		private void lbCostumes_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		#endregion

		#region Masks/Heads
		private void lbHeadsMasks_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		#endregion
	}
}
