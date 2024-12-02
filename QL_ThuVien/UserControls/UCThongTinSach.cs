using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_ThuVien.DAO;
using QL_ThuVien.DTO;


namespace QL_ThuVien.UserControls
{
    public partial class UCThongTinSach : UserControl
    {
        public UCThongTinSach()
        {
            InitializeComponent();
            loadThongTinSachList();
        }
        private string maSach;

        void loadThongTinSachList()
        {
            dtgvSach.DataSource = Sach_DAO.Instance.GetListSach();
            SetUpThongTinSachDataGridView();
            if (dtgvSach.Rows.Count > 0)
            {
                DataGridViewRow row = dtgvSach.Rows[0];

                lblTenSach.Text = row.Cells["tenSach"].Value.ToString();
                lblTacGia.Text = row.Cells["tenTacGia"].Value.ToString();
                lblISNB.Text = row.Cells["ISBN"].Value.ToString();
                lblNamXuatBan.Text = row.Cells["namXuatBan"].Value.ToString();
                lblTheLoai.Text = row.Cells["tenTheLoai"].Value.ToString();
                lblNXB.Text = row.Cells["tenNhaXuatBan"].Value.ToString();
                lblGiaBan.Text = row.Cells["giaBan"].Value.ToString();
                lblSoLuong.Text = row.Cells["soLuong"].Value.ToString();

                maSach = dtgvSach.Rows[0].Cells["maSach"].Value.ToString();
            }
        }

        void SetUpThongTinSachDataGridView()
        {
            dtgvSach.Columns["maSach"].HeaderText = "MÃ SÁCH";
            dtgvSach.Columns["tenSach"].HeaderText = "TÊN SÁCH";
            dtgvSach.Columns["biaSach"].HeaderText = "BÌA SÁCH";
            dtgvSach.Columns["ISBN"].HeaderText = "ISBN";
            dtgvSach.Columns["namXuatBan"].HeaderText = "NĂM XUẤT BẢN";
            dtgvSach.Columns["soLuong"].HeaderText = "SỐ LƯỢNG";
            dtgvSach.Columns["giaBan"].HeaderText = "GIÁ BÁN";
            dtgvSach.Columns["tenTheLoai"].HeaderText = "THỂ LOẠI";
            dtgvSach.Columns["tenTacGia"].HeaderText = "TÁC GIẢ";
            dtgvSach.Columns["tenNhaXuatBan"].HeaderText = "NHÀ XUẤT BẢN";
            dtgvSach.Columns["viTri"].HeaderText = "VỊ TRÍ";

            dtgvSach.AllowUserToAddRows = false;
            dtgvSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            dtgvSach.AutoResizeColumns();
            dtgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvSach.RowTemplate.Height = 40;
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            pnlAdd.BorderColor = Color.FromArgb(141,110,99);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            pnlAdd.BorderColor = Color.FromArgb(250, 243, 224);
        }

        private void btnRemove_MouseEnter(object sender, EventArgs e)
        {
            pnlRemove.BorderColor = Color.FromArgb(141, 110, 99);
        }

        private void btnRemove_MouseLeave(object sender, EventArgs e)
        {
            pnlRemove.BorderColor = Color.FromArgb(250, 243, 224);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên sách cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên sách cần tìm";
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

        void addControlDesktop()
        {
            this.pnlDesktop.Controls.Add(this.pnlTool);
            this.pnlDesktop.Controls.Add(this.pnlThongTinSach);
            this.pnlDesktop.Controls.Add(this.pnlDataGridView);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addControlDesktop();
            UCThemSach uc = new UCThemSach();
            addUserControl(uc);
        }

        private void dtgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvSach.Rows[e.RowIndex];

                lblTenSach.Text = row.Cells["tenSach"].Value.ToString();
                lblTacGia.Text = row.Cells["tenTacGia"].Value.ToString();
                lblISNB.Text = row.Cells["ISBN"].Value.ToString();
                lblNamXuatBan.Text = row.Cells["namXuatBan"].Value.ToString();
                lblTheLoai.Text = row.Cells["tenTheLoai"].Value.ToString();
                lblNXB.Text = row.Cells["tenNhaXuatBan"].Value.ToString();
                lblGiaBan.Text = row.Cells["giaBan"].Value.ToString();
                lblSoLuong.Text = row.Cells["soLuong"].Value.ToString();

                maSach = dtgvSach.Rows[0].Cells["maSach"].Value.ToString();
            }
        }

        void loadDanhSachNhanVienTheoTen(string tenSach)
        {
            dtgvSach.DataSource = Sach_DAO.Instance.GetListSachTheoTen(tenSach);
            SetUpThongTinSachDataGridView();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string tenSach = txtSearch.Text.Trim();
            loadDanhSachNhanVienTheoTen(tenSach);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (maSach == null)
                MessageBox.Show("Bạn chưa chọn sách", "Thông báo!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (Sach_DAO.Instance.XoaSach(maSach))
                    {
                        MessageBox.Show("Đã xóa thành công (1) sách!", "Thông báo");
                        loadThongTinSachList();
                    }
                    else
                        MessageBox.Show("Lỗi", "Thông báo");
                }
            }
        }
    }
}
