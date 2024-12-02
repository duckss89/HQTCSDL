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
using static QL_ThuVien.DAO.ThongKeSach;

namespace QL_ThuVien.UserControls
{
    public partial class UCThongKeSach : UserControl
    {
        public UCThongKeSach()
        {
            InitializeComponent();
        }

        private void UCThongKeSach_Load(object sender, EventArgs e)
        {
            int tongSoSach = ThongKeSach.GetTongSoSach();
            txtTongSoSach.Text = tongSoSach.ToString();
        }

        private void txtSachchuamuon_Load(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm DAO để lấy dữ liệu
                string result = ThongKeSach.GetSachChuaDuocMuon();

                // Hiển thị kết quả vào TextBox hoặc Label
                txtSachchuamuon.Text = result; // `txtSachChuaDuocMuon` là TextBox
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Kiểm tra xem người dùng đã chọn giá trị nào trong ComboBox
            string selectedValue = cboTheLoai.SelectedItem.ToString(); // Lấy giá trị đã chọn

            // Biến lưu kết quả thống kê
            string result = string.Empty;

            // Kiểm tra giá trị được chọn và gọi phương thức thống kê tương ứng
            if (selectedValue == "Tất cả")
            {
                // Gọi phương thức lấy thống kê cho tất cả thể loại
                result = TheLoaiDao.GetThongKeTheLoai(); // Không truyền tham số để lấy tất cả
            }
            else
            {
                // Gọi phương thức lấy thống kê cho thể loại được chọn
                result = TheLoaiDao.GetThongKeTheLoai(selectedValue);
            }

            // Hiển thị kết quả lên giao diện
            txtTheLoai.Text = result; // Giả sử bạn có một TextBox hoặc Label để hiển thị kết quả
        }

        
        private void cboNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cboNhaXuatBan.SelectedItem.ToString();  // Lấy giá trị đã chọn
            string result;

            // Kiểm tra xem người dùng chọn "Tất cả" hay một nhà xuất bản cụ thể
            if (selectedValue == "Tất cả")
            {
                result = "Hiển thị tất cả nhà xuất bản"; // Trường hợp chọn "Tất cả"
            }
            else
            {
                result = $" {selectedValue}"; // Trường hợp chọn một nhà xuất bản cụ thể
            }

            // Hiển thị kết quả trong TextBox hoặc Label
           txtNhaXuatBan.Text = result;  // txtNhaXuatBan là TextBox dùng để hiển thị kết quả
        }


        private void cboTacGia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedValue = cboTacGia.SelectedItem.ToString();
            string result;
            if (selectedValue == "Tất cả")
            {
                result = "Hiển thị tất cả tác giả ";

            }
            else
            {
                result = $" {selectedValue}";
            }
            txtTacGia.Text = result;    
        }
    }
    }
    



