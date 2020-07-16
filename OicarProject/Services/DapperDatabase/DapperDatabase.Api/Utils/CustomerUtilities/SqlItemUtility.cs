using DapperDatabase.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Utils.CustomerUtilities
{
    public class SqlItemUtility
    {

        public static DataTable GetPreferences( List<Ingredients> Items)
        {
            var output = new DataTable();



            output.Columns.Add("IngredientName", typeof(string));
     
            foreach (var item in Items)
            {
                output.Rows.Add(item.IngredientName);
            }


            return output;
        }


    }
}
