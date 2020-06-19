using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public interface ISQLConnection
    {


        public SqlConnection Connect(string connectionString);
      
    }
}
