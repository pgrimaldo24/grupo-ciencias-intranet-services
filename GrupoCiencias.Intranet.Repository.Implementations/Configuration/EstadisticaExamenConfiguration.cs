using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    class EstadisticaExamenConfiguration : IEntityTypeConfiguration<EstadisticaExamenEntity>
    {
        public void Configure(EntityTypeBuilder<EstadisticaExamenEntity> builder)
        {
            builder.HasKey(e => e.Idestadistica)
                   .HasName("pk_estadistica_examen");

            builder.ToTable("estadistica_examen");

            builder.HasIndex(e => e.Idestadistica, "estadistica_examen_pk")
                .IsUnique();

            builder.HasIndex(e => e.Iduniversidad, "relationship_45_fk");

            builder.HasIndex(e => e.Idsemestre, "relationship_46_fk");

            builder.Property(e => e.Idestadistica)
                .ValueGeneratedNever()
                .HasColumnName("idestadistica");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Idsemestre).HasColumnName("idsemestre");

            builder.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

            builder.Property(e => e.NombreEstadistica)
                .HasMaxLength(100)
                .HasColumnName("nombre_estadistica");

            builder.HasOne(d => d.IdsemestreNavigation)
                .WithMany(p => p.EstadisticaExamen)
                .HasForeignKey(d => d.Idsemestre)
                .HasConstraintName("fk_estadist_relations_semestre");

            builder.HasOne(d => d.IduniversidadNavigation)
                .WithMany(p => p.EstadisticaExamen)
                .HasForeignKey(d => d.Iduniversidad)
                .HasConstraintName("fk_estadist_relations_universi");
        }
    }
}
