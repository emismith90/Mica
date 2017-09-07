using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Antares.Essentials.Data.Extensions;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Data.Models.Effort;
using Mica.Domain.Data.Models.Client;
using Mica.Domain.Data.Models.Ticket;
using Mica.Domain.Data.TypeBuilders.Inventory;
using Mica.Domain.Data.TypeBuilders.Effort;
using Mica.Domain.Data.TypeBuilders.Client;
using Mica.Domain.Data.TypeBuilders.Ticket;

namespace Mica.Domain.Data.Contexts
{
    public class MicaContext : IdentityDbContext
    {
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
        public DbSet<InventoryOperationEntity> InventoryOperations { get; set; }

        public DbSet<EffortEntity> Efforts { get; set; }
        public DbSet<EffortOperationEntity> EffortOperations { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketStatusEntity> TicketStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new MaterialType());
            modelBuilder.AddConfiguration(new InventoryType());
            modelBuilder.AddConfiguration(new InventoryOperationType());

            modelBuilder.AddConfiguration(new EffortType());
            modelBuilder.AddConfiguration(new EffortOperationType());

            modelBuilder.AddConfiguration(new ClientType());

            modelBuilder.AddConfiguration(new TicketType());
            modelBuilder.AddConfiguration(new TicketStatusType());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();

            var config = builder.Build();

            optionsBuilder.UseMySql(config["ConnectionString"]);
        }
    }
}
