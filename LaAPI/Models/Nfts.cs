namespace LaAPI.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System.Text.Json.Serialization;
    public class NftsTrait
    {
        public string trait_type { get; set; }
        public string display_type { get; set; }
        public string max_value { get; set; }
        public int trait_count { get; set; } 
        public string order { get; set; }
        public string value { get; set; }
    }
    public class NftsId
    {
        public string token_id { get; set; } = null!;
        public string slug { get; set; }
    }
    public class Nfts
    {
        [BsonId]
        public NftsId? Id { get; set; }

        public NftsTrait[] traits { get; set; } = null!;
        public string image_url { get; set; }
    }
}
