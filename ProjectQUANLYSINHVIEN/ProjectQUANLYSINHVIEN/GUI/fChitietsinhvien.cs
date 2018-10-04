using ProjectQUANLYSINHVIEN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQUANLYSINHVIEN.GUI
{
    public partial class fChitietsinhvien : Form
    {
        public fChitietsinhvien()
        {
            InitializeComponent();
        }

        private void fChitietsinhvien_Load(object sender, EventArgs e)
        {
            txbMasinhvien.Text = Chitietsinhvien.MASINHVIEN;
            txbTensinhvien.Text = Chitietsinhvien.TENSINHVIEN;
            txbKhoa.Text = Chitietsinhvien.KHOA;
            txbLop.Text = Chitietsinhvien.LOP;
            txbGioitinh.Text = Chitietsinhvien.GIOITINH;
            txbDiachi.Text = Chitietsinhvien.DIACHI;

            
            pictureBoxAvatar.Image = Image.FromFile(Chitietsinhvien.ANH);
            this.pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
          
        }
    }
}
