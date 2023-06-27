using LaAPI.DTO;
using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class NftsService
    {
        private readonly IMongoCollection<BsonDocument> nfts;
        private readonly IMongoCollection<BsonDocument> nftsSale;
        private Dictionary<string, List<NftsDTO>> cachedNftsDTO = new Dictionary<string,List<NftsDTO>>();
        public NftsService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            nfts = database.GetCollection<BsonDocument>(mongoDBSettings.Value.NftsName);
            nftsSale = database.GetCollection<BsonDocument>(mongoDBSettings.Value.NftsSalesName);
        }

		public async Task<List<NftsDTO>> GetNftsByCollectionAsync(string collection, int pageNumber, int pageSize)
        {
            return cachedNftsDTO[collection].Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<int> GetTotalNftsByCollection(string collection)
        {

            // create cached
            if (!cachedNftsDTO.ContainsKey(collection))
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id.slug", collection);
                var projection = Builders<BsonDocument>.Projection
                    .Include("image_url")
                    .Include("_id.token_id")
                    .Include("_id.slug");

                var options = new FindOptions<BsonDocument>
                {
                    Projection = projection
                };

                var cursor = await nfts.FindAsync(filter, options);
                
                var documents = await cursor.ToListAsync();
                var listNftDTO = new List<NftsDTO>();
                foreach ( var document in documents)
                {
                    var nftsDTO = new NftsDTO()
                    {
                        image_url = document.GetValue("image_url").AsString,
                        token_id = document["_id"]["token_id"].AsString,
                        slug = document["_id"]["slug"].AsString
                    };

                    listNftDTO.Add(nftsDTO);
                }
               
                cachedNftsDTO.Add(collection, listNftDTO);
            }


            return cachedNftsDTO[collection].Count;
        }
    }
}
