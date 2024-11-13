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
    public partial class UCThemNhanVien : UserControl
    {
        public UCThemNhanVien()
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UCNhanVien uc = new UCNhanVien();
            addUserControl(uc);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ho = txtHo.Text.Trim();
            string hoLot = txtHoLot.Text.Trim();
            string ten = txtTen.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString();
            string email = txtEmail.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string tenDuong = txtTenDuong.Text.Trim();
            string phuongXa = txtPhuongXa.Text.Trim();
            string quanHuyen = txtQuanHuyen.Text.Trim();
            string tinhThanhPho = txtTinhThanhPho.Text.Trim();

            string gioiTinh = null;
            if (rdoNam.Checked)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";

            bool chucVu = false;
            if(cboChucVu.Text == "Admin")
                chucVu = true;

            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cá nhân của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soDienThoai.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Parse(ngaySinh) > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tenDuong) || string.IsNullOrEmpty(phuongXa) || string.IsNullOrEmpty(quanHuyen) || string.IsNullOrEmpty(tinhThanhPho))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin địa chỉ của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NhanVien_DAO.Instance.ThemNhanVien(ho, hoLot, ten, ngaySinh, gioiTinh, tenDuong, phuongXa, quanHuyen, tinhThanhPho, soDienThoai, email, chucVu))
            {
                MessageBox.Show(string.Format("Bạn đã thêm thành công thông tin nhân viên {0} {1} {2}", ho, hoLot, ten), "Thông báo");

                txtHo.Clear();
                txtHoLot.Clear();
                txtTen.Clear();
                dtpNgaySinh.Value = DateTime.Now;
                txtEmail.Clear();
                txtSoDienThoai.Clear();
                txtTenDuong.Clear();
                txtPhuongXa.Clear();
                txtQuanHuyen.Clear();
                txtTinhThanhPho.Clear();
                if (rdoNam.Checked)
                    rdoNam.Checked = false;
                else
                    rdoNu.Checked = false;
                cboChucVu.ResetText();
            }
            else
                MessageBox.Show("Có lỗi khi thêm thông tin nhân viên!", "Thông báo");
        }

        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtHoLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnResetText_Click(object sender, EventArgs e)
        {
            txtHo.Clear();
            txtHoLot.Clear();
            txtTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            txtTenDuong.Clear();
            txtPhuongXa.Clear();
            txtQuanHuyen.Clear();
            txtTinhThanhPho.Clear();
            if (rdoNam.Checked)
                rdoNam.Checked = false;
            else
                rdoNu.Checked = false;
            cboChucVu.ResetText();
        }
    }
}
