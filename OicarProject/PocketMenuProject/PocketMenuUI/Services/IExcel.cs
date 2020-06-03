using PocketMenuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
  public  interface IExcel
    {

        public  void Get();


        public Task<string> PostExcel(CatererViewModel model);

    }
}
