using System.Collections.Generic;
using api.interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.database
{
    public class ReadSong : IReadSong
    {
        public List<Song> GetAll()
        {
             List<Song> playlist = new List<Song>();


            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"Select * from song order by SongTimeStamp desc; ";

            using var cmd = new MySqlCommand(stm, con);

             MySqlDataReader rdr =cmd.ExecuteReader();


            while(rdr.Read())
            {
                Song temp = new Song(){SongID= rdr.GetInt16(0),SongTitle=rdr.GetString(1), SongTimeStamp=rdr.GetDateTime(2)};
                playlist.Add(temp);
            }

           con.Close();
           //return the song list

           return playlist;
        }

        public Song GetOne(int id)
        {
            throw new System.NotImplementedException();
        }
        
    }
}