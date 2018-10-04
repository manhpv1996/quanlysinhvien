using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjectQUANLYSINHVIEN.DTO;
using System.Data;

namespace ProjectQUANLYSINHVIEN.DAL
{
    class lop_DAL
    {
        Dataconnection dc;
        SqlDataAdapter adt;
        SqlCommand cm;
        public lop_DAL()
        {
            dc = new Dataconnection();
        }
        public DataTable getAllLop()
        {
            string sqlGetAllLop = "SELECT lp.id,lp.Malop,lp.Tenlop ,k.Tenkhoa FROM dbo.Lop lp,dbo.Khoa k WHERE lp.Makhoa=k.Makhoa";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlGetAllLop, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;

        }
        public bool insertLop(lop lp)
        {
            string sqlInsertLop = "INSERT INTO Lop(Malop,Tenlop,Makhoa) VALUES(@MALOP,@TENLOP,@MAKHOA)";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlInsertLop, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = lp.MALOP;
                cm.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = lp.TENLOP;
                cm.Parameters.Add("@MAKHOA", SqlDbType.NVarChar).Value = lp.MAKHOA;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool updateLop(lop lp)
        {
            string sqlupdateLop = "UPDATE Lop SET Malop=@MALOP ,Tenlop=@TENLOP ,Makhoa=@MAKHOA WHERE id =@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlupdateLop, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = lp.MALOP;
                cm.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = lp.TENLOP ;
                cm.Parameters.Add("@MAKHOA", SqlDbType.NVarChar).Value = lp.MAKHOA;
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = lp.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool deleteLop(lop lp)
        {
            string sqlDeleteLop = "DELETE FROM Lop WHERE id =@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlDeleteLop, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = lp.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable getTenloptheotenKhoa(lop lp)
        {
            string sqlGettenlop = "SELECT Malop,Tenlop  FROM Lop WHERE Makhoa ='" + lp.MAKHOA + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlGettenlop, con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
        public DataTable laydanhsachtentatcalop(lop lp)
        {
            string sqlLaydanhsachtenlop = "SELECT Tenlop FROM Lop WHERE Tenlop='"+lp.TENLOP+"'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlLaydanhsachtenlop,con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            return dt;
        }
    }
}
