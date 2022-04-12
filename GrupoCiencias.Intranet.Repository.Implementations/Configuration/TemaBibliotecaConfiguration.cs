using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class TemaBibliotecaConfiguration : IEntityTypeConfiguration<TemaBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<TemaBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idtema)
                   .HasName("pk_tema_biblioteca");

            builder.ToTable("tema_biblioteca");

            builder.HasIndex(e => e.Idcurso, "relationship_47_fk");

            builder.HasIndex(e => e.Idtema, "tema_biblioteca_pk")
                .IsUnique();

            builder.Property(e => e.Idtema)
                .ValueGeneratedNever()
                .HasColumnName("idtema");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");

            builder.Property(e => e.NombreTema)
                .HasMaxLength(150)
                .HasColumnName("nombre_tema");

            builder.Property(e => e.Orden)
                .HasColumnName("orden")
                .HasDefaultValueSql("1");

            builder.HasOne(d => d.IdcursoNavigation)
                .WithMany(p => p.TemaBibliotecas)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("fk_tema_bib_relations_cursos");
        }
    }
}
