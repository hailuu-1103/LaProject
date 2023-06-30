using LaAPI.DTO;
using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class NftService
    {
        private readonly IMongoCollection<BsonDocument>    nft;
        private readonly IMongoCollection<BsonDocument>    nftSale;
        private readonly Dictionary<string, List<NftsDTO>> cachedNftDto = new();
        public NftService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            this.nft         = database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsName);
            this.nftSale = database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsSalesName);
        }

		public Task<List<NftsDTO>> GetNftByCollectionAsync(string collection, int pageNumber, int pageSize)
        {
            return Task.FromResult(this.cachedNftDto[collection].Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }
        public async Task<int> GetTotalNftByCollection(string collection)
        {

            // create cached
            if (this.cachedNftDto.TryGetValue(collection, out var value)) return value.Count;
            var filter = Builders<BsonDocument>.Filter.Eq("_id.slug", collection);
            var projection = Builders<BsonDocument>.Projection
                .Include("image_url")
                .Include("_id.token_id")
                .Include("_id.slug");

            var options = new FindOptions<BsonDocument>
            {
                Projection = projection
            };

            var cursor = await this.nft.FindAsync(filter, options);
                
            var documents  = await cursor.ToListAsync();
            var listNftDto = documents.Select(document => new NftsDTO() { image_url = document.GetValue("image_url").AsString, token_id = document["_id"]["token_id"].AsString, slug = document["_id"]["slug"].AsString }).ToList();

            this.cachedNftDto.Add(collection, listNftDto);


            return this.cachedNftDto[collection].Count;
        }
    }
}
