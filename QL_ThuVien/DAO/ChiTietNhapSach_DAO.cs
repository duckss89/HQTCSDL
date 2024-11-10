using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    class ChiTietNhapSach_DAO
    {
        public DataTable GetListCtNhapSachTheoMaSach(string maNhapSach)
        {
            string query = "Exec sp_LayChiTietNhapSachTheoMaNhapSach @maNhapSach = N'" + maNhapSach + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }


    }
}
