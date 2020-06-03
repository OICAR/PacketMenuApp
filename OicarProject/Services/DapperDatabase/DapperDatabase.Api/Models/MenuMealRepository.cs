using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class MenuMealRepository : IRepository<MenuMeal>
    {
        private readonly IConfiguration _configuration;
        public MenuMealRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(MenuMeal entity)
        {
            var sql = "AddMenuMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Price", entity.Price);
            queryParameters.Add("@BeverageID", entity.IDMeal);
            queryParameters.Add("@MenuID", entity.IDMenu);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(MenuMeal entity)
        {
            var sql = "UpdateMenuMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", entity.IDMenuMeal);
            queryParameters.Add("@Price", entity.Price);
            queryParameters.Add("@BeverageID", entity.IDMeal);
            queryParameters.Add("@MenuID", entity.IDMenu);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteMenuMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<MenuMeal> Get(int id)
        {
            var sql = "GetMenuMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<MenuMeal>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<MenuMeal>> GetAll()
        {
            var sql = "GetAllMenuMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<MenuMeal>(sql, commandType: CommandType.StoredProcedure);
        }
    }
}
