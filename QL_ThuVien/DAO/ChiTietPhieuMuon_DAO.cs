using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien.DAO
{
    public class ChiTietPhieuMuon_DAO
    {
        private static ChiTietPhieuMuon_DAO instance;

        public static ChiTietPhieuMuon_DAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuMuon_DAO(); return instance; }
            private set { instance = value; }
        }

        private ChiTietPhieuMuon_DAO() { }



        //hiển thị lstview Chi tiết phiếu mượn của UCMuonSach
        public DataTable GetChiTietPM(string maPhieuMuon)
        {
            string query = " SELECT  s.tenSach," +
                            " ct.soLuong," +
                            " ct.tinhTrangSach," +
                            " ct.ghiChu" +
                            " FROM ChiTietPhieuMuon ct" +
                            " JOIN PhieuMuon pm ON pm.maPhieuMuon = ct.maPhieuMuon" +
                            " JOIN Sach s ON  ct.maSach = s.maSach" +
                            " WHERE ct.maPhieuMuon = '" + maPhieuMuon + "'";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maPhieuMuon });
        }

        public void GetDocGiaThenLoadToDict(Dictionary<string, string> dict)
        {
            string statement = "SELECT maDocGia, hoTen FROM DocGia";
            DataProvider.Instance.Function(statement, (command) =>
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dict.Add(reader.GetString(reader.GetOrdinal("hoTen")),
                            reader.GetString(reader.GetOrdinal("maDocGia"))); // them khoa hoTen va gia tri maDocGia vao comboBox
                    }
                    return new Object();
                }
            });

        }

        public void GetNhanVienThenLoadToDict(Dictionary<string, string> dict)
        {
            string statement1 = "SELECT maNhanVien, hoTenNhanVien FROM NhanVien";
            DataProvider.Instance.Function(statement1, (command) =>
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dict.Add(reader.GetString(reader.GetOrdinal("hoTenNhanVien")),
                            reader.GetString(reader.GetOrdinal("maNhanVien"))); // them khoa hoTen va gia tri maDocGia vao comboBox
                    }
                    return new Object();
                }
            });

        }

        public void GetSachThenLoadToDict(Dictionary<string, string> dictSach)
        {
            string statement2 = "SELECT maSach, tenSach FROM Sach";
            DataProvider.Instance.Function(statement2, (command) =>
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dictSach.Add(reader.GetString(reader.GetOrdinal("tenSach")),
                            reader.GetString(reader.GetOrdinal("maSach"))); // them khoa hoTen va gia tri maDocGia vao comboBox
                    }
                    return new Object();
                }
            });
        }

        public void DeletePhieuMuon(string phieuXoa)
        {
            string statement = "DELETE FROM PhieuMuon WHERE maPhieuMuon = @maPhieuMuon; " +
                                   "DELETE FROM ChiTietPhieuMuon WHERE maPhieuMuon = @maPhieuMuon";
            DataProvider.Instance.Function(statement, (command) =>
            {
                command.Parameters.AddWithValue("@maPhieuMuon", phieuXoa);
                command.ExecuteNonQuery();
                return new Object();
            });
        }



    }
}
