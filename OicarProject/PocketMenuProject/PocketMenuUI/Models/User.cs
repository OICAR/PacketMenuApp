using PocketMenuUI.Utils.StringUtilities;
using PocketMenuUI.Utils.UserUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class User
    {

        public string UserID { get; set; }


        public string FullName { get; set; }

        public string Gender { get; set; }


        public string temp { get; set; }

        public string newEatingHabbit { get; set; }


        public HashSet<string> Preferences { get => Preferences = newEatingHabbit == null ? null : StringUtility.ParseString(newEatingHabbit); set { } }



        public Dictionary<string, bool> EatingHabits { get; set; }


        public HashSet<string> TempEatingHabits { get => TempEatingHabits = EatingHabits == null ? null : UserUtility.GetSelectedHabits(EatingHabits); set { } }



    }
}
