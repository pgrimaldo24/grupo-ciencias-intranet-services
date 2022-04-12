using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class DetallePreguntasConfiguration : IEntityTypeConfiguration<DetallePreguntasEntity>
    {
        public void Configure(EntityTypeBuilder<DetallePreguntasEntity> builder)
        {
            builder.HasKey(e => e.Idpregunta)
                   .HasName("pk_detalle_pregunta");

            builder.ToTable("detalle_pregunta");

            builder.HasComment("estado:\n\n1 - registrada\n2 - aprobada\n3- observada\n0-eliminada");

            builder.HasIndex(e => e.Idpregunta, "detallepregunta_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idpregunta, "idx_idpregunta_detalle_pregunta");

            builder.HasIndex(e => e.Idcabecerapregunta, "relationship_8_fk");

            builder.Property(e => e.Idpregunta)
                .ValueGeneratedNever()
                .HasColumnName("idpregunta");

            builder.Property(e => e.Alternativa)
                .HasMaxLength(200)
                .HasColumnName("alternativa");

            builder.Property(e => e.Descripcion).HasColumnName("descripcion");

            builder.Property(e => e.DetalleObservacion)
                .HasMaxLength(200)
                .HasColumnName("detalle_observacion");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Idcabecerapregunta).HasColumnName("idcabecerapregunta");

            builder.HasOne(d => d.IdcabecerapreguntaNavigation)
                .WithMany(p => p.DetallePregunta)
                .HasForeignKey(d => d.Idcabecerapregunta)
                .HasConstraintName("fk_detalle__relations_cabecera");
        }
    }
}
