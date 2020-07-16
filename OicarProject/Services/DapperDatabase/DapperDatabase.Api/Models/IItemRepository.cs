using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
  public  interface IItemRepository<T> where T : class
    {

        Task<IEnumerable<T>> Get(string searchCondition);
     void   Add(List<T> entity);
    

    }
}
