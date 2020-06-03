using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IRepository<Meal> repository;

        public MealController(IConfiguration configuration)
        {
            repository = new MealRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<Meal>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Meal> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Meal entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Meal entity)
        {
            entity.IDMeal = id;
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