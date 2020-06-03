using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Restaurant
    {
		public int IDRestaurant { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }
		public Caterer Caterer { get; set; }
		public double Rating { get; set; }
		public int MenuID { get; set; }
	}
}
