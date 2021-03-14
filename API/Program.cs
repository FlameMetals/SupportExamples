using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FFM.DataAccess.App;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace FFM.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<FFM_DbContext>();
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                }
                catch (Exception exception)
                {
                    //FFM.SharedCode.Logging.WebHelper.LogWebError("API", "API.Program.Main", exception);
                }
            }

            // run the web app
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
