using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FFM.API.StartupExtensions
{
    /// <summary>
    /// API DbContext Startup Extension
    /// </summary>
    public static class DbContextExtension
    {
        /// <summary>
        /// Startup Add Config for DbContext
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="Configuration">IConfiguration</param>
        public static void AddDbContextConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            //var connectionString = @"Server=mi3-wsq3.a2hosting.com; Database=ctgcontr_FfmDBContext;User Id=ctgcontr_FfmDBContext; Password=Dngk41?2;";
            services.AddDbContext<FFM.DataAccess.App.FFM_DbContext>
                (
                    //options => options.UseSqlite(Configuration.GetConnectionString("App"), b => b.MigrationsAssembly("DataAccess"))
                    //options => options.UseSqlServer(Configuration.GetConnectionString("App"), b => b.MigrationsAssembly("DataAccess"))
                    options => options.UseInMemoryDatabase("FFM_DbContext")
               ) ;


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