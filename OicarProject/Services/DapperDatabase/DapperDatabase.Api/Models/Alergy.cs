using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Alergy
    {
		public int IDAlergy { get; set; }
		public bool Egg { get; set; }
		public bool Peanut { get; set; }
		public bool Shellfish { get; set; }
		public bool Soy { get; set; }
		public bool Fish { get; set; }
		public bool Sesame { get; set; }
	}
}
