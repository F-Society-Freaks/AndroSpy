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
    public partial class CagriKayitlari : Form
    {
        Socket sock;
        public string ID = "";
        public CagriKayitlari(Socket sck, string aydi)
        {
            InitializeComponent();
            sock = sck; ID = aydi;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] yenile = Encoding.UTF8.GetBytes("CALLLOGS|");
            Gonderici.Send(sock, yenile, 0, yenile.Length, 59999);
            }
            catch (Exception) { }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try { 
                byte[] yenile = Encoding.UTF8.GetBytes("DELETECALL|" + listView1.SelectedItems[0].Text);
                Gonderici.Send(sock, yenile, 0, yenile.Length, 59999);
                }
                catch (Exception) { }
            }
        }
    }
}
