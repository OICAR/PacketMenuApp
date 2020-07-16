using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PocketMenuUI.Infrastructure;
using PocketMenuUI.Models;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public class ExcelService :IExcel
    {
       

        private readonly HttpClient _httpClientFactory;
        private readonly IApi _api;

        private static char _DELIMITER = ',';
        private static Item _temp;
        private static List<Item> _tempList;

        public ExcelService(HttpClient httpClient, IApi api)
        {
            _httpClientFactory = httpClient;
            _api = api;
        }

        public static async Task<byte[]> GetBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<string> PostExcel(CatererViewModel model)
        {

              var uri = _api.PostExcel();



            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var bytes = await GetBytes(model.FormDocument);


            MealsDTO mealsDoc = new MealsDTO();
            mealsDoc.Document = bytes;


            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(mealsDoc));

            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = _httpClientFactory;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.SendAsync(request);

            // GoogleMapDTO locations = null;
            //if (response.IsSuccessStatusCode)
            //{
            //    var responseStream = await response.Content.ReadAsStringAsync();
            //    qRCodes = JsonConvert.DeserializeObject<QRDataCatering>(responseStream);
            //}

            //Checking the response is successful or not which is sent using HttpClient  
            //TODO STO VRATITI AKO UPIT BUDE NEUSPIJESAN "Umjesto Exception"
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync()) : throw new Exception("Error cancelling order, try later.");

        }

        public async Task<List<Item>>  Get(IFormFile document)
        {
            _tempList = new List<Item>();
            //_temp = new Item();
            string json = null;

            var bytes = await GetBytes(document);


            var stream2 = new MemoryStream(bytes);

            IFormFile file = new FormFile(stream2, 0, document.Length, "name", "filename.xlsx");


            string folderName = "UploadExcel";

            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            List<string> ItemLista = new List<string>();
            List<string> IngredientsLista = new List<string>();
            if (file.Length > 0)
            {

                ISheet sheet;


                using (var stream = file.OpenReadStream())
                {

                    //json = ReadExcelasJSON(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;

                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;

                    }

                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        Item item = new Item();
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == NPOI.SS.UserModel.CellType.Blank)) continue;
                        for (int celNumber = row.FirstCellNum; celNumber < cellCount; celNumber++)
                        {
                            if (row.GetCell(celNumber) != null)
                            {
                                var data = row.GetCell(celNumber).ToString();


                             
                                switch (celNumber)
                                {
                                    case 0:

                                        item.Title = data;
                                        break;
                                    case 1:
                                        item.Price = int.Parse(data);

                                        break;
                                    case 2:
                                        item.Ingredients = new List<Ingredients>();
                                        foreach (var igredient in parseToList(data, _DELIMITER))
                                        {
                                            Ingredients ingredients = new Ingredients();
                                            ingredients.IngredientName = igredient;

                                            item.Ingredients.Add(ingredients);

                                        }


                                        break;
                                    default:
                                        return null;
                                }

                                _temp = item;

                            }

                        }

                        _tempList.Add(_temp);

                    }

                }

            }
            return _tempList;

        }


        private static List<string> parseToList(string data, char DELIMITER)

        {


            

            List<string> result = data.Split(DELIMITER).ToList();

            return result;
        }

       
    }
}
