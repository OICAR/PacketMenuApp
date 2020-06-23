using PocketMenuUI.Utils.StringUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models.ModelsDTO
{
    public class UserDTO
    {

        public string UserID { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public HashSet<string> Preferences { get; set; }

        public HashSet<string> EatingHabits { get; set; }

    }
}
