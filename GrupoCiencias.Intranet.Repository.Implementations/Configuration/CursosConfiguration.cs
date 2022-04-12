using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class CursosConfiguration : IEntityTypeConfiguration<CursosEntity>
    {
        public void Configure(EntityTypeBuilder<CursosEntity> builder)
        {
            builder.HasKey(e => e.Idcurso)
                     .HasName("pk_cursos");

            builder.ToTable("cursos");

            builder.HasIndex(e => e.Idcurso, "cursos_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idareaconocimiento, "relationship_28_fk");

            builder.Property(e => e.Idcurso)
                .ValueGeneratedNever()
                .HasColumnName("idcurso");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.Idareaconocimiento).HasColumnName("idareaconocimiento");

            builder.Property(e => e.NombreCorto)
                .HasMaxLength(70)
                .HasColumnName("nombre_corto");

            builder.Property(e => e.NombreCurso)
                .HasMaxLength(70)
                .HasColumnName("nombre_curso");

            builder.Property(e => e.Orden).HasColumnName("orden");

            builder.Property(e => e.OrdenExamen).HasColumnName("orden_examen");

            builder.Property(e => e.UrlTemarioBiblioteca)
                .HasMaxLength(500)
                .HasColumnName("url_temario_biblioteca");

            builder.HasOne(d => d.IdareaconocimientoNavigation)
                .WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Idareaconocimiento)
                .HasConstraintName("fk_cursos_relations_area_con");
        }
    }
}
