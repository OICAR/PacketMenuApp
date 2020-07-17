
using Dapper;
using DapperDatabase.Api.DAL.SSMS;
using DapperDatabase.Api.Utils.CustomerUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDatabase.Api.Models
{
    public class ItemRepository : IItemRepository<Item>
    {

        private readonly IConfiguration _configuration;
        ISQLConnection _connection;


        public ItemRepository(IConfiguration configuration, ISQLConnection connection)
        {
            _configuration = configuration;
            _connection = connection;
        }


        //public async Add(List<Item> entity)
        //{

        //    using (IDbConnection cnn = _connection.Connect(_configuration))
        //    {
        //        var sql = "addItems";

                


        //        //var p = new
        //        //{
        //        //    customerHabbits = getDataset.AsTableValuedParameter("BasicCDT"),
        //        //    Customer=entity.FullName
        //        //};


        //        foreach (var item in entity)
        //        {
        //            var getDataset = SqlItemUtility.GetPreferences(item.Ingredients);

        //            var queryParameters = new DynamicParameters();
        //            queryParameters.Add("@Title", item.Title);
        //            //queryParameters.Add("@Price", item.Price);
        //            //queryParameters.Add("@Ingredients", getDataset.AsTableValuedParameter("ItemsType"));
        //            await cnn.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
        //        }

        //    }


        //}


        public async void Add(List<Item> entity)
        {

            using (IDbConnection cnn = _connection.Connect(_configuration))
            {
                var sql = "addItems";

                //var getDataset = SqlCustomerUtility.GetPreferences(entity.Preferences, entity.EatingHabits);


                //var p = new
                //{
                //    customerHabbits = getDataset.AsTableValuedParameter("BasicCDT"),
                //    Customer=entity.FullName
                //};

                var queryParameters = new DynamicParameters();
                foreach (var item in entity)
                {
                    var getDataset = SqlItemUtility.GetPreferences(item.Ingredients);

                    queryParameters.Add("@Title", item.Title);
                    queryParameters.Add("@Price", item.Price);
                    queryParameters.Add("@Ingredients", getDataset.AsTableValuedParameter("ItemsType"));
                    queryParameters.Add("@IDCateringFacility", item.ID);

                    await cnn.ExecuteAsync(sql, queryParameters, commandType: CommandType.StoredProcedure);
                }



                //var queryParameters = new DynamicParameters();
                //queryParameters.Add("@customerHabbits", getDataset.AsTableValuedParameter("BasicCDT"));
                //queryParameters.Add("@CustomerID", entity.UserID);
                //queryParameters.Add("@Customer", entity.FullName);
                //queryParameters.Add("@Gender", entity.Gender);



            }



        }


            public Task<IEnumerable<Item>> Get(string searchCondition)
        {
            throw new NotImplementedException();
        }
    }
}