namespace LaAPI.Services
{
    using LaAPI.DTO;
    using LaAPI.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class SaleFilter
    {
        public int    token_id { get; set; }
        public string slug     { get; set; }
    }

    public class NftSaleService
    {
        private readonly Dictionary<SaleFilter, List<NftsSaleDTO>> cachedNftSaleDto = new();
        private readonly IMongoCollection<BsonDocument>            nft;
        public NftSaleService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client   = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            this.nft = database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsSalesName);
        }
        public Task<List<NftsSaleDTO>> GetNftSaleByCollectionAsync(string collection, int id, int pageNumber, int pageSize)
        {
            var saleFilter = new SaleFilter()
            {
                token_id = id,
                slug     = collection
            };
            return Task.FromResult(this.cachedNftSaleDto[saleFilter].Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }
        public async Task<List<NftsSaleDTO>> GetNftSaleByCollection(string collection, int id)
        {
            var saleFilter = new SaleFilter
            {
                token_id = id,
                slug     = collection
            };
            if (this.cachedNftSaleDto.TryGetValue(saleFilter, out var value)) return value.Where(nftSaleDto => nftSaleDto.token_id == id).ToList();
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id.slug", collection),
                Builders<BsonDocument>.Filter.Eq("id", id)
            );
            var projection = Builders<BsonDocument>.Projection
                .Include("id")
                .Include("_id.slug")
                .Include("price")
                .Include("usd_price")
                .Include("unit_token")
                .Include("from")
                .Include("to")
                .Include("time");

            var options = new FindOptions<BsonDocument>
            {
                Projection = projection
            };

            var cursor    = await this.nft.FindAsync(filter, options);
            var documents = await cursor.ToListAsync();

            var nftDto = documents.Select(document => new NftsSaleDTO
            {
                token_id   = document["id"].AsInt32,
                slug       = document["_id"]["slug"].AsString,
                price      = document["price"].AsDouble,
                usd_price  = document["usd_price"].AsDouble,
                unit_token = document["unit_token"].AsString,
                from       = document["from"].AsString,
                to         = document["to"].AsString,
                time       = document["time"].AsString,
            }).ToList();
            this.cachedNftSaleDto.Add(saleFilter, nftDto);

            return this.cachedNftSaleDto[saleFilter].Where(nftSaleDto => nftSaleDto.token_id == id).ToList();
        }
    }
}