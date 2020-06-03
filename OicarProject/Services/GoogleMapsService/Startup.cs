using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsService.Data;
using GoogleMapsService.Data.Services;
using GoogleMapsService.Models;
using GoogleMapsService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace GoogleMapsService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddDbContext<Google_mapsContext>
            (options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(
                        "google")));
            services.AddDbContext<ApplicationDbContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString(
                            "DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(
                    options =>
                        options.SignIn
                            .RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<
                    ApplicationDbContext>();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;

            services
                .AddTransient<IEmailSender, EmailSender>();
            services
                .AddTransient<IGoogleMapsRepository,
                    SQLGoogleMapsRepository>();
            services.Configure<AuthMessageSenderOptions>(
                Configuration);

         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
