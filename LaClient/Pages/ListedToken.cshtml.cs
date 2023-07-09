namespace LaClient.Pages
{
    using System.Text.Json;
    using LaAPI.DTO;
    using LaClient.Materials;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ListedTokenModel : PageModel
    {
        private static readonly string     NftCollectionApiUrl = $"{ProjectStaticValue.Host}/api/NftCollections/GetAllCollections";
        private                 HttpClient client;

        public List<NftCollectionDTO>? NftsCollectionDto;

        public ListedTokenModel() { this.client = new HttpClient(); }

        public async Task<IActionResult> OnGetAsync()
        {
            var response = await this.client.GetAsync(NftCollectionApiUrl);
            var data     = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            this.NftsCollectionDto = JsonSerializer.Deserialize<List<NftCollectionDTO>>(data, options);
            return this.Page();
        }
    }
}