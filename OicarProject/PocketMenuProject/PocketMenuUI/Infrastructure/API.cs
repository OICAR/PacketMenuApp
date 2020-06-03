using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Infrastructure
{
    public static class API
    {

        private static string BaseURL = "https://api-gateway20200429072611.azurewebsites.net";


        public static class Forecast
        {
            public static string GetWeatherForecast(string baseUri) => $"{baseUri}/api/weatherforecast";
        
        }

        public static class QRCode
        {

            public static string GetQRCode(string baseUri) => $"{baseUri}/api/QRCode";



        }


        public static class GoogleMaps
        {


            public static string GetMaps(string baseUri) => $"{baseUri}/api/maps";


        }

        public static class ExcelAPI
        {


            public static string GetExcel(string baseUri) => $"{baseUri}/api/excel";
            public static string PostExcel(string baseUri) => $"{baseUri}/api/document";


        }

    }
}
