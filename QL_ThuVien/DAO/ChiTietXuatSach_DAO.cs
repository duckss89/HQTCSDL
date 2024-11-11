using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class ChiTietXuatSach_DAO
    {
        public DataTable GetListCtXuatSachTheoMaXuatSach(string maXuatSach)
        {
            string query = "Exec sp_LayChiTietXuatSachTheoMaXuatSach @maXuatSach = N'" + maXuatSach + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
