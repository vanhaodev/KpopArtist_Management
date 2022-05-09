using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.SQL.CUD
{
    public class ArtistCUD
    {
        public static Tuple<bool, int> Insert()
        {
            int artistID = 0;
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Artist_InsertBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StageName", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.StageName;
                    cmd.Parameters.Add("@RealName", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.RealName;
                    cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = QueryData.Instance.Artist.Gender;
                    cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = QueryData.Instance.Artist.BirthDay != null ? QueryData.Instance.Artist.BirthDay : DateTime.Now;
                    cmd.Parameters.Add("@BirthPlace", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.BirthPlace;
                    cmd.Parameters.Add("@DebutDay", SqlDbType.Date).Value = QueryData.Instance.Artist.DebutDay != null ? QueryData.Instance.Artist.DebutDay : DateTime.Now;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Description;
                    cmd.Parameters.Add("@FandomID", SqlDbType.Int).Value = QueryData.Instance.Artist.Fandom.FandomID > 0 ? QueryData.Instance.Artist.Fandom.FandomID : 0;
                    cmd.Parameters.Add("@Height", SqlDbType.Float).Value = QueryData.Instance.Artist.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = QueryData.Instance.Artist.Weight;
                    cmd.Parameters.Add("@LabelID", SqlDbType.Int).Value = QueryData.Instance.Artist.Label.LabelID > 0 ? QueryData.Instance.Artist.Label.LabelID : 0;
                    con.Open();

                    artistID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    QueryData.Instance.Artist.ArtistID = artistID;

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }                   
                }
                
                //IMAGE
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_InsertImage", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = artistID;
                        cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistImage_Add[i].ImageID;
                        cmd.Parameters.Add("@ImageURL", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.ArtistImage_Add[i].Description;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }

                //GROUP
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_InsertGroup", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = artistID;
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //SONG
                for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_InsertSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = artistID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistSong_Add[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //SNS
                using (SqlCommand cmd = new SqlCommand("Artist_InsertSNS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = artistID;
                    cmd.Parameters.Add("@Youtube", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Youtube;
                    cmd.Parameters.Add("@Instagram", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Instagram;
                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Facebook;
                    cmd.Parameters.Add("@Twitter", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Twitter;
                    cmd.Parameters.Add("@Tiktok", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Tiktok;
                    cmd.Parameters.Add("@Vlive", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Vlive;
                    cmd.Parameters.Add("@AppleMusic", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.AppleMusic;
                    cmd.Parameters.Add("@Spotify", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Spotify;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Website;

                    cmd.ExecuteNonQuery();

                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                
                return Tuple.Create(true, artistID);
            }
            catch(Exception e)
            {
                Console.WriteLine($"=====================ARTIST INSERT==========================\n" +
                    $"{e}" +
                    $"\n================================================================");
                return Tuple.Create(false, 0);
            }
        }

        /// <summary>
        /// KHI UPDATE
        /// Dữ liệu = Insert - Delete
        /// </summary>
        public static bool Update()
        {
            SqlConnection con = new SqlConnection(DatabaseManager.connectString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("Artist_UpdateBase", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                    cmd.Parameters.Add("@StageName", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.StageName;
                    cmd.Parameters.Add("@RealName", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.RealName;
                    cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = QueryData.Instance.Artist.Gender;
                    cmd.Parameters.Add("@BirthDay", SqlDbType.Date).Value = QueryData.Instance.Artist.BirthDay != null ? QueryData.Instance.Artist.BirthDay : DateTime.Now;
                    cmd.Parameters.Add("@BirthPlace", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.BirthPlace;
                    cmd.Parameters.Add("@DebutDay", SqlDbType.Date).Value = QueryData.Instance.Artist.DebutDay != null ? QueryData.Instance.Artist.DebutDay : DateTime.Now;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Description;
                    cmd.Parameters.Add("@FandomID", SqlDbType.Int).Value = QueryData.Instance.Artist.Fandom.FandomID > 0 ? QueryData.Instance.Artist.Fandom.FandomID : 0;
                    cmd.Parameters.Add("@Height", SqlDbType.Float).Value = QueryData.Instance.Artist.Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = QueryData.Instance.Artist.Weight;
                    cmd.Parameters.Add("@LabelID", SqlDbType.Int).Value = QueryData.Instance.Artist.Label.LabelID > 0 ? QueryData.Instance.Artist.Label.LabelID : 0;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                //DELETE IMAGE
               // Console.WriteLine(QueryData.Instance.Artist.ArtistImage_Delete[0].ImageID + " =============================" + QueryData.Instance.Artist.ArtistID);
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Delete.Count; i++)
                {
                    
                    using (SqlCommand cmd = new SqlCommand("Artist_DeleteImage", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                        cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistImage_Delete[i].ImageID;

                        Console.WriteLine(QueryData.Instance.Artist.ArtistImage_Delete[i].ImageID + " =============================" + QueryData.Instance.Artist.ArtistID);
                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //ADD IMAGE
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_InsertImage", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                        cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistImage_Add[i].ImageID;
                        cmd.Parameters.Add("@ImageURL", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.ArtistImage_Add[i].Description;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //DELETE GROUP
                //GROUP
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Delete.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_DeleteGroup", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistGroup_Delete[i].GroupID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //ADD GROUP
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_InsertGroup", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //DELETE SONG
                for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Delete.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_DeleteSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistSong_Delete[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //ADD SONG
                for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("Artist_InsertSong", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                        cmd.Parameters.Add("@SongID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistSong_Add[i].SongID;

                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
                //EDIT SNS
                using (SqlCommand cmd = new SqlCommand("Artist_UpdateSNS", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;
                    cmd.Parameters.Add("@Youtube", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Youtube;
                    cmd.Parameters.Add("@Instagram", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Instagram;
                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Facebook;
                    cmd.Parameters.Add("@Twitter", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Twitter;
                    cmd.Parameters.Add("@Tiktok", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Tiktok;
                    cmd.Parameters.Add("@Vlive", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Vlive;
                    cmd.Parameters.Add("@AppleMusic", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.AppleMusic;
                    cmd.Parameters.Add("@Spotify", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Spotify;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = QueryData.Instance.Artist.Sns.Website;

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
                    using (SqlCommand cmd = new SqlCommand("Artist_Hide", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;

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
                    using (SqlCommand cmd = new SqlCommand("Artist_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ArtistID", SqlDbType.Int).Value = QueryData.Instance.Artist.ArtistID;

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
