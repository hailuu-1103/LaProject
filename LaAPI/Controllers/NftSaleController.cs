using LaAPI.DTO;
using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LaAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class NftSaleController : Controller
    {
        private readonly NftSaleService nftSaleService;
        public NftSaleController(NftSaleService service)
        {
            this.nftSaleService = service;
        }
        [HttpGet("GetNftSaleByCollectionAsync/{collection}/{id:int}/{pageNumber:int}/{pageSize:int}")]
        public async Task<List<NftsSaleDTO>> GetNftSaleByCollectionAsync(string collection, int id, int pageNumber, int pageSize)
        {
            return await this.nftSaleService.GetNftSaleByCollectionAsync(collection, id, pageNumber, pageSize);
        }
		[HttpGet("GetNftSaleByCollection/{collection}/{id:int}")]
		public async Task<List<NftsSaleDTO>> GetNftSaleByCollection(string collection, int id)
		{
			return await this.nftSaleService.GetNftSaleByCollection(collection, id);
		}
	}
}
