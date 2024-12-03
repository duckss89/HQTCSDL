using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace QL_ThuVien.DAO
{
    public class ChiTietPhieuTra_DAO
    {
        private static ChiTietPhieuTra_DAO instance;

        public static ChiTietPhieuTra_DAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuTra_DAO(); return instance; }
            private set { instance = value; }
        }

        private ChiTietPhieuTra_DAO() { }



        //hiển thị lstview Chi tiết phiếu mượn của UCMuonSach
        public DataTable GetChiTietPT(string maPhieuTra)
        {
            string query = " SELECT  s.tenSach," +
                            " ct.phiPhatSinh," +
                            " ct.tinhTrangSach," +
                            " ct.ghiChu" +
                            " FROM ChiTietPhieuTra ct" +
                            " JOIN PhieuTra pt ON pt.maPhieuTra = ct.maPhieuTra" +
                            " JOIN Sach s ON  ct.maSach = s.maSach" +
                            " WHERE ct.maPhieuTra = '" + maPhieuTra + "'";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { maPhieuTra });
        }

        public void GetPhieuMuonThenLoadToComboBox(Guna2ComboBox comboBox)
        {
            string statement = "SELECT maPhieuMuon FROM PhieuMuon";

            // Execute the SQL statement and read the data
            DataProvider.Instance.Function<Object>(statement, (command) =>
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maPhieuMuon = reader.GetString(reader.GetOrdinal("maPhieuMuon"));
                        comboBox.Items.Add(maPhieuMuon); // Use maPhieuMuon as both key and value
                    }
                }
                return null;
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

    }
}
