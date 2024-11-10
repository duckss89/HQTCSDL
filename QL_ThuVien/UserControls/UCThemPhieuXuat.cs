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
    public partial class UCThemPhieuXuat : UserControl
    {
        private string maXuatSach;
        public UCThemPhieuXuat()
        {
            InitializeComponent();
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

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UCXuatSach uc = new UCXuatSach();
            addUserControl(uc);
        }

        private void btnSaveNhapSach_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển
            string maNhanVien = cboNhanVien.SelectedValue?.ToString();
            string nguonNhap = cboSach.SelectedValue?.ToString();
            DateTime ngayXuat = dtpNgayXuat.Value;
            int soLuong = (int)numSoLuong.Value;
            string lyDo = cboLyDo.Text.Trim();
            decimal tongTien;
            decimal donGia;

            if (!decimal.TryParse(txtTongTien.Text.Trim(), out tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngayXuat > DateTime.Now)
            {
                MessageBox.Show("Ngày xuất không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (NhapSach_DAO.Instance.ThemNhapSach(maXuatSach, maNhanVien, nguonNhap, tongTien, soLuong, donGia, ngayXuat, lyDo))
            //{
            //    MessageBox.Show("Thêm thông tin nhập sách thành công!", "Thông báo", MessageBoxButtons.OK);

            //    cboNhanVien.SelectedIndex = -1;
            //    cboSach.SelectedIndex = -1;
            //    txtTongTien.Clear();
            //    txtDonGia.Clear();
            //    numSoLuong.Value = 1;
            //    cboLyDo.SelectedIndex = -1;
            //}
            else
            {
                MessageBox.Show("Có lỗi khi thêm thông tin nhập sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnResetNhapSach_Click(object sender, EventArgs e)
        {
            cboNhanVien.SelectedIndex = -1;
            cboSach.SelectedIndex = -1;
            cboLyDo.SelectedIndex = -1;

            dtpNgayXuat.Value = DateTime.Now;

            numSoLuong.Value = 1;

            txtTongTien.Clear();
            txtDonGia.Clear();
        }

    }
}
