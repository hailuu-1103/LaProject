using LaProject.Models;
using LaProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaProject.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        private readonly MongoDBService mongoDBService;
        public PlaylistController(MongoDBService service)
        {
            this.mongoDBService = service;
        }
        [HttpGet]
        public async Task<List<Playlist>> GetAsync()
        {
            return await mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Playlist playlist)
        {
            await mongoDBService.CreateAsync(playlist);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPlaylistAsync(string id, [FromBody] string movieId)
        {
            await mongoDBService.AddToPlaylistAsync(id, movieId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
}
