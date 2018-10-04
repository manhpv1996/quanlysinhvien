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
    class khoa_BLL
    {
        khoa_DAL khoa_dal = new khoa_DAL();

        public DataTable getAllKhoa()
        {
            return khoa_dal.getAllKhoa();
        }
        public bool insertKhoa(khoa k)
        {
            return khoa_dal.insertKhoa(k);
        }
        public bool updateKhoa(khoa k)
        {
            return khoa_dal.updateKhoa(k);
        }
        public bool deleteKhoa(khoa k)
        {
            return khoa_dal.deleteKhoa(k);
        }
    }
}
