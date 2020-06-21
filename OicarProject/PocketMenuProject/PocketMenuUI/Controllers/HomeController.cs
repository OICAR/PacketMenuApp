﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Http;
 using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PocketMenuUI.Models;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.Services;

namespace PocketMenuUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWatherForecast _weatherSvc;
        
        public HomeController(ILogger<HomeController> logger,IWatherForecast watherForecastService )
        {
            _weatherSvc = watherForecastService;
            _logger = logger;
        }

        string Baseurl = "https://api-gateway20200429072611.azurewebsites.net";

        


              public ActionResult SwaggerIndex()
        {

            return Redirect("https://dapperdatabaseapi20200527121926.azurewebsites.net");

        }


            public async  Task<ActionResult> Index()
        {
            

            List<WeatherForecastDTO> EmpInfo = new List<WeatherForecastDTO>();

            //using (var client = new HttpClient())
            //{
            //    //Passing service base url  
            //    client.BaseAddress = new Uri(Baseurl);

            //    client.DefaultRequestHeaders.Clear();
            //    //Define request data format  
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            //    HttpResponseMessage Res = await client.GetAsync("/api/weatherforecast");

            //    //Checking the response is successful or not which is sent using HttpClient  
            //    if (Res.IsSuccessStatusCode)
            //    {
            //        //Storing the response details recieved from web api   
            //        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

            //        //Deserializing the response recieved from web api and storing into the Employee list  
            //        EmpInfo = JsonConvert.DeserializeObject<List<WeatherForecastDTO>>(EmpResponse);

            //    }
            //    //returning the employee list to view  

            //}


            EmpInfo = await _weatherSvc.GetForecast();

            return View(EmpInfo);


        }

        public async Task<IActionResult> PrivacyAsync()
        {

            List<WeatherForecastDTO> EmpInfo = new List<WeatherForecastDTO>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/weatherforecast");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<WeatherForecastDTO>>(EmpResponse);

                }
                //returning the employee list to view  

            }



            return View(EmpInfo);
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }*/
        // [Route("Error/{statusCode}")]
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage =
                        "Sorry, the resource you requested could not be found";
                    break;
            }

            return View("Error");

        }
    }
}
