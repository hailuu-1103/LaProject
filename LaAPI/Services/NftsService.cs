using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class NftsService
    {
        private readonly IMongoCollection<Nfts> nfts;

        public NftsService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            nfts = database.GetCollection<Nfts>(mongoDBSettings.Value.NftsName);
        }
        public async Task<List<Nfts>> GetAsync()
        {
            var result = await nfts.Find(new BsonDocument()).ToListAsync();
            return result;
        }
    }
}
