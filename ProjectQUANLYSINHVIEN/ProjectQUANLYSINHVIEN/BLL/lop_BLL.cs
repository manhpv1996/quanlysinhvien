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
    class lop_BLL
    {
        lop_DAL lop_dal = new lop_DAL();
        public DataTable getAllLop()
        {
            return lop_dal.getAllLop();
        }
        public bool insertLop(lop lp)
        {
            return lop_dal.insertLop(lp);
        }
        public bool updateLop(lop lp)
        {
            return lop_dal.updateLop(lp);
        }
        public bool deleteLop(lop lp)
        {
            return lop_dal.deleteLop(lp);
        }
        public DataTable getTenloptheotenKhoa(lop lp)
        {
            return lop_dal.getTenloptheotenKhoa(lp);
        }
        public DataTable laydanhsachtentatcalop(lop lp)
        {
            return lop_dal.laydanhsachtentatcalop(lp);
        }
    }
}
