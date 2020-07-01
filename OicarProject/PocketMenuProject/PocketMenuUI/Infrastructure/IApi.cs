using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Infrastructure
{
    public interface IApi
    {

            public  string GetWeatherForecast();
            public  string GetQRCode() ;
            public  string GetMaps();
            public  string GetExcel() ;
            public  string PostExcel();
        public string PostCaterer();

        public string PostUser();

    }
}
