using LaAPI.DTO;
using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LaAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class NftsSaleController : Controller
    {
        private readonly NftsSaleService nftsSaleService;
        public NftsSaleController(NftsSaleService service)
        {
            this.nftsSaleService = service;
        }
        [HttpGet("GetNftsSaleByCollectionAsync/{collection}/{id}/{pageNumber}/{pageSize}")]
        public async Task<List<NftsSaleDTO>> GetNftsSaleByCollectionAsync(string collection, int id, int pageNumber, int pageSize)
        {
            return await nftsSaleService.GetNftsSaleByCollectionAsync(collection, id, pageNumber, pageSize);
        }
		[HttpGet("GetNftsSaleByCollection/{collection}/{id}")]
		public async Task<List<NftsSaleDTO>> GetNftsSaleByCollection(string collection, int id)
		{
			return await nftsSaleService.GetNftsSaleByCollection(collection, id);
		}
	}
}
