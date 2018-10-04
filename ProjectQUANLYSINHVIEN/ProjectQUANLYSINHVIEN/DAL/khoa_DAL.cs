using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjectQUANLYSINHVIEN.DTO;

namespace ProjectQUANLYSINHVIEN.DAL
{
    class khoa_DAL
    {
        Dataconnection dc;
        SqlDataAdapter adt;
        SqlCommand cm;
     
        public khoa_DAL()
        {
            dc = new Dataconnection();
            
        }
        public DataTable getAllKhoa()
        {
            string sqlGetAllKhoa = "SELECT Makhoa,Tenkhoa FROM Khoa";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(sqlGetAllKhoa,con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;

        }
        public bool insertKhoa(khoa k)
        {
            string sqlInsertKhoa = "INSERT INTO Khoa(Makhoa,Tenkhoa) VALUES(@MAKHOA,@TENKHOA)";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlInsertKhoa,con);
            try
            {
                con.Open();
                cm.Parameters.Add("@MAKHOA", SqlDbType.NVarChar).Value = k.MAKHOA;
                cm.Parameters.Add("@TENKHOA", SqlDbType.NVarChar).Value = k.TENKHOA;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool updateKhoa(khoa k)
        {
            string sqlInsertKhoa = "UPDATE Khoa SET Makhoa=@MAKHOA ,Tenkhoa=@TENKHOA WHERE id =@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlInsertKhoa, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@MAKHOA", SqlDbType.NVarChar).Value = k.MAKHOA;
                cm.Parameters.Add("@TENKHOA", SqlDbType.NVarChar).Value = k.TENKHOA;
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = k.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool deleteKhoa(khoa k)
        {
            string sqlDeleteKhoa = "DELETE FROM Khoa WHERE id =@ID";
            SqlConnection con = dc.getConnection();
            cm = new SqlCommand(sqlDeleteKhoa, con);
            try
            {
                con.Open();
                cm.Parameters.Add("@ID", SqlDbType.Int).Value = k.ID;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
