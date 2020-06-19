using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.DAL.SSMS
{
   public interface ISQLConnection
    {
        public SqlConnection Connect(IConfiguration _configuration);
    }
}
