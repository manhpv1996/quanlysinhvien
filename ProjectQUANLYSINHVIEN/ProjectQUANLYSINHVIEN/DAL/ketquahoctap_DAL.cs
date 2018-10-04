using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProjectQUANLYSINHVIEN.DTO;
using System.Windows.Forms;

namespace ProjectQUANLYSINHVIEN.DAL
{
    class ketquahoctap_DAL
    {
        Dataconnection dc;
        SqlCommand cm;
        SqlDataAdapter adt;
        public ketquahoctap_DAL()
        {
            dc = new Dataconnection();
        }
        public DataTable laytatcalop(string khoa)
        {
            string sqlLaytatcalop = "SELECT Malop ,Tenlop FROM Lop WHERE Makhoa ='" + khoa + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcalop, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable laytatcasinhvien(string lop)
        {
            string sqlLaytatcasinhvien = "SELECT Masv ,Tensv FROM SinhVien WHERE Malop ='" + lop + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcasinhvien, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable laytatcaKy()
        {
            string sqlLaytatcaKy = "SELECT Tenky FROM Ky ";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcaKy, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable laytatcamonhoc(string khoa, int ky)
        {
            string sqlLaytatcamonhoc = "SELECT  mh.Mamh ,mh.Tenmh ,mh.Loaimonhoc ,k.Makhoa,mh.Kyhoc FROM dbo.Monhoc mh LEFT JOIN dbo.Khoa k ON k.Makhoa = mh.Makhoa WHERE   mh.Loaimonhoc IN ( N'Đại cương', N'Chuyên nghành' )AND ( k.Makhoa IS NULL OR k.Makhoa = '" + khoa + "' ) AND mh.Kyhoc=" + ky;
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcamonhoc, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LayTatCaCacMonHocThuocKhoa(khoa k)
        {
            string sqlLayTatCaCacMonHocThuocKhoa = "SELECT  mh.Mamh ,mh.Tenmh,mh.Loaimonhoc,k.Makhoa FROM    dbo.Monhoc mh LEFT JOIN dbo.Khoa k ON k.Makhoa = mh.Makhoa WHERE   mh.Loaimonhoc IN( N'Đại cương', N'Chuyên nghành') AND (k.Makhoa IS NULL OR k.Makhoa='" + k.MAKHOA + "')";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLayTatCaCacMonHocThuocKhoa, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public bool Themdulieuvaobang(ketquahoctap kqht)
        {
            string sqlThemdulieuvaobang = "INSERT INTO Ketquahoctap (Masv,Mamh,Diem) VALUES (@MASINHVIEN,@MAMONHOC,@DIEM)";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlThemdulieuvaobang, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@MASINHVIEN", SqlDbType.NVarChar).Value = kqht.MASINHVIEN;
                cm.Parameters.Add("@MAMONHOC", SqlDbType.NVarChar).Value = kqht.MAMONHOC;
                cm.Parameters.Add("@DIEM", SqlDbType.Float).Value = kqht.DIEM;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable Laydanhsachketquahoctap()
        {
            string sqlLaydanhsachketquahoctap = "SELECT  kqht.id ,kqht.Masv , sv.Tensv ,lp.Tenlop ,k.Tenkhoa , mh.Tenmh  ,mh.Kyhoc ,kqht.Diem FROM dbo.Ketquahoctap kqht INNER JOIN dbo.SinhVien sv ON sv.Masv = kqht.Masv  INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop INNER JOIN dbo.Khoa k ON k.Makhoa = lp.Makhoa INNER JOIN dbo.Monhoc mh ON mh.Mamh = kqht.Mamh";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaydanhsachketquahoctap, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public bool Xoadulieuketquasinhvien(ketquahoctap kqht)
        {
            string sqlXoadulieuketquasinhvien = "DELETE FROM Ketquahoctap WHERE id=@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlXoadulieuketquasinhvien, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = kqht.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable LaytatcadulieusinhvienbangMasvVaMamh(ketquahoctap kqht)
        {
            string sqlLaytatcadulieusinhvienbangMasvVaMamh = "SELECT * FROM Ketquahoctap WHERE Masv='" + kqht.MASINHVIEN + "'AND Mamh='" + kqht.MAMONHOC + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcadulieusinhvienbangMasvVaMamh, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public bool Capnhatdulieubangketquahoctap(ketquahoctap kqht)
        {
            string sqlCapnhatdulieubangketquahoctap = "UPDATE Ketquahoctap SET Masv=@MASINHVIEN , Mamh=@MAMONHOC ,Diem =@DIEM WHERE @ID=id";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlCapnhatdulieubangketquahoctap, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = kqht.ID;
                cm.Parameters.Add("@MASINHVIEN", SqlDbType.NVarChar).Value = kqht.MASINHVIEN;
                cm.Parameters.Add("@MAMONHOC", SqlDbType.NVarChar).Value = kqht.MAMONHOC;
                cm.Parameters.Add("@DIEM", SqlDbType.Float).Value = kqht.DIEM;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable Laytatcacacmoncuaky(int ky)
        {
            string sqlLaytatcacacmoncuaky = "SELECT Mamh,Tenmh FROM dbo.Monhoc WHERE Kyhoc =" + ky;
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcacacmoncuaky, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable Laytatcacacmontrongmotkycuasinhvien(string Msv, int Ky)
        {
            string sqlLaytatcacacmontrongmotkycuasinhvien = "SELECT kq.Mamh,mh.Tenmh FROM dbo.Ketquahoctap kq INNER JOIN dbo.Monhoc mh ON mh.Mamh = kq.Mamh WHERE kq.Masv='" + Msv + "'AND mh.Kyhoc=" + Ky;
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcacacmontrongmotkycuasinhvien, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable Monsinhviencodiem(string Masinhvien)
        {
            string sqlMonsinhviencodiem = "SELECT  kq.Masv,sv.Tensv,kq.Mamh,mh.Tenmh,mh.Kyhoc,mh.Makhoa ,mh.Loaimonhoc,kq.Diem FROM dbo.SinhVien sv INNER JOIN dbo.Ketquahoctap kq ON kq.Masv = sv.Masv INNER JOIN dbo.Monhoc mh ON mh.Mamh = kq.Mamh WHERE kq.Masv='" + Masinhvien + "'";
            SqlConnection con = dc.getConnection();

            adt = new SqlDataAdapter(sqlMonsinhviencodiem, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;

        }
        public DataTable Monsinhvienchuacodiem(string Masinhvien, string Makhoa)
        {

            string sqlMonsinhvienchuacodiem = "SELECT  * FROM dbo.Monhoc mh WHERE   mh.Mamh NOT IN (SELECT kq.Mamh FROM dbo.SinhVien sv INNER JOIN dbo.Ketquahoctap kq ON kq.Masv = sv.Masv WHERE kq.Masv ='" + Masinhvien + "') AND (mh.Loaimonhoc = N'Đại cương' OR mh.Loaimonhoc=N'Chuyên nghành' AND mh.Makhoa='" + Makhoa + "')";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlMonsinhvienchuacodiem, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;

        }
        public double TongDiemDathi(string masinhvien)
        {
            string sqlTongDiem = "SELECT SUM(kq.Diem) AS Tk FROM dbo.SinhVien sv INNER JOIN dbo.Ketquahoctap kq ON kq.Masv = sv.Masv INNER JOIN dbo.Monhoc mh ON mh.Mamh = kq.Mamh WHERE kq.Masv = '" + masinhvien + "'";
            SqlConnection con = dc.getConnection();
            con.Open();
            cm = new SqlCommand(sqlTongDiem, con);
            SqlDataReader rdr = cm.ExecuteReader();
            double columnValue = 0;

            while (rdr.Read())
            {
                columnValue = Convert.ToDouble(rdr["Tk"]);
            }

            return columnValue;
        }
        public DataTable Layketquahoctaptheotunglop(sinhvien sv)
        {
            string sqlLayketquahoctaptheotunglop = @"SELECT kq.id, kq.Masv ,
                                                            sv.Tensv ,
                                                            lp.Tenlop,
		                                                    kh.Tenkhoa,
		                                                    mh.Tenmh,
		                                                    mh.Kyhoc,
		                                                    kq.Diem
                                                    FROM    dbo.Ketquahoctap kq
                                                            INNER JOIN dbo.SinhVien sv ON sv.Masv = kq.Masv
                                                            INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
		                                                    INNER JOIN dbo.Khoa kh ON kh.Makhoa = lp.Makhoa
		                                                    INNER JOIN dbo.Monhoc mh ON mh.Mamh = kq.Mamh
                                                    WHERE   sv.Malop ='" + sv.MALOP + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLayketquahoctaptheotunglop, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable Layketquahoctaptheotunglopvasinhvien(sinhvien sv)
        {
            string Layketquahoctaptheotunglopvasinhvien = @"SELECT kq.id, kq.Masv ,
                                                                    sv.Tensv ,
                                                                    lp.Tenlop,
		                                                            kh.Tenkhoa,
		                                                            mh.Tenmh,
		                                                            mh.Kyhoc,
		                                                            kq.Diem
                                                            FROM    dbo.Ketquahoctap kq
                                                                    INNER JOIN dbo.SinhVien sv ON sv.Masv = kq.Masv
                                                                    INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
		                                                            INNER JOIN dbo.Khoa kh ON kh.Makhoa = lp.Makhoa
		                                                            INNER JOIN dbo.Monhoc mh ON mh.Mamh = kq.Mamh
                                                            WHERE   sv.Malop ='" + sv.MALOP + "' AND sv.Masv='" + sv.MASV + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(Layketquahoctaptheotunglopvasinhvien, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable Layketquahoctaptheotungkhoa(khoa kh)
        {
            string Layketquahoctaptheotungkhoa = @"SELECT kq.id, kq.Masv ,
                                                            sv.Tensv ,
                                                            lp.Tenlop,
		                                                    kh.Tenkhoa,
		                                                    mh.Tenmh,
		                                                    mh.Kyhoc,
		                                                    kq.Diem
                                                    FROM    dbo.Ketquahoctap kq
                                                            INNER JOIN dbo.SinhVien sv ON sv.Masv = kq.Masv
                                                            INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
		                                                    INNER JOIN dbo.Khoa kh ON kh.Makhoa = lp.Makhoa
		                                                    INNER JOIN dbo.Monhoc mh ON mh.Mamh = kq.Mamh
                                                    WHERE   kh.Makhoa ='" + kh.MAKHOA + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(Layketquahoctaptheotungkhoa, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
    }
}
