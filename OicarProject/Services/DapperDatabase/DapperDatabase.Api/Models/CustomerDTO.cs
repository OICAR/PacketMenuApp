using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class CustomerDTO
    {
        public string FullName { get; set; }


        public string Gender { get; set; }


        //public string temp { get; set; }



        public HashSet<string> Preferences { get; set; }



        public HashSet<string> EatingHabits { get; set; }

    }
}
