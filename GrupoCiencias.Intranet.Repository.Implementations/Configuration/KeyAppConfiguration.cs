using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class KeyAppConfiguration : IEntityTypeConfiguration<KeyAppEntity>
    {
        public void Configure(EntityTypeBuilder<KeyAppEntity> builder)
        {
            builder.ToTable("keyapp");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.FechaBaja)
                .HasColumnType("date")
                .HasColumnName("fechabaja");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechacreacion")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
             
            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("usuario")
                .HasDefaultValueSql("'ADMIN'::character varying");

            builder.Property(e => e.Clave)
               .HasMaxLength(50)
               .HasColumnName("clave");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");

        }
    }
}
