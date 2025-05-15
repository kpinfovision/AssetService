using Microsoft.EntityFrameworkCore;
using Xome.Cascase2.AssetService.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Xome.Cascase2.AssetService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Asset> ASSET { get; set; }              


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Asset>().HasNoKey();

            //modelBuilder.Entity<ManualTask>().HasData(
            //    new ManualTask { Id = 1, TaskId = 1, TaskName = "MarketingRequestTask" },
            //    new ManualTask { Id = 2, TaskId = 2, TaskName = "LoadValuationTask" }
            //);      
        }


    }
}
