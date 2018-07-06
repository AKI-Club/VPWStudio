using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio
{
	public partial class SwapWrestler_VPW2 : Form
	{
		/// <summary>
		/// List of stables
		/// </summary>
		private SortedList<int, StableDefinition> Stables;

		/// <summary>
		/// ID2 of first wrestler to swap
		/// </summary>
		public byte Wrestler1_ID2;

		/// <summary>
		/// Current stable number of first wrestler to swap
		/// </summary>
		public int Wrestler1_CurStable;

		/// <summary>
		/// Current index of first wrestler to swap in stable id2 list
		/// </summary>
		public int Wrestler1_CurIndex;

		/// <summary>
		/// ID2 of second wrestler to swap
		/// </summary>
		public byte Wrestler2_ID2;

		/// <summary>
		/// Current stable number of second wrestler to swap
		/// </summary>
		public int Wrestler2_CurStable;

		/// <summary>
		/// Current index of second wrestler to swap in stable id2 list
		/// </summary>
		public int Wrestler2_CurIndex;

		public SwapWrestler_VPW2(SortedList<int, StableDefinition> _stables)
		{
			Stables = _stables;

			InitializeComponent();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// gotta do a lot of things

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
