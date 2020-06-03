using System;
using System.ComponentModel.DataAnnotations;

namespace PocketMenuUI.Models.ModelsDTO
{
    public class WeatherForecastDTO
    {
        public DateTime Date { get; set; }

        [Display(Name = "Current name")]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        [Display(Name = "Summary")]
        public string Summary { get; set; }
    }
}
