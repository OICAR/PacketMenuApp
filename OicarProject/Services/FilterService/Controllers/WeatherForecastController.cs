using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication3.Models;

namespace FilterService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
  



        public WeatherForecastController( )
        {
           
        }

        [HttpGet]
        public IEnumerable<PrehranaData> Get (User a)
        {
            
           
            //List<User> listaJusera =new List<User>(); 
            a= new User()
            {
                EatingHabits =
                    
            };
            var webClient = new WebClient();
            var json = webClient.DownloadString("test.json");
            var pp = JsonConvert.DeserializeObject<Prehrana>(json);
            var cs = pp.prehrane.ToList();
            var b = a.EatingHabits;
            var lol = cs
                .Where(s => a.EatingHabits
                    .Any(s1=>s.Prehrana
                        .Contains<>(s1.Value)) );
            
            /*
                 
                  var lol = popisImplojia
                .Where(s => pp.prehrane
                    .Any(s1=>s.prehranaEmployee
                    .Contains(s1.Prehrana)) );
                    
             var model = _employeeRepository.GetAllEmployees();
             
             return View(lol);*/
            return lol;

        }
    }
}