using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperDatabase.Api.Controllers
{
    [Produces("application/json")] 
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {


        private readonly IRepository<Customer> repository;

        public CustomerController(IConfiguration configuration)
        {
            repository = new CustomerRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.Add(customer);
            }
        }

        [ProducesResponseType(typeof(Customer), 200)]
        [HttpPut("{id}")]
        public void Put(int id, [FromQuery]Customer customer)
        {
            customer.IDCustomer = id;
            if (ModelState.IsValid)
            {
                repository.Update(customer);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

    }
}