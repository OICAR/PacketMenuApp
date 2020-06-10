using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocketMenuUI.Models.ModelsDTO;

namespace PocketMenuUI.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {


            return View(new UserDTO ());
        }

        [HttpPost]
        public IActionResult Create(UserDTO user)
        {


            return RedirectToAction("Index",
                "Home");
        }
    }
}