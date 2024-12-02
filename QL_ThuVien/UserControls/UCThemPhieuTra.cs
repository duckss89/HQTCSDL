using Guna.UI2.WinForms;
using Newtonsoft.Json;
using QL_ThuVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuVien.UserControls
{
    public partial class UCThemPhieuTra : UserControl
    {
        Dictionary<string, string> dictDocGia = new Dictionary<string, string>();
        Dictionary<string, string> dictNhanVien = new Dictionary<string, string>();
        Dictionary<string, string> dictSach = new Dictionary<string, string>();
        private string maPhieuTra;

        public UCThemPhieuTra()
        {
            InitializeComponent();
            cboMaPhieuMuon.Items.Clear();
            ChiTietPhieuTra_DAO.Instance.GetPhieuMuonThenLoadToComboBox(cboMaPhieuMuon);
            txtNhanVien.Items.Clear();
            ChiTietPhieuMuon_DAO.Instance.GetNhanVienThenLoadToDict(dictNhanVien);
            dictNhanVien.Keys.ToList().ForEach(key => txtNhanVien.Items.Add(key));

            cboSach.Items.Clear();
            ChiTietPhieuMuon_DAO.Instance.GetSachThenLoadToDict(dictSach);
            dictSach.Keys.ToList().ForEach(key => cboSach.Items.Add(key));

            cboTrangThai.Items.Clear();
            cboTrangThai.DataSource = new string[] { "Đúng hạn", "Trễ" };

            cboTinhTrang.Items.Clear();
            cboTinhTrang.DataSource = new string[] { "Bình thường", "Hư hỏng", "Mất" };
            LoadTableChiTietPhieuTra();
        }
        private void LoadTableChiTietPhieuTra()
        {

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
            UCTraSach uc = new UCTraSach();
            addUserControl(uc);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.ParseExact(dtpNgayTra.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Chuyển đổi ngày tháng thành chuỗi với định dạng yyyy-MM-dd
            string ngayTraFormatted = date1.ToString("yyyy-MM-dd");

            MessageBox.Show("Lưu phiếu trả thành công.", "Thông báo");

            PhieuTra_DAO.Instance.ThemPhieuTra(cboMaPhieuMuon.SelectedItem.ToString(), dictNhanVien[txtNhanVien.SelectedItem.ToString()], ngayTraFormatted, cboTrangThai.SelectedItem.ToString(), GetChiTietTraSach());
            cboMaPhieuMuon.SelectedIndex = -1;
            txtNhanVien.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            cboSach.SelectedIndex = -1;
            cboTinhTrang.SelectedIndex = -1;
            cboPhiPhatSinh.Clear();
            txtGhiChu.Clear();

            dtpNgayTra.Value = DateTime.Now;
        }

        private void btnAddListView_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đã chọn đầy đủ các thông tin cần thiết
            if (cboSach.SelectedIndex == -1 || cboTinhTrang.SelectedIndex == -1 || string.IsNullOrEmpty(cboPhiPhatSinh.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm vào danh sách.", "Thông báo");
                return;
            }

            // Duyệt qua các item hiện tại trong ListView để kiểm tra trùng lặp
            foreach (ListViewItem item1 in lsvChiTietTra.Items)
            {
                if (item1.SubItems[0].Text == dictSach[cboSach.SelectedItem.ToString()])
                {
                    // Nếu sách đã tồn tại, cộng dồn phí phát sinh
                    decimal currentPhiPhatSinh = decimal.Parse(item1.SubItems[2].Text);
                    decimal newPhiPhatSinh = decimal.Parse(cboPhiPhatSinh.Text);
                    item1.SubItems[2].Text = (currentPhiPhatSinh + newPhiPhatSinh).ToString("F2"); // Cộng dồn phí phát sinh
                    return;
                }
            }

            // Nếu không trùng lặp, thêm mới vào ListView
            ListViewItem item = new ListViewItem(dictSach[cboSach.SelectedItem.ToString()]); // Mã sách
            item.SubItems.Add(cboSach.SelectedItem.ToString()); // Tên sách
            item.SubItems.Add(decimal.Parse(cboPhiPhatSinh.Text).ToString("F2")); // Phí phát sinh
            item.SubItems.Add(cboTinhTrang.SelectedItem.ToString()); // Tình trạng sách
            item.SubItems.Add(txtGhiChu.Text); // Ghi chú

            // Thêm item vào ListView
            lsvChiTietTra.Items.Add(item);
        }

        private string GetChiTietTraSach()
        {
            var chiTietList = new List<object>();

            foreach (ListViewItem item in lsvChiTietTra.Items)
            {
                string maSach = item.SubItems[0].Text;
                decimal phiPhatSinh = decimal.Parse(item.SubItems[2].Text);
                string tinhTrangSach = item.SubItems[3].Text;
                string ghiChu = item.SubItems[4].Text;

                var chiTiet = new
                {
                    maSach,
                    phiPhatSinh,
                    tinhTrangSach,
                    ghiChu
                };

                chiTietList.Add(chiTiet);
            }

            return JsonConvert.SerializeObject(chiTietList);
        }

        private void btnRemoveListView_Click(object sender, EventArgs e)
        {

            // Check if any item is selected in the ListView
            if (lsvChiTietTra.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn phiếu mượn cần xóa.", "Thông báo");
            }
            else
            {
                // Get the selected item
                ListViewItem selectedItem = lsvChiTietTra.SelectedItems[0];

                // Optionally, get the item text or any other property you need (e.g., item identifier)
                string phieuXoa = selectedItem.Text;

                // Delete the item from the ListView
                lsvChiTietTra.Items.Remove(selectedItem);

                // Optionally, delete the item from the database (if needed)
                ChiTietPhieuMuon_DAO.Instance.DeletePhieuMuon(phieuXoa);

                // Optionally, reload the table data or refresh the ListView
                LoadTableChiTietPhieuTra();

                // Show a confirmation message
                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
        }
        private void btnResetText_Click(object sender, EventArgs e)
        {
            cboMaPhieuMuon.SelectedIndex = -1;
            txtNhanVien.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            cboSach.SelectedIndex = -1;
            cboTinhTrang.SelectedIndex = -1;

            cboPhiPhatSinh.Clear();
            txtGhiChu.Clear();

            dtpNgayTra.Value = DateTime.Now;
            lsvChiTietTra.Items.Clear();

        }
    }
}
