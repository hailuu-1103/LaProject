using LaAPI.DTO;
using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LaAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class NftsController : Controller
    {
        private readonly NftsService nftsService;
        public NftsController(NftsService service)
        {
            this.nftsService = service;
        }
        [HttpGet("GetNftByCollection/{collection}/{pageNumber}/{pageSize}")]
        public async Task<List<NftsDTO>> GetNftsByCollectionAsync(string collection, int pageNumber, int pageSize)
        {
            return await nftsService.GetNftsByCollectionAsync(collection, pageNumber, pageSize);
        }
		[HttpGet("GetTotalNftsByCollection/{collection}")]
		public async Task<int> GetTotalNftsByCollection(string collection)
		{
			return await nftsService.GetTotalNftsByCollection(collection);
		}
	}
}
