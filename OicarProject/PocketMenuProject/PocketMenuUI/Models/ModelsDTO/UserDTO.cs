using PocketMenuUI.Utils.StringUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models.ModelsDTO
{
    public class UserDTO
    {


        public UserDTO()
        {
            this.EatingHabits = new Dictionary<string, bool>();

            this.EatingHabits.Add("SVE", false);
            this.EatingHabits.Add("VEGETARIAN", false);
            this.EatingHabits.Add("VEGAN", false);
            this.EatingHabits.Add("CHRON ", false);
            this.EatingHabits.Add("DIJABETES", false);
            this.EatingHabits.Add("CELIJAKIJA  ", false);
        }


        public string FullName { get; set; }

        public string Gender { get; set; }


        public string temp { get; set; }



        public HashSet<string> Preferences { get => Preferences = temp == null ? null : StringUtility.ParseString(';', temp); set{ } }



        public Dictionary<string, bool> EatingHabits { get; set; }




       

    }
}
