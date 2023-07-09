namespace LaAPI.Services
{
    using LaAPI.DTO;
    using LaAPI.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class NftService
    {
        private readonly Dictionary<string, List<NftDto>> cachedNftDto = new();
        private readonly IMongoCollection<BsonDocument>   nft;
        public NftService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client   = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            this.nft = database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsName);
            database.GetCollection<BsonDocument>(mongoDbSettings.Value.NftsSalesName);
        }

        public Task<List<NftDto>> GetNftByCollectionAsync(string collection, int pageNumber, int pageSize)
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
                .Include("_id.slug")
                .Include("nft_rarity")
                .Include("nft_return")
                .Include("traits.trait_type")
                .Include("traits.trait_count")
                .Include("traits.value");

            var options = new FindOptions<BsonDocument>
            {
                Projection = projection
            };

            var cursor = await this.nft.FindAsync(filter, options);

            var documents = await cursor.ToListAsync();
            var listNftDto = documents.Select(document => new NftDto
            {
                image_url  = document.GetValue("image_url").AsString,
                token_id   = document["_id"]["token_id"].AsString,
                slug       = document["_id"]["slug"].AsString,
                nft_rarity = document["nft_rarity"].AsDouble,
                nft_return = this.GetNftReturn(document, "nft_return"),
                traits     = this.GetListTraits(document)
            }).ToList();

            this.cachedNftDto.Add(collection, listNftDto);


            return this.cachedNftDto[collection].Count;
        }
        public async Task<NftDto> GetNftByCollectionAndId(string collection, string id) { return this.cachedNftDto[collection].FirstOrDefault(dto => dto.token_id.Equals(id))!; }

        public Task<List<NftDto>> SortNftCollectionByParam(string collection, string param, int pageNumber, int pageSize)
        {
            if (this.cachedNftDto.TryGetValue(collection, out var listDto))
                this.cachedNftDto[collection] = param switch
                {
                    "rarity_asc" => listDto.OrderBy(dto => dto.nft_rarity).ToList(),
                    "rarity_desc" => listDto.OrderByDescending(dto => dto.nft_rarity).ToList(),
                    "return_asc" => listDto.OrderBy(dto => dto.nft_return).ToList(),
                    "return_desc" => listDto.OrderByDescending(dto => dto.nft_return).ToList(),
                    _ => this.cachedNftDto[collection]
                };

            return Task.FromResult(this.cachedNftDto[collection].Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());
        }
        private double GetNftReturn(BsonDocument document, string fieldName)
        {
            if (!document.Contains(fieldName)) return 0;
            var fieldValue = document[fieldName];
            if (fieldValue.IsInt32) return Convert.ToDouble(fieldValue.AsInt32);

            if (fieldValue.IsDouble) return fieldValue.AsDouble;

            return 0;
        }
        private List<Trait> GetListTraits(BsonValue document)
        {
            var traitsArray = document["traits"].AsBsonArray;

            return (from BsonDocument? traitDocument in traitsArray
                select new Trait { trait_type = traitDocument["trait_type"].AsString, trait_count = traitDocument["trait_count"].AsInt32, value = traitDocument["value"].AsString }).ToList();
        }
    }
}