using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Infrastructure
{
    public class API : IApi
    {
        
        private static string BaseURL = "https://api-gateway20200712080357.azurewebsites.net";

        public string GetExcel() => $"{BaseURL}/api/excel";
        public string GetMaps() => $"{BaseURL}/api/maps";

        public string GetQRCode() => $"{BaseURL}/api/QRCode";

        public string GetWeatherForecast() => $"{BaseURL}/api/weatherforecast";

        public string PostCaterer() => $"https://dapperdatabaseapi20200712065211.azurewebsites.net/api/Caterer" ;

        public string PostExcel() => $"{BaseURL}/api/document";

        public string PostItem() => $"{BaseURL}/api/Item";

        public string PostUser() => $"{BaseURL}/api/Customer";

    }
}
