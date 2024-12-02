using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class TacGia_DTO
    {
        public TacGia_DTO(string maTacGia, string tenTacGia, DateTime? ngaySinh)
        {
            this.MaTacGia = maTacGia;
            this.TenTacGia = tenTacGia;
            this.NgaySinh = ngaySinh;
        }

        public TacGia_DTO(DataRow row)
        {
            this.MaTacGia = row["maTacGia"].ToString();
            this.TenTacGia = row["tenTacGIa"].ToString();
            if (row.Table.Columns.Contains("NgaySinh"))
            {
                this.NgaySinh = DateTime.TryParse(row["NgaySinh"].ToString(), out DateTime parsedDate) ? (DateTime?)parsedDate : null;
            }
            else
            {
                this.NgaySinh = null; // Hoặc xử lý khác nếu cần
            }
        }

        private string maTacGia;
        public string MaTacGia
        {
            get => maTacGia;
            set => maTacGia = value;
        }

        private string tenTacGia;
        public string TenTacGia
        {
            get => tenTacGia;
            set => tenTacGia = value;
        }

        private DateTime? ngaySinh;
        public DateTime? NgaySinh
        {
            get => ngaySinh;
            set => ngaySinh = value;
        }

    }
}
