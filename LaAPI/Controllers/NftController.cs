namespace LaAPI.Controllers
{
    using LaAPI.DTO;
    using LaAPI.Services;
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    [Route("api/[controller]")]
    public class NftController : Controller
    {
        private readonly NftService nftService;
        public NftController(NftService service) { this.nftService = service; }
        [HttpGet("GetNftByCollection/{collection}/{pageNumber:int}/{pageSize:int}")]
        public async Task<List<NftDto>> GetNftByCollectionAsync(string collection, int pageNumber, int pageSize)
        {
            return await this.nftService.GetNftByCollectionAsync(collection, pageNumber, pageSize);
        }
        [HttpGet("GetTotalNftByCollection/{collection}")]
        public async Task<int> GetTotalNftByCollection(string collection) { return await this.nftService.GetTotalNftByCollection(collection); }
        [HttpGet("GetNftByCollectionAndId/{collection}/{id}")]
        public async Task<NftDto> GetNftByCollectionAndId(string collection, string id) { return await this.nftService.GetNftByCollectionAndId(collection, id); }
    }
}