using LaAPI.DTO;
using LaAPI.Models;
using LaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LaAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class NftCollectionsController : Controller
    {
        private readonly NftCollectionsService nftCollectionsService;
        public NftCollectionsController(NftCollectionsService service)
        {
            this.nftCollectionsService = service;
        }
		[HttpGet("GetAllCollections")]
		public async Task<ActionResult<List<NftsCollectionDTO>>> GetAllAsync()
		{
			var documents = await this.nftCollectionsService.GetAllAsync();

			var results = new List<NftsCollectionDTO>();
			// Map the BsonDocument array to NftsCollectionDto array

			foreach (var document in documents)
			{
				var dto = new NftsCollectionDTO()
				{
					id = document.GetValue("_id").AsString,
					name = document.GetValue("name").AsString,
				};
				if (document.TryGetValue("primary_asset_contracts", out var primaryAssetContracts) &&
					primaryAssetContracts is BsonDocument primaryAssetContractsDoc &&
					primaryAssetContractsDoc.TryGetValue("image_url", out var imageUrl))
				{
					string imageUrlValue = imageUrl.AsString;

					dto.image_url= imageUrlValue;
				}
				results.Add(dto);
			}

			return this.Ok(results.ToList());
		}

		[HttpGet("GetCollectionCount")]
		public async Task<int> GetCollectionCount()
		{
			var documents = await this.nftCollectionsService.GetAllAsync();
			
			return 0;
		}

	}
}
