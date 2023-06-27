using LaAPI.DTO;
using LaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaAPI.Services
{
    public class SaleFilter
    {
        public int token_id { get; set; }
        public string slug { get; set; }
    }
    public class NftsSaleService
    {
        private readonly IMongoCollection<BsonDocument> nfts;
        private Dictionary<SaleFilter, List<NftsSaleDTO>> cachedNftsSaleDTO = new();
        public NftsSaleService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            nfts = database.GetCollection<BsonDocument>(mongoDBSettings.Value.NftsSalesName);
        }
        public async Task<List<NftsSaleDTO>> GetNftsSaleByCollectionAsync(string collection, int id, int pageNumber, int pageSize)
        {
            var saleFilter = new SaleFilter()
            {
                token_id = id,
                slug = collection,
            };
            return cachedNftsSaleDTO[saleFilter].Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<List<NftsSaleDTO>> GetNftsSaleByCollection(string collection, int id)
        {
            var saleFilter = new SaleFilter()
            {
                token_id = id,
                slug = collection,
            };
            if (!cachedNftsSaleDTO.ContainsKey(saleFilter))
            {
                var filter = Builders<BsonDocument>.Filter.And(
                     Builders<BsonDocument>.Filter.Eq("_id.slug", collection),
                     Builders<BsonDocument>.Filter.Eq("id", id)
                 );
                var projection = Builders<BsonDocument>.Projection
                    .Include("id")
                    .Include("_id.slug")
                    .Include("price")
                    .Include("unit_token")
                    .Include("from")
                    .Include("to")
                    .Include("time");

                var options = new FindOptions<BsonDocument>
                {
                    Projection = projection
                };

                var cursor = await nfts.FindAsync(filter, options);
                var documents = await cursor.ToListAsync();

                var nftsDTO = documents.Select(document => new NftsSaleDTO
                {
                    token_id = document["id"].AsInt32,
                    slug = document["_id"]["slug"].AsString,
                    price = document["price"].AsDouble,
                    unit_token = document["unit_token"].AsString,
                    from = document["from"].AsString,
                    to = document["to"].AsString,
                    time = document["time"].AsString,
                }).ToList();
                cachedNftsSaleDTO.Add(saleFilter, nftsDTO);
            }
            

            return cachedNftsSaleDTO[saleFilter].Where(nftSaleDTO => nftSaleDTO.token_id == id).ToList();
        }
    }
}
