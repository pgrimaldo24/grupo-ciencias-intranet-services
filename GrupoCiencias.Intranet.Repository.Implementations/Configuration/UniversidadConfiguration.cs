using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class UniversidadConfiguration : IEntityTypeConfiguration<UniversidadEntity>
    {
        public void Configure(EntityTypeBuilder<UniversidadEntity> builder)
        {
            builder.HasKey(e => e.Iduniversidad)
                  .HasName("universidad_pkey");

            builder.ToTable("universidad");

            builder.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            builder.Property(e => e.Idmaster)
                  .HasMaxLength(50)
                  .HasColumnName("idmaster");

            builder.Property(e => e.Activo)
               .HasColumnName("activo")
               .HasDefaultValueSql("1");

            builder.HasOne(d => d.Master)
                 .WithMany(p => p.Universidads)
                 .HasForeignKey(d => d.Idmaster)
                 .HasConstraintName("master__carreras_constraint");
        }
    }
}
