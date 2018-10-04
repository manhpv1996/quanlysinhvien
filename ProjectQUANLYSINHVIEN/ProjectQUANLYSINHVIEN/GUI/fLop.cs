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
    public partial class fLop : Form
    {
        khoa_BLL khoa_bll = new khoa_BLL();
        lop lp = new lop();
        lop_BLL lop_bll = new lop_BLL();
        public fLop()
        {
            InitializeComponent();
        }
        public void showTenkhoa()
        {
            DataTable dt = new DataTable();
            dt = khoa_bll.getAllKhoa();
            cbMakhoa.DataSource = dt;
            cbMakhoa.DisplayMember = "Tenkhoa";
            cbMakhoa.ValueMember = "Makhoa";
        }
        public void showdanhsachlop()
        {
            DataTable dt = new DataTable();
            dt = lop_bll.getAllLop();
            gcDanhsachlop.DataSource = dt;
        }
        public bool kiemtrasutontaicualop(string Tenlop)
        {
            lp.TENLOP = Tenlop;
            DataTable dt = new DataTable();
            dt = lop_bll.laydanhsachtentatcalop(lp);
            if (dt.Rows.Count >=1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool kiemtradauvao()
        {
            if (string.IsNullOrEmpty(cbMakhoa.Text))
            {
                MessageBox.Show("Bạn phải chọn 1 khoa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrWhiteSpace(txbMalop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMalop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbTenlop.Text))
            {
                MessageBox.Show("Tên lớp không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenlop.Focus();
                return false;
            }
            else
            {
                if (kiemtrasutontaicualop(txbTenlop.Text))
                {
                    MessageBox.Show("Tên lớp này đã tồn tại ở hệ thống xin vui lòng nhập tên lớp khác  ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbTenlop.Focus();
                    return false;
                }
            }
            return true;
        }
        private void fLop_Load(object sender, EventArgs e)
        {
            showTenkhoa();
            showdanhsachlop();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                lp.MALOP = txbMalop.Text;
                lp.TENLOP = txbTenlop.Text;
                lp.MAKHOA = cbMakhoa.SelectedValue.ToString();
                if (lop_bll.insertLop(lp))
                {
                    MessageBox.Show("Thêm thành công ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdanhsachlop();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        DataRow dtr;
        string ID;
        private void gvDanhsachlop_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dtr = gvDanhsachlop.GetFocusedDataRow();
            ID = dtr["id"].ToString();
            cbMakhoa.Text = dtr["Tenkhoa"].ToString();
            txbMalop.Text = dtr["Malop"].ToString();
            txbTenlop.Text = dtr["Tenlop"].ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gvDanhsachlop.DataRowCount <= 0)
            {
                MessageBox.Show("không có dữ liệu để sửa ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dtr == null)
                {
                    MessageBox.Show("Bạn phải chọn một trường dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (kiemtradauvao())
                    {
                        lp.ID = Convert.ToInt32(ID);
                        lp.MALOP = txbMalop.Text;
                        lp.TENLOP = txbTenlop.Text;
                        lp.MAKHOA = cbMakhoa.SelectedValue.ToString();
                        if (lop_bll.updateLop(lp))
                        {
                            MessageBox.Show("Sửa thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showdanhsachlop();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gvDanhsachlop.DataRowCount <= 0)
            {
                MessageBox.Show("không có dữ liệu để xóa ! ", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dtr == null)
                {
                    MessageBox.Show("Bạn phải chọn một trường dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    lp.ID = Convert.ToInt32(ID);
                    if (lop_bll.deleteLop(lp))
                    {
                        MessageBox.Show("Xóa thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showdanhsachlop();

                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }
    }
}
