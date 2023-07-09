namespace LaAPI.Controllers
{
    using LaAPI.DTO;
    using LaAPI.Services;
    using Microsoft.AspNetCore.Mvc;

    [Controller]
    [Route("api/[controller]")]
    public class NftCollectionsController : Controller
    {
        private readonly NftCollectionsService nftCollectionsService;
        public NftCollectionsController(NftCollectionsService service) { this.nftCollectionsService = service; }
        [HttpGet("GetAllCollections")]
        public async Task<List<NftsCollectionDTO>> GetAllAsync() { return await this.nftCollectionsService.GetAllAsync(); }

        [HttpGet("GetNftCollectionByCollection/{collection}")]
        public async Task<NftsCollectionDTO> GetNftCollectionByCollection(string collection) { return await this.nftCollectionsService.GetNftCollectionByCollection(collection); }

        [HttpGet("GetTopSaleNftCollection")]
        public async Task<NftsCollectionDTO> GetTopSaleNftCollection() { return await this.nftCollectionsService.GetTopSaleNftCollection(); }

        [HttpGet("GetTopOwnerNftCollection")]
        public async Task<NftsCollectionDTO> GetTopOwnerNftCollection() { return await this.nftCollectionsService.GetTopOwnerNftCollection(); }
    }
}