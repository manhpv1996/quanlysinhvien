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
    public partial class fKetquahoctap : Form
    {
        khoa_BLL khoa_bll = new khoa_BLL();
        ketquahoctap_BLL kqht_bll = new ketquahoctap_BLL();
        khoa k = new khoa();
        ketquahoctap kqht = new ketquahoctap();
        sinhvien sv = new sinhvien();

        public fKetquahoctap()
        {
            InitializeComponent();
        }
        public void laytatcacackhoa()
        {
            DataTable dt = new DataTable();
            dt = khoa_bll.getAllKhoa();
            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "Tenkhoa";
            cbKhoa.ValueMember = "Makhoa";
        }
        public void laytatcaKy()
        {
            DataTable dt = new DataTable();
            dt = kqht_bll.laytatcaKy();
            cbKy.DataSource = dt;
            cbKy.DisplayMember = "Tenky";
            cbKy.ValueMember = "Tenky";
        }
        // lấy tất cả dữ liệu sinh viên sau khi nhập điểm
        public void Laytatcadulieusinhvien()
        {
            DataTable dt = new DataTable();
            dt = kqht_bll.Laydanhsachketquahoctap();
            grcKetquahoctap.DataSource = dt;
        }
        // Lấy tất cả dữ liệu sinh viên trong một khoa 
        //public void Laytatcadulieusinhvientheotungkhoa()
        //{
        //    DataTable dt2 = new DataTable();
        //    k.MAKHOA = cbKhoa.SelectedValue.ToString();
        //    dt2 = kqht_bll.Layketquahoctaptheotungkhoa(k);
        //    grcKetquahoctap.DataSource = dt2;
        //}
        // Lấy tất cả dữ liệu sinh viên của một lớp và theo từng tên sinh viên 
        public void Laytatcadulieusinhvientunglop()
        {
            DataTable dt3 = new DataTable();
            sv.MALOP = cbLop.SelectedValue.ToString();
            sv.MASV = cbSinhvien.SelectedValue.ToString();
            dt3 = kqht_bll.Layketquahoctaptheotunglopvasinhvien(sv);
            grcKetquahoctap.DataSource = dt3;
        }
        private void fKetquahoctap_Load(object sender, EventArgs e)
        {

            laytatcacackhoa();
            laytatcaKy();
            Laytatcadulieusinhvien();

        }
        // Lấy tất cả các lớp show ra combobox khi chọn một khoa bất kỳ

        public void showlop()
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
        // lấy tất cả các môn chung và môn chuyên nghành thuộc khoa đấy khi chọn vào một khoa bất kỳ
        public void showMonhoc()
        {
            string tenkhoa = cbKhoa.SelectedValue.ToString();
            DataTable dt = new DataTable();
            k.MAKHOA = tenkhoa;
            dt = kqht_bll.LayTatCaCacMonHocThuocKhoa(k);
            cbMonhoc.DataSource = dt;
            cbMonhoc.DisplayMember = "Tenmh";
            cbMonhoc.ValueMember = "Mamh";
        }
        private void cbKhoa_SelectedValueChanged_2(object sender, EventArgs e)
        {
            showlop();
            showMonhoc();
        }


        private void cbLop_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dttb = new DataTable();
            string lop = cbLop.SelectedValue.ToString();
            sv.MALOP = lop;
            dttb = kqht_bll.Layketquahoctaptheotunglop(sv);
            grcKetquahoctap.DataSource = dttb;

            if (lop.Equals("System.Data.DataRowView"))
                return;

            dt = kqht_bll.laytatcasinhvien(lop);
            if (dt == null)
            {
                cbSinhvien.DataSource = null;
            }
            else
            {
                cbSinhvien.DataSource = dt;
                cbSinhvien.DisplayMember = "Tensv";
                cbSinhvien.ValueMember = "Masv";
            }
        }

        private void cbKy_SelectedValueChanged(object sender, EventArgs e)
        {
            string tenky = cbKy.SelectedValue.ToString();
            string khoa = cbKhoa.SelectedValue.ToString();

            if (tenky.Equals("System.Data.DataRowView"))
                return;

            DataTable dt = new DataTable();
            dt = kqht_bll.laytatcamonhoc(khoa, Convert.ToInt32(tenky));
            if (dt == null)
            {

                cbMonhoc.DataSource = null;
            }
            cbMonhoc.DataSource = dt;
            cbMonhoc.DisplayMember = "Tenmh";
            cbMonhoc.ValueMember = "Mamh";
        }
        // kiểm tra dữ liệu đầu vào của sinh viên khi nhập điểm
        public bool kiemtradulieudauvao()
        {
            if (string.IsNullOrEmpty(cbSinhvien.Text))
            {
                MessageBox.Show("Tên sinh viên phải được chọn ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSinhvien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbMonhoc.Text))
            {

                MessageBox.Show("Tên môn học phải được chọn ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMonhoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbDiemmonhoc.Text))
            {
                MessageBox.Show("Điểm môn học không được để trống ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDiemmonhoc.Focus();
                return false;
            }
            return true;
        }
        // kiểm tra sự tồn tại của sinh viên và môn học tương thích khi nhập vào
        public bool Kiemtrasutontai()
        {
            DataTable dt = new DataTable();
            dt = kqht_bll.LaytatcadulieusinhvienbangMasvVaMamh(kqht);
            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            return true;

        }
        // kiểm tra sinh viên này đã nhập đầy đủ điểm ở kỳ trước chưa rồi mới cho nhập điểm ở kỳ này

        public bool Kiemtra(string Masv, int ky)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            Masv = cbSinhvien.SelectedValue.ToString();
            ky = int.Parse(cbKy.SelectedValue.ToString()) - 1;
            dt1 = kqht_bll.Laytatcacacmoncuaky(ky);
            dt2 = kqht_bll.Laytatcacacmontrongmotkycuasinhvien(Masv, ky);
            int countdt1 = dt1.Rows.Count;
            int coundt2 = dt2.Rows.Count;
            if (countdt1 == coundt2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string Msv = cbSinhvien.SelectedValue.ToString();
            int Ky = int.Parse(cbKy.SelectedValue.ToString());
            if (Ky >= 1)
            {
                if (!Kiemtra(Msv, Ky))
                {
                    int a = Ky - 1;
                    MessageBox.Show("Dữ liệu kỳ " + a + " của sinh viên: " + cbSinhvien.Text.ToString() + " chưa được nhập đầy đủ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (kiemtradulieudauvao())
                    {
                        kqht.MASINHVIEN = cbSinhvien.SelectedValue.ToString();
                        kqht.MAMONHOC = cbMonhoc.SelectedValue.ToString();
                        kqht.DIEM = float.Parse(txbDiemmonhoc.Text);
                        if (Kiemtrasutontai())
                        {
                            MessageBox.Show("Sinh viên này và môn này đã được nhập , vui lòng kiểm tra lại ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            if (kqht_bll.Themdulieuvaobang(kqht))
                            {
                                MessageBox.Show("Thêm thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Laytatcadulieusinhvientunglop();
                            }
                            else
                            {
                                MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }
        }
        DataRow dtr;
        string ID;
        private void grvKetquahoctap_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dtr = grvKetquahoctap.GetFocusedDataRow();
            ID = dtr["id"].ToString();
            cbKhoa.Text = dtr["Tenkhoa"].ToString();
            cbLop.Text = dtr["Tenlop"].ToString();
            cbSinhvien.Text = dtr["Tensv"].ToString();
            cbKy.Text = dtr["Kyhoc"].ToString();
            cbMonhoc.Text = dtr["Tenmh"].ToString();
            txbDiemmonhoc.Text = dtr["Diem"].ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtr == null)
            {
                MessageBox.Show("Bạn phải chọn vào một trường dữ liệu để xóa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else
            {
                kqht.ID = Convert.ToInt32(ID);
                if (kqht_bll.Xoadulieuketquasinhvien(kqht))
                {
                    MessageBox.Show("Xóa thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Laytatcadulieusinhvien();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtr == null)
            {
                MessageBox.Show("Bạn phải chọn một trường dữ liệu để sửa ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (kiemtradulieudauvao())
                {
                    kqht.MASINHVIEN = cbSinhvien.SelectedValue.ToString();
                    kqht.MAMONHOC = cbMonhoc.SelectedValue.ToString();
                    kqht.DIEM = float.Parse(txbDiemmonhoc.Text);
                    kqht.ID = Convert.ToInt32(ID);
                    if (Kiemtrasutontai())
                    {
                        MessageBox.Show("Sinh viên này và môn này đã được nhập , vui lòng kiểm tra lại ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (kqht_bll.Capnhatdulieubangketquahoctap(kqht))
                        {
                            MessageBox.Show("Sửa thành công  ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Laytatcadulieusinhvien();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }
        public static string Tensinhvien = "";
        public static string Tenlop = "";
        public static string Tenkhoa = "";
        public static DataTable dt, dt1;
        public static double TD;

        private void cbSinhvien_SelectedValueChanged(object sender, EventArgs e)
        {
            Laytatcadulieusinhvientunglop();
        }

        private void cbSinhvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            Laytatcadulieusinhvientunglop();
        }

        private void btnTongket_Click(object sender, EventArgs e)
        {
            string Masv = cbSinhvien.SelectedValue.ToString();
            string Makhoa = cbKhoa.SelectedValue.ToString();
            Tensinhvien = cbSinhvien.Text;
            Tenlop = cbLop.Text;
            Tenkhoa = cbKhoa.Text;
            dt = kqht_bll.Monsinhviencodiem(Masv);
            dt1 = kqht_bll.Monsinhvienchuacodiem(Masv, Makhoa);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không thể tổng kết vì sinh viên này chưa có điểm thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                TD = kqht_bll.TongDiemDathi(Masv);
                fBaocao fbaocao = new fBaocao();
                fbaocao.ShowDialog();
            }

        }
    }
}
