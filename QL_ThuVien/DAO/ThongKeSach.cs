using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class ThongKeSach
    {
        public static int GetTongSoSach()
        {
            string query = "EXEC sp_TongSoSach";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
        public static string GetSachChuaDuocMuon()
        {
            string query = "EXEC sp_TongSoSachChuaDuocMuon";
            string result = string.Empty;
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string tenSach = reader["tenSach"].ToString();
                                int soLuong = int.Parse(reader["soLuong"].ToString());
                                result += $" {tenSach},  {soLuong}\n";
                            }
                        }
                        else
                        {
                            result = "Không có sách nào chưa từng được mượn.";
                        }
                    }
                }
            }

            return result;
        }

        public static class TheLoaiDao
        {
            public static string GetThongKeTheLoai(string theLoai = null)
            {
                string query = "EXEC sp_ThongKeTheLoai @TheLoai";
                string result = string.Empty;
                using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TheLoai", (object)theLoai ?? DBNull.Value);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        if (data.Rows.Count > 0)
                        {
                            foreach (DataRow row in data.Rows)
                            {
                                result += $" {row["tenTheLoai"]},  {row["SoLuongSach"]}\n";
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
            public static string GetTenNhaXuatBan()
            {
                string query = "EXEC sp_LayTenNhaXuatBan";
                string result = string.Empty;


                using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
                {
                    connection.Open();


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);


                        if (data.Rows.Count > 0)
                        {

                            foreach (DataRow row in data.Rows)
                            {
                                result += $"{row["tenNhaXuatBan"]}\n";
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
            public static string GetTenTacGia()
            {
                string query = "EXEC sp_LayTenTacGia";
                string result = string.Empty;  // Biến để chứa kết quả

                using (SqlConnection connection = new SqlConnection(DataProvider.Instance.connectionSTR))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        if (data.Rows.Count > 0)
                        {
                            // Duyệt qua từng dòng dữ liệu và nối kết quả vào chuỗi
                            foreach (DataRow row in data.Rows)
                            {
                                result += $"{row["tenTacGia"]}\n";  // Thêm tên tác giả vào kết quả
                            }
                        }
                        else
                        {
                            result = "Không có dữ liệu";  // Nếu không có dữ liệu, thông báo lỗi
                        }
                    }
                }

                return result;  // Trả về chuỗi kết quả
            }

        }
    }
}

                
