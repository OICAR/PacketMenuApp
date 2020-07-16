using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace DapperDatabase.Api.Models
{
    public class MenuBeverageRepository : IRepository<MenuBeverage>
    {
        private readonly IConfiguration _configuration;
        public MenuBeverageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(MenuBeverage entity)
        {
            var sql = "AddMenuBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Price", entity.Price);
            queryParameters.Add("@BeverageID", entity.IDBeverage);
            queryParameters.Add("@MenuID", entity.IDMenu);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteMenuBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(MenuBeverage entity)
        {
            var sql = "UpdateMenuBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", entity.IDMenuBeverage);
            queryParameters.Add("@Price", entity.Price);
            queryParameters.Add("@BeverageID", entity.IDBeverage);
            queryParameters.Add("@MenuID", entity.IDMenu);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<MenuBeverage> Get(int id)
        {
            var sql = "GetMenuBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<MenuBeverage>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<MenuBeverage>> GetAll()
        {
            var sql = "GetAllMenuBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<MenuBeverage>(sql, commandType: CommandType.StoredProcedure);
        }

        public int Adding(Caterer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
