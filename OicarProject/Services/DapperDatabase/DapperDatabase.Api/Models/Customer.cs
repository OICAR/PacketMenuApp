using FluentValidation;

namespace DapperDatabase.Api.Models
{
    public class Customer
    {
        public int IDCustomer { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public EatingHabits EatingHabits { get; set; }
        public Address Address { get; set; }

    }


    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(sample => sample.Name).NotNull();
            RuleFor(sample => sample.Name).NotEmpty();
            RuleFor(sample => sample.Surname).NotNull();
            RuleFor(sample => sample.Surname).NotEmpty();
        }

    }
}
