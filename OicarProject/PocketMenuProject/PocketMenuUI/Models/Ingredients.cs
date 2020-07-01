using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{

   public enum MesureUnit {


        l,
        mg,
        dl,
        cl



    }


    public class Ingredients
    {

        public string IngredientName { get; set; }

        public MesureUnit Unit { get; set; }

        public double Amount { get; set; }


    }
}
