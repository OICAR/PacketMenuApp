using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class Meal
    {
        public Meal(string title, string ingredients, double price)
        {
            Title = title;
            Ingredients = ingredients;
            Price = price;
        }

        public string Title { get; set; }
        public string Ingredients { get; set; }
        public int Amount { get; set; }
        public EatingHabits EatingHabits { get; set; }

        public double Price { get; set; }
    }
}
