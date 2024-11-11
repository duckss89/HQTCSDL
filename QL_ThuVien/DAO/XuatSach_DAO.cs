using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class XuatSach_DAO
    {
        private static XuatSach_DAO instance;

        public static XuatSach_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new XuatSach_DAO();
                return instance;
            }
            private set { instance = value; }
        }

        private XuatSach_DAO() { }

        public DataTable GetListXuatSach()
        {
            string query = "Exec sp_LayDanhSachXuatSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListXuatSachTheoMa(string maXuatSach)
        {
            string query = "Exec sp_TimKiemXuatSachTheoMaXuat @maXuatSach = '" + maXuatSach+"'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
