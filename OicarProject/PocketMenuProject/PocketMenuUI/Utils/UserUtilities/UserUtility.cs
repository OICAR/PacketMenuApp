using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Utils.UserUtilities
{
    public static class UserUtility
    {

        public static HashSet<string> GetSelectedHabits(Dictionary<string, bool> eatingHabits)
        {

            HashSet<string> temp = new HashSet<string>();



            foreach (var item in eatingHabits)
            {

                if (item.Value==true)
                {
                    temp.Add(item.Key);

                }

            }

            return temp;

        }

    }
}
