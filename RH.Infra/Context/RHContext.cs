using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RH.Domain.Usuario;
using RH.Infra.Mappings;
using System.IO;

namespace RH.Infra.Context
{
    public class RHContext : DbContext
    {
        public RHContext(DbContextOptions<RHContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }


    public class RHContextFactory : IDesignTimeDbContextFactory<RHContext>
    {
        public RHContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<RHContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            dbContextBuilder.UseSqlServer(connectionString);

            return new RHContext(dbContextBuilder.Options);
        }
    }
}
