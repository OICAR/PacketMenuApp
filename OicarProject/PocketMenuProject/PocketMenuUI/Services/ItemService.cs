using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PocketMenuUI.Infrastructure;
using PocketMenuUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public class ItemService : IItem
    {


        private readonly IApi _api;
        private readonly HttpClient _httpClientFactory;
  

        public ItemService(IApi api, HttpClient httpClientFactory)
        {
            _api = api;
            _httpClientFactory = httpClientFactory;
        }


        public static async Task<byte[]> GetBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<string> PostItem(List<Item> item)
        {
           

                  var uri = _api.PostItem();


            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            //var bytes = await GetBytes();


            //MealsDTO mealsDoc = new MealsDTO();
            //mealsDoc.Document = bytes;


            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(item));

            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = _httpClientFactory;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.SendAsync(request);


            return  response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync()) : throw new Exception("Error cancelling order, try later.");


        }
    }
}
