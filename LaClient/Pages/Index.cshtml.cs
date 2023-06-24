﻿using LaAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LaClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private HttpClient client;

        private const string NftCollectionApiUrl = "https://localhost:7042/api/NftsCollections/GetAllCollections";

        public List<NftsCollectionDTO> NftsCollectionDTO;

        public IndexModel(ILogger<IndexModel> logger)
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
			this.NftsCollectionDTO = JsonSerializer.Deserialize<List<NftsCollectionDTO>>(data, options);
            this.NftsCollectionDTO = this.NftsCollectionDTO.Take(10).ToList();
            return Page();
		}
    }
}