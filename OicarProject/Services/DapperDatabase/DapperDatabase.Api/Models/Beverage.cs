using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Beverage
    {
        public int IDBeverage { get; set; }
        public string Name { get; set; }
        public EatingHabits EatingHabits { get; set; }

    }
}
