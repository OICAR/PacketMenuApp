using Microsoft.Extensions.Options;
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
    public class GoogleMapsService : IGoogleMap
    {

        private readonly IOptions<AppSettings> _settings;
        private readonly IApi _api;
        private readonly HttpClient _httpClientFactory;
        private readonly string _Url;


        public GoogleMapsService(HttpClient httpClient, IOptions<AppSettings> settings, IApi api)
        {
            _httpClientFactory = httpClient;          
            _api = api;
        }


        public async  Task<GoogleMapDTO> Add(GoogleMapDTO cateringFacility)
        {
            var uri = _api.GetMaps();

            var request = new HttpRequestMessage(HttpMethod.Post, uri);


            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(cateringFacility));

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
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GoogleMapDTO>(await response.Content.ReadAsStringAsync()) : throw new Exception("Error cancelling order, try later.");
        }

        public async Task<List<GoogleMapDTO>> GetAllLocations()
        {


            List<GoogleMapDTO> response = new List<GoogleMapDTO>();

            var uri = _api.GetMaps();


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

                //Deserializing the response recieved from web api and storing into the Employee list  
                response = JsonConvert.DeserializeObject<List<GoogleMapDTO>>(responseString);

            }



            // var responseString = await _apiClient.GetStringAsync(uri);

            //  var response = JsonConvert.DeserializeObject<List<WeatherForecastDTO>>(responseString);

            return response;




        }
    }
}
