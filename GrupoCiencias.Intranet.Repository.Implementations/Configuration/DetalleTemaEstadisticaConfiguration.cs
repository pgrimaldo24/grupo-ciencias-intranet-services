using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class DetalleTemaEstadisticaConfiguration : IEntityTypeConfiguration<DetalleTemaEstadisticaEntity>
    {
        public void Configure(EntityTypeBuilder<DetalleTemaEstadisticaEntity> builder)
        {
            builder.HasKey(e => new { e.Idestadistica, e.Idtema })
                  .HasName("pk_detalle_tema_estadistica");

            builder.ToTable("detalle_tema_estadistica");

            builder.HasIndex(e => new { e.Idestadistica, e.Idtema }, "detalle_tema_estadistica_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idtema, "relationship_49_fk");

            builder.HasIndex(e => e.Idestadistica, "relationship_50_fk");

            builder.Property(e => e.Idestadistica).HasColumnName("idestadistica");

            builder.Property(e => e.Idtema).HasColumnName("idtema");

            builder.Property(e => e.CantidadPreguntas).HasColumnName("cantidad_preguntas");

            builder.HasOne(d => d.IdestadisticaNavigation)
                .WithMany(p => p.DetalleTemaEstadisticas)
                .HasForeignKey(d => d.Idestadistica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle__relations_estadist");

            builder.HasOne(d => d.IdtemaNavigation)
                .WithMany(p => p.DetalleTemaEstadisticas)
                .HasForeignKey(d => d.Idtema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle__relations_tema_bib");
        }
    }
}
