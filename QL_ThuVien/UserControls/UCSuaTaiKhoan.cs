using QL_ThuVien.DAO;
using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TheArtOfDevHtmlRenderer.Adapters;

namespace QL_ThuVien.UserControls
{
    public partial class UCSuaTaiKhoan : UserControl
    {
        string maTaiKhoan;
        public UCSuaTaiKhoan(string maTaiKhoan)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
            LoadThongTinTaiKhoan();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UCTaiKhoan uc = new UCTaiKhoan();
            addUserControl(uc);
        }

        public void LoadThongTinTaiKhoan()
        {
            if (string.IsNullOrEmpty(maTaiKhoan) == false)
            {
                List<TaiKhoan_DTO> listTaiKhoan = TaiKhoan_DAO.Instance.LayThongTinTaiKhoanTheoMaTK(maTaiKhoan);
                foreach (TaiKhoan_DTO item in listTaiKhoan)
                {
                    txtMaNhanVien.Text = item.MaNhanVien;
                    txtTenDangNhap.Text = item.TenDangNhap;
                    txtMatKhau.Text = item.MatKhau;
                    dtpNgayTao.Value = ((DateTime)item.NgayTao);
                    cboTrangThai.Text = (item.TrangThai == true) ? "Hoạt động" : "Khóa";

                    List<NhanVien_DTO> listNhanVien = NhanVien_DAO.Instance.LayThongTinNhanVienTheoMaNV(item.MaNhanVien);
                    foreach(NhanVien_DTO item1 in listNhanVien)
                    {
                        txtTenNhanVien.Text = item1.HoTenNhanVien;
                    }    


                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            bool trangThai = true;
            if (cboTrangThai.SelectedIndex == 1)
                trangThai = false;
            string ngayTao = dtpNgayTao.Value.ToString();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TaiKhoan_DAO.Instance.SuaTaiKhoan(maTaiKhoan,tenDangNhap, matKhau, maNhanVien, trangThai))
            {
                MessageBox.Show(string.Format("Bạn đã sửa thành công tài khoản {0}",tenDangNhap), "Thông báo");

                UCTaiKhoan uc = new UCTaiKhoan();
                addUserControl(uc);
            }
            else
                MessageBox.Show("Sửa tài khoản thất bại");

        }
    }
}
