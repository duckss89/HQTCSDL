using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class XuatSach_DTO
    {
        public XuatSach_DTO(string maXuatSach, string maNhanVien, DateTime ngayXuat, decimal tongGiaBan)
        {
            this.MaXuatSach = maXuatSach;
            this.MaNhanVien = maNhanVien;
            this.NgayXuat = ngayXuat;
            this.TongGiaBan = tongGiaBan;
        }

        public XuatSach_DTO(DataRow row)
        {
            this.MaXuatSach = row["maXuatSach"].ToString();
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.NgayXuat = (DateTime)row["ngayXuat"];
            this.TongGiaBan = (decimal)row["tongGiaBan"];
        }
        private string maXuatSach;
        public string MaXuatSach
        {
            get { return maXuatSach; }
            set{ maXuatSach = value; } 
        }
        private string maNhanVien;
        public string MaNhanVien 
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private DateTime ngayXuat;
        public DateTime NgayXuat 
         {
            get { return ngayXuat; }
            set { ngayXuat = value; }
        }
        private decimal tongGiaBan;
        public decimal TongGiaBan 
        {
            get { return tongGiaBan; }
            set { tongGiaBan = value; }
        }
    }

    public class ChiTietXuatSach_DTO
    {
        public ChiTietXuatSach_DTO(string maChiTietXuat, string maXuatSach, string maSach, int soLuongXuat, decimal giaBan, string lyDoXuat)
        {
            this.MaChiTietXuat = maChiTietXuat;
            this.MaXuatSach = maXuatSach;
            this.MaSach = maSach;
            this.SoLuongXuat = soLuongXuat;
            this.GiaBan = giaBan;
            this.LyDoXuat = lyDoXuat;
        }

        public ChiTietXuatSach_DTO(DataRow row)
        {
            this.MaChiTietXuat = row["maChiTietXuat"].ToString();
            this.MaXuatSach = row["maXuatSach"].ToString();
            this.MaSach = row["maSach"].ToString();
            this.SoLuongXuat = (int)row["soLuongXuat"];
            this.GiaBan = (decimal)row["giaBan"];
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
