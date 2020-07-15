using System.Collections.Generic;

namespace WebApplication3.Models
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