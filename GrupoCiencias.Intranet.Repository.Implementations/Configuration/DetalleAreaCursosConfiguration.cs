using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    class DetalleAreaCursosConfiguration : IEntityTypeConfiguration<DetalleAreaCursosEntity>
    {
        public void Configure(EntityTypeBuilder<DetalleAreaCursosEntity> builder)
        {
            builder.HasKey(e => e.Iddetalle)
                    .HasName("detalle_area_curso_pkey");

            builder.ToTable("detalle_area_curso");

            builder.Property(e => e.Iddetalle).HasColumnName("iddetalle");

            builder.Property(e => e.CantidadPreguntas).HasColumnName("cantidad_preguntas");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");

            builder.HasOne(d => d.IdareaNavigation)
                .WithMany(p => p.DetalleAreaCursos)
                .HasForeignKey(d => d.Idarea)
                .HasConstraintName("fk_area_detalle");

            builder.HasOne(d => d.IdcursoNavigation)
                .WithMany(p => p.DetalleAreaCursos)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("fk_courso_detalle");
        }
    }
}
