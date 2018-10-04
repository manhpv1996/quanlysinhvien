using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProjectQUANLYSINHVIEN.DTO;

namespace ProjectQUANLYSINHVIEN.DAL
{
    class monhoc_DAL
    {
        Dataconnection dc;
        SqlCommand cm;
        SqlDataAdapter adt;
        public monhoc_DAL()
        {
            dc = new Dataconnection();
        }
        public DataTable getAllLoaiMH()
        {
            string sqlselect = "SELECT Tenloaimh FROM Loaimonhoc";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlselect, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable getAllMonHoc()
        {
            string sqlselectAllMH = "SELECT mh.id,mh.Kyhoc,mh.Mamh,mh.Tenmh,mh.Loaimonhoc,k.Tenkhoa FROM dbo.Monhoc mh LEFT JOIN dbo.Khoa k ON k.Makhoa = mh.Makhoa ";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlselectAllMH, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public bool ThemMonhoc(monhoc monhoc)
        {
            string sqlInsertMH = "INSERT INTO Monhoc (Mamh,Tenmh,Kyhoc,Loaimonhoc,Makhoa)VALUES(@MAMONHOC,@TENMONHOC,@KYHOC,@LOAIMONHOC,@MAKHOA)";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlInsertMH, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@MAMONHOC", SqlDbType.NVarChar).Value = monhoc.MAMONHOC;
                cm.Parameters.Add("@TENMONHOC", SqlDbType.NVarChar).Value = monhoc.TENMONHOC;
                cm.Parameters.Add("@KYHOC", SqlDbType.Int).Value = monhoc.KYHOC;
                cm.Parameters.Add("@LOAIMONHOC", SqlDbType.NVarChar).Value = monhoc.LOAIMONHOC;
                cm.Parameters.Add("@MAKHOA", SqlDbType.NVarChar).Value = monhoc.MAKHOA;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool SuaMonhoc(monhoc monhoc)
        {
            string sqlUpdateMH = "UPDATE Monhoc SET Mamh =@MAMONHOC,Tenmh=@TENMONHOC,Kyhoc=@KYHOC,Loaimonhoc=@LOAIMONHOC,Makhoa=@MAKHOA WHERE id=@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlUpdateMH, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = monhoc.ID;
                cm.Parameters.Add("@MAMONHOC", SqlDbType.NVarChar).Value = monhoc.MAMONHOC;
                cm.Parameters.Add("@TENMONHOC", SqlDbType.NVarChar).Value = monhoc.TENMONHOC;
                cm.Parameters.Add("@KYHOC", SqlDbType.Int).Value = monhoc.KYHOC;
                cm.Parameters.Add("@LOAIMONHOC", SqlDbType.NVarChar).Value = monhoc.LOAIMONHOC;
                cm.Parameters.Add("@MAKHOA", SqlDbType.NVarChar).Value = monhoc.MAKHOA;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool XoaMonhoc(monhoc monhoc)
        {
            string sqlUpdateMH = "DELETE FROM Monhoc WHERE id=@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlUpdateMH, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = monhoc.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
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
    }
}
