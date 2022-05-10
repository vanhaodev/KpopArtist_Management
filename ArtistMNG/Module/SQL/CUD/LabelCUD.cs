using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL.CUD
{
    public class LabelCUD
    {
        public static Tuple<bool, int> Insert()
        {
            int id = 0;
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Label_InsertBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Label.LabelName;
                    cmd.Parameters.Add("@Founder", SqlDbType.NVarChar).Value = QueryData.Instance.Label.Founder;
                    cmd.Parameters.Add("@Founded", SqlDbType.Date).Value = QueryData.Instance.Label.Founded != null ? QueryData.Instance.Label.Founded : DateTime.Now;
                    cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = QueryData.Instance.Label.Location;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Label.Description;
                    con.Open();

                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    QueryData.Instance.Label.LabelID = id;

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return Tuple.Create(true, id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================LABEL INSERT==========================\n" +
                    $"{e}" +
                    $"\n================================================================");
                return Tuple.Create(false, 0);
            }

        }
        public static bool Update()
        {
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Label_UpdateBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LabelID", SqlDbType.Int).Value = QueryData.Instance.Label.LabelID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Label.LabelName;
                    cmd.Parameters.Add("@Founder", SqlDbType.NVarChar).Value = QueryData.Instance.Label.Founder;
                    cmd.Parameters.Add("@Founded", SqlDbType.Date).Value = QueryData.Instance.Label.Founded != null ? QueryData.Instance.Label.Founded : DateTime.Now;
                    cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = QueryData.Instance.Label.Location;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Label.Description;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================LABEL UPDATE==========================\n" +
                                    $"{e}" +
                                    $"\n================================================================");
                return false;
            }
        }
        public static bool Delete()
        {
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Label_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LabelID", SqlDbType.Int).Value = QueryData.Instance.Label.LabelID;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================LABEL DELETE==========================\n" +
                                    $"{e}" +
                                    $"\n================================================================");
                return false;
            }
        }
    }
}
