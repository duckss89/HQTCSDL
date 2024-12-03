using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuVien.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // ctrl + r + e
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider(); return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private DataProvider(){}

        //Nguyên
        public string connectionSTR = "Data Source=DESKTOP-8O97R1M\\MSSQLSERVER10;Initial Catalog=QL_ThuVien;Integrated Security=True;TrustServerCertificate=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }


        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    //string[] listPara = query.Split(' ');
                    //int i = 0;
                    string[] listPara = query.Split(new char[] { ' ', ',', ')', '(', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
        public delegate T IFunction<T>(SqlCommand command);
        public T Function<T>(string statement, IFunction<T> function)
        {
            T result;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    connection.Open();
                    result = function(command);
                }
            }
            return result;
        }

        public T Function<T>(string statement, IFunction<T> function, params SqlParameter[] parameters)
        {
            T result;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.Parameters.AddRange(parameters); // Add parameters to the command
                    connection.Open();
                    result = function(command);
                }
            }
            return result;
        }
    }

}

