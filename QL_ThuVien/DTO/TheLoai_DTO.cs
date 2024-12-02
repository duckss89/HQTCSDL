using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class TheLoai_DTO
    {
        public TheLoai_DTO(string maTheLoai, string tenTheLoai)
        {
            this.MaTheLoai = maTheLoai;
            this.TenTheLoai = tenTheLoai;
        }

        public TheLoai_DTO(DataRow row)
        {
            this.MaTheLoai = row["maTheLoai"].ToString();
            this.TenTheLoai = row["tenTheLoai"].ToString();
        }

        private string maTheLoai;
        public string MaTheLoai
        {
            get => maTheLoai;
            set => maTheLoai = value;
        }
        private string tenTheLoai;
        public string TenTheLoai
        {
            get => tenTheLoai;
            set => tenTheLoai = value;
        }
    }
}
