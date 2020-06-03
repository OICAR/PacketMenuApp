using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Api_Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(SayHelloWorldMiddleware);
            app.UseOcelot();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            
        }
        
        private RequestDelegate SayHelloWorldMiddleware(RequestDelegate next)
        {
            return async ctx =>
            {

                if (ctx.Request.Path.StartsWithSegments("/"))
                {
                    await next(ctx);

                    await ctx.Response.WriteAsync("Hello, World");
                }


                else
                {
                    await next(ctx);
                    //if (ctx.Response.StatusCode==200)
                    //{

                    //}

                }

            };
        }

    }
}
