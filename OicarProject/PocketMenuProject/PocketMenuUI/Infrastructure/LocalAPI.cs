﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Infrastructure
{
    public class LocalAPI : IApi
    {
        private static string BaseURL = "https://api-gateway20200429072611.azurewebsites.net";

        public string GetExcel() => $"{BaseURL}/api/excel";
        public string GetMaps() => $"http://localhost:51421"+"/api/maps";

        public string GetQRCode() => "http://localhost:57198"+ "/api/QRGenerator";

        public string GetWeatherForecast() => $"{BaseURL}/api/weatherforecast";

        public string PostCaterer() => "https://localhost:5001" + "/api/Caterer";

        public string PostItem() => "https://localhost:5001" + "/api/Item";

        public string PostExcel() => "https://localhost:44398"+ "/api/Home";

        public string PostUser() => "https://localhost:5001"+ "/api/Customer";

       
    }
}
