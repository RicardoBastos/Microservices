using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Seguranca.Domain.Usuario;
using Seguranca.Infra.Mappings;
using System.IO;

namespace Seguranca.Infra.Context
{
    public class SegurancaContext : DbContext
    {
        public SegurancaContext(DbContextOptions<SegurancaContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }


    public class SegurancaContextFactory : IDesignTimeDbContextFactory<SegurancaContext>
    {
        public SegurancaContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<SegurancaContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            dbContextBuilder.UseSqlServer(connectionString);

            return new SegurancaContext(dbContextBuilder.Options);
        }
    }
}
