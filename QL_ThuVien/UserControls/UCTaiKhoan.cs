using QL_ThuVien.DAO;
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

namespace QL_ThuVien.UserControls
{
    public partial class UCTaiKhoan : UserControl
    {
        public UCTaiKhoan()
        {
            InitializeComponent();
            loadDanhSachTaiKhoan();
        }

        private string maTaiKhoan;

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemTaiKhoan uc = new UCThemTaiKhoan();
            addUserControl(uc);
        }

        void loadDanhSachTaiKhoan()
        {
            dgvTaiKhoan.DataSource = TaiKhoan_DAO.Instance.GetListNhanVien();
            SetUpTaiKhoanDataGridView();
            if (dgvTaiKhoan.Rows.Count > 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[0];

                lblHoTen.Text = row.Cells["hoTenNhanVien"].Value.ToString();
                lblTenDangNhap.Text = row.Cells["tenDangNhap"].Value.ToString();
                lblMatKhau.Text = row.Cells["matKhau"].Value.ToString();
                lblTrangThai.Text = row.Cells["trangThai"].Value.ToString();
                lblNgayTao.Text = row.Cells["ngayTao"].Value.ToString();

                maTaiKhoan = dgvTaiKhoan.Rows[0].Cells["maTaiKhoan"].Value.ToString();
            }
        }

        void loadDanhSachTaiKhoanTheoTen(string tenNhanVien)
        {
            dgvTaiKhoan.DataSource = TaiKhoan_DAO.Instance.GetListTaiKhoanTheoTenNhanVien(tenNhanVien);
            SetUpTaiKhoanDataGridView();
        }

        void SetUpTaiKhoanDataGridView()
        {
            dgvTaiKhoan.Columns["tenDangNhap"].HeaderText = "TÊN ĐĂNG NHẬP";
            dgvTaiKhoan.Columns["matKhau"].HeaderText = "MẬT KHẨU";
            dgvTaiKhoan.Columns["hoTenNhanVien"].HeaderText = "NHÂN VIÊN";
            dgvTaiKhoan.Columns["trangThai"].HeaderText = "TRẠNG THÁI";
            dgvTaiKhoan.Columns["ngayTao"].HeaderText = "NGÀY TẠO";

            dgvTaiKhoan.Columns["maTaiKhoan"].Visible = false;

            dgvTaiKhoan.Columns["ngayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
            //dgvXuatSach.AutoResizeColumns();
            //dgvXuatSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTaiKhoan.RowTemplate.Height = 40;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên nhân viên cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên nhân viên cần tìm";
                txtSearch.ForeColor = System.Drawing.Color.FromArgb(125, 137, 149);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                lblHoTen.Text = row.Cells["hoTenNhanVien"].Value.ToString();
                lblTenDangNhap.Text = row.Cells["tenDangNhap"].Value.ToString();
                lblMatKhau.Text = row.Cells["matKhau"].Value.ToString();
                lblTrangThai.Text = row.Cells["trangThai"].Value.ToString();
                lblNgayTao.Text = row.Cells["ngayTao"].Value.ToString();

                maTaiKhoan = dgvTaiKhoan.Rows[e.RowIndex].Cells["maTaiKhoan"].Value.ToString();
            }
        }

        private void ptrTimKiem_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtSearch.Text.Trim();
            loadDanhSachTaiKhoanTheoTen(tenNhanVien);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (maTaiKhoan == null)
                MessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (TaiKhoan_DAO.Instance.XoaTaiKhoan(maTaiKhoan))
                    {
                        MessageBox.Show(string.Format("Xóa thành công tài khoản {0}", maTaiKhoan), "Thông báo");
                        loadDanhSachTaiKhoan();
                    }
                    else
                        MessageBox.Show("Lỗi", "Thông báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UCSuaTaiKhoan uc = new UCSuaTaiKhoan(maTaiKhoan);
            addUserControl(uc);
        }
    }
}
