using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class NftsCollectionsService
    {
        private readonly IMongoCollection<NftsCollection> nftsCollection;
        public NftsCollectionsService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            nftsCollection = database.GetCollection<NftsCollection>(mongoDBSettings.Value.NftsCollectionsName);
        }
        public async Task<List<NftsCollection>> GetAllAsync()
        {
            var result = await nftsCollection.Find(new BsonDocument()).ToListAsync();
            return result;
        }
    }
}
