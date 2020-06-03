using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Meal
    {
        public int IDMeal { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Ingredients { get; set; }
        public EatingHabits EatingHabits { get; set; }

    }
}
