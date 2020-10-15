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
        cl,
        g,
        komad
    }


    public class Ingredients
    {
        public Ingredients(string ingredientName, MesureUnit unit, double amount)
        {
            IngredientName = ingredientName;
            Unit = unit;
            Amount = amount;
        }

        public Ingredients()
        {
        }

        public string IngredientName { get; set; }

        public MesureUnit Unit { get; set; }

        public double Amount { get; set; }


    }
}
