using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTableEditCommentDialog : Form
	{
		public string NewComment;

		public FileTableEditCommentDialog(int curID, string curComment)
		{
			InitializeComponent();
			labelComment.Text = String.Format("Commen&t for ID {0:X4}",curID);
			tbComment.Text = curComment;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.NewComment = tbComment.Text;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
