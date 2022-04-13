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
        [EnableCors("Open Policy")]
        [HttpGet]
        public List<Song> Get()
        {
            List<Song> mySong = new List<Song>();
            ReadSong readSong = new ReadSong();
            return readSong.GetAll();
            
        }

        // GET: api/Songs -async/5
        [EnableCors("Open Policy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            List<Song> mySong = new List<Song>();
            ReadSong readSong = new ReadSong();
            return readSong.GetOne(id);
            
        }

        // POST: api/Songs -async // create
        [EnableCors("Open Policy")]
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            CreateSong createSong = new CreateSong();
            createSong.Create(song);
        }

        // PUT: api/Songs -async/5 // update and favorite
        [EnableCors("Open Policy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song song)
        {
            UpdateSong updateSong = new UpdateSong();
            updateSong.Update(song);
            updateSong.FavoriteUpdate(song);
        }

        // DELETE: api/Songs -async/5 // delete
        [EnableCors("Open Policy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteSong deleteSong = new DeleteSong();
            deleteSong.Delete(id);
        }
    }
}
