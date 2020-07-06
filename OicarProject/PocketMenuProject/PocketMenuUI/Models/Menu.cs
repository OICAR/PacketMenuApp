using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    public class Menu
    {

        public int CateringFacilityID { get; set; }

        public int CateringFacilityName { get; set; }


        public List<Item> Articles{ get; set; }
  
    }
}
