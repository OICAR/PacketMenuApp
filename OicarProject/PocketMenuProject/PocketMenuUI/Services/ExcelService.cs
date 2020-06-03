using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PocketMenuUI.Infrastructure;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public class ExcelService :IExcel
    {
        private string _Url = "https://api-gateway20200429072611.azurewebsites.net";

        private readonly HttpClient _httpClientFactory;



        public ExcelService(HttpClient httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public async void Get()
        {
            var uri = API.ExcelAPI.GetExcel(_Url);


            _httpClientFactory.DefaultRequestHeaders.Clear();
            //Define request data format  
            _httpClientFactory.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = await _httpClientFactory.GetAsync(uri);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var responseString = Res.Content.ReadAsStringAsync().Result;

            }

     

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

            //  var uri = API.ExcelAPI.PostExcel(_Url);

            var uri = "http://localhost:62755/api/home";


            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var bytes = GetBytes(model.Document);


            CatererDTO caterer = new CatererDTO();
            caterer.Document = await bytes;


            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(caterer));

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





}
}
