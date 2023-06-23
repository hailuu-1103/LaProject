using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
        public async Task<string> GetAllAsync(string id)
        {
            return await nftsCollectionsService.GetAllAsync(id);
        }

		[HttpGet("GetCollectionCount")]
		public async Task<int> GetAllAsync()
		{
			return await nftsCollectionsService.GetCollectionCount();
		}
	}
}
