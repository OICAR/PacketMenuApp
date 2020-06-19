using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public interface ICustomerRepository<T> where T : class
    {

        Task<int> Add(T entity);


    }
}
