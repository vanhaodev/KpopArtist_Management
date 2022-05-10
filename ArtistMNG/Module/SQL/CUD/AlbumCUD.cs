using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL.CUD
{
    public class AlbumCUD
    {
        public static Tuple<bool, int> Insert()
        {
            int id = 0;
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Album_InsertBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Album.AlbumName;
                    cmd.Parameters.Add("@ReleaseDay", SqlDbType.Date).Value = QueryData.Instance.Album.ReleaseDay != null ? QueryData.Instance.Album.ReleaseDay : DateTime.Now;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Album.Description;
                    con.Open();

                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    QueryData.Instance.Album.AlbumID = id;

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                //SONG
                for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Album_InsertSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumSong_Add[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                return Tuple.Create(true, id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================AlbumSONG INSERT==========================\n" +
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
                using (SqlCommand cmd = new SqlCommand("Album_UpdateBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Album.AlbumName;
                    cmd.Parameters.Add("@ReleaseDay", SqlDbType.Date).Value = QueryData.Instance.Album.ReleaseDay != null ? QueryData.Instance.Album.ReleaseDay : DateTime.Now;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Album.Description;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                //DELETE SONG
                for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Delete.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Album_DeleteSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumSong_Delete[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //ADD SONG
                for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Album_InsertSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@aLBUMID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumSong_Add[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================AlbumSONG UPDATE==========================\n" +
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
                using (SqlCommand cmd = new SqlCommand("Album_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = QueryData.Instance.Album.AlbumID;                  
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
                Console.WriteLine($"=====================Album DELETE==========================\n" +
                                    $"{e}" +
                                    $"\n================================================================");
                return false;
            }
        }
    }
}
