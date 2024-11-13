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
    public partial class UCSuaNhanVien : UserControl
    {
        private string maNhanVien;
        public UCSuaNhanVien(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            LoadThongTinNhanVien();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public void LoadThongTinNhanVien()
        {
            if (string.IsNullOrEmpty(maNhanVien) == false)
            {
                List<NhanVien_DTO> listNhanVien = NhanVien_DAO.Instance.LayThongTinNhanVienTheoMaNV(maNhanVien);
                foreach (NhanVien_DTO item in listNhanVien)
                {
                    txtHo.Text = item.Ho;
                    txtHoLot.Text = item.HoLot;
                    txtTen.Text = item.Ten;
                    txtTenDuong.Text = item.TenDuong;
                    txtQuanHuyen.Text = item.QuanHuyen;
                    txtPhuongXa.Text = item.PhuongXa;
                    txtTinhThanhPho.Text = item.TinhThanhPho;
                    dtpNgaySinh.Value = ((DateTime)item.NgaySinh);
                    if (item.GioiTinh == "Nữ")
                        rdoNu.Checked = true;
                    else
                        rdoNam.Checked = true;
                    txtEmail.Text = item.Email;
                    txtSoDienThoai.Text = item.SoDienThoai;
                    cboChucVu.Text = (item.ChucVu == true) ? "Staff" : "Admin"; 
                }
            }
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
            UCNhanVien uc = new UCNhanVien();
            addUserControl(uc);
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
            bool chucVu;

            string gioiTinh = null;
            if (rdoNam.Checked)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";

            if (cboChucVu.SelectedIndex == 0)
                chucVu = false;
            else
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

            if (NhanVien_DAO.Instance.SuaNhanVien(maNhanVien,ho, hoLot, ten, ngaySinh, gioiTinh, tenDuong, phuongXa, quanHuyen, tinhThanhPho, soDienThoai, email, chucVu))
            {
                MessageBox.Show(string.Format("Bạn đã sửa thành công thông tin nhân viên {0} {1} {2}", ho, hoLot, ten), "Thông báo");

                UCNhanVien uc = new UCNhanVien();
                addUserControl(uc);
            }
            else
                MessageBox.Show("Có lỗi khi sửa thông tin nhân viên!", "Thông báo");
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
    }
}
