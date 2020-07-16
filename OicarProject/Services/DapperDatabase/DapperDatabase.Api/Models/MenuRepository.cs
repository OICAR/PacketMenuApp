using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace DapperDatabase.Api.Models
{
    public class MenuRepository : IRepository<Menu>
    {
        private readonly IConfiguration _configuration;
        public MenuRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Menu entity)
        {
            var sql = "AddMenu";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", entity.Name);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteMenu";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Menu entity)
        {
            var sql = "UpdateMenu";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", entity.IDMenu);
            queryParameters.Add("@Name", entity.Name);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Menu> Get(int id)
        {
            var sql = "GetMenu";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<Menu>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            var sql = "GetAllMenu";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<Menu>(sql, commandType: CommandType.StoredProcedure);
        }

        public int Adding(Caterer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
