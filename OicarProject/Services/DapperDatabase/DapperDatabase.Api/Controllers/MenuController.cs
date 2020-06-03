using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IRepository<Menu> repository;

        public MenuController(IConfiguration configuration)
        {
            repository = new MenuRepository(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<Menu>> GetAsync()
        {
            return await repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Menu> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Menu entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Menu entity)
        {
            entity.IDMenu = id;
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