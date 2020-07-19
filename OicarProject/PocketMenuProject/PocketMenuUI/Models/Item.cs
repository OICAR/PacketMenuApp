using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class Item
    {
        public Item()
        {
        }

        public Item(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public Item(string title, List<Ingredients> ingredients, double price)
        {
            Title = title;
            Ingredients = ingredients;
            Price = price;
        }

        public int ID { get; set; }
        public int CatererFacilityID { get; set; }
        public List<Ingredients> Ingredients { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

    }
}
