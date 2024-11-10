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
    public partial class UCThemPhieuNhap : UserControl
    {
        public UCThemPhieuNhap()
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
        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            UCNhapSach uc = new UCNhapSach();
            addUserControl(uc);
        }
        private void btnSaveNhapSach_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển
            string maNhanVien = cboNhanVien.SelectedValue?.ToString();
            string nguonNhap = txtNguonNhap.Text.Trim();
            string soDienThoai = txtEmail.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tenDuong = txtTenDuong.Text.Trim();
            string phuongXa = txtPhuongXa.Text.Trim();
            string quanHuyen = txtQuanHuyen.Text.Trim();
            string tinhThanhPho = txtThanhPho.Text.Trim();
            DateTime ngayXuat = dtNgayNhap.Value;
            int soLuong = (int)numSoLuong.Value;
            string lyDo = cboSach.Text.Trim();
            decimal tongTien;
            decimal donGia;

            // Kiểm tra số điện thoại phải có 10 chữ số
            if (soDienThoai.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tổng tiền và đơn giá
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

            // Kiểm tra ngày xuất không lớn hơn ngày hiện tại
            if (ngayXuat > DateTime.Now)
            {
                MessageBox.Show("Ngày xuất không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện thêm dữ liệu vào bảng NhapSach
            //if (NhapSach_DAO.Instance.ThemNhapSach( maNhanVien, nguonNhap, soDienThoai, email, tenDuong, phuongXa, quanHuyen, tinhThanhPho, tongTien, soLuong, donGia, ngayXuat, lyDo))
            //{
            //    MessageBox.Show("Thêm thông tin nhập sách thành công!", "Thông báo", MessageBoxButtons.OK);

            //    // Xóa dữ liệu trong các textbox sau khi lưu thành công
            //    cboNhanVien.SelectedIndex = -1;
            //    cboSach.SelectedIndex = -1;
            //    txtEmail.Clear();
            //    txtSoDienThoai.Clear();
            //    txtTenDuong.Clear();
            //    txtPhuongXa.Clear();
            //    txtQuanHuyen.Clear();
            //    txtThanhPho.Clear();
            //    txtTongTien.Clear();
            //    txtDonGia.Clear();
            //    numSoLuong.Value = 1;
            //}
            else
            {
                MessageBox.Show("Có lỗi khi thêm thông tin nhập sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
