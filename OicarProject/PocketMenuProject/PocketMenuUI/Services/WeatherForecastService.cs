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
    public class WeatherForecastService : IWatherForecast
    {


        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly string _forecastUrl;
        private readonly IApi _api;
        public WeatherForecastService(HttpClient httpClient, IOptions<AppSettings> settings, IApi api)
        {
            _apiClient = httpClient;            
            _api = api;
        }


        //TODO IweatherFOrecastChange
        public async Task<List<WeatherForecastDTO>> GetForecast()
        {
            List<WeatherForecastDTO> response = new List<WeatherForecastDTO>();

            var uri = _api.GetWeatherForecast();


            //Define request data format  
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            HttpResponseMessage Res = await _apiClient.GetAsync(uri);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var responseString = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                response = JsonConvert.DeserializeObject<List<WeatherForecastDTO>>(responseString);

            }



            // var responseString = await _apiClient.GetStringAsync(uri);

            //  var response = JsonConvert.DeserializeObject<List<WeatherForecastDTO>>(responseString);

            return response;

        }
    }
}
