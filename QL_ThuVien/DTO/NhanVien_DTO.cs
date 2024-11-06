using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
   public  class NhanVien_DTO
    {
        public NhanVien_DTO(string maNhanVien, string hoTenNhanVien, string ho, string hoLot, string ten, DateTime? ngaySinh, string gioiTinh, string diaChiChiTiet, string tenDuong, string phuongXa, string quanHuyen, string tinhThanhPho, string soDienThoai, string email, bool chucVu, DateTime? ngayLamViec)
        {
            this.MaNhanVien = maNhanVien;
            this.HoTenNhanVien = hoTenNhanVien;
            this.Ho = ho;
            this.HoLot = hoLot;
            this.Ten = ten;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChiChiTiet = diaChiChiTiet;
            this.TenDuong = tenDuong;
            this.PhuongXa = phuongXa;
            this.QuanHuyen = quanHuyen;
            this.TinhThanhPho = tinhThanhPho;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
            this.ChucVu = chucVu;
            this.NgayLamViec = ngayLamViec;
        }

        public NhanVien_DTO(DataRow row)
        {
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.HoTenNhanVien = row["hoTenNhanVien"].ToString();
            this.Ho = row["ho"].ToString();
            this.HoLot = row["hoLot"].ToString();
            this.Ten = row["ten"].ToString();
            this.NgaySinh = (DateTime?)row["ngaySinh"];
            this.GioiTinh = row["gioiTinh"].ToString();
            this.DiaChiChiTiet = row["diaChiChiTiet"].ToString();
            this.TenDuong = row["tenDuong"].ToString();
            this.PhuongXa = row["phuongXa"].ToString();
            this.QuanHuyen = row["quanHuyen"].ToString();
            this.TinhThanhPho = row["tinhThanhPho"].ToString();
            this.SoDienThoai = row["soDienThoai"].ToString();
            this.Email = row["email"].ToString();
            this.ChucVu = (bool)row["chucVu"];
            this.NgayLamViec = (DateTime?)row["ngayLamViec"];
        }

        private string maNhanVien;
        public string MaNhanVien
        {
            get => maNhanVien;
            set => maNhanVien = value;
        }

        private string hoTenNhanVien;
        public string HoTenNhanVien
        {
            get => hoTenNhanVien;
            set => hoTenNhanVien = value;
        }

        private string ho;
        public string Ho
        {
            get => ho;
            set => ho = value;
        }

        private string hoLot;
        public string HoLot
        {
            get => hoLot;
            set => hoLot = value;
        }

        private string ten;
        public string Ten
        {
            get => ten;
            set => ten = value;
        }

        private DateTime? ngaySinh;
        public DateTime? NgaySinh
        {
            get => ngaySinh;
            set => ngaySinh = value;
        }

        private string gioiTinh;
        public string GioiTinh
        {
            get => gioiTinh;
            set => gioiTinh = value;
        }

        private string diaChiChiTiet;
        public string DiaChiChiTiet
        {
            get => diaChiChiTiet;
            set => diaChiChiTiet = value;
        }

        private string tenDuong;
        public string TenDuong
        {
            get => tenDuong;
            set => tenDuong = value;
        }

        private string phuongXa;
        public string PhuongXa
        {
            get => phuongXa;
            set => phuongXa = value;
        }

        private string quanHuyen;
        public string QuanHuyen
        {
            get => quanHuyen;
            set => quanHuyen = value;
        }

        private string tinhThanhPho;
        public string TinhThanhPho
        {
            get => tinhThanhPho;
            set => tinhThanhPho = value;
        }

        private string soDienThoai;
        public string SoDienThoai
        {
            get => soDienThoai;
            set => soDienThoai = value;
        }

        private string email;
        public string Email
        {
            get => email;
            set => email = value;
        }

        private bool chucVu;
        public bool ChucVu
        {
            get => chucVu;
            set => chucVu = value;
        }

        private DateTime? ngayLamViec;
        public DateTime? NgayLamViec
        {
            get => ngayLamViec;
            set => ngayLamViec = value;
        }
    }

}
   

