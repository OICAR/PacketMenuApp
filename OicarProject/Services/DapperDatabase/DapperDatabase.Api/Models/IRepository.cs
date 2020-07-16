using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
         int Adding(Caterer entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);

    }
}
