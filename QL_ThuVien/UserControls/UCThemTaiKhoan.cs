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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Media;

namespace QL_ThuVien.UserControls
{
    public partial class UCThemTaiKhoan : UserControl
    {
        public UCThemTaiKhoan()
        {
            InitializeComponent();
            dtpNgayTao.Value = DateTime.Now;
            loadNhanVien();
            cboTrangThai.SelectedIndex = 0;
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

        void loadNhanVien()
        {
            NhanVien_DAO nhanVien = new NhanVien_DAO();
            List<NhanVien_DTO> listNhanVien = nhanVien.GetNhanVien();

            cboNhanVien.SelectedIndexChanged -= cboNhanVien_SelectedIndexChanged;

            cboNhanVien.Items.Clear();
            cboNhanVien.DataSource = listNhanVien;
            cboNhanVien.DisplayMember = "HoTenNhanVien";
            cboNhanVien.ValueMember = "MaNhanVien";

            cboNhanVien.SelectedIndex = -1;

            cboNhanVien.SelectedIndexChanged += cboNhanVien_SelectedIndexChanged;
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNhanVien = null;

            if (cboNhanVien.SelectedItem != null)
            {
                NhanVien_DTO selectedNhanVien = (NhanVien_DTO)cboNhanVien.SelectedItem;

                maNhanVien = selectedNhanVien.MaNhanVien;
                txtMaNhanVien.Text = maNhanVien;
            }

            if (TaiKhoan_DAO.Instance.KiemTraTaiKhoan(maNhanVien))
            {
                MessageBox.Show("Nhân viên đã có tài khoản!", "Thông báo");
                txtMaNhanVien.Clear();
                cboNhanVien.ResetText();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            bool trangThai = true;
            if(cboTrangThai.SelectedIndex == 1)
                trangThai=false;
            string ngayTao = dtpNgayTao.Value.ToString();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Parse(ngayTao) > DateTime.Now)
            {
                MessageBox.Show("Ngày tạo không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TaiKhoan_DAO.Instance.ThemTaiKhoan(tenDangNhap, matKhau, maNhanVien, trangThai, ngayTao))
            {
                MessageBox.Show("Tạo tài khoản thành công");

                txtMaNhanVien.Clear();
                txtTenDangNhap.Clear();
                txtMatKhau.Clear();
                cboTrangThai.SelectedIndex = 0;
                dtpNgayTao.Value = DateTime.Now;
                cboNhanVien.SelectedIndex = -1;

            }
            else
                MessageBox.Show("Tạo tài khoản thất bại");

        }

        private void btnResetText_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboTrangThai.SelectedIndex = 0;
            dtpNgayTao.Value = DateTime.Now;
            cboNhanVien.SelectedIndex = -1;
        }
    }
}
