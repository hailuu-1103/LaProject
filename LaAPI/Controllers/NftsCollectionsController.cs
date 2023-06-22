using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class NftsCollectionsController : Controller
    {
        private readonly NftsCollectionsService nftsCollectionsService;
        public NftsCollectionsController(NftsCollectionsService service)
        {
            this.nftsCollectionsService = service;
        }
        [HttpGet("GetAllCollections")]
        public async Task<List<NftsCollection>> GetAllAsync()
        {
            return await nftsCollectionsService.GetAllAsync();
        }
    }
}
