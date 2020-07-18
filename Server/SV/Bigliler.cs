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
    public partial class Bigliler : Form
    {
        Socket sck; public string ID = "";
        public Bigliler(Socket socket, string aydi)
        {
            InitializeComponent();
            sck = socket; ID = aydi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            byte[] bilgi = Encoding.UTF8.GetBytes("SARJ|");
            Gonderici.Send(sck, bilgi, 0, bilgi.Length, 59999);
            }
            catch (Exception) { }
        }
    }
}
