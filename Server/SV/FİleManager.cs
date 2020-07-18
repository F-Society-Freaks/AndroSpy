using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{ 
    public partial class FİleManager : Form
    {
        Socket soketimiz;
        public string ID = "";
        public FİleManager(Socket s, string aydi)
        {
            InitializeComponent();
            soketimiz = s;
            ID = aydi;
        }
        
        public void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            Invoke((MethodInvoker)delegate {                                     
            //int startTickCount = Environment.TickCount;
            int sent = 0;  // how many bytes is already sent
            do
            {
               // if (Environment.TickCount > startTickCount + timeout)
                 //   throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                    try
                    {
                     
                        //Text += " "+ sent.ToString() + "/" + size.ToString() + " ";
                          //  Text += ((100 / size) * sent).ToString();
                        //yzd.progressBar1.Value = ((100 / size) * sent);
                        //yzd.label2.Text = "İşlemdeki Dosya: "+ listView1.SelectedItems[0].Text;
                        Application.DoEvents();
                       
                    }
                    catch (Exception) { }
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably full, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (sent < size);
            });
        }
        private void indirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("INDIR|"+listView1.SelectedItems[0].SubItems[1].Text + "/" + listView1.SelectedItems[0].Text));
            }
            catch (Exception) { }
        }

        private void yükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog() {
                Multiselect = false, Filter = "Tüm dosyalar|*.*", 
               Title = "Karşıya yüklemek için bir dosya seçiniz.."
           })
            {
                if(op.ShowDialog() == DialogResult.OK)
                {
                    try { 
                    byte[] dosya_byte = Encoding.UTF8.GetBytes("DOSYABYTE|" + File.ReadAllBytes(op.FileName).Length.ToString() + "|" + op.FileName.Substring(
                        op.FileName.LastIndexOf(@"\") + 1));
                    Send(soketimiz, dosya_byte, 0, dosya_byte.Length, 59999);
                    Send(soketimiz, File.ReadAllBytes(op.FileName), 0, File.ReadAllBytes(op.FileName).Length, 59999);
                    }
                    catch (Exception) { }
                }
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("DOSYA|"));
            }
            catch (Exception) { }
        }

        private void sİlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("DELETE|" + listView1.SelectedItems[0].SubItems[1].Text + "/" + 
             listView1.SelectedItems[0].Text));
            }
            catch (Exception) { }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            byte[] ac_veri = Encoding.UTF8.GetBytes("DOSYAAC|" + listView1.SelectedItems[0].SubItems[1].Text + "/" +
             listView1.SelectedItems[0].Text);
            Send(soketimiz, ac_veri, 0, ac_veri.Length, 59999);
            }
            catch (Exception) { }
        }

        private void gizliÇalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("GIZLI|" + listView1.SelectedItems[0].SubItems[1].Text + "/" +
             listView1.SelectedItems[0].Text));
            }
            catch (Exception) { }
        }

        private void açToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try { 
            byte[] ac_veri = Encoding.UTF8.GetBytes("DOSYAAC|" + listView2.SelectedItems[0].SubItems[1].Text);
            Send(soketimiz, ac_veri, 0, ac_veri.Length, 59999);
            }
            catch (Exception) { }
        }

        private void yenileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("DOSYA|"));
            }
            catch (Exception) { }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("DELETE|" + listView2.SelectedItems[0].SubItems[1].Text));
            }
            catch (Exception) { }
        }

        private void gizliÇalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try { 
            soketimiz.Send(Encoding.UTF8.GetBytes("GIZLI|" + listView2.SelectedItems[0].SubItems[1].Text));
            }
            catch (Exception) { }
        }

        private void indirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                soketimiz.Send(Encoding.UTF8.GetBytes("INDIR|" + listView2.SelectedItems[0].SubItems[1].Text));
            }
            catch (Exception) { }
        }
    }
}
