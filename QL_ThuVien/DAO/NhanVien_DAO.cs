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


        private NhanVien_DAO() { }
        public DataTable GetListNhanVien()
        {
            string query = "Exec sp_layDanhSachNhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
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
    

