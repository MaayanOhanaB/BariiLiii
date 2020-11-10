using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BariiLiii.Areas.Identity.Data;
using BariiLiii.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BariiLiii
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Initialization by DbInitializer
            //Separation between build and run
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BariiLiiiContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex) { }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
