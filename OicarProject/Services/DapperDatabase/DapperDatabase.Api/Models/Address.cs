using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Address
    {
		public int IDAddress { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string PinCode { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }

	}
}
