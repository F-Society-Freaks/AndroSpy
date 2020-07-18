namespace SV
{
    partial class FİleManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FİleManager));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.indirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sİlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gizliÇalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.açToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.indirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yenileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gizliÇalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(669, 315);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dosya İsmi";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dizin Adı";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Uzantı";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Boyut";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Konum";
            this.columnHeader5.Width = 140;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indirToolStripMenuItem,
            this.yükleToolStripMenuItem,
            this.açToolStripMenuItem,
            this.yenileToolStripMenuItem,
            this.sİlToolStripMenuItem,
            this.gizliÇalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 136);
            // 
            // indirToolStripMenuItem
            // 
            this.indirToolStripMenuItem.Name = "indirToolStripMenuItem";
            this.indirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.indirToolStripMenuItem.Text = "İndir";
            this.indirToolStripMenuItem.Click += new System.EventHandler(this.indirToolStripMenuItem_Click);
            // 
            // yükleToolStripMenuItem
            // 
            this.yükleToolStripMenuItem.Name = "yükleToolStripMenuItem";
            this.yükleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.yükleToolStripMenuItem.Text = "Yükle";
            this.yükleToolStripMenuItem.Click += new System.EventHandler(this.yükleToolStripMenuItem_Click);
            // 
            // açToolStripMenuItem
            // 
            this.açToolStripMenuItem.Name = "açToolStripMenuItem";
            this.açToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.açToolStripMenuItem.Text = "Aç";
            this.açToolStripMenuItem.Click += new System.EventHandler(this.açToolStripMenuItem_Click);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // sİlToolStripMenuItem
            // 
            this.sİlToolStripMenuItem.Name = "sİlToolStripMenuItem";
            this.sİlToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.sİlToolStripMenuItem.Text = "Sİl";
            this.sİlToolStripMenuItem.Click += new System.EventHandler(this.sİlToolStripMenuItem_Click);
            // 
            // gizliÇalToolStripMenuItem
            // 
            this.gizliÇalToolStripMenuItem.Name = "gizliÇalToolStripMenuItem";
            this.gizliÇalToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.gizliÇalToolStripMenuItem.Text = "Gizli Çal";
            this.gizliÇalToolStripMenuItem.Click += new System.EventHandler(this.gizliÇalToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 347);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cihaz";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(675, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SD Kart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView2.ContextMenuStrip = this.contextMenuStrip2;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(669, 315);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dosya İsmi";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Dizin Adı";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Uzantı";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Boyut";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Konum";
            this.columnHeader10.Width = 140;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.açToolStripMenuItem1,
            this.indirToolStripMenuItem1,
            this.yenileToolStripMenuItem1,
            this.silToolStripMenuItem,
            this.gizliÇalToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(117, 114);
            // 
            // açToolStripMenuItem1
            // 
            this.açToolStripMenuItem1.Name = "açToolStripMenuItem1";
            this.açToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.açToolStripMenuItem1.Text = "Aç";
            this.açToolStripMenuItem1.Click += new System.EventHandler(this.açToolStripMenuItem1_Click);
            // 
            // indirToolStripMenuItem1
            // 
            this.indirToolStripMenuItem1.Name = "indirToolStripMenuItem1";
            this.indirToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.indirToolStripMenuItem1.Text = "İndir";
            this.indirToolStripMenuItem1.Click += new System.EventHandler(this.indirToolStripMenuItem1_Click);
            // 
            // yenileToolStripMenuItem1
            // 
            this.yenileToolStripMenuItem1.Name = "yenileToolStripMenuItem1";
            this.yenileToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.yenileToolStripMenuItem1.Text = "Yenile";
            this.yenileToolStripMenuItem1.Click += new System.EventHandler(this.yenileToolStripMenuItem1_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // gizliÇalToolStripMenuItem1
            // 
            this.gizliÇalToolStripMenuItem1.Name = "gizliÇalToolStripMenuItem1";
            this.gizliÇalToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.gizliÇalToolStripMenuItem1.Text = "Gizli Çal";
            this.gizliÇalToolStripMenuItem1.Click += new System.EventHandler(this.gizliÇalToolStripMenuItem1_Click);
            // 
            // FİleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 347);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FİleManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dosya Yöneticisi";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem indirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yükleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripMenuItem sİlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gizliÇalToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem açToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem indirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gizliÇalToolStripMenuItem1;
    }
}