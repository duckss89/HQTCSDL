using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class TheLoai_DAO
    {
        private static TheLoai_DAO instance;
        public static TheLoai_DAO Instance
        {
            get { if (instance == null) instance = new TheLoai_DAO(); return instance; }
            private set { instance = value; }
        }
        public TheLoai_DAO() { }

        public List<TheLoai_DTO> GetTheLoai()
        {
            List<TheLoai_DTO> list = new List<TheLoai_DTO>();
            string query = "SELECT * FROM NhaXuatBan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TheLoai_DTO theLoai = new TheLoai_DTO(item);
                list.Add(theLoai);
            }

            return list;
        }
    }

}

