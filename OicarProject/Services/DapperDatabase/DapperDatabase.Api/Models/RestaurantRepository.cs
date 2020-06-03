using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly IConfiguration _configuration;
        public RestaurantRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Restaurant entity)
        {
            var sql = "AddRestaurant";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@Rating", entity.Rating);
            queryParameters.Add("@Country", entity.Address.Country);
            queryParameters.Add("@City", entity.Address.City);
            queryParameters.Add("@PinCode", entity.Address.PinCode);
            queryParameters.Add("@Street", entity.Address.Street);
            queryParameters.Add("@Number", entity.Address.Number);
            queryParameters.Add("@NameCaterer", entity.Caterer.Name);
            queryParameters.Add("@OIB", entity.Caterer.OIB);
            queryParameters.Add("@MenuID", entity.MenuID);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteRestaurant";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<Restaurant> Get(int id)
        {
            var sql = "GetRestaurant";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<Restaurant>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            var sql = "GetAllRestaurant";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<Restaurant>(sql, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Restaurant entity)
        {
            var sql = "UpdateRestaurant";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", entity.Name);
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@Rating", entity.Rating);
            queryParameters.Add("@Country", entity.Address.Country);
            queryParameters.Add("@City", entity.Address.City);
            queryParameters.Add("@PinCode", entity.Address.PinCode);
            queryParameters.Add("@Street", entity.Address.Street);
            queryParameters.Add("@Number", entity.Address.Number);
            queryParameters.Add("@NameCaterer", entity.Caterer.Name);
            queryParameters.Add("@OIB", entity.Caterer.OIB);
            queryParameters.Add("@MenuID", entity.MenuID);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
