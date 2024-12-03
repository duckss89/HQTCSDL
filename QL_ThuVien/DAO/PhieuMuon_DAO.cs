using QL_ThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class PhieuMuon_DAO
    {
        private static PhieuMuon_DAO instance;

        public static PhieuMuon_DAO Instance
        {
            get { if (instance == null) instance = new PhieuMuon_DAO(); return instance; }
            private set { instance = value; }
        }


        private PhieuMuon_DAO() { }

        public DataTable GetListPhieuMuon()
        {
            string query = "Exec sp_LayDanhSachPhieuMuon";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void XoaPhieuMuon(string maPhieuMuon)
        {
            string query = $"Exec sp_XoaPhieuMuon '{maPhieuMuon}'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable GetInfoPhieuMuon(string maPhieuMuon)
        {
            string query = " SELECT  dg.hoTen AS hoTenDocGia," +
                " nv.hoTenNhanVien AS hoTenNhanVien, pm.ngayMuon, pm.ngayHetHan" +
                " FROM PhieuMuon pm" +
                " JOIN DocGia dg ON pm.maDocGia = dg.maDocGia" +
                " JOIN NhanVien nv ON pm.maNhanVien = nv.maNhanVien" +
                " WHERE pm.maPhieuMuon = '" + maPhieuMuon + "'";

            return DataProvider.Instance.ExecuteQuery(query);
        }
        public void ThemPhieuMuon(string maDocGia, string maNhanVien, string ngayMuon, string ngayHetHan, string chiTietPhieuMuon)
        {
            string query = "EXEC sp_ThemPhieuMuon @maDocGia, @maNhanVien, @ngayMuon, @ngayHetHan, @chiTietPhieuMuon";

            // Create parameters for the query
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maDocGia", SqlDbType.VarChar) { Value = maDocGia },
                new SqlParameter("@maNhanVien", SqlDbType.VarChar) { Value = maNhanVien },
                new SqlParameter("@ngayMuon", SqlDbType.Date) { Value = DateTime.Parse(ngayMuon) },
                new SqlParameter("@ngayHetHan", SqlDbType.Date) { Value = DateTime.Parse(ngayHetHan) },
                new SqlParameter("@chiTietPhieuMuon", SqlDbType.NVarChar) { Value = chiTietPhieuMuon }
            };

            // Execute the query
            DataProvider.Instance.Function(query, command =>
            {
                return command.ExecuteNonQuery();
            }, parameters);
        }
        public DataTable GetListPhieuMuonTK(string searchText, string searchType)
        {
            string query = $"EXEC sp_LayDSPMTheoSachHoacDocGia '{searchText}', '{searchType}'";

            return DataProvider.Instance.ExecuteQuery(query);
        }


    }
}

