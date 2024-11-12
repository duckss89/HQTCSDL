using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class Sach_DTO
    {
        public Sach_DTO(string maSach, string tenSach, string biaSach, string ISBN, int namXuatBan, int soLuong, decimal giaBan, string maTheLoai, string maTacGia, string maNhaXuatBan, string viTri)
        {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.BiaSach = biaSach;
            this.ISBN = ISBN;
            this.NamXuatBan = namXuatBan;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
            this.MaTheLoai = maTheLoai;
            this.MaTacGia = maTacGia;
            this.MaNhaXuatBan = maNhaXuatBan;
            this.ViTri = viTri;
        }

        public Sach_DTO(DataRow row)
        {
            this.MaSach = row["maSach"].ToString();
            this.TenSach = row["tenSach"].ToString();
            this.BiaSach = row["biaSach"].ToString();
            this.ISBN = row["ISBN"].ToString();
            this.NamXuatBan = (int)row["namXuatBan"];
            this.SoLuong = (int)row["soLuong"];
            this.GiaBan = (decimal)row["giaBan"];
            this.MaTheLoai = row["maTheLoai"].ToString();
            this.MaTacGia = row["maTacGia"].ToString();
            this.MaNhaXuatBan = row["maNhaXuatBan"].ToString();
            this.ViTri = row["viTri"].ToString();
        }

        private string maSach;
        public string MaSach
        {
            get => maSach;
            set => maSach = value;
        }

        private string tenSach;
        public string TenSach
        {
            get => tenSach;
            set => tenSach = value;
        }

        private string biaSach;
        public string BiaSach
        {
            get => biaSach;
            set => biaSach = value;
        }

        private string ISBN;
        public string iSBN
        {
            get => ISBN;
            set => ISBN = value;
        }

        private int namXuatBan;
        public int NamXuatBan
        {
            get => namXuatBan;
            set => namXuatBan = value;
        }

        private int soLuong;
        public int SoLuong
        {
            get => soLuong;
            set => soLuong = value;
        }

        private decimal giaBan;
        public decimal GiaBan
        {
            get => giaBan;
            set => giaBan = value;
        }

        private string maTheLoai;
        public string MaTheLoai
        {
            get => maTheLoai;
            set => maTheLoai = value;
        }

        private string maTacGia;
        public string MaTacGia
        {
            get => maTacGia;
            set => maTacGia = value;
        }

        private string maNhaXuatBan;
        public string MaNhaXuatBan
        {
            get => maNhaXuatBan;
            set => maNhaXuatBan = value;
        }

        private string viTri;
        public string ViTri
        {
            get => viTri;
            set => viTri = value;
        }
    }

}
