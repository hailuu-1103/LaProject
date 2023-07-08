namespace LaProject.Controllers
{
    using LaProject.Models;
    using LaProject.Services;

    [Controller]
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        private readonly MongoDBService mongoDBService;
        public PlaylistController(MongoDBService service) { this.mongoDBService = service; }
        [HttpGet]
        public async Task<List<Playlist>> GetAsync() { return await this.mongoDBService.GetAsync(); }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Playlist playlist)
        {
            await this.mongoDBService.CreateAsync(playlist);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPlaylistAsync(string id, [FromBody] string movieId)
        {
            await this.mongoDBService.AddToPlaylistAsync(id, movieId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await this.mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
}