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

namespace QL_ThuVien.UserControls
{
    public partial class UCNhanVien : UserControl
    {
        public UCNhanVien()
        {
            InitializeComponent();
            loadNhanVienList();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên nhân viên cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên nhân viên cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemNhanVien uc = new UCThemNhanVien();
            addUserControl(uc);
        }
        void loadNhanVienList()
        {
            dgvNhanVien.DataSource = NhanVien_DAO.Instance.GetListNhanVien();
            SetUPNhanVienDataGridView();
        }
        void SetUPNhanVienDataGridView()
        {

            dgvNhanVien.Columns["maNhanVien"].HeaderText = "MÃ NHÂN VIÊN ";
            dgvNhanVien.Columns["hoTenNhanVien"].HeaderText = "HỌ VÀ TÊN ";
            dgvNhanVien.Columns["ngaySinh"].HeaderText = "NGÀY SINH";
            dgvNhanVien.Columns["gioiTinh"].HeaderText = "GIỚI TÍNH";
            dgvNhanVien.Columns["diaChiChiTiet"].HeaderText = "ĐỊA CHỈ";
            dgvNhanVien.Columns["soDienThoai"].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvNhanVien.Columns["email"].HeaderText = "EMAIL";
            dgvNhanVien.Columns["chucVu"].HeaderText = "CHỨC VỤ ";
            dgvNhanVien.Columns["ngayLamViec"].HeaderText = " NGÀY LÀM VIỆC  ";

            dgvNhanVien.Columns["ngaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["ngayLamViec"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanVien.AutoResizeColumns();
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNhanVien.RowTemplate.Height = 40;
        }

        
            
        List<NhanVien_DTO> TimKiemNhanVienTheoTen(string tenNhanVien)
        {
            return NhanVien_DAO.Instance.TimKiemNhanVienTheoTen(tenNhanVien);
        }

        void TimKiemNhanVien(string tenNhanVien)
        {
            dgvNhanVien.DataSource = TimKiemNhanVienTheoTen(tenNhanVien);
            SetUPNhanVienDataGridView();
        }

        private void ptrTimKiem_Click(object sender, EventArgs e)
        {
            string tenNhanVien = txtSearch.Text.Trim();
            TimKiemNhanVien(tenNhanVien);
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                lblChucVu.Text = row.Cells["chucVu"].Value.ToString();
                lblDiaChi.Text = row.Cells["diachiChiTiet"].Value.ToString();
                lblEmail.Text = row.Cells["email"].Value.ToString();
                lblGioiTinh.Text = row.Cells["gioiTinh"].Value.ToString();
                lblHoTen.Text = row.Cells["hoTenNhanVien"].Value.ToString();
                lblNgayLamViec.Text = row.Cells["ngayLamViec"].Value.ToString();
                lblNgaySinh.Text = row.Cells["ngaySinh"].Value.ToString();
                lblSoDienThoai.Text = row.Cells["soDienThoai"].Value.ToString();

            }
        }
    }
    }

