using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class SolicitudMatriculaConfiguration : IEntityTypeConfiguration<SolicitudMatriculaEntity>
    {
        public void Configure(EntityTypeBuilder<SolicitudMatriculaEntity> builder)
        {
            builder.HasNoKey();

            builder.ToTable("solicitud_matricula");

            builder.Property(e => e.Apellidos)
                .HasColumnType("character varying")
                .HasColumnName("apellidos");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Nombres)
                .HasColumnType("character varying")
                .HasColumnName("nombres");
        }
    }
}
