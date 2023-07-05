namespace LaAPI.Services
{
    using LaAPI.DTO;
    using LaAPI.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class NftCollectionsService
    {
        private readonly Dictionary<string, NftsCollectionDTO> cachedNftCollectionDTO = new();
        private readonly IMongoCollection<BsonDocument>        nftCollection;
        public NftCollectionsService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client   = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            this.nftCollection = database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsCollectionsName);
        }
        private BsonDocument[] RetrieveDocuments()
        {
            // Query the collection and retrieve documents
            var documents = this.nftCollection.Find(new BsonDocument()).ToList();
            return documents.ToArray();
        }
        public async Task<List<NftsCollectionDTO>> GetAllAsync()
        {
            var documents = this.RetrieveDocuments();
            var result    = new List<NftsCollectionDTO>();
            foreach (var document in documents)
            {
                var dto = new NftsCollectionDTO
                {
                    id   = document.GetValue("_id").AsString,
                    name = document.GetValue("name").AsString
                };
                if (document.TryGetValue("primary_asset_contracts", out var primaryAssetContracts) &&
                    primaryAssetContracts is BsonDocument primaryAssetContractsDoc &&
                    primaryAssetContractsDoc.TryGetValue("image_url", out var imageUrl))
                {
                    var imageUrlValue = imageUrl.AsString;

                    dto.image_url = imageUrlValue;
                }

                result.Add(dto);
                this.cachedNftCollectionDTO.TryAdd(dto.id, dto);
            }

            return result;
        }
        public async Task<NftsCollectionDTO> GetNftCollectionByCollection(string collection) { return this.cachedNftCollectionDTO[collection]; }
    }
}