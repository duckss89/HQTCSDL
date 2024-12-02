using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DTO
{
    public class NhaXuatBan_DTO
    {
        public NhaXuatBan_DTO(string maNhaXuatBan, string tenNhaXuatBan, string diaChiChiTiet, string tenDuong, string phuongXa, string quanHuyen, string tinhThanhPho)
        {
            this.MaNhaXuatBan = maNhaXuatBan;
            this.TenNhaXuatBan = tenNhaXuatBan;
            this.DiaChiChiTiet = diaChiChiTiet;
            this.TenDuong = tenDuong;
            this.PhuongXa = phuongXa;
            this.QuanHuyen = quanHuyen;
            this.TinhThanhPho = tinhThanhPho;
        }

        public NhaXuatBan_DTO(DataRow row)
        {
            this.MaNhaXuatBan = row["maNhaXuatBan"].ToString();
            this.TenNhaXuatBan = row["tenNhaXuatBan"].ToString();
            this.DiaChiChiTiet = row["diaChiChiTiet"].ToString();
            this.TenDuong = row["tenDuong"].ToString();
            this.PhuongXa = row["phuongXa"].ToString();
            this.QuanHuyen = row["quanHuyen"].ToString();
            this.TinhThanhPho = row["tinhThanhPho"].ToString();
        }

        public string maNhaXuatBan;
        public string MaNhaXuatBan
        {
            get { return maNhaXuatBan; }
            set { maNhaXuatBan = value; }
        }

        public string tenNhaXuatBan;
        public string TenNhaXuatBan
        {
            get { return tenNhaXuatBan; }
            set { tenNhaXuatBan = value; }
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
    }
}
