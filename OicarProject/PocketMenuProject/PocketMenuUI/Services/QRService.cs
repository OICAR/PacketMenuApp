using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PocketMenuUI.Infrastructure;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;

namespace PocketMenuUI.Services
{
    public class QRService : IQRCodeGenerator
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClientFactory;
        private readonly ILogger<QRService> _logger;
        private readonly IApi _api;

        public QRService(HttpClient httpClient, IOptions<AppSettings> settings, ILogger<QRService> logger, IApi api)
        {
            _httpClientFactory = httpClient;      
            _settings = settings;
            _logger = logger;
            _api = api;
        }



        public async Task<QRImage> GetQRImage(GoogleMapDTO qRDataCatering)
        {



            var uri = _api.GetQRCode();

            var request = new HttpRequestMessage(HttpMethod.Post, uri);


            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(qRDataCatering));

            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = _httpClientFactory;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.SendAsync(request);

            QRDataCatering qRCodes = null;
            //if (response.IsSuccessStatusCode)
            //{
            //    var responseStream = await response.Content.ReadAsStringAsync();
            //    qRCodes = JsonConvert.DeserializeObject<QRDataCatering>(responseStream);
            //}

            //Checking the response is successful or not which is sent using HttpClient  
            //TODO STO VRATITI AKO UPIT BUDE NEUSPIJESAN "Umjesto Exception"
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<QRImage>(await response.Content.ReadAsStringAsync()) : throw new Exception("Error cancelling order, try later.");
        }
    }
}
