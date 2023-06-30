using LaAPI.DTO;
using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LaAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class NftController : Controller
    {
        private readonly NftService nftService;
        public NftController(NftService service)
        {
            this.nftService = service;
        }
        [HttpGet("GetNftByCollection/{collection}/{pageNumber:int}/{pageSize:int}")]
        public async Task<List<NftsDTO>> GetNftByCollectionAsync(string collection, int pageNumber, int pageSize)
        {
            return await this.nftService.GetNftByCollectionAsync(collection, pageNumber, pageSize);
        }
		[HttpGet("GetTotalNftByCollection/{collection}")]
		public async Task<int> GetTotalNftByCollection(string collection)
		{
			return await this.nftService.GetTotalNftByCollection(collection);
		}
	}
}
