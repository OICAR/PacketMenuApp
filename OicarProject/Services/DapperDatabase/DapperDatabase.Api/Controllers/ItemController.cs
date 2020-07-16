using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDatabase.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository<Item> _repository;



        public ItemController(IItemRepository<Item> repository)
        {
            _repository = repository;
        }




        [HttpPost]
        public void Post(List<Item> entity)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(entity);
                
            }
           
        }






    }
}