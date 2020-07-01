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
        private readonly IQRCodeGenerator _QRCodeSvc;
        private readonly ILogger<CatererController> _logger;
        private readonly IGoogleMap _GoogleMapSvc;
        private readonly ICaterers _service;

        public CatererController(ILogger<CatererController> logger, IGoogleMap googleMapSvc, IQRCodeGenerator QRCodeSvc, ICaterers service)
        {
            _GoogleMapSvc = googleMapSvc;
            _logger = logger;
            _QRCodeSvc = QRCodeSvc;
            _service = service;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}



        public IActionResult Registration(string test)
        {

            if (test== null)
            {
                return View();
            }

            return this.Content(test);
        }



        [HttpPost]
        public async Task<ActionResult> Create
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

                var newCaterer = new CatererDTO
                {
                    Name = model.CatererName,
                    IDCaterer = 1,
                    OIB=123
                };

                var newQRCode = new XMLModel
                {
                   Name=model.CateringFacilitiName,
                   Coordinates=model.Address
                };



                await _GoogleMapSvc.Add(newLocation);
                _service.PostCaterer(newCaterer);

               var QRImage = await _QRCodeSvc.GetQRImage(newQRCode);


            return File(QRImage.QRImageInBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "MyQRCode.jpg");
            
            }

            return View("Index");
        }




    }
}