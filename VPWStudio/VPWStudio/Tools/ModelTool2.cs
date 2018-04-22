using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// todo: what am I doing
using SharpDX;

namespace VPWStudio
{
	/// <summary>
	/// ModelTool2, an attempt to test SharpDX
	/// </summary>
	public partial class ModelTool2 : Form
	{
		private AkiModel CurModel = new AkiModel();

		public ModelTool2()
		{
			InitializeComponent();
		}

		private void LoadModel(int fileID)
		{
		}
	}
}
