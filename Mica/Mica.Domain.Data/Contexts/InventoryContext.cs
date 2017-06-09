using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Models;
using Mica.Domain.Data.TypeBuilders;
using Mica.Domain.Data.TypeBuilders.Extensions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mica.Domain.Data.Contexts
{
    public class InventoryContext : DbContext
    {
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<MaterialVariantEntity> MaterialVariants { get; set; }
        public DbSet<MaterialVariantEntity> Inventories { get; set; }
        public DbSet<MaterialVariantEntity> InventoryOperations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new MaterialType());
            modelBuilder.AddConfiguration(new MaterialVariantType());
            modelBuilder.AddConfiguration(new InventoryType());
            modelBuilder.AddConfiguration(new InventoryOperationType());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseMySql(config.GetConnectionString("MicaConnection"));
        }
    }
}
