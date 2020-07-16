using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocketMenuUI.Models;

namespace PocketMenuUI.Controllers
{
    public class MenusController : Controller
    {
        [Route("{controller}/{id}")]
        public IActionResult Menu(string id)
        {
            string catererID = id;
            List<Meal> meals = new List<Meal> {
            new Meal("Spaghetti bolognes","Spaghetti, bolognese sauce",35.00),
            new Meal("Salad", "Onions, tomatoes, turnips",18.00) };

            List<Beverage> drinks = new List<Beverage> {
            new Beverage("Coca-Cola",15.00),
            new Beverage("Sprite",15.00) };

            Menu menu = new Menu("RE02", meals, drinks);
            menu.CateringFacilityName = "Restoran X";

            return View(menu);
        }
    }
}
