namespace LaClient.Pages
{
    using System.Text.Json;
    using LaAPI.DTO;
    using LaClient.Materials;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private static readonly string     NftCollectionApiUrl = $"{ProjectStaticValue.Host}/api/NftCollections/";
        private                 HttpClient client;
        private                 string     NftCollectionApiHandler;

        public List<NftCollectionDTO>? NftCollectionDto;

        private JsonSerializerOptions? options;
        public  NftCollectionDTO?      TopOwnerNftCollectionDto;
        public  NftCollectionDTO?      TopSaleNftCollectionDto;
        public  NftCollectionDTO?      TopReturnNftCollectionDto;

        public IndexModel()
        {
            this.client = new HttpClient();
            this.options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.NftCollectionApiHandler = "GetAllCollections";
            var listNftCollectionResponse = await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataNftCollection         = await listNftCollectionResponse.Content.ReadAsStringAsync();

            this.NftCollectionDto = JsonSerializer.Deserialize<List<NftCollectionDTO>>(dataNftCollection, this.options);
            this.NftCollectionDto = this.NftCollectionDto!.OrderByDescending(dto => dto.nft_collection_return).Take(10).ToList();

            this.NftCollectionApiHandler = "GetTopSaleNftCollection";
            var topSaleCollectionResponse = await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataTopSaleCollection     = await topSaleCollectionResponse.Content.ReadAsStringAsync();
            this.TopSaleNftCollectionDto = JsonSerializer.Deserialize<NftCollectionDTO>(dataTopSaleCollection, this.options);

            this.NftCollectionApiHandler = "GetTopOwnerNftCollection";
            var topOwnerCollectionResponse = await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataTopOwnerCollection     = await topOwnerCollectionResponse.Content.ReadAsStringAsync();
            this.TopOwnerNftCollectionDto = JsonSerializer.Deserialize<NftCollectionDTO>(dataTopOwnerCollection, this.options);
            
            this.NftCollectionApiHandler = "GetTopReturnNftCollection";
            var topReturnCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var topReturnCollectionData = await topReturnCollectionResponse.Content.ReadAsStringAsync();
            this.TopReturnNftCollectionDto =
                JsonSerializer.Deserialize<NftCollectionDTO>(topReturnCollectionData, this.options);
            
            return this.Page();
        }
    }
}