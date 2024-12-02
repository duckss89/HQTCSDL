using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class Sach_DAO
    {
        private static Sach_DAO instance;

        public static Sach_DAO Instance
        {
            get { if (instance == null) instance = new Sach_DAO(); return instance; }
            private set { instance = value; }
        }

        public Sach_DAO() { }

        public DataTable GetListSach()
        {
            string query = "Exec sp_LayDanhSachThongTinSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<Sach_DTO> GetSach()
        {
            List<Sach_DTO> list = new List<Sach_DTO>();
            string query = "SELECT * FROM Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Sach_DTO sach = new Sach_DTO(item);
                list.Add(sach);
            }

            return list;
        }

        public DataTable GetListSachTheoTen(string tenSach)
        {
            string query = "Exec sp_TimKiemThongTinSachTheoTen @tenSach = N'" + tenSach + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool XoaSach(string maSach)
        {
            string query = "Delete NhanVien where maSach = '" + maSach + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ThemSach(string tenSach, string biaSach, string ISBN, int namXuatBan, int soLuong, decimal giaBan, string maTheLoai, string maTacGia, string maNhaXuatBan, string viTri)
        {
            string query = "sp_ThemSach " +
                           "@tenSach = N'" + tenSach + "', " +
                           "@biaSach = N'" + biaSach + "', " +
                           "@ISBN = '" + ISBN + "', " +
                           "@namXuatBan = " + namXuatBan + ", " +
                           "@soLuong = " + soLuong + ", " +
                           "@giaBan = " + giaBan + ", " +
                           "@maTheLoai = '" + maTheLoai + "', " +
                           "@maTacGia = '" + maTacGia + "', " +
                           "@maNhaXuatBan = '" + maNhaXuatBan + "', " +
                           "@viTri = N'" + viTri + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Sach_DTO> GetViTri()
        {
            List<Sach_DTO> list = new List<Sach_DTO>();
            string query = "SELECT viTri FROM Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Sach_DTO viTri = new Sach_DTO(item);
                list.Add(viTri);
            }
            return list;
        }

    }
}
