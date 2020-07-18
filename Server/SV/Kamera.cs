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
    public partial class Kamera : Form
    {
        Socket soketimiz;
        public string ID = "";
        public Kamera(Socket s, string aydi)
        {
            soketimiz = s;
            ID = aydi;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            try { 
            string cam = radioButton1.Checked ? "1" : "0";
           soketimiz.Send(Encoding.UTF8.GetBytes("CAM|" + cam));
            }
            catch (Exception) { }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
    }
}
