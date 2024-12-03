using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class PhieuTra_DAO
    {
        private static PhieuTra_DAO instance;

        public static PhieuTra_DAO Instance
        {
            get { if (instance == null) instance = new PhieuTra_DAO(); return instance; }
            private set { instance = value; }
        }


        private PhieuTra_DAO() { }

        public DataTable GetListPhieuTra()
        {
            string query = "Exec sp_LayDanhSachPhieuTra";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void XoaPhieuTra(string maPhieuTra)
        {
            string query = $"Exec sp_XoaPhieuTra '{maPhieuTra}'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable GetInfoPhieuTra(string maPhieuTra)
        {
            string query = "SELECT dg.hoTen AS hoTenDocGia, " +
                "nv.hoTenNhanVien, pt.ngayTra, pt.trangThai " +
                "FROM PhieuTra pt " +
                "JOIN PhieuMuon pm ON pm.maPhieuMuon = pt.maPhieuMuon " +
                "JOIN DocGia dg ON pm.maDocGia = dg.maDocGia " +
                "JOIN NhanVien nv ON pt.maNhanVien = nv.maNhanVien " +
                "WHERE pt.maPhieuTra = @maPhieuTra";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maPhieuTra });
        }
        public void ThemPhieuTra(string maPhieuMuon, string maNhanVien, string ngayTra, string trangThai, string chiTietPhieuTra)
        {
            string query = "EXEC sp_ThemPhieuTra @maPhieuMuon, @maNhanVien, @ngayTra, @trangThai, @chiTietPhieuTra";

            // Create parameters for the query
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maPhieuMuon", SqlDbType.VarChar) { Value = maPhieuMuon },
                new SqlParameter("@maNhanVien", SqlDbType.VarChar) { Value = maNhanVien },
                new SqlParameter("@ngayTra", SqlDbType.Date) { Value = DateTime.Parse(ngayTra) },
                new SqlParameter("@trangThai",SqlDbType.NVarChar) { Value = trangThai },
                new SqlParameter("@chiTietPhieuTra", SqlDbType.NVarChar) { Value = chiTietPhieuTra }
            };

            // Execute the query
            DataProvider.Instance.Function(query, command =>
            {
                return command.ExecuteNonQuery();
            }, parameters);
        }
        public DataTable GetListPhieuTraTK(string searchText, string searchType)
        {
            string query = $"EXEC sp_LayDSPTTheoSachHoacDocGia '{searchText}', '{searchType}'";

            return DataProvider.Instance.ExecuteQuery(query);
        }

    }
}
