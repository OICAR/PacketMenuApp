using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{
    //public class Menu
    //{

    //    public int CateringFacilityID { get; set; }

    //    public int CateringFacilityName { get; set; }


    //    public List<Item> Articles{ get; set; }

    //}
    public class Menu
    {

        public Menu(List<Meal> meals)
        {
            Meals = meals;
        }

        public Menu(List<Meal> meals, List<Beverage> beverages)
        {
            Meals = meals;
            Beverages = beverages;
        }

        public Menu(string iDCateringFacility, List<Meal> meals, List<Beverage> beverages)
        {
            IDCateringFacility = iDCateringFacility;
            Meals = meals;
            Beverages = beverages;
        }

        public string IDCateringFacility { get; set; }

        public string CateringFacilityName { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Beverage> Beverages { get; set; }
    }
}
