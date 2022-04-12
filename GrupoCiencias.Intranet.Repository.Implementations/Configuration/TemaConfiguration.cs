using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class TemaConfiguration : IEntityTypeConfiguration<TemaEntity>
    {
        public void Configure(EntityTypeBuilder<TemaEntity> builder)
        {
            builder.HasKey(e => e.Idtema)
                 .HasName("pk_temas");

            builder.ToTable("temas");

            builder.HasIndex(e => e.Idcurso, "relationship_1_fk");

            builder.HasIndex(e => e.Idtema, "temas_pk")
                .IsUnique();

            builder.Property(e => e.Idtema)
                .ValueGeneratedNever()
                .HasColumnName("idtema");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");

            builder.Property(e => e.NombreTema)
                .HasMaxLength(150)
                .HasColumnName("nombre_tema");

            builder.Property(e => e.Orden)
                .HasColumnName("orden")
                .HasDefaultValueSql("1");

            builder.HasOne(d => d.IdcursoNavigation)
                .WithMany(p => p.Temas)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("fk_temas_relations_cursos");
        }
    }
}
