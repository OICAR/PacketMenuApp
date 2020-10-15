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
        public IActionResult Menu(int id)
        {


            //string catererID = coordinates;

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
