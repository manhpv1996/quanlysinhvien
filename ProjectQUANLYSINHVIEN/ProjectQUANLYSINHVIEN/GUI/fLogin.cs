using ProjectQUANLYSINHVIEN.BLL;
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

namespace ProjectQUANLYSINHVIEN
{
    public partial class fLogin : Form
    {
       
        admin_BLL admin_bll;
        DataTable dt = new DataTable();
        
        public fLogin()
        {
            
            InitializeComponent();
            admin_bll = new admin_BLL();
        }
        public bool kiemtradauvao()
        {
            if (string.IsNullOrWhiteSpace(txbTendangnhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTendangnhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbMatkhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMatkhau.Focus();
                return false;
            }
            return true;
        }
        public void btnDangnhap_Click(object sender, EventArgs e)
        {
            fQuanlychung fql = new fQuanlychung();
            if (!kiemtradauvao())
            {
                return;
            }
            else 
            {
                admin.TENDANGNHAP = txbTendangnhap.Text;
                admin.MATKHAU = txbMatkhau.Text;
                dt = admin_bll.getAmin();
                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    fql.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại ! ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
            }
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
         
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình không ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
