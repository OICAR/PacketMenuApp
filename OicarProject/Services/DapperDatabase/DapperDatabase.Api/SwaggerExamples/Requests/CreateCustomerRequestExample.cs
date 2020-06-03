using DapperDatabase.Api.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DapperDatabase.Api.SwaggerExamples.Requests
{
    public class CreateCustomerRequestExample : IExamplesProvider<Customer>
    {
        public Customer GetExamples()
        {
            return new Customer
            {
                Name = "new name",
                Surname = "new surname",
                Address = new Address
                {
                    Country = "new country",
                    City = "new city",
                    PinCode = "new picode",
                    Street = "new street",
                    Number = "new number",
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
            };
        }
    }
}
