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
using Item = WebApplication3.Models.Item;

namespace FilterService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilterController : ControllerBase
    {
  



        public FilterController( )
        {
           
        }

        [HttpGet]
        
        public IEnumerable<Ingredients> Get (User user, 
        Item item)
        {
            
           

/*
        var webClient = new WebClient();
            var json = webClient.DownloadString("test.json");
        var pp = JsonConvert.DeserializeObject<Prehrana>(json);
            var cs = pp.prehrane.ToList();
           var b = user.EatingHabits;
           */


            //verzija da trazi po sastojcima
            var lol = item.Ingredients
                .Where(s => user.EatingHabits
                    .Any(s1=>s.IngredientName
                      .Contains(s1.Key)) );
            
            
            //verzija da trazi po eating habitu
            var haha = user.EatingHabits
                .Where(s => item.Ingredients
                    .Any(s1=>s.Key
                        .Contains(s1.IngredientName)) );
           
            return lol;

        }
    }
}