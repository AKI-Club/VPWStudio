using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors.NoMercy
{
	public partial class StoryMode_NoMercy : Form
	{
		// todo: figure out where these file IDs are defined, and if possible, read them from ROM

		// chapter titles file ID 01DD

		// match information file IDs
		/*
		 * 01DE - World Heavyweight
		 * 01DF - Tag Team
		 * 01E0 - Intercontinental
		 * 01E1 - European
		 * 01E2 - Hardcore
		 * 01E3 - Light Heavyweight
		 * 01E4 - Women's
		 * 01E5 - No Mercy GBC
		 */

		// dialog file IDs
		/*
		 * 01E6 - World Heavyweight
		 * 01E7 - Tag Team
		 * 01E8 - Intercontinental
		 * 01E9 - European
		 * 01EA - Hardcore
		 * 01EB - Light Heavyweight
		 * 01EC - Women's
		 * 01ED - No Mercy GBC
		 */

		public StoryMode_NoMercy()
		{
			InitializeComponent();
			cbStoryPath.SelectedIndex = 0;

			// todo: get names from file ID 01DC, entries 12-19, instead of assuming them
		}

		private void cbStoryPath_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbStoryPath.SelectedIndex >= 0)
			{
			}
		}
	}
}
