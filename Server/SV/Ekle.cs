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
    public partial class Ekle : Form
    {
        Socket sckt;
        public Ekle(Socket sck)
        {
            InitializeComponent();
            sckt = sck;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try { 
            byte[] veriler = Encoding.UTF8.GetBytes("REHBERISIM|" + textBox1.Text + "=" + textBox2.Text + "=");
            Gonderici.Send(sckt, veriler, 0, veriler.Length, 59999);
            await Task.Delay(500);
        }
            catch (Exception) { }
             Close();
        }
    }
}
