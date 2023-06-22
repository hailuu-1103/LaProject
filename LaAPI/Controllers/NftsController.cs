using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<Nfts>> GetAsync()
        {
            return await nftsService.GetAsync();
        }
    }
}
