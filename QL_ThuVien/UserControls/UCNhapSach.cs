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
            LoadDuLieuNhapSach();
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
        void LoadDuLieuNhapSach()
        {
            dgvNhapSach.DataSource = NhapSach_DAO.Instance.GetListNhapSach();
            SetUpNhapSachDataGridView();
            if (dgvNhapSach.Rows.Count > 0)
            {
                DataGridViewRow row = dgvNhapSach.Rows[0];

                lblNguonNhap.Text = row.Cells["nguonNhap"].Value.ToString();
                lblTenNV.Text = row.Cells["tenNhanVien"].Value.ToString();
                lblNgayNhap.Text = row.Cells["ngayNhap"].Value.ToString();
                lblSDT.Text = row.Cells["soDienThoai"].Value.ToString();
                lblEmail.Text = row.Cells["email"].Value.ToString();
                lblDiaChiCT.Text = row.Cells["diaChiChiTiet"].Value.ToString();
                lblTongTien.Text = row.Cells["tongTien"].Value.ToString() + " VND";

                maNhapSach = dgvNhapSach.Rows[0].Cells["maNhapSach"].Value.ToString();

                HienThiChiTietNhapSach(maNhapSach);
            }
        }

        void LoadDuLieuNhapSachTheoMa(string maNhapSach)
        {
            dgvNhapSach.DataSource = NhapSach_DAO.Instance.GetListNhapSachTheoMaSach(maNhapSach);
            SetUpNhapSachDataGridView();

        }

        void SetUpNhapSachDataGridView()
        {
                dgvNhapSach.Columns["maNhapSach"].HeaderText = "MÃ NHẬP SÁCH";
                dgvNhapSach.Columns["tenNhanVien"].HeaderText = "NHÂN VIÊN NHẬP";
                dgvNhapSach.Columns["nguonNhap"].HeaderText = "NGUỒN NHẬP";
                dgvNhapSach.Columns["diaChiChiTiet"].HeaderText = "ĐỊA CHỈ CHI TIẾT";
                dgvNhapSach.Columns["soDienThoai"].HeaderText = "SỐ ĐIỆN THOẠI";
                dgvNhapSach.Columns["email"].HeaderText = "EMAIL";
                dgvNhapSach.Columns["ngayNhap"].HeaderText = "NGÀY NHẬP";
                dgvNhapSach.Columns["tongTien"].HeaderText = "TỔNG TIỀN";

                dgvNhapSach.Columns["ngayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvNhapSach.AllowUserToAddRows = false;
                dgvNhapSach.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvNhapSach.AutoResizeColumns();
                dgvNhapSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvNhapSach.RowTemplate.Height = 40;

        }

        private void HienThiChiTietNhapSach(string maNhapSach)
        {
            lsvChiTietNhap.Items.Clear();

            ChiTietNhapSach_DAO dao = new ChiTietNhapSach_DAO();
            DataTable dt = dao.GetListCtNhapSachTheoMaSach(maNhapSach);

            foreach (DataRow row in dt.Rows)
            {
                string tenSach = row["tenSach"].ToString();
                string soLuongNhap = row["soLuongNhap"].ToString();
                string giaNhap = row["giaNhap"].ToString();

                ListViewItem item = new ListViewItem(tenSach);
                item.SubItems.Add(soLuongNhap);
                item.SubItems.Add(giaNhap);

                lsvChiTietNhap.Items.Add(item);
            }

            lsvChiTietNhap.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvChiTietNhap.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        #endregion

        #region Event

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemPhieuNhap uc = new UCThemPhieuNhap();
            addUserControl(uc);
        }

        private void dgvNhapSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhapSach.Rows[e.RowIndex];

                lblNguonNhap.Text = row.Cells["nguonNhap"].Value.ToString();
                lblTenNV.Text = row.Cells["tenNhanVien"].Value.ToString();
                lblNgayNhap.Text = row.Cells["ngayNhap"].Value.ToString();
                lblSDT.Text = row.Cells["soDienThoai"].Value.ToString();
                lblEmail.Text = row.Cells["email"].Value.ToString();
                lblDiaChiCT.Text = row.Cells["diaChiChiTiet"].Value.ToString();
                lblTongTien.Text = row.Cells["tongTien"].Value.ToString() + " VND";

                maNhapSach = dgvNhapSach.Rows[e.RowIndex].Cells["maNhapSach"].Value.ToString();

                HienThiChiTietNhapSach(maNhapSach);
            }
        }

        private void ptrTimKiem_Click(object sender, EventArgs e)
        {
            string maNhapSach = txtSearch.Text.Trim();
            LoadDuLieuNhapSachTheoMa(maNhapSach);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNhapSach))
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UCSuaDocGia uc = new UCSuaDocGia(maNhapSach);
            addUserControl(uc);
        }

        private void txtSearch_Enter_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã phiếu nhập cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập mã phiếu nhập cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (maNhapSach == null)
                MessageBox.Show("Bạn chưa chọn phiếu nhập", "Thông báo!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (NhapSach_DAO.Instance.XoaNhapSach(maNhapSach))
                    {
                        MessageBox.Show("Đã xóa thành công (1) phiếu nhập", "Thông báo");
                        LoadDuLieuNhapSach();
                    }
                    else
                        MessageBox.Show("Lỗi", "Thông báo");
                }
            }
        }
        #endregion
    }
}
