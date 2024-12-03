using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class ChiTietPhieuMuon_DTO
    {
        public ChiTietPhieuMuon_DTO(string maCtPhieuMuon, string maPhieuMuon, string maSach, int soLuong, string tinhTrangSach, string ghiChu)
        {
            this.MaCtPhieuMuon = maCtPhieuMuon;
            this.MaPhieuMuon = maPhieuMuon;
            this.MaSach = maSach;
            this.SoLuong = soLuong;
            this.TinhTrangSach = tinhTrangSach;
            this.GhiChu = ghiChu;
        }
        public ChiTietPhieuMuon_DTO(DataRow row)
        {
            this.MaCtPhieuMuon = row["maCtPhieuMuon"].ToString();
            this.MaPhieuMuon = row["maPhieuMuon"].ToString();
            this.MaSach = row["maSach"].ToString();
            this.SoLuong = Int32.Parse(row["soLuong"].ToString());
            this.TinhTrangSach = row["tinhTrangSach"].ToString();
            this.GhiChu = row["ghiChu"].ToString();
        }

        public ChiTietPhieuMuon_DTO()
        {
        }

        private string maCtPhieuMuon;
        public string MaCtPhieuMuon { get => maCtPhieuMuon; set => maCtPhieuMuon = value; }
        private string maPhieuMuon;
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        private string maSach;
        public string MaSach { get => maSach; set => maSach = value; }
        private int soLuong;
        public int SoLuong { get => soLuong; set => soLuong = value; }
        private string tinhTrangSach;
        public string TinhTrangSach { get => tinhTrangSach; set => tinhTrangSach = value; }
        private string ghiChu;
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

    }
}
