using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Utils.CustomerUtilities
{
    public static class SqlCustomerUtility
    {

        public static DataTable GetPreferences(HashSet<string> preferences, HashSet<string> eatingHabits)
        {
            var output = new DataTable();

            output.Columns.Add("EatingHabit", typeof(string));
            output.Columns.Add("CategoryName", typeof(string));

            foreach (var item in preferences)
            {
            output.Rows.Add(item,"Favorite Food");

            }

            foreach (var item in eatingHabits)
            {
                output.Rows.Add(item, "Eating habit");
            }


            return output;
        }




    }
}
