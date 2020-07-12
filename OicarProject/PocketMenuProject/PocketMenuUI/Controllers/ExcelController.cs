using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PocketMenuUI.Infrastructure;
using PocketMenuUI.Services;
using PocketMenuUI.Utils.ExcelUtlities;
using PocketMenuUI.ViewModel;

namespace PocketMenuUI.Controllers
{
    public class ExcelController : Controller
    {

        private readonly IExcel _ExcelSvc;

        public ExcelController(IExcel excelSvc)
        {
            _ExcelSvc = excelSvc;
        }



        public IActionResult Index()
        {
            return View();
        }



        public async Task<ActionResult> Import()
        {
            string json = null;

            CatererViewModel caterer = new CatererViewModel();


            IFormFile file = Request.Form.Files[0];
            caterer.FormDocument = file;
            //string tableData=  ExcelUtility.DisplayTable(file);

            string tableData = await _ExcelSvc.PostExcel(caterer);

            //_ExcelSvc.Get();


            return RedirectToAction("Registration", "Caterer", new
            {
                test = tableData
             
            });

            //return this.Content(tableData);
        }


        public async Task<ActionResult> Export(CatererViewModel caterer)
        {

           string responseContent= await _ExcelSvc.PostExcel(caterer);

            return this.Content(responseContent);
        }

    }
}