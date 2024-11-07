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
    public partial class UCSuaDocGia : UserControl
    {
        private string maDocGia;
        public UCSuaDocGia(string maDocGia)
        {
            InitializeComponent();
            this.maDocGia = maDocGia;
            LoadThongTinDocGia();
        }

        #region Method
        public void LoadThongTinDocGia()
        {
            if (string.IsNullOrEmpty(maDocGia) == false)
            {
                List<DocGia_DTO> listDocGia = DocGia_DAO.Instance.LayThongTinDocGiaTheoMaDG(maDocGia);
                foreach (DocGia_DTO item in listDocGia)
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
                }
            }
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Clear();
            pnlDesktop.Controls.Add(userControl);
            userControl.BringToFront();
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
        private void btnReturn_Click(object sender, EventArgs e)
        {
            UCDocGia uc = new UCDocGia();
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

            if (DocGia_DAO.Instance.SuaDocGia(maDocGia, ho, hoLot, ten, ngaySinh, gioiTinh, tenDuong, phuongXa, quanHuyen, tinhThanhPho, soDienThoai, email))
            {
                MessageBox.Show(string.Format("Bạn đã sửa thành công thông tin độc giả {0} {1} {2}", ho, hoLot, ten), "Thông báo");
                UCDocGia uc = new UCDocGia();
                addUserControl(uc);
            }
            else
                MessageBox.Show(string.Format("Có lỗi thi sửa thông tin độc giả {0} {1} {2}", ho, hoLot, ten), "Thông báo");
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
        #endregion
    }
}
