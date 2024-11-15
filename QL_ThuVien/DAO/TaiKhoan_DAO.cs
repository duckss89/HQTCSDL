using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class TaiKhoan_DAO
    {
        private static TaiKhoan_DAO instance;

        public static TaiKhoan_DAO Instance
        {
            get { if (instance == null) instance = new TaiKhoan_DAO(); return instance; }
            private set { instance = value; }
        }

        public TaiKhoan_DAO() { }

        public DataTable GetListNhanVien()
        {
            string query = "EXEC sp_LayDanhSachTaiKhoan";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListTaiKhoanTheoTenNhanVien(string tenNhanVien)
        {
            string query = "EXEC sp_TimKiemTaiKhoanTheoTen @tenNhanVien = N'" + tenNhanVien + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool KiemTraTaiKhoan(string maNhanVien)
        {
            string query = "SELECT dbo.fn_KiemTraTaiKhoan('"+maNhanVien+"') AS DaCoTaiKhoan";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToBoolean(result);
        }

        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string maNhanVien, bool trangThai, string ngayTao)
        {
            string query = "EXEC sp_ThemTaiKhoan "
                         + "@tenDangNhap = N'" + tenDangNhap + "', "
                         + "@matKhau = N'" + matKhau + "', "
                         + "@maNhanVien = N'" + maNhanVien + "', "
                         + "@trangThai = " + (trangThai ? "1" : "0") + ", "
                         + "@ngayTao = '" + ngayTao + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool XoaTaiKhoan(string maTaiKhoan)
        {
            string query = "Delete TaiKhoan where maTaiKhoan = '"+maTaiKhoan+"'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<TaiKhoan_DTO> LayThongTinTaiKhoanTheoMaTK(string maTaiKhoan)
        {
            List<TaiKhoan_DTO> list = new List<TaiKhoan_DTO>();

            string query = "EXEc sp_LayThongTinTaiKhoanTheoMaTaiKhoan @maTaiKhoan = '" + maTaiKhoan + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO(item);
                list.Add(tk);
            }

            return list;
        }

        public bool SuaTaiKhoan(string maTaiKhoan, string tenDangNhap, string matKhau, string maNhanVien, bool trangThai)
        {
            string query = "EXEC sp_SuaTaiKhoan "
                         + "@maTaiKhoan = '" + maTaiKhoan + "', "
                         + "@tenDangNhap = '" + tenDangNhap + "', "
                         + "@matKhau = '" + matKhau + "', "
                         + "@maNhanVien = '" + maNhanVien + "', "
                         + "@trangThai = " + (trangThai ? "1" : "0");

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }


    }
}
