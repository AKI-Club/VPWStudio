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

		// file ID 01CC is used for main story mode stuff

		// chapter titles file ID 01DD
		// runtime NTSC-U v1.0 location (one of them, at least) 800F4E60

		// match information file IDs
		/*
		 * 01DE - World Heavyweight (runtime NTSC-U v1.0 loc 800F4E66; NTSC-U v1.0 Z64 offset 0x71386)
		 * 01DF - Tag Team (runtime NTSC-U v1.0 loc 800F4E6C; NTSC-U v1.0 Z64 offset 0x7138C)
		 * 01E0 - Intercontinental (runtime NTSC-U v1.0 loc 800F4E72)
		 * 01E1 - European (runtime NTSC-U v1.0 loc 800F4E78)
		 * 01E2 - Hardcore (runtime NTSC-U v1.0 loc 800F4E7E)
		 * 01E3 - Light Heavyweight (runtime NTSC-U v1.0 loc 800F4E84)
		 * 01E4 - Women's (runtime NTSC-U v1.0 loc 800F4E8A)
		 * 01E5 - No Mercy GBC (runtime NTSC-U v1.0 loc 800F4E90)
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
