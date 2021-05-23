using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using product_catalog.Areas.Identity.Data;
using product_catalog.Data;

[assembly: HostingStartup(typeof(product_catalog.Areas.Identity.IdentityHostingStartup))]
namespace product_catalog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<product_catalogContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("product_catalogContextConnection")));

                //services.AddDefaultIdentity<product_catalogUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<product_catalogContext>();
            });
        }
    }
}