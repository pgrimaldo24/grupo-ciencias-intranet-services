using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class AreaConocimientoConfiguration : IEntityTypeConfiguration<AreaConocimientoEntity>
    {
        public void Configure(EntityTypeBuilder<AreaConocimientoEntity> builder)
        {
            builder.HasKey(e => e.Idareaconocimiento)
                   .HasName("pk_area_conocimiento");

            builder.ToTable("area_conocimiento");

            builder.HasIndex(e => e.Idareaconocimiento, "area_conocimiento_pk")
                .IsUnique();

            builder.Property(e => e.Idareaconocimiento)
                .ValueGeneratedNever()
                .HasColumnName("idareaconocimiento");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            builder.Property(e => e.Orden).HasColumnName("orden");
        }
    }
}
