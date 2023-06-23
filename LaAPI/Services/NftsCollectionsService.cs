using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class NftsCollectionsService
    {
        private readonly IMongoCollection<BsonDocument> nftsCollection;
        public NftsCollectionsService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            nftsCollection = database.GetCollection<BsonDocument>(mongoDBSettings.Value.NftsCollectionsName);
        }
        private BsonDocument[] RetrieveDocuments()
        {
			// Query the collection and retrieve documents
			var documents = nftsCollection.Find(new BsonDocument()).ToList();
			return documents.ToArray();
		}
        public async Task<string> GetAllAsync(string id)
        {
            var result = RetrieveDocuments();
            foreach(var document in result)
            {
                return document[id].AsString;
            }
            return null;
        }
        public async Task<int> GetCollectionCount()
        {
            var documents = this.RetrieveDocuments();
            return documents.Length;
        }
    }
}
