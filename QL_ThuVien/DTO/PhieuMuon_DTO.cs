using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class PhieuMuon_DTO
    {
        public PhieuMuon_DTO() { }
        public PhieuMuon_DTO(string maPhieuMuon, string maDocGia, string maNhanVien, DateTime? ngayMuon, DateTime? ngayHetHan)
        {
            this.MaPhieuMuon = maPhieuMuon;
            this.MaDocGia = maDocGia;
            this.MaNhanVien = maNhanVien;
            this.NgayMuon = ngayMuon;
            this.NgayHetHan = ngayHetHan;
        }
        public PhieuMuon_DTO(DataRow row)
        {
            this.MaPhieuMuon = row["maPhieuMuon"].ToString();
            this.MaDocGia = row["maDocGia"].ToString();
            this.MaNhanVien = row["maNhanVien"].ToString();
            this.NgayMuon = (DateTime?)row["ngayMuon"];
            this.NgayHetHan = (DateTime?)row["ngayHetHan"];
        }
        private string maPhieuMuon;
        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
        private string maDocGia;
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
        private string maNhanVien;
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        private DateTime? ngayMuon;
        public DateTime? NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        private DateTime? ngayHetHan;
        public DateTime? NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
    }
}
