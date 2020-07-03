using PocketMenuUI.Infrastructure;
using PocketMenuUI.Models;
using PocketMenuUI.Utils.HttpMethodsUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PocketMenuUI.Services
{
    public class MenuService : IMenu
    {

        private readonly HttpClient _httpClientFactory;
        private readonly IApi _api;



        public MenuService(HttpClient httpClientFactory, IApi api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }

        public  void PostMenu(Menu model)
        {
            var uri = _api.PostCaterer();

            HttpPost.PostVoid <Menu>(uri, model, _httpClientFactory);

        }
    }
}
