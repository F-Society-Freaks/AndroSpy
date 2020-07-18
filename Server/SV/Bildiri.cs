using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class Bildiri : Form
    {
        public Bildiri(string isim, string marka_model, Image bayrak)
        {
            InitializeComponent();
            Screen ekran = Screen.FromPoint(Location);
            Location = new Point(ekran.WorkingArea.Right - Width, ekran.WorkingArea.Bottom - Height);
            label1.Text = isim; label2.Text = marka_model; pictureBox1.Image = bayrak;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
