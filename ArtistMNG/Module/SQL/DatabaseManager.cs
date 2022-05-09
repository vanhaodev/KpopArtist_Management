using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Module.SQL
{
    public static class DatabaseManager
    {
        //Server=xx.xx.xx.xx;Database=xxdatabase;User ID=root;Password=xxx123
        //static SqlConnection cnn = new SqlConnection(@"Server=NVH2001\VANHAODEV;Database=Artist;User Id=nvh2001;Password=nvh2001;");
        //public static string connectString = @"Server=34.142.169.129;Database=Artist;User ID=sqlserver;Password=nvh2001;";
        public static string connectString = @"Server=LAPTOP-81LIJIKS\SQLEXPRESS;Database=Artist;Trusted_Connection=True;";

        static SqlConnection cnn = new SqlConnection(connectString);

        static SqlCommand com = null;
        static SqlDataAdapter da = null;
        static DataTable dt = null;
        static string cmd = "";
        
        public static DataTable ShowDataQuery(string query)
        {
            cmd = query;
            cnn.Open();

            com = new SqlCommand(cmd, cnn);
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public static DataTable ShowData(DatabaseTable databaseTable, string Select, string columnName = "", string whereValue = "")
        {
            cmd = $"SELECT {Select} FROM [{databaseTable.ToString()}]";
            if (columnName.Length > 0)
            {
                cmd += " WHERE " + columnName + " LIKE '" + whereValue + "%'";
            }
            cnn.Open();

            com = new SqlCommand(cmd, cnn);
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public static DataTable ShowDataStoredProcedure(string stored, string input1 = "", string input2 = "", string input3 = "", string input4 = "")
        {
            cmd = $"{stored} {input1} {input2} {input3} {input4}";            
            cnn.Open();
            com = new SqlCommand(cmd, cnn);
            com.CommandType = CommandType.Text;
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public static ComboBox ShowData_Combobox(DatabaseTable databaseTable, string Select, string columnName = "", string whereValue = "")
        {
            cmd = $"SELECT {Select} FROM [{databaseTable.ToString()}]";
            if (columnName.Length > 0)
            {
                cmd += " WHERE " + columnName + " LIKE '" + whereValue + "%'";
            }
            cnn.Open();
            com = new SqlCommand(cmd, cnn);
            com.CommandType = CommandType.Text;
            SqlDataReader dr = com.ExecuteReader();
            ComboBox cbx = new ComboBox();
            while (dr.Read())
            {
                cbx.Items.Add(dr[0]);

            }
            cnn.Close();
            return cbx;
        }
        //public static int ArtistNew()
        //{
        //    cmd = "IF EXISTS (SELECT * FROM [Artist] WHERE ArtistID = 1) BEGIN INSERT INTO[Artist](StageName, RealName, FandomID) VALUES(N'Nghệ danh mới', N'Tên thật mới', 0); "
        //    +"SELECT SCOPE_IDENTITY(); "
        //    +"END "
        //    +"ELSE "
        //    +"BEGIN SELECT 0 END";

        //    try
        //    {             
        //        cnn.Open();
        //        com = new SqlCommand(cmd, cnn);
        //        com.CommandType = CommandType.Text;

        //        da = new SqlDataAdapter(com);
        //        dt = new DataTable();
        //        da.Fill(dt);
        //        return (int)dt.Rows[0][0];
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return 0;

        //    }
        //    // dóng chuỗi kết nối
        //    finally
        //    {
        //        cnn.Close();
        //    }
        //}
        public static bool Image(DatabaseTable databaseTable ,DatabaseExecuteState DatabaseExecuteState, int imageID, string imageURL, string description, int ownerID = 0)
        {
            try
            {
                //khỏi tạo instance của class SqlCommand
                SqlCommand cmd = new SqlCommand();
                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                switch(DatabaseExecuteState)
                {
                    case DatabaseExecuteState.Insert:
                        if(databaseTable == DatabaseTable.Artist)
                        {
                            cmd.CommandText = "Artist_InsertImage";
                        }   
                        else if (databaseTable == DatabaseTable.Group)
                        {
                            cmd.CommandText = "Group_InsertImage";
                        }    
                        
                        break;
                    case DatabaseExecuteState.Update:
                        if (databaseTable == DatabaseTable.Artist)
                        {
                            cmd.CommandText = "Artist_UpdateImage";
                        }
                        else if (databaseTable == DatabaseTable.Group)
                        {
                            cmd.CommandText = "Group_UpdateImage";
                        }
                        break;
                    case DatabaseExecuteState.Delete:
                        if (databaseTable == DatabaseTable.Artist)
                        {
                            cmd.CommandText = "Artist_DeleteImage";
                        }
                        else if (databaseTable == DatabaseTable.Group)
                        {
                            cmd.CommandText = "Group_DeleteImage";
                        }
                        break;     
                }    
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                //khai báo các thông tin của tham số truyền vào
                if(DatabaseExecuteState == DatabaseExecuteState.Insert
                    || DatabaseExecuteState == DatabaseExecuteState.Delete)
                {
                    if(databaseTable == DatabaseTable.Artist)
                    {
                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = ownerID;
                    }   
                    else if (databaseTable == DatabaseTable.Group)
                    {
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = ownerID;
                    }                  
                }    
                if(DatabaseExecuteState != DatabaseExecuteState.Insert)
                {
                    cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = imageID;
                }    

                if(DatabaseExecuteState != DatabaseExecuteState.Delete)
                {
                    cmd.Parameters.Add("@ImageURL", SqlDbType.NVarChar).Value = imageURL;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                }    

                //mở chuỗi kết nối
                cnn.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            // dóng chuỗi kết nối
            finally
            {
                cnn.Close();
            }

        }       
    }
}
