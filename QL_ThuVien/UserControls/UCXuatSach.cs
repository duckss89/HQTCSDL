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
    public partial class UCXuatSach : UserControl
    {
        public UCXuatSach()
        {
            InitializeComponent();
            loadXuatSachList();
        }

        #region Method

        private string maXuatSach;

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        void addControlDesktopXuatSach()
        {
            this.pnlDesktop.Controls.Add(this.pnlTool);
            this.pnlDesktop.Controls.Add(this.pnlThongTinMuon);
            this.pnlDesktop.Controls.Add(this.pnlDataGridView);
        }

        void loadXuatSachList()
        {
            dgvXuatSach.DataSource = XuatSach_DAO.Instance.GetListXuatSach();
            SetUpXuatSachDataGridView();
            if (dgvXuatSach.Rows.Count > 0)
            {
                DataGridViewRow row = dgvXuatSach.Rows[0];

                lblTenNV.Text = row.Cells["hoTenNhanVien"].Value.ToString();
                lblNgayXuat.Text = row.Cells["ngayXuat"].Value.ToString();
                lblTongGiaBan.Text = row.Cells["tongGiaBan"].Value.ToString() + " VND";

                maXuatSach = dgvXuatSach.Rows[0].Cells["maXuatSach"].Value.ToString();

                HienThiChiTietXuatSach(maXuatSach);
            }
        }

        void SetUpXuatSachDataGridView()
        {
            dgvXuatSach.Columns["maXuatSach"].HeaderText = "MÃ XUẤT SÁCH";
            dgvXuatSach.Columns["hoTenNhanVien"].HeaderText = "TÊN NHÂN VIÊN";
            dgvXuatSach.Columns["hoTenNhanVien"].Width = 170;
            dgvXuatSach.Columns["ngayXuat"].HeaderText = "NGÀY XUẤT";
            dgvXuatSach.Columns["tongGiaBan"].HeaderText = "TỔNG GIÁ BÁN";

            dgvXuatSach.Columns["ngayXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvXuatSach.AllowUserToAddRows = false;
            dgvXuatSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            //dgvXuatSach.AutoResizeColumns();
            //dgvXuatSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvXuatSach.RowTemplate.Height = 40;
        }

        private void HienThiChiTietXuatSach(string maXuatSach)
        {
            lsvChiTietXuat.Items.Clear();

            ChiTietXuatSach_DAO dao = new ChiTietXuatSach_DAO();
            DataTable dt = dao.GetListCtXuatSachTheoMaXuatSach(maXuatSach);

            foreach (DataRow row in dt.Rows)
            {
                string tenSach = row["tenSach"].ToString();
                string soLuongXuat = row["soLuongXuat"].ToString();
                string giaBan = row["giaBan"].ToString();
                string lyDoXuat = row["lyDoXuat"].ToString();

                ListViewItem item = new ListViewItem(tenSach);
                item.SubItems.Add(soLuongXuat);
                item.SubItems.Add(giaBan);
                item.SubItems.Add(lyDoXuat);

                lsvChiTietXuat.Items.Add(item);
            }
            lsvChiTietXuat.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvChiTietXuat.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void LoadDuLieuXuatSachTheoMa(string maXuatSach)
        {
            dgvXuatSach.DataSource = XuatSach_DAO.Instance.GetListXuatSachTheoMa(maXuatSach);
            SetUpXuatSachDataGridView();

        }
        #endregion


        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UCThemPhieuXuat uc = new UCThemPhieuXuat();
            addUserControl(uc);
        }

        private void dgvXuatSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvXuatSach.Rows[e.RowIndex];

                lblTenNV.Text = row.Cells["hoTenNhanVien"].Value.ToString();
                lblNgayXuat.Text = row.Cells["ngayXuat"].Value.ToString();
                lblTongGiaBan.Text = row.Cells["tongGiaBan"].Value.ToString() + " VND";

                maXuatSach = dgvXuatSach.Rows[e.RowIndex].Cells["maXuatSach"].Value.ToString();

                HienThiChiTietXuatSach(maXuatSach);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã xuất sách cần tìm")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Nhập mã xuất sách cần tìm";
                txtSearch.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string maXuatSach = txtSearch.Text.Trim();
            LoadDuLieuXuatSachTheoMa(maXuatSach);
        }
    #endregion

    }
}
