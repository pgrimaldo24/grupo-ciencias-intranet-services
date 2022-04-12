using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class AsistenciaEstudiantesConfiguration : IEntityTypeConfiguration<AsistenciaEstudiantesEntity>
    {
        public void Configure(EntityTypeBuilder<AsistenciaEstudiantesEntity> builder)
        {
            builder.HasNoKey();

            builder.ToTable("asistencia_estudiante");

            builder.HasIndex(e => e.Idestudiante, "relationship_52_fk");

            builder.HasIndex(e => e.Idasistencia, "relationship_53_fk");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Idasistencia).HasColumnName("idasistencia");

            builder.Property(e => e.Idestudiante).HasColumnName("idestudiante");

            builder.Property(e => e.Indicador)
                .HasMaxLength(2)
                .HasColumnName("indicador");

            builder.Property(e => e.Justificacion)
                .HasMaxLength(200)
                .HasColumnName("justificacion");

            builder.HasOne(d => d.IdasistenciaNavigation)
                .WithMany()
                .HasForeignKey(d => d.Idasistencia)
                .HasConstraintName("fk_asistenc_relations_asistenc");

            builder.HasOne(d => d.IdestudianteNavigation)
                .WithMany()
                .HasForeignKey(d => d.Idestudiante)
                .HasConstraintName("fk_asistenc_relations_estudian");
        }
    }
}
