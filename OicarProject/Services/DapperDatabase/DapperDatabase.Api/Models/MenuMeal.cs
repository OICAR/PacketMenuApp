using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class MenuMeal
    {
        public int IDMenuMeal { get; set; }
        public Double Price { get; set; }
        public int IDMeal { get; set; }
        public int IDMenu { get; set; }
    }
}
