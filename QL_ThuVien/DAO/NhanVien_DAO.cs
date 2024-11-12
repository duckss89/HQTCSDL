using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
   public class NhanVien_DAO
    {
        private static NhanVien_DAO instance;

        public static NhanVien_DAO Instance
        {
            get { if (instance == null) instance = new NhanVien_DAO(); return instance; }
            private set { instance = value; }
        }


        public NhanVien_DAO() { }

        public DataTable GetListNhanVien()
        {
            string query = "Exec sp_layDanhSachNhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public List<NhanVien_DTO> GetNhanVien()
        {
            List<NhanVien_DTO> list = new List<NhanVien_DTO>();
            string query = "SELECT * FROM NhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien_DTO nhanVien = new NhanVien_DTO(item);
                list.Add(nhanVien);
            }

            return list;
        }

        public DataTable GetListNhanVienTheoTen(string tenNhanVien)
        {
            string query = "Exec sp_TimKiemNhanVienTheoTen @tenNhanVien= N'" + tenNhanVien + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool XoaNhanVien(string maNhanVien)
        {
            string query = "Delete NhanVien where maNhanVien = '" + maNhanVien + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
    

