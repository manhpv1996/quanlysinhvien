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
    public partial class fSinhvien : Form
    {
        khoa_BLL khoa_bll = new khoa_BLL();
        lop lp = new lop();
        lop_BLL lop_bll = new lop_BLL();
        sinhvien sv = new sinhvien();
        khoa khoa = new khoa();
        sinhvien_BLL sv_bll = new sinhvien_BLL();
        ketquahoctap_BLL kqht_bll = new ketquahoctap_BLL();
        public fSinhvien()
        {
            InitializeComponent();
        }
        public void getTenkhoa()
        {
            DataTable dt = new DataTable();
            dt = khoa_bll.getAllKhoa();
            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "Tenkhoa";
            cbKhoa.ValueMember = "Makhoa";
        }
        public void getTenlop()
        {
            string tenkhoa = cbKhoa.SelectedValue.ToString();
            if (tenkhoa.Equals("System.Data.DataRowView"))
                return;
            DataTable dt = new DataTable();


            dt = kqht_bll.laytatcalop(tenkhoa);
            if (dt == null)
            {
                cbLop.DataSource = null;
            }
            else
            {
                cbLop.DataSource = dt;
                cbLop.DisplayMember = "Tenlop";
                cbLop.ValueMember = "Malop";
            }
        }

        private void fSinhvien_Load(object sender, EventArgs e)
        {
            getTenkhoa();
            getTenlop();
            showdanhsachsinhvien();
        }

        // Hàm tính tổng số sinh viên trong một khoa
        public void Inratongsosinhvientrongkhoa()
        {
            khoa.MAKHOA = cbKhoa.SelectedValue.ToString();
            int tongsosinhvien = sv_bll.Laytongsosinhvientrongmotkhoa(khoa);
            if (tongsosinhvien == 0)
            {
                lbTongsinhvienkhoa.Text = "Khoa: " + cbKhoa.Text + " không có sinh viên nào cả ! ";
            }
            else
            {
                lbTongsinhvienkhoa.Text = "Khoa: " + cbKhoa.Text + " có " + tongsosinhvien + " sinh viên";
            }
        }
        // Hàm tính tổng số sinh viên trong một lớp
        public void Inratongsosinhvientrongmotlop()
        {
            lp.MALOP = cbLop.SelectedValue.ToString();
            int tongsosinhvien = sv_bll.Laytongsosinhvientrongmotlop(lp);
            if (tongsosinhvien == 0)
            {
                lbTongsinhvienlop.Text = "Lớp : " + cbLop.Text + " không có sinh viên nào cả ! ";
            }
            else
            {
                lbTongsinhvienlop.Text = "Lớp : " + cbLop.Text + " có " + tongsosinhvien + " sinh viên ";
            }
        }
        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void showdanhsachsinhvien()
        {
            khoa.MAKHOA = cbKhoa.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sv_bll.GetAllsinhvien(khoa);
            grcDanhsachsinhvien.DataSource = dt;
        }
        public bool kiemtradauvao()
        {
            if (string.IsNullOrEmpty(cbKhoa.Text))
            {
                MessageBox.Show("Bạn phải chọn 1 khoa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(cbLop.Text))
            {
                MessageBox.Show("Bạn phải chọn 1 lớp ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbMasv.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMasv.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbTensv.Text))
            {
                MessageBox.Show("Tên sinh viên không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTensv.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbDiachi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDiachi.Focus();
                return false;
            }
            return true;
        }
        string filePath = "";
        string folderpath = @"E:\";

        private void btnImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp|all files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                // image file path
                txtFilePath.Text = open.FileName;
                filePath = open.FileName;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtradauvao())
            {
                sv.MASV = txbMasv.Text;
                sv.TENSV = txbTensv.Text;
                sv.MALOP = cbLop.SelectedValue.ToString();
                if (rbtnNam.Checked)
                {
                    sv.GIOITINH = 1;
                }
                if (rbtnNu.Checked)
                {
                    sv.GIOITINH = 0;
                }
                sv.DIACHI = txbDiachi.Text;
                if (sv_bll.insertSinhVien(sv, filePath, folderpath))
                {
                    MessageBox.Show("Thêm sinh viên thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showdanhsachsinhvien();
                    Inratongsosinhvientrongkhoa();
                    Inratongsosinhvientrongmotlop();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        string ID;
        DataRow dtr;
        private void grvDanhsachsinhvien_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dtr = grvDanhsachsinhvien.GetFocusedDataRow();
            ID = dtr["id"].ToString();
            cbKhoa.Text = dtr["Tenkhoa"].ToString();
            Chitietsinhvien.KHOA = dtr["Tenkhoa"].ToString();
            cbLop.Text = dtr["Tenlop"].ToString();
            Chitietsinhvien.LOP = dtr["Tenlop"].ToString();
            txbMasv.Text = dtr["Masv"].ToString();
            Chitietsinhvien.MASINHVIEN = dtr["Masv"].ToString();
            txbTensv.Text = dtr["Tensv"].ToString();
            Chitietsinhvien.TENSINHVIEN = dtr["Tensv"].ToString();
            txbDiachi.Text = dtr["Diachi"].ToString();
            Chitietsinhvien.DIACHI = dtr["Diachi"].ToString();
            if (dtr["Gioitinh"].ToString() == "Nam")
            {
                rbtnNam.Checked = true;
            }
            else
            {
                rbtnNu.Checked = true;
            }
            Chitietsinhvien.GIOITINH = dtr["Gioitinh"].ToString();
            txtFilePath.Text = dtr["Image"].ToString();
            if (dtr["Image"].ToString() == "" || dtr["Image"].ToString() == @"E:\")
            {
                pictureBox1.Image = Image.FromFile(@"E:\avatarrong.jpg");
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(dtr["Image"].ToString());
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Chitietsinhvien.ANH = dtr["Image"].ToString();


        }



        private void btnSua_Click(object sender, EventArgs e)
        {

            if (grvDanhsachsinhvien.RowCount <= 0)
            {
                MessageBox.Show("Không có dữ liệu nào để sửa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dtr == null)
                {
                    MessageBox.Show("Bạn phải chọn một trường dữ liệu để sửa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (kiemtradauvao())
                    {
                        sv.ID = Convert.ToInt32(ID);
                        sv.MASV = txbMasv.Text;
                        sv.TENSV = txbTensv.Text;
                        sv.DIACHI = txbDiachi.Text;
                        sv.MALOP = cbLop.SelectedValue.ToString();
                        if (rbtnNam.Checked)
                        {
                            sv.GIOITINH = 1;
                        }
                        if (rbtnNu.Checked)
                        {
                            sv.GIOITINH = 0;
                        }
                        if (sv_bll.UpdateSinhVien(sv, filePath, folderpath))
                        {
                            MessageBox.Show("Chỉnh sửa thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showdanhsachsinhvien();
                            Inratongsosinhvientrongkhoa();
                            Inratongsosinhvientrongmotlop();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDanhsachsinhvien.RowCount <= 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (dtr == null)
                {
                    MessageBox.Show("bạn phải chọn vào 1 trường dữ liệu để xóa! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    sv.ID = Convert.ToInt32(ID);
                    if (sv_bll.deleteSinhVien(sv))
                    {
                        MessageBox.Show("Xóa thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showdanhsachsinhvien();
                        Inratongsosinhvientrongkhoa();
                        Inratongsosinhvientrongmotlop();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void cbKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            getTenlop();
            khoa.MAKHOA = cbKhoa.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sv_bll.Laytatcasinhvientheotungkhoa(khoa);
            grcDanhsachsinhvien.DataSource = dt;
            Inratongsosinhvientrongkhoa();
        }

        private void cbLop_SelectedValueChanged(object sender, EventArgs e)
        {
            lp.MALOP = cbLop.SelectedValue.ToString();
            if (lp.MALOP.Equals("System.Data.DataRowView"))
                return;

            DataTable dt = new DataTable();
            dt = sv_bll.Laytatcasinhvientheotunglop(lp);
            grcDanhsachsinhvien.DataSource = dt;
            Inratongsosinhvientrongmotlop();
        }

        private void txbTimkiem_TextChanged(object sender, EventArgs e)
        {
            string makhoa = cbKhoa.SelectedValue.ToString();
            string malop = cbLop.SelectedValue.ToString();
            string masinhvien = txbTimkiem.Text;
            DataTable dt = new DataTable();
            dt = sv_bll.Timkiemsinhvientheoten(makhoa, malop, masinhvien);
            grcDanhsachsinhvien.DataSource = dt;
        }

        private void btnXemtatca_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sv_bll.Laytatcasinhviencuatatcacackhoa();
            grcDanhsachsinhvien.DataSource = dt;
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            if (dtr == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng sinh viên để xem ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                fChitietsinhvien fchitietsinhvien = new fChitietsinhvien();
                fchitietsinhvien.ShowDialog();
            }

        }
    }
}
