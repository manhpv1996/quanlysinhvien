using ProjectQUANLYSINHVIEN.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQUANLYSINHVIEN
{
    public partial class fQuanlychung : Form
    {
        public fQuanlychung()
        {
            this.BackgroundImage = Properties.Resources.background;
            InitializeComponent();
            var timer = new Timer();
            //change the background image every second  
            timer.Interval = 3000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void đăngKýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDangky fdangky = new fDangky();
            fdangky.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoimatkhau fdoimk = new fDoimatkhau();
            fdoimk.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhoa fkhoa = new fKhoa();
            fkhoa.ShowDialog();
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLop flop = new fLop();
            flop.ShowDialog();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSinhvien fsinhvien = new fSinhvien();
            fsinhvien.ShowDialog();

        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMonhoc fmonhoc = new fMonhoc();
            fmonhoc.ShowDialog();
        }

        private void kếtQuảHọcTậpSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKetquahoctap fkqht = new fKetquahoctap();
            fkqht.ShowDialog();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //add image in list from resource file.  
            List<Bitmap> lisimage = new List<Bitmap>();
            lisimage.Add(Properties.Resources.background);
            lisimage.Add(Properties.Resources.background1);
            lisimage.Add(Properties.Resources.background2);
            lisimage.Add(Properties.Resources.background3);
            var indexbackimage = DateTime.Now.Second % lisimage.Count;
            this.BackgroundImage = lisimage[indexbackimage];
        }
    }
}
