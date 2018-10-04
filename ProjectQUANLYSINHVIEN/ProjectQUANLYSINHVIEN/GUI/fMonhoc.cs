using ProjectQUANLYSINHVIEN.BLL;
using ProjectQUANLYSINHVIEN.DAL;
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
    public partial class fMonhoc : Form
    {
        monhoc_BLL monhoc_bll = new monhoc_BLL();
        khoa_DAL khoa_dal = new khoa_DAL();
        monhoc monhoc = new monhoc();

        public fMonhoc()
        {
            InitializeComponent();
        }
        public void Laytatcaloaimonhoc()
        {
            DataTable dt = new DataTable();
            dt = monhoc_bll.getAllLoaiMH();
            cbLoaimh.DataSource = dt;
            cbLoaimh.DisplayMember = "Tenloaimh";
            cbLoaimh.ValueMember = "Tenloaimh";
        }
        public void Laytatcakhoa()
        {
            DataTable dt = new DataTable();
            dt = khoa_dal.getAllKhoa();
            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "Tenkhoa";
            cbKhoa.ValueMember = "Makhoa";
        }
        public void Laytatcacacky()
        {
            DataTable dt = new DataTable();
            dt = monhoc_bll.laytatcaKy();
            cbKy.DataSource = dt;
            cbKy.DisplayMember = "Tenky";
            cbKy.ValueMember = "Tenky";
        }
        public void showdanhsachmonhoc()
        {
            DataTable dt = new DataTable();
            dt = monhoc_bll.getAllMonHoc();
            grcMonHoc.DataSource = dt;
        }
        private void fMonhoc_Load(object sender, EventArgs e)
        {
            Laytatcaloaimonhoc();
            showdanhsachmonhoc();
            Laytatcacacky();
        }
        public bool kiemtradauvao()
        {
            if (string.IsNullOrEmpty(txbMaMH.Text))
            {
                MessageBox.Show("Tên môn học không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaMH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txbTenMH.Text))
            {

                MessageBox.Show("Tên môn học không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenMH.Focus();
                return false;
            }
         
            if (string.IsNullOrWhiteSpace(cbLoaimh.Text))
            {
                MessageBox.Show("Loại môn học phải được chọn ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLoaimh.Focus();
                return false;
            }
            return true;
        }

        private void cbLoaimh_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbLoaimh.Text == "Đại cương")
            {

                cbKhoa.DataSource = null;
            }
            else
            {
                Laytatcakhoa();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (kiemtradauvao())
            {
                monhoc.MAMONHOC = txbMaMH.Text;
                monhoc.TENMONHOC = txbTenMH.Text;
                monhoc.KYHOC =Convert.ToInt32( cbKy.SelectedValue.ToString());
                monhoc.LOAIMONHOC = cbLoaimh.SelectedValue.ToString();
                if (cbKhoa.DataSource == null)
                {
                    monhoc.MAKHOA ="";
                }
                else
                { 

                    monhoc.MAKHOA = cbKhoa.SelectedValue.ToString();
                }

                if (monhoc_bll.ThemMonhoc(monhoc))
                {
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdanhsachmonhoc();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        DataRow dtr;
        string ID;
        private void grvMonHoc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dtr = grvMonHoc.GetFocusedDataRow();
            ID = dtr["id"].ToString();
            txbMaMH.Text = dtr["Mamh"].ToString();
            txbTenMH.Text = dtr["Tenmh"].ToString();
            cbKy.Text = dtr["Kyhoc"].ToString();
            cbLoaimh.Text = dtr["Loaimonhoc"].ToString();
            cbKhoa.Text = dtr["Tenkhoa"].ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                monhoc.ID = Convert.ToInt32(ID);
                monhoc.MAMONHOC = txbMaMH.Text;
                monhoc.TENMONHOC = txbTenMH.Text;
                monhoc.KYHOC = Convert.ToInt32(cbKy.SelectedValue.ToString());
                monhoc.LOAIMONHOC = cbLoaimh.SelectedValue.ToString();

                if (cbKhoa.DataSource == null)
                {
                    monhoc.MAKHOA = "";
                }
                else
                {

                    monhoc.MAKHOA = cbKhoa.SelectedValue.ToString();
                }
                if (monhoc_bll.SuaMonhoc(monhoc))
                {
                    MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdanhsachmonhoc();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            monhoc.ID = Convert.ToInt32(ID);
            if (monhoc_bll.XoaMonhoc(monhoc))
            {
                MessageBox.Show("Xóa thành công !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                showdanhsachmonhoc();

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra ! ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }
    }
}
