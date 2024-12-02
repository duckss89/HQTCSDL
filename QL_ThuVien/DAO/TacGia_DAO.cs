using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class TacGia_DAO
    {
        private static TacGia_DAO instance;
        public static TacGia_DAO Instance
        {
            get { if (instance == null) instance = new TacGia_DAO(); return instance; }
            private set { instance = value; }
        }
        public List<TacGia_DTO> GetTacGia()
        {
            List<TacGia_DTO> list = new List<TacGia_DTO>();
            string query = "SELECT * FROM TacGia";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TacGia_DTO tacGia = new TacGia_DTO(item);
                list.Add(tacGia);
            }

            return list;
        }
    }
}
