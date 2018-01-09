using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMusicApp.WebApi.Services;
using MyMusicApp.WebApi.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IMusicLibrary _service;

        public ValuesController(IMusicLibrary service)
        {
            _service = service;
        }

        // GET api/values
        /// <summary>
        /// Get this instance. COUCOU
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _service.GetSongs();
        }

        // GET api/values/5
        [HttpGet("genre")]
        public IEnumerable<Song> Get(string genre)
        {
            return _service.GetSongs(genre);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
