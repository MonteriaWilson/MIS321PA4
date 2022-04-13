using System;
namespace api.Models
{
    public class Song
    {
        public int SongID {get;set;}
        public string SongTitle {get;set;}
        public DateTime SongTimeStamp {get;set;}
        public string Deleted {get;set;}
        public string Favorite {get;set;}

         public override string ToString() 
        {
            return SongTitle + " (ID: " + SongID + ", Added " + SongTimeStamp + ")";
        }
    }
}