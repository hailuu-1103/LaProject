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
        public Task<List<NftsCollectionDTO>> GetAllAsync()
        {
            var documents = this.RetrieveDocuments();
            var result    = new List<NftsCollectionDTO>();
            foreach (var document in documents)
            {
                var dto = new NftsCollectionDTO
                {
                    id   = document.GetValue("_id").AsString,
                    name = document.GetValue("name").AsString,
                    nft_collection_return = this.GetDynamicFieldInDocument(document, "nft_collection_return")
                };
                if (document.TryGetValue("primary_asset_contracts", out var primaryAssetContracts) &&
                    primaryAssetContracts is BsonDocument primaryAssetContractsDoc &&
                    primaryAssetContractsDoc.TryGetValue("image_url", out var imageUrl))
                {
                    var imageUrlValue = imageUrl.AsString;

                    dto.image_url = imageUrlValue;
                }

                if (document.TryGetValue("stats", out var stats))
                    dto.stats = new Stats
                    {
                        total_sales = this.GetDynamicFieldInValue(stats, "total_sales"),
                        num_owners  = this.GetDynamicFieldInValue(stats, "num_owners")
                    };
                dto.twitter_followers = this.GetDynamicFieldInDocument(document, "twitter_followers");
                dto.avg_tweet_interaction = this.GetDynamicFieldInDocument(document, "avg_tweet_interaction");
                dto.avg_tweet_attention = this.GetDynamicFieldInDocument(document, "avg_tweet_attention");
                result.Add(dto);
                this.cachedNftCollectionDTO.TryAdd(dto.id, dto);
            }

            return Task.FromResult(result);
        }
        public Task<NftsCollectionDTO> GetNftCollectionByCollection(string collection) { return Task.FromResult(this.cachedNftCollectionDTO[collection]); }

        public Task<NftsCollectionDTO> GetTopSaleNftCollection() { return Task.FromResult(this.cachedNftCollectionDTO.Values.MaxBy(dto => dto.stats.total_sales)!); }

        public Task<NftsCollectionDTO> GetTopOwnerNftCollection() { return Task.FromResult(this.cachedNftCollectionDTO.Values.MaxBy(dto => dto.stats.num_owners)!); }

        public Task<NftsCollectionDTO> GetTopReturnNftCollection()
        {
            return Task.FromResult(this.cachedNftCollectionDTO.Values.MaxBy(dto => dto.nft_collection_return))!;
        }
        public Task<List<NftsCollectionDTO>> SortByCollectionReturn()
        {
            return Task.FromResult(this.cachedNftCollectionDTO.Values.ToList().OrderBy(dto => dto.nft_collection_return).ToList());
        }
        private double GetDynamicFieldInValue(BsonValue document, string fieldName)
        {
            var fieldValue = document[fieldName];
            if (fieldValue.IsInt32) return Convert.ToDouble(fieldValue.AsInt32);

            if (fieldValue.IsDouble) return fieldValue.AsDouble;

            return 0;
        }

        private double GetDynamicFieldInDocument(BsonDocument document, string fieldName)
        {
            if (!document.Contains(fieldName)) return 0;
            var fieldValue = document[fieldName];
            if (fieldValue.IsInt32) return Convert.ToDouble(fieldValue.AsInt32);

            if (fieldValue.IsDouble) return fieldValue.AsDouble;

            return 0;
        }
    }
}