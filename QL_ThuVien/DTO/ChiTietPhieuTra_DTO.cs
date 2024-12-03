using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class ChiTietPhieuTra_DTO
    {
        public ChiTietPhieuTra_DTO(string maCtPhieuTra, string maPhieuTra, string maSach, decimal phiPhatSinh, string tinhTrangSach, string ghiChu)
        {
            this.MaCtPhieuTra = maCtPhieuTra;
            this.MaPhieuTra = maPhieuTra;
            this.MaSach = maSach;
            this.PhiPhatSinh = phiPhatSinh;
            this.TinhTrangSach = tinhTrangSach;
            this.GhiChu = ghiChu;
        }
        public ChiTietPhieuTra_DTO(DataRow row)
        {
            this.MaCtPhieuTra = row["maCtPhieuTra"].ToString();
            this.MaPhieuTra = row["maPhieuTra"].ToString();
            this.MaSach = row["maSach"].ToString();
            this.PhiPhatSinh = decimal.Parse(row["phiPhatSinh"].ToString());
            this.TinhTrangSach = row["tinhTrangSach"].ToString();
            this.GhiChu = row["ghiChu"].ToString();
        }
        private string maCtPhieuTra;
        public string MaCtPhieuTra { get => maCtPhieuTra; set => maCtPhieuTra = value; }
        private string maPhieuTra;
        public string MaPhieuTra { get => maPhieuTra; set => maPhieuTra = value; }
        private string maSach;
        public string MaSach { get => maSach; set => maSach = value; }
        private decimal phiPhatSinh;
        public decimal PhiPhatSinh { get => phiPhatSinh; set => phiPhatSinh = value; }
        private string tinhTrangSach;
        public string TinhTrangSach { get => tinhTrangSach; set => tinhTrangSach = value; }
        private string ghiChu;
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

    }
}
