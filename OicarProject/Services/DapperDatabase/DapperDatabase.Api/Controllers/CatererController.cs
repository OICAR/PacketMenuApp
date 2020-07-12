using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatererController : ControllerBase
    {
        private readonly IRepository<Caterer> _repository;

        public CatererController(IRepository<Caterer> repository)
        {
<<<<<<< HEAD
            repository = new CatererRepository
            (configuration);
=======
            _repository = repository;
>>>>>>> d1550256c0fa04190130e1ffcdc6fd80f2149b17
        }

        [HttpGet]
        public async Task<IEnumerable<Caterer>> GetAsync()
        {
            return await _repository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Caterer> GetByIdAsync(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Caterer entity)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(entity);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Caterer entity)
        {
            entity.IDCaterer = id;
            if (ModelState.IsValid)
            {
                _repository.Update(entity);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}