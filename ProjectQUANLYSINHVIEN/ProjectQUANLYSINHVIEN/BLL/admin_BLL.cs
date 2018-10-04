using ProjectQUANLYSINHVIEN.DAL;
using ProjectQUANLYSINHVIEN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQUANLYSINHVIEN.BLL
{
    class admin_BLL
    {
        admin_DAL admin_dal = new admin_DAL();

        public DataTable getAmin()
        {
            return admin_dal.getAmin();
        }
        public bool insertAdmin()
        {
            return admin_dal.insertAdmin();
        }
        public DataTable getTendangnhap(string tendangnhap)
        {
            return admin_dal.getTendangnhap(tendangnhap);
        }
        public bool updateAdmin()
        {
            return admin_dal.updateAdmin();
        }
    }
}
