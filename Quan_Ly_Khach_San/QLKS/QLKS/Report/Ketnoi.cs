using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Report
{
    internal class Ketnoi
    {
        private string connectstring = "Data Source=LAPTOP-BL7H57TI\\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";
        public SqlConnection getConnect()
        {
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            return conn;
        }
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection ketnoi = new SqlConnection(connectstring))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                data = thucthi.ExecuteNonQuery();
                ketnoi.Close();
            }
            return data;
        }
    }
}
