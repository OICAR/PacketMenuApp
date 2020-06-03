using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class MenuBeverage
    {
        public int IDMenuBeverage { get; set; }
        public Double Price { get; set; }
        public int IDBeverage { get; set; }
        public int IDMenu { get; set; }
    }
}
