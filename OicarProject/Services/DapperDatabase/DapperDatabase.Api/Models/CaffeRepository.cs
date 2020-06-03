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
    public class CaffeRepository : IRepository<Caffe>
    {
        private readonly IConfiguration _configuration;
        public CaffeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Caffe entity)
        {
            var sql = "AddCaffe";
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
            var sql = "DeleteCaffe";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<Caffe> Get(int id)
        {
            var sql = "GetCaffe";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<Caffe>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Caffe>> GetAll()
        {
            var sql = "GetAllCaffe";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<Caffe>(sql, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(Caffe entity)
        {
            var sql = "UpdateCaffe";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", entity.IDCaffe);
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
