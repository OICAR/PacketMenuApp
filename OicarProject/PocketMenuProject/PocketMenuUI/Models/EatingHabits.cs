using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class EatingHabits
    {
        public int ID { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }
        public Alergy Alergies { get; set; }
        public bool LactoseIntolerant { get; set; }
        public bool Chrons { get; set; }
        public bool Celiac { get; set; }
    }
}
