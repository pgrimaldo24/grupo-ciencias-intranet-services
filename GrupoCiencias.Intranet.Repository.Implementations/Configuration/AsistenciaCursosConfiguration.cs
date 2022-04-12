using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class AsistenciaCursosConfiguration : IEntityTypeConfiguration<AsistenciaCursosEntity>
    {
        public void Configure(EntityTypeBuilder<AsistenciaCursosEntity> builder)
        {
            builder.HasKey(e => e.Idasistencia)
                     .HasName("pk_asistencia_curso");

            builder.ToTable("asistencia_curso");

            builder.HasIndex(e => e.Idasistencia, "asistencia_curso_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idcurso, "relationship_54_fk");

            builder.Property(e => e.Idasistencia)
                .ValueGeneratedNever()
                .HasColumnName("idasistencia");

            builder.Property(e => e.Dia).HasColumnName("dia");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Fecha).HasColumnName("fecha");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");

            builder.HasOne(d => d.IdcursoNavigation)
                .WithMany(p => p.AsistenciaCursos)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("fk_asistenc_relations_cursos");
        }
    }
}
