using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class Menu
    {
        public Menu(List<Meal> meals)
        {
            Meals = meals;
        }

        public Menu(List<Meal> meals,List<Beverage> beverages)
        {
            Meals = meals;
            Beverages = beverages;
        }

        public List<Meal> Meals { get; set; }
        public List<Beverage> Beverages { get; set; }
    }
}
