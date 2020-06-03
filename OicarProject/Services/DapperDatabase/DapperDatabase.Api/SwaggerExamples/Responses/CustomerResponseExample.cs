using DapperDatabase.Api.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.SwaggerExamples.Responses
{
    public class CustomerResponseExample : IExamplesProvider<IEnumerable<Customer>>
    {
        //public Customer GetExamples()
        //{
        //    return new Customer
        //    {
        //        Name = "response name",
        //        Surname = "response surname",
        //        Address = new Address
        //        {
        //            Country = "response country",
        //            City = "response city",
        //            PinCode = "response picode",
        //            Street = "response street",
        //            Number = "response number",
        //        },
        //        EatingHabits = new EatingHabits
        //        {
        //            CeliacDisease = false,
        //            CrohnsDisease = false,
        //            LactoseIntolerant = false,
        //            Vegan = false,
        //            Vegetarian = false,
        //            Alergy = new Alergy()
        //        }
        //    };
        //}
        public IEnumerable<Customer> GetExamples()
        {
            return new List<Customer>
            {
                    new Customer
                    {
                         Name = "response name",
                        Surname = "response surname",
                        Address = new Address
                    {
                        Country = "response country",
                        City = "response city",
                        PinCode = "response picode",
                        Street = "response street",
                        Number = "response number",
                    },
                    EatingHabits = new EatingHabits
                    {
                        CeliacDisease = false,
                        CrohnsDisease = false,
                        LactoseIntolerant = false,
                        Vegan = false,
                        Vegetarian = false,
                        Alergy = new Alergy()
                    }
                }
            };
        }
    }
}
