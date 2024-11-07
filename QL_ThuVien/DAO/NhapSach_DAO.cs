using QL_ThuVien.DTO;
using QL_ThuVien.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class NhapSach_DAO
    {
        private static NhapSach_DAO instance;

        public static NhapSach_DAO Instance
        {
            get { if (instance == null) instance = new NhapSach_DAO(); return instance; }
            private set { instance = value; }
        }


        private NhapSach_DAO() { }

        public DataTable GetListNhapSach()
        {
            string query = "Exec sp_LayDanhSachNhapSach";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
