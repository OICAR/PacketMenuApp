using DapperDatabase.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Utils
{
    public static class CustomerUtility
    {

        public static Customer SQLCustomer(CustomerDTO requestCustomer)

        {

            string[] fullName = EditName(requestCustomer.FullName);

            EditSurname(fullName);


            EditEatingHabits(requestCustomer.EatingHabits);


            return new Customer { Name = fullName[0], Surname = fullName[1],};
        
        
        
        }

        private static EatingHabits EditEatingHabits(Dictionary<string, bool> eatingHabits)
        {

            EatingHabits habits = new EatingHabits();


            foreach (var item in eatingHabits)
            {

                switch (item.Key)
                {
                  
                    
                    default:
                }


            }



        }

        private static string EditSurname(string[] fullName)
        {
            string surname = null;
            for (int i = 1; i <= fullName.Length; i++)
            {
                surname += fullName[i] + "";
            }
            return surname;
        }

        private static string[] EditName(string fullName)
        {
            return Regex.Split(fullName, @"(?<!^)(?=[A-Z])");

        }
    }
}
