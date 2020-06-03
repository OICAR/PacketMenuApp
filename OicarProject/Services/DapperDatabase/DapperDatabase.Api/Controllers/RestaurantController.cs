using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly IRepository<Restaurant> repository;

        public RestaurantController(IConfiguration configuration)
        {
            repository = new RestaurantRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<Restaurant>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Restaurant entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Restaurant entity)
        {
            entity.IDRestaurant = id;
            if (ModelState.IsValid)
            {
                repository.Update(entity);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}