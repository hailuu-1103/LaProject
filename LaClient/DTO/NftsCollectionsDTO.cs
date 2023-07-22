namespace LaAPI.DTO
{
    public class NftCollectionDTO
    {
        public string id                    { get; set; }
        public string name                  { get; set; }
        public string image_url             { get; set; }
        public double nft_collection_return { get; set; }
        public double twitter_followers     { get; set; }
        public double avg_tweet_interaction { get; set; }
        public double avg_tweet_attention   { get; set; }
        public Stats  stats                 { get; set; }
    }

    public class Stats
    {
        public double total_sales { get; set; }
        public double num_owners  { get; set; }
    }
}