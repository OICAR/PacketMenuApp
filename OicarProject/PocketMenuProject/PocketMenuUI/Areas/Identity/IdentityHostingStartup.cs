using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocketMenuUI.Data;
using PocketMenuUI.Services;

[assembly: HostingStartup(typeof(PocketMenuUI.Areas.Identity.IdentityHostingStartup))]
namespace PocketMenuUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
              
            });
        }
    }
}