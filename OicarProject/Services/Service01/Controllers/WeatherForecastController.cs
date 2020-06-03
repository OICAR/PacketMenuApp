using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Service01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public IEnumerable<WeatherForecast> weatherForecasts { get; set; }
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

         //   Authenticate();

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57198/WeatherForecast");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                weatherForecasts= await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(responseStream);
            }

            else
            {
                weatherForecasts = new List<WeatherForecast>();
            }

            return weatherForecasts;
        }


        private async Task<QRCodes>  Authenticate()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:57198/api/QRGenerator");

            request.Content = new StringContent(JsonSerializer.Serialize(new QRDataCatering() { CateringName = "nikola",LocationCordinates="12.43.214.21" }));

            request.Content.Headers.ContentType=new MediaTypeWithQualityHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = await client.SendAsync(request);

            QRCodes qRCodes = null;
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                qRCodes = Newtonsoft.Json.JsonConvert.DeserializeObject<QRCodes>(responseStream);
            }


            return qRCodes;


        }


        //[HttpPost]
        //public async Task<QRImage> GetQR()
        //{
        //    QRDataCatering data = new QRDataCatering();

        //    data.CateringName = "Nikola";
        //    data.LocationCordinates = "1.21.34.21";

            // var uri = API.QRCode.GetQRCode(_QRCodeGeneratorUrl);

            //XmlDocument doc = new XmlDocument();
            //doc.Load(qRDataCatering.FileName);

            //_apiClient.DefaultRequestHeaders.Clear();
            ////Define request data format  
            //_apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //var orderContent = new StringContent(JsonConvert.SerializeObject(doc), System.Text.Encoding.UTF8, "application/xml");
            ////Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            //HttpResponseMessage Res = await _apiClient.PutAsync(uri, orderContent);

            ////Checking the response is successful or not which is sent using HttpClient  
            ////TODO STO VRATITI AKO UPIT BUDE NEUSPIJESAN "Umjesto Exception"
            //return Res.IsSuccessStatusCode ? JsonConvert.DeserializeObject<QRImage>(Res.Content.ReadAsStringAsync().Result) : throw new Exception("Error cancelling order, try later.");




            //using (var client = new HttpClient())
            //{
            //    var uri = "http://localhost:57198/api/QRGenerator";

            //    client.DefaultRequestHeaders.Clear();
            //    //Define request data format  
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            //    XmlSerializer xsSubmit = new XmlSerializer(typeof(QRDataCatering));
            //    var subReq = data;
            //    var xml = "";

            //    using (var sww = new StringWriter())
            //    {
            //        using (XmlWriter writer = XmlWriter.Create(sww))
            //        {
            //            xsSubmit.Serialize(writer, subReq);
            //            xml = sww.ToString(); // Your XML
            //        }
            //    }


            //    var orderContent = new StringContent(xml, System.Text.Encoding.UTF8, "application/xml");
            //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            //    HttpResponseMessage Res = await client.PostAsync(uri, orderContent);

            //    //Checking the response is successful or not which is sent using HttpClient  
            //    //TODO STO VRATITI AKO UPIT BUDE NEUSPIJESAN "Umjesto Exception"
            //    return Res.IsSuccessStatusCode ? JsonConvert.DeserializeObject<QRImage>(Res.Content.ReadAsStringAsync().Result) : throw new Exception("Error cancelling order, try later.");



            //}


        }


    }

