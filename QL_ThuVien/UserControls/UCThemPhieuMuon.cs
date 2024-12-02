using Guna.UI2.WinForms;
using Newtonsoft.Json;
using QL_ThuVien.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace QL_ThuVien.UserControls
{
    public partial class UCThemPhieuMuon : UserControl
    {
        Dictionary<string, string> dictDocGia = new Dictionary<string, string>();
        Dictionary<string, string> dictNhanVien = new Dictionary<string, string>();
        Dictionary<string, string> dictSach = new Dictionary<string, string>();
        private string maPhieuMuon;

        public UCThemPhieuMuon()
        {
            InitializeComponent();
            cboDocGia.Items.Clear();
            ChiTietPhieuMuon_DAO.Instance.GetDocGiaThenLoadToDict(dictDocGia);
            dictDocGia.Keys.ToList().ForEach(key => cboDocGia.Items.Add(key));

            txtNhanVien.Items.Clear();
            ChiTietPhieuMuon_DAO.Instance.GetNhanVienThenLoadToDict(dictNhanVien);
            dictNhanVien.Keys.ToList().ForEach(key => txtNhanVien.Items.Add(key));
            
            guna2ComboBox1.Items.Clear();
            ChiTietPhieuMuon_DAO.Instance.GetSachThenLoadToDict(dictSach);
            dictSach.Keys.ToList().ForEach(key => guna2ComboBox1.Items.Add(key));
            
            guna2ComboBox2.Items.Clear();
            guna2ComboBox2.DataSource = new string[] { "Cũ", "Mới", "Bình thường" };
            LoadTableChiTietPhieuMuon();
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
            UCMuonSach uc = new UCMuonSach();
            addUserControl(uc);
        }

        
        private void LoadTableChiTietPhieuMuon()
        {
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.ParseExact(dtpNgayTra.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Chuyển đổi ngày tháng thành chuỗi với định dạng yyyy-MM-dd
            string ngayTraFormatted = date1.ToString("yyyy-MM-dd");
            DateTime date2 = DateTime.ParseExact(dtpNgayMuon.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Chuyển đổi ngày tháng thành chuỗi với định dạng yyyy-MM-dd
            string ngayMuonFormatted = date2.ToString("yyyy-MM-dd");

            MessageBox.Show("Lưu phiếu mượn thành công.", "Thông báo");

            PhieuMuon_DAO.Instance.ThemPhieuMuon(dictDocGia[cboDocGia.SelectedItem.ToString()], dictNhanVien[txtNhanVien.SelectedItem.ToString()], ngayMuonFormatted, ngayTraFormatted, GetChiTietMuonSach());
            cboDocGia.SelectedIndex = -1;
            txtNhanVien.SelectedIndex = -1;
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;

            guna2NumericUpDown1.Value = 0;
            
            txtSoDienThoai.Clear();

            dtpNgayMuon.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;
        }

        private void btnAddListView_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đã chọn đầy đủ các thông tin cần thiết
            if (guna2ComboBox1.SelectedIndex == -1 || guna2ComboBox2.SelectedIndex == -1 || guna2NumericUpDown1.Value <= 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm vào danh sách.", "Thông báo");
                return;
            }
            foreach (ListViewItem item1 in lsvChiTietMuon.Items)
            {
                if (item1.SubItems[0].Text == dictSach[guna2ComboBox1.SelectedItem.ToString()])
                {
                    item1.SubItems[2].Text = (Int32.Parse(item1.SubItems[2].Text) + guna2NumericUpDown1.Value).ToString();
                    return;

                }
            }
            ListViewItem item = new ListViewItem(dictSach[guna2ComboBox1.SelectedItem.ToString()]);
            item.SubItems.Add(guna2ComboBox1.SelectedItem.ToString());
            item.SubItems.Add(guna2NumericUpDown1.Value.ToString());
            item.SubItems.Add(guna2ComboBox2.SelectedItem.ToString());
            item.SubItems.Add(txtSoDienThoai.Text);
            lsvChiTietMuon.Items.Add(item);
        }

        private string GetChiTietMuonSach()
        {
            var chiTietList = new List<object>();

            foreach (ListViewItem item in lsvChiTietMuon.Items)
            {
                string maSach = item.SubItems[0].Text;
                int soLuong = int.Parse(item.SubItems[2].Text);
                string tinhTrangSach = item.SubItems[3].Text;
                string ghiChu = item.SubItems[4].Text;

                var chiTiet = new
                {
                    maSach,
                    soLuong,
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
            if (lsvChiTietMuon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn phiếu mượn cần xóa.", "Thông báo");
            }
            else
            {
                // Get the selected item
                ListViewItem selectedItem = lsvChiTietMuon.SelectedItems[0];

                // Optionally, get the item text or any other property you need (e.g., item identifier)
                string phieuXoa = selectedItem.Text;

                // Delete the item from the ListView
                lsvChiTietMuon.Items.Remove(selectedItem);

                // Optionally, delete the item from the database (if needed)
                ChiTietPhieuMuon_DAO.Instance.DeletePhieuMuon(phieuXoa);

                // Optionally, reload the table data or refresh the ListView
                LoadTableChiTietPhieuMuon();

                // Show a confirmation message
                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
        }

        private void btnResetText_Click(object sender, EventArgs e)
        {
            cboDocGia.SelectedIndex = -1;
            txtNhanVien.SelectedIndex = -1;
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;

            guna2NumericUpDown1.Value = 0;
            txtSoDienThoai.Clear();

            dtpNgayMuon.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;

            lsvChiTietMuon.Items.Clear();

        }
    }
}
