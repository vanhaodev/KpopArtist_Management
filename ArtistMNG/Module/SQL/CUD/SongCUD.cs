using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL.CUD
{
    public class SongCUD
    {
        public static Tuple<bool, int> Insert()
        {
            int id = 0;
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Song_InsertBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Song.SongName;           
                    cmd.Parameters.Add("@ReleaseDay", SqlDbType.Date).Value = QueryData.Instance.Song.ReleaseDay != null ? QueryData.Instance.Song.ReleaseDay : DateTime.Now;
                    cmd.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = QueryData.Instance.Song.Genre;
                    cmd.Parameters.Add("@Producer", SqlDbType.NVarChar).Value = QueryData.Instance.Song.Producer;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Song.Description;
                    con.Open();

                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    QueryData.Instance.Song.SongID = id;

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return Tuple.Create(true, id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================SONG INSERT==========================\n" +
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
                using (SqlCommand cmd = new SqlCommand("Song_UpdateBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Song.SongID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Song.SongName;
                    cmd.Parameters.Add("@ReleaseDay", SqlDbType.Date).Value = QueryData.Instance.Song.ReleaseDay != null ? QueryData.Instance.Song.ReleaseDay : DateTime.Now;
                    cmd.Parameters.Add("@Genre", SqlDbType.NVarChar).Value = QueryData.Instance.Song.Genre;
                    cmd.Parameters.Add("@Producer", SqlDbType.NVarChar).Value = QueryData.Instance.Song.Producer;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Song.Description;
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
                Console.WriteLine($"=====================SONG UPDATE==========================\n" +
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
                using (SqlCommand cmd = new SqlCommand("Song_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Song.SongID;
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
                Console.WriteLine($"=====================SONG DELETE==========================\n" +
                                    $"{e}" +
                                    $"\n================================================================");
                return false;
            }
        }
    }
}
