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
    }
}
