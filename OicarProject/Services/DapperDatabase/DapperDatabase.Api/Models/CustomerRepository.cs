using Dapper;
using DapperDatabase.Api.DAL.SSMS;
using DapperDatabase.Api.Utils.CustomerUtilities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class CustomerRepository : ICustomerRepository<CustomerDTO>
    {

        private readonly IConfiguration _configuration;
        ISQLConnection _connection;
        public CustomerRepository(IConfiguration configuration, ISQLConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
        }                


        public async Task<int> Add(CustomerDTO entity)
        {

            using (IDbConnection cnn = _connection.Connect(_configuration))
            {
                var sql = "AddCustomertest";

                var getDataset = SqlCustomerUtility.GetPreferences(entity.Preferences, entity.EatingHabits);


                //var p = new
                //{
                //    customerHabbits = getDataset.AsTableValuedParameter("BasicCDT"),
                //    Customer=entity.FullName
                //};


                var queryParameters = new DynamicParameters();
                queryParameters.Add("@customerHabbits", getDataset.AsTableValuedParameter("BasicCDT"));
                queryParameters.Add("@CustomerID", entity.UserID);
                queryParameters.Add("@Customer", entity.FullName);
                queryParameters.Add("@Gender", entity.Gender);


                return await cnn.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);


            }


            //using var connection = 
            ////using var connection = new SqlConnection(_configuration.GetConnectionString("LocalDB"));
            //connection.Open();

            //var queryParameters = new DynamicParameters();
            //queryParameters.Add("@ID", 6);
            //queryParameters.Add("@FullName", entity.FullName);
            
 

        }

        public async Task<int> Delete(int id)
        {
            var sql = "DeleteCustomer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Update(CustomerDTO entity)
        {
            var sql = "UpdateCustomer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            var queryParameters = new DynamicParameters();
            //queryParameters.Add("@Id", entity.IDCustomer);
            //queryParameters.Add("@Name", entity.Name);
            //queryParameters.Add("@Surname", entity.Surname);
            //queryParameters.Add("@Vegan", entity.EatingHabits.Vegan);
            //queryParameters.Add("@Vegetarian", entity.EatingHabits.Vegetarian);
            //queryParameters.Add("@LactoseIntolerant", entity.EatingHabits.LactoseIntolerant);
            //queryParameters.Add("@CrohnsDisease", entity.EatingHabits.CrohnsDisease);
            //queryParameters.Add("@CeliacDisease", entity.EatingHabits.CeliacDisease);
            //queryParameters.Add("@Egg", entity.EatingHabits.Alergy.Egg);
            //queryParameters.Add("@Peanut", entity.EatingHabits.Alergy.Peanut);
            //queryParameters.Add("@Shellfish", entity.EatingHabits.Alergy.Shellfish);
            //queryParameters.Add("@Soy", entity.EatingHabits.Alergy.Soy);
            //queryParameters.Add("@Fish", entity.EatingHabits.Alergy.Fish);
            //queryParameters.Add("@Sesame", entity.EatingHabits.Alergy.Sesame);
            //queryParameters.Add("@Country", entity.Address.Country);
            //queryParameters.Add("@City", entity.Address.City);
            //queryParameters.Add("@PinCode", entity.Address.PinCode);
            //queryParameters.Add("@Street", entity.Address.Street);
            //queryParameters.Add("@Number", entity.Address.Number);

            return await connection.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerDTO> Get(int id)
        {
            var sql = "GetCustomer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@id", id);
            var result = await connection.QueryAsync<CustomerDTO>(sql, queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var sql = "GetAllCustomer";
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return await connection.QueryAsync<CustomerDTO>(sql, commandType: CommandType.StoredProcedure);
        }
    }
}
