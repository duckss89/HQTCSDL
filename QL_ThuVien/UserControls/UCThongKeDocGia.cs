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
    public partial class UCThongKeDocGia : UserControl
    {
        public UCThongKeDocGia()
        {
            InitializeComponent();
        }

        private void UCThongKeDocGia_Load(object sender, EventArgs e)
        {
            int tongSoDocGia = ThongKeDocGia_DAO.GetTongSoDocGia();
            txtTongSoDG.Text = tongSoDocGia.ToString();
        }

        private void txtDgNhieuNhat_Load(object sender, EventArgs e)
        {
            string tenDocGia = ThongKeDocGia_DAO.GetDocGiaMuonNhieuNhat().ToString();
            txtDgNhieuNhat.Text = tenDocGia.ToString();
        }

        private void txtDgTreHan_Load(object sender, EventArgs e)
        {
            string tenDocGia = ThongKeDocGia_DAO.GetDocGiaTreHanNhieuNhat().ToString();
            txtDgTreHan.Text = tenDocGia.ToString();
        }

        private void txtTongSoDG_TextChanged(object sender, EventArgs e)
        {


        }



        private void txtGioiTinh_Load(object sender, EventArgs e)
        {
            string tenDocGia = ThongKeDocGia_DAO.GetThongKeGioiTinh().ToString();
            txtGioiTinh.Text = tenDocGia.ToString();
        }

        private void txtDoTuoi_Load(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = new DateTime(2024, 11, 27);

            string result = ThongKeDocGia_DAO.GetThongKeDoTuoi(startDate, endDate);
            Console.WriteLine(result);
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {


            
                // Kiểm tra xem người dùng đã chọn giá trị nào trong ComboBox
                string selectedValue = cboGioiTinh.SelectedItem.ToString();  // Lấy giá trị đã chọn

                // Biến lưu kết quả thống kê
                string result = string.Empty;

                // Kiểm tra giá trị được chọn và gọi phương thức thống kê tương ứng
                if (selectedValue == "Nam")
                {
                    // Gọi phương thức lấy thống kê cho giới tính Nam
                    result = ThongKeDocGia_DAO.GetThongKeGioiTinh("Nam");
                }
                else if (selectedValue == "Nữ")
                {
                    // Gọi phương thức lấy thống kê cho giới tính Nữ
                    result = ThongKeDocGia_DAO.GetThongKeGioiTinh("Nữ");
                }
                else
                {
                    // Nếu không chọn "Nam" hoặc "Nữ", lấy thống kê cho tất cả giới tính
                    result = ThongKeDocGia_DAO.GetThongKeGioiTinh();  // Truyền null hoặc không truyền tham số để lấy tất cả
                }

                // Hiển thị kết quả lên giao diện
                txtGioiTinh.Text = result;  // Giả sử bạn có một TextBox hoặc Label để hiển thị kết quả
            }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }




    

