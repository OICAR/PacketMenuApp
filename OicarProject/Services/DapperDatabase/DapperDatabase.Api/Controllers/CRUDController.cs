using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController<T> : Controller where T : class
    {
        private readonly IRepository<T> repository;

        public CRUDController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //public async Task<IEnumerable<T>> GetAsync()
        //{
        //    return await repository.GetAll();
        //}


        [HttpGet("{id}")]
        public async Task<T> GetByIdAsync(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]T entity)
        {
            if (ModelState.IsValid)
            {
                repository.Add(entity);
            }
        }


        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]T entity)
        //{
        //    Type myType = entity.GetType();
        //    PropertyInfo propertyInfo = myType.GetProperties().Where(property => property.Name.StartsWith("ID")).FirstOrDefault();
        //    propertyInfo.GetValue(id);

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