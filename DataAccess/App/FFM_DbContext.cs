using Microsoft.EntityFrameworkCore;

namespace FFM.DataAccess.App
{
    public class FFM_DbContext  : DbContext
    {

        public FFM_DbContext(DbContextOptions<FFM_DbContext> options)
          : base(options)
        { }


        public DbSet<FFM.DataAccessModels.App.customerParts> customerParts { get; set; }
        public DbSet<FFM.DataAccessModels.App.customerPartsHeader> customerPartsHeader { get; set; }

        public DbSet<FFM.DataAccessModels.App.orderParts> orderParts { get; set; }
        public DbSet<FFM.DataAccessModels.App.orderPartsHeader> orderPartsHeader { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        //const string connectionString = @"Server=mi3-wsq3.a2hosting.com; Database=ctgcontr_FfmDBContext;User Id=ctgcontr_FfmDBContext; Password=Dngk41?2;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlite("Data Source=sqlitedemo.db");
        }

    }
}
