using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.Services;
using PocketMenuUI.ViewModel;

namespace PocketMenuUI.Controllers
{
    public class GoogleMapsController : Controller
    {
        private readonly ILogger<GoogleMapsController> _logger;
        private readonly IGoogleMap _GoogleMapSvc;

        public GoogleMapsController(ILogger<GoogleMapsController> logger, IGoogleMap googleMapSvc)
        {
            _GoogleMapSvc = googleMapSvc;
            _logger = logger;
        }

        // GET: GoogleMaps
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create
            (GoogleMapsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newLocation = new GoogleMapDTO
                {
                    Address = model.Address,
                    Lat = model.Lat,
                    Long = model.Long
                };

                _GoogleMapSvc.Add(newLocation);


                return RedirectToAction("Index",
                    "GoogleMaps");
            }

            return View();
        }

       

        public async Task<JsonResult> GetAllLocation()
        {
            var data =
                       await _GoogleMapSvc.GetAllLocations();
            return Json(data);
        }


    }
}