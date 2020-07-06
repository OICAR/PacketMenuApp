using Dapper;
using DapperDatabase.Api.DAL.SSMS;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class CatererRepository : IRepository<Caterer>
    {

        private readonly IConfiguration _configuration;
        ISQLConnection _connection;
        public CatererRepository(IConfiguration configuration, ISQLConnection connection)
        {
            _configuration = configuration;
            _connection = connection;

        }

        public async Task<int> Add(Caterer entity)
        {
            var sql = "AddCaterer";
            using ( var connection = _connection.Connect(_configuration))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@IDCaterer", entity.IDCaterer);
                queryParameters.Add("@Name", entity.Name);
                queryParameters.Add("@OIB", entity.OIB);

                return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteCaterer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<Caterer> Get(int id)
        {
            var sql = "GetCaterer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<Caterer>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Caterer>> GetAll()
        {
            var sql = "GetAllCaterer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<Caterer>(sql, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Caterer entity)
        {
            var sql = "UpdateCaterer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", entity.IDCaterer);
            queryParameters.Add("@Name", entity.Name);
            queryParameters.Add("@OIB", entity.OIB);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
