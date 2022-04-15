using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.database;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/Songs -async
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            System.Console.WriteLine("we are here");
            List<Song> mySong = new List<Song>();
            ReadSong readSong = new ReadSong();
            return readSong.GetAll();
            
        }

        // GET: api/Songs -async/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            List<Song> mySong = new List<Song>();
            ReadSong readSong = new ReadSong();
            return readSong.GetOne(id);
            
        }

        // POST: api/Songs -async // create
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            CreateSong createSong = new CreateSong();
            createSong.Create(song);
        }

        // PUT: api/Songs -async/5 // update and favorite
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] string song)
        {
            UpdateSong updateSong = new UpdateSong();
            Song s = new Song(){SongTitle = song};
            updateSong.FavoriteUpdate(s);
        }

        // DELETE: api/Songs -async/5 // delete
        [EnableCors("AnotherPolicy")]
        [HttpDelete ("{SongTitle}")]
        public void Delete(string SongTitle)
        {
            DeleteSong deleteSong = new DeleteSong();
            deleteSong.Delete(SongTitle);
        }
    }
}
