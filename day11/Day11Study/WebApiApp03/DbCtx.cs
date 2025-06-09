using Microsoft.EntityFrameworkCore;
using WebApiApp03.Entity;

namespace WebApiApp03
{
    public class DbCtx : DbContext
    {
        public DbSet<IoTDatas> IoTDatas => Set<IoTDatas>();

        public DbCtx(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IoTDatas>().ToTable("iot_datas");
            modelBuilder.Entity<IoTDatas>().HasKey(iot => iot.Id);
        }
    }

}
