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
    class ketquahoctap_BLL
    {
        ketquahoctap_DAL kqht_dal = new ketquahoctap_DAL();
        public DataTable laytatcalop(string khoa)
        {
            return kqht_dal.laytatcalop(khoa);
        }
        public DataTable laytatcasinhvien(string lop)
        {
            return kqht_dal.laytatcasinhvien(lop);
        }
        public DataTable laytatcaKy()
        {
            return kqht_dal.laytatcaKy();
        }
        public DataTable laytatcamonhoc(string khoa, int ky)
        {
            return kqht_dal.laytatcamonhoc(khoa, ky);
        }
        public DataTable LayTatCaCacMonHocThuocKhoa(khoa k)
        {
            return kqht_dal.LayTatCaCacMonHocThuocKhoa(k);
        }
        public bool Themdulieuvaobang(ketquahoctap kqht)
        {
            return kqht_dal.Themdulieuvaobang(kqht);
        }
        public DataTable Laydanhsachketquahoctap()
        {
            return kqht_dal.Laydanhsachketquahoctap();
        }
        public bool Xoadulieuketquasinhvien(ketquahoctap kqht)
        {
            return kqht_dal.Xoadulieuketquasinhvien(kqht);
        }
        public DataTable LaytatcadulieusinhvienbangMasvVaMamh(ketquahoctap kqht)
        {
            return kqht_dal.LaytatcadulieusinhvienbangMasvVaMamh(kqht);
        }
        public bool Capnhatdulieubangketquahoctap(ketquahoctap kqht)
        {
            return kqht_dal.Capnhatdulieubangketquahoctap(kqht);
        }
        public DataTable Laytatcacacmoncuaky(int ky)
        {
            return kqht_dal.Laytatcacacmoncuaky(ky);
        }
        public DataTable Laytatcacacmontrongmotkycuasinhvien(string Msv, int Ky)
        {
            return kqht_dal.Laytatcacacmontrongmotkycuasinhvien(Msv, Ky);
        }
        public DataTable Monsinhviencodiem(string Masinhvien)
        {
            return kqht_dal.Monsinhviencodiem(Masinhvien);
        }
        public DataTable Monsinhvienchuacodiem(string Masinhvien, string Makhoa)
        {
            return kqht_dal.Monsinhvienchuacodiem(Masinhvien, Makhoa);
        }
        public double TongDiemDathi(string masinhvien)
        {
            return kqht_dal.TongDiemDathi(masinhvien);
        }
        public DataTable Layketquahoctaptheotunglop(sinhvien sv)
        {
            return kqht_dal.Layketquahoctaptheotunglop(sv);
        }
        public DataTable Layketquahoctaptheotunglopvasinhvien(sinhvien sv)
        {
            return kqht_dal.Layketquahoctaptheotunglopvasinhvien(sv);
        }
        public DataTable Layketquahoctaptheotungkhoa(khoa kh)
        {
            return kqht_dal.Layketquahoctaptheotungkhoa(kh);
        }
    }
}
