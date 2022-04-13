using api.Models;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class DeleteSong
    {
        public void Delete(int id)
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();
            
            string stm =@"DELETE FROM song WHERE SongId = "" ";

             using var cmd = new MySqlCommand(stm, con);

             cmd.ExecuteNonQuery();
             
             con.Close();


        }
    }
}