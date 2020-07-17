using System.Collections.Generic;
using DapperDatabase.Api.Models;

namespace WebApplication3.Models
{
    public class Item
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int CatererFacilityID { get; set; }

        public List<Ingredients> Ingredients { get; set; }

        public double Price { get; set; }
    }
}