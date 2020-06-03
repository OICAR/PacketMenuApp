using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocketMenuUI.Models.ModelsDTO;
namespace PocketMenuUI.Services
{
   public interface IWatherForecast
    {

        Task<List<WeatherForecastDTO>> GetForecast();

    }
}
