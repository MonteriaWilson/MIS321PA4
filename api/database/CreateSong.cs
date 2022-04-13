using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.interfaces;
using api.Models;

namespace api.database
{
    public class CreateSong : ICreateSong
    {
         public static void CreateSongTable()
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE song (SongId INTEGER PRIMARY KEY AUTO_INCREMENT, SongTitle varchar(50), SongTimeStamp DateTime, Favorite varchar(1));";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }
            public void Create(Song song)
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO song(SongTitle, SongTimeStamp, Favorite) VALUES(@SongTitle, @SongTimeStamp, @Favorite)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
            cmd.Parameters.AddWithValue("@SongTimeStamp", song.SongTimeStamp);
            cmd.Parameters.AddWithValue("@Favorite", song.Favorite);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
              
        }
        }
    }
