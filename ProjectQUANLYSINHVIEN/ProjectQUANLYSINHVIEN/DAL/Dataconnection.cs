using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectQUANLYSINHVIEN
{
    public class Dataconnection
    {
        string constr;
        public Dataconnection()
        {
            constr = "Data Source=DESKTOP-U3BV707;Initial Catalog=QuanLySinhVien;Integrated Security=True";
        }
        public SqlConnection getConnection()
        {
            SqlConnection sql = new SqlConnection(constr);
            return sql;
        }
        
    }
}
