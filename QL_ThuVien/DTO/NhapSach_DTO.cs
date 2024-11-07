using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QL_ThuVien.DTO
{
    public class NhapSach_DTO
    {
        public NhapSach_DTO(string maNhapSach, string maNhanVien, string hoTenNhanVien, DateTime? ngayNhap, string nguonNhap, string soDienThoai, string email, string diaChiChiTiet, string tenDuong, string phuongXa, string quanHuyen, string tinhThanhPho, decimal tongTien)
        {
            this.MaNhapSach = maNhapSach;
            this.MaNhanVien = maNhanVien;
            this.HoTenNhanVien = hoTenNhanVien;
            this.NgayNhap = ngayNhap;
            this.NguonNhap = nguonNhap;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
            this.DiaChiChiTiet = diaChiChiTiet;
            this.TenDuong = tenDuong;
            this.PhuongXa = phuongXa;
            this.QuanHuyen = quanHuyen;
            this.TinhThanhPho = tinhThanhPho;
            this.TongTien = tongTien;
        }

        public NhapSach_DTO(DataRow row)
        {
            this.MaNhapSach = row["maNhapSach"].ToString();
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.HoTenNhanVien = row["hoTenNhanVien"].ToString();
            this.NgayNhap = row["ngayNhap"] as DateTime?;
            this.NguonNhap = row["nguonNhap"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.Email = row["email"].ToString();
            this.DiaChiChiTiet = row["diaChiChiTiet"].ToString();
            this.TenDuong = row["tenDuong"].ToString();
            this.PhuongXa = row["phuongXa"].ToString();
            this.QuanHuyen = row["quanHuyen"].ToString();
            this.TinhThanhPho = row["tinhThanhPho"].ToString();
            this.TongTien = Convert.ToDecimal(row["tongTien"].ToString());
        }

        private string maNhapSach;
        public string MaNhapSach
        {
            get { return maNhapSach; }
            set { maNhapSach = value; }
        }

        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        private string hoTenNhanVien;
        public string HoTenNhanVien
        {
            get { return hoTenNhanVien; }
            set { hoTenNhanVien = value; }
        }

        private DateTime? ngayNhap;
        public DateTime? NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        private string nguonNhap;
        public string NguonNhap
        {
            get { return nguonNhap; }
            set { nguonNhap = value; }
        }

        private string soDienThoai;
        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string diaChiChiTiet;
        public string DiaChiChiTiet
        {
            get { return diaChiChiTiet; }
            set { diaChiChiTiet = value; }
        }

        private string tenDuong;
        public string TenDuong 
        {
            get { return tenDuong; }
            set { tenDuong = value; } 
        }
        private string phuongXa;
        public string PhuongXa
        {
            get { return phuongXa; }
            set { phuongXa = value; }
        }
        private string quanHuyen;
        public string QuanHuyen
        {
            get { return quanHuyen; }
            set { quanHuyen = value; }
        }
        private string tinhThanhPho;
        public string TinhThanhPho
        {
            get { return tinhThanhPho; }
            set { tinhThanhPho = value; }
        }
        private decimal tongTien;
        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }

}
