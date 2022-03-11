using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class CarrerasConfiguration : IEntityTypeConfiguration<CarrerasEntity>
    {
        public void Configure(EntityTypeBuilder<CarrerasEntity> builder)
        {
            builder.HasKey(e => e.Idcarrera)
                    .HasName("carreras_pkey");

            builder.ToTable("carreras");

            builder.Property(e => e.Idcarrera).HasColumnName("idcarrera");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Idmaster)
                  .HasMaxLength(50)
                  .HasColumnName("idmaster");

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            builder.HasOne(d => d.AreasCarrera)
                .WithMany(p => p.Carreras)
                .HasForeignKey(d => d.Idarea)
                .HasConstraintName("areas_carreras_constraint");

            builder.HasOne(d => d.Master)
                .WithMany(p => p.Carreras)
                .HasForeignKey(d => d.Idmaster)
                .HasConstraintName("carreras_master_constraint");
        }
    }
}
