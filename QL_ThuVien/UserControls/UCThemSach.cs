using QL_ThuVien.DAO;
using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QL_ThuVien.DAO.ThongKeSach;

namespace QL_ThuVien.UserControls
{
    public partial class UCThemSach : UserControl
    {
        public UCThemSach()
        {
            InitializeComponent();
        }

        void loadTheLoai()
        {
            TheLoai_DAO theLoai = new TheLoai_DAO();
            List<TheLoai_DTO> listTheLoai = theLoai.GetTheLoai();

            cboTheLoai.Items.Clear();
            cboTheLoai.DataSource = listTheLoai;
            cboTheLoai.DisplayMember = "tenTheLoai";
            cboTheLoai.ValueMember = "maTheLoai";
        }

        void loadTacGia()
        {
            TacGia_DAO tacGia = new TacGia_DAO();
            List<TacGia_DTO> listTacGia = tacGia.GetTacGia();

            cboTacGia.Items.Clear();
            cboTacGia.DataSource = listTacGia;
            cboTacGia.DisplayMember = "tenTacGia";
            cboTacGia.ValueMember = "maTacGia";
        }

        void loadNhaXuatBan()
        {
            NhaXuatBan_DAO nhaXuatBan = new NhaXuatBan_DAO();
            List<NhaXuatBan_DTO> listNhaXuatBan = nhaXuatBan.GetNXB();

            cboNhaXuatBan.Items.Clear();
            cboNhaXuatBan.DataSource = listNhaXuatBan;
            cboNhaXuatBan.DisplayMember = "tenNhaXuatBan";
            cboNhaXuatBan.ValueMember = "maNhaXuatBan";
        }

        void loadViTri()
        {
            Sach_DAO viTri = new Sach_DAO();
            List<Sach_DTO> listViTri = viTri.GetViTri();

            cboViTri.Items.Clear();
            cboViTri.DataSource = listViTri;
            cboViTri.DisplayMember = "viTri";
            cboViTri.ValueMember = "viTri";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File|*.jpg;*.jpeg;*.png;*.gif";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ptrAnh.Image = Image.FromFile(filePath);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string tenSach = txtTenSach.Text.Trim();
            string ISBN = txtISBN.Text.Trim();
            string namXuatBanStr = txtNamXuatBan.Text.Trim();
            string giaBanStr = txtGiaBan.Text.Trim();
            string viTri = cboViTri.SelectedValue?.ToString();
            string maTheLoai = cboTheLoai.SelectedValue?.ToString();
            string maTacGia = cboTacGia.SelectedValue?.ToString();
            string maNhaXuatBan = cboNhaXuatBan.SelectedValue?.ToString();
            string biaSachPath = ptrAnh.Text;
            int soLuong = 0;


            if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(ISBN) ||
                string.IsNullOrEmpty(namXuatBanStr) ||
                string.IsNullOrEmpty(giaBanStr) || string.IsNullOrEmpty(viTri) ||
                string.IsNullOrEmpty(maTheLoai) || string.IsNullOrEmpty(maTacGia) || string.IsNullOrEmpty(maNhaXuatBan))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(namXuatBanStr, out int namXuatBan) || namXuatBan <= 0)
            {
                MessageBox.Show("Năm xuất bản phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaBanStr, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số thực dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string contentFolder = Path.Combine(Application.StartupPath, "Content");
            if (!Directory.Exists(contentFolder))
                Directory.CreateDirectory(contentFolder);

            string imageFileName = Path.GetFileName(biaSachPath);
            string relativeImagePath = $"Content/{imageFileName}";
            string newImagePath = Path.Combine(contentFolder, imageFileName);

            try
            {
                File.Copy(biaSachPath, newImagePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Sach_DAO.Instance.ThemSach(tenSach, relativeImagePath, ISBN, namXuatBan, soLuong, giaBan, maTheLoai, maTacGia, maNhaXuatBan, viTri))
            {
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtTenSach.Clear();
                txtISBN.Clear();
                txtNamXuatBan.Clear();
                txtGiaBan.Clear();
                cboViTri.SelectedIndex = -1;
                cboTheLoai.SelectedIndex = -1;
                cboTacGia.SelectedIndex = -1;
                cboNhaXuatBan.SelectedIndex = -1;
                ptrAnh.Image = null;
            }
            else
            {
                MessageBox.Show("Thêm sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
