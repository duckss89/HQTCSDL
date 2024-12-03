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

namespace QL_ThuVien.UserControls
{
    public partial class UCMuonSach : UserControl
    {
        public UCMuonSach()
        {
            InitializeComponent();
            loadPhieuMuonList();
        }
        #region Method

        private string maPhieuMuon;

        void loadPhieuMuonList()
        {
            dgvMuonSach.DataSource = PhieuMuon_DAO.Instance.GetListPhieuMuon();
            SetUpPhieuMuonDataGridView();
        }
        void addControlDesktop()
        {
            this.pnlDesktop.Controls.Add(this.pnlTool);
            this.pnlDesktop.Controls.Add(this.pnlThongTinMuon);
            this.pnlDesktop.Controls.Add(this.pnllDataGridView);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }
        void SetUpPhieuMuonDataGridView()
        {
            if (dgvMuonSach.Columns.Contains("maPhieuMuon"))
            {
                dgvMuonSach.Columns["maPhieuMuon"].HeaderText = "MÃ PHIẾU MƯỢN";
                dgvMuonSach.Columns["maPhieuMuon"].Visible = true; // Hiển thị cột này
            }
            if (dgvMuonSach.Columns.Contains("maDocGia"))
            {
                dgvMuonSach.Columns["maDocGia"].HeaderText = "MÃ ĐỌC GIẢ";
                dgvMuonSach.Columns["maDocGia"].Visible = true;
            }
            if (dgvMuonSach.Columns.Contains("maNhanVien"))
            {
                dgvMuonSach.Columns["maNhanVien"].HeaderText = "NHÂN VIÊN CHO MƯỢN";
                dgvMuonSach.Columns["maNhanVien"].Visible = true;
            }
            if (dgvMuonSach.Columns.Contains("ngayMuon"))
            {
                dgvMuonSach.Columns["ngayMuon"].HeaderText = "NGÀY MƯỢN";
                dgvMuonSach.Columns["ngayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvMuonSach.Columns.Contains("ngayHetHan"))
            {
                dgvMuonSach.Columns["ngayHetHan"].HeaderText = "NGÀY HẾT HẠN";
                dgvMuonSach.Columns["ngayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            dgvMuonSach.AllowUserToAddRows = false;
            dgvMuonSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMuonSach.AutoResizeColumns();
            dgvMuonSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMuonSach.RowTemplate.Height = 40;
        }

        //hiển thị chi tiết phiếu mượn trong lsvChiTietMuon
        private void LoadChiTietPhieuMuon(string maPhieuMuon)
        {
            lsvChiTietMuon.Items.Clear();
            DataTable chiTietPhieuMuon = ChiTietPhieuMuon_DAO.Instance.GetChiTietPM(maPhieuMuon);

            foreach (DataRow row in chiTietPhieuMuon.Rows)
            {
                ListViewItem item = new ListViewItem(row["tenSach"].ToString());
                item.SubItems.Add(row["soLuong"].ToString());
                item.SubItems.Add(row["tinhTrangSach"].ToString());
                item.SubItems.Add(row["ghiChu"].ToString());

                lsvChiTietMuon.Items.Add(item);
            }
        }

        #endregion

        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemPhieuMuon uc = new UCThemPhieuMuon();
            addUserControl(uc);
        }

        private void dgvMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMuonSach.Rows[e.RowIndex];
                var query = PhieuMuon_DAO.Instance.GetInfoPhieuMuon(row.Cells["maPhieuMuon"].Value.ToString());
                lblTenDocGia.Text = query.Rows[0]["hoTenDocGia"].ToString();
                lblEmail.Text = query.Rows[0]["hoTenNhanVien"].ToString();
                lblNgayLamViec.Text = query.Rows[0]["ngayMuon"].ToString().Substring(0, 10);
                label3.Text = query.Rows[0]["ngayHetHan"].ToString().Substring(0, 10);

                maPhieuMuon = dgvMuonSach.Rows[e.RowIndex].Cells["maPhieuMuon"].Value.ToString();
                // Load thông tin chi tiết vào ListView
                LoadChiTietPhieuMuon(maPhieuMuon);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (maPhieuMuon == null)
                MessageBox.Show("Bạn chưa chọn phiếu mượn", "Thông báo!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu mượn này?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        PhieuMuon_DAO.Instance.XoaPhieuMuon(maPhieuMuon);
                        MessageBox.Show("Đã xóa thành công (1) phiếu mượn", "Thông báo");
                        loadPhieuMuonList();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi", "Thông báo");
                    }
                }
            }
        }
        private void loadPhieuMuonList(string searchText, string searchType)
        {
            dgvMuonSach.DataSource = PhieuMuon_DAO.Instance.GetListPhieuMuonTK(searchText, searchType);
            SetUpPhieuMuonDataGridView();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearch.Text.Trim();
                string searchType = string.Empty;
                if (guna2RadioButton1.Checked)
                    searchType = "TenSach";
                else if (guna2RadioButton2.Checked)
                    searchType = "TenDocGia";

                loadPhieuMuonList(searchText, searchType);
            }
        }
        #endregion
    }
}
