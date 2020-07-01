using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Models
{

<<<<<<< HEAD:OicarProject/PocketMenuProject/PocketMenuUI/Models/Ingredients.cs
   public enum MesureUnit {
=======
    public enum MesureUnit {
>>>>>>> 1377a2954c3908b2325add34f40d05be11047a80:OicarProject/PocketMenuProject/PocketMenuUI/Models/Ingedients.cs


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
