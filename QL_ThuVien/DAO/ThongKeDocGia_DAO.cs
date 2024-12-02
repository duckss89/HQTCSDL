using QL_ThuVien.DAO;
using QL_ThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QL_ThuVien.DAO.ThongKeDocGia_DAO;

namespace QL_ThuVien.DAO
{
    public class ThongKeDocGia_DAO
    {
        // Tổng số độc giả 
        public static int GetTongSoDocGia()
        {
            string query = "EXEC sp_TongSoDocGia";

            object result = DataProvider.Instance.ExecuteScalar(query);


            if (result != null && int.TryParse(result.ToString(), out int total))
            {
                return total;
            }

            return 0;
        }


        public static string GetDocGiaMuonNhieuNhat()
        {
            string result = string.Empty;
            string query = "EXEC sp_DocGiaMuonNhieuNhat";

            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy cột đầu tiên trong kết quả
                            result = reader.GetString(0); // Giả định cột đầu tiên là `hoTen` và kiểu dữ liệu là `string`
                        }
                    }
                }
            }

            return result;
        }


        public static string GetDocGiaTreHanNhieuNhat()
        {
            string result = string.Empty;
            string query = "EXEC sp_DocGiaTreHanNhieuNhat";
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            result = reader["hoTen"].ToString();
                        }
                    }
                }
            }
            return result;
        }
        // Hàm lấy thống kê độc giả theo độ tuổi
        public DataTable GetThongKeDoTuoi()
        {
            string query = "EXEC sp_ThongKeDoTuoi";

            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }

        // Hàm lấy thống kê độc giả theo giới tính
        public static string GetThongKeGioiTinh(string gioiTinh = null)
        {
            string query = "EXEC sp_ThongKeGioiTinh @GioiTinh";
            string result = string.Empty;

            // Nếu gioiTinh không phải null, thêm tham số vào câu lệnh SQL
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @GioiTinh vào câu lệnh
                    command.Parameters.AddWithValue("@GioiTinh", (object)gioiTinh ?? DBNull.Value);  // Nếu gioiTinh null, thì truyền DBNull.Value

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    // Nếu có dữ liệu trong DataTable, chuyển đổi nó thành chuỗi
                    if (data.Rows.Count > 0)
                    {
                        // Duyệt qua từng dòng và tạo chuỗi kết quả
                        foreach (DataRow row in data.Rows)
                        {
                            result += $" {row["gioiTinh"]},  {row["SoLuong"]}\n";
                        }
                    }
                    else
                    {
                        result = "Không có dữ liệu";
                    }
                }
            }

            return result;
        }


        public static string GetThongKeDoTuoi(DateTime startDate, DateTime endDate)
        {
            string query = "EXEC sp_ThongKeDoTuoi";
            string result = string.Empty;

            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    // Nếu có dữ liệu trong DataTable, chuyển đổi thành chuỗi
                    if (data.Rows.Count > 0)
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            result += $"Nhóm tuổi: {row["NhomTuoi"]}, Số lượng: {row["SoLuongDocGia"]}\n";
                        }
                    }
                    else
                    {
                        result = "Không có dữ liệu";
                    }
                }
            }

            return result;
        }


    }
}
   









