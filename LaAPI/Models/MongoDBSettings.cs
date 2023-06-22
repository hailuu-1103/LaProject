namespace LaAPI.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string NftsName { get; set; } = null!;
        public string NftsCollectionsName { get; set; } = null!;
        public string NftsSalesName { get; set; } = null!;
    }
}
