using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class ClientTest : Form
	{
		/// <summary>
		/// Is the client currently connected to a server?
		/// </summary>
		private bool IsConnected;

		/// <summary>
		/// Port number used for communication.
		/// </summary>
		private int PortNumber;

		/// <summary>
		/// Socket for communicating with the server.
		/// </summary>
		private Socket Connection;

		private Timer MessageTimer;

		public ClientTest()
		{
			InitializeComponent();
			PortNumber = 49999; // stolen from old vpw music tool
			IsConnected = false;
			btnSendCommand.Enabled = false;

			MessageTimer = new Timer();
			MessageTimer.Interval = 1000;
		}

		#region Menu Items
		private void connectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!IsConnected)
			{
				// connect
				tsslblConStatus.Text = "Connecting...";

				try
				{
					Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					Connection.Connect("localhost", PortNumber);
				}
				catch (Exception ex)
				{
					IsConnected = false;
					connectToolStripMenuItem.Text = "Connect";
					tsslblConStatus.Text = "Not connected";

					Program.ErrorMessageBox(string.Format("Could not connect to server:\n{0}", ex.Message));
					return;
				}

				if (Connection.Connected)
				{
					IsConnected = true;
					connectToolStripMenuItem.Text = "Disconnect";
					tsslblConStatus.Text = String.Format("Connected on port {0}", PortNumber);
				}
			}
			else
			{
				// disconnect
				Connection.Disconnect(true);
				IsConnected = false;
				connectToolStripMenuItem.Text = "Connect";
				tsslblConStatus.Text = "Not connected";
			}

			btnSendCommand.Enabled = IsConnected;
		}

		private void portNumberToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClientTest_PortNumber pn = new ClientTest_PortNumber(PortNumber);
			if (pn.ShowDialog() == DialogResult.OK)
			{
				PortNumber = pn.PortNumber;
			}
		}

		private void clearOutputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tbOutput.Clear();
		}

		private void whatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Program.InfoMessageBox("This is meant to test communication between VPW Studio and an N64 emulator with some sort of scripting support.\n\nYes, it's another internal freem tool.");
		}
		#endregion

		private void btnSendCommand_Click(object sender, EventArgs e)
		{
			// [sanitize input]
			string cmdText = tbCommand.Text;

			// remove whitespace
			cmdText.Trim();
			cmdText.Replace(" ", string.Empty);

			// [validate input]

			// enforce a minimum command length
			if (cmdText.Length <= 1)
			{
				Program.ErrorMessageBox("Command must be at least 2 characters.");
				return;
			}

			// enforce even command length
			if (cmdText.Length % 2 != 0)
			{
				Program.ErrorMessageBox("Command must have an even amount of characters.");
				return;
			}

			// [parse input]
			// this part sucks, because we have to fuck with multiple substrings of a string
			for (int i = 0; i < cmdText.Length / 2; i++)
			{
				byte data;
				if (byte.TryParse(cmdText.Substring(i * 2, 2), NumberStyles.HexNumber, null, out data))
				{
					tbOutput.Text += string.Format("{0:X2}", data) + Environment.NewLine;
				}
				else
				{
					tbOutput.Text += string.Format("invalid input at byte #{1}: {0}", cmdText.Substring(i * 2, 2), i+1) + Environment.NewLine;
				}
			}

			tbOutput.Text += Environment.NewLine;

			// ok MAYBE we can send this off
		}

		private void ClientTest_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void ClientTest_FormClosing(object sender, FormClosingEventArgs e)
		{
			// actually close the connection before fucking off into the ether!!
			if (Connection.Connected)
			{
				Connection.Disconnect(false);
				Connection.Dispose();
			}
		}
	}
}
