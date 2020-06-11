﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class Beverage
    {
/*        public Beverage(string title, double price)
        {
            Title = title;
            Price = price;
        }*/

        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
       // public EatingHabits EatingHabits { get; set; }
    }
}
