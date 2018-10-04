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
    class sinhvien_BLL
    {
        sinhvien_DAL sv_dal = new sinhvien_DAL();
        public bool insertSinhVien(sinhvien sv, string filePath, string folderpath)
        {
            return sv_dal.insertSinhVien(sv, filePath, folderpath);
        }
        public DataTable GetAllsinhvien(khoa khoa)
        {
            return sv_dal.GetAllsinhvien(khoa);
        }
        public bool UpdateSinhVien(sinhvien sv, string filePath, string folderpath)
        {
            return sv_dal.UpdateSinhVien(sv, filePath, folderpath);
        }
        public bool deleteSinhVien(sinhvien sv)
        {
            return sv_dal.deleteSinhVien(sv);
        }
        public DataTable Laytatcasinhvientheotungkhoa(khoa kh)
        {
            return sv_dal.Laytatcasinhvientheotungkhoa(kh);
        }
        public int Laytongsosinhvientrongmotkhoa(khoa kh)
        {
            return sv_dal.Laytongsosinhvientrongmotkhoa(kh);
        }
        public DataTable Laytatcasinhvientheotunglop(lop lp)
        {
            return sv_dal.Laytatcasinhvientheotunglop(lp);
        }
        public int Laytongsosinhvientrongmotlop(lop lp)
        {
            return sv_dal.Laytongsosinhvientrongmotlop(lp);
        }
        public DataTable Timkiemsinhvientheoten(string makhoa, string malop, string masinhvien)
        {
            return sv_dal.Timkiemsinhvientheoten(makhoa, malop, masinhvien);
        }
        public DataTable Laytatcasinhviencuatatcacackhoa()
        {
            return sv_dal.Laytatcasinhviencuatatcacackhoa();
        }
    }
}
