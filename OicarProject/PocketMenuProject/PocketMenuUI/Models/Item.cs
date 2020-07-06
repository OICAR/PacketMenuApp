using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class Item
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public List<Ingredients> Ingredients { get; set; }

        public double Price { get; set; }

    }
}
