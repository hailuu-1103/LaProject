using System.Text.Json;
using LaAPI.DTO;
using LaClient.Materials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaClient.Pages
{
    public class DetailTokenModel : PageModel
    {
        private const int PageSize = 12;

        private static readonly string NftApiUrl = $"{ProjectStaticValue.Host}/api/Nft/";
        private static readonly string NftSaleApiUrl = $"{ProjectStaticValue.Host}/api/NftSale/";
        private HttpClient client;

        private string nftApiHandler;

        public List<NftsDTO> NftDto;
        private string nftSaleApiHandler;
        public List<NftsSaleDTO> NftSaleDto;

        public DetailTokenModel()
        {
            this.client = new HttpClient();
            this.NftDto = new List<NftsDTO>();
            this.NftSaleDto = new List<NftsSaleDTO>();
        }

        [FromQuery(Name = "page")] public int CurrentPage { get; set; } = 1;
        public List<string> PageLink { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string? collection)
        {
            this.nftApiHandler = $"GetTotalNftByCollection/{collection}";
            var responseTotalRecords = await this.client.GetAsync(NftApiUrl + this.nftApiHandler);
            var dataTotalRecords = await responseTotalRecords.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var totalRecords = JsonSerializer.Deserialize<int>(dataTotalRecords, options);
            var total = this.CalcPageCount(totalRecords);

            if (this.CurrentPage < 1 || this.CurrentPage > total)
            {
                return this.RedirectToPage("Error");
            }

            var page = new PageLink(PageSize);
            this.PageLink = page.getLink(this.CurrentPage, totalRecords, "/DetailedCollection/" + collection + "?");

            this.nftApiHandler = $"GetNftByCollection/{collection}/{this.CurrentPage}/{PageSize}";
            var response = await this.client.GetAsync(NftApiUrl + this.nftApiHandler);
            var data = await response.Content.ReadAsStringAsync();

            this.NftDto = JsonSerializer.Deserialize<List<NftsDTO>>(data, options)!.ToList();

            return this.Page();
        }

        private int CalcPageCount(int totalRecords)
        {
            var totalPage = totalRecords / PageSize;

            if (totalRecords % PageSize != 0) totalPage++;
            return totalPage;
        }
    }
}