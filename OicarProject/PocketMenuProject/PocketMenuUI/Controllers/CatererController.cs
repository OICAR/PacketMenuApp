using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.Services;
using PocketMenuUI.ViewModel;

namespace PocketMenuUI.Controllers
{
    [Authorize(Roles="Caterer")]
    public class CatererController : Controller
    {

        private readonly ILogger<CatererController> _logger;
        private readonly IGoogleMap _GoogleMapSvc;

        public CatererController(ILogger<CatererController> logger, IGoogleMap googleMapSvc)
        {
            _GoogleMapSvc = googleMapSvc;
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Registration(string test)
        {

            if (test== null)
            {
                return View();
            }

            return this.Content(test);
        }



        [HttpPost]
        public IActionResult Create
           (CatererViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newLocation = new GoogleMapDTO
                {
                    Address = model.Address,
                    Lat = model.Lat,
                    Long = model.Long
                };

                //_GoogleMapSvc.Add(newLocation);


                return RedirectToAction("Index",
                    "GoogleMaps");
            }

            return View("Index");
        }




    }
}