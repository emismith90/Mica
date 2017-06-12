using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mica.Domain.Data.Models;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Data.TypeBuilders.Extensions;
using Mica.Domain.Data.TypeBuilders.Inventory;
using Mica.Domain.Data.TypeBuilders;

namespace Mica.Domain.Data.Contexts
{
    public class MicaContext : IdentityDbContext
    {
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
        public DbSet<InventoryOperationEntity> InventoryOperations { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new MaterialType());
            modelBuilder.AddConfiguration(new InventoryType());
            modelBuilder.AddConfiguration(new InventoryOperationType());
            modelBuilder.AddConfiguration(new TicketType());

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
