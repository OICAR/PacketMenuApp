using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class EatingHabits
    {
		public int IDEatingHabits { get; set; }
		public bool Vegan { get; set; }
		public bool Vegetarian { get; set; }
		public Alergy Alergy { get; set; }
		public bool LactoseIntolerant { get; set; }
		public bool CrohnsDisease { get; set; }
		public bool CeliacDisease { get; set; }

	}
}
