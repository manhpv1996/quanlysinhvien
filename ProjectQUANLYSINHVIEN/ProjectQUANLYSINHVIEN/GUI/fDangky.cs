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
    public partial class fDangky : Form
    {
        admin_BLL admin_bll;
        
        DataTable dt = new DataTable();
        public fDangky()
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

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (!kiemtradauvao())
            {
                return;
            }
            else
            {
                admin.TENDANGNHAP = txbTendangnhap.Text;
               admin.MATKHAU = txbMatkhau.Text;
                dt = admin_bll.getTendangnhap(admin.TENDANGNHAP);
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại , vui lòng nhập tên tài khoản khác ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbTendangnhap.Clear();
                    txbTendangnhap.Focus();

                    return;
                }
                else
                {
                    if (admin_bll.insertAdmin())
                    {
                        MessageBox.Show("Đăng ký thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }
    }
}
