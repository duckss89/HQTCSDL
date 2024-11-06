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
    public partial class UCThemDocGia : UserControl
    {
        public UCThemDocGia()
        {
            InitializeComponent();
            dtpNgaySinh.Value = DateTime.Now;
        }

        #region Method
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
        #endregion

        #region Event
        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            UCDocGia uCDocGia = new UCDocGia();
            addUserControl(uCDocGia);
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

            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (DocGia_DAO.Instance.ThemDocGia(ho, hoLot, ten, ngaySinh, gioiTinh, tenDuong, phuongXa, quanHuyen, tinhThanhPho, soDienThoai, email))
            {
                MessageBox.Show(string.Format("Bạn đã thêm thành công độc giả {0} {1} {2}", ho, hoLot, ten), "Thông báo");

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
            }
            else
                MessageBox.Show("Có lỗi khi thêm khách hàng!", "Thông báo");
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
        }
        #endregion
    }
}
