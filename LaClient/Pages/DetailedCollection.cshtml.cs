using LaAPI.DTO;
using LaClient.Materials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Text.Json;

namespace LaClient.Pages
{
    public class DetailTokenModel : PageModel
    {
        private HttpClient client;

        private const string NftApiUrl = "https://localhost:7042/api/Nfts/";
        private const string NftSaleApiUrl = "https://localhost:7042/api/NftsSale/";

        private string NftApiHandler;
        private string NftSaleApiHandler;

        public List<NftsDTO> NftsDTO;
		public List<NftsSaleDTO> NftsSaleDTO;

        [FromQuery(Name = "page")] public int Page { get; set; } = 1;

        private const int pageSize = 10;
        public List<string> PageLink { get; set; } = new List<string>();
        public DetailTokenModel()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> OnGetAsync(string? collection)
        {
            NftApiHandler = $"GetTotalNftsByCollection/{collection}";
			var responseTotalRecords = await client.GetAsync(NftApiUrl + NftApiHandler);
			var dataTotalRecords = await responseTotalRecords.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var totalRecords = JsonSerializer.Deserialize<int>(dataTotalRecords, options);
			int total = CalcPageCount(totalRecords);

			if (Page < 1 || Page > total)
			{
				return RedirectToPage("Error");
			}

			PageLink page = new PageLink(pageSize);
			PageLink = page.getLink(Page, totalRecords, "/DetailedToken/" + collection + "?");

			NftApiHandler = $"GetNftByCollection/{collection}/{Page}/{pageSize}";
			var response = await client.GetAsync(NftApiUrl + NftApiHandler);
			var data = await response.Content.ReadAsStringAsync();
			
			NftsDTO = JsonSerializer.Deserialize<List<NftsDTO>>(data, options).ToList();

            return Page();
        }
		private int CalcPageCount(int totalRecords)
		{
			int totalPage = totalRecords / pageSize;

			if (totalRecords % pageSize != 0) totalPage++;
			return totalPage;
		}
	}
}
