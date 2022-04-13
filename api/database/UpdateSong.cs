using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.Models;
namespace api.database
{
    public class UpdateSong
    {
        public static void UpdateSongTable()
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE TABLE IF EXISTS song";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
            con.Close();
            
        }

         public void Update(Song song)
        {

            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"UPDATE song SET SongTitle = @SongTitle Where SongId = @SongId;";


            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@SongId", song.SongID);
            cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);

            cmd.ExecuteNonQuery();
            con.Close();

           
        }
           public void FavoriteUpdate(Song song)
        {

            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"UPDATE song SET Favorite = @Favorite;";


            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@SongId", song.SongID);
            cmd.Parameters.AddWithValue("@Favorite", song.Favorite);

            cmd.ExecuteNonQuery();
            con.Close();

           
        }

    }
}