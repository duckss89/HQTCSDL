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
    public partial class UCTraSach : UserControl
    {
        public UCTraSach()
        {
            InitializeComponent();
            loadPhieuTraList();
        }
        #region Method

        private string maPhieuTra;
        void loadPhieuTraList()
        {
            DataTable data = PhieuTra_DAO.Instance.GetListPhieuTra();
            dgvTraSach.DataSource = data;
            SetUpPhieuTraDataGridView();
        }

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
        void SetUpPhieuTraDataGridView()
        {
            dgvTraSach.Columns.Clear(); // Xóa các cột cũ để tránh trùng lặp

            dgvTraSach.Columns.Add("maPhieuTra", "MÃ PHIẾU TRẢ");
            dgvTraSach.Columns["maPhieuTra"].DataPropertyName = "maPhieuTra";

            dgvTraSach.Columns.Add("maPhieuMuon", "MÃ PHIẾU MƯỢN");
            dgvTraSach.Columns["maPhieuMuon"].DataPropertyName = "maPhieuMuon";

            dgvTraSach.Columns.Add("maNhanVien", "NHÂN VIÊN CHO MƯỢN");
            dgvTraSach.Columns["maNhanVien"].DataPropertyName = "maNhanVien";

            dgvTraSach.Columns.Add("ngayTra", "NGÀY TRẢ");
            dgvTraSach.Columns["ngayTra"].DataPropertyName = "ngayTra";
            dgvTraSach.Columns["ngayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvTraSach.Columns.Add("trangThai", "TRẠNG THÁI");
            dgvTraSach.Columns["trangThai"].DataPropertyName = "trangThai";

            dgvTraSach.AllowUserToAddRows = false;
            dgvTraSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTraSach.AutoResizeColumns();
            dgvTraSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTraSach.RowTemplate.Height = 40;
        }



        //hiển thị chi tiết phiếu mượn trong lsvChiTietTra
        private void LoadChiTietPhieuTra(string maPhieuTra)
        {
            lsvChiTietMuon.Items.Clear();
            DataTable chiTietPhieuTra = ChiTietPhieuTra_DAO.Instance.GetChiTietPT(maPhieuTra);

            foreach (DataRow row in chiTietPhieuTra.Rows)
            {
                ListViewItem item = new ListViewItem(row["tenSach"].ToString());
                item.SubItems.Add(row["phiPhatSinh"].ToString());
                item.SubItems.Add(row["tinhTrangSach"].ToString());
                item.SubItems.Add(row["ghiChu"].ToString());

                lsvChiTietMuon.Items.Add(item);
            }
        }


        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemPhieuTra uc = new UCThemPhieuTra();
            addUserControl(uc);
        }

        private void dgvTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTraSach.Rows[e.RowIndex];
                var query = PhieuTra_DAO.Instance.GetInfoPhieuTra(row.Cells["maPhieuTra"].Value.ToString());
                lblTenDocGia.Text = query.Rows[0]["hoTenDocGia"].ToString();
                lblEmail.Text = query.Rows[0]["hoTenNhanVien"].ToString();
                lblNgayLamViec.Text = query.Rows[0]["ngayTra"].ToString().Substring(0, 10);
                label3.Text = query.Rows[0]["trangThai"].ToString();

                maPhieuTra = dgvTraSach.Rows[e.RowIndex].Cells["maPhieuTra"].Value.ToString();
                // Load thông tin chi tiết vào ListView
                LoadChiTietPhieuTra(maPhieuTra);
            }
        }
        private void loadPhieuTraList(string searchText, string searchType)
        {
            dgvTraSach.DataSource = PhieuTra_DAO.Instance.GetListPhieuTraTK(searchText, searchType);
            SetUpPhieuTraDataGridView();
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

                loadPhieuTraList(searchText, searchType);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (maPhieuTra == null)
                MessageBox.Show("Bạn chưa chọn phiếu trả", "Thông báo!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu trả này?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        PhieuTra_DAO.Instance.XoaPhieuTra(maPhieuTra);
                        MessageBox.Show("Đã xóa thành công (1) phiếu trả", "Thông báo");
                        loadPhieuTraList();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi", "Thông báo");
                    }
                }
            }
        }

        #endregion
    }
}
