using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel.Charts;
using PocketMenuUI.Models;

namespace PocketMenuUI.Controllers
{
    public class MenusController : Controller
    {
        [Route("{controller}/{id}")]
        public IActionResult Menu(string id)
        {
            string catererID = id;
            //List<Meal> meals = new List<Meal> {
            //new Meal("Spaghetti bolognes","Spaghetti, bolognese sauce",35.00),
            //new Meal("Salad", "Onions, tomatoes, turnips",18.00) };

            //List<Beverage> drinks = new List<Beverage> {
            //new Beverage("Coca-Cola",15.00),
            //new Beverage("Sprite",15.00) };

            //Menu menu = new Menu("RE02", meals, drinks);

            Item item1 = new Item("Cevapi",new List<Ingredients> 
            { 
                new Ingredients("meso",MesureUnit.g,300),
                new Ingredients("luk",MesureUnit.g,40),
                new Ingredients("lepina",MesureUnit.komad,1),
                new Ingredients("ajvar",MesureUnit.g,50)
            },20);
            Item item2 = new Item("Coca Cola", 15);

            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);


            Menu menu = new Menu(items, "Come In");

            return View(menu);
        }
    }
}
