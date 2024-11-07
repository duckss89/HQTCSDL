using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class DocGia_DAO
    {
        private static DocGia_DAO instance;

        public static DocGia_DAO Instance
        {
            get { if (instance == null) instance = new DocGia_DAO(); return instance; }
            private set { instance = value; }
        }


        private DocGia_DAO() { }

        public DataTable GetListDocGia()
        {
            string query = "Exec sp_LayDanhSacDocGia";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<DocGia_DTO> TimKiemDocGiaTheoTen(string tenDocGia)
        {
            List<DocGia_DTO> list = new List<DocGia_DTO>();

            string query = "Exec sp_TimKiemDocGiaTheoTen @tenDocGia = N'"+tenDocGia+"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DocGia_DTO dg = new DocGia_DTO(item);
                list.Add(dg);
            }

            return list;
        }

        public bool XoaDocGia(string maDocGia)
        {
            string query = "Delete DocGia Where maDocGia = '" + maDocGia + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ThemDocGia(string ho, string hoLot, string ten, string ngaySinh, string gioiTinh, string tenDuong, string phuongXa, string quanHuyen, string tinhThanhPho, string soDienThoai, string email)
        {
            string query = "sp_ThemDocGia "
                         + "@ho = N'" + ho + "', "
                         + "@hoLot = N'" + hoLot + "', "
                         + "@ten = N'" + ten + "', "
                         + "@ngaySinh = '" + ngaySinh + "', "
                         + "@gioiTinh = N'" + gioiTinh + "', "
                         + "@tenDuong = N'" + tenDuong + "', "
                         + "@phuongXa = N'" + phuongXa + "', "
                         + "@quanHuyen = N'" + quanHuyen + "', "
                         + "@tinhThanhPho = N'" + tinhThanhPho + "', "
                         + "@soDienThoai = '" + soDienThoai + "', "
                         + "@email = '" + email + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<DocGia_DTO> LayThongTinDocGiaTheoMaDG(string maDocGia)
        {
            List<DocGia_DTO> list = new List<DocGia_DTO>();

            string query = "EXEc sp_LayThongTinDocGiaTheoMa @maDocGia = '" + maDocGia + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DocGia_DTO dg = new DocGia_DTO(item);
                list.Add(dg);
            }

            return list;
        }

        public bool SuaDocGia(string MaDocGia, string Ho, string HoLot, string Ten, string NgaySinh, string GioiTinh, string TenDuong, string PhuongXa, string QuanHuyen, string TinhThanhPho, string SoDienThoai, string Email)
        {
            string query = "Exec sp_SuaThongTinDocGia " +
                           "@MaDocGia = '" + MaDocGia + "', " +
                           "@Ho = N'" + Ho + "', " +
                           "@HoLot = N'" + HoLot + "', " +
                           "@Ten = N'" + Ten + "', " +
                           "@NgaySinh = '" + NgaySinh + "', " +
                           "@GioiTinh = N'" + GioiTinh + "', " +
                           "@TenDuong = N'" + TenDuong + "', " +
                           "@PhuongXa = N'" + PhuongXa + "', " +
                           "@QuanHuyen = N'" + QuanHuyen + "', " +
                           "@TinhThanhPho = N'" + TinhThanhPho + "', " +
                           "@SoDienThoai = '" + SoDienThoai + "', " +
                           "@Email = '" + Email + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
