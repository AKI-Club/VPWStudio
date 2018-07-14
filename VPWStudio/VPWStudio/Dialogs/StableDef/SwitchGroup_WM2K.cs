using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio
{
	/// <summary>
	/// Move a wrestler to another stable.
	/// </summary>
	public partial class SwitchGroup_WM2K : Form
	{
		/// <summary>
		/// ID2 of wrestler to move.
		/// </summary>
		public byte MoveWrestler;

		/// <summary>
		/// List of stables.
		/// </summary>
		/// Needs to be pared down to exclude full groups.
		public SortedList<int, StableDefinition> Stables;

		/// <summary>
		/// Possible stables that wrestlers can be moved to.
		/// </summary>
		private Dictionary<int, StableDefinition> FreeStables = new Dictionary<int, StableDefinition>();

		/// <summary>
		/// Current stable number.
		/// </summary>
		private int CurStableNum;

		/// <summary>
		/// Target stable number.
		/// </summary>
		public int NewStableNum;

		public SwitchGroup_WM2K(byte _wres, int _curStable, SortedList<int, StableDefinition> _stables)
		{
			MoveWrestler = _wres;
			Stables = _stables;
			CurStableNum = _curStable;

			InitializeComponent();
			labelWrestlerID.Text = String.Format(labelWrestlerID.Text, MoveWrestler, CurStableNum);

			for (int i = 0; i < Stables.Count; i++)
			{
				// only include stables if:
				// 1. They have free slots
				// 2. They're not the original stable
				if (!Stables[i].IsGroupFull() && i != CurStableNum)
				{
					FreeStables.Add(i, Stables[i]);
				}
			}

			cbTargetGroup.BeginUpdate();
			foreach (KeyValuePair<int, StableDefinition> sd in FreeStables)
			{
				cbTargetGroup.Items.Add(sd.Key);
			}
			cbTargetGroup.EndUpdate();
			cbTargetGroup.SelectedIndex = 0;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			NewStableNum = int.Parse(cbTargetGroup.Items[cbTargetGroup.SelectedIndex].ToString());
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
