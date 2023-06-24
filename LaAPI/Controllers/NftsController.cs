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
        [HttpGet]
        public async Task<List<string>> GetNftCountAsync()
        {
            var nfts = await nftsService.GetAsync();
            var nftsDistinct = nfts.DistinctBy(nfts => nfts.Id.token_id).ToList();
			var result = new List<string>();
            foreach (var nft in nftsDistinct)
            {
                result.Add(nft.Id.token_id);
            }
            return result;
        }
    }
}
