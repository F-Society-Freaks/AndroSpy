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
    public partial class Ayarlar : Form
    {
        Socket sock; public string ID = "";
        public Ayarlar(Socket sck, string aydi)
        {
            InitializeComponent();
            sock = sck; ID = aydi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yenile();
        }
        public void yenile()
        {
            try
            {
                byte[] bilgiler = Encoding.UTF8.GetBytes("VOLUMELEVELS|");
                Gonderici.Send(sock, bilgiler, 0, bilgiler.Length, 59999);
            }
            catch (Exception) { }
        }
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            try { 
            byte[] bilgiler = Encoding.UTF8.GetBytes("ZILSESI|" + trackBar1.Value.ToString());
            Gonderici.Send(sock, bilgiler, 0, bilgiler.Length, 59999);
            yenile();
        }
            catch (Exception) { }
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            try { 
            byte[] bilgiler = Encoding.UTF8.GetBytes("MEDYASESI|" + trackBar2.Value.ToString());
            Gonderici.Send(sock, bilgiler, 0, bilgiler.Length, 59999);
            yenile();
        }
            catch (Exception) { }
        }

        private void trackBar3_MouseUp(object sender, MouseEventArgs e)
        {
            try { 
            byte[] bilgiler = Encoding.UTF8.GetBytes("BILDIRIMSESI|" + trackBar3.Value.ToString());
            Gonderici.Send(sock, bilgiler, 0, bilgiler.Length, 59999);
            yenile();
            }
            catch (Exception) { }
        }
    }
}
