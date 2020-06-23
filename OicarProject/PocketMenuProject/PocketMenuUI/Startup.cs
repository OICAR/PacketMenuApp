using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PocketMenuUI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocketMenuUI.Models;
using PocketMenuUI.Services;
using AutoMapper;
using PocketMenuUI.Infrastructure;

namespace PocketMenuUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalDB")));
            services.AddDbContext<JelovnikDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("JelovnikConnection")));
            services.AddDefaultIdentity<ApplicationUser>
            (options => options.SignIn
            .RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IApi, LocalAPI>();

            services.AddTransient<IJelovnikRepository, 
                SQLRepository>();
            services.AddSession(options =>
            {
                options.IdleTimeout=TimeSpan.FromSeconds(3600);
            });
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration.GetValue<string>("web:client_id");
                googleOptions.ClientSecret = Configuration.GetValue<string>("web:client_secret");
            });
        
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews()
                .Services
                .AddHttpClientServices(Configuration);
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

    
     }
    static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {

            //add http client services 
            services.AddHttpClient<IWatherForecast, WeatherForecastService>()
                   .SetHandlerLifetime(TimeSpan.FromMinutes(5)); //Sample. Default lifetime is 2 minutes
            services.AddHttpClient<IQRCodeGenerator,QRService>();
            services.AddHttpClient<IGoogleMap, GoogleMapsService>();
            services.AddHttpClient<IExcel, ExcelService>();
            services.AddHttpClient<IUsers, UserService>();

            return services;



        }

    }
}
