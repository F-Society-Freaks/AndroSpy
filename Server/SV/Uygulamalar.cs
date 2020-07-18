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
    public partial class Uygulamalar : Form
    {
        Socket socket; public string ID = "";
        public Uygulamalar(Socket sck, string aydi)
        {
            InitializeComponent();
            socket = sck; ID = aydi;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] laz_ziya = Encoding.UTF8.GetBytes("APPLICATIONS|");
            Gonderici.Send(socket, laz_ziya, 0, laz_ziya.Length, 59999);
            }
            catch (Exception) { }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] laz_ziya = Encoding.UTF8.GetBytes("OPENAPP|" + listView1.SelectedItems[0].SubItems[1].Text);
            Gonderici.Send(socket, laz_ziya, 0, laz_ziya.Length, 59999);
            }
            catch (Exception) { }
        }
    }
}
