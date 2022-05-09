using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL.CUD
{
    public class GroupCUD
    {
        public static Tuple<bool, int> Insert()
        {
            int id = 0;
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Group_InsertBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Group.GroupName;
                    cmd.Parameters.Add("@DebutDay", SqlDbType.Date).Value = QueryData.Instance.Group.DebutDay != null ? QueryData.Instance.Group.DebutDay : DateTime.Now;                   
                    cmd.Parameters.Add("@FandomID", SqlDbType.Int).Value = QueryData.Instance.Group.Fandom.FandomID > 0 ? QueryData.Instance.Group.Fandom.FandomID : 0;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Description;
                    cmd.Parameters.Add("@LabelID", SqlDbType.Int).Value = QueryData.Instance.Artist.Label.LabelID > 0 ? QueryData.Instance.Group.Label.LabelID : 0;
                    con.Open();

                    id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    QueryData.Instance.Group.GroupID = id;

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                
                //SONG
                for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Group_InsertSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupSong_Add[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //SNS
                using (SqlCommand cmd = new SqlCommand("Group_InsertSNS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Youtube", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Youtube;
                    cmd.Parameters.Add("@Instagram", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Instagram;
                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Facebook;
                    cmd.Parameters.Add("@Twitter", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Twitter;
                    cmd.Parameters.Add("@Tiktok", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Tiktok;
                    cmd.Parameters.Add("@Vlive", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Vlive;
                    cmd.Parameters.Add("@AppleMusic", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.AppleMusic;
                    cmd.Parameters.Add("@Spotify", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Spotify;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Website;

                    cmd.ExecuteNonQuery();

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

                return Tuple.Create(true, id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"=====================GROUP INSERT==========================\n" +
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
                using (SqlCommand cmd = new SqlCommand("Group_UpdateBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = QueryData.Instance.Group.GroupName;
                    cmd.Parameters.Add("@DebutDay", SqlDbType.Date).Value = QueryData.Instance.Group.DebutDay != null ? QueryData.Instance.Group.DebutDay : DateTime.Now;
                    cmd.Parameters.Add("@FandomID", SqlDbType.Int).Value = QueryData.Instance.Group.Fandom.FandomID > 0 ? QueryData.Instance.Group.Fandom.FandomID : 0;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Description;
                    cmd.Parameters.Add("@LabelID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID > 0 ? QueryData.Instance.Group.Label.LabelID : 0;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }               
                //DELETE SONG
                for (int i = 0; i < QueryData.Instance.Group.GroupSong_Delete.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Group_DeleteSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupSong_Delete[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //ADD SONG
                for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Group_InsertSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupSong_Add[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //UPDATE SNS
                using (SqlCommand cmd = new SqlCommand("Group_UpdateSNS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID;
                    cmd.Parameters.Add("@Youtube", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Youtube;
                    cmd.Parameters.Add("@Instagram", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Instagram;
                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Facebook;
                    cmd.Parameters.Add("@Twitter", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Twitter;
                    cmd.Parameters.Add("@Tiktok", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Tiktok;
                    cmd.Parameters.Add("@Vlive", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Vlive;
                    cmd.Parameters.Add("@AppleMusic", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.AppleMusic;
                    cmd.Parameters.Add("@Spotify", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Spotify;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = QueryData.Instance.Group.Sns.Website;

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
                Console.WriteLine($"====================ARTIST UPDATE===========================\n" +
                    $"{e}" +
                    $"\n================================================================");
                return false;
            }
        }
        public static bool Delete(DatabaseExecuteState databaseExecuteState)
        {
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);

            try
            {
                if (databaseExecuteState == DatabaseExecuteState.Hide)
                {
                    using (SqlCommand cmd = new SqlCommand("Group_Hide", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                else if (databaseExecuteState == DatabaseExecuteState.Delete)
                {
                    using (SqlCommand cmd = new SqlCommand("Group_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Group.GroupID;

                        con.Open();
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
                Console.WriteLine($"====================ARTIST DELETE - HIDE===========================\n" +
                    $"{e}" +
                    $"\n================================================================");
                return false;
            }
        }
    }
}
