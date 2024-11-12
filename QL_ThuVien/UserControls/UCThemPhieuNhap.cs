using Newtonsoft.Json;
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
using System.Xml.Linq;

namespace QL_ThuVien.UserControls
{
    public partial class UCThemPhieuNhap : UserControl
    {
        public UCThemPhieuNhap()
        {
            InitializeComponent();
            loadNhanVien();
            loadSach();
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
        }

        void loadNhanVien()
        {
            NhanVien_DAO nhanVien = new NhanVien_DAO();
            List<NhanVien_DTO> listNhanVien = nhanVien.GetNhanVien();

            cboNhanVien.Items.Clear();
            cboNhanVien.DataSource = listNhanVien;
            cboNhanVien.DisplayMember = "HoTenNhanVien";
            cboNhanVien.ValueMember = "MaNhanVien";
        }

        void loadSach()
        {
            Sach_DAO sach = new Sach_DAO();
            List<Sach_DTO> listSach = sach.GetSach();

            cboSach.Items.Clear();
            cboSach.DataSource = listSach;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
        }

        void tinhTongTien()
        {
            double tongTien = 0;

            foreach (ListViewItem item in lsvChiTietMuon.Items)
            {
                double donGia = Convert.ToDouble(item.SubItems[3].Text);

                tongTien += donGia;
            }

            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            UCNhapSach uc = new UCNhapSach();
            addUserControl(uc);
        }

        private void btnAddListView_Click(object sender, EventArgs e)
        {
            Sach_DTO selectedSach = (Sach_DTO)cboSach.SelectedItem;
            string maSach = selectedSach.MaSach;
            string tenSach = selectedSach.TenSach;
            int soLuong = Convert.ToInt32(numSoLuong.Value);
            double donGia = Convert.ToDouble(selectedSach.GiaBan);

            bool sachExist = false;
            foreach (ListViewItem item in lsvChiTietMuon.Items)
            {
                if (item.Text == maSach)
                {
                    int currentSoLuong = Convert.ToInt32(item.SubItems[2].Text);
                    item.SubItems[2].Text = (currentSoLuong + soLuong).ToString();

                    item.SubItems[3].Text = (donGia * (currentSoLuong + soLuong)).ToString("N0");

                    sachExist = true;
                    break;
                }
            }

            if (!sachExist)
            {
                ListViewItem item = new ListViewItem(maSach);
                item.SubItems.Add(tenSach.ToString());
                item.SubItems.Add(soLuong.ToString());
                item.SubItems.Add((donGia * soLuong).ToString("N0"));

                lsvChiTietMuon.Items.Add(item);
            }

            cboSach.ResetText();
            numSoLuong.Value = 1;

            tinhTongTien();
        }
    

        private void btnRemoveListView_Click(object sender, EventArgs e)
        {
            if (lsvChiTietMuon.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvChiTietMuon.SelectedItems[0];

                lsvChiTietMuon.Items.Remove(selectedItem);

                tinhTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.");
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedItem != null)
            {
                Sach_DTO selectedSach = (Sach_DTO)cboSach.SelectedItem;

                txtDonGia.Text = selectedSach.GiaBan.ToString("N0");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NhanVien_DTO selectedNhanVien = (NhanVien_DTO)cboNhanVien.SelectedItem;
            string maNhanVien = selectedNhanVien.MaNhanVien;
            string nguonNhap = txtNguonNhap.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string email = txtEmail.Text;
            string tenDuong = txtTenDuong.Text;
            string phuongXa = txtPhuongXa.Text;
            string quanHuyen = txtQuanHuyen.Text;
            string tinhThanhPho = txtThanhPho.Text;
            decimal tongTien = decimal.Parse(txtTongTien.Text);
            string chiTietNhapSach = GetChiTietNhapSach();

            NhapSach_DAO.Instance.ThemPhieuNhap(maNhanVien, nguonNhap, soDienThoai, email,
                                            tenDuong, phuongXa, quanHuyen, tinhThanhPho,
                                            tongTien, chiTietNhapSach);
            MessageBox.Show("Thêm phiếu nhập thành công!");
        }

        private string GetChiTietNhapSach()
        {
            var chiTietList = new List<object>();

            foreach (ListViewItem item in lsvChiTietMuon.Items)
            {
                string maSach = item.SubItems[0].Text;
                int soLuongNhap = int.Parse(item.SubItems[2].Text);
                decimal giaNhap = decimal.Parse(item.SubItems[3].Text);

                var chiTiet = new
                {
                    maSach,
                    soLuongNhap,
                    giaNhap
                };

                chiTietList.Add(chiTiet);
            }

            return JsonConvert.SerializeObject(chiTietList);
        }

    }
}
