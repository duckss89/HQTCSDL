using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class CtXuatSach_DTO
    {
        public CtXuatSach_DTO(string maChiTietXuat, string maXuatSach, string maSach, int soLuongXuat, decimal giaBan, string lyDoXuat)
        {
            this.MaChiTietXuat = maChiTietXuat;
            this.MaXuatSach = maXuatSach;
            this.MaSach = maSach;
            this.SoLuongXuat = soLuongXuat;
            this.GiaBan = giaBan;
            this.LyDoXuat = lyDoXuat;
        }

        public CtXuatSach_DTO(DataRow row)
        {
            this.MaChiTietXuat = row["maChiTietXuat"].ToString();
            this.MaXuatSach = row["maXuatSach"].ToString();
            this.MaSach = row["maSach"].ToString();
            this.SoLuongXuat = Convert.ToInt32(row["soLuongXuat"]);
            this.GiaBan = Convert.ToDecimal(row["giaBan"]);
            this.LyDoXuat = row["lyDoXuat"].ToString();
        }

        private string maChiTietXuat;
        public string MaChiTietXuat
        {
            get { return maChiTietXuat; }
            set { maChiTietXuat = value; }
        }

        private string maXuatSach;
        public string MaXuatSach
        {
            get { return maXuatSach; }
            set { maXuatSach = value; }
        }

        private string maSach;
        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }

        private int soLuongXuat;
        public int SoLuongXuat
        {
            get { return soLuongXuat; }
            set { soLuongXuat = value; }
        }

        private decimal giaBan;
        public decimal GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }

        private string lyDoXuat;
        public string LyDoXuat
        {
            get { return lyDoXuat; }
            set { lyDoXuat = value; }
        }
    }

}
