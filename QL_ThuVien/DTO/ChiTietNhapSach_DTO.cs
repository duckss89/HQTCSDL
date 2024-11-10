using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class ChiTietNhapSach_DTO
    {
        public ChiTietNhapSach_DTO(string maChiTietNhap, string maNhapSach, string maSach, int soLuongNhap, decimal giaNhap)
        {
            this.MaChiTietNhap = maChiTietNhap;
            this.MaNhapSach = maNhapSach;
            this.MaSach = maSach;
            this.SoLuongNhap = soLuongNhap;
            this.GiaNhap = giaNhap;
        }

        public ChiTietNhapSach_DTO(DataRow row)
        {
            this.MaChiTietNhap = row["maChiTietNhap"].ToString();
            this.MaNhapSach = row["maNhapSach"].ToString();
            this.MaSach = row["maSach"].ToString();
            this.SoLuongNhap = Convert.ToInt32(row["soLuongNhap"]);
            this.GiaNhap = Convert.ToDecimal(row["giaNhap"]);
        }

        private string maChiTietNhap;
        public string MaChiTietNhap
        {
            get { return maChiTietNhap; }
            set { maChiTietNhap = value; }
        }

        private string maNhapSach;
        public string MaNhapSach
        {
            get { return maNhapSach; }
            set { maNhapSach = value; }
        }

        private string maSach;
        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }

        private int soLuongNhap;
        public int SoLuongNhap
        {
            get { return soLuongNhap; }
            set { soLuongNhap = value; }
        }

        private decimal giaNhap;
        public decimal GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
    }

}
