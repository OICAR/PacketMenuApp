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
    public class MealRepository : IRepository<Meal>
    {
        private readonly IConfiguration _configuration;
        public MealRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<int> Add(Meal entity)
        {
            var sql = "AddMeal";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@Amount", entity.Amount);
            queryParameters.Add("@Ingredients", entity.Ingredients);
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
            var sql = "DeleteMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Meal entity)
        {
            var sql = "UpdateMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@Amount", entity.Amount);
            queryParameters.Add("@Ingredients", entity.Ingredients);
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

        public async Task<Meal> Get(int id)
        {
            var sql = "GetMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<Meal>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Meal>> GetAll()
        {
            var sql = "GetAllMeal";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<Meal>(sql, commandType: CommandType.StoredProcedure);
        }

        public int Adding(Caterer entity)
        {
            throw new NotImplementedException();
        }
    }
}
