using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL.CUD
{
    public class FandomCUD
    {
        public static Tuple<bool, int> Insert()
        {
            int id = 0;
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Fandom_InsertBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Fandom.FandomName;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Fandom.Description;
                    con.Open();

                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    QueryData.Instance.Fandom.FandomID = id;

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return Tuple.Create(true, id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================FANDOM INSERT==========================\n" +
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
                using (SqlCommand cmd = new SqlCommand("Fandom_UpdateBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FandomID", SqlDbType.Int).Value = QueryData.Instance.Fandom.FandomID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Fandom.FandomName;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Fandom.Description;
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
                Console.WriteLine($"=====================FANDOM UPDATE==========================\n" +
                                    $"{e}" +
                                    $"\n================================================================");
                return false;
            }
        }
    }
}
