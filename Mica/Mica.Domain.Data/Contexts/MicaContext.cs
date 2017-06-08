using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Models;
using Mica.Domain.Data.TypeBuilders;
using Mica.Domain.Data.TypeBuilders.Extensions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mica.Domain.Data.Contexts
{
    public class MicaContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new TodoType());

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
