using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocketMenuUI.Models;
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
        private readonly ICaterers _CatererSvc;
        private readonly UserManager<ApplicationUser>
           _userManager;
        public CatererController(ILogger<CatererController> logger, IGoogleMap googleMapSvc, IQRCodeGenerator QRCodeSvc, ICaterers catererSvc, UserManager<ApplicationUser> userManager)
        {
            _GoogleMapSvc = googleMapSvc;
            _logger = logger;
            _QRCodeSvc = QRCodeSvc;
            _CatererSvc = catererSvc;
            _userManager = userManager;
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
                 var userID =
                _userManager.GetUserId(User);
                var newCaterer = new CatererDTO
                {
                    CatererID=userID,
                    Address=model.Address,
                    Lat=model.Lat,
                    Long=model.Long,
                    CateringFacilitiName=model.CateringFacilitiName,
                    CatererName=model.CatererName
                };

                newLocation= await _GoogleMapSvc.Add(newLocation);
                _CatererSvc.PostCaterer(newCaterer);

               



               var QRImage = await _QRCodeSvc.GetQRImage(newLocation);




            return File(QRImage.QRImageInBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "MyQRCode.jpg");
            
            }

            return View("Index");
        }




    }
}