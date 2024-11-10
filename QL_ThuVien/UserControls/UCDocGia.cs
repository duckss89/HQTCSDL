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
    public partial class UCDocGia : UserControl
    {
        public UCDocGia()
        {
            InitializeComponent();
            loadDocGiaList();
        }

        #region Method

        private string maDocGia;

        void addControlDesktop()
        {
            this.pnlDesktop.Controls.Add(this.pnlTool);
            this.pnlDesktop.Controls.Add(this.pnlThongTinDocGia);
            this.pnlDesktop.Controls.Add(this.pnlDataGridView);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        void loadDocGiaList()
        {
            dgvDocGia.DataSource = DocGia_DAO.Instance.GetListDocGia();
            SetUpDocGiaDataGridView();
            if (dgvDocGia.Rows.Count > 0)
            {
                DataGridViewRow row = dgvDocGia.Rows[0];

                lblTenDocGia.Text = row.Cells["hoTen"].Value.ToString();
                lblNgaySinh.Text = row.Cells["ngaySinh"].Value.ToString();
                lblGioiTinh.Text = row.Cells["gioiTinh"].Value.ToString();
                lblDiaChi.Text = row.Cells["diaChiChiTiet"].Value.ToString();
                lblSoDienThoai.Text = row.Cells["soDienThoai"].Value.ToString();
                lblEmail.Text = row.Cells["email"].Value.ToString();
                lblNgayDangKy.Text = row.Cells["ngayDangKy"].Value.ToString();

                maDocGia = dgvDocGia.Rows[0].Cells["maDocGia"].Value.ToString();
            }
        }

        List<DocGia_DTO> TimKiemDocGiaTheoTen(string tenDocGia)
        {
            return DocGia_DAO.Instance.TimKiemDocGiaTheoTen(tenDocGia);
        }

        void TimKiemDocGia(string tenDocGia)
        {
            dgvDocGia.DataSource = TimKiemDocGiaTheoTen(tenDocGia);
            SetUpDocGiaDataGridView();
        }

        void SetUpDocGiaDataGridView()
        {
            dgvDocGia.Columns["maDocGia"].HeaderText = "MÃ ĐỌC GIẢ";
            dgvDocGia.Columns["hoTen"].HeaderText = "HỌ VÀ TÊN";
            dgvDocGia.Columns["ngaySinh"].HeaderText = "NGÀY SINH";
            dgvDocGia.Columns["gioiTinh"].HeaderText = "GIỚI TÍNH";
            dgvDocGia.Columns["diaChiChiTiet"].HeaderText = "ĐỊA CHỈ";
            dgvDocGia.Columns["soDienThoai"].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvDocGia.Columns["email"].HeaderText = "EMAIL";
            dgvDocGia.Columns["ngayDangKy"].HeaderText = "NGÀY ĐĂNG KÝ";

            dgvDocGia.Columns["ho"].Visible = false;
            dgvDocGia.Columns["hoLot"].Visible = false;
            dgvDocGia.Columns["ten"].Visible = false;
            dgvDocGia.Columns["tenDuong"].Visible = false;
            dgvDocGia.Columns["quanHuyen"].Visible = false;
            dgvDocGia.Columns["phuongXa"].Visible = false;
            dgvDocGia.Columns["tinhThanhPho"].Visible = false;

            dgvDocGia.Columns["ngaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDocGia.Columns["ngayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvDocGia.AllowUserToAddRows = false;
            dgvDocGia.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDocGia.AutoResizeColumns();
            dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDocGia.RowTemplate.Height = 40;
        }
        #endregion

        #region Event

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên đọc giả cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập tên đọc giả cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            addControlDesktop();
            UCThemDocGia uc = new UCThemDocGia();
            addUserControl(uc);
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                lblTenDocGia.Text = row.Cells["hoTen"].Value.ToString();
                lblNgaySinh.Text = row.Cells["ngaySinh"].Value.ToString();
                lblGioiTinh.Text = row.Cells["gioiTinh"].Value.ToString();
                lblDiaChi.Text = row.Cells["diaChiChiTiet"].Value.ToString();
                lblSoDienThoai.Text = row.Cells["soDienThoai"].Value.ToString();
                lblEmail.Text = row.Cells["email"].Value.ToString();
                lblNgayDangKy.Text = row.Cells["ngayDangKy"].Value.ToString();

                maDocGia = dgvDocGia.Rows[e.RowIndex].Cells["maDocGia"].Value.ToString();
            }
        }


        private void ptrTimKiem_Click(object sender, EventArgs e)
        {
            string tenDocGia = txtSearch.Text.Trim();
            TimKiemDocGia(tenDocGia);
        }
       

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (maDocGia == null)
                MessageBox.Show("Bạn chưa chọn đọc giả", "Thông báo!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đọc giả này?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (DocGia_DAO.Instance.XoaDocGia(maDocGia))
                    {
                        MessageBox.Show("Đã xóa thành công (1) đọc giả!", "Thông báo");
                        loadDocGiaList();
                    }
                    else
                        MessageBox.Show("Lỗi", "Thông báo");
                }
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDocGia))
            {
                MessageBox.Show("Vui lòng chọn độc giả để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UCSuaDocGia uc = new UCSuaDocGia(maDocGia);
            addUserControl(uc);
        }
        #endregion


    }
}
