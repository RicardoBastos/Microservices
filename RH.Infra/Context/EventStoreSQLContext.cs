using Core.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RH.Infra.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class EventStoreSqlContextFactory : IDesignTimeDbContextFactory<EventStoreSqlContext>
    {
        public EventStoreSqlContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<EventStoreSqlContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            dbContextBuilder.UseSqlServer(connectionString);

            return new EventStoreSqlContext(dbContextBuilder.Options);
        }
    }
}
