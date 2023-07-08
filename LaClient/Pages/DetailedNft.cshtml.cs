namespace LaClient.Pages;

using System.Text.Json;
using LaAPI.DTO;
using LaClient.DTO;
using LaClient.Materials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DetailedNft : PageModel
{
    private static readonly string                 NftApiUrl           = $"{ProjectStaticValue.Host}/api/Nft/";
    private static readonly string                 NftCollectionApiUrl = $"{ProjectStaticValue.Host}/api/NftCollections/";
    private static readonly string                 NftSaleApiUrl       = $"{ProjectStaticValue.Host}/api/NftSale/";
    private                 HttpClient             client;
    private                 string                 NftApiHandler;
    private                 string                 NftCollectionApiHandler;
    private                 string                 NftSaleApiHandler;
    private                 JsonSerializerOptions? options = new() { PropertyNameCaseInsensitive = true };

    public DetailedNft() { this.client = new HttpClient(); }
    public NftDto             NftDto     { get; set; }
    public List<NftsSaleDTO>? NftSaleDto { get; set; } = new();
    public async Task<IActionResult> OnGetAsync([FromQuery] string collection, [FromQuery] string id)
    {
        this.NftCollectionApiHandler = "GetNftCollectionByCollection" + "/" + collection;

        // Get response from Nft
        this.NftApiHandler = "GetNftByCollectionAndId" + "/" + collection + "/" + id;
        var nftResponse = await this.client.GetAsync(NftApiUrl + this.NftApiHandler);
        var nftData     = await nftResponse.Content.ReadAsStringAsync();
        var nft         = JsonSerializer.Deserialize<NftDto>(nftData, this.options);

        // Get response from NftCollection
        var collectionResponse = await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
        var collectionData     = await collectionResponse.Content.ReadAsStringAsync();
        var nftCollection      = JsonSerializer.Deserialize<NftsCollectionDTO>(collectionData, this.options);
        this.NftDto = new NftDto { slug = nft!.slug, image_url = nft.image_url, token_id = nft.token_id, collection_name = nftCollection!.name };


        this.NftSaleApiHandler = "GetNftSaleByCollection" + "/" + this.NftDto.slug + "/" + this.NftDto.token_id;
        // Get response from NftSale
        var saleResponse = await this.client.GetAsync(NftSaleApiUrl + this.NftSaleApiHandler);
        var saleData     = await saleResponse.Content.ReadAsStringAsync();
        this.NftSaleDto = JsonSerializer.Deserialize<List<NftsSaleDTO>>(saleData, this.options);

        return this.Page();
    }
}