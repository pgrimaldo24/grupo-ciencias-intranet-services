using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class PreguntasTempConfiguration : IEntityTypeConfiguration<PreguntasTempEntity>
    {
        public void Configure(EntityTypeBuilder<PreguntasTempEntity> builder)
        {
            builder.HasNoKey();

            builder.ToTable("preguntas_temp");

            builder.Property(e => e.Alternativa)
                .HasColumnType("character varying")
                .HasColumnName("alternativa");

            builder.Property(e => e.Cabecerapregunta).HasColumnName("cabecerapregunta");

            builder.Property(e => e.Descripcion).HasColumnName("descripcion");

            builder.Property(e => e.DetalleObservacion)
                .HasColumnType("character varying")
                .HasColumnName("detalle_observacion");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Idpregunta).HasColumnName("idpregunta");
        }
    }
}
