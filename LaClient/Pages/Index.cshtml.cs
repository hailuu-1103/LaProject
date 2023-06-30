namespace LaClient.Pages
{
	using System.Text.Json;
	using LaAPI.DTO;
	using LaClient.Materials;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.RazorPages;

	public class IndexModel : PageModel
    {
	    private HttpClient client;

        private static readonly string NftCollectionApiUrl = $"{ProjectStaticValue.Host}/api/NftCollections/GetAllCollections";

        public List<NftsCollectionDTO>? NftCollectionDto;

        public IndexModel()
        {
	        this.client = new HttpClient();
        }

        public async Task<IActionResult> OnGetAsync()
        {
			var response = await client.GetAsync(NftCollectionApiUrl);
			var data = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			this.NftCollectionDto = JsonSerializer.Deserialize<List<NftsCollectionDTO>>(data, options);
            this.NftCollectionDto = this.NftCollectionDto!.Take(10).ToList();
            return this.Page();
		}
    }
}