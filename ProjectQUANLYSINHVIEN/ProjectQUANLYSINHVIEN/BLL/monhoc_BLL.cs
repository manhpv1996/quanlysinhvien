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
    class monhoc_BLL
    {
        monhoc_DAL monhoc_dal = new monhoc_DAL();

        public DataTable getAllLoaiMH()
        {
            return monhoc_dal.getAllLoaiMH();
        }
        public DataTable getAllMonHoc()
        {
            return monhoc_dal.getAllMonHoc();
        }
        public bool ThemMonhoc(monhoc monhoc)
        {
            return monhoc_dal.ThemMonhoc(monhoc);
        }
        public bool SuaMonhoc(monhoc monhoc)
        {
            return monhoc_dal.SuaMonhoc(monhoc);
        }
        public bool XoaMonhoc(monhoc monhoc)
        {
            return monhoc_dal.XoaMonhoc(monhoc);
        }
        public DataTable laytatcaKy()
        {
            return monhoc_dal.laytatcaKy();
        }
    }
}
