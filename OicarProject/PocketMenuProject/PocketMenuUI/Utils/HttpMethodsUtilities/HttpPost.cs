using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PocketMenuUI.Utils.HttpMethodsUtilities
{
    public static class HttpPost
    {


        public static async void PostVoid <T>(string postUrl, T entity,HttpClient _client)where T :class
            {
              

                var request = new HttpRequestMessage(HttpMethod.Post, postUrl);


                request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(entity));

                request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var client = _client;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 await client.SendAsync(request);


            }



    }
}
