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
    class admin_DAL
    {
        Dataconnection dc;
        SqlCommand cm;
        SqlDataAdapter adt;
        public admin_DAL()
        {
            dc = new Dataconnection();
        }
        public DataTable getAmin()
        {
            string selectAdmin = " SELECT * FROM dbo.Admin WHERE Tendangnhap='" + admin.TENDANGNHAP + "'AND Password='" + admin.MATKHAU + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(selectAdmin,con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getTendangnhap(string tendangnhap)
        {
            string selectAdmin = " SELECT Tendangnhap FROM dbo.Admin WHERE Tendangnhap='" + tendangnhap + "'";
            SqlConnection con = dc.getConnection();
            adt = new SqlDataAdapter(selectAdmin, con);
            con.Open();
            DataTable dt = new DataTable();
            adt.Fill(dt);
            con.Close();
            return dt;
        }
        public bool insertAdmin()
        {
            string insertAdmin = "INSERT INTO dbo.Admin(Tendangnhap,Password)VALUES(@TENDANGNHAP,@PASSWORD)";
            SqlConnection con = dc.getConnection();
            try
            {
                cm = new SqlCommand(insertAdmin, con);
                con.Open();
                cm.Parameters.Add("@TENDANGNHAP", SqlDbType.NVarChar).Value = admin.TENDANGNHAP;
                cm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar).Value = admin.MATKHAU;
                cm.ExecuteNonQuery();
                con.Close();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public bool updateAdmin()
        {
            string updateAdmin = "UPDATE dbo.Admin SET Password=@PASSWORD";
            SqlConnection con = dc.getConnection();
            try
            {
                cm = new SqlCommand(updateAdmin, con);
                con.Open();
                cm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar).Value = admin.MATKHAU;
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
