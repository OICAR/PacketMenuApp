using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuBeverageController : ControllerBase
    {
        private readonly IRepository<MenuBeverage> repository;

        public MenuBeverageController(IConfiguration configuration)
        {
            repository = new MenuBeverageRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<MenuBeverage>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<MenuBeverage> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]MenuBeverage entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]MenuBeverage entity)
        {
            entity.IDMenuBeverage = id;
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