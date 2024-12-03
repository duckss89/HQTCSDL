using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class PhieuTra_DTO
    {
        public PhieuTra_DTO(string maPhieuTra, string maPhieuMuon, string maNhanVien, DateTime? ngayTra, string trangThai)
        {
            this.MaPhieuTra = maPhieuTra;
            this.MaPhieuMuon = maPhieuMuon;
            this.MaNhanVien = maNhanVien;
            this.NgayTra = ngayTra;
            this.TrangThai = trangThai;
        }
        public PhieuTra_DTO(DataRow row)
        {
            this.MaPhieuTra = row["maPhieuTra"].ToString();
            this.MaPhieuMuon = row["maPhieuMuon"].ToString();
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.NgayTra = (DateTime?)row["ngayTra"];
            this.TrangThai = row["trangThai"].ToString();
        }
        private string maPhieuTra;
        public string MaPhieuTra { get => maPhieuTra; set => maPhieuTra = value; }
        private string maPhieuMuon;
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        private string maNhanVien;
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        private DateTime? ngayTra;
        public DateTime? NgayTra { get => ngayTra; set => ngayTra = value; }
        private string trangThai;
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
