using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class RecursosConfiguration : IEntityTypeConfiguration<RecursosEntity>
    {
        public void Configure(EntityTypeBuilder<RecursosEntity> builder)
        {
            builder.HasKey(e => e.Idrecurso)
                    .HasName("pk_recurso");

            builder.ToTable("recurso");

            builder.HasIndex(e => e.Idrecurso, "recurso_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idanio, "relationship_16_fk");

            builder.HasIndex(e => e.Idcurso, "relationship_24_fk");

            builder.Property(e => e.Idrecurso)
                .ValueGeneratedNever()
                .HasColumnName("idrecurso");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");

            builder.Property(e => e.Idanio).HasColumnName("idanio");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");

            builder.Property(e => e.Mes).HasColumnName("mes");

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            builder.Property(e => e.Orden).HasColumnName("orden");

            builder.Property(e => e.RutaRecurso)
                .HasMaxLength(400)
                .HasColumnName("ruta_recurso");

            builder.HasOne(d => d.IdanioNavigation)
                .WithMany(p => p.Recursos)
                .HasForeignKey(d => d.Idanio)
                .HasConstraintName("fk_recurso_relations_anios");

            builder.HasOne(d => d.IdcursoNavigation)
                .WithMany(p => p.Recursos)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("fk_recurso_relations_cursos");
        }
    }
}
