using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelService.Models
{
    public class Item
    {

        public string Name { get; set; }

        public int Price { get; set; }


        public List<string> Ingredents { get; set; }

    }
}
