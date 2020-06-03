using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DapperDatabase.Api.Models
{
    public class BeverageRepository : IRepository<Beverage>
    {
        private readonly IConfiguration _configuration;
        public BeverageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<int> Add(Beverage entity)
        {
            var sql = "AddBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@Vegan", entity.EatingHabits.Vegan);
            queryParameters.Add("@Vegetarian", entity.EatingHabits.Vegetarian);
            queryParameters.Add("@LactoseIntolerant", entity.EatingHabits.LactoseIntolerant);
            queryParameters.Add("@CrohnsDisease", entity.EatingHabits.CrohnsDisease);
            queryParameters.Add("@CeliacDisease", entity.EatingHabits.CeliacDisease);
            queryParameters.Add("@Egg", entity.EatingHabits.Alergy.Egg);
            queryParameters.Add("@Peanut", entity.EatingHabits.Alergy.Peanut);
            queryParameters.Add("@Shellfish", entity.EatingHabits.Alergy.Shellfish);
            queryParameters.Add("@Soy", entity.EatingHabits.Alergy.Soy);
            queryParameters.Add("@Fish", entity.EatingHabits.Alergy.Fish);
            queryParameters.Add("@Sesame", entity.EatingHabits.Alergy.Sesame);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Beverage entity)
        {
            var sql = "UpdateeBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@Vegan", entity.EatingHabits.Vegan);
            queryParameters.Add("@Vegetarian", entity.EatingHabits.Vegetarian);
            queryParameters.Add("@LactoseIntolerant", entity.EatingHabits.LactoseIntolerant);
            queryParameters.Add("@CrohnsDisease", entity.EatingHabits.CrohnsDisease);
            queryParameters.Add("@CeliacDisease", entity.EatingHabits.CeliacDisease);
            queryParameters.Add("@Egg", entity.EatingHabits.Alergy.Egg);
            queryParameters.Add("@Peanut", entity.EatingHabits.Alergy.Peanut);
            queryParameters.Add("@Shellfish", entity.EatingHabits.Alergy.Shellfish);
            queryParameters.Add("@Soy", entity.EatingHabits.Alergy.Soy);
            queryParameters.Add("@Fish", entity.EatingHabits.Alergy.Fish);
            queryParameters.Add("@Sesame", entity.EatingHabits.Alergy.Sesame);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Beverage> Get(int id)
        {
            var sql = "GetBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<Beverage>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Beverage>> GetAll()
        {
            var sql = "GetAllBeverage";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<Beverage>(sql, commandType: CommandType.StoredProcedure);
        }
    }
}
