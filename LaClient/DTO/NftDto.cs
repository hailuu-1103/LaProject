namespace LaClient.DTO
{
    public class NftDto
    {
        public string token_id        { get; set; }
        public string slug            { get; set; }
        public string image_url       { get; set; }
        public string collection_name { get; set; }
        public double nft_rarity      { get; set; }
        public double nft_return      { get; set; }
    }
}