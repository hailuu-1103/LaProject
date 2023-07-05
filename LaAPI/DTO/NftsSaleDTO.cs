namespace LaAPI.DTO
{
    public class NftsSaleDTO
    {
        public int    token_id   { get; set; }
        public string slug       { get; set; }
        public double price      { get; set; }
        public double usd_price  { get; set; }
        public string unit_token { get; set; }
        public string from       { get; set; }
        public string to         { get; set; }
        public string time       { get; set; }
    }
}