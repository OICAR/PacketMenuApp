using Newtonsoft.Json;
using PocketMenuUI.Infrastructure;
using PocketMenuUI.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public class UserService : IUsers
    {

        private readonly HttpClient _httpClientFactory;
        private readonly IApi _api;



        public UserService(HttpClient httpClientFactory, IApi api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }


        public async void PostUser(UserDTO user)
        {
            var uri = _api.PostUser();



            var request = new HttpRequestMessage(HttpMethod.Post, uri);


            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(user));

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
            //return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync()) : throw new Exception("Error cancelling order, try later.");

        }
    }
}
