namespace LaAPI.DTO
{
    public class NftsSaleDTO
    {
        public int      token_id   { get; set; }
        public float    price      { get; set; }
        public float    usd_price  { get; set; }
        public string   unit_token { get; set; }
        public string   from       { get; set; }
        public string   to         { get; set; }
        public DateTime time       { get; set; }
    }
}