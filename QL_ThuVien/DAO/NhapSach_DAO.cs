using QL_ThuVien.DTO;
using QL_ThuVien.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class NhapSach_DAO
    {
        private static NhapSach_DAO instance;

        public static NhapSach_DAO Instance
        {
            get { if (instance == null) instance = new NhapSach_DAO(); return instance; }
            private set { instance = value; }
        }


        private NhapSach_DAO() { }

        public DataTable GetListNhapSach()
        {
            string query = "Exec sp_LayDanhSachNhapSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<NhapSach_DTO> TimKiemNhapSachTheoMaSach(string maNhapSach)
        {
            List<NhapSach_DTO> list = new List<NhapSach_DTO>();

            string query = "Exec sp_TimKiemNhapSach @maNhapSach = N'" + maNhapSach + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapSach_DTO ns = new NhapSach_DTO(item);
                list.Add(ns);
            }

            return list;
        }
        public bool XoaNhapSach(string maNhapSach)
        {
            string query = "Delete DocGia Where maNhapSach = '" + maNhapSach + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ThemNhapSach(string maNhapSach, string maNhanVien, string nguonNhap, string soDienThoai, string email,
                         string diaChiChiTiet, string tenDuong, string phuongXa, string quanHuyen, string tinhThanhPho, decimal tongTien)
        {
            string query = "sp_ThemNhapSach "
                         + "@maNhapSach = '" + maNhapSach + "', "
                         + "@maNhanVien = '" + maNhanVien + "', "
                         + "@nguonNhap = N'" + nguonNhap + "', "
                         + "@soDienThoai = '" + soDienThoai + "', "
                         + "@email = '" + email + "', "
                         + "@diaChiChiTiet = N'" + diaChiChiTiet + "', "
                         + "@tenDuong = N'" + tenDuong + "', "
                         + "@phuongXa = N'" + phuongXa + "', "
                         + "@quanHuyen = N'" + quanHuyen + "', "
                         + "@tinhThanhPho = N'" + tinhThanhPho + "', "
                         + "@tongTien = " + tongTien;

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<NhapSach_DTO> LayThongTinDocGiaTheoMaDG(string maDocGia)
        {
            List<NhapSach_DTO> list = new List<NhapSach_DTO>();

            string query = "EXEC sp_LayThongTinDocGiaTheoMa @maDocGia";


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapSach_DTO ns = new NhapSach_DTO(item);
                list.Add(ns);
            }

            return list;
        }
        public bool SuaNhapSach(string maNhapSach, string maNhanVien, string nguonNhap, string soDienThoai, string email,
                         string diaChiChiTiet, string tenDuong, string phuongXa, string quanHuyen, string tinhThanhPho, decimal tongTien)
        {
            string query = "Exec sp_SuaNhapSach "
                         + "@maNhapSach = '" + maNhapSach + "', "
                         + "@maNhanVien = '" + maNhanVien + "', "
                         + "@nguonNhap = N'" + nguonNhap + "', "
                         + "@soDienThoai = '" + soDienThoai + "', "
                         + "@email = '" + email + "', "
                         + "@diaChiChiTiet = N'" + diaChiChiTiet + "', "
                         + "@tenDuong = N'" + tenDuong + "', "
                         + "@phuongXa = N'" + phuongXa + "', "
                         + "@quanHuyen = N'" + quanHuyen + "', "
                         + "@tinhThanhPho = N'" + tinhThanhPho + "', "
                         + "@tongTien = " + tongTien;

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
