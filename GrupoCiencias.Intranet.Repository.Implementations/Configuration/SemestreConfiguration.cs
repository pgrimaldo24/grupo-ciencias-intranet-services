using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class SemestreConfiguration : IEntityTypeConfiguration<SemestreEntity>
    {
        public void Configure(EntityTypeBuilder<SemestreEntity> builder)
        {
            builder.HasKey(e => e.Idsemestre)
                     .HasName("pk_semestre");

            builder.ToTable("semestre");

            builder.HasIndex(e => e.Idanio, "relationship_36_fk");

            builder.HasIndex(e => e.Idsemestre, "semestre_pk")
                .IsUnique();

            builder.Property(e => e.Idsemestre)
                .ValueGeneratedNever()
                .HasColumnName("idsemestre");

            builder.Property(e => e.Idanio).HasColumnName("idanio");

            builder.Property(e => e.NombreSemestre)
                .HasMaxLength(50)
                .HasColumnName("nombre_semestre");

            builder.HasOne(d => d.IdanioNavigation)
                .WithMany(p => p.Semestres)
                .HasForeignKey(d => d.Idanio)
                .HasConstraintName("fk_semestre_relations_anios");
        }
    }
}
