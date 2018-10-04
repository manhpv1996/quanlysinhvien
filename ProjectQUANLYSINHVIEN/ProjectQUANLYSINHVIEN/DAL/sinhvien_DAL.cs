using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProjectQUANLYSINHVIEN.DTO;
using System.Windows.Forms;
using System.IO;

namespace ProjectQUANLYSINHVIEN.DAL
{
    class sinhvien_DAL
    {
        Dataconnection dc;
        SqlDataAdapter adt;
        SqlCommand cm;
        public sinhvien_DAL()
        {
            dc = new Dataconnection();
        }
        public DataTable GetAllsinhvien(khoa khoa)
        {
            string sqlSelectSinhVien = @"SELECT  sv.id ,
                                                Masv ,
                                                sv.Tensv ,
                                                k.Tenkhoa ,
                                                lp.Tenlop ,
                                                ( CASE sv.Gioitinh
                                                    WHEN 1 THEN N'Nam'
                                                    ELSE N'Nữ'
                                                    END ) AS Gioitinh ,
                                                sv.Diachi,sv.Image
                                        FROM    dbo.SinhVien sv ,
                                                dbo.Lop lp ,
                                                dbo.Khoa k
                                        WHERE   sv.Malop = lp.Malop
                                                AND lp.Makhoa = k.Makhoa AND k.Makhoa='" + khoa.MAKHOA + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlSelectSinhVien, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }

        public bool insertSinhVien(sinhvien sv,string filePath, string folderpath)
        {
            SqlConnection con = dc.getConnection();
            string sqlInsert = "INSERT INTO SinhVien(Masv,Tensv,Gioitinh,Malop,Diachi,Image) VALUES(@MASV,@TENSV,@GIOITINH,@MALOP,@DIACHI,@IMAGE)";
            cm = new SqlCommand(sqlInsert, con);
            if (filePath == "")
            {
                cm.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = sv.MASV;
                cm.Parameters.Add("@TENSV", SqlDbType.NVarChar).Value = sv.TENSV;
                cm.Parameters.Add("@GIOITINH", SqlDbType.Int).Value = sv.GIOITINH;
                cm.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = sv.MALOP;
                cm.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = sv.DIACHI;
                cm.Parameters.AddWithValue("@IMAGE", "");
            }
            else
            {
                cm.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = sv.MASV;
                cm.Parameters.Add("@TENSV", SqlDbType.NVarChar).Value = sv.TENSV;
                cm.Parameters.Add("@GIOITINH", SqlDbType.Int).Value = sv.GIOITINH;
                cm.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = sv.MALOP;
                cm.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = sv.DIACHI;
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@IMAGE", folderpath + Path.GetFileName(filePath));
                File.Copy(filePath, Path.Combine(folderpath, Path.GetFileName(filePath)), true);
            }
            try
            {
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(sinhvien sv,string filePath,string folderpath)
        {
            string sqlUpdate = "UPDATE SinhVien SET Masv=@MASV,Tensv=@TENSV,Gioitinh=@GIOITINH,Malop=@MALOP,Diachi=@DIACHI,Image=@IMAGE WHERE id =@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlUpdate, con);
            if (filePath == "")
            {
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = sv.ID;
                cm.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = sv.MASV;
                cm.Parameters.Add("@TENSV", SqlDbType.NVarChar).Value = sv.TENSV;
                cm.Parameters.Add("@GIOITINH", SqlDbType.Int).Value = sv.GIOITINH;
                cm.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = sv.MALOP;
                cm.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = sv.DIACHI;
                cm.Parameters.AddWithValue("@IMAGE", "");
            }
            else
            {
                cm.Parameters.Add("@ID",SqlDbType.Int).Value=sv.ID;
                cm.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = sv.MASV;
                cm.Parameters.Add("@TENSV", SqlDbType.NVarChar).Value = sv.TENSV;
                cm.Parameters.Add("@GIOITINH", SqlDbType.Int).Value = sv.GIOITINH;
                cm.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = sv.MALOP;
                cm.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = sv.DIACHI;
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@IMAGE", folderpath + Path.GetFileName(filePath));
                File.Copy(filePath, Path.Combine(folderpath, Path.GetFileName(filePath)), true);
            }
            try
            {
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
        public bool deleteSinhVien(sinhvien sv)
        {
            string sqlDeleteSinhVien = "DELETE SinhVien  WHERE id =@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlDeleteSinhVien, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = sv.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable Laytatcasinhvientheotungkhoa(khoa kh)
        {
            string Laytatcasinhvientheotungkhoa = @"SELECT  sv.id , sv.Masv ,sv.Tensv,kh.Tenkhoa,lp.Tenlop,( CASE sv.Gioitinh
                                                    WHEN 1 THEN N'Nam'
                                                    ELSE N'Nữ'
                                                    END ) AS Gioitinh,sv.Diachi,sv.Image
                                                    FROM    dbo.SinhVien sv
                                                            INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
                                                            INNER JOIN dbo.Khoa kh ON kh.Makhoa = lp.Makhoa
                                                    WHERE   kh.Makhoa = '" + kh.MAKHOA + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(Laytatcasinhvientheotungkhoa, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public int Laytongsosinhvientrongmotkhoa(khoa kh)
        {
            string sqlLaytongsosinhvientrongmotkhoa = @"SELECT  COUNT(sv.id) AS tongsv
                                                        FROM    dbo.SinhVien sv
                                                                INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
                                                                INNER JOIN dbo.Khoa kh ON kh.Makhoa = lp.Makhoa
                                                        WHERE   kh.Makhoa = '" + kh.MAKHOA + "'";
            SqlConnection con = dc.getConnection();
            con.Open();
            cm = new SqlCommand(sqlLaytongsosinhvientrongmotkhoa, con);
            SqlDataReader reader = cm.ExecuteReader();
            int Tongsinhvien = 0;
            while (reader.Read())
            {
                Tongsinhvien = Convert.ToInt32(reader["tongsv"].ToString());
            }
            return Tongsinhvien;
        }
        public DataTable Laytatcasinhvientheotunglop(lop lp)
        {
            string Laytatcasinhvientheotunglop = @"SELECT  sv.id ,
                                                            sv.Masv ,
                                                            sv.Tensv ,
                                                            kh.Tenkhoa ,
                                                            lp.Tenlop ,
                                                            ( CASE sv.Gioitinh
                                                                WHEN 1 THEN N'Nam'
                                                                ELSE N'Nữ'
                                                              END ) AS Gioitinh ,
                                                            sv.Diachi,sv.Image
                                                    FROM    dbo.SinhVien sv
                                                            INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
                                                            INNER JOIN dbo.Khoa kh ON kh.Makhoa = lp.Makhoa
                                                    WHERE   lp.Malop = '" + lp.MALOP + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(Laytatcasinhvientheotunglop, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public int Laytongsosinhvientrongmotlop(lop lp)
        {
            string sqlLaytongsosinhvientrongmotlop = @"SELECT  COUNT(sv.id) AS tongsv
                                                        FROM    dbo.SinhVien sv
                                                                INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
                                                        WHERE   lp.Malop =  '" + lp.MALOP + "'";
            SqlConnection con = dc.getConnection();
            con.Open();
            cm = new SqlCommand(sqlLaytongsosinhvientrongmotlop, con);
            SqlDataReader reader = cm.ExecuteReader();
            int Tongsinhvien = 0;
            while (reader.Read())
            {
                Tongsinhvien = Convert.ToInt32(reader["tongsv"].ToString());
            }
            return Tongsinhvien;
        }
        public DataTable Timkiemsinhvientheoten(string makhoa, string malop, string masinhvien)
        {
            string sqlTimkiemsinhvientheoten = @"SELECT  sv.id ,
                                                        Masv ,
                                                        sv.Tensv ,
                                                        k.Tenkhoa ,
                                                        lp.Tenlop ,
                                                        ( CASE sv.Gioitinh
                                                            WHEN 1 THEN N'Nam'
                                                            ELSE N'Nữ'
                                                            END ) AS Gioitinh ,
                                                        sv.Diachi,sv.Image
                                                FROM    dbo.SinhVien sv
                                                        INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
                                                        INNER JOIN dbo.Khoa k ON k.Makhoa = lp.Makhoa
                                                WHERE   k.Makhoa = '" + makhoa + "' AND lp.Malop='" + malop + "' AND sv.Tensv LIKE N'%" + masinhvien + "%'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlTimkiemsinhvientheoten, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable Laytatcasinhviencuatatcacackhoa()
        {
            string sqlLaytatcasinhviencuatatcacackhoa = @"SELECT sv.id ,
                                                                sv.Masv ,
                                                                sv.Tensv ,
                                                                khoa.Tenkhoa ,
                                                                lp.Tenlop ,
                                                                ( CASE sv.Gioitinh
                                                                    WHEN 1 THEN N'Nam'
                                                                    ELSE N'Nữ'
                                                                    END ) AS Gioitinh ,
                                                                sv.Diachi,sv.Image
                                                        FROM    dbo.SinhVien sv
                                                                INNER JOIN dbo.Lop lp ON lp.Malop = sv.Malop
                                                                INNER JOIN dbo.Khoa khoa ON khoa.Makhoa = lp.Makhoa";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaytatcasinhviencuatatcacackhoa, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }

    }
}
