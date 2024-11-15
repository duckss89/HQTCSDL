using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class TaiKhoan_DTO
    {
        public TaiKhoan_DTO(string maTaiKhoan, string tenDangNhap, string matKhau, string maNhanVien, bool trangThai, DateTime ngayTao)
        {
            this.MaTaiKhoan = maTaiKhoan;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.MaNhanVien = maNhanVien;
            this.TrangThai = trangThai;
            this.NgayTao = ngayTao;
        }

        public TaiKhoan_DTO(DataRow row)
        {
            this.MaTaiKhoan = row["maTaiKhoan"].ToString();
            this.TenDangNhap = row["tenDangNhap"].ToString();
            this.MatKhau = row["matKhau"].ToString();
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.TrangThai = (bool)row["trangThai"];
            this.NgayTao = (DateTime)row["ngayTao"];
        }

        private string maTaiKhoan;
        public string MaTaiKhoan
        {
            get => maTaiKhoan;
            set => maTaiKhoan = value;
        }

        private string tenDangNhap;
        public string TenDangNhap
        {
            get => tenDangNhap;
            set => tenDangNhap = value;
        }

        private string matKhau;
        public string MatKhau
        {
            get => matKhau;
            set => matKhau = value;
        }

        private string maNhanVien;
        public string MaNhanVien
        {
            get => maNhanVien;
            set => maNhanVien = value;
        }

        private bool trangThai;
        public bool TrangThai
        {
            get => trangThai;
            set => trangThai = value;
        }

        private DateTime ngayTao;
        public DateTime NgayTao
        {
            get => ngayTao;
            set => ngayTao = value;
        }
    }

}
