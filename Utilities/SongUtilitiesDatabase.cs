using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections.Generic;
using api.Models;
using api.interfaces;
using MySql.Data.MySqlClient;
namespace api.Utilities
{
    public class SongUtilitiesDatabase
    {

         public List<Song> playlist { get; set; }
         public void PrintPlaylist() { 
            List<Song> playlist = new List<Song>();

            ReadSong readSong = new ReadSong();
            playlist = readSong.GetAll();

            foreach (Song song in playlist) { // for every song in the playlist, write the song's ToString to the console
            //    if(song.Deleted != "y"){
                    Console.WriteLine(song.ToString());
            //   }

            }
          
        }

        public void AddSong() { 

            Song newSong = new Song(){SongTitle = PromptSongDetails(), SongTimestamp = DateTime.Now};
            CreateSong create = new CreateSong();
            create.Create(newSong);
        }

        public string PromptSongDetails() { // Ask user for title of the song to add
            Console.Clear();
            Console.WriteLine("What is the title of your song?");
            return Console.ReadLine();
        }

        public void DeleteSong() { 
            
            Console.WriteLine("What is the id of the song you would like to delete?");
            int IDToDelete =int.Parse(Console.ReadLine());
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();
            
            string stm =@$"Delete FROM song WHERE SongID = {IDToDelete};";

             using var cmd = new MySqlCommand(stm, con);

             cmd.ExecuteNonQuery();
             
             con.Close();
            
            
            
        }

        
        // public void EditSong()
        // {
        //     List<Song> playlist = new List<Song>();

        //     ReadSong readSong = new ReadSong();
        //     playlist = readSong.GetAll();

        //     PrintPlaylist();
        
        //     Console.WriteLine("What is the id of the song you would like to edit?");
        //     int idToUpdate = int.Parse(Console.ReadLine());

        //     Console.WriteLine("What is the title of the song");
        //     string titleToUpdate =Console.ReadLine();

        //     foreach (Song song in playlist) { // for every song in the playlist, write the song's ToString to the console
        //         if (song.SongID == idToUpdate){
        //             song.SongTitle = titleToUpdate;
        //             UpdateSong mySong = new UpdateSong();
        //             mySong.Update(song);
        //         }
        //     }
            
           

        // }
        public void FavoriteSong()
        {
            List<Song> playlist = new List<Song>();

            ReadSong readSong = new ReadSong();

            PrintPlaylist();

            Console.WriteLine("What is the id of the song you would like to edit");
            int idToFav = int.Parse(Console.ReadLine());

            foreach (Song song in playlist)
            {
                if (song.SongID == idToFav)
                {
                    song.FavoriteSong = "y";
                    UpdateSong mySong = new UpdateSong();
                    mySong.Update(song);
                }
            }
        }

       

    }
    }

    
