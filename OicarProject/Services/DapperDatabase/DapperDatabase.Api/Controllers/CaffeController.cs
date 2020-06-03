using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaffeController : ControllerBase
    {

        private readonly IRepository<Caffe> repository;

        public CaffeController(IConfiguration configuration)
        {
            repository = new CaffeRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<Caffe>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Caffe> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Caffe customer)
        {
            if (ModelState.IsValid)
            {
                repository.Add(customer);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Caffe customer)
        {
            customer.IDCaffe = id;
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