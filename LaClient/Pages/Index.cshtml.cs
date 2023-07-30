namespace LaClient.Pages
{
    using System.Text.Json;
    using LaAPI.DTO;
    using LaClient.Materials;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using ClosedXML.Excel;
    using ExcelDataReader;

    public class IndexModel : PageModel
    {
        private static readonly string NftCollectionApiUrl = $"{ProjectStaticValue.Host}/api/NftCollections/";
        private                 HttpClient client;
        private                 string NftCollectionApiHandler;
        private const           int NumberOfRecord = 5;
        private                 List<NftCollectionDTO>? CachedNftCollectionDtos;

        public List<NftCollectionDTO> TopReturnCollectionDtos;
        public List<NftCollectionDTO> TopFollowersCollectionDtos;
        public NftCollectionDTO?      TopOwnerNftCollectionDto;
        public NftCollectionDTO?      TopSaleNftCollectionDto;
        public NftCollectionDTO?      TopReturnNftCollectionDto;

        private List<NftCollectionDTO>? AllNftCollectionDto;
        private JsonSerializerOptions?  options;

        public IndexModel()
        {
            this.client = new HttpClient();
            this.options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IActionResult> OnGetAsync(string searchItem)
        {
            this.NftCollectionApiHandler = "GetAllCollections";
            var listNftCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataNftCollection = await listNftCollectionResponse.Content.ReadAsStringAsync();

            this.CachedNftCollectionDtos =
                JsonSerializer.Deserialize<List<NftCollectionDTO>>(dataNftCollection, this.options);
            this.TopReturnCollectionDtos = this.CachedNftCollectionDtos!
                .OrderByDescending(dto => dto.nft_collection_return).Take(NumberOfRecord)
                .ToList();
            this.TopFollowersCollectionDtos = this.CachedNftCollectionDtos!
                .OrderByDescending(dto => dto.twitter_followers).Take(NumberOfRecord)
                .ToList();
            this.NftCollectionApiHandler = "GetTopSaleNftCollection";
            var topSaleCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataTopSaleCollection = await topSaleCollectionResponse.Content.ReadAsStringAsync();
            this.TopSaleNftCollectionDto =
                JsonSerializer.Deserialize<NftCollectionDTO>(dataTopSaleCollection, this.options);

            this.NftCollectionApiHandler = "GetTopOwnerNftCollection";
            var topOwnerCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataTopOwnerCollection = await topOwnerCollectionResponse.Content.ReadAsStringAsync();
            this.TopOwnerNftCollectionDto =
                JsonSerializer.Deserialize<NftCollectionDTO>(dataTopOwnerCollection, this.options);

            this.NftCollectionApiHandler = "GetTopReturnNftCollection";
            var topReturnCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var topReturnCollectionData = await topReturnCollectionResponse.Content.ReadAsStringAsync();
            this.TopReturnNftCollectionDto =
                JsonSerializer.Deserialize<NftCollectionDTO>(topReturnCollectionData, this.options);

            return this.Page();
        }

        public async Task<JsonResult> OnPostSearch(string searchTerm)
        {
            this.NftCollectionApiHandler = "GetAllCollections";
            var listNftCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var dataNftCollection = await listNftCollectionResponse.Content.ReadAsStringAsync();

            this.AllNftCollectionDto =
                JsonSerializer.Deserialize<List<NftCollectionDTO>>(dataNftCollection, this.options);
            var data = this.AllNftCollectionDto!.Select(dto => dto)
                .Where(dto => dto.name.ToLower().Contains(searchTerm.ToLower())).ToList();
            return new JsonResult(data);
        }

        public async Task<IActionResult> OnGetExport()
        {
            this.NftCollectionApiHandler = "GetAllCollections";
            var listNftCollectionResponse =
                await this.client.GetAsync(NftCollectionApiUrl + this.NftCollectionApiHandler);
            var       dataNftCollection = await listNftCollectionResponse.Content.ReadAsStringAsync();
            this.AllNftCollectionDto =
                JsonSerializer.Deserialize<List<NftCollectionDTO>>(dataNftCollection, this.options);
            var       data     = this.AllNftCollectionDto!.OrderByDescending(dto => dto.nft_collection_return).ToList();
            using var workbook = new XLWorkbook();
            var       ws       = workbook.Worksheets.Add("Sheet1");
            //Header
            ws.Cell(1, 1).Value = "Project";
            ws.Cell(1, 2).Value = "Return Score";
            ws.Cell(1, 3).Value = "Followers";
            ws.Cell(1, 4).Value = "Interaction";
            ws.Cell(1, 5).Value = "Attention";

            ws.Range("A1:G1").Style.Fill.BackgroundColor = XLColor.Alizarin;

            var i = 2;
            foreach (var product in data)
            {
                ws.Cell(i, 1).Value = product.name;
                ws.Cell(i, 2).Value = ((decimal)product.nft_collection_return).ToString("F2");
                ws.Cell(i, 3).Value = ((decimal)product.twitter_followers).ToString("F2");
                ws.Cell(i, 4).Value = ((decimal)product.avg_tweet_interaction).ToString("F2");
                ws.Cell(i, 5).Value = ((decimal)product.avg_tweet_attention).ToString("F2");
                i++;
            }

            i--;

            ws.Cells("A1:G" + i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cells("A1:G" + i).Style.Border.TopBorder    = XLBorderStyleValues.Thin;
            ws.Cells("A1:G" + i).Style.Border.LeftBorder   = XLBorderStyleValues.Thin;
            ws.Cells("A1:G" + i).Style.Border.RightBorder  = XLBorderStyleValues.Thin;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return await Task.FromResult<IActionResult>(this.File(
                content,
                "application/vnd.openxmlformats-officedocument-speadsheetml.sheet",
                "Product.xlsx"
            ));
        }
    }
}