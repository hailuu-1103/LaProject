using LaAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LaClient.Pages
{
    using LaClient.Materials;

    public class ListedTokenModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private HttpClient client;

        private static readonly string NftCollectionApiUrl = $"{ProjectStaticValue.Host}/api/NftCollections/GetAllCollections";

        public List<NftsCollectionDTO>? NftsCollectionDto;

        public ListedTokenModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
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
            this.NftsCollectionDto = JsonSerializer.Deserialize<List<NftsCollectionDTO>>(data, options);
            return this.Page();
        }
    }
}
