using Microsoft.AspNetCore.Http;
using PocketMenuUI.Models;
using PocketMenuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
  public  interface IExcel
    {

        public Task<List<Item>> Get(IFormFile document);


        public Task<string> PostExcel(CatererViewModel model);

    }
}
