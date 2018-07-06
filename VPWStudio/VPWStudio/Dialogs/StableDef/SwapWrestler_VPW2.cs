using System;
using System.Collections.Generic;
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
		/// Possible stables that wrestlers can be moved to.
		/// </summary>
		private Dictionary<int, StableDefinition> FreeStables = new Dictionary<int, StableDefinition>();

		/// <summary>
		/// Current stable number of first wrestler to swap
		/// </summary>
		public int Wrestler1_CurStable;

		/// <summary>
		/// Current index of first wrestler to swap in stable id2 list
		/// </summary>
		public int Wrestler1_CurIndex;

		/// <summary>
		/// Stable number of second wrestler to swap
		/// </summary>
		public int Wrestler2_CurStable;

		/// <summary>
		/// Index of second wrestler to swap in stable id2 list
		/// </summary>
		public int Wrestler2_CurIndex;

		public SwapWrestler_VPW2(SortedList<int, StableDefinition> _stables, int _wres1Stable, int _wres1Index)
		{
			Stables = _stables;
			Wrestler1_CurStable = _wres1Stable;
			Wrestler1_CurIndex = _wres1Index;

			InitializeComponent();

			// available stables: everything except the one the first wrestler is in
			// todo: handle situation where nobody is in a stable
			for (int i = 0; i < Stables.Count; i++)
			{
				if (i != Wrestler1_CurStable)
				{
					FreeStables.Add(i, Stables[i]);
				}
			}
			cbDestStable.BeginUpdate();
			foreach (KeyValuePair<int, StableDefinition> sd in FreeStables)
			{
				cbDestStable.Items.Add(sd.Key);
			}
			cbDestStable.EndUpdate();
			cbDestStable.SelectedIndex = 0;

			labelSwapWres1.Text = String.Format(labelSwapWres1.Text, Stables[Wrestler1_CurStable].WrestlerID2s[Wrestler1_CurIndex], Wrestler1_CurStable);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (lbDestStableWrestlers.SelectedIndex < 0)
			{
				Program.ErrorMessageBox("Please select a wrestler to swap.");
				return;
			}

			Wrestler2_CurStable = Stables.IndexOfKey(int.Parse(cbDestStable.Items[cbDestStable.SelectedIndex].ToString()));
			Wrestler2_CurIndex = lbDestStableWrestlers.SelectedIndex;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void PopulateWrestlers()
		{
			int stableNum = Stables.IndexOfKey(int.Parse(cbDestStable.Items[cbDestStable.SelectedIndex].ToString()));
			lbDestStableWrestlers.Items.Clear();
			lbDestStableWrestlers.BeginUpdate();
			for (int i = 0; i < FreeStables[stableNum].WrestlerID2s.Length; i++)
			{
				if (FreeStables[stableNum].WrestlerID2s[i] != 0)
				{
					lbDestStableWrestlers.Items.Add(String.Format("{0:X2}", FreeStables[stableNum].WrestlerID2s[i]));
				}
			}
			lbDestStableWrestlers.EndUpdate();
		}

		/// <summary>
		/// Switch stable
		/// </summary>
		private void cbDestStable_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbDestStable.SelectedIndex < 0)
			{
				return;
			}
			PopulateWrestlers();
		}
	}
}
