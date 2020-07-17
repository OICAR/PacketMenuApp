using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Item
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public List<Ingredients> Ingredients { get; set; }

        public int CatererFacilityID { get; set; }

        public double Price { get; set; }

    }
}
