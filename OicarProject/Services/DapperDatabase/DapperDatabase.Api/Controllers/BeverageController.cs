using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly IRepository<Beverage> repository;

        public BeverageController(IConfiguration configuration)
        {
            repository = new BeverageRepository(configuration);
        }

        //[HttpGet]
        //public async Task<IEnumerable<Beverage>> GetAsync()
        //{
        //    return await repository.GetAll();
        //}


        [HttpGet("{id}")]
        public async Task<Beverage> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Beverage entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]Beverage entity)
        //{
        //    entity.IDBeverage = id;
        //    if (ModelState.IsValid)
        //    {
        //        repository.Update(entity);
        //    }
        //}

        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    repository.Delete(id);
        //}
    }
}