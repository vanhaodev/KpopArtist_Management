using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Properties.Settings.Default.LastUsername = theUsername;
///Properties.Settings.Default.Save();
/// </summary>
namespace ArtistMNG.Module.SQL
{
    public static class UserManager
    {
        public static Tuple<bool, string, string> Login(string username, string password)
        {
            //sử dụng lớp SqlConnection để tạo chuỗi kết nối
            SqlConnection con = new SqlConnection();
            //gọi chuỗi kết nối ở file App.config bằng thuộc tính ConnectionString
            //con.ConnectionString = @"Server=NVH2001\VANHAODEV;Database=Artist;User Id=nvh2001;Password=nvh2001;";
            con.ConnectionString = @"Server=34.142.169.129;Database=Artist;User ID=sqlserver;Password=nvh2001;";
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "[UserLogin]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                //mở chuỗi kết nối
                con.Open();

                //sử dụng ExecuteNonQuery để thực thi
                //cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(dt);
                }

                if (dt.Rows[0].Field<int>("Status") == 0)
                {
                    return Tuple.Create(false, "", "");
                }                       
                else
                {
                    Console.WriteLine(dt.Rows[0].Field<string>("username") + " " + dt.Rows[0].Field<string>("fullname"));
                    return Tuple.Create(true, dt.Rows[0].Field<string>("username"), dt.Rows[0].Field<string>("fullname"));
                }             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Tuple.Create(false, "", "");
            }
            // dóng chuỗi kết nối
            finally
            {
                con.Close();
            }      
        }
    }
}
