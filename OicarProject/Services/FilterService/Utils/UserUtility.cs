using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class UserUtility
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