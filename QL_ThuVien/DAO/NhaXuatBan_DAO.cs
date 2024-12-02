using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class NhaXuatBan_DAO
    {
        public static NhaXuatBan_DAO instance;

        public static NhaXuatBan_DAO Instance
        {
            get { if (instance == null) instance = new NhaXuatBan_DAO(); return instance; }
            private set { instance = value; }
        }

        public NhaXuatBan_DAO() { }

        public List<NhaXuatBan_DTO> GetNXB()
        {
            List<NhaXuatBan_DTO> list = new List<NhaXuatBan_DTO>();
            string query = "SELECT * FROM NhaXuatBan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaXuatBan_DTO nhaXuatBan = new NhaXuatBan_DTO(item);
                list.Add(nhaXuatBan);
            }

            return list;
        }
    }
}
