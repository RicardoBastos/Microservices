using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Usuario;

namespace RH.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {   
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(120)")
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(c => c.Salario)
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            builder.Property(c => c.Email)
               .HasColumnType("varchar(60)")
               .HasMaxLength(60)
               .IsRequired();
        }
    }
}
