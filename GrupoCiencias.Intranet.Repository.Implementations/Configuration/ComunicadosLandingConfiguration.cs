using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{

    public class ComunicadosLandingConfiguration : IEntityTypeConfiguration<ComunicadosLandingEntity>
    {
        public void Configure(EntityTypeBuilder<ComunicadosLandingEntity> builder)
        {
            builder.HasKey(e => e.Idcomunicado)
                       .HasName("comunicados_landing_pkey");

            builder.ToTable("comunicados_landing");

            builder.Property(e => e.Idcomunicado)
                .ValueGeneratedNever()
                .HasColumnName("idcomunicado");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnName("descripcion");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");

            builder.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
        }
    }
}
