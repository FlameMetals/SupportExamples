using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore50.StartupExtensions
{
    public class DbContextExtension
    {

        /// <summary>
        /// Startup Add Config for DbContext
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="Configuration">IConfiguration</param>
        public static void AddDbContextConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            //var connectionString = @"Server=mi3-wsq3.a2hosting.com; Database=ctgcontr_FfmDBContext;User Id=ctgcontr_FfmDBContext; Password=Dngk41?2;";
            services.AddDbContext<DataAccess.App.DbContext>
                (
                    options => options.UseSqlServer(Configuration.GetConnectionString("App"), b => b.MigrationsAssembly("DataAccess")
               ));

            services.AddDbContext<FFM.DataAccess.VisualShop.VS_DbContext>
                (
                    options => options.UseSqlServer(Configuration.GetConnectionString("VisualShop")
               ));

            services.AddDbContext<FFM.DataAccess.SSiLoadEntry.SSi_DbContext>
                (
                    options => options.UseSqlServer(Configuration.GetConnectionString("SSiLoadEntry")
               ));

        }

        /// <summary>
        /// Startup Use Config for DbContext
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void UseDbContextConfig(this IApplicationBuilder app)
        {

        }

    }
}
