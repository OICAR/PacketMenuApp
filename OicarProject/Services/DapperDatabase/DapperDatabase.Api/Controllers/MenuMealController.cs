using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMealController : ControllerBase
    {

        private readonly IRepository<MenuMeal> repository;

        public MenuMealController(IConfiguration configuration)
        {
            repository = new MenuMealRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<MenuMeal>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<MenuMeal> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]MenuMeal entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]MenuMeal entity)
        {
            entity.IDMenuMeal = id;
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