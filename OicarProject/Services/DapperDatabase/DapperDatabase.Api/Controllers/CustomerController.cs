using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.DAL.SSMS;
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


        private readonly ICustomerRepository<CustomerDTO> _repository;


        public CustomerController(ICustomerRepository<CustomerDTO> repository)
        {
            _repository = repository ;
        }

        //[HttpGet]
        //public async Task<IEnumerable<Customer>> GetAsync()
        //{
        //    return await repository.GetAll();
        //}


        //[HttpGet("{id}")]
        //public async Task<CustomerDTO> GetByIdAsync(int id)
        //{
        //    return await _repository.Get(id);
        //}

        [HttpPost]
        public void Post(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(customer);
            }
        }

        //[ProducesResponseType(typeof(Customer), 200)]
        //[HttpPut("{id}")]
        //public void Put(int id, [FromQuery]Customer customer)
        //{
        //    customer.IDCustomer = id;
        //    if (ModelState.IsValid)
        //    {
        //        repository.Update(customer);
        //    }
        //}

        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    repository.Delete(id);
        //}

    }
}