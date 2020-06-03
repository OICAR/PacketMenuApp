﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocketMenuUI.Models.ModelsDTO;
using PocketMenuUI.Services;

namespace PocketMenuUI.Controllers
{
    public class QRCodeController : Controller
    {

        private readonly ILogger<QRCodeController> _logger;
        private readonly IQRCodeGenerator _QRCodeSvc;
        public QRCodeController(ILogger<QRCodeController> logger, IQRCodeGenerator QRCodeSvc)
        {

            
            _QRCodeSvc = QRCodeSvc;
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public async Task<ActionResult> SingleFile(XMLModel file)
        {

            var QRImage = await _QRCodeSvc.GetQRImage(file);

            // ReturnFileFromBitmap();

            //Isto kao sto bi se inace vratio View, na ovaj nacin pretrazivac izbaci sirovi file(u ovom slucaju QR kod)
            return File(QRImage.QRImageInBytes, "image/jpeg");
            //return RedirectToAction("Index");
        }

        private void ReturnFileFromBitmap()
        {
            throw new NotImplementedException();
        }
    }
}