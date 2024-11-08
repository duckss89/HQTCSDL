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
    public partial class UCNhapSach : UserControl
    {
        public UCNhapSach()
        {
            InitializeComponent();
            LoadNhapSachList();
        }

        #region Method

        private string maNhapSach;

        void addControlDesktop()
        {
            this.pnlDesktop.Controls.Add(this.pnlTool);
            this.pnlDesktop.Controls.Add(this.pnlThongTinMuon);
            this.pnlDesktop.Controls.Add(this.pnlDataGridView);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }
        void LoadNhapSachList()
        {
            dgvNhapSach.DataSource = NhapSach_DAO.Instance.GetListNhapSach();
            SetUpNhapSachDataGridView();
        }

        List<NhapSach_DTO> TimKiemNhapSachTheoMaSach(string maNhapSach)
        {
            return NhapSach_DAO.Instance.TimKiemNhapSachTheoMaSach(maNhapSach);  // sửa lại gọi hàm mà không khai báo kiểu string ở đây
        }

        void TimKiemNhapSach(string maNhapSach)
        {
            dgvNhapSach.DataSource = TimKiemNhapSachTheoMaSach(maNhapSach); // gọi đúng phương thức
            SetUpNhapSachDataGridView();
        }

        void SetUpNhapSachDataGridView()
        {
            dgvNhapSach.Columns["maNhapSach"].HeaderText = "MÃ NHẬP SÁCH";
            dgvNhapSach.Columns["hoTenNhanVien"].HeaderText = "HỌ TÊN NHÂN VIÊN";
            dgvNhapSach.Columns["nguonNhap"].HeaderText = "NGUỒN NHẬP";
            dgvNhapSach.Columns["diaChiChiTiet"].HeaderText = "ĐỊA CHỈ CHI TIẾT";
            dgvNhapSach.Columns["soDienThoai"].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvNhapSach.Columns["email"].HeaderText = "EMAIL";
            dgvNhapSach.Columns["ngayNhap"].HeaderText = "NGÀY NHẬP";
            dgvNhapSach.Columns["tongTien"].HeaderText = "TỔNG TIỀN";

            dgvNhapSach.Columns["maNhanVien"].Visible = false;
            dgvNhapSach.Columns["tenDuong"].Visible = false;
            dgvNhapSach.Columns["quanHuyen"].Visible = false;
            dgvNhapSach.Columns["phuongXa"].Visible = false;
            dgvNhapSach.Columns["tinhThanhPho"].Visible = false;


            dgvNhapSach.Columns["ngayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvNhapSach.AllowUserToAddRows = false;
            dgvNhapSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhapSach.AutoResizeColumns();
            dgvNhapSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNhapSach.RowTemplate.Height = 40;
        }
        private void dgvNhapSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhapSach.Rows[e.RowIndex];

                // Lấy các thông tin từ dòng dữ liệu và gán cho các Label
                lblNguonNhap.Text = row.Cells["nguonNhap"].Value.ToString();
                lblTenNV.Text = row.Cells["hoTenNhanVien"].Value.ToString();
                lblNgayNhap.Text = row.Cells["ngayNhap"].Value.ToString();
                lblSDT.Text = row.Cells["soDienThoai"].Value.ToString();
                lblEmail.Text = row.Cells["email"].Value.ToString();
                lblDiaChiCT.Text = row.Cells["diaChiChiTiet"].Value.ToString();
                lblTongTien.Text = row.Cells["tongTien"].Value.ToString();
                // Lấy mã nhập sách để sử dụng sau này
                maNhapSach = dgvNhapSach.Rows[e.RowIndex].Cells["maNhapSach"].Value.ToString();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên mã sách cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên mã sách cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void ptrTimKiem_Click(object sender, EventArgs e)
        {
            string maNhapSach = txtSearch.Text.Trim();
            TimKiemNhapSach(maNhapSach);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemPhieuNhap uc = new UCThemPhieuNhap();
            addUserControl(uc);
        }

        #endregion
    }
}
