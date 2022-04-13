using System.Collections.Generic;
using api.Models;
namespace api.interfaces
{
    public interface IReadSong
    {
        public List<Song> GetAll();
        public Song GetOne(int id);
    }
}