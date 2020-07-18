using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
namespace SV
{
    public partial class Konum : Form
    {
        Socket sck; public string ID = "";
        public Konum(Socket soket, string aydi)
        {
            InitializeComponent();
            sck = soket; ID = aydi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            byte[] konum_al = Encoding.UTF8.GetBytes("KONUM|");
            Gonderici.Send(sck, konum_al, 0, konum_al.Length, 59999);
            }
            catch (Exception) { }
        }
    }
}
