//using System;
//using BariiLiii.Areas.Identity.Data;
//using BariiLiii.Data;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(BariiLiii.Areas.Identity.IdentityHostingStartup))]
//namespace BariiLiii.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<BariiLiiiContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("BariiLiiiContextConnection")));

//                services.AddDefaultIdentity<BariiLiiiUser>(options => options.SignIn.RequireConfirmedAccount = false)
//                    .AddEntityFrameworkStores<BariiLiiiContext>();
//            });
//        }
//    }
//}