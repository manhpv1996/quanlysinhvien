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

namespace ProjectQUANLYSINHVIEN.GUI
{
    public partial class fKhoa : Form
    {
        khoa_BLL khoa_bll = new khoa_BLL();
        khoa k = new khoa();
        public fKhoa()
        {
            InitializeComponent();
        }
        public bool kiemtradauvao()
        {
            if (string.IsNullOrWhiteSpace(txbMakhoa.Text))
            {
                MessageBox.Show("Mã khoa không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMakhoa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbTenkhoa.Text))
            {
                MessageBox.Show("Tên khoa không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenkhoa.Focus();
                return false;
            }
            return true;
        }
        public void showdanhsachkhoa()
        {
            DataTable dt = new DataTable();
            dt = khoa_bll.getAllKhoa();
            gcDanhsachkhoa.DataSource = dt;
        }

        private void fKhoa_Load(object sender, EventArgs e)
        {
            showdanhsachkhoa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!kiemtradauvao())
            {
                return;
            }
            else
            {
                k.MAKHOA = txbMakhoa.Text;
                k.TENKHOA = txbTenkhoa.Text;
                if (khoa_bll.insertKhoa(k))
                {
                    MessageBox.Show("thêm thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdanhsachkhoa();
                }
                else
                {
                    MessageBox.Show("đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

        }
        string ID;
        DataRow dtr;
        private void gvDanhsachkhoa_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dtr = gvDanhsachkhoa.GetFocusedDataRow();
            ID = dtr["id"].ToString();
            txbMakhoa.Text = dtr["Makhoa"].ToString();
            txbTenkhoa.Text = dtr["Tenkhoa"].ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gvDanhsachkhoa.DataRowCount <= 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dtr == null)
                {
                    MessageBox.Show("phải click vào dòng cần sửa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (kiemtradauvao())
                    {
                        k.ID = Convert.ToInt32(ID);
                        k.MAKHOA = txbMakhoa.Text;
                        k.TENKHOA = txbTenkhoa.Text;
                        if (khoa_bll.updateKhoa(k))
                        {
                            MessageBox.Show("Sửa thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showdanhsachkhoa();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra , vui lòng kiểm tra lại ! ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gvDanhsachkhoa.DataRowCount<=0)
            {
                MessageBox.Show("Không có dữ liệu để xóa","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dtr == null)
                {
                    MessageBox.Show("bạn phải chọn vào một trường dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    k.ID = Convert.ToInt32(ID);
                    if (khoa_bll.deleteKhoa(k))
                    {
                        MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showdanhsachkhoa();
                    }
                    else
                    {
                        MessageBox.Show(" Đã có lỗi xảy ra !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
