using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class DocGia_DAO
    {
        private static DocGia_DAO instance;

        public static DocGia_DAO Instance
        {
            get { if (instance == null) instance = new DocGia_DAO(); return instance; }
            private set { instance = value; }
        }


        private DocGia_DAO() { }

        public DataTable GetListDocGia()
        {
            string query = "Exec sp_LayDanhSacDocGia";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<DocGia_DTO> TimKiemDocGiaTheoTen(string tenDocGia)
        {
            List<DocGia_DTO> list = new List<DocGia_DTO>();

            string query = "Exec sp_TimKiemDocGiaTheoTen @tenDocGia = N'"+tenDocGia+"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DocGia_DTO dg = new DocGia_DTO(item);
                list.Add(dg);
            }

            return list;
        }

        public bool XoaDocGia(string maDocGia)
        {
            string query = "Delete DocGia Where maDocGia = '" + maDocGia + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
