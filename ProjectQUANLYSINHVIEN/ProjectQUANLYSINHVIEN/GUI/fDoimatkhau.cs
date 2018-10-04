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
    public partial class fDoimatkhau : Form
    {
        admin_BLL admin_bll;
        public fDoimatkhau()
        {
            InitializeComponent();
            admin_bll = new admin_BLL();

        }

        private void fDoimatkhau_Load(object sender, EventArgs e)
        {
            txbTendangnhap.Text = admin.TENDANGNHAP;
            txbMatkhauhientai.Text = admin.MATKHAU;
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbMatkhaumoi.Text))
            {
                MessageBox.Show("Bạn không được để trống thư mục này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMatkhaumoi.Focus();
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txbNhaplaimatkhau.Text))
                {
                    MessageBox.Show("Bạn không được để trống thư mục này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbNhaplaimatkhau.Focus();
                    return;
                }
                else
                {
                    if (txbMatkhaumoi.Text.Equals(txbNhaplaimatkhau.Text))
                    {
                        admin.MATKHAU = txbNhaplaimatkhau.Text;
                        if (admin_bll.updateAdmin())
                        {
                            MessageBox.Show("cập thật thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công ! ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu nhập lại chưa giống với mật khẩu mới , vui lòng kiểm tra lại ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbNhaplaimatkhau.Focus();
                        return;
                    }

                }
            }
        }
    }
}
