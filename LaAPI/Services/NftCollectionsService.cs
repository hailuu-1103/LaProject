using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class NftCollectionsService
    {
        private readonly IMongoCollection<BsonDocument> nftCollection;
        public NftCollectionsService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            this.nftCollection = database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsCollectionsName);
        }
        private BsonDocument[] RetrieveDocuments()
        {
			// Query the collection and retrieve documents
			var documents = this.nftCollection.Find(new BsonDocument()).ToList();
			return documents.ToArray();
		}
        public async Task<BsonDocument[]> GetAllAsync()
        {
            var result = this.RetrieveDocuments();
            return result;
        }
        public Task<int> GetCollectionCount()
        {
            var documents = this.RetrieveDocuments();
            return Task.FromResult(documents.Length);
        }
    }
}
