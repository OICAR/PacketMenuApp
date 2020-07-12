using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class Caterer
    {
        public int IDCaterer { get; set; }
        public string Name { get; set; }
        public string OIB { get; set; }

        public string CatererName { get; set; }

        //public string CatererOIB { get; set; }

        public string CatererID { get; set; }


        public string CateringFacilitiName { get; set; }

        //public int? Rating { get; set; }


        public int Id { get; set; }
        public int? Rating { get; set; }

        public string Address { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }


    }
}
